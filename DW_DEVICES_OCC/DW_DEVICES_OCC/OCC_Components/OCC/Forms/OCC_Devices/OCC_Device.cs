using DataModel;
using OCC.Core;
using OCC.Forms.OCC_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms.OCC_Devices
{
    public partial class OCC_Device : Form
    {
        public bool InDelectBatchesMode = false;
        public OCC_Device()
        {
            InitializeComponent();
            
            // 开启定时器
            //PingTimer.Enabled = true;
            //PingTimer.Interval = Convert.ToInt32(1000);

        }


        private void OCC_Device_Load(object sender, EventArgs e)
        {
            DeviceList.Columns[0].Visible = false;
            DeviceListInitialize();



        }

        private void OCC_Device_Closed(object sender, EventArgs e)
        {
            PingTimer.Stop();
        }


        public void DeviceListInitialize()
        {
            Debug.Info("加载用户数据");

            List<DeviceDataModel> deviceInfoCoollection;
            try
            {
                DeviceList.Rows.Clear();
                deviceInfoCoollection = DataBaseCRUDManager.Instance.GetAllActivatedDeviceInfo();
                if (deviceInfoCoollection.Count >= 1)
                {
                    DeviceList.Rows.Add(deviceInfoCoollection.Count);

                    for (int i = 0; i < deviceInfoCoollection.Count; i++)
                    {
                        Debug.Info($" index {i} {deviceInfoCoollection[i].Name}");
                        DeviceList.Rows[i].Tag = deviceInfoCoollection[i];
                        DeviceList.Rows[i].Cells["DeviceName"].Value = deviceInfoCoollection[i].Name;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Error($"Get device info failed {ex}");
            }
        }

        private void AddDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OCC_DeviceDetail userDetailForm = new OCC_DeviceDetail();
            userDetailForm.Owner = this;
            userDetailForm.Type = OCC_DeviceDetail.FormType.CREATE;
            userDetailForm.ShowDialog();
        }

        private void DeleteDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!InDelectBatchesMode)
            {
                InDelectBatchesMode = true;
                DeviceList.Columns[0].Visible = InDelectBatchesMode;
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
                            DataBaseCRUDManager.Instance.DeleteUserInfoById(data.Id);
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

                InDelectBatchesMode = false;
                DeviceList.Columns[0].Visible = InDelectBatchesMode;
                DeviceListInitialize();
            }
        }


        #region Mouse right button functions

        private int index = -1;

        private void DeviceList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    DeviceList.ClearSelection();
                    DeviceList.Rows[e.RowIndex].Selected = true;
                    DeviceList.CurrentCell = DeviceList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    DeviceRightClick.Show(MousePosition.X, MousePosition.Y);

                    index = e.RowIndex;

                    Debug.Info($"UserList_CellMouseUp Selected index {index} {DeviceList.Rows[e.RowIndex].Cells["Username"].Value}");
                }
            }
        }


        private void AujustDeviceInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var targetDevice = DeviceList.Rows[index].Tag as DeviceDataModel;
            OCC_DeviceDetail userDetailForm = new OCC_DeviceDetail();
            userDetailForm.Owner = this;
            userDetailForm.Type = OCC_DeviceDetail.FormType.ADJUST;
            userDetailForm.Tag = targetDevice;
            userDetailForm.ShowDialog();
            index = -1;
        }

        private void DeleteDeiveInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var targetDevice = DeviceList.Rows[index].Tag as DeviceDataModel;
            DataBaseCRUDManager.Instance.DeleteUserInfoById(targetDevice.Id);
            index = -1;

            DeviceListInitialize();
        }

        #endregion

        private void PingTimer_Tick(object sender, EventArgs e)
        {
            DevicePingManager.Instance.PingDevices(new List<string> { "192.168.0.198", "192.168.0.181", "192.168.0.148", "192.168.0.140" });
            foreach (var ping in DevicePingManager.Instance.IPDict)
            {
                Debug.Error($"ping myself ip: {ping.Key} ping: {ping.Value}");
            }
        }
    }
}
