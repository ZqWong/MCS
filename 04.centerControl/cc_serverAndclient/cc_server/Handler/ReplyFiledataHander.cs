using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventBus.Handlers;
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

            Console.WriteLine("客户端IP :{0}, 传输进度 :{1} 文件完整性校验： {2}, 文件名称 :{3}", 
                eventData.client_ip, eventData.receive_ratio, eventData.verify_complete, eventData.fileName);

        }
    }
}
