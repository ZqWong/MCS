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
    /// 重命名客户端文件夹
    /// </summary>
    public class RenameContentHandler : IEventHandler<R_C_RenameContentData>
    {

        public void HandleEvent(R_C_RenameContentData eventData)
        {

            C_RenameContentData sendData = new C_RenameContentData();
            try
            {
                Content content = new Content(eventData.ContentPath);
                switch (content.Type)
                {
                    case Content.TYPE_NOT_FOUND:
                        throw new KnownException("无法找到文件或目录 " + content.Path + " 。");
                    case Content.TYPE_DRIVER:
                        throw new KnownException("不能重命名驱动器 " + content.Path + " 。");
                    case Content.TYPE_FILE:
                        if (FileProcess.IsFileOrDirectoryNameValid(eventData.NewContentName) == false)
                        {
                            throw new KnownException("新的文件名称 " + eventData.NewContentName + " 是无效的。");
                        }
                        string newFilePath = FileProcess.GetRenamedFilePath(content.Path, eventData.NewContentName);
                        File.Move(content.Path, newFilePath);
                        break;
                    case Content.TYPE_DIRECTORY:
                        if (FileProcess.IsFileOrDirectoryNameValid(eventData.NewContentName) == false)
                        {
                            throw new KnownException("新的目录名称 " + eventData.NewContentName + " 是无效的。");
                        }
                        string newDirectoryPath = FileProcess.GetRenamedDirectoryPath(content.Path, eventData.NewContentName);
                        Directory.Move(content.Path, newDirectoryPath);
                        break;
                }
            }
            catch (Exception e)
            {
                sendData.ErorrOccured = true;
                sendData.ErrorMessage = e.Message;
            }

            RabbitMQEventBus.GetSingleton().Trigger<C_RenameContentData>(eventData.fromIp, sendData);//直接通过事件总线触发
        }
    }
}
