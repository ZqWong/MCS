using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;



public class DevicePingManager : LockedSingletonClass<DevicePingManager>
{
    public object lockPingIp = new object();
    
    /// <summary>
    /// 给定列表中可以ping同的IP列表缓存
    /// </summary>
    private ConcurrentDictionary<string, string> canPingIpCacheDictionary = new ConcurrentDictionary<string, string>();
    /// <summary>
    /// 真正拿到的可ping通的信息
    /// </summary>
    public ConcurrentDictionary<string, string> IPDict = new ConcurrentDictionary<string, string>();


    public void PingDevices(List<string> ips)
    {
        try
        {
            // 赋值给IPlist
            lock (lockPingIp)
            {
                // 将上次查找的ip保存。防止在两次查找间隔过程中清空了_IPBag导致应用到_IPBag的里面为空
                // 这样会导致IPList是_IPBag延迟定长的结果
                IPDict.Clear();
                foreach (var item in canPingIpCacheDictionary)
                {
                    IPDict[item.Key] = item.Value;
                }
            }
            
            while (!canPingIpCacheDictionary.IsEmpty)
            {
                canPingIpCacheDictionary.Clear();
            }

            foreach (var ip in ips)
            {
                PingTargetIp(ip);
            }       
        }
        catch (Exception ex)
        {
            Debug.Error($"局域网中ping发生异常 {ex}");
        }
    }

    private void PingTargetIp(string ip)
    {
        if (string.IsNullOrEmpty(ip))
        {
            // 过于频繁 关闭log
            // NlogHandler.GetSingleton().Error(string.Format("pingIp 中的ip 地址不能为null"));
            return;
        }

        Ping pingHandler;
        pingHandler = new Ping();
        pingHandler.PingCompleted += new PingCompletedEventHandler(PingCompleted);
        pingHandler.SendAsync(ip, 1000, null);
    }

    private void PingCompleted(object sender, PingCompletedEventArgs e)
    {
        if (e.Reply == null)
            return;

        if (e.Reply.Status.Equals(IPStatus.Success))
        {
            canPingIpCacheDictionary[e.Reply.Address.ToString()] = e.Reply.RoundtripTime.ToString();
        }
        else
        {
            //MessageBox.Show(e.Reply.Address.ToString());
        }
    }
}

