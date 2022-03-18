using DataCache;
using DataModel;
using OCC.Core;
using RabbitMQEvent;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms
{
    public partial class OCC_Main : UIPage
    {
        #region 单例 & 上下文

        /// <summary>
        /// 上下文同步
        /// </summary>
        public static SynchronizationContext UiContext;

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
        /// 创建串口连接
        /// </summary>
        private Dictionary<int, SerialPort> serialDictionary = new Dictionary<int, SerialPort>();

        private Dictionary<string, string> portDictionary = new Dictionary<string, string>();

        public OCC_Main()
        {
            UiContext = SynchronizationContext.Current;

            InitializeComponent();

            DataManager.Instance.GetDeviceData();
            DataGridViewDevicesInitialize();
       
            PCDeviceStatusTimer.Enabled = true;
            PCDeviceStatusTimer.Interval = Convert.ToInt32(1000); //ms

            HardwareDeviceStatusTimer.Enabled = true;
            HardwareDeviceStatusTimer.Interval = Convert.ToInt32(10000); //ms
        }

        /// <summary>
        /// 设备列表初始化
        /// </summary>
        public void DataGridViewDevicesInitialize()
        {         
            DataGridViewDevice.Rows.Clear();

            DataGridViewDevice.Rows.Add(DataManager.Instance.DeviceInfoCollection.Count);

            if (DataManager.Instance.DeviceInfoCollection.Count > 0)
            {
                for (int i = 0; i < DataManager.Instance.DeviceInfoCollection.Count; i++)
                {
                    Debug.Info($" index {i} {DataManager.Instance.DeviceInfoCollection[i].DataModel.Name}");
                    DataGridViewDevice.Rows[i].Tag = DataManager.Instance.DeviceInfoCollection[i];
                    DataGridViewDevice.Rows[i].Cells["DeviceName"].Value = DataManager.Instance.DeviceInfoCollection[i].DataModel.Name;

                    // 创建串口缓存，用来检测串口连接设备的连接状态
                    UpdateHardwareConnect(DataManager.Instance.DeviceInfoCollection[i]);
                }
            }

#if DEBUG
            foreach (var item in SerialPort.GetPortNames())
            {
                Debug.Info($"SerialPort connected: {item}");
            }
#endif 
        }

 

        #region 选择系统

        /// <summary>
        /// 刷新系统数据 通过上下文模式
        /// </summary>
        /// <param name="args"></param>
        public void ComboBoxAppInitialize(object args)
        {
            ComboBoxApp.Items.Clear();
            foreach (var item in DataManager.Instance.AppDeviceBindedCollection)
            {                
                ComboBoxApp.Items.Add(item.AppData.AppName);
            }
        }

        /// <summary>
        /// 系统开始
        /// </summary> 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAppStart_Click(object sender, EventArgs e)
        {
            if (GetCheckBoxCheckedCount().Equals(0))
            {
                ShowWarningDialog("请选择一个或多个要启动的设备");
            }
            else if (-1 != ComboBoxApp.SelectedIndex)
            {
                Debug.Info($"Current Select App {ComboBoxApp.SelectedItem}");

                var appDeviceBinded = DataManager.Instance.GetAppDeviceBindedCacheByAppName(ComboBoxApp.SelectedItem.ToString());

                // 先遍历出用户已选择的设备id                
                for (int i = 0; i < DataGridViewDevice.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(DataGridViewDevice.Rows[i].Cells["Selected"].Selected) == true)
                    {
                        var cache = DataGridViewDevice.Rows[i].Tag as DeviceStatusCache;

                        var config = appDeviceBinded.DeviceBindData.FirstOrDefault(d => d.DeviceId.Equals(cache.DataModel.Id));

                        if (null != config)
                        {
                            var mi = RemoteProcessLanuchHelper.CreateRemoteLanuchAppTask(cache.DataModel.IP, config.Path, true);
                            OCC_Main.Instance.Invoke(mi);
                        }
                        else
                        {
                            ShowErrorNotifier($"设备 {cache.DataModel.Name} 启动系统 {appDeviceBinded.AppData.AppName} 失败！请检查设备类型，确认是否正确配置启动路径。");
                        }
                    }                        
                }
            }
            else
            {
                ShowWarningDialog("请选择要培训的系统");
            }
        }

        private int GetCheckBoxCheckedCount()
        {
            int selectCount = 0;

            for (int i = 0; i < this.DataGridViewDevice.Rows.Count; i++)
            {
                if (Convert.ToBoolean(DataGridViewDevice.Rows[i].Cells["Selected"].Value) == true)
                {
                    selectCount++;
                }
            }

            return selectCount;
        }

        #endregion

        #region 选择分组

        /// <summary>
        /// 刷新组分数据 通过上下文模式
        /// </summary>
        /// <param name="args"></param>
        public void ComboBoxGroupInitialize(object args)
        {
            ComboBoxGroup.Items.Clear();

        }

        /// <summary>
        /// 分组开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGroupStart_Click(object sender, EventArgs e)
        {
            if (-1 != ComboBoxGroup.SelectedIndex)
            {
                Debug.Info($"Current Select App {ComboBoxGroup.SelectedItem}");
            }
            else
            {
                ShowWarningDialog("请选择要启动的分组");
            }
        }

        #endregion

        #region 计时器

        /// <summary>
        /// PC设备状态检测 计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceStatusTimer_Tick(object sender, EventArgs e)
        {
            List<string> ips = new List<string>();
            DataManager.Instance.DeviceInfoCollection.ForEach(d => ips.Add(d.DataModel.IP));
            DevicePingManager.Instance.PingDevices(ips);

            UpdateDevicesPowerStatus();
            SendDeviceConnectStatusEvent();
        }

        /// <summary>
        /// 硬件设备状态检测 计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HardwareDeviceStatusTimer_Tick(object sender, EventArgs e)
        {
            UpdateHardwareConnectStatus();
        }

        #endregion

        /// <summary>
        /// 更新设备电源状态
        /// </summary>
        private void UpdateDevicesPowerStatus()
        {
            foreach (DeviceStatusCache deviceInfo in DataManager.Instance.DeviceInfoCollection)
            {

                if (deviceInfo.DataModel.DeviceType == 1)
                {
                    UpdatePcPowerStatus(deviceInfo);
                }
                else
                {
                    UpdateHardwareConnect(deviceInfo);
                }
            }
        }

        private void UpdatePcPowerStatus(DeviceStatusCache data)
        {
            if (null == data)
                return;

            //#if DEBUG
            //                Debug.Info($" DevicePingManager.Instance.IPDict {deviceInfo.DataModel.IP}");
            //#endif                
            if (DevicePingManager.Instance.ConnectedIPDictionary.ContainsKey(data.DataModel.IP))
            {
                if (DataManager.Instance.DeviceInfoCollection[data.Index].PowerStatus == DevicePowerStatus.CLOSEING)
                    return;

                DataGridViewDevice.Rows[data.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_开;
                OCC_Device.Instance.DeviceList.Rows[data.Index].Cells["OpenOrClosePCState"].Value = global::OCC.Properties.Resources.switch_开;
                DataManager.Instance.DeviceInfoCollection[data.Index].PowerStatus = DevicePowerStatus.OPENED;
                DataManager.Instance.DeviceInfoCollection[data.Index].Ping = DevicePingManager.Instance.ConnectedIPDictionary[data.DataModel.IP];                
            }
            else
            {
                // 这里是为了避免新加入的设备会造成数据列表不匹配的问题
                if (DataManager.Instance.DeviceInfoCollection.Count != DataGridViewDevice.Rows.Count)
                    return;

                if (DataManager.Instance.DeviceInfoCollection[data.Index].PowerStatus == DevicePowerStatus.OPENING)
                    return;

                DataGridViewDevice.Rows[data.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_关;
                OCC_Device.Instance.DeviceList.Rows[data.Index].Cells["OpenOrClosePCState"].Value = global::OCC.Properties.Resources.switch_关;
                DataManager.Instance.DeviceInfoCollection[data.Index].PowerStatus = DevicePowerStatus.CLOSED;
                DataManager.Instance.DeviceInfoCollection[data.Index].Ping = string.Empty;                
            }
        }

        /// <summary>
        /// 更新非电脑设备连接状态
        /// </summary>
        private void UpdateHardwareConnect(DeviceStatusCache data)
        {
            // 如果是串口类型则创建串口连接
            if (data.DataModel.ConnectType.Equals(1))
            {
                SerialPort outer;
                SerialPortExecute.CreateSerialConnect(data.DataModel.IP, data.DataModel.Serial, data.DataModel.Buad, (sender, e) => {
                },
                out outer);
                serialDictionary.Add(data.Index, outer);

                if (outer.IsOpen)
                {
                    DataGridViewDevice.Rows[data.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_开;
                    DataGridViewDevice.Rows[data.Index].Cells["ConnectionStatus"].Value = global::OCC.Properties.Resources.switch_开;
                }
            }
            else if (data.DataModel.ConnectType.Equals(0))
            {
                if (DevicePingManager.Instance.ConnectedIPDictionary.ContainsKey(data.DataModel.IP))
                {
                    DataGridViewDevice.Rows[data.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_开;
                    DataGridViewDevice.Rows[data.Index].Cells["ConnectionStatus"].Value = global::OCC.Properties.Resources.switch_开;
                }
                else
                {
                    DataGridViewDevice.Rows[data.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_关;
                    DataGridViewDevice.Rows[data.Index].Cells["ConnectionStatus"].Value = global::OCC.Properties.Resources.switch_关;
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
                if (deviceStatus.DataModel.DeviceType == 1)
                {
                    // 发送获取客户端状态的消息
                    //RabbitMQEventBus.GetSingleton().Trigger<R_C_SystemStateData>(showIP, new R_C_SystemStateData());//直接通过事件总线触发
                    //Debug.Info($"{this} Trigger {deviceStatus.DataModel.IP} R_C_SystemStateData");
                    RabbitMQManager.Instance.Trigger(deviceStatus.DataModel.IP, new OCC_TO_CLIENT.R_C_SystemStateData());
                }
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
                    DataGridViewDevice.Rows[device.Index].Cells["ConnectionStatus"].Value =
                        connect ?
                        global::OCC.Properties.Resources.switch_开 :
                        global::OCC.Properties.Resources.switch_关;
                }
            }
        }

        /// <summary>
        /// 更新硬件设备连接状态
        /// </summary>
        private void UpdateHardwareConnectStatus()
        {
            foreach (DeviceStatusCache deviceInfo in DataManager.Instance.DeviceInfoCollection)
            {
                if (deviceInfo.DataModel.DeviceType != 1)
                {
                    // 网口连接
                    if (deviceInfo.DataModel.ConnectType == 1)
                    {

                    }
                    // 串口连接
                    else if(deviceInfo.DataModel.ConnectType == 2)
                    {
                        SerialPort serial;
                        if (HardwareConnectController.SerialPortConnect(deviceInfo.DataModel.IP, deviceInfo.DataModel.Buad, out serial))
                        {
                            DataGridViewDevice.Rows[deviceInfo.Index].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.switch_开;
                            OCC_Device.Instance.DeviceList.Rows[deviceInfo.Index].Cells["OpenOrClosePCState"].Value = global::OCC.Properties.Resources.switch_开;
                        }                     
                    }
                    else
                    {

                    }
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
            if (e.RowIndex.Equals(-1))
                return;

            // 点击了列表中的关机按钮
            // TODO: 是否需要添加确认窗口 在关机
            if (DataGridViewDevice.Columns[e.ColumnIndex].Name == "SwitchButton")
            {
                var deviceData = DataGridViewDevice.Rows[e.RowIndex].Tag as DeviceStatusCache;
                if (deviceData.DataModel.DeviceType == 1)
                {
                    RemotePowerSet(sender, e);
                }                
            }
            if (DataGridViewDevice.Columns[e.ColumnIndex].Name == "Selected")
            {
                //MessageBox.Show("行: " + e.RowIndex.ToString() + ", 列: " + e.ColumnIndex.ToString() + "; 选中了");
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
                // 关机
                if (targetDevice.PowerStatus == DevicePowerStatus.OPENED)
                {
                    try
                    {
                        if (DevicePowerController.RemotePowerOff(targetDevice.DataModel.IP))
                        {
                            DataGridViewDevice.Rows[e.RowIndex].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.开_关机中;
                            targetDevice.PowerStatus = DevicePowerStatus.CLOSEING;
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorNotifier($"关闭设备 {DataGridViewDevice.Rows[e.RowIndex].Cells["DeviceName"].Value} 失败!\n{ex}");
                        throw;
                    }                
                }
                // 开机
                else if (targetDevice.PowerStatus == DevicePowerStatus.CLOSED)
                {
                    try
                    {
                        DevicePowerController.RemotePowerOn(targetDevice.DataModel.MAC);
                        DataGridViewDevice.Rows[e.RowIndex].Cells["SwitchButton"].Value = global::OCC.Properties.Resources.开_关机中;
                        targetDevice.PowerStatus = DevicePowerStatus.OPENING;
                    }
                    catch (Exception ex)
                    {
                        ShowErrorNotifier($"启动设备 {DataGridViewDevice.Rows[e.RowIndex].Cells["DeviceName"].Value} 失败!\n{ex}");
                        throw;
                    }
                   
                }
                else if (targetDevice.PowerStatus == DevicePowerStatus.OPENING)
                {
                    ShowWarningNotifier($"设备 {targetDevice.DataModel.IP} 正在启动中!");
                }
                else if (targetDevice.PowerStatus == DevicePowerStatus.CLOSEING)
                {
                    ShowWarningNotifier($"设备 {targetDevice.DataModel.IP} 正在关闭中!");
                }
                else
                {
                    ShowWarningNotifier($"设备 {targetDevice.DataModel.IP} 发生了未知错误!");
                }

            }


        }
    }
}
 