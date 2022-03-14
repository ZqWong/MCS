using DataModel;
using RabbitMQEvent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms.OCC_Main
{
    public partial class OCC_Main : Form
    {
        public class UpdateSystemStateArgs
        {
            public string ip { get; set; }
            public float cpu { get; set; }
            public float memory { get; set; }
            public int tickCount { get; set; }
            public float gpu_ratio { get; set; }
            public float gpu_memory_ratio { get; set; }
        }

        public class UpdateConnectionStateArgs
        {
            public string ip { get; set; }
            public bool connect { get; set; }
        }


        #region 单例
        private static OCC_Main s_instance = null;
        private static readonly object syslock = new object();
        public static OCC_Main Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (syslock)
                    {
                        if (s_instance == null)
                        {
                            s_instance = new OCC_Main();
                        }
                    }
                }
                return s_instance;
            }
        }

        #endregion

        /// <summary>
        /// 开机状态枚举
        /// </summary>
        public enum DevicePowerStatus
        {
            OPENED = 0,  //开机状态
            CLOSED,      //关机状态
            CLOSEING,    //关机中
            OPENING      //开机中
        }

        /// <summary>
        /// 设备数据绑定结构
        /// </summary>
        public class DeviceStatusCache
        {
            public DeviceStatusCache() { }
            public DeviceStatusCache(int index, DevicePowerStatus powerStatus, DeviceDataModel dataModel)
            {
                Index = index;
                PowerStatus = powerStatus;
                DataModel = dataModel;
            }

            public int Index;
            public DevicePowerStatus PowerStatus = DevicePowerStatus.CLOSED;
            public DeviceDataModel DataModel;
        }

        public const string FORM_NAME = "首页";
        
        /// <summary>
        /// 上下文同步
        /// </summary>
        public static SynchronizationContext UiContext;

        /// <summary>
        /// 设备状态缓存
        /// </summary>
        public List<DeviceStatusCache> DeviceInfoCollection = new List<DeviceStatusCache>();
        /// <summary>
        /// 设备数据
        /// </summary>
        private List<DeviceDataModel> deviceInfoCoollection;

        public OCC_Main()
        {
            UiContext = SynchronizationContext.Current;

            InitializeComponent();
                    
            DataGridViewDevicesInitialize();

            DeviceStatusTimer.Enabled = true;
            DeviceStatusTimer.Interval = Convert.ToInt32(1000); //ms
        }


        /// <summary>
        /// 设备列表初始化
        /// </summary>
        private void DataGridViewDevicesInitialize()
        {
            DataGridViewDevice.Rows.Clear();

            deviceInfoCoollection = DataBaseCRUDManager.Instance.GetAllActivatedDeviceInfo();



            if (deviceInfoCoollection.Count > 0)
            {
                DataGridViewDevice.Rows.Add(deviceInfoCoollection.Count);

                for (int i = 0; i < deviceInfoCoollection.Count; i++)
                {
                    // 对设备状态进行缓存
                    DeviceInfoCollection.Add(new DeviceStatusCache(i, DevicePowerStatus.CLOSED, deviceInfoCoollection[i]));
                    Debug.Info($" index {i} {deviceInfoCoollection[i].Name}");
                    DataGridViewDevice.Rows[i].Tag = deviceInfoCoollection[i];                    
                    DataGridViewDevice.Rows[i].Cells["DeviceName"].Value = deviceInfoCoollection[i].Name;                    
                }
            }
        }

        /// <summary>
        /// 设备状态检测 计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceStatusTimer_Tick(object sender, EventArgs e)
        {
            List<string> ips = new List<string>();
            DeviceInfoCollection.ForEach(d => ips.Add(d.DataModel.IP));
            DevicePingManager.Instance.PingDevices(ips);

            UpdateDevicePowerStatus();
            SendDeviceConnectStatusEvent();
        }

        /// <summary>
        /// 更新设备电源状态
        /// </summary>
        private void UpdateDevicePowerStatus()
        {
            foreach (DeviceDataModel deviceInfo in deviceInfoCoollection)
            {
                Debug.Error($" DevicePingManager.Instance.IPDict {deviceInfo.IP}");

#if DEBUG
                foreach (var ip in DevicePingManager.Instance.IPDict)
                {
                    Debug.Error($"ip connected {ip}");
                }
#endif
                var target = DeviceInfoCollection.FirstOrDefault(d => d.DataModel.IP.Equals(deviceInfo.IP));

                if (DevicePingManager.Instance.IPDict.ContainsKey(deviceInfo.IP))
                {
                    if (DeviceInfoCollection[target.Index].PowerStatus == DevicePowerStatus.CLOSEING)
                        return;

                    if (null != target)
                    {
                        DataGridViewDevice.Rows[target.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_开;
                        DeviceInfoCollection[target.Index].PowerStatus = DevicePowerStatus.OPENED;
                    }
                }
                else
                {
                    if (DeviceInfoCollection[target.Index].PowerStatus == DevicePowerStatus.OPENING)
                        return;

                    if (null != target)
                    {
                        DataGridViewDevice.Rows[target.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_关;
                        DeviceInfoCollection[target.Index].PowerStatus = DevicePowerStatus.CLOSED;
                    }
                }
            }
        }

        /// <summary>
        /// 更新设备连接集控状态
        /// </summary>
        private void SendDeviceConnectStatusEvent()
        {
            List<DeviceStatusCache> devicePowerOnCollection =  DeviceInfoCollection.FindAll(d => d.PowerStatus.Equals(DevicePowerStatus.OPENED));

            foreach (DeviceStatusCache deviceStatus in devicePowerOnCollection)
            {
                // 发送获取客户端状态的消息
                //RabbitMQEventBus.GetSingleton().Trigger<R_C_SystemStateData>(showIP, new R_C_SystemStateData());//直接通过事件总线触发
                RabbitMQManager.Instance.Trigger(deviceStatus.DataModel.IP, new OCC_TO_CLIENT.R_C_SystemStateData());
            }
        }

        /// <summary>
        /// 更新客户端发送过来的消息
        /// </summary>
        /// <param name="state"></param>
        public void UpdateDeviceSystemInfoEventHandler(object state)
        {
            string ip = ((UpdateSystemStateArgs)state).ip;
            float cpu = ((UpdateSystemStateArgs)state).cpu;
            float memory = ((UpdateSystemStateArgs)state).memory;
            int tickCount = ((UpdateSystemStateArgs)state).tickCount;
            float gpu_ratio = ((UpdateSystemStateArgs)state).gpu_ratio;
            float gpu_memory_ratio = ((UpdateSystemStateArgs)state).gpu_memory_ratio;

            List<DeviceStatusCache> devicePowerOnCollection = DeviceInfoCollection.FindAll(d => d.PowerStatus.Equals(DevicePowerStatus.OPENED));

            foreach (DeviceStatusCache deviceStatus in devicePowerOnCollection)
            {                
                // 发送获取客户端状态的消息
                //RabbitMQEventBus.GetSingleton().Trigger<R_C_SystemStateData>(showIP, new R_C_SystemStateData());//直接通过事件总线触发
                //RabbitMQManager.Instance.Trigger(deviceStatus.DataModel.IP, new OCC_TO_CLIENT.R_C_SystemStateData());
                if (deviceStatus.DataModel.IP.Equals(ip))
                {
                    Debug.Info($"UpdateDeviceSystemInfoEventHandler ip {ip} name {deviceStatus.DataModel.Name} row index {deviceStatus.Index} Connected");                    
                    Debug.Info($"Rows {deviceStatus.Index} {deviceStatus.DataModel.Name} Cells[ConnectionStatus] switch_开 ");
                    this.DataGridViewDevice.Rows[deviceStatus.Index].Cells["ConnectionStatus"].Value = global::OCC.Properties.Resources.switch_开;                    
                    DataGridViewDevice.Refresh();
                }                
            }
            //Debug.Info($"ip {((UpdateSystemStateArgs)state).ip} {((UpdateSystemStateArgs)state).cpu} {((UpdateSystemStateArgs)state)}");
        }

        public void UpdateDeviceConnectionState(object state)
        {
            string ip = ((UpdateConnectionStateArgs)state).ip;
            bool connect = ((UpdateConnectionStateArgs)state).connect;

            if (null != ip)
            {
                var device = DeviceInfoCollection.FirstOrDefault(d => d.DataModel.IP.Equals(ip));
                if (null != device)
                {
                    DataGridViewDevice.Rows[device.Index].Cells["ConnectionStatus "].Value =
                        connect ?
                        global::OCC.Properties.Resources.switch_开 :
                        global::OCC.Properties.Resources.switch_关;
                }
            }
        }


        /// <summary>
        /// 当表格中有对象被点击时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewDevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 点击了列表中的关机按钮
            // TODO: 是否需要添加确认窗口 在关机
            if (DataGridViewDevice.Columns[e.ColumnIndex].Name == "SwitchButton")
            {
                RemotePowerSet(sender, e);
            }
            if (DataGridViewDevice.Columns[e.ColumnIndex].Name == "Selected")
            {
                MessageBox.Show("行: " + e.RowIndex.ToString() + ", 列: " + e.ColumnIndex.ToString() + "; 选中了");
            }
        }

        /// <summary>
        /// 远程开关机设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemotePowerSet(object sender, DataGridViewCellEventArgs e)
        {
            var targetDevice = DeviceInfoCollection.FirstOrDefault(d => d.Index.Equals(e.RowIndex));
            if (null != targetDevice)
            {
                // 开机
                if (targetDevice.PowerStatus == DevicePowerStatus.OPENED)
                {
                    if (DevicePowerManager.RemotePowerOff(targetDevice.DataModel.IP))
                    {
                        DataGridViewDevice.Rows[e.RowIndex].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.开_关机中;
                        targetDevice.PowerStatus = DevicePowerStatus.CLOSEING;
                    }
                    else
                    {
                        MessageBox.Show($"关闭计算机 {targetDevice.DataModel.IP} 过程中发生错误!");
                    }
                }
                // 关机
                else if (targetDevice.PowerStatus == DevicePowerStatus.CLOSED)
                {
                    DevicePowerManager.RemotePowerOn(targetDevice.DataModel.MAC);
                    DataGridViewDevice.Rows[e.RowIndex].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.开_关机中;
                    targetDevice.PowerStatus = DevicePowerStatus.OPENING;
                }
                else if (targetDevice.PowerStatus == DevicePowerStatus.OPENING)
                {
                    MessageBox.Show($"计算机 {targetDevice.DataModel.IP} 正在启动中!");
                }
                else if (targetDevice.PowerStatus == DevicePowerStatus.CLOSEING)
                {
                    MessageBox.Show($"计算机 {targetDevice.DataModel.IP} 正在关闭中!");
                }
                else
                {
                    MessageBox.Show($"计算机 {targetDevice.DataModel.IP} 发生了未知错误!");
                }

            }


        }
    }
}
 