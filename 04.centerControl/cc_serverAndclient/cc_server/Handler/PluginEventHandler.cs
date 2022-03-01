using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventBus.Handlers;
using UserEventData;

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
            Console.WriteLine("==================================routing key is :{0} ===================================", eventData.routingKeys);

            if (eventData.routingKeys == "connection.created")
            {
                string ipPort = eventData.headers["name"].ToString();
                // 值为： 192.168.0.73:50325 -> 192.168.0.112:5672
                Console.WriteLine("========连接========{0}",ipPort);
            }
            else if (eventData.routingKeys == "connection.closed")
            {
                string ipPort = eventData.headers["name"].ToString();
                Console.WriteLine("========断开========{0}", ipPort);
            }
            // 需要监控哪些就继续if else

        }
    }
}
