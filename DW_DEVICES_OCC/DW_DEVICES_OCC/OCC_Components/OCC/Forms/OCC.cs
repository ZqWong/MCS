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

namespace OCC
{
    public partial class OCC : Form
    {
        public OCC()
        {
            InitializeComponent();

            CreateSideBarButton("BtnMain", "主页", global::OCC.Properties.Resources.主页_btn, (sender, e) =>
            {
                Debug.Info("主页按钮 点击");
            });

            CreateSideBarButton("BtnDevice", "设备", global::OCC.Properties.Resources.主页_btn, (sender, e) =>
            {
                Debug.Info("设备按钮 点击");
            });

            MoouseDrag();

            CreateSideBarButtonByUserAuthority(DataManager.Instance.CurrentUserAuthData.AuthLevel);
        }

        private void OCC_Load(object sender, EventArgs e)
        {
            
        }

        #region Create Sidebar button


        private void CreateSideBarButtonByUserAuthority(int userAuthCode)
        {
            Debug.Info($"{this} CreateSideBarButtonByUserAuthority Level : {userAuthCode}");

            if (UserAuthManager.IsHasAuth(userAuthCode, (long)UserAuthEnum.MAIN_MENU))
            {

            }
            if (UserAuthManager.IsHasAuth(userAuthCode, (long)UserAuthEnum.DEVICE_MENU))
            {

            }
            if (UserAuthManager.IsHasAuth(userAuthCode, (long)UserAuthEnum.APP_MENU))
            {

            }
            if (UserAuthManager.IsHasAuth(userAuthCode, (long)UserAuthEnum.USERS_MENU))
            {

            }
            if (UserAuthManager.IsHasAuth(userAuthCode, (long)UserAuthEnum.DEVICE_GROUP_MENU))
            {

            }
            if (UserAuthManager.IsHasAuth(userAuthCode, (long)UserAuthEnum.LOG_MENU))
            {

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

        /// <summary>
        /// 当主界面设置按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            // TODO: 当设置按钮按下



        }


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
    }
}
