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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms
{
    public partial class OCC_GroupDeviceExecuteDetail : UIEditForm
    {
        private bool isEdit = false;

        private GroupDeviceExecuteDataModel groupData;

        public int GroupId { get; set; }

        public GroupDeviceExecuteDataModel GroupData
        {
            get
            {
                if (null == groupData)
                {
                    groupData = new GroupDeviceExecuteDataModel();

                    groupData.GroupId = GroupId;
                    groupData.DeviceId = DataManager.Instance.GetDeviceDataByName(ComboBoxGroupDevice.SelectedItem.ToString()).DataModel.Id;
                    groupData.Delay = int.Parse(TextBoxDelay.Text);
                    groupData.ExecuteId = DataManager.Instance.GetDeviceExecuteByName(ComboBoxExecute.SelectedItem.ToString()).Id;
                    groupData.SortId = int.Parse(TextBoxSort.Text);

                    groupData.CreateTime = DataBaseManager.Instance.DB.GetDate();
                    groupData.DelFlag = "0";
                }
                isEdit = false;
                return groupData;
            }
            set
            {
                if (null == groupData)
                {
                    groupData = new GroupDeviceExecuteDataModel();
                }
                isEdit = true;

                GroupId = value.GroupId;

                groupData.Id = value.Id;
                groupData.GroupId = value.GroupId;
                groupData.DeviceId = value.DeviceId;
                groupData.Delay = value.Delay;
                groupData.ExecuteId = value.ExecuteId;
                groupData.SortId = value.SortId;

                groupData.Updateby = value.Updateby;
                groupData.UpdateTime = value.UpdateTime;
                groupData.CreateBy = value.CreateBy;
                groupData.CreateTime = value.CreateTime;
                groupData.DelFlag = value.DelFlag;

                ViewUIIfHasData();
            }
        }

        private void ViewUIIfHasData()
        {
            ComboBoxGroupDevice.SelectedItem = DataManager.Instance.GetDeviceDataById(groupData.DeviceId).DataModel.Name;
            
            ComboBoxExecute.SelectedItem = DataManager.Instance.GetDeviceExecuteById(groupData.ExecuteId).Name;

            TextBoxDelay.Text = groupData.Delay.ToString();
            TextBoxSort.Text = groupData.SortId.ToString();
        }

        public OCC_GroupDeviceExecuteDetail()
        {
            InitializeComponent();

            foreach (var device in DataManager.Instance.DeviceInfoCollection)
            {                
                ComboBoxGroupDevice.Items.Add(device.DataModel.Name);
            }



            ButtonOkClick += ButtonOkClickHandler;
        }

        /// <summary>
        /// 设备选择变更时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxGroupDevice_SelectedValueChanged(object sender, EventArgs e)
        {
            var deviceName = ComboBoxGroupDevice.SelectedItem.ToString();
            var deviceData = DataManager.Instance.GetDeviceDataByName(deviceName);
            var executes = DataManager.Instance.GetTargetDeiveExecuteByDeviceTypeId(deviceData.DataModel.DeviceType);
            foreach (var execute in executes)
            {
                ComboBoxExecute.Items.Add(execute.Name);
            }
        }


        /// <summary>
        /// 确认按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOkClickHandler(object sender, EventArgs e)
        {
            if (null == ComboBoxGroupDevice.SelectedItem || null == ComboBoxExecute.SelectedItem)
            {
                ShowWarningDialog("请对数据进行选择或添加", false);
                return;
            }
                    
            var device = DataManager.Instance.GetDeviceDataByName(ComboBoxGroupDevice.SelectedItem.ToString());
            if (null == device)
            {
                ShowWarningDialog("请选择正确的设备", false);
                return;
            }


            var execute = DataManager.Instance.GetDeviceExecuteByName(ComboBoxExecute.SelectedItem.ToString());
            if (null == execute)
            {
                ShowWarningDialog("请选择正确的操作", false);
                return;
            }

            if (!isEdit)
            {
                GroupData.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
                GroupData.CreateTime = DataBaseManager.Instance.DB.GetDate();
            }

            GroupData.Updateby = DataManager.Instance.CurrentLoginUserData.UserName;
            GroupData.UpdateTime = DataBaseManager.Instance.DB.GetDate();
            GroupData.DelFlag = "0";

            try
            {
                if (isEdit)
                {
                    try
                    {
                        DataBaseCRUDManager.Instance.TryUpdateGroupDeviceExecute(groupData);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                else
                {
                    try
                    {
                        DataBaseCRUDManager.Instance.TryCreateGroupDeviceExecuteInfo(groupData);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog();
                msg.Message = $"创建新设备失败(ex: {ex})";
                msg.ShowDialog();
                return;
            }



            var owner = Owner as OCC_Group;
            owner.RefreshDataModel();
            Close();
        }


    }
}
