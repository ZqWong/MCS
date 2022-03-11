using CLIENT_TO_OCC;
using OCC.Forms.OCC_Main;
using RabbitMQEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler
{
    public class C_SystemStateEventHandler : IEventHandler<C_SystemStateData>
    {
        public void HandleEvent(C_SystemStateData eventData)
        {

            OCC_Main.UpdateSystemStateArgs args = new OCC_Main.UpdateSystemStateArgs()
            {
                ip = eventData.fromIp,
                cpu = eventData.cpu_ratio,
                memory = eventData.memory_available,
                tickCount = eventData.system_tick_count,
                gpu_ratio = eventData.gpu_ratio,
                gpu_memory_ratio = eventData.gpu_memory_ratio,
            };

            OCC_Main.UiContext.Post(OCC_Main.Instance.UpdateDeviceSystemInfoEventHandler, args);
        }
    }
}
