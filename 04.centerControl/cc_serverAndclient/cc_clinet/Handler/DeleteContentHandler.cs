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
    /// 删除客户端文件夹
    /// </summary>
    public class DeleteContentHandler : IEventHandler<R_C_DeleteContentData>
    {

        public void HandleEvent(R_C_DeleteContentData eventData)
        {

            C_DeleteContentData sendData = new C_DeleteContentData();

            sendData.DeleteResults = new string[eventData.ContentPaths.Count];
            for (int i = 0; i < eventData.ContentPaths.Count; i++)
            {
                Content content = new Content(eventData.ContentPaths[i]);
                try
                {
                    switch (content.Type)
                    {
                        case Content.TYPE_NOT_FOUND:
                            throw new KnownException("此路径所代表的不是一个文件或目录。");
                        case Content.TYPE_FILE:
                            File.Delete(content.Path);
                            break;
                        case Content.TYPE_DRIVER:
                            throw new KnownException("此路径所代表的是一个驱动器。");
                        case Content.TYPE_DIRECTORY:
                            Directory.Delete(content.Path, true);
                            break;
                    }
                }
                catch (Exception e)
                {
                    sendData.ErorrOccured = true;
                    sendData.DeleteResults[i] = content.Path + " " + e.Message;
                }
            }


            RabbitMQEventBus.GetSingleton().Trigger<C_DeleteContentData>(eventData.fromIp, sendData);//直接通过事件总线触发
        }
    }
}
