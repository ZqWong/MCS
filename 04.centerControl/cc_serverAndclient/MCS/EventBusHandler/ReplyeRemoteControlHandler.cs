using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using MCS;
using UserEventData;
using Utilities;

namespace cc_server
{
    /// <summary>
    /// 传输事件处理
    /// </summary>


    public class ReplyeRemoteControlHandler : IEventHandler<C_RemoteControlData>
    {
        public void HandleEvent(C_RemoteControlData eventData)
        {

            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (eventData.isOpen)
                {
                    if (RemoteControl.GetSingleton().mIpFormDict.ContainsKey(eventData.fromIp))
                    {
                        NlogHandler.GetSingleton().Debug(string.Format("不能重复打开远程 ip :{0}", eventData.fromIp));
                        return;
                    }

                    RemoteControl.GetSingleton().ShowControlWindow(eventData.fromIp, eventData.workingAreaHeight, eventData.workingAreaWidth);
                    //RemoteControl.GetSingleton().();
                }
                else
                {
                    RemoteControl.GetSingleton().RemoteWindosClosed(eventData.fromIp);
                }

            });
            主界面.GetSingleton().BeginInvoke(mi);

        }
    }
}
