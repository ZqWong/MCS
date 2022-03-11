using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms.OCC_Main
{
    public partial class OCC_Main : LockedSingletonFormClass<OCC_Main>
    {
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
        public class DeviceStatusStruct
        {
            public DeviceStatusStruct() { }
            public DeviceStatusStruct(int index, DevicePowerStatus powerStatus, DeviceDataModel dataModel)
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
        /// 设备状态缓存
        /// </summary>
        public List<DeviceStatusStruct> DeviceInfoCollection = new List<DeviceStatusStruct>();
        /// <summary>
        /// 设备数据
        /// </summary>
        private List<DeviceDataModel> deviceInfoCoollection;

        public OCC_Main()
        {
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
                    DeviceInfoCollection.Add(new DeviceStatusStruct(i, DevicePowerStatus.CLOSED, deviceInfoCoollection[i]));
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
 