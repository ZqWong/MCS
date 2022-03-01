using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace MCS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1.这里判定是否已经有实例在运行
            // 只运行一个实例
            Process instance = RunningInstance();
            if (instance == null)
            {
                // 1.1 没有实例在运行


                //Application.Run(new 设备输入数据());

                //处理未捕获的异常
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.Run(主界面.GetSingleton());
                // Application.Run(new 播放列表());

                System.Environment.Exit(0);
            }
            else
            {
                // 1.2 已经有一个实例在运行
                HandleRunningInstance(instance);
            }
        }

        /// <summary>
        /// 是否退出应用程序
        /// </summary>
        static bool glExitApp = false;

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            NlogHandler.GetSingleton().Error("CurrentDomain_UnhandledException");
            NlogHandler.GetSingleton().Error("IsTerminating : " + e.IsTerminating.ToString());
            NlogHandler.GetSingleton().Error(e.ExceptionObject.ToString());

            //LogHelper.Save("CurrentDomain_UnhandledException", LogType.Error);
            //LogHelper.Save("IsTerminating : " + e.IsTerminating.ToString(), LogType.Error);
            //LogHelper.Save(e.ExceptionObject.ToString());

            while (true)
            {//循环处理，否则应用程序将会退出
                if (glExitApp)
                {//标志应用程序可以退出，否则程序退出后，进程仍然在运行
                    // LogHelper.Save("ExitApp");
                    NlogHandler.GetSingleton().Error("ExitApp");
                    return;
                }
                System.Threading.Thread.Sleep(2 * 1000);
            };
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            NlogHandler.GetSingleton().Error("Application_ThreadException:" + e.Exception.Message);
            
            // LogHelper.Save(LogType.Error);
            //LogHelper.Save(e.Exception);
            //throw new NotImplementedException();
        }

        // 2.在进程中查找是否已经有实例在运行
        #region 确保程序只运行一个实例
        private static Process RunningInstance()
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

        // 3.已经有了就把它激活，并将其窗口放置最前端
        private static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, 1); //调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端
        }

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
        #endregion
    }
}
