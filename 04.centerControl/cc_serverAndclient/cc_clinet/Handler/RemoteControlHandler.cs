using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using UserEventData;
using Utilities;

namespace cc_clinet
{
    /// <summary>
    /// 远程控制
    /// </summary>
    public class RemoteControlHandler : IEventHandler<R_C_RemoteControlData>
    {

        public void HandleEvent(R_C_RemoteControlData eventData)
        {
            
            string processName = "jsmpeg-vnc";
            //string path = System.IO.Directory.GetCurrentDirectory();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\vnc";
            string fullPath = path + @"\jsmpeg-vnc.exe";

            int height = Screen.PrimaryScreen.Bounds.Height;
            int wdith = Screen.PrimaryScreen.Bounds.Width;
            NlogHandler.GetSingleton().Info(string.Format("远程控制Handler {0}, fullpath: {1}, height:{2}, wdith:{3}", processName, fullPath, height, wdith));

            if (File.Exists(fullPath) == null)
                NlogHandler.GetSingleton().Info(string.Format("fullPath is null"));
            else if (File.Exists(fullPath) == false)
            {
                NlogHandler.GetSingleton().Info(string.Format("fullPath is false"));
            }
            else if (File.Exists(fullPath))
            {
                NlogHandler.GetSingleton().Info(string.Format("fullPath is false"));
            }

            if (eventData.isOpen)
            {
                if (File.Exists(fullPath))
                {

                    NlogHandler.GetSingleton().Info(string.Format("开启远程控制 {0}", processName));

                    Process[] processes = Process.GetProcessesByName(processName);

                    if (processes.ToList().Count > 0)
                    {
                        NlogHandler.GetSingleton().Info(string.Format("开启远程控制 {0}, 但是远程的exe已经打开，此次不打开", processName));
                    }
                    else
                    {
                        Directory.SetCurrentDirectory(path);
                        Process process = new System.Diagnostics.Process();
                        process.StartInfo.FileName = fullPath;
                        process.StartInfo.Arguments = eventData.args;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardInput = false;
                        process.StartInfo.RedirectStandardOutput = false;
                        process.StartInfo.RedirectStandardError = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.Start();
                    }

                    // 触发获取本地进程信息event
                    var sendData = new C_RemoteControlData(true, "", height, wdith );
                    RabbitMQEventBus.GetSingleton().Trigger<C_RemoteControlData>(eventData.fromIp, sendData);//直接通过事件总线触发

                }
            }
            else
            {

                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process p in processes)
                {
                    NlogHandler.GetSingleton().Info(string.Format("关闭远程控制 {0}", processName));

                    p.Kill();
                    p.Close();
                }

                C_RemoteControlData sendData = new C_RemoteControlData(false, "", height, wdith);

                // 触发获取本地进程信息event
                RabbitMQEventBus.GetSingleton().Trigger<C_RemoteControlData>(eventData.fromIp, sendData);//直接通过事件总线触发
            }
        }
    }
}
