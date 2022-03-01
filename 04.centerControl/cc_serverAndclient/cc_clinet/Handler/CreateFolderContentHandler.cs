using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using NvAPIWrapper;
using NvAPIWrapper.GPU;
using UserEventData;
using Utilities;

namespace cc_clinet
{
    /// <summary>
    /// 新建客户端文件夹
    /// </summary>
    public class CreateFolderContentHandler : IEventHandler<R_C_CreateFolderContentData>
    {

        public void HandleEvent(R_C_CreateFolderContentData eventData)
        {

            C_CreateFolderContentData sendData = new C_CreateFolderContentData();
            try
            {
                Content content = new Content(eventData.Container);
                switch (content.Type)
                {
                    case Content.TYPE_NOT_FOUND:
                        throw new KnownException("无法在路径 " + content.Path + " 上创建目录，因为它代表的不是一个驱动器或目录。");
                    case Content.TYPE_DRIVER:
                        if (FileProcess.IsFileOrDirectoryNameValid(eventData.Name) == false)
                        {
                            throw new KnownException("要创建的目录名称 " + eventData.Name + "是无效的。");
                        }
                        Directory.CreateDirectory(content.Path + eventData.Name + Path.DirectorySeparatorChar);
                        break;
                    case Content.TYPE_FILE:
                        throw new KnownException("无法在路径 " + content.Path + " 上创建目录，因为它代表是一个文件。");
                    case Content.TYPE_DIRECTORY:
                        if (FileProcess.IsFileOrDirectoryNameValid(eventData.Name) == false)
                        {
                            throw new KnownException("要创建的目录名称 " + eventData.Name + "是无效的。");
                        }
                        Directory.CreateDirectory(content.Path + eventData.Name + Path.DirectorySeparatorChar);
                        break;
                }

            }
            catch (Exception e)
            {
                sendData.ErorrOccured = true;
                sendData.ErrorMessage = e.Message;

            }

            RabbitMQEventBus.GetSingleton().Trigger<C_CreateFolderContentData>(eventData.fromIp, sendData);//直接通过事件总线触发
        }
    }
}
