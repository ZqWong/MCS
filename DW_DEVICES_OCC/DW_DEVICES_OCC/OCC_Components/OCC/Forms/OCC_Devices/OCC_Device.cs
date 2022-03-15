using DataCache;
using DataModel;
using OCC.Core;
using Sunny.UI;
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

namespace OCC.Forms
{
    public partial class OCC_Device : Form
    {
        #region 单例 & 上下文

        /// <summary>
        /// 上下文同步
        /// </summary>
        public static SynchronizationContext UiContext;

        private static OCC_Device s_instance = null;
        private static readonly object syslock = new object();
        public static OCC_Device Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (syslock)
                    {
                        if (s_instance == null)
                        {
                            s_instance = new OCC_Device();
                        }
                    }
                }
                return s_instance;
            }
        }

        #endregion


        private bool inSelectMode = false;

        private int currentSelectRowIndex = -1;

        public OCC_Device()
        {
            UiContext = SynchronizationContext.Current;
            InitializeComponent();
            RefreshDataModel();

            DeviceList.Columns[0].Visible = false;

            DataManager.Instance.GetDeviceTypes();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void RefreshDataModel()
        {
            DataManager.Instance.GetDeviceData();
            DeviceListInitialize();
        }

        /// <summary>
        /// 初始化列表
        /// </summary>
        public void DeviceListInitialize()
        {         
            DeviceList.Rows.Clear();
            
            if (DataManager.Instance.DeviceInfoCollection.Count > 0)
            {
                DeviceList.Rows.Add(DataManager.Instance.DeviceInfoCollection.Count);
                for (int i = 0; i < DataManager.Instance.DeviceInfoCollection.Count; i++)
                {
                    Debug.Info($" index {i} {DataManager.Instance.DeviceInfoCollection[i].DataModel.Name}");
                    DeviceList.Rows[i].Tag = DataManager.Instance.DeviceInfoCollection[i];
                    DeviceList.Rows[i].Cells["DeviceName"].Value = DataManager.Instance.DeviceInfoCollection[i].DataModel.Name;
                    DeviceList.Rows[i].Cells["Remark"].Value = DataManager.Instance.DeviceInfoCollection[i].DataModel.Remark;
                    DeviceList.Rows[i].Cells["IP"].Value = DataManager.Instance.DeviceInfoCollection[i].DataModel.IP;                    
                }
            }
        }

        /// <summary>
        /// 创建设备按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddDevice_Click(object sender, EventArgs e)
        {
            OCC_DeviceDetail userDetailForm = new OCC_DeviceDetail();
            userDetailForm.Owner = this;
            userDetailForm.Text = "添加设备";
            userDetailForm.ShowDialogWithMask();
        }

        /// <summary>
        /// 编辑设备按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditDevice_Click(object sender, EventArgs e)
        {
            OCC_DeviceDetail userDetailForm = new OCC_DeviceDetail();
            userDetailForm.Owner = this;
            userDetailForm.Text = "编辑设备";

            var device = DeviceList.Rows[currentSelectRowIndex].Tag as DeviceStatusCache;
            userDetailForm.DeviceData = device.DataModel;
            userDetailForm.ShowDialogWithMask();
        }

        /// <summary>
        /// 删除设备按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemoveDevice_Click(object sender, EventArgs e)
        {
            if (!inSelectMode)
            {
                inSelectMode = true;
                DeviceList.Columns[0].Visible = inSelectMode;
            }
            else
            {
                foreach (DataGridViewRow row in DeviceList.Rows)
                {
                    if (row.Cells["Selected"].EditedFormattedValue.Equals(true))
                    {
                        var data = row.Tag as DeviceStatusCache;
                        Debug.Info($"Ready to delete {data.DataModel.Id} {data.DataModel.Name} {data.DataModel.IP}  infos");
                        try
                        {
                            DataBaseCRUDManager.Instance.DeleteDeviceInfoById(data.DataModel.Id);
                        }
                        catch (Exception ex)
                        {
                            MessageDialog msg = new MessageDialog();
                            msg.Message = $"删除设备信息失败(ex: {ex})";
                            msg.ShowDialog();
                            return;
                        }
                    }
                }

                inSelectMode = false;
                DeviceList.Columns[0].Visible = inSelectMode;
                RefreshDataModel();
                //DeviceListInitialize();
            }
        }


        #region RabbitMQ Events

        private void SetSystemInfoFormDeviceList(int rowIndex, string cpuRatio, string memeoryRatio, string bootTime, string gpuRatio, string gpuMemory)
        {
            DeviceList.Rows[rowIndex].Cells["CPURatio"].Value = cpuRatio;
            DeviceList.Rows[rowIndex].Cells["MemoryRatio"].Value = memeoryRatio;
            DeviceList.Rows[rowIndex].Cells["BootTime"].Value = bootTime;
            DeviceList.Rows[rowIndex].Cells["GPURatio"].Value = gpuRatio;
            DeviceList.Rows[rowIndex].Cells["GPUMemory"].Value = gpuMemory;
        }

        /// <summary>
        /// 接收到的消息
        /// </summary>
        /// <param name="state"></param>
        public void UpdateDeviceSystemInfoEventHandler(object state)
        {
            var ip = ((Handler.C_SystemStateEventHandler.UpdateSystemStateArgs)state).ip;
            var cpu = ((Handler.C_SystemStateEventHandler.UpdateSystemStateArgs)state).cpu;
            var memory = ((Handler.C_SystemStateEventHandler.UpdateSystemStateArgs)state).memory;
            var tickCount = ((Handler.C_SystemStateEventHandler.UpdateSystemStateArgs)state).tickCount;
            var gpu_ratio = ((Handler.C_SystemStateEventHandler.UpdateSystemStateArgs)state).gpu_ratio;
            var gpu_memory_ratio = ((Handler.C_SystemStateEventHandler.UpdateSystemStateArgs)state).gpu_memory_ratio;

            var target = DataManager.Instance.DeviceInfoCollection.FirstOrDefault(d => d.DataModel.IP.Equals(ip));
            if (null != target)
            {
                // 有返回说明已经开机/
                DeviceList.Rows[target.Index].Cells["ConnectionState"].Value = global::OCC.Properties.Resources.switch_开;

                DeviceList.Rows[target.Index].Cells["NetDelay"].Value = target.Ping;

                SetSystemInfoFormDeviceList(
                        target.Index,
                        string.Format("{0}%", cpu.ToString("f2")),
                        string.Format("{0}G", (memory / 1000).ToString("f2")),
                        string.Format("{0}h:{1}m", (int)(tickCount / 1000 / 3600), (int)(tickCount / 1000 % 3600 / 60)),
                        string.Format("{0}%", gpu_ratio.ToString("f2")),
                        string.Format("{0}%", gpu_memory_ratio.ToString("f2")));                    
            }
        }

        /// <summary>
        /// 接收到的消息
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
                    DeviceList.Rows[device.Index].Cells["ConnectionStatus "].Value =
                        connect ?
                        global::OCC.Properties.Resources.switch_开 :
                        global::OCC.Properties.Resources.switch_关;
                }
            }
        }


        #endregion

        /// <summary>
        /// 获取行选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectRowIndex = e.RowIndex;
        }
    }
}
