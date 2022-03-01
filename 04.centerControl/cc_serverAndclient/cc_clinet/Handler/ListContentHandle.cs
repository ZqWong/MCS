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
    /// 关机和重启
    /// </summary>
    public class ListContentHandle : IEventHandler<R_C_ListContentResData>
    {

        public void HandleEvent(R_C_ListContentResData eventData)
        {
            C_ListContentResData sendData = new C_ListContentResData();

            try
            {
                if (String.IsNullOrEmpty(eventData.DriverOrDirectoryPath))
                {
                    sendData.Drivers = Directory.GetLogicalDrives();
                }
                else
                {
                    Content content = new Content(eventData.DriverOrDirectoryPath);
                    switch (content.Type)
                    {
                        case Content.TYPE_NOT_FOUND:
                            NlogHandler.GetSingleton().Error("无法找到文件或目录 " + content.Path + " 。");
                            throw new KnownException("无法找到文件或目录 " + content.Path + " 。");
                        case Content.TYPE_DRIVER:
                            sendData.Directories = Directory.GetDirectories(content.Path);
                            sendData.Files = Directory.GetFiles(content.Path);
                            break;
                        case Content.TYPE_FILE:
                            NlogHandler.GetSingleton().Error("路径 " + content.Path + " 是一个文件，无法列出内容。");
                            throw new KnownException("路径 " + content.Path + " 是一个文件，无法列出内容。");
                        case Content.TYPE_DIRECTORY:
                            sendData.Directories = Directory.GetDirectories(content.Path);
                            sendData.Files = Directory.GetFiles(content.Path);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                sendData.ErorrOccured = true;
                sendData.ErrorMessage = e.Message;
            }

            RabbitMQEventBus.GetSingleton().Trigger<C_ListContentResData>(eventData.fromIp, sendData);//直接通过事件总线触发


        }

    }
}
