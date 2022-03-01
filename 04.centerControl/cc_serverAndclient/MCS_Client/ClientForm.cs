using Common;
using Common.Model;
using Common.XML;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace MCS_Client
{
    public partial class ClientForm : Form
    {
        public static ClientForm Form;

        // add by wuxin at 2019/12/10 - start
        public static string _UnityClientConfigFilePath = "";
        public static string _UnityClientName = "";
        public static string _UnityClientPath = "";
        // add by wuxin at 2019/12/10 - end

        #region 线程

        private Thread _WatchingApplicationOpenStateThread = null; // 监视应用程序打开状态线程

        private bool _StopWatchingApplicationOpenState = false;

        private Thread _WatchingUnityClientConfigChangeThread = null; // 监视VR考试软件配置文件更改线程

        public bool _StopWatchingUnityClientConfigChange = true;

        private Thread _HeartCheckThread = null; // 心跳检测线程

        public bool _Stop_HeartCheckThreade = true;

        #endregion

        public ClientForm()
        {
            Form = this;

            InitializeComponent();

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;// 设置该属性为false

            // 任务栏区显示图标
            this.ShowInTaskbar = false;

            // 连接服务器
            NetIO.Instance.Connect2Server();

            // 显示当前IP
            this.MyContextMenuStrip.Items[0].Text = "Local IP: " + LibUtilities.GetLocalIP();

            #region 将服务器客户端exe自动设置为自启动

            string path = System.Windows.Forms.Application.ExecutablePath;

            bool result = LibUtilities.IsAppAutoRun(path);

            if (!result)
            {
                LibUtilities.SetAutoRun(path, true);
            }

            #endregion

            #region 线程

            _WatchingApplicationOpenStateThread = new Thread(new ThreadStart(WatchingApplicationOpenState));
            _WatchingApplicationOpenStateThread.IsBackground = true;
            _WatchingApplicationOpenStateThread.Name = "_WatchingApplicationOpenStateThread";
            _WatchingApplicationOpenStateThread.Start();

            _WatchingUnityClientConfigChangeThread = new Thread(new ThreadStart(WatchingUnityClientConfigChange));
            _WatchingUnityClientConfigChangeThread.IsBackground = true;
            _WatchingUnityClientConfigChangeThread.Name = "_WatchingUnityClientConfigChangeThread";
            _WatchingUnityClientConfigChangeThread.Start();


            _HeartCheckThread = new Thread(new ThreadStart(HeartCheckThread));
            _HeartCheckThread.IsBackground = true;
            _HeartCheckThread.Name = "_HeartCheckThread";
            _HeartCheckThread.Start();

            #endregion
        }

        /// <summary>
        /// 监视应用程序打开状态
        /// </summary>
        public void WatchingApplicationOpenState()
        {
            while (true)
            {
                // upd by wuxin at 2019/12/10 - start
                if (_UnityClientName != "")
                {
                    int count = LibUtilities.GetPidByProcessName(_UnityClientName);

                    if (count == 0)
                    {
                        NetIO.Instance.SendMessage2Server((byte)Protocol.Type.SYSTEM, 0, (byte)Protocol.Command.ApplicationOpenState, false);
                    }
                    else
                    {
                        NetIO.Instance.SendMessage2Server((byte)Protocol.Type.SYSTEM, 0, (byte)Protocol.Command.ApplicationOpenState, true);
                    }

                    // 时间间隔1S
                    Thread.Sleep(1000);
                }
                // upd by wuxin at 2019/12/10 - end
            }
        }

        // 上一次考试状态
        private string _LastExamState = "";

        /// <summary>
        /// 监视VR考试软件配置文件更改
        /// </summary>
        public void WatchingUnityClientConfigChange()
        {
            while (true)
            {
                if (_UnityClientConfigFilePath != "")
                {
                    string strExamState = XmlManager.GetInnerTextByElementNameFromXml(_UnityClientConfigFilePath, XmlModel.ElementName_ExamState);

                    if (strExamState != _LastExamState)
                    {
                        // 已开始
                        if (strExamState == EnumExamState.Start.ToString())
                        {
                            NetIO.Instance.SendMessage2Server((byte)Protocol.Type.EXAM, 0, (byte)Protocol.Command.ExamStart, 0);
                        }
                        // 已结束
                        else if (strExamState == EnumExamState.Over.ToString())
                        {
                            NetIO.Instance.SendMessage2Server((byte)Protocol.Type.EXAM, 0, (byte)Protocol.Command.ExamOver, 0);
                        }

                        _LastExamState = strExamState;
                    }

                    // 时间间隔1S
                    Thread.Sleep(1000);
                }
            }
        }

        /// <summary>
        /// 添加双击托盘图标事件（双击显示窗口）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // 还原窗体显示    
                WindowState = FormWindowState.Normal;

                // 激活窗体并给予它焦点
                this.Activate();

                // 任务栏区显示图标
                this.ShowInTaskbar = true;
                // 托盘区图标隐藏
                this.MyNotifyIcon.Visible = false;
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // 还原窗体显示    
                WindowState = FormWindowState.Normal;

                // 激活窗体并给予它焦点
                this.Activate();

                // 任务栏区显示图标
                this.ShowInTaskbar = true;
                // 托盘区图标隐藏
                this.MyNotifyIcon.Visible = false;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("关闭程序会导致与服务器断开连接，是否确定关闭？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
        }

        private void ClientForm_SizeChanged(object sender, EventArgs e)
        {
            // 判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                // 隐藏任务栏区图标
                this.ShowInTaskbar = false;
                // 图标显示在托盘区
                this.MyNotifyIcon.Visible = true;
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("关闭程序会导致与服务器断开连接，是否确定关闭？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();

                // 关闭监视应用程序打开状态线程
                if (_WatchingApplicationOpenStateThread != null)
                {
                    _WatchingApplicationOpenStateThread.Abort();

                    _StopWatchingApplicationOpenState = true;
                }

                // 关闭监视应用程序打开状态线程
                if (_WatchingUnityClientConfigChangeThread != null)
                {
                    _WatchingUnityClientConfigChangeThread.Abort();

                    _StopWatchingUnityClientConfigChange = true;
                }

                // 关闭心跳检测线程
                if (_HeartCheckThread != null)
                {
                    _HeartCheckThread.Abort();

                    _Stop_HeartCheckThreade = true;
                }

            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 心跳检测线程
        /// </summary>
        private void HeartCheckThread()
        {
            while (true)
            {
                bool result = NetIO.Instance.SendMessage2Server((byte)Protocol.Type.HEART_CHECK, 0, 0, 0);

                if (!result)
                {
                    ShowMessage("尝试重新连接服务器...");
                    NetIO.Instance.Connect2Server();
                }
                else
                {
                    //ShowMessage(DateTime.Now + "：" + "向服务器发送心跳检测。");
                }

                // 发送间隔3S
                Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="messgae"></param>
        public void ShowMessage(string messgae)
        {
            this.txtMessage.AppendText(DateTime.Now + " " + messgae + "\n");
        }

        /// <summary>
        /// 显示消息（供外部调用）
        /// </summary>
        /// <param name="messgae"></param>
        public void ShowMessage(string[] messgae)
        {
            for (int i = 0; i < messgae.Length; i++)
            {
                this.txtMessage.AppendText(DateTime.Now + " " + "收到来自服务器的消息：" + messgae[i] + "\n");
            }
        }

        /// <summary>
        /// 测试考试开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //NetIO.Instance.SendMessage2Server((byte)Protocol.Type.EXAM, 0, (byte)Protocol.Command.ExamStart, 0);

            List<XmlModel> xmlList = new List<XmlModel>();

            XmlModel xmlModel4 = new XmlModel();
            xmlModel4.ElementName = XmlModel.ElementName_ExamState;
            xmlModel4.InnerText = EnumExamState.Start.ToString();

            xmlList.Add(xmlModel4);

            XmlManager.IsUpdating = true;
            //XmlManager.UpdateXml(Const.UnityClientConfigFilePath, xmlList);
            XmlManager.IsUpdating = false;
        }

        /// <summary>
        /// 测试考试结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //NetIO.Instance.SendMessage2Server((byte)Protocol.Type.EXAM, 0, (byte)Protocol.Command.ExamOver, 0);

            List<XmlModel> xmlList = new List<XmlModel>();

            XmlModel xmlModel4 = new XmlModel();
            xmlModel4.ElementName = XmlModel.ElementName_ExamState;
            xmlModel4.InnerText = EnumExamState.Over.ToString();

            xmlList.Add(xmlModel4);

            XmlManager.IsUpdating = true;
            //XmlManager.UpdateXml(Const.UnityClientConfigFilePath, xmlList);
            XmlManager.IsUpdating = false;
        }

        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.txtMessage.Text = "";
        }

        //private void HeartCheck_Tick(object sender, EventArgs e)
        //{
        //    bool result = NetIO.Instance.SendMessage2Server((byte)Protocol.Type.HEART_CHECK, 0, 0, 0);

        //    if (!result)
        //    {
        //        NetIO.Instance.Connect2Server();
        //    }
        //}
    }
}
