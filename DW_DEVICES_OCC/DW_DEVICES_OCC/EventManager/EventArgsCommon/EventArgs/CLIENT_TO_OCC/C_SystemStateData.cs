using RabbitMQEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIENT_TO_OCC
{
    public class C_SystemStateData : EventData
    {
        public float cpu_ratio;
        public float memory_available;
        public float gpu_ratio;
        public float gpu_memory_ratio;
        public int system_tick_count;
    }
}
