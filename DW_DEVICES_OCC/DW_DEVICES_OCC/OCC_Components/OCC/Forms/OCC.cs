using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using OCC.Core.LocalConfig;
using OCC.Core;
using OCC.Forms.OCC_Main;
using OCC.Forms.OCC_Users;

namespace OCC
{
    public partial class OCC : Form
    {
        private Form preForm;

        public OCC()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            MoouseDrag();
        }

        private void OCC_Load(object sender, EventArgs e)
        {
            DataManager.Instance.GetCommonInfos();

            UpdateUserInfo();

            CreateSideBarButtonByUserAuthority();

            OCC_Main occ_main = new OCC_Main();        
            ShowTargetForm(occ_main);
            preForm = occ_main;
        }

        /// <summary>
        /// 更新主页面登录用户信息
        /// </summary>
        private void UpdateUserInfo()
        {
            LabelUserName.Text = DataManager.Instance.CurrentLoginUserData.UserName;
            LabelUserRemark.Text = DataManager.Instance.CurrentLoginUserData.Remark;
            PictureUserIcon.Image = global::OCC.Properties.Resources.logo;
        }

        /// <summary>
        /// 当主界面设置按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            // TODO: 当设置按钮按下



        }

        #region 创建侧边栏按钮以及点击页面显示

        private void ShowTargetForm(Form targetForm)
        {
            preForm?.Close();
            preForm = targetForm;
            PanelContent.Controls.Clear();
            targetForm.MdiParent = this;
            targetForm.Parent = PanelContent;
            targetForm.FormBorderStyle = FormBorderStyle.None;
            targetForm.Show();
            targetForm.Dock = DockStyle.Fill;            
        }

        /// <summary>
        /// 根据用户权限更新主页面显示功能
        /// </summary>
        private void CreateSideBarButtonByUserAuthority()
        {            
            Debug.Info($"{this} CreateSideBarButtonByUserAuthority Level : {DataManager.Instance.CurrentUserAuthData.AuthLevel}");

            // 判断主界面权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.MAIN_MENU))
            {
                CreateSideBarButton(UserAuthEnum.MAIN_MENU.ToString(), UIText.OCC.MAIN_BUTTON_STRING, global::OCC.Properties.Resources.主页_btn, (sender, e) =>
                {
                    OCC_Main occ_main = new OCC_Main();
                    ShowTargetForm(occ_main);
                    Debug.Info("主页按钮 点击");
                });
            }
            // 判断设备权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.DEVICES_MENU))
            {
                CreateSideBarButton(UserAuthEnum.DEVICES_MENU.ToString(), UIText.OCC.DEVICES_BUTTON_STRING, global::OCC.Properties.Resources.主页_btn, (sender, e) =>
                {
                    OCC_Device occ = new OCC_Device();
                    ShowTargetForm(occ);
                    Debug.Info("设备按钮 点击");
                });
            }
            // 判断APP权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.APPS_MENU))
            {
                CreateSideBarButton(UserAuthEnum.APPS_MENU.ToString(), UIText.OCC.APPS_BUTTON_STRING, global::OCC.Properties.Resources.主页_btn, (sender, e) =>
                {
                    Debug.Info("app按钮 点击");
                });
            }
            // 判断用户管理权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.USERS_MENU))
            {
                CreateSideBarButton(UserAuthEnum.USERS_MENU.ToString(), UIText.OCC.USERS_BUTTON_STRING, global::OCC.Properties.Resources.主页_btn, (sender, e) =>
                {
                    OCC_Users occ = new OCC_Users();
                    ShowTargetForm(occ);
                    Debug.Info("用户按钮 点击");
                });
            }
            // 判断设备分组权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.DEVICE_GROUP_MENU))
            {
                CreateSideBarButton(UserAuthEnum.DEVICE_GROUP_MENU.ToString(), UIText.OCC.DEVICE_GROUP_BUTTON_STRING, global::OCC.Properties.Resources.主页_btn, (sender, e) =>
                {
                    Debug.Info("分组按钮 点击");
                });
            }
            // 判断日志权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.LOG_MENU))
            {
                CreateSideBarButton(UserAuthEnum.LOG_MENU.ToString(), UIText.OCC.LOG_BUTTON_STRING, global::OCC.Properties.Resources.主页_btn, (sender, e) =>
                {
                    Debug.Info("日志按钮 点击");
                });
            }
        }

        /// <summary>
        /// 创建侧边栏按钮
        /// </summary>
        /// <param name="btnName"></param>
        /// <param name="btnText"></param>
        /// <param name="image"></param>
        /// <param name="clickAction"></param>
        private void CreateSideBarButton(string btnName, string btnText, Bitmap image, Action<object, EventArgs> clickAction)
        {
            Button button = new Button();
            button.Dock = DockStyle.Top;
            button.FlatStyle = FlatStyle.Flat;
            button.ForeColor = SystemColors.ActiveCaption;
            button.FlatAppearance.BorderSize = 2;
            button.Image = image;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Location = new Point(3, 3);
            button.Name = btnName;
            button.Size = new Size(180, 45);
            button.TabIndex = 0;
            button.Text = btnText;
            button.UseVisualStyleBackColor = true;
            button.Click += (sender, e) =>
            {
                clickAction?.Invoke(sender, EventArgs.Empty);
            };
            SideButtonPanel.Controls.Add(button);
        }
        #endregion

        #region 鼠标拖动

        [DllImport("user32")]
        public static extern int ReleaseCapture();
        [DllImport("user32")]
        public static extern int SendMessage(IntPtr hwnd, int msg, int wp, int lp);
        /// <summary>
        /// 是否允许移动
        /// </summary>
        private bool IsMove = false;

        private void MoouseDrag()
        {
            if (LocalConifgManager.Instance.SystemConfig.DataModel.WindowsCanMoved)
            {
                TaskBar.MouseUp += (sender, e) =>
                {
                    IsMove = false;
                };

                TaskBar.MouseDown += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        Rectangle rect = new Rectangle(1, 1, Width - 70, Height);   //允许拖动的矩形范围
                        IsMove = rect.Contains(new Point(e.X, e.Y));                       //鼠标按下的点是否在允许拖动范围内
                    }
                };

                TaskBar.MouseMove += (sender, e) =>
                { 
                    if (IsMove && e.Button == MouseButtons.Left && WindowState != FormWindowState.Maximized)
                    {
                        ReleaseCapture();
                        SendMessage(Handle, 274, 61440 + 9, 0);
                        return;
                    }
                };
            }
        }


        #endregion

        #region 系统按钮

        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnApplicationClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private bool isMaximized = false;
        /// <summary>
        /// 最大化以及还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMaxMinStateChange_Click(object sender, EventArgs e)
        {
            WindowState = isMaximized ? FormWindowState.Normal : FormWindowState.Maximized;
            isMaximized = !isMaximized;
        }
        /// <summary>
        /// 最小化到任务栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMinimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion


    }
}
