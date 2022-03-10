﻿using System;
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
using OCC.Forms.OCC_APPs;
using OCC.Forms.OCC_Groups;
using OCC.Forms.OCC_Systems;
using OCC.Forms.OCC_Devices;

namespace OCC
{
    public partial class OCC : Form
    {
        private Form preForm;

        public OCC()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            //MoouseDrag();
        }

        private void OCC_Load(object sender, EventArgs e)
        {
            DataManager.Instance.GetCommonInfos();

            UpdateUserInfo();

            CreateTabButtonByUserAuthority();

            //OCC_Main occ_main = new OCC_Main();        
            //ShowTargetForm(occ_main);
            //preForm = occ_main;
        }


        //private void ShowTargetForm(TabPage page, Form form)
        //{            
        //    form.TopLevel = false;
        //    form.Dock = DockStyle.Fill;
        //    page.Controls.Add(form);
        //    form.Show();
        //}

        //private void CreatePathContent(int index, TabPage page)
        //{
        //    switch (index)
        //    {
        //        case 0:
        //            OCC_Main occ_Main = new OCC_Main();
        //            TabControlMain.SelectedTab.Text = OCC_Main.FORM_NAME;
        //            ShowTargetForm(page, occ_Main);
        //            break;
        //        case 1:
        //            break;
        //        default:
        //            Debug.Error($"");
        //            break;
        //    }

        //    TabControlMain.SelectedIndex = 0;

        //}

        //private void TabControlInitialize()
        //{
        //    for (int i = 0; i < TabControlMain.TabPages.Count; i++)
        //    {
        //        CreatePathContent(i, TabControlMain.TabPages[i]);


        //    }         
        //}

        /// <summary>
        /// 更新主页面登录用户信息
        /// </summary>
        private void UpdateUserInfo()
        {
            //LabelUserName.Text = DataManager.Instance.CurrentLoginUserData.UserName;
            //LabelUserRemark.Text = DataManager.Instance.CurrentLoginUserData.Remark;
            //PictureUserIcon.Image = global::OCC.Properties.Resources.logo;
        }

        /// <summary>
        /// 当主界面设置按钮按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            // TODO: 当设置按钮按下
                  
            DevicePowerManager.RemotePowerOn("1C-1B-0D-60-56-D6");

            //DevicePowerManager.RemotePowerOff("192.168.0.72");

        }

        #region 创建侧边栏按钮以及点击页面显示



        /// <summary>
        /// 根据用户权限更新主页面显示功能
        /// </summary>
        private void CreateTabButtonByUserAuthority()
        {            
            Debug.Info($"{this} CreateSideBarButtonByUserAuthority Level : {DataManager.Instance.CurrentUserAuthData.AuthLevel}");
            
            // 判断 首页 权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.MAIN_MENU))
            {
                CreateTabControlButton(UserAuthEnum.MAIN_MENU.ToString(), UIText.OCC.MAIN_BUTTON_STRING, new OCC_Main());
            }
            // 判断 设备 权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.DEVICES_MENU))
            {
                CreateTabControlButton(UserAuthEnum.DEVICES_MENU.ToString(), UIText.OCC.DEVICES_BUTTON_STRING, new OCC_Device());
            }
            // 判断 系统 APP权限 
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.APPS_MENU))
            {
                CreateTabControlButton(UserAuthEnum.APPS_MENU.ToString(), UIText.OCC.APPS_BUTTON_STRING, new OCC_APPs());
            }
            // 判断 数据管理 管理权限 （用户）
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.DATAS_MENU))
            {
                CreateTabControlButton(UserAuthEnum.DATAS_MENU.ToString(), UIText.OCC.DATAS_BUTTON_STRING, new OCC_Users());
            }
            // 判断 分组 权限 （设备绑定系统）
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.GROUP_MENU))
            {
                CreateTabControlButton(UserAuthEnum.GROUP_MENU.ToString(), UIText.OCC.GROUP_BUTTON_STRING, new OCC_Groups());
            }
            // 判断日志权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.SYSTEM_MENU))
            {
                CreateTabControlButton(UserAuthEnum.SYSTEM_MENU.ToString(), UIText.OCC.SYSTEM_BUTTON_STRING, new OCC_System());
            }
        }

        /// <summary>
        /// 创建侧边栏按钮
        /// </summary>
        /// <param name="btnName"></param>
        /// <param name="btnText"></param>
        /// <param name="image"></param>
        /// <param name="clickAction"></param>
        private void CreateTabControlButton(string btnName, string btnText, Form subForm)
        {
            TabPage newTabPage = new TabPage(btnText);            
            newTabPage.Name = btnName;
            TabControlMain.TabPages.Add(newTabPage);
            TabControlMain.SizeMode = TabSizeMode.FillToRight;
            //标签页属性设置
            subForm.TopLevel = false;
            subForm.Dock = DockStyle.Fill;
            subForm.FormBorderStyle = FormBorderStyle.None;
            //subForm.AutoScroll = true;
            subForm.Show();            
            subForm.Parent = TabControlMain.TabPages[btnName];
        }

        #endregion

        #region 鼠标拖动

        //[DllImport("user32")]
        //public static extern int ReleaseCapture();
        //[DllImport("user32")]
        //public static extern int SendMessage(IntPtr hwnd, int msg, int wp, int lp);
        ///// <summary>
        ///// 是否允许移动
        ///// </summary>
        //private bool IsMove = false;

        //private void MoouseDrag()
        //{
        //    if (LocalConifgManager.Instance.SystemConfig.DataModel.WindowsCanMoved)
        //    {
        //        TaskBar.MouseUp += (sender, e) =>
        //        {
        //            IsMove = false;
        //        };

        //        TaskBar.MouseDown += (sender, e) =>
        //        {
        //            if (e.Button == MouseButtons.Left)
        //            {
        //                Rectangle rect = new Rectangle(1, 1, Width - 70, Height);   //允许拖动的矩形范围
        //                IsMove = rect.Contains(new Point(e.X, e.Y));                       //鼠标按下的点是否在允许拖动范围内
        //            }
        //        };

        //        TaskBar.MouseMove += (sender, e) =>
        //        { 
        //            if (IsMove && e.Button == MouseButtons.Left && WindowState != FormWindowState.Maximized)
        //            {
        //                ReleaseCapture();
        //                SendMessage(Handle, 274, 61440 + 9, 0);
        //                return;
        //            }
        //        };
        //    }
        //}


        #endregion

        #region 系统按钮

        ///// <summary>
        ///// 关闭程序
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void BtnApplicationClose_Click(object sender, EventArgs e)
        //{
        //    Environment.Exit(0);
        //}

        //private bool isMaximized = false;
        ///// <summary>
        ///// 最大化以及还原
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void BtnMaxMinStateChange_Click(object sender, EventArgs e)
        //{
        //    WindowState = isMaximized ? FormWindowState.Normal : FormWindowState.Maximized;
        //    isMaximized = !isMaximized;
        //}
        ///// <summary>
        ///// 最小化到任务栏
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void BtnMinimized_Click(object sender, EventArgs e)
        //{
        //    WindowState = FormWindowState.Minimized;
        //}

        #endregion
    }
}
