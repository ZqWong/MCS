using DataCache;
using DataModel;
using OCC.Core;
using OCC.Forms.OCC_Devices;
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





        public const string FORM_NAME = "首页";
        
        /// <summary>
        /// 上下文同步
        /// </summary>
        public static SynchronizationContext UiContext;




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
            DataManager.Instance.GetDeviceData();

            DataGridViewDevice.Rows.Clear();

            DataGridViewDevice.Rows.Add(DataManager.Instance.DeviceInfoCollection.Count);

            if (DataManager.Instance.DeviceInfoCollection.Count > 0)
            {
                for (int i = 0; i < DataManager.Instance.DeviceInfoCollection.Count; i++)
                {
                    Debug.Info($" index {i} {DataManager.Instance.DeviceInfoCollection[i].DataModel.Name}");
                    DataGridViewDevice.Rows[i].Tag = DataManager.Instance.DeviceInfoCollection[i].DataModel;
                    DataGridViewDevice.Rows[i].Cells["DeviceName"].Value = DataManager.Instance.DeviceInfoCollection[i].DataModel.Name;
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
            DataManager.Instance.DeviceInfoCollection.ForEach(d => ips.Add(d.DataModel.IP));
            DevicePingManager.Instance.PingDevices(ips);

            UpdateDevicePowerStatus();
            SendDeviceConnectStatusEvent();
        }

        /// <summary>
        /// 更新设备电源状态
        /// </summary>
        private void UpdateDevicePowerStatus()
        {
            foreach (DeviceStatusCache deviceInfo in DataManager.Instance.DeviceInfoCollection)
            {
                Debug.Error($" DevicePingManager.Instance.IPDict {deviceInfo.DataModel.IP}");

#if DEBUG
                foreach (var ip in DevicePingManager.Instance.IPDict)
                {
                    Debug.Error($"ip connected {ip}");
                }
#endif
                
                if (DevicePingManager.Instance.IPDict.ContainsKey(deviceInfo.DataModel.IP))
                {
                    if (DataManager.Instance.DeviceInfoCollection[deviceInfo.Index].PowerStatus == DevicePowerStatus.CLOSEING)
                        return;

                    if (null != deviceInfo)
                    {
                        DataGridViewDevice.Rows[deviceInfo.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_开;
                        OCC_Device.Instance.DeviceList.Rows[deviceInfo.Index].Cells["OpenOrClosePCState"].Value = global::OCC.Properties.Resources.switch_开;
                        DataManager.Instance.DeviceInfoCollection[deviceInfo.Index].PowerStatus = DevicePowerStatus.OPENED;
                        DataManager.Instance.DeviceInfoCollection[deviceInfo.Index].Ping = DevicePingManager.Instance.IPDict[deviceInfo.DataModel.IP];
                    }
                }
                else
                {
                    if (DataManager.Instance.DeviceInfoCollection[deviceInfo.Index].PowerStatus == DevicePowerStatus.OPENING)
                        return;

                    if (null != deviceInfo)
                    {
                        DataGridViewDevice.Rows[deviceInfo.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_关;
                        OCC_Device.Instance.DeviceList.Rows[deviceInfo.Index].Cells["OpenOrClosePCState"].Value = global::OCC.Properties.Resources.switch_关;
                        DataManager.Instance.DeviceInfoCollection[deviceInfo.Index].PowerStatus = DevicePowerStatus.CLOSED;
                        DataManager.Instance.DeviceInfoCollection[deviceInfo.Index].Ping = string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// 向已开机的设备发送消息
        /// 更新设备连接集控状态
        /// </summary>
        private void SendDeviceConnectStatusEvent()
        {
            List<DeviceStatusCache> devicePowerOnCollection = DataManager.Instance.DeviceInfoCollection.FindAll(d => d.PowerStatus.Equals(DevicePowerStatus.OPENED));

            foreach (DeviceStatusCache deviceStatus in devicePowerOnCollection)
            {
                // 发送获取客户端状态的消息
                //RabbitMQEventBus.GetSingleton().Trigger<R_C_SystemStateData>(showIP, new R_C_SystemStateData());//直接通过事件总线触发
                RabbitMQManager.Instance.Trigger(deviceStatus.DataModel.IP, new OCC_TO_CLIENT.R_C_SystemStateData());
            }
        }

        /// <summary>
        /// 已开机设备回传设备信息消息
        /// 更新客户端发送过来的消息
        /// </summary>
        /// <param name="state"></param>
        public void UpdateDeviceSystemInfoEventHandler(object state)
        {
            string ip = ((Handler.C_SystemStateEventHandler.UpdateSystemStateArgs)state).ip;

            List<DeviceStatusCache> devicePowerOnCollection = DataManager.Instance.DeviceInfoCollection.FindAll(d => d.PowerStatus.Equals(DevicePowerStatus.OPENED));

            foreach (DeviceStatusCache deviceStatus in devicePowerOnCollection)
            {                
                if (deviceStatus.DataModel.IP.Equals(ip))
                {
                    Debug.Info($"UpdateDeviceSystemInfoEventHandler ip {ip} name {deviceStatus.DataModel.Name} row index {deviceStatus.Index} Connected");                    
                    Debug.Info($"Rows {deviceStatus.Index} {deviceStatus.DataModel.Name} Cells[ConnectionStatus] switch_开 ");
                    this.DataGridViewDevice.Rows[deviceStatus.Index].Cells["ConnectionStatus"].Value = global::OCC.Properties.Resources.switch_开;                    
                    DataGridViewDevice.Refresh();
                }                
            }
        }

        /// <summary>
        /// 通过RabbitMQ插件获取的设备连接状态，主要是关机
        /// </summary>
        /// <param name="state"></param>
        public void UpdateDeviceConnectionState(object state)
        {
            string ip = ((EventHandler.RemotePluginEventHandler.UpdateConnectionStateArgs)state).ip;
            bool connect = ((EventHandler.RemotePluginEventHandler.UpdateConnectionStateArgs)state).connect;

            if (null != ip)
            {
                var device = DataManager.Instance.DeviceInfoCollection.FirstOrDefault(d => d.DataModel.IP.Equals(ip));
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
            var targetDevice = DataManager.Instance.DeviceInfoCollection.FirstOrDefault(d => d.Index.Equals(e.RowIndex));
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
 