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
    public partial class OCC_Group : UIPage
    {
        #region 单例 & 上下文

        /// <summary>
        /// 上下文同步
        /// </summary>
        public static SynchronizationContext UiContext;

        private static OCC_Group s_instance = null;
        private static readonly object syslock = new object();
        public static OCC_Group Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (syslock)
                    {
                        if (s_instance == null)
                        {
                            s_instance = new OCC_Group();
                        }
                    }
                }
                return s_instance;
            }
        }

        #endregion

        private bool inGroupSelectMode = false;
        private bool inExecuteSelectMode = false;

        public GroupDataCache CurrentSelectedGroupData;

        public GroupDeviceExecuteDataModel CurrentSelectDeviceExecuteData;

        public OCC_Group()
        {
            UiContext = SynchronizationContext.Current;
            InitializeComponent();

            DataGridViewGroup.Columns[0].Visible = false;
            DataGridViewDeviceBinded.Columns[0].Visible = false;

            RefreshDataModel();
        }

        public void RefreshDataModel()
        {
            DataManager.Instance.GetGroupData();
            AppDataGridViewInitialize();
            if (DataGridViewGroup.Rows.Count > 0)
            {
                CurrentSelectedGroupData = DataGridViewGroup.Rows[0].Tag as GroupDataCache;
            }
            UiContext.Post(OCC_Main.Instance.ComboBoxGroupInitialize, null);
        }

        private void AppDataGridViewInitialize()
        {
            DataGridViewGroup.Rows.Clear();
            if (DataManager.Instance.GroupInfoCollection.Count > 0)
            {
                DataGridViewGroup.Rows.Add(DataManager.Instance.GroupInfoCollection.Count);
                for (int i = 0; i < DataManager.Instance.GroupInfoCollection.Count; i++)
                {
                    Debug.Info($" index {i} {DataManager.Instance.GroupInfoCollection[i].GroupId}");
                    DataGridViewGroup.Rows[i].Tag = DataManager.Instance.GroupInfoCollection[i];
                    DataGridViewGroup.Rows[i].Cells["GroupName"].Value = DataManager.Instance.GroupInfoCollection[i].GroupData.Name;
                    DataGridViewGroup.Rows[i].Cells["Remark"].Value = DataManager.Instance.GroupInfoCollection[i].GroupData.Remark;
                }
                //默认显示第一个APP所绑定的设备列表
                DeviceDataGridViewInitialize(DataManager.Instance.GroupInfoCollection[0]);
            }
        }

        /// <summary>
        /// 初始化设备绑定列表
        /// </summary>
        /// <param name="data"></param>
        private void DeviceDataGridViewInitialize(GroupDataCache data)
        {
            DataGridViewDeviceBinded.Rows.Clear();
            data.GroupExecuteDatas = data.GroupExecuteDatas.OrderBy(g => g.SortId).ToList();
            if (data.GroupExecuteDatas.Count > 0)
            {
                DataGridViewDeviceBinded.Rows.Add(data.GroupExecuteDatas.Count);
                for (int i = 0; i < data.GroupExecuteDatas.Count; i++)
                {
                    Debug.Info($" index {i} {data.GroupExecuteDatas[i].Id} {data.GroupExecuteDatas[i].DeviceId} {data.GroupExecuteDatas[i].ExecuteId}");

                    DataGridViewDeviceBinded.Rows[i].Tag = data.GroupExecuteDatas[i];

                    var deviceData = DataManager.Instance.GetDeviceDataById(data.GroupExecuteDatas[i].DeviceId);
                    DataGridViewDeviceBinded.Rows[i].Cells["DeviceName"].Value = deviceData.DataModel.Name;
                    DataGridViewDeviceBinded.Rows[i].Cells["Delay"].Value = data.GroupExecuteDatas[i].Delay;

                    var execute = DataManager.Instance.GetDeviceExecuteById(data.GroupExecuteDatas[i].ExecuteId);
                    DataGridViewDeviceBinded.Rows[i].Cells["Execute"].Value = execute.Name;

                    DataGridViewDeviceBinded.Rows[i].Cells["Sort"].Value = data.GroupExecuteDatas[i].SortId;
                }
            }
        }

        private void ButtonAddGroup_Click(object sender, EventArgs e)
        {
            OCC_GroupDetail userDetailForm = new OCC_GroupDetail();
            userDetailForm.Owner = this;
            userDetailForm.Text = "添加分组";
            userDetailForm.ShowDialogWithMask();
        }

        private void ButtonRemoveGroup_Click(object sender, EventArgs e)
        {
            if (!inGroupSelectMode)
            {
                inGroupSelectMode = true;
                DataGridViewGroup.Columns[0].Visible = inGroupSelectMode;
            }
            else
            {
                foreach (DataGridViewRow row in DataGridViewGroup.Rows)
                {
                    if (row.Cells["Selected"].EditedFormattedValue.Equals(true))
                    {
                        var data = row.Tag as GroupDataCache;
                        Debug.Info($"Ready to delete {data.GroupId} {data.GroupData.Name} infos");
                        try
                        {
                            DataBaseCRUDManager.Instance.DeleteGroupInfoById(data.GroupData.Id);
                        }
                        catch (Exception ex)
                        {
                            ShowErrorDialog($"删除分组信息失败(ex: {ex})");
                            throw ex;
                        }
                    }
                }

                inGroupSelectMode = false;
                DataGridViewGroup.Columns[0].Visible = inGroupSelectMode;
                RefreshDataModel();
                //DeviceListInitialize();
                OCC_Main.Instance.DataGridViewDevicesInitialize();
            }
        }

        private void ButtonEditGroup_Click(object sender, EventArgs e)
        {
            OCC_GroupDetail userDetailForm = new OCC_GroupDetail();
            userDetailForm.Owner = this;
            userDetailForm.Text = "编辑分组";
            
            userDetailForm.GroupData = CurrentSelectedGroupData.GroupData;
            userDetailForm.ShowDialogWithMask();
        }

        /// <summary>
        /// 获取当前选择的行数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.Info($"DataGridViewGroup Select Row {e.RowIndex}");

            if (e.RowIndex.Equals(-1))
                return;


            CurrentSelectedGroupData = DataGridViewGroup.Rows[e.RowIndex].Tag as GroupDataCache;

            CurrentSelectDeviceExecuteData = null;

            if (null != CurrentSelectedGroupData)
            {
                DeviceDataGridViewInitialize(CurrentSelectedGroupData);
            }
        }


        private void ButtonAddExecute_Click(object sender, EventArgs e)
        {
            if (null == CurrentSelectedGroupData)
            {
                ShowWarningDialog($"请选择有效的的分组");
                return;
            }
            OCC_GroupDeviceExecuteDetail groupDeviceExecute = new OCC_GroupDeviceExecuteDetail();
            groupDeviceExecute.Owner = this;
            groupDeviceExecute.GroupId = CurrentSelectedGroupData.GroupId;
            groupDeviceExecute.Text = "添加设备操作";
            groupDeviceExecute.ShowDialogWithMask();
        }

        private void ButtonDeleteExecute_Click(object sender, EventArgs e)
        {
            if (!inExecuteSelectMode)
            {
                inExecuteSelectMode = true;
                DataGridViewDeviceBinded.Columns[0].Visible = inExecuteSelectMode;
            }
            else
            {
                foreach (DataGridViewRow row in DataGridViewDeviceBinded.Rows)
                {
                    if (row.Cells["ExecuteSelected"].EditedFormattedValue.Equals(true))
                    {
                        var data = row.Tag as GroupDeviceExecuteDataModel;
                        Debug.Info($"Ready to delete {data.GroupId} infos");

                        try
                        {
                            DataBaseCRUDManager.Instance.DeleteGroupDeviceExecuteById(data.Id);
                        }
                        catch (Exception ex)
                        {
                            ShowErrorDialog($"删除分组操作信息失败(ex: {ex})");
                            throw ex;
                        }

                    }
                }

                inExecuteSelectMode = false;
                DataGridViewDeviceBinded.Columns[0].Visible = inExecuteSelectMode;
                RefreshDataModel();
                //DeviceListInitialize();
                OCC_Main.Instance.DataGridViewDevicesInitialize();
            }            
        }

        private void ButtonEditExecute_Click(object sender, EventArgs e)
        {
            if (null == CurrentSelectedGroupData)
            {
                ShowWarningDialog($"请选择有效的的分组");
                return;
            }

            OCC_GroupDeviceExecuteDetail groupDeviceExecute = new OCC_GroupDeviceExecuteDetail();
            groupDeviceExecute.Owner = this;
            groupDeviceExecute.Text = "编辑设备操作";
            groupDeviceExecute.GroupId = CurrentSelectedGroupData.GroupId;
            groupDeviceExecute.GroupData = CurrentSelectDeviceExecuteData;
            groupDeviceExecute.ShowDialogWithMask();

        }

        private void DataGridViewDeviceBinded_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.Info($"DataGridViewDeviceBinded Select Row {e.RowIndex}");

            if (e.RowIndex.Equals(-1))
                return;

            CurrentSelectDeviceExecuteData = DataGridViewDeviceBinded.Rows[e.RowIndex].Tag as GroupDeviceExecuteDataModel;
        }
    }
}
