using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MCS
{
    public partial class 用户添加 : Form
    {
        #region 全局变量
        /// <summary>
        /// 当前逻辑
        /// </summary>
        private string _CurrentLogic = "";

        UserBLL _UserBLL = new UserBLL();

        private UserModel _UserModel = new UserModel();

        #endregion

        public 用户添加()
        {
            InitializeComponent();
        }

        public 用户添加(string todoLogic, UserModel model)
        {
            InitializeComponent();

            if (todoLogic == "add")
            {
                this.Text = "用户添加界面";
                this.btnAdd.Text = "添 加";
                this.btnDelete.Visible = false;
            }
            else if (todoLogic == "upd")
            {
                this.Text = "用户修改界面";
                this.btnAdd.Text = "修 改";
                this.btnDelete.Visible = true;

                string userName = model.UserName;
                string id = model.ID;
                string password = "";

                DataSet ds = _UserBLL.GetAllUserInfoByID(id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    password = ds.Tables[0].Rows[0][UserModel.ColumnName_Password].ToString();
                }

                this.txtUserName.Text = userName;
                this.txtPassword.Text = password;

                _UserModel.ID = id;
                _UserModel.UserName = userName;
                _UserModel.Password = password;
            }

            _CurrentLogic = todoLogic;
        }


        #region 逻辑验证
        /// <summary>
        /// 添加用户前验证
        /// </summary>
        /// <returns>true验证通过，false验证失败</returns>
        private bool CheckBeforeAddUserInfo()
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


            return checkResult;
        }

        #endregion

        #region Button点击事件
        /// <summary>
        /// 添加考生所属公司信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddExamineeCompanyInfo_Click(object sender, EventArgs e)
        {
            // 添加用户前验证
            bool checkResult = CheckBeforeAddUserInfo();

            // 验证通过
            if (checkResult)
            {
                // 执行添加操作
                if (_CurrentLogic == "add")
                {
                    // 判断用户名是否存在
                    int count = _UserBLL.IsUserNameExist(this.txtUserName.Text.Trim());

                    if (count > 0)
                    {
                        Alert.noteMsg("用户名已存在！");
                        this.txtUserName.Focus();
                        this.txtUserName.BackColor = Color.Red;
                        return;
                    }

                    UserModel um = new UserModel();
                    um.UserName = this.txtUserName.Text.Trim();
                    um.Password = this.txtPassword.Text.Trim();
                    um.Level = EnumUserLevel.Normal.ToString();

                    int count2 = _UserBLL.AddUserInfo(um);

                    if (count2 > 0)
                    {
                        Alert.noteMsg("添加成功！");

                        用户管理 parentForm = (用户管理)this.Owner;

                        parentForm.ChildFormClose();

                        this.Close();
                    }
                    else
                    {
                        Alert.errorMsg("添加失败！");
                    }
                }
                // 执行修改操作
                else if (_CurrentLogic == "upd")
                {
                    _UserModel.UserName = this.txtUserName.Text.Trim();
                    _UserModel.Password = this.txtPassword.Text.Trim();

                    int count = _UserBLL.UpdUserInfo(_UserModel);

                    if (count > 0)
                    {
                        Alert.noteMsg("修改成功！");

                        用户管理 parentForm = (用户管理)this.Owner;

                        parentForm.ChildFormClose();

                        this.Close();
                    }
                    else
                    {
                        Alert.errorMsg("修改失败！");
                    }
                }
            }
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

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Alert.confirm("是否确认删除？"))
            {
                int count = _UserBLL.DelUserInfo(_UserModel.ID);

                if (count > 0)
                {
                    Alert.noteMsg("删除成功！");

                    用户管理 parentForm = (用户管理)this.Owner;

                    parentForm.ChildFormClose();

                    this.Close();
                }
                else
                {
                    Alert.errorMsg("删除失败！");
                }
            }

        }

        #endregion

        //private void txtUserName_TextChanged(object sender, EventArgs e)
        //{
        //    Check.isEmpty(this.txtUserName, "用户名");
        //    Check.CheckSpecialCharacters(this.txtUserName, "用户名");

        //    if (_CurrentLogic == "add")
        //    {
        //        // 判断用户名是否存在
        //        int count = _UserBLL.IsUserNameExist(this.txtUserName.Text.Trim());

        //        if (count > 0)
        //        {
        //            Alert.noteMsg("用户名已存在！");
        //            this.txtUserName.Focus();
        //            this.txtUserName.BackColor = Color.Red;
        //        }
        //    }
        //}

        //private void txtPassword_TextChanged(object sender, EventArgs e)
        //{
        //    Check.isEmpty(this.txtPassword, "密码");
        //    Check.CheckSpecialCharacters(this.txtPassword, "密码");
        //}
    }
}
