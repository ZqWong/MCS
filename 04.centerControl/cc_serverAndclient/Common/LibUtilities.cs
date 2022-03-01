using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class ComputerNetInfo
    {
        public string _strIp = "";
        public string _strMac = "";
        public string _strComputerName = "";
    }

    public class LibUtilities
    {
        [DllImport("ws2_32.dll")]
        private static extern int inet_addr(string cp);
        [DllImport("IPHLPAPI.dll")]
        private static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 pMacAddr, ref Int32 PhyAddrLen);

        /// <summary>
        /// 启动外部应用程序
        /// </summary>
        /// <param name="appPath">应用程序路径</param>
        /// <returns></returns>
        static public Process StartExternalProcess(string appPath, string arguments)
        {
            Process proRet = null;

            ProcessStartInfo startInfo = null;
            try
            {
                startInfo = new ProcessStartInfo(appPath);
                startInfo.UseShellExecute = false;
                if (arguments != "")
                {
                    startInfo.Arguments = arguments;
                }
                if (proRet != null && !proRet.HasExited)
                {
                    proRet.Kill();
                    proRet = null;
                }

                proRet = Process.Start(startInfo);
            }
            catch
            {

            }
            return proRet;
        }

        /// <summary>
        /// 启动外部应用程序
        /// </summary>
        /// <param name="appPath">应用程序路径</param>
        /// <returns></returns>
        static public Process StartExternalProcess(string appPath)
        {
            Process proRet = null;
            ProcessStartInfo startInfo = null;
            try
            {
                startInfo = new ProcessStartInfo(appPath);
                if (proRet != null && !proRet.HasExited)
                {
                    proRet.Kill();
                    proRet = null;
                }
                proRet = Process.Start(startInfo);
            }
            catch
            {

            }
            return proRet;
        }

        /// <summary>
        /// 启动外部应用程序（最大化,隐藏，正常显示等)
        /// </summary>
        /// <param name="appPath">应用程序路径</param>
        /// <returns></returns>
        static public Process StartExternalProcess(string appPath, ProcessWindowStyle style)
        {
            Process proRet = null;
            ProcessStartInfo startInfo = null;
            try
            {
                startInfo = new ProcessStartInfo(appPath);
                startInfo.WindowStyle = style;
                if (proRet != null && !proRet.HasExited)
                {
                    proRet.Kill();
                    proRet = null;
                }

                proRet = Process.Start(startInfo);
            }
            catch
            {

            }
            return proRet;
        }

        static public void CloseExternalProcess(Process proc)
        {
            try
            {
                if (proc != null && !proc.HasExited)
                {
                    proc.Kill();
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 设置开机自动运行
        /// </summary>
        /// <param name="executablePath">Application.ExecutablePath</param>
        /// <param name="isAutoRun">是否开机自动运行</param>
        static public void SetAutoRun(string executablePath, bool isAutoRun)
        {
            RegistryKey reg = null;
            try
            {
                String name = executablePath.Substring(executablePath.LastIndexOf(@"/") + 1);
                string subkey = @"Software\Microsoft\Windows\CurrentVersion\Run";

                reg = Registry.CurrentUser.OpenSubKey(subkey, true); // CurrentUser没问题，LocalMachine不行

                if (reg == null)
                    reg = Registry.CurrentUser.CreateSubKey(subkey);
                if (isAutoRun)
                    reg.SetValue(name, executablePath);
                else
                    reg.SetValue(name, false);
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (reg != null)
                    reg.Close();
            }
        }

        /// <summary>
        /// 判断应用程序是否开机自动运行
        /// </summary>
        /// <param name="executablePath"></param>
        /// <returns></returns>
        static public bool IsAppAutoRun(string executablePath)
        {

            bool ret = false;
            RegistryKey reg = null;
            try
            {
                if (!System.IO.File.Exists(executablePath))
                    throw new Exception("该文件不存在!");
                String name = executablePath.Substring(executablePath.LastIndexOf(@"/") + 1);
                string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                reg = Registry.CurrentUser.OpenSubKey(subkey, true);
                if (reg == null)
                {
                    ret = false;
                }
                else
                {
                    string strValue = reg.GetValue(name).ToString();
                    if (strValue == executablePath)
                    {
                        ret = true;
                    }
                    else
                    {
                        ret = false;
                    }
                }
            }
            catch
            {
                ret = false;
            }
            finally
            {
                if (reg != null)
                    reg.Close();
            }
            return ret;
        }

        static public bool IsDiskRoot(string folderPath)
        {
            if (folderPath.Length == 3 && folderPath.IndexOf("\\", 0, 3) == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取加载dll的exe所在的文件夹
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyExeFolder()
        {
            Assembly myAssembly = Assembly.GetEntryAssembly();
            string path = myAssembly.Location;
            DirectoryInfo dr = new DirectoryInfo(path);
            return dr.Parent.FullName;
        }

        /// <summary>
        /// 修改计算机名(using Microsoft.Win32;)
        /// </summary>
        /// <param name="name"></param>
        public static void SetComputerNameAs(string name)
        {
            try
            {
                RegistryKey myRKCN = Registry.LocalMachine.OpenSubKey("SYSTEM\\ControlSet001\\Services\\Tcpip\\Parameters", true);
                foreach (string site in myRKCN.GetValueNames())
                {
                    if (site == "NV Hostname")
                    {
                        myRKCN.DeleteValue(site, false);
                        myRKCN.SetValue("NV Hostname", name);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 运行CMD命令
        /// 
        /// 调用示例代码
        /// string[] cmd = new string[] { "ping 192.168.3.15 -n 1", "ping 192.168.3.16 -n 2" };
        /// MessageBox.Show(Cmd(cmd));
        /// 
        /// </summary>
        /// <param name="cmd">命令</param>
        /// <returns>如果运行成功则返回0，否则非0</returns>
        public static int RunCmd(string[] cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.AutoFlush = true;

            for (int i = 0; i < cmd.Length; i++)
            {
                p.StandardInput.WriteLine(cmd[i].ToString());
            }
            p.StandardInput.WriteLine("exit");
            p.StandardInput.Flush();
            p.StandardInput.Close();

            int retCode = -1;
            bool isExit = false;
            try
            {
                isExit = p.WaitForExit(300);
                retCode = p.ExitCode;  // n 为进程执行返回值 
                if (retCode == 1190)//已经执行了任务计划
                {
                    retCode = 0;
                }
                p.Close();
                if (isExit == false)
                {
                    isExit = p.CloseMainWindow();
                }
            }
            catch
            {
                retCode = -2;
            }
            try
            {
                if (isExit == false)
                {
                    p.Kill();
                }
            }
            catch
            {
            }
            return retCode;
        }

        /// <summary>
        /// 获取本机IP
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            try
            {
                string HostName = Dns.GetHostName(); //得到主机名
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
                //MessageBox.Show("获取本机IP出错:" + ex.Message);
                return "";
            }
        }

        /// <summary>
        /// 判断指定进程是否正在运行
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static int GetPidByProcessName(string processName)
        {
            Process[] arrayProcess = Process.GetProcessesByName(processName);

            foreach (Process p in arrayProcess)
            {
                return p.Id;
            }
            return 0;
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName">进程名</param>
        public static void KillProcess(string processName)
        {
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                if (item.ProcessName == processName)
                {
                    item.Kill();
                }
            }
        }

        /// <summary>
        /// 打开文件夹
        /// </summary>
        /// <param name="dir"></param>
        /// 返回错误消息
        public static string OpenDirectory(string dir)
        {
            string errMsg = "";
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", dir);
            }
            catch (System.Exception ex)
            {
                errMsg = ex.Message;
            }
            return errMsg;
        }

        public static void CopyDirectory(string srcDir, string tgtDir)
        {
            DirectoryInfo source = new DirectoryInfo(srcDir);
            DirectoryInfo target = new DirectoryInfo(tgtDir);

            if (target.FullName.StartsWith(source.FullName, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("父目录不能拷贝到子目录！");
            }

            if (!source.Exists)
            {
                return;
            }

            if (!target.Exists)
            {
                target.Create();
            }

            FileInfo[] files = source.GetFiles();

            for (int i = 0; i < files.Length; i++)
            {
                File.Copy(files[i].FullName, target.FullName + @"\" + files[i].Name, true);
            }

            DirectoryInfo[] dirs = source.GetDirectories();

            for (int j = 0; j < dirs.Length; j++)
            {
                CopyDirectory(dirs[j].FullName, target.FullName + @"\" + dirs[j].Name);
            }
        }

        static public ComputerNetInfo[] GetOnlineComputerNetInfo()
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
                    com._strMac = getMacAddressbyIPAddress(com._strIp);
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

        static public string getIPbyComputerName(string computerName)
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
        /// 判断计算机是否开机
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public static bool IsComputerPowerOn(string IP)
        {
            
            Ping p = new Ping();
            
            PingReply receive = null;

            try
            {
                receive = p.Send(IP);
            }
            catch (Exception e)
            {
                return false;
            }

            if (receive.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public string getMacAddressbyIPAddress(string IPAddress)
        {
            string Mac = null;
            try
            {
                Int32 ldest = inet_addr(IPAddress); //将IP地址从 点数格式转换成无符号长整型
                Int64 macinfo = new Int64();
                Int32 len = 6;
                SendARP(ldest, 0, ref macinfo, ref len);
                string TmpMac = Convert.ToString(macinfo, 16).PadLeft(12, '0');//转换成16进制　　注意有些没有十二位
                Mac = TmpMac.Substring(0, 2).ToUpper();//
                for (int i = 2; i < TmpMac.Length; i = i + 2)
                {
                    Mac = TmpMac.Substring(i, 2).ToUpper() + "-" + Mac;
                }
            }
            catch (Exception Mye)
            {
                Mac = "获取远程主机的MAC错误：" + Mye.Message;
            }
            return Mac;
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

        // add by wuxin at 2020/1/7 - start
        /// <summary>
        /// 数字转中文
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string NumberToChinese(int number)
        {
            string ret = null;
            int input2 = Math.Abs(number);
            string resource = "零一二三四五六七八九";
            string unit = "个十百千万亿兆京垓秭穰沟涧正载极";

            if (number > Math.Pow(10, 4 * (unit.Length - unit.IndexOf('万'))))
            {
                throw new Exception("the input is too big,input:" + number);
            }

            Func<int, List<List<int>>> splitNumFunc = (val) =>
            {
                int i = 0;
                int mod;
                int val_ = val;
                List<List<int>> splits = new List<List<int>>();
                List<int> splitNums;
                do
                {
                    mod = val_ % 10;
                    val_ /= 10;
                    if (i % 4 == 0)
                    {
                        splitNums = new List<int>();
                        splitNums.Add(mod);
                        if (splits.Count == 0)
                        {
                            splits.Add(splitNums);
                        }
                        else
                        {
                            splits.Insert(0, splitNums);
                        }
                    }
                    else
                    {
                        splitNums = splits[0];
                        splitNums.Insert(0, mod);
                    }
                    i++;
                } while (val_ > 0);
                return splits;
            };

            Func<List<List<int>>, string> hommizationFunc = (data) =>
            {
                List<StringBuilder> builders = new List<StringBuilder>();
                for (int i = 0; i < data.Count; i++)
                {
                    List<int> data2 = data[i];
                    StringBuilder newVal = new StringBuilder();
                    for (int j = 0; j < data2.Count;)
                    {
                        if (data2[j] == 0)
                        {
                            int k = j + 1;
                            for (; k < data2.Count && data2[k] == 0; k++) ;
                            //个位不是0，前面补一个零
                            newVal.Append('零');
                            j = k;
                        }
                        else
                        {
                            newVal.Append(resource[data2[j]]).Append(unit[data2.Count - 1 - j]);
                            j++;
                        }
                    }

                    if (newVal[newVal.Length - 1] == '零' && newVal.Length > 1)
                    {
                        newVal.Remove(newVal.Length - 1, 1);
                    }
                    else if (newVal[newVal.Length - 1] == '个')
                    {
                        newVal.Remove(newVal.Length - 1, 1);
                    }

                    if (i == 0 && newVal.Length > 1 && newVal[0] == '一' && newVal[1] == '十')
                    {//一十 --> 十
                        newVal.Remove(0, 1);
                    }

                    builders.Add(newVal);
                }

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < builders.Count; i++)
                {
                    //拼接
                    if (builders.Count == 1)
                    {
                        //个位数
                        sb.Append(builders[i]);
                    }
                    else
                    {
                        if (i == builders.Count - 1)
                        {
                            //万位以下的
                            if (builders[i][builders[i].Length - 1] != '零')
                            {
                                //十位以上的不拼接"零"
                                sb.Append(builders[i]);
                            }
                        }
                        else
                        {
                            //万位以上的
                            if (builders[i][0] != '零')
                            {
                                //零万零亿之类的不拼接
                                sb.Append(builders[i]).Append(unit[unit.IndexOf('千') + builders.Count - 1 - i]);
                            }
                        }
                    }
                }
                return sb.ToString();
            };

            List<List<int>> ret_split = splitNumFunc(input2);
            ret = hommizationFunc(ret_split);
            if (number < 0) ret = "-" + ret;

            return ret;

        }

        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

        // add by wuxin at 2020/1/7 - end

        ///// <summary> 
        ///// 用来判断一个指定的程序是否正在运行
        ///// </summary> 
        ///// <param name="appId">程序名称,长一点比较好,防止有重复</param> 
        ///// <returns>如果程序是第一次运行返回True,否则返回False</returns>
        //public static bool IsFirst(string appId)
        //{
        //    bool ret = false;
        //    if (OpenMutex(0x1F0001, 0, appId) == IntPtr.Zero)
        //    {
        //        CreateMutex(IntPtr.Zero, 0, appId);
        //        ret = true;
        //    }
        //    return ret;
        //}

        ///// <summary>
        ///// 尝试调用指定的进程，返回句柄
        ///// </summary>
        ///// <param name="dwDesiredAccess">access</param>
        ///// <param name="bInheritHandle">inheritance option</param>
        ///// <param name="lpName">object name</param>
        ///// <returns>相应的句柄</returns>
        //[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        //private static extern IntPtr OpenMutex(
        // uint dwDesiredAccess,
        // int bInheritHandle,
        // string lpName
        // );

        ///// <summary>
        ///// 创建进程，返回相应的句柄
        ///// </summary>
        ///// <param name="lpMutexAttributes">SD</param>
        ///// <param name="bInitialOwner">initial owner</param>
        ///// <param name="lpName">object name</param>
        ///// <returns>相应的句柄</returns>
        //[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        //private static extern IntPtr CreateMutex(
        // IntPtr lpMutexAttributes,
        // int bInitialOwner,
        // string lpName
        // );
    }
}
