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
    /// 获取系统状态，cpu占用率、内存使用率等
    /// </summary>
    public class SystemStateHandler : IEventHandler<R_C_SystemStateData>
    {
        private static PerformanceCounter cpuCounter;
        private static PerformanceCounter ramCounter;


        public SystemStateHandler()
        {

            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

        }

        public void HandleEvent(R_C_SystemStateData eventData)
        {

            //NlogHandler.GetSingleton().Info(string.Format("获取系统信息Handler，cpu等"));

            float gpuAvailableMemory = (float)PhysicalGPU.GetPhysicalGPUs()[0].MemoryInformation
                .CurrentAvailableDedicatedVideoMemoryInkB;
            float gpuTotalMemory =
                (float)PhysicalGPU.GetPhysicalGPUs()[0].MemoryInformation.AvailableDedicatedVideoMemoryInkB;

            var SendEventData = new C_SystemStateData()
            {
                cpu_ratio = cpuCounter.NextValue(),
                memory_available = ramCounter.NextValue(),
                system_tick_count = System.Environment.TickCount,
                gpu_ratio = PhysicalGPU.GetPhysicalGPUs()[0].UsageInformation.GPU.Percentage,
                gpu_memory_ratio = (gpuTotalMemory - gpuAvailableMemory) / gpuTotalMemory * 100.0f,

            };

            RabbitMQEventBus.GetSingleton().Trigger<C_SystemStateData>(SendEventData);//直接通过事件总线触发
        }
    }
}
