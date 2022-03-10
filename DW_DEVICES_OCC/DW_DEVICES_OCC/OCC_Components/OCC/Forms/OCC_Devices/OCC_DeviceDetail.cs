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
    public partial class OCC_DeviceDetail : Form
    {
        public enum FormType
        {
            CREATE,
            ADJUST
        }

        public FormType Type = FormType.CREATE;



        public OCC_DeviceDetail()
        {
            InitializeComponent();
            BtnConfirm.Enabled = Type.Equals(FormType.ADJUST);           
        }

        private void OCC_DeviceDetail_Load(object sender, EventArgs e)
        {

        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            //UserDataModel userData = new UserDataModel();

            //if (Type.Equals(FormType.CREATE))
            //    userData.Id = Guid.NewGuid().ToString();
            //else if (Type.Equals(FormType.ADJUST))
            //{
            //    var targetUser = Tag as UserDataModel;
            //    userData.Id = targetUser.Id;
            //}                
            //userData.UserName = TextBoxDeviceName.Text;
            //userData.Password = TextBoxIP.Text;
            //userData.LoginName = TextBoxMac.Text;
            //userData.Email = TextBoxEmail.Text;
            //userData.Phonenumber = TextBoxPhoneNumber.Text;
            //userData.Remark = RichTextBoxRemark.Text;

            //userData.Sex = ComboBoxSex.SelectedIndex.ToString();

            //try
            //{
            //    var targetCompany = DataManager.Instance.CompanyDatas.First(n => n.Name.Equals(ComboBoxCompany.SelectedItem.ToString()));
            //    if (null != targetCompany)
            //    {
            //        userData.CompanyId = targetCompany.Id;
            //    }
            //    else
            //    {
            //        MessageDialog msg = new MessageDialog();
            //        msg.Message = $"未找到指定公司信息(c: {ComboBoxCompany.SelectedItem})";
            //        msg.ShowDialog();
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageDialog msg = new MessageDialog();
            //    msg.Message = $"获取公司信息失败(ex: {ex})";
            //    msg.ShowDialog();
            //    return;
            //}

            //try
            //{
            //    var targetUserType = DataManager.Instance.UserTypeDatas.First(n => n.Name.Equals(ComboBoxDeviceType.SelectedItem.ToString()));
            //    if (null != targetUserType)
            //    {
            //        userData.UserType = targetUserType.Id;
            //    }
            //    else
            //    {
            //        MessageDialog msg = new MessageDialog();
            //        msg.Message = $"未找到指定用户类型信息(u: {ComboBoxDeviceType.SelectedItem})";
            //        msg.ShowDialog();
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageDialog msg = new MessageDialog();
            //    msg.Message = $"获取用户权限信息失败(ex: {ex})";
            //    msg.ShowDialog();
            //    return;
            //}

            //userData.CreateBy = DataManager.Instance.CurrentLoginUserData.UserName;
            //userData.CreateTime = DataBaseManager.Instance.DB.GetDate();
            //userData.Updateby = DataManager.Instance.CurrentLoginUserData.UserName;
            //userData.UpdateTime = DataBaseManager.Instance.DB.GetDate();
            //userData.DelFlag = "0";

            //if (Type.Equals(FormType.CREATE))
            //{
            //    try
            //    {                    
            //        if (!DataBaseCRUDManager.Instance.TryCreateUserInfo(userData))
            //        {
            //            Debug.Info($"Create a new user {userData}");
            //        }                        
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageDialog msg = new MessageDialog();
            //        msg.Message = $"创建新用户失败(ex: {ex})";
            //        msg.ShowDialog();
            //        return;
            //    }
            //}
            //else if(Type.Equals(FormType.ADJUST))
            //{
            //    DataBaseCRUDManager.Instance.TryUpdateUserInfoById(userData);
            //}         

            //OCC_Users userForm = (OCC_Users)Owner;
            //userForm.UserListInitialize();
            //this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            this.Text = Type.Equals(FormType.ADJUST) ? "用户信息修改." : "添加新用户.";
            if (Type.Equals(FormType.ADJUST))
            {
                var targetUser = Tag as UserDataModel;
                TextBoxDeviceName.Text = targetUser.UserName;
                TextBoxIP.Text = targetUser.Password;
                TextBoxMac.Text = targetUser.LoginName;
                ComboBoxDeviceType.SelectedIndex = DataManager.Instance.UserTypeDatas.FindIndex(n => n.Id.Equals(targetUser.UserType));
            }
        }
    }
}
