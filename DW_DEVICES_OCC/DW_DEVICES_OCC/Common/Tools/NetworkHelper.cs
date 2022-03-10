using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


public static class NetworkHelper
{
    [DllImport("ws2_32.dll")]
    private static extern int inet_addr(string cp);

    [DllImport("IPHLPAPI.dll")]
    private static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 pMacAddr, ref Int32 PhyAddrLen);

    /// <summary>
    /// 获取IP地址
    /// </summary>
    /// <returns></returns>
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

    public class ComputerNetInfo
    {
        public string _strIp = "";
        public string _strMac = "";
        public string _strComputerName = "";
    }

    // 获取局域网在线电脑信息
    public static ComputerNetInfo[] GetOnlineComputerNetInfo()
    {
        List<ComputerNetInfo> comListAll = new List<ComputerNetInfo>();
        Process p = new Process();
        p.StartInfo.FileName = "net";
        p.StartInfo.Arguments = "view";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.CreateNoWindow = true;
        p.Start();
        p.StandardInput.WriteLine("exit");
        StreamReader reader = p.StandardOutput;
        for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
        {
            line = line.Trim();
            if (line.StartsWith(@"\\"))
            {
                string name = line.Substring(2).Trim();
                string[] strList = name.Split();
                ComputerNetInfo com = new ComputerNetInfo();
                com._strComputerName = strList[0];
                com._strIp = getIPbyComputerName(com._strComputerName);
                com._strMac = GetMacAddress(com._strIp);
                if (com._strIp != null)
                {
                    if (com._strIp.Trim() != "")
                    {
                        comListAll.Add(com);
                    }
                }
            }
        }
        ComputerNetInfo[] comRetInfo = new ComputerNetInfo[comListAll.Count];
        for (int i = 0; i < comListAll.Count; i++)
        {
            comRetInfo[i] = comListAll[i];
        }
        p.Close();
        return comRetInfo;
    }

    /// <summary>
    /// 通过计算机名获取IP
    /// </summary>
    /// <param name="computerName"></param>
    /// <returns></returns>
    public static string getIPbyComputerName(string computerName)
    {
        string IPAddress = null;
        IPHostEntry myHost = new IPHostEntry();
        try
        {
            myHost = Dns.GetHostEntry(computerName);
            if (myHost.AddressList.Length > 2)
            {
                for (int i = 0; i < myHost.AddressList.Length; i++)
                {
                    if (i == 2)
                    {
                        IPAddress = myHost.AddressList[i].ToString();
                    }
                }
            }
            else
            {
                if (myHost.AddressList.Length == 1)
                {
                    IPAddress = myHost.AddressList[0].ToString();
                }
                else
                {
                    for (int i = 0; i < myHost.AddressList.Length; i++)
                    {

                        if (i == 1)
                        {
                            IPAddress = myHost.AddressList[i].ToString();
                        }
                    }
                }
            }
        }
        catch /*(Exception e)*/
        {

        }

        return IPAddress;
    }

    /// <summary>
    /// 更改计算机IP
    /// </summary>
    /// <param name="IP"></param>
    public static void SwitchToStatic(string IP)
    {
        ManagementBaseObject inPar = null;
        ManagementBaseObject outPar = null;
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = mc.GetInstances();
        foreach (ManagementObject mo in moc)
        {
            if (!(bool)mo["IPEnabled"])
                continue;

            inPar = mo.GetMethodParameters("EnableStatic");
            inPar["IPAddress"] = new string[] { IP };
            inPar["SubnetMask"] = new string[] { "255.255.255.0" };
            outPar = mo.InvokeMethod("EnableStatic", inPar, null);
            break;
        }
    }
}

