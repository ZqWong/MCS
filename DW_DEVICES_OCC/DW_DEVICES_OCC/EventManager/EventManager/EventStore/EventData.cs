using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQEvent
{
    /// <summary>
    /// 事件源：描述事件信息，用于参数传递
    /// </summary>
    public class EventData : IEventData
    {
        /// <summary>
        /// 事件发生的时间
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 触发事件的对象
        /// </summary>
        public Object EventSource { get; set; }

        public EventData()
        {
            EventTime = DateTime.Now;
        }

        public bool ErorrOccured;

        public string ErrorMessage;

        /// <summary>
        /// 发送端ip
        /// </summary>
        public string fromIp = GetIP();


        public static string GetIP()
        {
            try
            {
                //获取主机名
                string HostName = Dns.GetHostName();
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                Debug.Error($"获取IP失败 {ex}");
                return "";
            }
        }
    }
}
