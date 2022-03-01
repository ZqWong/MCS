using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using MCS;
using UserEventData;

namespace cc_server
{
    /// <summary>
    /// 传输事件处理
    /// </summary>
    public class ReplyFileDataHander : IEventHandler<C_ReplyFileData>
    {
        public void HandleEvent(C_ReplyFileData eventData)
        {
            传输文件.client_receive_progress_Args args = new 传输文件.client_receive_progress_Args()
            {
                ip = eventData.fromIp, totalSize = eventData.totalSize, alreadySendSize = eventData.alreadySendSize
            };

            传输文件.GetSingleton().GetSyncContext().Post(传输文件.GetSingleton().client_receive_progress, args);


            //Console.WriteLine("客户端IP :{0}, 传输进度 :{1} 文件完整性校验： {2}, 文件名称 :{3}", 
            //    eventData.client_ip, eventData.receive_ratio, eventData.verify_complete, eventData.fileName);

        }
    }
}
