using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using LibNvDriverSetting;
using LibUtilitiesNameSpace;
using UserEventData;
using Utilities;

namespace cc_clinet
{
    /// <summary>
    /// 立体开关
    /// 控制显示的dll是32位，需要通过进程来控制，进程间通信通过有名管道
    /// </summary>
    public class GetCltStereoHandler : IEventHandler<R_C_GetCltStereo>
    {
        public static NamedPipeServerStream server = null;

        public static bool startStereoProcess(ref NamedPipeServerStream server)
        {
            // 判断是否运行该名称进程
            string processName = "cc_client_stereo";

            if (Process.GetProcessesByName(processName).Length > 0)
            {
                NlogHandler.GetSingleton().Info(string.Format("查看显卡设置的程序 {0} 已经运行 本次操作无效", processName));

                return false;
            }

            string currentPath = Application.StartupPath;

            // 启动进程
            var controlProcess = new R_C_ControlProcessData(currentPath + @"\stereoProgress\cc_client_stereo.exe", true);

            NlogHandler.GetSingleton().Info(string.Format("运行stereo控制程序, 目录是: {0}", currentPath + @"\stereoProgress\cc_client_stereo.exe"));

            controlProcess.createNoWindow = true;

            // 触发获取本地进程信息event
            RabbitMQEventBus.GetSingleton().Trigger<R_C_ControlProcessData>(GetLocalIp.GetSingleton().GetIP(), controlProcess);//直接通过事件总线触发

            server = new NamedPipeServerStream("StereoPipeLine", PipeDirection.InOut, 20);

            NlogHandler.GetSingleton().Info(string.Format("运行stereo进程，等待管道连接"));

            return true;

        }

        public static void pipeMessage(NamedPipeServerStream server, string pipeString, ref string recData)
        {

            NlogHandler.GetSingleton().Info(string.Format("运行stereo进程，并且管道已经连接"));

            StreamWriter sw = new StreamWriter(server);
            sw.WriteLine(pipeString);
            sw.Flush();


            StreamReader sr = new StreamReader(server);
            recData = sr.ReadLine();
            Console.WriteLine(recData);

            sw.Close();
            sr.Close();

            NlogHandler.GetSingleton().Info(string.Format("运行stereo进程，管道已经关闭"));
        }

        public async void HandleEvent(R_C_GetCltStereo eventData)
        {
            try
            {
                ////获取客户端立体显示的状态
                string pipeString = "GetStereoInfo";

                if (startStereoProcess(ref server))
                {
                    await server.WaitForConnectionAsync();

                    string recData = "";

                    pipeMessage(server, pipeString, ref recData);


                    if (recData.StartsWith(pipeString))
                    {
                        string stereo = recData.Substring(pipeString.Length, 1);
                        string swapEye = recData.Substring(pipeString.Length + 1, 1);

                        ////将响应的信息发送只服务器.
                        C_GetCltStereo SendData = new C_GetCltStereo();
                        SendData.m_stereoOn = Convert.ToInt32(stereo);
                        SendData.m_swapEye = Convert.ToInt32(swapEye);

                        NlogHandler.GetSingleton().Info("响应服务器获取立体及左右眼状态的请求，立体->" + stereo + ", 左右眼->" + swapEye);

                        RabbitMQEventBus.GetSingleton().Trigger<C_GetCltStereo>(SendData);//直接通过事件总线触发

                        server.Close();
                    }
                    else
                    {
                        NlogHandler.GetSingleton().Info("服务器获取立体及左右眼状态通讯协议异常，收到字符为：" + recData);
                    }
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Info("服务器获取立体及左右眼状态通讯协议异常，收到字符为：" + e.Message.ToString());
            }



        }
    }
}
