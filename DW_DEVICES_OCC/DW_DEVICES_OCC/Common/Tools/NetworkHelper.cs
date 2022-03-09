using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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

    [DllImport("ws2_32.dll")]
    private static extern int inet_addr(string cp);

    [DllImport("IPHLPAPI.dll")]
    private static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 pMacAddr, ref Int32 PhyAddrLen);

    /// <summary>
    /// 获取Mac地址
    /// </summary>
    /// <param name="hostip"></param>
    /// <returns></returns>
    public static string GetMacAddress(string hostip)//获取远程IP（不能跨网段）的MAC地址
    {
        string Mac = "";
        try
        {
            Int32 ldest = inet_addr(hostip); //将IP地址从 点数格式转换成无符号长整型
            Int64 macinfo = new Int64();
            Int32 len = 6;
            SendARP(ldest, 0, ref macinfo, ref len);
            string TmpMac = Convert.ToString(macinfo, 16);//转换成16进制
            Mac = TmpMac.Substring(0, 2).ToUpper();
            for (int i = 2; i < TmpMac.Length; i = i + 2)
            {
                Mac = TmpMac.Substring(i, 2).ToUpper() + "-" + Mac;
            }
        }
        catch (Exception ex)
        {
            Debug.Error("获取远程主机的MAC错误，请输入正确的IP！ex:" + ex);
        }
        return Mac;
    }
}

