using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using UserEventData;

namespace cc_clinet
{
    /// <summary>
    /// 查看进程运行状态
    /// </summary>
    public class ProcessStateHandler : IEventHandler<R_C_ProcessStateData>
    {
        public void HandleEvent(R_C_ProcessStateData eventData)
        {
            C_ProcessStateData sendData = new C_ProcessStateData();
            sendData.ProcessNameList = new List<string>();

            foreach (string processName in eventData.ProcessNameList)
            {
                Process[] all = Process.GetProcessesByName(processName);

                if (all.Length == 0)
                {
                }
                else
                {
                    sendData.ProcessNameList.Add(all[0].ProcessName);
                }
            }

            RabbitMQEventBus.GetSingleton().Trigger<C_ProcessStateData>(sendData);//直接通过事件总线触发

        }
    }
}
