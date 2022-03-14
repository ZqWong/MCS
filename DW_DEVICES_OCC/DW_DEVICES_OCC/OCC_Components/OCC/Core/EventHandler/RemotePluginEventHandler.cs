using OCC.Forms.OCC_Devices;
using OCC.Forms.OCC_Main;
using RabbitMQEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandler
{
    /// <summary>
    /// 插件控制连接设备是否连接
    /// </summary>
    public class RemotePluginEventHandler : IEventHandler<S_PluginEventData>
    {
        public class UpdateConnectionStateArgs
        {
            public string ip { get; set; }
            public bool connect { get; set; }
        }


        public void HandleEvent(S_PluginEventData eventData)
        {
            Debug.Error((eventData.routingKeys == "connection.created").ToString());

            if (eventData.routingKeys == "connection.created")
            {
                // 值为： 192.168.0.73:50325 -> 192.168.0.112:5672
                string ipPort = eventData.headers["name"].ToString();

                string clientIp = ipPort.Substring(0, ipPort.IndexOf(':'));

                UpdateConnectionStateArgs args = new UpdateConnectionStateArgs() { ip = clientIp, connect = true };
                OCC_Main.UiContext.Post(OCC_Main.Instance.UpdateDeviceConnectionState, args);
                OCC_Device.UiContext.Post(OCC_Device.Instance.UpdateDeviceConnectionState, args);
            }
            else if (eventData.routingKeys == "connection.closed")
            {
                string ipPort = eventData.headers["name"].ToString();

                string clientIp = ipPort.Substring(0, ipPort.IndexOf(':'));

                UpdateConnectionStateArgs args = new UpdateConnectionStateArgs() { ip = clientIp, connect = false };
                OCC_Main.UiContext.Post(OCC_Main.Instance.UpdateDeviceConnectionState, args);
                OCC_Device.UiContext.Post(OCC_Device.Instance.UpdateDeviceConnectionState, args);

                //// 如果远程桌面控制客户端重启或关机，远程桌面维护的已经连接远程桌面的客户端字典不会清空。在此清空
                //RemoteControl.GetSingleton().RemoteWindosClosed(clientIp);
            }
        }
    }
}
