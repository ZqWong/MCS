using DataModel;
using OCC.Core;
using OCC.Forms.OCC_Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms.OCC_APPs
{
    public partial class OCC_APPDetail : Form
    {
        public OCC_APPDetail()
        {
            InitializeComponent();
      
        }

        private void OCC_AppDetail_Load(object sender, EventArgs e)
        {

        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            OCC_Device deviceForm = (OCC_Device)Owner;

            AppDataModel appDataModel = new AppDataModel();

            appDataModel.Id = Guid.NewGuid().ToString();
            appDataModel.AppName = TextBoxAPPName.Text;
            appDataModel.AppPath = TextBoxAPPPath.Text;

            appDataModel.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
            appDataModel.Updateby = DataManager.Instance.CurrentLoginUserData.UserName;
            appDataModel.CreateTime = DataBaseManager.Instance.DB.GetDate();
            appDataModel.UpdateTime = DataBaseManager.Instance.DB.GetDate();
            appDataModel.DelFlag = "0";

            DataBaseCRUDManager.Instance.TryCreateAppInfo(appDataModel);

            deviceForm.DeviceListInitialize();
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OCC_AppDetail_Shown(object sender, EventArgs e)
        {
            //this.Text = Type.Equals(FormType.ADJUST) ? "用户信息修改." : "添加新用户.";
            //if (Type.Equals(FormType.ADJUST))
            //{
            //    var targetUser = Tag as UserDataModel;
            //    TextBoxAPPPath.Text = targetUser.UserName;
            //    TextBoxIP.Text = targetUser.Password;
            //    TextBoxMac.Text = targetUser.LoginName;
            //    ComboBoxDeviceType.SelectedIndex = DataManager.Instance.UserTypeDatas.FindIndex(n => n.Id.Equals(targetUser.UserType));
            //}
        }
    }
}
