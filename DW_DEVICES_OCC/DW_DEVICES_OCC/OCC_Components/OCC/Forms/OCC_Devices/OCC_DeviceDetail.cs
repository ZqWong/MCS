using DataModel;
using OCC.Core;
using OCC.Forms.OCC_Controls;
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

namespace OCC.Forms.OCC_Devices
{
    public partial class OCC_DeviceDetail : UIEditForm
    {
        public enum FormType
        {
            CREATE,
            ADJUST
        }

        public FormType Type = FormType.CREATE;



        private DeviceDataModel deviceData;
        public DeviceDataModel DeviceData
        {
            get
            {
                if (null == deviceData)
                {
                    deviceData = new DeviceDataModel();
                }
                deviceData.Id = Guid.NewGuid().ToString();
                deviceData.Name = TextBoxDeviceName.Text;
                deviceData.IP = TextBoxIP.Text;
                deviceData.MAC = TextBoxMAC.Text;
                deviceData.Remark = TextBoxRemark.Text;

                return deviceData;
            }
            set
            {
                deviceData.Id = value.Id;
                deviceData.Name = value.Name;
                deviceData.MAC = value.MAC;
                deviceData.IP = value.IP;
                deviceData.Remark = value.Remark;
                deviceData.DeviceType = value.DeviceType;
                deviceData.Updateby = value.Updateby;
                deviceData.CreateBy = value.CreateBy;
                deviceData.CreateTime = value.CreateTime;
            }

        }


        protected override bool CheckData()
        {
            return CheckEmpty(TextBoxDeviceName, "请输入设备名")
                && CheckEmpty(TextBoxIP, "请输入设备IP")
                && CheckEmpty(ComboBoxDeviceType, "请选择有效设备类型");
        }


        public OCC_DeviceDetail()
        {
            InitializeComponent();

            foreach (var item in DataManager.Instance.DeviceTypeCollection)
            {
                ComboBoxDeviceType.Items.Add(item.Name);
            }
            ComboBoxDeviceType.SelectedIndex = 0;
            ButtonOkClick += OCC_DeviceDetail_ButtonOkClick;   
        }

        private void OCC_DeviceDetail_ButtonOkClick(object sender, EventArgs e)
        {
            //DeviceData


            var deviceType = DataManager.Instance.DeviceTypeCollection.FirstOrDefault(t => t.Name.Equals(ComboBoxDeviceType.SelectedItem));
            if (null == deviceType)
            {
                ShowWarningDialog("请选择正确的设备类型", false);
                return;
            }

            DeviceData.DeviceType = deviceType.Id;

            DeviceData.Id = Guid.NewGuid().ToString();
            DeviceData.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
            DeviceData.CreateTime = DataBaseManager.Instance.DB.GetDate();
            DeviceData.Updateby = DataManager.Instance.CurrentLoginUserData.UserName;
            DeviceData.UpdateTime = DataBaseManager.Instance.DB.GetDate();
            DeviceData.DelFlag = "0";

            try
            {
                if (!DataBaseCRUDManager.Instance.TryCreateDeviceInfo(DeviceData))
                {
                    Debug.Info($"Create a new user {DeviceData}");
                }
                
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog();
                msg.Message = $"创建新设备失败(ex: {ex})";
                msg.ShowDialog();
                return;                
            }

            var owner = Owner as OCC_Device;
            owner.DeviceListInitialize();
            Close();
        }


        private void TextBoxLoginName_TextChanged(object sender, EventArgs e)
        {
            //bool isExist = DataBaseCRUDManager.Instance.CheckUsernameExist(TextBoxMac.Text);
            //if (!Type.Equals(FormType.ADJUST))
            //{
            //    labelUserRepetition.Visible = isExist;
            //}
            //CheckUserInfoCorrect();
        }

        private void ComboBoxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckUserInfoCorrect();

        }

        private void ComboBoxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckUserInfoCorrect();

        }

        private void TextBoxUsername_TextChanged(object sender, EventArgs e)
        {
            CheckUserInfoCorrect();

        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CheckUserInfoCorrect();

        }

        private bool CheckUserInfoCorrect()
        {
            //if (Type.Equals(FormType.ADJUST))
            //{
            //    BtnConfirm.Enabled = true;
            //    return true;
            //}

            //bool ret = !DataBaseCRUDManager.Instance.CheckUsernameExist(TextBoxMac.Text) &&
            //        ComboBoxDeviceType.SelectedIndex != -1 &&
            //        ComboBoxCompany.SelectedIndex != -1 &&
            //        TextBoxDeviceName.Text != String.Empty &&
            //        TextBoxIP.Text != String.Empty;

            //BtnConfirm.Enabled = ret;

            //return ret;

            return true;
        }

        private void OCC_UserDetail_Shown(object sender, EventArgs e)
        {
            //this.Text = Type.Equals(FormType.ADJUST) ? "用户信息修改." : "添加新用户.";
            //if (Type.Equals(FormType.ADJUST))
            //{
            //    var targetUser = Tag as UserDataModel;
            //    TextBoxDeviceName.Text = targetUser.UserName;
            //    TextBoxIP.Text = targetUser.Password;
            //    TextBoxMac.Text = targetUser.LoginName;
            //    ComboBoxDeviceType.SelectedIndex = DataManager.Instance.UserTypeDatas.FindIndex(n => n.Id.Equals(targetUser.UserType));
            //}
        }

        private void TextBoxIP_Leave(object sender, EventArgs e)
        {
            var mac = NetworkHelper.GetMacAddress(TextBoxIP.Text);
            DeviceData.MAC = mac;
            TextBoxMAC.Text = mac;
        }
    }
}
