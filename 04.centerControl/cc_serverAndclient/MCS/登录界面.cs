using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using System;
using System.Windows.Forms;

namespace MCS
{
    public partial class 登录界面 : Form
    {
        UserBLL _UserBLL = new UserBLL();

        public 登录界面()
        {
            InitializeComponent();
        }

        private bool CheckBeforeLogin()
        {
            bool checkResult = true;

            // 验证控件是否为空
            checkResult = Check.isEmpty(this.txtUserName, "用户名");

            if (!checkResult) return checkResult;

            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtUserName, "用户名");

            if (!checkResult) return checkResult;

            // 验证控件是否为空
            checkResult = Check.isEmpty(this.txtPassword, "密码");

            if (!checkResult) return checkResult;

            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtPassword, "密码");

            if (!checkResult) return checkResult;

            UserModel um = new UserModel();
            um.UserName = this.txtUserName.Text.Trim();
            um.Password = this.txtPassword.Text.Trim();

            int count = _UserBLL.IsUserExist(um);

            if (count > 0)
            {
                checkResult = true;
            }
            else
            {

                Alert.alert("用户名或密码错误！");
                checkResult = false;
            }

            return checkResult;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // TODO: 测试暂时隐藏，发布时显示 - start
            //// 登录前验证
            //bool checkResult = CheckBeforeLogin();

            //if (checkResult)
            //{
            //    GlobalClass.Instance._LoginUserName = this.txtUserName.Text.Trim();
            //    string level = _UserBLL.GetUserLevelByUserName(this.txtUserName.Text.Trim());

            //    if (level == EnumUserLevel.Admin.ToString())
            //    {
            //        GlobalClass.Instance._IsHasAdminLevel = true;
            //    }
            //    else
            //    {
            //        GlobalClass.Instance._IsHasAdminLevel = false;

            //    }

            //    this.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态
            //    this.Close();    //关闭登录窗口
            //}
            //else
            //{
            //    this.DialogResult = DialogResult.None;
            //}
            // TODO: 测试暂时隐藏，发布时显示 - end

            Global.Instance.LoginUserName = "Admin";
            Global.Instance.IsHasAdminLevel = true;
            this.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态
            this.Close();    //关闭登录窗口
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
