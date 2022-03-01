using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using DW_CC_NET.RabbitMQ;
using NPOI.OpenXmlFormats.Spreadsheet;
using UserEventData;

namespace MCS
{
    public partial class 远程控制 : Form
    {
        //private static readonly object syslock = new object();

        //private static 远程控制 _instance;
        
        //public static 远程控制 GetSingleton()
        //{
        //    if (_instance == null)
        //    {
        //        lock (syslock)
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new 远程控制();
        //            }
        //        }
        //    }

        //    return _instance;
        //}

        private ChromiumWebBrowser webview;

        private int mWidth;
        private int mHeigh;

        public 远程控制()
        {
            //// cef只能被初始化一次
            //AppDomain.CurrentDomain.AssemblyResolve += Resolver;

            //LoadApp();

            InitializeComponent();

            if (RemoteControl.GetSingleton().mIpFormDict.Count > 0)
                this.WindowState = FormWindowState.Minimized;
        }

        ~远程控制()
        {
            // Cef.Shutdown();
        }

        //[MethodImpl(MethodImplOptions.NoInlining)]
        //private static void LoadApp()
        //{
        //    var settings = new CefSettings();

        //    // Set BrowserSubProcessPath based on app bitness at runtime
        //    settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
        //        Environment.Is64BitProcess ? "x64" : "x86",
        //        "CefSharp.BrowserSubprocess.exe");

        //    // Make sure you set performDependencyCheck false
        //    Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

        //}

        //// Will attempt to load missing assembly from either x86 or x64 subdir
        //private static Assembly Resolver(object sender, ResolveEventArgs args)
        //{
        //    if (args.Name.StartsWith("CefSharp"))
        //    {
        //        string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
        //        string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
        //            Environment.Is64BitProcess ? "x64" : "x86",
        //            assemblyName);

        //        return File.Exists(archSpecificPath)
        //            ? Assembly.LoadFile(archSpecificPath)
        //            : null;
        //    }

        //    return null;
        //}

        private void 远程控制_Load(object sender, EventArgs e)
        {

            InitializeComponent();

            this.Width = mWidth;
            this.Height = mHeigh;
        }

        public void ShowControlWindow(string ip, int width, int heigh)
        {
            if (webview == null)
            {
                webview = new ChromiumWebBrowser();
                // 取消右键菜单
                webview.MenuHandler = new MenuHandler();
            }

            webview.Dock = DockStyle.Fill;

            string url = string.Format("http://{0}:8080", ip);

            webview.Load(url);
            //webview.Load("http://192.168.0.57:8080");

            this.Controls.Add(webview);

            int deskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int deskHeight = Screen.PrimaryScreen.WorkingArea.Height;

            int windowTitleHeight = this.Height - this.ClientRectangle.Height;
            int workAreaHeight = deskHeight - windowTitleHeight;

            float ratio = (float)(width) / (float)(heigh);

            mWidth = (int)((float)(workAreaHeight) * ratio);
            mHeigh = deskHeight;
        }


        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (webview == null)
                return;

            if (webview.Address != "")
            {
                int start = webview.Address.IndexOf("/") + 1;
                int end = webview.Address.LastIndexOf(":");

                string ip = webview.Address.Substring(start + 1, end - start - 1);

                R_C_RemoteControlData sendData = new R_C_RemoteControlData(false, "desktop");

                RabbitMQEventBus.GetSingleton()
                    .Trigger<R_C_RemoteControlData
                    >(ip, sendData); //直接通过事件总线触发
            }



            webview.Dispose();
            webview = null;
            
            this.Controls.Clear();
        }

    }

    internal class MenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
        }
        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return false;
        }
        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
        }
        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }



    public class RemoteControl
    {

        private static readonly object syslock = new object();

        private static RemoteControl _instance;

        public static RemoteControl GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new RemoteControl();
                    }
                }
            }

            return _instance;
        }

        public Dictionary<string, Form> mIpFormDict;

        private RemoteControl()
        {
            // cef只能被初始化一次
            AppDomain.CurrentDomain.AssemblyResolve += Resolver;

            LoadApp();

            mIpFormDict = new Dictionary<string, Form>();


        }

        ~RemoteControl()
        {
            Cef.Shutdown();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void LoadApp()
        {
            var settings = new CefSettings();

            // Set BrowserSubProcessPath based on app bitness at runtime
            settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                Environment.Is64BitProcess ? "x64" : "x86",
                "CefSharp.BrowserSubprocess.exe");

            // Make sure you set performDependencyCheck false
            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

        }

        // Will attempt to load missing assembly from either x86 or x64 subdir
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                    Environment.Is64BitProcess ? "x64" : "x86",
                    assemblyName);

                return File.Exists(archSpecificPath)
                    ? Assembly.LoadFile(archSpecificPath)
                    : null;
            }

            return null;
        }

        public void ShowControlWindow(string ip, int width, int heigh)
        {

            远程控制 form = new 远程控制();
            mIpFormDict.Add(ip, form);
            form.ShowControlWindow(ip, width, heigh);
            form.Show();
            form.Text = string.Format("远程桌面   目标IP:{0}", ip);

        }

        public void RemoteWindosClosed(string ip)
        {
            if (mIpFormDict.ContainsKey(ip))
                mIpFormDict.Remove(ip);
        }
    }
}
