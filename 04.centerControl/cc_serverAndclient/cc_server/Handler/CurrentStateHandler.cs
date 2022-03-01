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


    public class CurrentStateHandler : IEventHandler<C_SystemStateData>
    {
        public void HandleEvent(C_SystemStateData eventData)
        {
            Console.WriteLine("客户端IP :{0}, 当前CPU占用率 :{1}, 当前可用内存 :{2} MB", eventData.client_ip, eventData.cpu_ratio, eventData.memory_available);

        }
    }
}
