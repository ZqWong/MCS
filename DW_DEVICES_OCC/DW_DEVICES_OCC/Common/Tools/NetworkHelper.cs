using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


public static class NetworkHelper
{
    public static string GetIP()
    {
        string ret = string.Empty;
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
                    ret = IpEntry.AddressList[i].ToString();
                }
            }         
            return ret;
        }
        catch (Exception ex)
        {
            Debug.Error($"NetworkHelper GetIP Exception {ex}");    
            return ret;
        }
    }

}

