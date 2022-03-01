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
    /// 监控客户端connection、channel、binding等状态更改信息
    /// 由rabbitmq-event-exchange 插件传输
    /// 
    /// </summary>


    public class PluginEventHandler : IEventHandler<S_PluginEventData>
    {
        public void HandleEvent(S_PluginEventData eventData)
        {

            if (eventData.routingKeys == "connection.created")
            {
                string ipPort = eventData.headers["name"].ToString();
                // 值为： 192.168.0.73:50325 -> 192.168.0.112:5672

                string clientIp = ipPort.Substring(0, ipPort.IndexOf(':'));

                主界面.UpdateCC_ClientConnectionState_Args args = new 主界面.UpdateCC_ClientConnectionState_Args() {ip = clientIp, connect = true};

                主界面.GetSingleton().GetSyncContext().Post(主界面.GetSingleton().UpdateCC_ClientConnectionState, args);
            }
            else if (eventData.routingKeys == "connection.closed")
            {
                string ipPort = eventData.headers["name"].ToString();

                string clientIp = ipPort.Substring(0, ipPort.IndexOf(':'));

                主界面.UpdateCC_ClientConnectionState_Args args = new 主界面.UpdateCC_ClientConnectionState_Args() { ip = clientIp, connect = false };

                主界面.GetSingleton().GetSyncContext().Post(主界面.GetSingleton().UpdateCC_ClientConnectionState, args);

                // 如果远程桌面控制客户端重启或关机，远程桌面维护的已经连接远程桌面的客户端字典不会清空。在此清空
                RemoteControl.GetSingleton().RemoteWindosClosed(clientIp);

            }
            // 需要监控哪些就继续if else

        }
    }
}
