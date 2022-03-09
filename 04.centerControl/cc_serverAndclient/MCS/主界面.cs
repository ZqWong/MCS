using Common;
using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using MCS.SocketHandler;
using ServerFrame;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using CommonTools.tools;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using MainTrain.Tools;
using Org.BouncyCastle.Asn1.Cms;
using UserEventData;
using Utilities;

namespace MCS
{
    public partial class 主界面 : Form
    {

        private static readonly object syslock = new object();

        private static 主界面 _instance;
        private static SynchronizationContext s_uiContext;

        public static 主界面 GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new 主界面();
                    }
                }
            }

            return _instance;
        }

        public SynchronizationContext GetSyncContext()
        {
            return s_uiContext;
        }

        /// <summary>
        /// 考试信息
        /// </summary>
        ExaminationBLL _ExaminationBLL = new ExaminationBLL();
        /// <summary>
        /// 考试机信息
        /// </summary>
        ExaminationPCBLL _ExaminationPCBLL = new ExaminationPCBLL();
        /// <summary>
        /// 考生信息
        /// </summary>
        ExamineeBLL _ExamineeBLL = new ExamineeBLL();
        /// <summary>
        /// 获取所有系统信息
        /// </summary>
        SystemBLL _SystemBLL = new SystemBLL();
        /// <summary>
        /// 获取设备信息
        /// </summary>
        DeviceControlInfoBLL _GetDeviceInfoBLL = new DeviceControlInfoBLL();
        /// <summary>
        /// 获取相对路径
        /// </summary>
        string _AppStartPath = Application.StartupPath;

        /// <summary>
        /// 选中数据的IP集合
        /// </summary>
        private List<string> _SelectedIPList = new List<string>();
        /// <summary>
        /// 选中数据的Mac集合
        /// </summary>
        private List<string> _SelectedMacList = new List<string>();

        // 当前局域网能ping通IP
        private ConcurrentDictionary<string, string> _IPDict = new ConcurrentDictionary<string, string>();
        public ConcurrentDictionary<string, string> IPDict = new ConcurrentDictionary<string, string>();
        public object lockPingIp = new object();

        /// <summary>
        /// 当前已连接的客户端
        /// </summary>
        public List<string> connectedIP = new List<string>();
        public object lockConnectedIp = new object();

        /// <summary>
        /// 控制播放列表播放的线程
        /// </summary>
        private CancellationTokenSource _playListControlSource = new CancellationTokenSource();
        /// <summary>
        /// 播放列表名称
        /// </summary>
        private string playListName;
        /// <summary>
        /// 当前播放APP名称
        /// </summary>
        private string curPlayAppName;
        /// <summary>
        /// 控制任务
        /// </summary>
        private Task controlTask = new Task(() => { });
        /// <summary>
        /// 播放音频间隔（ms）
        /// </summary>
        private int playVideoIntervalMS = int.Parse(ConfigHelper.GetSingleton().GetAppConfig("PlayVideoInterval"));
        /// <summary>
        /// 关闸开启延迟时间
        /// </summary>
        private int OpenRasterDelayTime = int.Parse(ConfigHelper.GetSingleton().GetAppConfig("OpenRasterDelay"));
        /// <summary>
        /// 整体开关机状态记录. true：已经整体开机完成，当前是开机状态   false：整体关机完成，当前是关机状态
        /// </summary>
        public bool allAccomPower = false;
        /// <summary>
        /// 整体开关机剩余时间记录
        /// </summary>
        public float controlPowerRemainSeconds = 0;
        /// <summary>
        /// 键盘钩子
        /// </summary>
        private KeyboardHookLib _keyboardHook = null;

        private 主界面()
        {
            // 此项目删除权限管理，在此设置全局的权限
            Global.Instance.LoginUserName = "Admin";
            Global.Instance.IsHasAdminLevel = true;

            // 提供在各种同步模型中传播同步上下文的基本功能。
            s_uiContext = SynchronizationContext.Current;

            InitializeComponent();

            // 判断是否是精简版显示
            if (ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "0")
            {
                // 精简版
                fullShow(false);
            }
            else if (ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "1" || ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "2")
            {
                // 阜新环幕专用
                fuxinHuanmuLabShow(true);
            }
            else if (ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "3")
            {
                // 办公室演示区专用
                OfficeDemonstrationAreaShow(true);
            }
            else
            {
                // 正常版
                fullShow(true);
            }

            this.toolStripStatusLabel_server.Text = "当前登录用户：" + Global.Instance.LoginUserName;

            // 自动执行
            AutoExcute();

            // 启动服务
            NlogHandler.GetSingleton().Info("开始连接到服务器");
            StartServer();
            NlogHandler.GetSingleton().Info("连接到服务完成");

            // 加载考试机数据
            try
            {
                LoadData();
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error("页面数据加载异常：" + e.Message.ToString());
            }
            
            NlogHandler.GetSingleton().Info("页面数据加载完成");

            // 定时器开启
            timer1.Enabled = true;
            timer1.Interval = Convert.ToInt32(ConfigHelper.GetSingleton().GetAppConfig("TimeInterval")) * 1000;

            // 安装钩子
            HookInstall();

            // 启动后延迟执行方案“启动执行”
            StartUpExecPlane();

            // 输入数据处理
            // 通过配置文件来选择，因为pci1710的采集卡，如果在没有安装该驱动的计算机启动了采集卡的监听程序，会报错
            if (ConfigHelper.GetSingleton().GetAppConfig("PCI1710Enable") == "1")
            {
                设备输入数据.GetSingleton();
            }

        }

        /// <summary>
        /// 启动后，如果方案中包含名称为“启动执行”的方案，则延迟10秒后执行该方案
        /// </summary>
        private async void StartUpExecPlane()
        {
            if (this.comboBox_device.FindString("启动执行") == -1)
            {
                return;
            }
            else
            {
                this.comboBox_device.SelectedIndex = this.comboBox_device.FindString("启动执行");

                // 与整体其他部分思路不一致，并没有调用button_device_on_Click
                string planName = comboBox_device.Text.Trim();

                await Task.Run(() =>
                {
                    Thread.Sleep(10000);
                    其他设备控制.GetSingleton().ExecPlan(planName);
                });
            }
        }

        /// <summary>
        /// 查找并执行方案
        /// </summary>
        /// <param name="planName"></param>
        private async void FindAndExecPlane(string planName)
        {
            int planIndex = this.comboBox_device.SelectedIndex = this.comboBox_device.FindString(planName);
            if (planIndex == -1)
                return;
            else
            {
                await Task.Run(() =>
                {
                    其他设备控制.GetSingleton().ExecPlan(planName);
                });
            }
        }

        /// <summary>
        /// 根据配置文件安装钩子
        /// </summary>
        private void HookInstall()
        {
            if (ConfigHelper.GetSingleton().GetAppConfig("Hook") == "0")
                return;

            if (ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "2")
            {
                // 阜新VR教室键盘钩子
                _keyboardHook = new KeyboardHookLib();
                _keyboardHook.InstallHook(new KeyboardHookLib.MyHookDelegate(GetHookProcFuXinVR));
            }

        }

        /// <summary>
        /// 阜新vr教室键盘钩子函数
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private int GetHookProcFuXinVR(int nCode, int wParam, IntPtr lParam)
        {
            //当nCode大于0，并且时按下事件时为1
            if (nCode >= 0 && (wParam == KeyboardHookLib.WM_KEYDOWN) || (wParam == KeyboardHookLib.WM_KEYDOWN))
            {
                //将按键信息转换为结构体
                KeyboardHookLib.HookStruct hookStruc = (KeyboardHookLib.HookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookLib.HookStruct));
                //是否拦截按键的标识符，默认不拦截
                bool handle = false;
                switch ((Keys)hookStruc.vkVode)
                {
                    // 将拦截标识符置为拦截，如果按了上键相当于向当前窗口发送一个回车
                    // handle = true;
                    case Keys.F11:
                        FindAndExecPlane("3D翻转开");
                        break;
                    case Keys.F12:
                        FindAndExecPlane("3D翻转关");
                        break;
                }
                //1表示拦截键盘
                if (handle) { return 1; }
            }
            return KeyboardHookLib.CallNextHookEx(KeyboardHookLib._hHookValue, nCode, wParam, lParam);
        }

        /// <summary>
        /// 自动执行
        /// </summary>
        private void AutoExcute()
        {
            //// 测试用
            //DataSet ds = examinationInfoBLL.GetAllExaminationInfo();
            //MessageBox.Show(ds.Tables[0].Rows.Count.ToString());

            _SystemBLL = new SystemBLL();

            DataSet ds = _SystemBLL.GetAllSystemInfo();

            if (ds.Tables[0].Rows.Count > 0)
            {
                // 上次数据库备份时间
                DateTime lastDatabaseBackupTime = Convert.ToDateTime(ds.Tables[0].Rows[0][SystemModel.ColumnName_LastDatabaseBackupTime]);

                // 当前时间
                DateTime currentDateTime = DateTime.Now;

                #region 系统日志自动清理
                // 系统日志清理
                try
                {
                    //System.IO.File.WriteAllText(Const.LogPath, string.Empty);
                    // 系统日志清理
                    LogHelper.CleanUp();

                    // 更新数据库备份时间
                    DataSet ds2 = _SystemBLL.GetAllSystemInfo();

                    SystemModel sm = new SystemModel();
                    sm.LastSystemLogCleanupTime = DateTime.Now.ToString();

                    sm.LastDatabaseBackupTime = ds2.Tables[0].Rows[0][SystemModel.ColumnName_LastDatabaseBackupTime].ToString();
                    sm.ID = ds2.Tables[0].Rows[0][SystemModel.ColumnName_ID].ToString();


                    int result = _SystemBLL.UpdSystemInfo(sm);

                    if (result > 0)
                    {

                        LogHelper.WriteLog("更新系统日志清理时间：" + DateTime.Now.ToString());
                    }
                    else
                    {

                        LogHelper.WriteErrorLog("更新系统日志清理时间！");
                    }

                }
                catch (Exception e)
                {
                    LogHelper.WriteErrorLog("系统日志清理失败！原因：" + e);
                }


                #endregion

                #region 数据库自动备份
                try
                {
                    // 数据库备份
                    // 每次运行主控系统，获取上次数据库备份时间与操作系统当前时间进行对比，时间间隔1天以上（包括1天），数据库自动进行备份，并且更新数据库备份时间
                    TimeSpan ts1 = currentDateTime - lastDatabaseBackupTime;
                    int sub1 = ts1.Days; //sub就是两天相差的天数

                    if (sub1 >= 1)
                    {
                        // 数据库自动备份
                        DatabaseBackupFunction();

                        // 更新数据库备份时间
                        DataSet ds1 = _SystemBLL.GetAllSystemInfo();

                        SystemModel sm = new SystemModel();
                        sm.LastDatabaseBackupTime = DateTime.Now.ToString();
                        sm.ID = ds1.Tables[0].Rows[0][SystemModel.ColumnName_ID].ToString();
                        sm.LastSystemLogCleanupTime = ds1.Tables[0].Rows[0][SystemModel.ColumnName_LastSystemLogCleanupTime].ToString();

                        int result = _SystemBLL.UpdSystemInfo(sm);

                        if (result > 0)
                        {

                            LogHelper.WriteLog("更新数据库备份时间：" + DateTime.Now.ToString());
                        }
                        else
                        {

                            LogHelper.WriteErrorLog("更新数据库备份时间失败！");
                        }
                    }
                }
                catch (Exception e)
                {
                    LogHelper.WriteLog("异常：更新数据库备份时间失败！");
                }
                #endregion
            }
        }
        // add by wuxin at 2018/09/10 - end

        /// <summary>
        /// 启动服务
        /// </summary>
        private void StartServer()
        {
            RabbitMQEventBus.GetSingleton().Init(
                ConfigHelper.GetSingleton().GetAppConfig("BrokerName"),
                GetLocalIp.GetSingleton().GetIP(),
                Process.GetCurrentProcess().ProcessName,
                ConfigHelper.GetSingleton().GetAppConfig("ExchangeType"),
                ConfigHelper.GetSingleton().GetAppConfig("User_Name"),
                ConfigHelper.GetSingleton().GetAppConfig("HostName"),
                ConfigHelper.GetSingleton().GetAppConfig("Password")
                );

            NlogHandler.GetSingleton().Error(
                $"{ConfigHelper.GetSingleton().GetAppConfig("BrokerName")}" +
                $" {GetLocalIp.GetSingleton().GetIP()}" +
                $" {Process.GetCurrentProcess().ProcessName} " +
                $"{ConfigHelper.GetSingleton().GetAppConfig("ExchangeType")} " +
                $"{ConfigHelper.GetSingleton().GetAppConfig("User_Name")}" +
                $" {ConfigHelper.GetSingleton().GetAppConfig("HostName")} " +
                $"{ConfigHelper.GetSingleton().GetAppConfig("Password")}");

            RabbitMQEventBus.GetSingleton().RegisterAllEventHandlerFromAssembly(Assembly.GetExecutingAssembly());

            NlogHandler.GetSingleton().Error($"Assembly.GetExecutingAssembly() : {Assembly.GetExecutingAssembly().GetName()}");

            RabbitMQEventBus.GetSingleton().CreatePluginEventConsumerChannel();
        }

        /// <summary>
        /// 加载考试机数据
        /// </summary>
        private void LoadData()
        {
            DataSet ds;

            ds = _ExaminationPCBLL.GetAllExaminationPCInfo();

            int count = ds.Tables[0].Rows.Count;

            this.MCS_DataGridView.Rows.Clear();

            if (count > 0)
            {
                this.MCS_DataGridView.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    this.MCS_DataGridView.Rows[i].Cells["No"].Value = i + 1;

                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCName].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_ExamPCName].ToString();

                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_IP].ToString();

                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Mac].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_Mac].ToString();

                    // add by wuxin at 2018/10/14 - start
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Type].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_Type].ToString();
                    // add by wuxin at 2018/10/14 - end

                    //MessageBox.Show(this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Type].Value.ToString());

                    // 开关机状态
                    Image img = null;
                    img = Image.FromFile(_AppStartPath + Const.ComputerClosedPicRPath);

                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Value = img;

                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag = Const.Tag_OpenOrClosePCState_Closed;

                    // 连接状态
                    //this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Value = Const.ConnectionState_NoConnection;
                    //this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Style.ForeColor = Color.Red;
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Value = Image.FromFile(_AppStartPath + Const.ConnectionState_NoConnection_PicRPath);
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Tag = Const.Tag_ConnectionState_NoConnection;

                    // 考试系统软件打开状态
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamAppOpenState].Value = Image.FromFile(_AppStartPath + Const.ExamAppOpenState_Close_PicRPath);
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamAppOpenState].Tag = Const.Tag_ExamAppOpenState_Close;

                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExaminationContent].Value = "";
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamineeName].Value = "";

                    // 考试状态
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Empty_PicRPath);
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamState].Tag = Const.Tag_ExamState_Empty;

                    // 考试机状态
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Empty_PicRPath);
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Tag = Const.Tag_ExamState_Empty;

                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExaminationID].Value = "";
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamineeID].Value = "";

                    this.MCS_DataGridView.Rows[i].Cells["ResetButton"].Value = "回收/分配";

                    if (i % 2 != 0)
                    {
                        this.MCS_DataGridView.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.MCS_DataGridView.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }

                    // add by wuxin at 2018/10/14 - start
                    // 练习机默认背景色设置为白色，以区分考试机和练习机
                    string type = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_Type].ToString();

                    if (type == "0")
                    {
                        this.MCS_DataGridView.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }

                    this.MCS_DataGridView.Rows[i].Cells["ExaminationResultID"].Value = "";

                    // add by wuxin at 2018/10/14 - end
                }
            }

            //for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
            //{
            //    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = true;
            //}

            //button_refresh_Click(null, null);

            //for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
            //{
            //    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = false;
            //}

            ShortCutLoad();

            S_C_SyncSystemTimeData sendDate = new S_C_SyncSystemTimeData();

            sendDate.wYear = (ushort)(DateTime.Now.Year);
            sendDate.wMonth = (ushort)(DateTime.Now.Month);
            sendDate.wDay = (ushort)(DateTime.Now.Day);
            sendDate.wHour = (ushort)(DateTime.Now.Hour);
            sendDate.wMinute = (ushort)(DateTime.Now.Minute);
            sendDate.wSecond = (ushort)(DateTime.Now.Second);
            sendDate.wMiliseconds = (ushort)(DateTime.Now.Millisecond);

            RabbitMQEventBus.GetSingleton().Trigger<S_C_SyncSystemTimeData>(sendDate); //直接通过事件总线触发

        }

        /// <summary>
        /// 加载左侧所有的控制combobox
        /// </summary>
        public void ShortCutLoad()
        {
            // 加载计算机启动时间
            string delay = ConfigHelper.GetSingleton().GetAppConfig("ComputerStartDelay");
            this.textBox_delay.Text = delay;

            // 加载分组信息
            this.comboBox_group.Items.Clear();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/StartUpGroup";

            List<XmlNode> groupNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            this.comboBox_group.Items.Add("");

            for (int i = 0; i < groupNodes.Count; i++)
            {
                String groupName = XmlUtil.GetAttribute(groupNodes[i], "name", "");

                this.comboBox_group.Items.Add(groupName);
            }

            // 加载应用 combox
            DataSet ds;

            ds = 进程管理.GetSingleton()._GetAllAppInfoBLL.GetAppName();

            // 添加一个空行
            DataRow row1 = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.InsertAt(row1, 0);

            comboBox_process.ValueMember = ProcessControlModel.DB_Name;
            comboBox_process.DisplayMember = ProcessControlModel.DB_Name;
            comboBox_process.DataSource = ds.Tables[0];

            // 加载方案 combox
            this.comboBox_device.Items.Clear();

            this.comboBox_device.Items.Add("");
            foreach (var planName in 其他设备控制.GetSingleton().planDict.Keys)
            {
                comboBox_device.Items.Add(planName);
            }

            // 加载播放列表
            this.comboBox_playList.DataSource = null;
            this.comboBox_playList.Items.Clear();
            this.comboBox_playList.Items.Add("");

            this.comboBox_playList.DataSource = DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>()
                .Select(it => it.PlayListName).Distinct().ToList().ConvertAll(s => (object)s);
        }

        public void ChildFormClose()
        {
            //LoadData();
        }

        /// <summary>
        /// 子窗体关闭
        /// </summary>
        /// <param name="model"></param>
        public void ChildFormClose(ExaminationPCModel model)
        {
            // 下标
            int index = model.Index;

            // 考试状态无，代表已经回收了的考试
            if (model.ExamState == EnumExamState.Empty)
            {
                // 考试内容
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExaminationContent].Value = "";
                // 考试编号
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExaminationID].Value = "";
                // 考生名称
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamineeName].Value = "";
                // 考生编号
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamineeID].Value = "";

                // 考试状态（空显示）
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamState].Tag = Const.Tag_ExamState_Empty;
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Empty_PicRPath);

                // 考试机状态（空闲）
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamPCState].Tag = Const.Tag_ExamPCState_Idle;
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamPCState].Value = Image.FromFile(_AppStartPath + Const.ExamPCState_Idle_PicRPath);

                // add by wuxin at 2018/10/14 - start
                // 考试结果编号
                this.MCS_DataGridView.Rows[index].Cells["ExaminationResultID"].Value = "";
                // add by wuxin at 2018/10/14 - end

                return;
            }
            else if (model.ExamState == EnumExamState.NoStart)
            {
                // 考试状态（未开始）
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamState].Tag = Const.Tag_ExamState_NoStart;
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamState].Value = Image.FromFile(_AppStartPath + Const.ExamState_NoStart_PicRPath);
            }
            else if (model.ExamState == EnumExamState.Start)
            {
                // 考试状态（已开始）
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamState].Tag = Const.Tag_ExamState_Start;
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Start_PicRPath);
            }
            else if (model.ExamState == EnumExamState.Over)
            {
                // 考试状态（已结束）
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamState].Tag = Const.Tag_ExamState_Over;
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Over_PicRPath);
            }

            // 考试内容
            string examinationID = model.ExaminationID;

            DataSet dsExamination = _ExaminationBLL.GetExaminationInfoByExaminationID(examinationID);

            if (dsExamination.Tables[0].Rows.Count > 0)
            {
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExaminationContent].Value = dsExamination.Tables[0].Rows[0][ExaminationModel.ColumnName_ExaminationName].ToString();
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExaminationID].Value = dsExamination.Tables[0].Rows[0][ExaminationModel.ColumnName_ExaminationID].ToString();
            }

            // 考生姓名
            string examineeID = model.ExamineeID;

            DataSet dsExaminee = _ExamineeBLL.GetExamineeInfoByExamineeID(examineeID);

            if (dsExaminee.Tables[0].Rows.Count > 0)
            {
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamineeName].Value = dsExaminee.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeName].ToString();
                this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamineeID].Value = dsExaminee.Tables[0].Rows[0][ExamineeModel.ColumnName_ExamineeID].ToString();
            }

            // 考试机状态（占用）
            this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamPCState].Tag = Const.Tag_ExamPCState_Busy;
            this.MCS_DataGridView.Rows[index].Cells[ExaminationPCModel.ColumnName_ExamPCState].Value = Image.FromFile(_AppStartPath + Const.ExamPCState_Busy_PicRPath);

            // add by wuxin at 2018/10/14 - start
            // 考试结果编号
            this.MCS_DataGridView.Rows[index].Cells["ExaminationResultID"].Value = model.ExaminationResultID;
            // add by wuxin at 2018/10/14 - end
        }

        /// <summary>
        /// 回收/分配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MCS_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = this.MCS_DataGridView.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    ExaminationPCModel model = new ExaminationPCModel();

                    //MessageBox.Show(e.RowIndex.ToString());

                    model.Index = e.RowIndex;

                    // 开关机状态
                    string strOpenOrClosePCState = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag.ToString();

                    // 开关机状态 ！= 开机
                    if (strOpenOrClosePCState != Const.Tag_OpenOrClosePCState_Open)
                    {
                        Alert.alert("当前考试机未开机！", "回收/分配失败");
                        return;
                    }

                    model.OpenOrClosePCState = EnumOpenOrClosePCState.Open;

                    // C#Client连接状态
                    string strConnectionState = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ConnectionState].Tag.ToString();

                    // C#Client连接状态
                    if (strConnectionState != Const.Tag_ConnectionState_Connected)
                    {
                        Alert.errorMsg("C#Client未连接到服务器，请检查以下内容：\n" + "1、检查网络状况。\n" + "2、检查C#Client软件是否启动，如未启动，请手动启动。\n" + "3、联系软件提供商。");
                        return;
                    }

                    model.ConnectionState = EnumConnectionState.Connected;

                    // 考试系统状态
                    string strExamAppOpenState = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ExamAppOpenState].Tag.ToString();

                    // C#Client连接状态
                    if (strExamAppOpenState == Const.Tag_ExamAppOpenState_Open)
                    {
                        model.EnumExamAppOpenState = EnumExamAppOpenState.Open;
                    }
                    else
                    {
                        model.EnumExamAppOpenState = EnumExamAppOpenState.Close;
                    }

                    // 考试编号
                    string strExaminationID = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ExaminationID].Value.ToString();
                    model.ExaminationID = strExaminationID;

                    // 考生编号
                    string strExamineeID = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ExamineeID].Value.ToString();
                    model.ExamineeID = strExamineeID;

                    // 考试状态
                    string strExamState = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ExamState].Tag.ToString();

                    if (strExamState == Const.Tag_ExamState_Empty)
                    {
                        model.ExamState = EnumExamState.Empty;
                    }
                    else if (strExamState == Const.Tag_ExamState_NoStart)
                    {
                        model.ExamState = EnumExamState.NoStart;
                    }
                    else if (strExamState == Const.Tag_ExamState_Start)
                    {
                        model.ExamState = EnumExamState.Start;
                    }
                    else if (strExamState == Const.Tag_ExamState_Over)
                    {
                        model.ExamState = EnumExamState.Over;
                    }

                    // 考试机状态
                    string strExamPCState = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ExamPCState].Tag.ToString();

                    if (strExamPCState == Const.Tag_ExamPCState_Idle)
                    {
                        model.ExamPCState = EnumExamPCState.Idle;
                    }
                    else if (strExamPCState == Const.Tag_ExamPCState_Busy)
                    {
                        model.ExamPCState = EnumExamPCState.Busy;
                    }

                    // ExamPCName
                    model.ExamPCName = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ExamPCName].Value.ToString();
                    // IP
                    model.IP = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();
                    // Mac
                    model.Mac = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_Mac].Value.ToString();

                    // add by wuxin at 2018/10/14 - start
                    // Type
                    model.Type = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_Type].Value.ToString();
                    // add by wuxin at 2018/10/14 - end

                    // add by wuxin at 2018/10/14 - start
                    model.ExaminationResultID = this.MCS_DataGridView.Rows[e.RowIndex].Cells["ExaminationResultID"].Value.ToString();
                    // add by wuxin at 2018/10/14 - end

                    回收分配界面 form = new 回收分配界面(model);
                    form.ShowDialog(this);
                }
            }
        }

        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void btnControlExamPC_Click(object sender, EventArgs e)
        {
            // 停止刷新网格信息
            MCS_DataGridView.EndEdit();
            // 关闭所有按钮响应
            EnableButton(false);

            // 应用按钮按下后显示信息
            
            // 执行动作选择内容
            string action = "";
            Action actionGetText = delegate() { action = this.cbAction.Text.Trim(); };
            this.Invoke(actionGetText);

            // 未选择执行内容
            if (action == String.Empty)
            {
                MessageBox.Show("请选择执行内容");

            }
            else if ((action == "开机"))
            {
                await Task.Run(() => DoAction("开机"));

            }
            else if ((action == "关机"))
            {
                string processName;

                // 要遍历应用程序列表， 控制了一些应用的关闭
                for (int i = 0; i < 主界面.GetSingleton().comboBox_process.Items.Count; i++)
                {
                    processName = 主界面.GetSingleton().comboBox_process.GetItemText(主界面.GetSingleton().comboBox_process.Items[i]);

                    if (processName != "")
                    {

                        MethodInvoker mi = new MethodInvoker(() =>
                        {
                            comboBox_process.SelectedIndex = 主界面.GetSingleton().comboBox_process.FindString(processName);

                            ProgressControls(false);

                            comboBox_process.SelectedIndex = 0;
                        });
                        主界面.GetSingleton().BeginInvoke(mi);
                    }
                }

                await Task.Run(() => DoAction("关机"));
            }
            else if ((action == "重启"))
            {
                await Task.Run(() => DoAction("重启"));
            }

            EnableButton(true);
        }

        /// <summary>
        /// 在进程开启或关闭操作时Enable或者Disable界面的button
        /// </summary>
        /// <param name="show"></param>
        private void EnableButton(bool ableState)
        {
            Action action = delegate()
            {
                this.btnControlExamPC.Enabled = ableState;
                this.button_device_on.Enabled = ableState;
                this.button_groupOn.Enabled = ableState;
                this.button_groupOff.Enabled = ableState;
                this.其他设备控制ToolStripMenuItem.Enabled = ableState;
                this.comboBox_group.Enabled = ableState;
                this.button_process_on.Enabled = ableState;
                this.button_process_off.Enabled = ableState;
            };
            this.Invoke(action);

        }

        public void DoAction(string action )
        {
            // 获取用户输入延迟时间
            float delay = float.Parse(textBox_delay.Text);
            // 更新用户时间到本地
            ConfigHelper.GetSingleton().UpdateAppConfig("ComputerStartDelay", delay.ToString());
            // 0.001s 判断
            if (delay < 0.001)
            {
                DialogResult dr = MessageBox.Show("请确认是否以小于0.001秒的延迟启动计算机", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    
                }
                else
                {
                    return;
                }
            }

            int row = MCS_DataGridView.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                // 找到选择的计算机
                if (Convert.ToBoolean(MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value) == true)
                {
                    // 跨线程修改winform
                    //MethodInvoker mi = new MethodInvoker(() =>
                    //{

                    // Ip地址
                    string showIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();
                    // Mac地址
                    string showMac = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Mac].Value.ToString();

                    // 控制项
                    switch (action)
                    {
                        case "开机":

                            // 这里应该是通过局域网主板MAC地址启动，类似于向日葵远程桌面的功能，需要主板支持
                            MyTool.WakeUpComputer(showMac);

                            // 重新设置状态图片
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Value = Image.FromFile(_AppStartPath + Const.ComputerOpeningPicRPath);
                            // 重新设置状态文字
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag = Const.Tag_OpenOrClosePCState_Opening;

                            break;
                        case "关机":
                            // 如果设备在已连接状态
                            if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Tag == Const.Tag_ConnectionState_Connected)
                            {
                                // 发送消息关机 这里参数 0 应该是关机，1 是重启
                                RabbitMQEventBus.GetSingleton().Trigger<R_C_ControlPowerData>(showIP, new R_C_ControlPowerData(0));
                            }
                            // 如果设备在未连接状态
                            else if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Tag == Const.Tag_ConnectionState_NoConnection)
                            {
                                // 通过命令行关机 shutdown -s -m \\\\" + ip + " -t 1
                                MyTool.ShutDownComputer(showIP);
                            }
                            // 重新设置状态图片
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Value = Image.FromFile(_AppStartPath + Const.ComputerClosingPicRPath);
                            // 重新设置状态文字
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag = Const.Tag_OpenOrClosePCState_Closing;

                            LogHelper.WriteLog("客户端（" + showIP + "）正在关机...");

                            // 考试机状态
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Empty_PicRPath);
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Tag = Const.Tag_ExamState_Empty;

                            break;
                        case "重启":
                            // 发送消息关机 这里参数 0 应该是关机，1 是重启
                            RabbitMQEventBus.GetSingleton().Trigger<R_C_ControlPowerData>(showIP, new R_C_ControlPowerData(1));
                            break;
                        default:
                            break;
                    }
                    //});
                    //主界面.GetSingleton().BeginInvoke(mi);

                    if (action != "关机")
                    {
                        Thread.Sleep((int)(delay * 1000));
                    }
                }
            }
        }

        /// <summary>
        /// 获取局域网某个ip是否能ping通
        /// </summary>
        private void HuntComputers()
        {
            try
            {
                // 赋值给IPlist
                lock (lockPingIp)
                {
                    // 将上次查找的ip保存。防止在两次查找间隔过程中清空了_IPBag导致应用到_IPBag的里面为空
                    // 这样会导致IPList是_IPBag延迟定长的结果
                    IPDict.Clear();
                    foreach (var item in _IPDict)
                    {
                        IPDict[item.Key] = item.Value;
                    }
                }
                // 清空_IPBag
                string tmp = "";
                while (!_IPDict.IsEmpty)
                {
                    _IPDict.Clear();
                }

                DataSet ds_device_ip = _GetDeviceInfoBLL.GetDeviceIPInfo();
                foreach (DataRow row in ds_device_ip.Tables[0].Rows)
                {
                    string ip = row[DeviceControlModel.DB_IP].ToString();
                    _ping(ip);
                }

                DataSet ds_pc_info = _ExaminationPCBLL.GetAllExaminationPCInfo();
                foreach (DataRow row in ds_pc_info.Tables[0].Rows)
                {
                    string ip = row[ExaminationPCModel.ColumnName_IP].ToString();
                    _ping(ip);
                }
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error(string.Format("局域网中ping发生异常 {0}", e.Message));
            }
        }

        private void _ping(string pingIP)
        {
            if (pingIP == "")
            {
                // 过于频繁 关闭log
                // NlogHandler.GetSingleton().Error(string.Format("pingIp 中的ip 地址不能为null"));
                return;
            }

            Ping myPing;
            myPing = new Ping();
            myPing.PingCompleted += new PingCompletedEventHandler(_myPing_PingCompleted);
            
            myPing.SendAsync(pingIP, 1000, null);
        }

        private void _myPing_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            if(e.Reply == null)
                return;

            if (e.Reply.Status == IPStatus.Success)
            {
                _IPDict[e.Reply.Address.ToString()] = e.Reply.RoundtripTime.ToString();
            }
            else
            {
                //MessageBox.Show(e.Reply.Address.ToString());
            }
        }


        /// <summary>
        /// 更新考试机开关机状态
        /// </summary>
        private void UpdateExamPCPowerState()
        {
            // 更新开关机状态
            // UpdatePowerState();

            bool open = false;

            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; Interlocked.Increment(ref i))
            {
                string showIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                if (IPDict.ContainsKey(showIP))
                    open = true;
                else
                    open = false;

                string tag = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag.ToString();

                if (open == true && tag != Const.Tag_OpenOrClosePCState_Closing && tag != Const.Tag_OpenOrClosePCState_Open)
                {
                    SetPowerState(i, true);

                    LogHelper.WriteLog("客户端（" + showIP + "）已开机。");

                    // 考试机状态
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Value = Image.FromFile(_AppStartPath + Const.ExamPCState_Idle_PicRPath);
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Tag = Const.Tag_ExamPCState_Idle;

                }
                else if (open == false && tag != Const.Tag_OpenOrClosePCState_Opening && tag != Const.Tag_OpenOrClosePCState_Closed)
                {
                    SetPowerState(i, false);

                    LogHelper.WriteLog("客户端（" + showIP + "）已关机。");

                    // 考试机状态
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Empty_PicRPath);
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Tag = Const.Tag_ExamState_Empty;
                }
            }
        }

        /// <summary>
        /// 更新开关机状态
        /// </summary>
        private void UpdatePowerState()
        {

            void GetAndChangeState(string ip)
            {
                for (int i = 0; i < this.MCS_DataGridView.Rows.Count; Interlocked.Increment(ref i))
                {
                    string showIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                    if (showIP != ip)
                        continue;

                    bool open = LibUtilities.IsComputerPowerOn(showIP);
                    string tag = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag.ToString();

                    if (open == true && tag != Const.Tag_OpenOrClosePCState_Closing && tag != Const.Tag_OpenOrClosePCState_Open)
                    {
                        SetPowerState(i, true);

                        LogHelper.WriteLog("客户端（" + showIP + "）已开机。");

                        // 考试机状态
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Value = Image.FromFile(_AppStartPath + Const.ExamPCState_Idle_PicRPath);
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Tag = Const.Tag_ExamPCState_Idle;

                    }
                    else if (open == false && tag != Const.Tag_OpenOrClosePCState_Opening && tag != Const.Tag_OpenOrClosePCState_Closed)
                    {
                        SetPowerState(i, false);

                        LogHelper.WriteLog("客户端（" + showIP + "）已关机。");

                        // 考试机状态
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Empty_PicRPath);
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCState].Tag = Const.Tag_ExamState_Empty;
                    }
                }
            }

            // 更新计算机开关机状态
            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; Interlocked.Increment(ref i))
            {
                string showIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                Task.Run(() => GetAndChangeState(showIP));

                // 判断是否开关机
            }


        }

        /// <summary>
        /// 设置开关机状态
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="powerOn"></param>
        private void SetPowerState(int rowIndex, bool powerOn)
        {
            if (powerOn)
            {
                this.MCS_DataGridView.Rows[rowIndex].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Value = Image.FromFile(_AppStartPath + Const.ComputerOpenPicRPath);

                this.MCS_DataGridView.Rows[rowIndex].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag = Const.Tag_OpenOrClosePCState_Open;
            }
            else
            {
                this.MCS_DataGridView.Rows[rowIndex].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Value = Image.FromFile(_AppStartPath + Const.ComputerClosedPicRPath);

                this.MCS_DataGridView.Rows[rowIndex].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag = Const.Tag_OpenOrClosePCState_Closed;
            }
        }

        public class UpdateCC_ClientConnectionState_Args
        {
            public string ip { get; set; }
            public bool connect { get; set; }
        }


        public void UpdateCC_ClientConnectionState(object state)
        {
            string ip = ((UpdateCC_ClientConnectionState_Args) state).ip;
            bool connect = ((UpdateCC_ClientConnectionState_Args)state).connect;

            if (ip != "")
            {

                // 更新计算机连接状态
                for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
                {

                    string dgvShowIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                    bool result = false;

                    if (dgvShowIP != ip)
                    {
                        continue;
                    }

                    // 先清空form上的显示
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CpuRatio].Value = string.Format("");
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Memory].Value = string.Format("");
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_TickCount].Value = string.Format("");
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ProcessState].Value = string.Format("");
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_GpuRatio].Value = string.Format("");
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_GpuMemoryRatio].Value = string.Format("");
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value = string.Format("");
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Value = string.Format("");

                    if (connect)
                    {
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Value = Image.FromFile(_AppStartPath + Const.ConnectionState_Connected_PicRPath);
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Tag = Const.Tag_ConnectionState_Connected;



                        if (connectedIP.Contains(ip))
                        {
                            continue;
                        }
                        else
                        {
                            lock (lockConnectedIp)
                            {
                                connectedIP.Add(ip);
                            }
                        }
                    }
                    else
                    {
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Value = Image.FromFile(_AppStartPath + Const.ConnectionState_NoConnection_PicRPath);
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Tag = Const.Tag_ConnectionState_NoConnection;

                        if (connectedIP.Contains(ip))
                        {
                            lock (lockConnectedIp)
                            {
                                connectedIP.Remove(ip);
                            }
                        }
                        else
                        {
                            continue;
                        }
                        
                    }

                }
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            int row = MCS_DataGridView.Rows.Count;//得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (cbAllSelect.CheckState == CheckState.Checked)
                {
                    //MCS_DataGridView.Rows[i].Selected = true;
                    MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = true;
                }
                else if (cbAllSelect.CheckState == CheckState.Unchecked)
                {
                    //MCS_DataGridView.Rows[i].Selected = false;
                    MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = false;
                }
            }

            MCS_DataGridView.EndEdit();


            //int count = this.MCS_DataGridView.Rows.Count;

            //if (count > 0)
            //{
            //    if (this.cbAllSelect.Checked)
            //    {
            //        SetGVAllCheckBoxState(true);
            //    }
            //    else
            //    {
            //        SetGVAllCheckBoxState(false);
            //    }
            //}
        }

        /// <summary>
        /// 设置当前GV所有CheckBox状态
        /// </summary>
        /// <param name="flag"></param>
        //private void SetGVAllCheckBoxState(bool flag)
        //{
        //    int count = this.MCS_DataGridView.Rows.Count;

        //    for (int i = 0; i < count; i++)
        //    {
        //        this.MCS_DataGridView.Rows[i].Cells[0].Value = flag;
        //    }
        //}

        private void MCS_DataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.MCS_DataGridView.IsCurrentCellDirty)
            {

                this.MCS_DataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //为什么要使用this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit); 
                //因为当我们对 checkbox 的 cell 进行编辑后，你会看到在 RowHeader 上显示一个笔的形状的东西，这说明此列正在编辑，如果直接用 Value 获取值，则会获得在编辑之前的值，
                //使用了 CommitEdit 方法后，我们再调用 Value 属性就会获得你看到的值，当然这句话也可以放在 dataGridView 的事件里面进行处理，就不需要再每次遍历之前执行这句了。
            }
        }

        /// <summary>
        /// 与MCS_DataGridView_CellClick功能冲突
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MCS_DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            

            //if (e.RowIndex >= 0 && this.MCS_DataGridView.Rows.Count > 0)
            //{
            //    //MessageBox.Show("aaa");
            //    if (this.MCS_DataGridView.Columns[e.ColumnIndex].Name.Equals("CheckBox"))
            //    {
            //        string ip = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();
            //        string mac = this.MCS_DataGridView.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_Mac].Value.ToString();



            //        // 获得checkbox 列单元格
            //        DataGridViewCheckBoxCell dgvCheckBoxCell = this.MCS_DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

            //        bool flag = Convert.ToBoolean(dgvCheckBoxCell.Value);

            //        if (flag)
            //        {
            //            // 增加选中
            //            this.MCS_DataGridView.Rows[e.RowIndex].Selected = true;

            //            //if (!_SelectedIPList.Contains(ip))
            //            //    _SelectedIPList.Add(ip);
            //            //if (!_SelectedMacList.Contains(mac))
            //            //    _SelectedMacList.Add(mac);
            //        }
            //        else
            //        {
            //            // 删除选中
            //            this.MCS_DataGridView.Rows[e.RowIndex].Selected = false;

            //            //if (_SelectedIPList.Contains(ip))
            //            //    _SelectedIPList.Remove(ip);
            //            //if (_SelectedMacList.Contains(mac))
            //            //    _SelectedMacList.Remove(mac);
            //        }
            //    }
            //}
        }


        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 主界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 存在被占用的考试机，是否要回收占用的考试机并关闭主控系统
            if (MessageBox.Show("是否确认退出？", "退出", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int row = MCS_DataGridView.Rows.Count;//得到总行数  

                string runProcessName = "";

                DataSet ds_appInfo = 进程管理.GetSingleton()._GetAllAppInfoBLL.GetAllAppinfo();

                for (int i = 0; i < row; i++) //得到总行数并在之内循环  
                {
                    string ip = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value
                        .ToString();

                    if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ProcessState].Value != null)
                        runProcessName = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ProcessState].Value.ToString();

                    List<string> runProcessNameArray = runProcessName.Split(',').ToList();

                    foreach (var processName in runProcessNameArray)
                    {
                        DataRow[] dr = ds_appInfo.Tables[0].Select(string.Format("AppName = '{0}' and IP = '{1}'", processName, ip));

                        if (dr.Count() > 1)
                        {
                            // MessageBox.Show("进程数据库表访问出现问题!");
                        }
                        else if (dr.Count() == 1)
                        {
                            string processPathName = dr[0][ProcessControlModel.DB_Path].ToString();
                            RabbitMQEventBus.GetSingleton().Trigger<R_C_ControlProcessData>(ip, new R_C_ControlProcessData(processPathName, false)); //直接通过事件总线触发
                        }
                    }


                }

                //DataSet ds_appInfo = 进程管理.GetSingleton()._GetAllAppInfoBLL.GetAllAppinfo();

                //// 关闭客户端由服务端启动的进程
                //foreach (string ip in 进程管理.GetSingleton().processDict.Keys)
                //{
                //    foreach (string processName in 进程管理.GetSingleton().processDict[ip])
                //    {
                //        DataRow[] dr = ds_appInfo.Tables[0].Select(string.Format("AppName = '{0}' and IP = '{1}'", processName, ip));

                //        if (dr.Count() > 1)
                //        {
                //            MessageBox.Show("进程数据库表访问出现问题!");
                //        }
                //        else if (dr.Count() == 1)
                //        {
                //            string processPathName = dr[0][ProcessControlModel.DB_Path].ToString();
                //            RabbitMQEventBus.GetSingleton().Trigger<R_C_ControlProcessData>(ip, new R_C_ControlProcessData(processPathName, false)); //直接通过事件总线触发
                //        }

                //    }
                //}
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void 主界面_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.WriteLog("服务器关闭！");
        }

        /// <summary>
        /// 修改主界面考试机列表中的考试状态
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="logic"></param>
        public void UpdateDgvState(string ip, string logic)
        {
            //MessageBox.Show(ip + ":" + logic);

            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
            {
                string dgvShowIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                if (dgvShowIP == ip)
                {
                    // add by wuxin at 2018/10/17 - start
                    // 考试软件打开的情况下，才去判断考试状态是已开始还是已关闭
                    if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamAppOpenState].Tag == Const.Tag_ExamAppOpenState_Open)
                    {
                        // add by wuxin at 2018/10/17 - end
                        if (logic == "ExamStart")
                        {
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Start_PicRPath);
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamState].Tag = Const.Tag_ExamState_Start;
                        }
                        else if (logic == "ExamOver")
                        {
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamState].Value = Image.FromFile(_AppStartPath + Const.ExamState_Over_PicRPath);
                            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamState].Tag = Const.Tag_ExamState_Over;
                        }
                    }
                }
            }
        }

        public class UpdateSystemState_Args
        {
            public string ip { get; set; }
            public float cpu { get; set; }
            public float memory { get; set; }
            public int tickCount { get; set; }
            public float gpu_ratio { get; set; }
            public float gpu_memory_ratio { get; set; }

        }
        public void UpdateSystemState(object state)
        {
            string ip = ((UpdateSystemState_Args) state).ip;
            float cpu = ((UpdateSystemState_Args) state).cpu;
            float memory = ((UpdateSystemState_Args)state).memory;
            int tickCount = ((UpdateSystemState_Args)state).tickCount;
            float gpu_ratio = ((UpdateSystemState_Args)state).gpu_ratio;
            float gpu_memory_ratio = ((UpdateSystemState_Args)state).gpu_memory_ratio;


            //MessageBox.Show(ip + ":" + logic);

            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
            {
                string dgvShowIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                if (dgvShowIP == ip)
                {
                    if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Tag !=
                        Const.Tag_ConnectionState_Connected)
                    {
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Value = Image.FromFile(_AppStartPath + Const.ConnectionState_Connected_PicRPath);
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ConnectionState].Tag = Const.Tag_ConnectionState_Connected;

                        if (!connectedIP.Contains(ip))
                        {
                            connectedIP.Add(ip);
                        }
                    }

                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CpuRatio].Value = string.Format("{0}%", cpu.ToString("f2"));
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Memory].Value = string.Format("{0}G", (memory/1000).ToString("f2"));
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_TickCount].Value = string.Format("{0}h:{1}m", (int)(tickCount / 1000 / 3600), (int)(tickCount / 1000 % 3600 / 60));
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_GpuRatio].Value = string.Format("{0}%", gpu_ratio.ToString("f2"));
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_GpuMemoryRatio].Value = string.Format("{0}%", gpu_memory_ratio.ToString("f2"));
                }
            }
        }

        public class UpdateCltSteteo_Args
        {
            public string ip { get; set; }
            public int m_swapEye { get; set; }
            public int m_stereoOn { get; set; }
        }

        public void UpdateCltStereo(object state)
        {
            string ip = ((UpdateCltSteteo_Args)state).ip;
            int m_swapEye = ((UpdateCltSteteo_Args)state).m_swapEye;
            int m_stereoOn = ((UpdateCltSteteo_Args)state).m_stereoOn;

            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
            {
                string dgvShowIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                if (dgvShowIP == ip)
                {
                    // 立体
                    if (m_stereoOn == 1)
                    {
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value = "开";
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Style.ForeColor = Color.Green;
                    }
                    else if (m_stereoOn == 0)
                    {
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value = "关";
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Style.ForeColor = Color.Red;
                    }

                    // 左右眼
                    if (m_swapEye == 1)
                    {
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Value = "开";
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Style.ForeColor = Color.Green;
                    }
                    else if (m_swapEye == 0)
                    {
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Value = "关";
                        this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Style.ForeColor = Color.Red;
                    }

                    // _log.Log("收到客户端响应：立体状态" + "->" + data.m_stereoOn + "，" + "左右眼状态" + " -> " + data.m_swapEye + "（" + ip + ")");

                }
            }
        }

        public void UpdateProcessState(string ip, List<string> processNameList)
        {
            DataSet ds_appInfo = 进程管理.GetSingleton()._GetAllAppInfoBLL.GetAllAppinfo();

            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
            {
                string dgvShowIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                if (dgvShowIP == ip)
                {
                    List<string> runningProcessList = new List<string>();

                    foreach (var processName in processNameList)
                    {
                        DataRow[] dr = ds_appInfo.Tables[0].Select(string.Format("FilePath like '%{0}%' and IP = '{1}'", processName, ip));

                        if (dr.Count() > 1)
                        {
                            //NlogHandler.GetSingleton().Error(string.Format("进程数据库表访问出现问题  {0}", processName));
                            //MessageBox.Show("进程数据库表访问出现问题!");
                        }
                        else if (dr.Count() == 1)
                        {

                            runningProcessList.Add(dr[0][ProcessControlModel.DB_Name].ToString());
                        }
                    }

                    //string allProcessName = string.Join(",", runningProcessList.Distinct().ToList().ToArray());
                    string allProcessName = string.Join(",", runningProcessList.ToList().ToArray());

                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ProcessState].Value = string.Format(allProcessName);
                }
            }
        }


        //public class UpdateProcessState_Args
        //{
        //    public string ip { get; set; }
        //    public bool isRun { get; set; }
        //    public string processName { get; set; }

        //}
        //public void UpdateProcessState(object state)
        //{
        //    //MessageBox.Show(ip + ":" + logic);

        //    string ip = ((UpdateProcessState_Args)state).ip;
        //    bool isRun = ((UpdateProcessState_Args) state).isRun;
        //    string processName = ((UpdateProcessState_Args)state).processName;

        //    for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
        //    {
        //        string dgvShowIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();


        //        if (dgvShowIP == ip)
        //        {
        //            string runProcessName = "";
        //            if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ProcessState].Value != null)
        //                runProcessName = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ProcessState].Value.ToString();

        //            string[] runProcessNameArray = runProcessName.Split(',');
        //            List<string> runProcessNameList = new List<string>(runProcessNameArray);

        //            if (isRun)
        //            {
        //                if (!runProcessNameList.Contains(processName))
        //                    runProcessNameList.Add(processName);

        //            }
        //            else
        //            {
        //                if (!runProcessNameList.Contains(processName))
        //                    runProcessNameList.Remove(processName);
        //            }

        //            runProcessNameList.Remove("");

        //            string allProcessName = string.Join(",", runProcessNameList.ToArray());

        //            this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ProcessState].Value = string.Format(allProcessName);
        //        }
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
       {
            // 获取局域网所有ping通IP
            HuntComputers();

            // 根据能ping通的IPList判断开机状态
            UpdateExamPCPowerState();

            // 获取客户端的系统状态和客户端的延迟
            UpdatePCSystemState();

            // 获取客户端运行进程的信息（通过进程管理打开的进程）
            UpdateProcessState();

        }

        /// <summary>
        /// 向客户端发送获取当前系统状态的指令，只在DatagridView上显示已开机的pc发送
        /// 更新网络延迟
        /// </summary>
        private void UpdatePCSystemState()
        {
            // 只在DatagridView上显示已开机的pc发送
            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; Interlocked.Increment(ref i))
            {
                string showIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                string tag = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag.ToString();

                if ( tag == Const.Tag_OpenOrClosePCState_Open)
                {
                    // 更新网络延迟
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_NetDelay].Value = IPDict[showIP];

                    // 发送获取客户端状态的消息
                    RabbitMQEventBus.GetSingleton().Trigger<R_C_SystemStateData>(showIP, new R_C_SystemStateData());//直接通过事件总线触发
                }
            }
        }

        /// <summary>
        /// 获取客户端的某个process的状态
        /// </summary>
        private void UpdateProcessState()
        {
            R_C_ProcessStateData sendData = new R_C_ProcessStateData();

            sendData.ProcessNameList = new List<string>();

            string processName;

            DataSet ds_appInfo = 进程管理.GetSingleton()._GetAllAppInfoBLL.GetAllAppinfo();

            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; Interlocked.Increment(ref i))
            {
                string showIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                string tag = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag.ToString();

                sendData.ProcessNameList.Clear();

                if (tag == Const.Tag_OpenOrClosePCState_Open)
                {
                    for (int j = 0; j < 主界面.GetSingleton().comboBox_process.Items.Count; j++)
                    {
                        processName = 主界面.GetSingleton().comboBox_process.GetItemText(主界面.GetSingleton().comboBox_process.Items[j]);

                        if (processName != "")
                        {
                            DataRow[] dr = ds_appInfo.Tables[0].Select(string.Format("AppName = '{0}' and IP = '{1}'", processName, showIP));

                            if (dr.Count() > 1)
                            {
                                // MessageBox.Show("进程数据库表访问出现问题!");
                                // NlogHandler.GetSingleton().Error(string.Format("访问数据库中的应用数据信息访问出现错误，检查是否数据库中出现了两个同样的应用名称"));
                            }
                            else if (dr.Count() == 1)
                            {
                                string processPathName = dr[0][ProcessControlModel.DB_Path].ToString();
                                string onlyName = Path.GetFileName(processPathName).Replace(".exe", "");
                                sendData.ProcessNameList.Add(onlyName);
                            }
                        }
                    }

                    RabbitMQEventBus.GetSingleton().Trigger<R_C_ProcessStateData>(showIP, sendData);//直接通过事件总线触发
                }
            }
        }

        #region 菜单
        private void 考试成绩管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            考试成绩查询 form = new 考试成绩查询();
            form.ShowDialog();
        }

        private void 考生管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Instance.IsHasAdminLevel)
            {
                考生信息管理界面 form = new 考生信息管理界面();
                form.ShowDialog();
            }
            else
            {
                Alert.alert("无管理员权限！");
            }
        }

        private void 考生所属公司管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Instance.IsHasAdminLevel)
            {
                考生所属公司信息管理 form = new 考生所属公司信息管理();
                form.ShowDialog();
            }
            else
            {
                Alert.alert("无管理员权限！");
            }
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Instance.IsHasAdminLevel)
            {
                用户管理 form = new 用户管理();
                form.ShowDialog();
            }
            else
            {
                Alert.alert("无管理员权限！");
            }
        }

        /// <summary>
        /// 数据库备份
        /// </summary>
        private void DatabaseBackupFunction()
        {
            string host = ConfigHelper.GetSingleton().GetAppConfig("DBhost");
            string port = ConfigHelper.GetSingleton().GetAppConfig("DBport");
            string user = ConfigHelper.GetSingleton().GetAppConfig("DBname");
            string password = ConfigHelper.GetSingleton().GetAppConfig("DBpassword");
            string database = ConfigHelper.GetSingleton().GetAppConfig("DBdatabasename");
            string fileName = database + "_bak_" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string bakPath = Application.StartupPath + "\\DBBackup\\" + fileName + ".sql";

            string mysqldumpPath = Application.StartupPath; // 注意：mysqldumpPath.exe所在路径的各级名称均不能带空格，否则不可执行！！！！！！！

            string cmdStr = "/c " + mysqldumpPath + "\\mysqldump -h" + host + " -P" + port + " -u" + user + " -p" + password + " -R -E " + database + " > " + bakPath;

            try
            {
                //String appDirecroty = System.Windows.Forms.Application.StartupPath + "\\";
                //Cmd.StartCmd(appDirecroty, cmdStr);

                System.Diagnostics.Process.Start("cmd", cmdStr);

                LogHelper.WriteLog("数据库自动备份成功！");
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("数据库自动备份失败！原因：" + ex.ToString());
            }
        }

        private void 备份数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string host = ConfigHelper.GetSingleton().GetAppConfig("DBhost");
            string port = ConfigHelper.GetSingleton().GetAppConfig("DBport");
            string user = ConfigHelper.GetSingleton().GetAppConfig("DBname");
            string password = ConfigHelper.GetSingleton().GetAppConfig("DBpassword");
            string database = ConfigHelper.GetSingleton().GetAppConfig("DBdatabasename");
            string fileName = database + "_bak_" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string bakPath = Application.StartupPath + "\\DBBackup\\" + fileName + ".sql";

            string mysqldumpPath = Application.StartupPath; // 注意：mysqldumpPath.exe所在路径的各级名称均不能带空格，否则不可执行！！！！！！！

            string cmdStr = "/c " + mysqldumpPath + "\\mysqldump -h" + host + " -P" + port + " -u" + user + " -p" + password + " -R -E " + database + " > " + bakPath;

            try
            {
                //String appDirecroty = System.Windows.Forms.Application.StartupPath + "\\";
                //Cmd.StartCmd(appDirecroty, cmdStr);

                System.Diagnostics.Process.Start("cmd", cmdStr);

                Alert.noteMsg("数据库备份成功！");
            }
            catch (Exception ex)
            {
                Alert.errorMsg("数据库备份失败！");
            }
        }

        private void 还原数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string host = ConfigHelper.GetSingleton().GetAppConfig("DBhost");
                string port = ConfigHelper.GetSingleton().GetAppConfig("DBport");
                string user = ConfigHelper.GetSingleton().GetAppConfig("DBname");
                string password = ConfigHelper.GetSingleton().GetAppConfig("DBpassword");
                string database = ConfigHelper.GetSingleton().GetAppConfig("DBdatabasename");

                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.InitialDirectory = Application.StartupPath + @"\DBBackup";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dbFilePath = openFileDialog.FileName;

                    string mysqldumpPath = Application.StartupPath; // 注意：mysql.exe所在路径的各级名称均不能带空格，否则不可执行！！！！！！！

                    string cmdStr = "/c " + mysqldumpPath + "\\mysql --force -h" + host + " -P" + port + " -u" + user + " -p" + password + " " + database + " < " + dbFilePath;

                    DialogResult result = MessageBox.Show("您是否真的想覆盖以前的数据库吗？那么以前的数据库数据将丢失！！！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        //Cmd.StartCmd(appDirecroty, command);

                        System.Diagnostics.Process.Start("cmd", cmdStr);

                        Alert.noteMsg("数据库还原成功！");
                    }
                }

            }
            catch (Exception ex)
            {
                Alert.errorMsg("数据库还原失败！");
            }
        }

        private void 打开系统日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //logPath ConfigurationManager.AppSettings["LogPath"] + "\\Service_Log.txt";

            // string logPath = Const.LogPath;

            string logPath = NlogHandler.GetSingleton().GetFileName();

            System.Diagnostics.Process.Start(logPath); //打开此文件。
        }

        private void 考试机配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.Instance.IsHasAdminLevel)
            {
                考试机配置 form = new 考试机配置();
                form.ShowDialog(this);
            }
            else
            {
                Alert.alert("无管理员权限！");
            }
        }

        private void 版本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // add by wuxin at 2018/6/8 - start
        private void 传输文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            传输文件.GetSingleton().ShowDialog();
            //传输文件 form = new 传输文件();
            //form.ShowDialog();
        }

        private void 考题管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            回收分配界面 form = new 回收分配界面();
            form.ShowDialog();

            //远程控制.GetSingleton().ShowControlWindow();
            //远程控制.GetSingleton().ShowDialog();



            //string strPathExe = @"C:\Users\DuoWei\Desktop\vnc\jsmpeg-vnc.exe";

            //string path = strPathExe.Substring(0, strPathExe.LastIndexOf('\\'));

            //Directory.SetCurrentDirectory(path);
            //Process process = new System.Diagnostics.Process();
            //process.StartInfo.FileName = strPathExe;
            //process.StartInfo.Arguments = "desktop";//-s -t 可以用来关机、开机或重启
            //process.StartInfo.UseShellExecute = false;
            //process.StartInfo.RedirectStandardInput = false;  //true
            //process.StartInfo.RedirectStandardOutput = false;  //true
            //process.StartInfo.RedirectStandardError = false;
            //process.StartInfo.CreateNoWindow = true;
            //process.Start();

        }

        private void 考试相关信息录入界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            考试相关信息录入界面 form = new 考试相关信息录入界面();
            form.ShowDialog();
        }

        private void lnkyzhangToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 主界面_Load(object sender, EventArgs e)
        {

        }


        private void 主界面_Load_1(object sender, EventArgs e)
        {

        }

        private void 进程管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //进程管理 form = new 进程管理();
            //form.ShowDialog();
            进程管理.GetSingleton().ShowDialog();
        }

        private void 测试配置文件xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            配置文件 form = new 配置文件();
            form.ShowDialog();
        }

        private void 其他设备管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //其他设备控制 form = new 其他设备控制();
            //form.ShowDialog();
            其他设备控制.GetSingleton().ShowDialog();
        }

        /// <summary>
        /// 刷新左右眼和立体开关状态
        /// 只刷新checkbox选中的行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button_refresh_Click(object sender, EventArgs e)
        {
            MCS_DataGridView.EndEdit();

            if (e != null)
            {
                if (GetCheckBoxCheckedCount() == 0)
                {
                    MessageBox.Show("如果想要刷新翻转状态，请选择要刷新客户端!");
                    return;
                }
            }

            // 先清空form上的显示
            // 否则一旦断开了数据还在显示
            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
            {
                if (Convert.ToBoolean(this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value))
                {
                    string showIP = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                    //string tag = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag.ToString();
                    //this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value = string.Format("  ");
                    //this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Value = string.Format("  ");


                    RabbitMQEventBus.GetSingleton().Trigger<R_C_GetCltStereo>(showIP,new R_C_GetCltStereo());//直接通过事件总线触发

                }
            }


        }

        public void button_stereo_Click(object sender, EventArgs e)
        {
            MCS_DataGridView.EndEdit();

            if (e != null)
            {
                if (MessageBox.Show("请确认已点击刷新！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }

            string processName;

            for (int i = 0; i < 主界面.GetSingleton().comboBox_process.Items.Count; i++)
            {
                processName = 主界面.GetSingleton().comboBox_process.GetItemText(主界面.GetSingleton().comboBox_process.Items[i]);

                if (processName != "")
                {
                    comboBox_process.SelectedIndex = 主界面.GetSingleton().comboBox_process.FindString(processName);

                    ProgressControls(false);

                    comboBox_process.SelectedIndex = 0;

                }
            }

            int row = MCS_DataGridView.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (Convert.ToBoolean(MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value) == true)
                {
                    string ip = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                    //if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value == null)
                    //{
                    //    button_refresh_Click(null, null);
                    //}

                    if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value != null && this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Value != null)
                    {
                        string stereoState = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value.ToString();
                        string left_right = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Value.ToString();

                        C_NvStateData sendData = new C_NvStateData();

                        if (stereoState == "开")
                        {
                            sendData.m_stereoOn = 0;
                        }
                        else if (stereoState == "关")
                        {
                            sendData.m_stereoOn = 1;
                        }

                        if (left_right == "开")
                        {
                            sendData.m_swapEye = 1;
                        }
                        else if (left_right == "关")
                        {
                            sendData.m_swapEye = 0;
                        }

                        RabbitMQEventBus.GetSingleton().Trigger<C_NvStateData>(ip, sendData); //直接通过事件总线触发
                    }
                    else
                    {
                        if (MessageBox.Show("您没点击刷新!!!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            //button_refresh_Click(null, null);
        }

        public void button_leftRight_Click(object sender, EventArgs e)
        {
            MCS_DataGridView.EndEdit();

            if (MessageBox.Show("请确认已点击刷新！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
            }
            else
            {
                return;
            }

            string processName;

            for (int i = 0; i < 主界面.GetSingleton().comboBox_process.Items.Count; i++)
            {
                processName = 主界面.GetSingleton().comboBox_process.GetItemText(主界面.GetSingleton().comboBox_process.Items[i]);

                if (processName != "")
                {
                    comboBox_process.SelectedIndex = 主界面.GetSingleton().comboBox_process.FindString(processName);

                    ProgressControls(false);

                    comboBox_process.SelectedIndex = 0;

                }
            }

            int row = MCS_DataGridView.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (Convert.ToBoolean(MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value) == true)
                {
                    string ip = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                    //if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value == null)
                    //{
                    //    button_refresh_Click(null, null);
                    //}

                    if (this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value != null && this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Value != null)
                    {
                        string stereoState = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_Stereo].Value.ToString();
                        string left_right = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_LeftRight].Value.ToString();

                        C_NvStateData sendData = new C_NvStateData();

                        if (left_right == "开")
                        {
                            sendData.m_swapEye = 0;
                        }
                        else if (left_right == "关")
                        {
                            sendData.m_swapEye = 1;
                        }

                        if (stereoState == "开")
                        {
                            sendData.m_stereoOn = 1;
                        }
                        else if (stereoState == "关")
                        {
                            sendData.m_stereoOn = 2;
                        }

                        RabbitMQEventBus.GetSingleton().Trigger<C_NvStateData>(ip, sendData); //直接通过事件总线触发
                    }
                    else
                    {
                        if (MessageBox.Show("您没点击刷新!!!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            //button_refresh_Click(null, null);
        }


        #endregion

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 远程控制StripMenuItem_Click(object sender, EventArgs e)
        {
            // 创建 远程控制
            RemoteControl.GetSingleton();

            // 确保有且仅有一个客户机被选中
            if (GetCheckBoxCheckedCount() == 0)
            {
                MessageBox.Show("请进选中一个客户机");
            }
            else if (this.cbAllSelect.Checked == true)
            {
                MessageBox.Show("请取消全选状态");
            }
            else
            {
                // 给选中客户机发送执行远程控制命令
                for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value) == true)
                    {
                        string ip = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();
                        string processName = "jsmpeg-vnc.exe";
                        string processFilePathName = @".\jsmpeg-vnc.exe";

                        LogHelper.WriteLog(string.Format("目标计算机 ip: {0} 远程控制 {1}", ip, processName));

                        RabbitMQEventBus.GetSingleton()
                            .Trigger<R_C_RemoteControlData
                            >(ip, new R_C_RemoteControlData(true, "desktop")); //直接通过事件总线触发
                        // break;
                    }
                }

            }
        }

        private int GetCheckBoxCheckedCount()
        {
            int selectCount = 0;

            for (int i = 0; i < this.MCS_DataGridView.Rows.Count; i++)
            {
                if (Convert.ToBoolean(MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value) == true)
                {
                    selectCount++;
                }
            }

            return selectCount;
        }


        private void 更新客户端toolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 应用管理的启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button_process_on_Click(object sender, EventArgs e)
        {
            // await Task.Run(() => 其他设备控制.GetSingleton().ExecPlan("光闸打开"));
            if (GetCheckBoxCheckedCount() == 0 && sender != null && e != null)
            {
                if (MessageBox.Show("当前未选择客户机，是否全选?", Const.NOTES, MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cbAllSelect.Checked = true;
                }
                else
                {
                    return;
                }
            }

            ProgressControls(true);
            await Task.Run(() => DelayOpenRaster());
            
        }

        private void DelayOpenRaster()
        {
            Thread.Sleep(OpenRasterDelayTime);
            其他设备控制.GetSingleton().ExecPlan("光闸打开");
        }

        public void ProgressControls(bool isOn)
        { 
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                MCS_DataGridView.EndEdit();

                NlogHandler.GetSingleton().Info(string.Format("控制进程 , 当前线程ID {0}", Thread.CurrentThread.ManagedThreadId.ToString()));

                DataSet ds;

                string appName = comboBox_process.SelectedValue.ToString();

                // 应用管理
                ds = 进程管理.GetSingleton()._GetAllAppInfoBLL.GetAllAppinfoByName(appName);
                
                int row = MCS_DataGridView.Rows.Count; //得到总行数
                
                for (int i = 0; i < row; i++) //得到总行数并在之内循环  
                {
                    if (Convert.ToBoolean(MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value) == true)
                    {
                        string ip = MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();
                        string appPath = "";
                        
                        DataRow[] dr = ds.Tables[0].Select(string.Format("{0} = '{1}' and {2} = '{3}'", ProcessControlModel.DB_IP, ip, ProcessControlModel.DB_Name, appName));

                        if (dr.Length == 1)
                        {
                            appPath = dr[0][ProcessControlModel.DB_Path].ToString();
                        }
                        else
                        {
                            // MessageBox.Show("请确认应用信息!");
                        }

                        LogHelper.WriteLog(string.Format("目标计算机 ip: {0} 操作进程 {1} 开启状态：{2}", ip, appName, isOn));

                        NlogHandler.GetSingleton().Info($"准备启动 设备({ip}) App: {appName} AppPath: {appPath}");

                        RabbitMQEventBus.GetSingleton()
                            .Trigger<R_C_ControlProcessData
                            >(ip, new R_C_ControlProcessData(appPath, isOn)); //直接通过事件总线触发
                    }
                }
            });
            主界面.GetSingleton().Invoke(mi);
        }

        /// <summary>
        /// 应用管理的关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button_process_off_Click(object sender, EventArgs e)
        {
            EnableButton(false);

            ProgressControls(false);

            // 控制4D座椅
            _4D座椅.GetSingleton().SendMsg("STOP");

            await Task.Run(() => 其他设备控制.GetSingleton().ExecPlan("光闸关闭"));
            await Task.Run(() => Thread.Sleep(playVideoIntervalMS));

            EnableButton(true);
        }

        public async void button_device_on_Click(object sender, EventArgs e)
        {

            EnableButton(false);

            string planName = comboBox_device.Text.Trim();

            await Task.Run(() => 其他设备控制.GetSingleton().ExecPlan(planName));

            EnableButton(true);

        }

        private void DeviceControl(List<string> deviceList, bool isOn)
        {

            DataRow[] dr;

            List<string> controlName;
            List<string> deviceListTemp = new List<string>();

            foreach (string deviceName in deviceList)
            {
                // 无奈之举
                EnableButton(false);

                dr = 其他设备控制.GetSingleton().ds_device_all.Tables[0].Select(string.Format("{0} = '{1}'", DeviceControlModel.DB_Name, deviceName));

                if (dr.Length == 0)
                {
                    continue;
                }

                string className = dr[0][DeviceControlModel.DB_CLASS].ToString();

                controlName = 其他设备控制.GetSingleton().GetPowerControlName(className);

                if (controlName.Count == 2)
                {
                    deviceListTemp.Clear();
                    deviceListTemp.Add(deviceName);

                    if (isOn)
                    {
                        其他设备控制.GetSingleton().DeviceControl(deviceListTemp, controlName[0]);
                    }
                    else
                    {
                        其他设备控制.GetSingleton().DeviceControl(deviceListTemp, controlName[1]);
                    }
                }
                else
                {
                    NlogHandler.GetSingleton().Error(string.Format("检查其他设备的配置文件，是否包含类型名称 {0}", className));
                }

            }

            EnableButton(true);
        }

        private void 帮助ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            帮助界面 form = new 帮助界面();
            form.ShowDialog();
        }

        private void 版本信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            版本信息 form = new 版本信息();
            form.ShowDialog();
        }

        private void 分组信息StripMenuItem_Click(object sender, EventArgs e)
        {
            分组管理 form = new 分组管理();
            form.ShowDialog();
        }

        /// <summary>
        /// 分组控制启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void button_groupOn_Click(object sender, EventArgs e)
        {
            EnableButton(false);

            List<string> groupNameList = GetXmlGroupInfo(this.comboBox_group.Text);

            // 执行计算机控制
            this.cbAction.Text = "开机";

            for (int i = 0; i < this.MCS_DataGridView.RowCount; i++)
            {
                string pcName = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCName].Value.ToString();

                if (groupNameList.Contains(pcName))
                {
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = true;
                }
                else
                {
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = false;
                }
            }

            await Task.Run(() => btnControlExamPC_Click(null, null));

            await Task.Run(() => DeviceControl(groupNameList, true ));

            EnableButton(true);

        }

        /// <summary>
        /// 通过配置文件xml获取配置的设备信息
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public List<string> GetXmlGroupInfo(string groupName)
        {
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            string selectNode = "/configuration/StartUpGroup";

            List<XmlNode> groupNodes = XmlUtil.GetChildNodes(xmlDoc, selectNode, "");

            List<string> resultList = new List<string>();

            foreach (XmlNode node in groupNodes)
            {
                if (XmlUtil.GetAttribute(node, "name", "") == groupName)
                {
                    List<XmlNode> deviceNodes = XmlUtil.GetChildNodes(node, "", "");

                    foreach (XmlNode deviceNode in deviceNodes)
                    {
                        string deviceName = XmlUtil.GetAttribute(deviceNode, "name", "");

                        resultList.Add(deviceName);
                    }
                    break;
                }
            }

            return resultList;
        }

        /// <summary>
        /// 分组控制关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void button_groupOff_Click(object sender, EventArgs e)
        {

            EnableButton(false);

            // 执行计算机控制
            this.cbAction.Text = "关机";

            List<string> groupNameList = GetXmlGroupInfo(this.comboBox_group.Text);

            for (int i = 0; i < this.MCS_DataGridView.RowCount; i++)
            {
                string pcName = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCName].Value.ToString();

                if (groupNameList.Contains(pcName))
                {
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = true;
                }
                else
                {
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = false;
                }
            }

            await Task.Run(() => btnControlExamPC_Click(null, null));

            await Task.Run(() => DeviceControl(groupNameList, false ));

            EnableButton(true);
        }

        private void 刷新StripMenuItem1_Click(object sender, EventArgs e)
        {
            // 整体刷新 相当于重新load主界面
            ShortCutLoad();

            timer1_Tick(null, null);

            // 清空并重新加载考试机数据
            LoadData();

            this.cbAllSelect.Checked = false;
        }

        private void 主界面_KeyDown(object sender, KeyEventArgs e)
        {
            //如果同时按下了 ctrl键和D键，弹出信息框
            if (e.Alt && e.KeyCode == Keys.C)
            {
                更新客户端 form = new 更新客户端();
                form.ShowDialog();
            }

            // 如果同时按下alt+d：
            if (e.Alt && e.KeyCode == Keys.D)
            {
                if (ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "1" || ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "2")
                {
                    fuxinHuanmuLabShow(false);
                }
                else if (ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "3")
                {
                    OfficeDemonstrationAreaShow(false);
                }

                fullShow(true);
            }


            // 如果同时按下alt+f:
            if (e.Alt && e.KeyCode == Keys.J)
            {
                if (ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "1" || ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "2")
                {
                    fuxinHuanmuLabShow(true);
                }
                else if (ConfigHelper.GetSingleton().GetAppConfig("LiteVersion") == "3")
                {
                    OfficeDemonstrationAreaShow(true);
                }
                else
                {
                    fullShow(false);
                }
            }
        }

        /// <summary>
        /// 分组控制，单机之后会选中该分组下所有计算机（不包括设备）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbAllSelect.Checked = false;

            List<string> groupNameList = GetXmlGroupInfo(this.comboBox_group.Text);

            for (int i = 0; i < this.MCS_DataGridView.RowCount; i++)
            {
                string pcName = this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCName].Value.ToString();

                if (groupNameList.Contains(pcName))
                {
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = true;
                }
                else
                {
                    this.MCS_DataGridView.Rows[i].Cells[ExaminationPCModel.ColumnName_CheckBox].Value = false;
                }
            }

        }

        /// <summary>
        /// 外部程序调用更改comboBox_group的值，来主动调用comboBox_group_SelectedIndexChanged事件
        /// </summary>
        /// <param name="groupName"></param>
        public void ComboBoxGroupSelectChange(string groupName)
        {
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (this.comboBox_group.Items.Contains(groupName))
                {
                    this.comboBox_group.SelectedIndex = this.comboBox_group.FindString(groupName);
                }

                NlogHandler.GetSingleton().Error(string.Format("ComboBoxGroupSelectChange 完成 groupName : {0}", groupName));

            });
            主界面.GetSingleton().Invoke(mi);
        }

        public void ComboBoxProgressSelectChange(string progressName)
        {
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (this.comboBox_process.FindString(progressName) > -1)
                {
                    this.comboBox_process.SelectedIndex = this.comboBox_process.FindString(progressName);
                }

            });
            主界面.GetSingleton().BeginInvoke(mi);
        }

        public void PlayControlLabelLastSeting(string last)
        {
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                this.label_last.Text = last;
            });
            主界面.GetSingleton().BeginInvoke(mi);

        }

        public void PlayControlLabelCurSeting(string cur)
        {
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                this.label_cur.Text = cur;
            });
            主界面.GetSingleton().BeginInvoke(mi);

        }

        public void PlayControlLabelNextSeting(string next)
        {
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                this.label_next.Text = next;
            });
            主界面.GetSingleton().BeginInvoke(mi);

        }
        /// <summary>
        /// 播放列表播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void button_playOn_Click(object sender, EventArgs e)
        {
            // 先全选后播放
            if (this.cbAllSelect.Checked)
            {
                this.cbAllSelect.Checked = false;
            }

            this.cbAllSelect.Checked = true;

            playListName = this.comboBox_playList.SelectedItem.ToString();
            curPlayAppName = "";

            List<T_PLAYLIST_INFO> playListInfo = DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>()
                .Where(it => it.PlayListName == playListName).ToList();

            playListInfo.Sort((x, y) => x.No.CompareTo(y.No));

            controlTask = Task.Run(() => ControlPlayList(playListInfo));

            // await controlTask;
            this.playButtonEnable(false);
            this.playButtonEnable(true, OpenRasterDelayTime);

        }

        private async void playButtonEnable(bool state, int waitTimeMS = 0)
        {
            if (waitTimeMS > 0)
            {
                await Task.Run(() => Thread.Sleep(waitTimeMS));

            }

            Action action = delegate ()
            {
                this.button_next.Enabled = state;
                this.button_last.Enabled = state;
                this.button_playOn.Enabled = state;
                this.button_playOff.Enabled = state;
            };
            this.Invoke(action);
        }

        /// <summary>
        /// 获取播放控制相关所有按钮的enable状态
        /// </summary>
        /// <returns></returns>
        public bool GetPalyGroupButtonEnableState()
        {
            if (!this.button_next.Enabled || !this.button_last.Enabled || !this.button_playOn.Enabled ||
                !this.button_playOff.Enabled)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        /// <summary>
        /// 播放列表停止播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void button_playOff_Click(object sender, EventArgs e)
        {
            if (GetComboxCurPlayingListNameText() == "" || GetLableCurPlayText() == "" || this.button_playOff.Enabled == false)
                return;

            playButtonEnable(false);

            playListName = "";
            curPlayAppName = "";

            _playListControlSource.Cancel();

            // 不加就死锁
            await controlTask;

            _playListControlSource = new CancellationTokenSource();

            PlayControlLabelLastSeting("");
            PlayControlLabelCurSeting("");
            PlayControlLabelNextSeting("");

            // 停止播放的对button的控制，都在ControlPlayList 中进行
            // Thread.Sleep(playVideoIntervalMS);
            // playButtonEnable(true);
            //Task.Run(()=> playButtonEnable(true, playVideoIntervalMS));

            
        }

        /// <summary>
        /// 开启控制播放的进程，实现按照播放列表顺序和播放时间顺序播放
        /// </summary>
        /// <param name="playListInfo"></param>
        private void ControlPlayList(List<T_PLAYLIST_INFO> playListInfo)
        {
            foreach (T_PLAYLIST_INFO playInfo in playListInfo)
            {
                curPlayAppName = playInfo.VideoName;
                // 播放列表控制
                float curRuntimeMilSeconds = 0.0f;

                if (this.comboBox_process.FindString(playInfo.VideoName) != -1)
                {
                    ComboBoxProgressSelectChange(playInfo.VideoName);
                    // this.comboBox_process.SelectedIndex = this.comboBox_process.FindString(playInfo.VideoName);
                }
                else
                {
                    continue;
                }

                button_process_on_Click(null, null);

                List<T_PLAYLIST_INFO> playListTemp = DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>()
                    .Where(it => it.PlayListName == playListName).ToList();

                playListTemp.Sort((x, y) => x.No.CompareTo(y.No));

                int index = playListTemp.FindIndex(item => item.VideoName == curPlayAppName);

                PlayControlLabelLastSeting("");
                PlayControlLabelCurSeting(curPlayAppName);
                PlayControlLabelNextSeting("");

                if (index > 0)
                {
                    // this.label_last.Text = playListInfo[index - 1].VideoName;
                    PlayControlLabelLastSeting(playListTemp[index - 1].VideoName);
                }

                if (index < playListTemp.Count - 1)
                {
                    // this.label_next.Text = playListInfo[index + 1].VideoName;
                    PlayControlLabelNextSeting(playListTemp[index + 1].VideoName);
                }

                while (!_playListControlSource.IsCancellationRequested && curRuntimeMilSeconds < (playInfo.Time < 0.000001 ? float.MaxValue : playInfo.Time * 1000))
                {
                    Thread.Sleep(100);
                    curRuntimeMilSeconds += 100;
                }

                MethodInvoker mi = new MethodInvoker(() =>
                {
                    button_process_off_Click(null, null);
                });
                主界面.GetSingleton().BeginInvoke(mi);

                playButtonEnable(false);

                if (curRuntimeMilSeconds >= (playInfo.Time < 0.000001 ? float.MaxValue : playInfo.Time * 1000) && playListInfo.FindIndex(item => item.VideoName == curPlayAppName) == playListInfo.Count - 1)
                {
                    playListName = "";
                }
                else
                {
                    // PlayVideoInterval
                }

                Thread.Sleep(playVideoIntervalMS);

                playButtonEnable(true);

                if (_playListControlSource.IsCancellationRequested)
                {
                    break;
                }
            }

            PlayControlLabelLastSeting("");
            PlayControlLabelCurSeting("");
            PlayControlLabelNextSeting("");

        }

        private void StopPlayTask()
        {

        }

        /// <summary>
        /// 上一部按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void button_last_Click(object sender, EventArgs e)
        {
            if (playListName == "")
                return;

            List<T_PLAYLIST_INFO> playListInfo = DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>()
                .Where(it => it.PlayListName == playListName).ToList();

            playListInfo.Sort((x, y) => x.No.CompareTo(y.No));

            int index = playListInfo.FindIndex(item => item.VideoName == curPlayAppName);

            if (index > 0)
            {
                this.button_next.Enabled = false;
                this.button_last.Enabled = false;
                this.button_playOn.Enabled = false;
                this.button_playOff.Enabled = false;

                _playListControlSource.Cancel();

                // 不加就死锁
                await controlTask;

                _playListControlSource = new CancellationTokenSource();

                controlTask = Task.Run(() => ControlPlayList(playListInfo.Skip(index - 1).ToList()));

                this.button_next.Enabled = true;
                this.button_last.Enabled = true;
                this.button_playOn.Enabled = true;
                this.button_playOff.Enabled = true;
            }
        }

        /// <summary>
        /// 下一部按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void button_next_Click(object sender, EventArgs e)
        {
            if (playListName == "")
                return;

            List<T_PLAYLIST_INFO> playListInfo = DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>()
                .Where(it => it.PlayListName == playListName).ToList();

            playListInfo.Sort((x, y) => x.No.CompareTo(y.No));

            int index = playListInfo.FindIndex(item => item.VideoName == curPlayAppName);

            if (index < playListInfo.Count - 1)
            {
                this.button_next.Enabled = false;
                this.button_last.Enabled = false;
                this.button_playOn.Enabled = false;
                this.button_playOff.Enabled = false;

                _playListControlSource.Cancel();

                // 不加就死锁
                await controlTask;

                _playListControlSource = new CancellationTokenSource();

                controlTask = Task.Run(()=> ControlPlayList(playListInfo.Skip(index + 1).ToList()));

                this.button_next.Enabled = true;
                this.button_last.Enabled = true;
                this.button_playOn.Enabled = true;
                this.button_playOff.Enabled = true;
            }
        }

        /// <summary>
        /// 设置播放类别combox的选中项
        /// </summary>
        /// <param name="playName"></param>
        public void SetComboxPlayList(string playName)
        {
            if (this.comboBox_playList.FindString(playName) == -1)
            {
                // MessageBox.Show("请检查是否正确配置整体开机方案");
                NlogHandler.GetSingleton().Error("播放类别的下拉列表框中不包含当前要选择的名称" + playName);
                return;
            }
            else
            {
                this.comboBox_playList.SelectedIndex = this.comboBox_playList.FindString(playName);
            }
        }

        /// <summary>
        /// 从数据库中获取播放列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetPlayListName()
        {
            return DBConnect.GetSingleton().db.Queryable<T_PLAYLIST_INFO>()
                .Select(it => it.PlayListName).Distinct().ToList();
        }

        /// <summary>
        /// 正在播放的播放列表，如果没有播放就不传
        /// </summary>
        /// <returns></returns>
        public string GetComboxCurPlayingListNameText()
        {
            if (GetLableCurPlayText() != "")
            {
                return this.comboBox_playList.Text;
            }
            else
            {
                return "";
            }
        }

        public string GetLableCurPlayText()
        {
            return this.label_cur.Text;
        }

        public string GetLableProPlayText()
        {
            return this.label_last.Text;
        }
        public string GetLableNextPlayText()
        {
            return this.label_next.Text;
        }

        public int GetplayVideoIntervalMS()
        {
            return playVideoIntervalMS;
        }

        private void 播放管理toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new 播放列表();
            form.ShowDialog();
        }

        public async void button_allPowerOn_Click(object sender, EventArgs e)
        {
            if (this.comboBox_device.FindString("整体开机") == -1)
            {
                MessageBox.Show("请检查是否正确配置整体开机方案");
                return;
            }
            else
            {
                button_allPowerOn.Enabled = false;
                button_allPowerOff.Enabled = false;

                this.comboBox_device.SelectedIndex = this.comboBox_device.FindString("整体开机");

                // 与整体其他部分思路不一致，并没有调用button_device_on_Click
                string planName = comboBox_device.Text.Trim();

                controlPowerRemainSeconds = GetPlanExecTime(planName);
                timer_power.Enabled = true;

                await Task.Run(() => 其他设备控制.GetSingleton().ExecPlan(planName));

                // timer_power 自动enable=false
                controlPowerRemainSeconds = 0;

                button_allPowerOn.Enabled = true;
                button_allPowerOff.Enabled = true;

                allAccomPower = true;
            }
        }

        public async void button_allPowerOff_Click(object sender, EventArgs e)
        {
            if (this.comboBox_device.FindString("整体关机") == -1)
            {
                MessageBox.Show("请检查是否正确配置整体开机方案");
                return;
            }
            else
            {
                button_allPowerOn.Enabled = false;
                button_allPowerOff.Enabled = false;

                this.comboBox_device.SelectedIndex = this.comboBox_device.FindString("整体关机");

                // 与整体其他部分思路不一致，并没有调用button_device_on_Click
                string planName = comboBox_device.Text.Trim();

                controlPowerRemainSeconds = GetPlanExecTime(planName);
                timer_power.Enabled = true;

                await Task.Run(() => 其他设备控制.GetSingleton().ExecPlan(planName));

                // timer_power 自动enable=false
                controlPowerRemainSeconds = 0;

                button_allPowerOn.Enabled = true;
                button_allPowerOff.Enabled = true;

                allAccomPower = false;
            }
        }

        public float GetPlanExecTime(string planName)
        {
            return 其他设备控制.GetSingleton().GetPlanExecTime(planName) + 100;
        }

        private void fullShow(bool state)
        {
            groupBox1.Visible = state;
            groupBox_groupInfo.Visible = state;
            groupBox3.Visible = state;
            groupBox2.Visible = state;
            groupBox4.Visible = state;

            数据库管理ToolStripMenuItem.Visible = state;
            分组信息StripMenuItem.Visible = state;
            系统日志管理ToolStripMenuItem.Visible = state;
            系统管理ToolStripMenuItem.Visible = state;
            传输文件ToolStripMenuItem.Visible = state;
            远程控制StripMenuItem.Visible = state;
            进程管理ToolStripMenuItem.Visible = state;
            其他设备控制ToolStripMenuItem.Visible = state;

            this.process_state.Visible = state;
            this.stereo_state.Visible = state;
            this.leftRight_state.Visible = state;

            if (state == false)
            {
                this.Width = 1058;
            }
            else
            {
                this.Width = 1250;
            }
        }


        private void fuxinHuanmuLabShow(bool state)
        {
            if (state == false)
            {
                button_stereo.Visible = true;
                groupBox4.Location = new Point(12, 829);
            }
            else
            {
                fullShow(false);
                groupBox4.Location = new Point(12, 317);
                groupBox4.Visible = true;
                button_stereo.Visible = false;
                this.leftRight_state.Visible = true;
            }
        }

        /// <summary>
        /// 办公室演示区的精简界面
        /// </summary>
        /// <param name="state"></param>
        private void OfficeDemonstrationAreaShow(bool state)
        {
            if (state == false)
            {
                groupBox2.Location = new Point(12, 701);
                groupBox5.Visible = true;

                this.Height = 1019;
                menuStrip.Visible = true;
            }
            else
            {
                fullShow(false);
                groupBox2.Location = new Point(12, 42);
                groupBox2.Visible = true;
                groupBox5.Visible = false;
                panel1.Visible = false;

                this.Height = 260;
                menuStrip.Visible = false;

            }
        }

        private void timer_power_Tick(object sender, EventArgs e)
        {
            if (controlPowerRemainSeconds > 0)
            {
                controlPowerRemainSeconds -= 1;

                toolStripStatusLabel1.Text = "欢迎使用多维集控系统" + " 剩余时间: " + controlPowerRemainSeconds.ToString();
            }

            if (controlPowerRemainSeconds <= 0)
            {
                controlPowerRemainSeconds = 0;
                timer_power.Enabled = false;
                toolStripStatusLabel1.Text = "欢迎使用多维集控系统" ;
            }
        }
    }
}
