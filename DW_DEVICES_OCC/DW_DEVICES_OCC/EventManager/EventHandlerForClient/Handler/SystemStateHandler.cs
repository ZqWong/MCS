using OCC_TO_CLIENT;
using RabbitMQEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIENT_TO_OCC
{
    public class SystemStateHandler : IEventHandler<R_C_SystemStateData>
    {
        public void HandleEvent(R_C_SystemStateData eventData)
        {
            throw new NotImplementedException();
        }
    }
}
