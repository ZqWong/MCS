using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
    /// 更新
    /// </summary>
    public class UpdateHandler : IEventHandler<R_C_UpdateData>
    {

        public void HandleEvent(R_C_UpdateData eventData)
        {
            NlogHandler.GetSingleton().Info(string.Format("开始更新client, 现client运行目录: {0}, 更新文件目录: {1} , 更新程序路径: {2}, 当前客户端路径: {3}", 
                eventData.oldFolder, eventData.newFolder, eventData.updateClientFullName, eventData.clientFullName));


            string udpateClientProgressName = ComFunc.GetSingleton().GetName(eventData.updateClientFullName);

            string oldUpdateClientPath = ComFunc.GetSingleton().GetParentPath(eventData.updateClientFullName);

            string newUpdateClientFullName = eventData.newFolder +
                                             ComFunc.GetSingleton().GetParentFolderName(oldUpdateClientPath) +
                                             udpateClientProgressName;


            NlogHandler.GetSingleton().Info(string.Format("现有updateClientProgress目录 :{0}, 新的updateClientProgress目录 :{1}",
                eventData.updateClientFullName, newUpdateClientFullName));


            string clientPath = ComFunc.GetSingleton().GetParentPath(eventData.clientFullName);

            if (oldUpdateClientPath != clientPath)
            {
                string updateSourcePath =
                    eventData.newFolder + ComFunc.GetSingleton().GetParentFolderName(oldUpdateClientPath);

                NlogHandler.GetSingleton().Info(string.Format("更新updateClient程序。从目录：{0} 到目录： {1}", updateSourcePath, oldUpdateClientPath));

                try
                {
                    // 删除
                    List<string> exceptPath = new List<string>();
                    exceptPath.Add(oldUpdateClientPath);
                    ComFunc.GetSingleton().DeleteFolder(oldUpdateClientPath, exceptPath);
                    // 复制
                    ComFunc.GetSingleton().directoryCopy(updateSourcePath, oldUpdateClientPath);
                }
                catch (Exception e)
                {
                    NlogHandler.GetSingleton().Info(string.Format("move exception :{0}", e.Message.ToString()));
                }
                
            }


            var controlProcess = new R_C_ControlProcessData(eventData.updateClientFullName, true);

            NlogHandler.GetSingleton().Info(string.Format("运行updateClinet程序"));

            controlProcess.arguments = string.Format("-o {0} -n {1} -c {2} -u {3}", eventData.oldFolder, eventData.newFolder,eventData.clientFullName,
                eventData.updateClientFullName);

            controlProcess.createNoWindow = false;

            // 触发获取本地进程信息event
            RabbitMQEventBus.GetSingleton().Trigger<R_C_ControlProcessData>(GetLocalIp.GetSingleton().GetIP(), controlProcess);//直接通过事件总线触发

        }
    }
} 
