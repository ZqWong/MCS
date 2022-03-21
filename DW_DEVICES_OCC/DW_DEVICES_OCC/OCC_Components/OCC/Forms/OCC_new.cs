using System;
using System.Data;
using System.Windows.Forms;
using OCC.Core.LocalConfig;
using OCC.Core;
using System.Threading;
using RabbitMQEvent;
using System.Diagnostics;
using System.Reflection;
using OCC.Forms;
using Sunny.UI;

namespace OCC
{
    public partial class OCC : UIForm
    {
        // 同步上下文
        public static SynchronizationContext s_uiContext;

        public bool boola;

        private static OCC s_instance = null;
        private static readonly object syslock = new object();
        public static OCC Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (syslock)
                    {
                        if (s_instance == null)
                        {
                            s_instance = new OCC();
                        }
                    }
                }
                return s_instance;
            }
        }

        public OCC()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            s_uiContext = SynchronizationContext.Current;

            DataBaseInitialize();

            if (LocalConifgManager.Instance.SystemConfig.DataModel.ShowLoginForm)
            {
                OCC_Login login = new OCC_Login();
                login.Owner = this;

                login.LoginCompleteAction = () =>
                {                    
                    RemoveTabControlButton(0);
                    RabbitMQServerInitialize();
                    DataManager.Instance.GetCommonInfos();
                    CreateTabButtonByUserAuthority();
                };

                CreateTabControlButton(UserAuthEnum.DEVICES_MENU.ToString(), UIText.OCC.LOGIN_BUTTON_STRING, login);
            }

            
        }


        private void DataBaseInitialize()
        {
            /// 数据库读取
            try
            {
                var connectionString = string.Format(
                    DataBaseConst.SQL_SUGAR_CONNECTION_STRING_FORMAT,
                    LocalConifgManager.Instance.SystemConfig.DataModel.DatabaseHost,
                    LocalConifgManager.Instance.SystemConfig.DataModel.DatabaseRepName,
                    LocalConifgManager.Instance.SystemConfig.DataModel.DatabaseUsername,
                    LocalConifgManager.Instance.SystemConfig.DataModel.DatabasePassword,
                    null,
                    true);

                if (DataBaseManager.Instance.Initialize(connectionString, true, SqlSugar.DbType.MySql, true))
                {
                    ShowSuccessNotifier($"数据库初始化成功.");
                }                
            }
            catch (Exception ex)
            {
                ShowErrorDialog($"[OCC] 数据库初始化失败 :\n{ex}");
                Debug.Error($"[OCC] Database Initialize failed :{ex}");
            }

        }


        private void RabbitMQServerInitialize()
        {
            /// RabbitMQ 链接 与 本地配置文件初始化
            try
            {
                //RabbitMQManager.Instance.Initialize("event_bus", GetIP(), Process.GetCurrentProcess().ProcessName, "topic", "client_duowei", "192.169.0.198", "duowei");
                //RabbitMQManager.Instance.Initialize("event_bus", NetworkHelper.GetIP(), Process.GetCurrentProcess().ProcessName, "topic", "client_duowei", "127.0.0.1", "duowei");

                try
                {
                    RabbitMQManager.Instance.Initialize(
                      LocalConifgManager.Instance.SystemConfig.DataModel.RabbitMQBrokerName,
                      NetworkHelper.GetIP(),
                      Process.GetCurrentProcess().ProcessName,
                      LocalConifgManager.Instance.SystemConfig.DataModel.RabbitMQExchangeType,
                      LocalConifgManager.Instance.SystemConfig.DataModel.Username,
                      //LocalConifgManager.Instance.SystemConfig.DataModel.Hostname,
                      "127.0.0.1",
                      LocalConifgManager.Instance.SystemConfig.DataModel.Password);
                }
                catch (Exception ex)
                {
                    ShowErrorDialog($"[OCC] RabbitMQ 初始化失败 :\n{ex}");
                    System.Environment.Exit(0);
                    throw;
                }
            
                //注册当前程序集中实现的所有IEventHandler<T> （(Assembly.GetExecutingAssembly()：获取包含当前执行的代码的程序集）
                RabbitMQManager.Instance.RegisterAllEventHandlerFromAssembly(Assembly.GetExecutingAssembly());
                RabbitMQManager.Instance.CreatePluginEventConsumerChannel();

                ShowSuccessNotifier($"RabbitMQ 初始化成功.");
            }
            catch (Exception ex)
            {
                ShowErrorDialog($"[OCC] RabbitMQ 初始化失败 :\n{ex}");
                Debug.Error($"[OCC] RabbitMQ Initialize failed :{ex}");
                System.Environment.Exit(0);
            }
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
                // 编码时请注意 使用的 OCC_Main.Instance 创建否则线程会出问题
                CreateTabControlButton(UserAuthEnum.MAIN_MENU.ToString(), UIText.OCC.MAIN_BUTTON_STRING, OCC_Main.Instance);
            }
            // 判断 设备 权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.DEVICES_MENU))
            {
                CreateTabControlButton(UserAuthEnum.DEVICES_MENU.ToString(), UIText.OCC.DEVICES_BUTTON_STRING, OCC_Device.Instance);
            }
            // 判断 系统 APP权限 
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.APPS_MENU))
            {
                CreateTabControlButton(UserAuthEnum.APPS_MENU.ToString(), UIText.OCC.APPS_BUTTON_STRING, OCC_APP.Instance);
            }
            // 判断 数据管理 管理权限 （用户）
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.DATAS_MENU))
            {
                CreateTabControlButton(UserAuthEnum.DATAS_MENU.ToString(), UIText.OCC.DATAS_BUTTON_STRING, new OCC_Users());
            }
            // 判断 分组 权限 （设备绑定系统）
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.GROUP_MENU))
            {
                CreateTabControlButton(UserAuthEnum.GROUP_MENU.ToString(), UIText.OCC.GROUP_BUTTON_STRING, new OCC_Group());
            }
            // 判断日志权限
            if (UserAuthManager.IsHasAuth(DataManager.Instance.CurrentUserAuthData.AuthLevel, (long)UserAuthEnum.SYSTEM_MENU))
            {
                CreateTabControlButton(UserAuthEnum.SYSTEM_MENU.ToString(), UIText.OCC.SYSTEM_BUTTON_STRING, new OCC_System());
            }
        }

        /// <summary>
        /// 创建分页按钮
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
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            subForm.Show();            
            subForm.Parent = TabControlMain.TabPages[btnName];
        }

        /// <summary>
        /// 删除分页按钮
        /// </summary>
        /// <param name="btnName"></param>
        /// <param name="btnText"></param>
        /// <param name="image"></param>
        /// <param name="clickAction"></param>
        private void RemoveTabControlButton(int index)
        {
            TabControlMain.TabPages.RemoveAt(index);
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
