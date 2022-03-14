﻿using DataModel;
using OCC.Core;
using OCC.Forms.OCC_Controls;
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

namespace OCC.Forms.OCC_Devices
{
    public partial class OCC_Device : Form
    {
        /// <summary>
        /// 上下文同步
        /// </summary>
        public static SynchronizationContext UiContext;

        #region 单例
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



        public bool InSelectMode = false;
        public OCC_Device()
        {
            UiContext = SynchronizationContext.Current;
            InitializeComponent();
            DeviceListInitialize();

            DataManager.Instance.GetDeviceTypes();
        }


        private void OCC_Device_Load(object sender, EventArgs e)
        {
            DeviceList.Columns[0].Visible = false;
            //DeviceListInitialize();
        }

        private void OCC_Device_Closed(object sender, EventArgs e)
        {
           
        }


        public void DeviceListInitialize()
        {
            DataManager.Instance.GetDeviceData();
            DeviceList.Rows.Clear();

            DeviceList.Rows.Add(DataManager.Instance.DeviceInfoCollection.Count);

            if (DataManager.Instance.DeviceInfoCollection.Count > 0)
            {
                for (int i = 0; i < DataManager.Instance.DeviceInfoCollection.Count; i++)
                {
                    Debug.Info($" index {i} {DataManager.Instance.DeviceInfoCollection[i].DataModel.Name}");
                    DeviceList.Rows[i].Tag = DataManager.Instance.DeviceInfoCollection[i].DataModel;
                    DeviceList.Rows[i].Cells["DeviceName"].Value = DataManager.Instance.DeviceInfoCollection[i].DataModel.Name;
                    DeviceList.Rows[i].Cells["Remark"].Value = DataManager.Instance.DeviceInfoCollection[i].DataModel.Remark;
                    DeviceList.Rows[i].Cells["IP"].Value = DataManager.Instance.DeviceInfoCollection[i].DataModel.IP;                    
                }
            }
        }

        #region Mouse right button functions

        private int index = -1;

        //private void DeviceList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    //if (e.Button == MouseButtons.Right)
        //    //{
        //    //    if (e.RowIndex >= 0)
        //    //    {
        //    //        DeviceList.ClearSelection();
        //    //        DeviceList.Rows[e.RowIndex].Selected = true;
        //    //        DeviceList.CurrentCell = DeviceList.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //    //        DeviceRightClick.Show(MousePosition.X, MousePosition.Y);

        //    //        index = e.RowIndex;

        //    //        Debug.Info($"UserList_CellMouseUp Selected index {index} {DeviceList.Rows[e.RowIndex].Cells["Username"].Value}");
        //    //    }
        //    //}
        //}

        #endregion

        private void PingTimer_Tick(object sender, EventArgs e)
        {
            DevicePingManager.Instance.PingDevices(new List<string> { "192.168.0.198", "192.168.0.181", "192.168.0.148", "192.168.0.140" });
            foreach (var ping in DevicePingManager.Instance.IPDict)
            {
                Debug.Error($"ping myself ip: {ping.Key} ping: {ping.Value}");
            }
        }

        private void ButtonAddDevice_Click(object sender, EventArgs e)
        {
            OCC_DeviceDetail userDetailForm = new OCC_DeviceDetail();
            userDetailForm.Owner = this;
            userDetailForm.Type = OCC_DeviceDetail.FormType.CREATE;
            userDetailForm.Text = "添加设备";
            userDetailForm.ShowDialog();
        }

        private void ButtonEditDevice_Click(object sender, EventArgs e)
        {
                                                
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRemoveDevice_Click(object sender, EventArgs e)
        {
            if (!InSelectMode)
            {
                InSelectMode = true;
                DeviceList.Columns[0].Visible = InSelectMode;
            }
            else
            {
                foreach (DataGridViewRow row in DeviceList.Rows)
                {
                    if (row.Cells["Selected"].EditedFormattedValue.Equals(true))
                    {
                        var data = row.Tag as DeviceDataModel;
                        Debug.Info($"Ready to delete {data.Id} {data.Name} {data.IP}  infos");
                        try
                        {
                            DataBaseCRUDManager.Instance.DeleteDeviceInfoById(data.Id);
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

                InSelectMode = false;
                DeviceList.Columns[0].Visible = InSelectMode;
                DeviceListInitialize();
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
    }
}
