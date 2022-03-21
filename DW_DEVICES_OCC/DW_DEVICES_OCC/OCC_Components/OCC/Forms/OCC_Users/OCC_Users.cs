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
    public partial class OCC_Users : UIPage
    {
        public bool InDelectBatchesMode = false;
        private int currentSelectRowIndex = -1;

        public OCC_Users()
        {
            InitializeComponent();
        }


        private void OCC_Users_Load(object sender, EventArgs e)
        {
            UserList.Columns[0].Visible = false;
            UserListInitialize();
        }

        public void UserListInitialize()
        {
            Debug.Info("加载用户数据");

            List<UserDataModel> userInfoCoollection;
            try
            {
                UserList.Rows.Clear();
                userInfoCoollection = DataBaseCRUDManager.Instance.TryGetAllUserInfo();
                if (userInfoCoollection.Count >= 1)
                {
                    UserList.Rows.Add(userInfoCoollection.Count);

                    for (int i = 0; i < userInfoCoollection.Count; i++)
                    {
                        Debug.Info($" index {i} {userInfoCoollection[i].UserName}");
                        UserList.Rows[i].Tag = userInfoCoollection[i];
                        UserList.Rows[i].Cells["Username"].Value = userInfoCoollection[i].UserName;
                        UserList.Rows[i].Cells["AuthLevel"].Value = DataManager.Instance.UserTypeDatas.FirstOrDefault(t => t.Id.Equals(userInfoCoollection[i].UserType)).Name;
                        //UserList.Rows[i].Cells["Email"].Value = userInfoCoollection[i].Email;
                        switch (userInfoCoollection[i].Sex)
                        {
                            case "-1":
                            case "0":
                                UserList.Rows[i].Cells["Sex"].Value = "未知";
                                break;
                            case "1":
                                UserList.Rows[i].Cells["Sex"].Value = "男";
                                break;
                            case "2":
                                UserList.Rows[i].Cells["Sex"].Value = "女";
                                break;
                            default:
                                break;
                        }
                        //UserList.Rows[i].Cells["PhoneNumber"].Value = userInfoCoollection[i].Phonenumber;
                        UserList.Rows[i].Cells["Company"].Value = DataManager.Instance.CompanyDatas.FirstOrDefault(c => c.Id.Equals(userInfoCoollection[i].CompanyId)).Name;
                        //UserList.Rows[i].Cells["UserStatus"].Value = userInfoCoollection[i].UserStatus;
                        UserList.Rows[i].Cells["Remark"].Value = userInfoCoollection[i].Remark;
                        UserList.Rows[i].Cells["IdentityId"].Value = userInfoCoollection[i].IdentityId;                        
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Error($"Get user info failed {ex}");
            }
        }


        private void DeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!InDelectBatchesMode)
            {
                InDelectBatchesMode = true;
                UserList.Columns[0].Visible = InDelectBatchesMode;
            }
            else
            {
                foreach (DataGridViewRow row in UserList.Rows)
                {
                    if (row.Cells["Selected"].EditedFormattedValue.Equals(true))
                    {
                        var data = row.Tag as UserDataModel;
                        Debug.Info($"Ready to delete {data.Id} {data.UserName} {data.LoginName} user infos");
                        try
                        {
                            DataBaseCRUDManager.Instance.DeleteUserInfoById(data.Id);
                        }
                        catch (Exception ex)
                        {
                            MessageDialog msg = new MessageDialog();
                            msg.Message = $"删除用户信息失败(ex: {ex})";
                            msg.ShowDialog();
                            return;
                        }
                    }
                }

                InDelectBatchesMode = false;
                UserList.Columns[0].Visible = InDelectBatchesMode;
                UserListInitialize();
            }
        }


        //#region Mouse right button functions

        //private int index = -1;

        //private void UserList_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        if (e.RowIndex >= 0)
        //        {
        //            UserList.ClearSelection();
        //            UserList.Rows[e.RowIndex].Selected = true;
        //            UserList.CurrentCell = UserList.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //            UserRightClick.Show(MousePosition.X, MousePosition.Y);

        //            index = e.RowIndex;

        //            Debug.Info($"UserList_CellMouseUp Selected index {index} {UserList.Rows[e.RowIndex].Cells["Username"].Value}");
        //        }
        //    }
        //}

        //#endregion

        private void ButtonAddUser_Click(object sender, EventArgs e)
        {
            OCC_UserDetail userDetailForm = new OCC_UserDetail();
            userDetailForm.Owner = this;
            userDetailForm.Type = OCC_UserDetail.FormType.CREATE;
            userDetailForm.ShowDialog();
        }

        private void ButtonDeleteUser_Click(object sender, EventArgs e)
        {
            if (!InDelectBatchesMode)
            {
                InDelectBatchesMode = true;
                UserList.Columns[0].Visible = true;
            }
            else
            {
                foreach (DataGridViewRow row in UserList.Rows)
                {
                    if (row.Cells["Selected"].EditedFormattedValue.Equals(true))
                    {
                        var data = row.Tag as UserDataModel;
                        try
                        {
                            DataBaseCRUDManager.Instance.DeleteUserInfoById(data.Id);
                        }
                        catch (Exception ex)
                        {
                            ShowErrorNotifier($"删除用户{(data.UserName)}信息失败 {ex}");
                            return;
                        }
                    }
                }


                InDelectBatchesMode = false;
                UserList.Columns[0].Visible = InDelectBatchesMode;
            }
            UserListInitialize();
        }

        private void ButtonEditUser_Click(object sender, EventArgs e)
        {
            var targetUser = UserList.Rows[currentSelectRowIndex].Tag as UserDataModel;
            OCC_UserDetail userDetailForm = new OCC_UserDetail();
            userDetailForm.Owner = this;
            userDetailForm.Type = OCC_UserDetail.FormType.ADJUST;
            userDetailForm.Tag = targetUser;
            userDetailForm.ShowDialog();
        }

        private void UserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
                return;
            currentSelectRowIndex = e.RowIndex;
        }
    }
}
