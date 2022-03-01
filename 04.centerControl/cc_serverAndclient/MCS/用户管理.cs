using Common.Model;
using MCS.DB.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MCS
{
    public partial class 用户管理 : Form
    {
        UserBLL _UserBLL = new UserBLL();
        Dictionary<string, string> _UserDic = new Dictionary<string, string>();

        
        public 用户管理()
        {
            InitializeComponent();

            // 加载用户信息
            LoadUserInfo();
        }

        /// <summary>
        /// 子窗体关闭
        /// </summary>
        public void ChildFormClose()
        {
            // 刷新用户ListBox
            RefreshUserListBox();
        }

        /// <summary>
        /// 刷新考生所属公司列表
        /// </summary>
        private void RefreshUserListBox()
        {
            LoadUserInfo();
        }

        /// <summary>
        /// 加载用户信息
        /// </summary>
        private void LoadUserInfo()
        {
            this.UserList.Items.Clear();
            _UserDic.Clear();

            DataSet ds = _UserBLL.GetAllUserInfo();

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    string userID = ds.Tables[0].Rows[i][UserModel.ColumnName_ID].ToString();
                    string userName = ds.Tables[0].Rows[i][UserModel.ColumnName_UserName].ToString();

                    this.UserList.Items.Add(userName);

                    if (!_UserDic.ContainsKey(userName))
                    {
                        _UserDic.Add(userName, userID);
                    }
                }
            }
        }

        #region Button点击事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddExamineeCompanyInfo_Click(object sender, EventArgs e)
        {
            用户添加 form = new 用户添加("add", null);
            form.ShowDialog(this);
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

        private void UserList_DoubleClick(object sender, EventArgs e)
        {
            if (this.UserList.Items.Count > 0 && this.UserList.SelectedItem != null)
            {
                UserModel model = new UserModel();
                model.UserName = this.UserList.SelectedItem.ToString();

                string value;
                _UserDic.TryGetValue(this.UserList.SelectedItem.ToString(), out value);

                model.ID = value;

                用户添加 form = new 用户添加("upd", model);
                form.ShowDialog(this);
            }
        }


        #endregion

        private void 用户管理_Load(object sender, EventArgs e)
        {

        }
    }
}
