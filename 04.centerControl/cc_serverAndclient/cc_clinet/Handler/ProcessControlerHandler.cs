using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using UserEventData;
using Utilities;

namespace cc_clinet
{
    /// <summary>
    /// 进程控制事件处理
    /// </summary>
    public class ProcessControlerHandler : IEventHandler<R_C_ControlProcessData>
    {

        public async void HandleEvent(R_C_ControlProcessData eventData)
        {
            // todo 是否会出现启动应用之后紧接着一个获取进程信息的事件，由于多线程处理handler，造成进程未启动完成，而回复给服务器的消息时进程关闭。

            string[] str = eventData.processFilePathName.Split('\\');
            string processName = str[str.Length - 1].Replace(".exe", "");

            if (eventData.trunOn)
            {
                if (File.Exists(eventData.processFilePathName))
                {
                    // 判断是否运行该名称进程
                    if (Process.GetProcessesByName(processName).Length > 0)
                    {
                        NlogHandler.GetSingleton().Info(string.Format("进程 {0} 已经运行 打开操作未能执行。", processName));

                        return;
                    }

                    NlogHandler.GetSingleton().Info(string.Format("打开进程 {0}, 参数 {1}", processName, eventData.arguments));

                    string strPathExe = eventData.processFilePathName;

                    string path = strPathExe.Substring(0, strPathExe.LastIndexOf('\\'));

                    string curDict = System.Environment.CurrentDirectory;

                    Directory.SetCurrentDirectory(path);
                    Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = strPathExe;
                    process.StartInfo.Arguments = eventData.arguments;//-s -t 可以用来关机、开机或重启
                    process.StartInfo.UseShellExecute = eventData.useShellExecute;
                    process.StartInfo.RedirectStandardInput = eventData.redirectStandardInput;  //true
                    process.StartInfo.RedirectStandardOutput = eventData.redirectStandardOutput;  //true
                    process.StartInfo.RedirectStandardError = eventData.redirectStandardError;
                    process.StartInfo.CreateNoWindow = eventData.createNoWindow;
                    if (eventData.createNoWindow)
                    {
                        process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;     //把窗口隐藏，使其在后台运行
                    }

                    process.Start();

                    Directory.SetCurrentDirectory(curDict);
                }

            }
            else
            {

                Process[] processes = Process.GetProcessesByName(processName);
                foreach (Process p in processes)
                {
                    string FilePathName = ComFunc.GetSingleton().GetMainModuleFilepath(p.Id);

                    if (eventData.processFilePathName.StartsWith(@".\"))
                    {
                        string currentPath = Directory.GetCurrentDirectory();

                        if (FilePathName.Contains(currentPath))
                        {
                            FilePathName = "." + FilePathName.Substring(currentPath.Length,
                                               FilePathName.Length - currentPath.Length);
                        }
                    }

                    if (eventData.processFilePathName == FilePathName)
                    {
                        NlogHandler.GetSingleton().Info(string.Format("关闭进程 {0}", processName));
                        try
                        {
                            if (p.CloseMainWindow() == false)
                            {
                                p.Kill();
                                p.Close();
                            }

                            await Task.Delay(2000);

                            p.Kill();
                            p.Close();

                            NlogHandler.GetSingleton().Info(string.Format("杀死并清空进程 {0}", processName));

                        }
                        catch (Exception e)
                        {
                            NlogHandler.GetSingleton().Info(string.Format("关闭进程异常 {0}", e.Message.ToString()));
                        }
                        
                        
                    }
                }
            }
        }
    }
}
