using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using Utilities;
using NvAPIWrapper;
using NvAPIWrapper.GPU;

/// <summary>
/// 1.程序运行需要获取管理员权限，方法是通过bat中转启动
/// 2.程序在布置时需要完成两项前置工作，第一是更改用户账户控制设置的滑块到最低，第二是将启动的bat文件放到自动启动文件夹下
/// 3.
/// </summary>
namespace cc_clinet
{

    class Program
    {

        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();

            //MessageBox.Show(current.ProcessName);

            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            // 遍历与当前进程名称相同的进程列表 
            foreach (Process process in processes)
            {
                // 如果实例已经存在则忽略当前进程 
                if (process.Id != current.Id)
                {
                    string path = Assembly.GetExecutingAssembly().Location.Replace("/", "\\");
                    // 保证要打开的进程同已经存在的进程来自同一文件路径
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        // 返回已经存在的进程
                        return process;
                    }
                }
            }
            return null;
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            NlogHandler.GetSingleton().Error(e.ExceptionObject.ToString());
            // Environment.Exit(1);
        }


        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            NlogHandler.GetSingleton().Debug("ccclient应用程序启动");

            if (RunningInstance() != null)
            {
                NlogHandler.GetSingleton().Error("已经有客户端运行，关闭此次运行客户端");
                return;
            }

            // 隐藏窗口
            HideWindows();

            try
            {
                // 通过修改注册表的方式，设置开机自动启动
                AutoRunWithAdmin.SetMeStart(true);
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error(string.Format("自启动报错 : {0}", e.Message.ToString()));
                throw;
            }

            while (GetLocalIp.GetSingleton().GetIP() == "127.0.0.1")
            {
                Thread.Sleep(1000);

                NlogHandler.GetSingleton().Error(string.Format("本机ip地址 : {0}", GetLocalIp.GetSingleton().GetIP()));
            }

            NlogHandler.GetSingleton().Error(string.Format("本机ip地址 : {0}", GetLocalIp.GetSingleton().GetIP()));

            RabbitMQEventBus.GetSingleton().Init(
                ConfigHelper.GetSingleton().GetAppConfig("BrokerName"),
                GetLocalIp.GetSingleton().GetIP(),
                Process.GetCurrentProcess().ProcessName,
                ConfigHelper.GetSingleton().GetAppConfig("ExchangeType"),
                ConfigHelper.GetSingleton().GetAppConfig("User_Name"),
                ConfigHelper.GetSingleton().GetAppConfig("HostName"),
                ConfigHelper.GetSingleton().GetAppConfig("Password"),
            ConfigHelper.GetSingleton().GetAppConfig("SSL"),
            ConfigHelper.GetSingleton().GetAppConfig("Sync"));
            //注册当前程序集中实现的所有IEventHandler<T>
            //EventBus.Default.RegisterAllEventHandlerFromAssembly(Assembly.GetExecutingAssembly());
            RabbitMQEventBus.GetSingleton().RegisterAllEventHandlerFromAssembly(Assembly.GetExecutingAssembly());

            NlogHandler.GetSingleton().Info(string.Format("集控客户端开启"));

            // 初始化获取显卡信息
            try
            {
                NVIDIA.Initialize();
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error(string.Format("获取显卡信息dll初始化异常 ：{0} ", e.Message.ToString()));
            }

            // 日志清理
            try
            {
                LogCleanUp();
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error(string.Format("日志清理异常 ：{0} ", e.Message.ToString()));
            }
            

            Console.WriteLine("***********************");
            Console.ReadLine();

            // 手动close，来删除autodelete属性为false的queue
            RabbitMQEventBus.GetSingleton().Dispose();

            
        }

        public static void LogCleanUp()
        {
            //string fileName = NlogHandler.GetSingleton().GetFileName();
            //int index_temp = fileName.LastIndexOf("\\");
            //string fileDir = fileName.Substring(0, index_temp + 1);
            string fileDir = NlogHandler.GetSingleton().GetFolderName();

            long length = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(fileDir);
            ComFunc.GetSingleton().GetFilesLenInFolderRescusively(directoryInfo.GetDirectories(), directoryInfo.GetFiles(), ref length);

            // 大于100M就清理
            if (length / Math.Pow(1024, 2) < 100)
            {
                return;
            }

            // 清空文件夹
            foreach (string d in Directory.GetFileSystemEntries(fileDir))
            {
                if (System.IO.File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    System.IO.File.Delete(d);//直接删除其中的文件    
                }

                if (System.IO.Directory.Exists(d))
                {
                    Directory.Delete(d, true);
                }

            }
        }


        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public static void HideWindows()
        {
            Console.Title = "SysGreenBackService";
            IntPtr intptr = FindWindow("ConsoleWindowClass", "SysGreenBackService");
            while (intptr == IntPtr.Zero)
            {
                intptr = FindWindow("ConsoleWindowClass", "SysGreenBackService");
            }
            ShowWindow(intptr, 0);//隐藏这个窗口
        }
    }


}
