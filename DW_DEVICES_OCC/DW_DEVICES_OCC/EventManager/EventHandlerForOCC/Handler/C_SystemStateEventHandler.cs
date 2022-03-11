using CLIENT_TO_OCC;
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
            
        }
    }
}
