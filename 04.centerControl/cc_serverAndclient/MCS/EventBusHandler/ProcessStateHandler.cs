using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Model;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using MCS;
using UserEventData;

namespace cc_server
{
    /// <summary>
    /// 传输事件处理
    /// </summary>


    public class ProcessStateHandler : IEventHandler<C_ProcessStateData>
    {
        public void HandleEvent(C_ProcessStateData eventData)
        {
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                主界面.GetSingleton().UpdateProcessState(eventData.fromIp, eventData.ProcessNameList);
            });

            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
