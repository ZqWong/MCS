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
using Utilities;

namespace cc_server
{
    /// <summary>
    /// 传输事件处理
    /// </summary>


    public class CurrentStateHandler : IEventHandler<C_SystemStateData>
    {
        public void HandleEvent(C_SystemStateData eventData)
        {
            主界面.UpdateSystemState_Args args = new 主界面.UpdateSystemState_Args()
            {
                ip = eventData.fromIp, cpu = eventData.cpu_ratio, memory = eventData.memory_available , tickCount = eventData.system_tick_count,
                gpu_ratio = eventData.gpu_ratio, gpu_memory_ratio = eventData.gpu_memory_ratio,
            };

            主界面.GetSingleton().GetSyncContext().Post(主界面.GetSingleton().UpdateSystemState, args);

            // 不加log，因为该方法每隔一段周期就会被调用
            //NlogHandler.GetSingleton().Info(string.Format("Gpu 可用内存 百分比 {0}", eventData.gpu_memory_ratio));
            //Console.WriteLine("客户端IP :{0}, 当前CPU占用率 :{1}, 当前可用内存 :{2} MB", eventData.client_ip, eventData.cpu_ratio, eventData.memory_available);


        }
    }
}
