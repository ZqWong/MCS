using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;


public static class LocalInfoHelper
{

    public static string GetCpuID()
    {
        try
        {
            //获取CPU序列号代码
            string cpuInfo = "";//cpu序列号
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
            }
            moc = null;
            mc = null;
            return cpuInfo;
        }
        catch
        {
            return "unknow";
        }
        finally
        {
        }

    }
    public static string GetMacAddress()
    {
        try
        {
            //获取网卡硬件地址
            string mac = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    mac = mo["MacAddress"].ToString();
                    break;
                }
            }
            moc = null;
            mc = null;
            return mac;
        }
        catch
        {
            return "unknow";
        }
        finally
        {
        }

    }
    public static string GetIPAddress()
    {
        try
        {
            //获取IP地址
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    //st=mo["IpAddress"].ToString();
                    System.Array ar;
                    ar = (System.Array)(mo.Properties["IpAddress"].Value);
                    st = ar.GetValue(0).ToString();
                    break;
                }
            }
            moc = null;
            mc = null;
            return st;
        }
        catch
        {
            return "unknow";
        }
        finally
        {
        }

    }

    public static string GetDiskID()
    {
        try
        {
            //获取硬盘ID
            String HDid = "";
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                HDid = (string)mo.Properties["Model"].Value;
            }
            moc = null;
            mc = null;
            return HDid;
        }
        catch
        {
            return "unknow";
        }
        finally
        {
        }

    }

    /// <summary>
    /// 操作系统的登录用户名
    /// </summary>
    /// <returns></returns>
    public static string GetUserName()
    {
        try
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {

                st = mo["UserName"].ToString();

            }
            moc = null;
            mc = null;
            return st;
        }
        catch
        {
            return "unknow";
        }
        finally
        {
        }

    }


    /// <summary>
    /// PC类型
    /// </summary>
    /// <returns></returns>
    public static string GetSystemType()
    {
        try
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {

                st = mo["SystemType"].ToString();

            }
            moc = null;
            mc = null;
            return st;
        }
        catch
        {
            return "unknow";
        }
        finally
        {
        }

    }

    /// <summary>
    /// 物理内存
    /// </summary>
    /// <returns></returns>
    public static string GetTotalPhysicalMemory()
    {
        try
        {

            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {

                st = mo["TotalPhysicalMemory"].ToString();

            }
            moc = null;
            mc = null;
            return st;
        }
        catch
        {
            return "unknow";
        }
        finally
        {
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static string GetComputerName()
    {
        try
        {
            return System.Environment.GetEnvironmentVariable("ComputerName");
        }
        catch
        {
            return "unknow";
        }
        finally
        {
        }
    }


    //
    // 取得设备硬盘的卷标号 此方法为取硬盘逻辑分区序列号，重新格式化会改变
    public static string GetDiskVolumeSerialNumber()
    {
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
        disk.Get();
        return disk.GetPropertyValue("VolumeSerialNumber").ToString();
    }



    // 取得设备硬盘的物理序列号    
    public static string GetDiskSerialNumber()
    {
        ManagementObjectSearcher mos = new ManagementObjectSearcher();
        mos.Query = new SelectQuery("Win32_DiskDrive", "", new string[] { "PNPDeviceID", "Signature" });
        ManagementObjectCollection myCollection = mos.Get();
        ManagementObjectCollection.ManagementObjectEnumerator em = myCollection.GetEnumerator();
        em.MoveNext();
        ManagementBaseObject moo = em.Current;
        string id = moo.Properties["signature"].Value.ToString().Trim();
        return id;
    }



    public static List<string> GetRemovableDeviceID()
    {
        List<string> deviceIDs = new List<string>();
        ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT  *  From  Win32_LogicalDisk ");
        ManagementObjectCollection queryCollection = query.Get();
        foreach (ManagementObject mo in queryCollection)
        {

            switch (int.Parse(mo["DriveType"].ToString()))
            {
                case (int)DriveType.Removable:   //可以移动磁盘       
                    {
                        //MessageBox.Show("可以移动磁盘");  
                        deviceIDs.Add(mo["DeviceID"].ToString());
                        break;
                    }
                case (int)DriveType.Fixed:   //本地磁盘       
                    {
                        //MessageBox.Show("本地磁盘");  
                        deviceIDs.Add(mo["DeviceID"].ToString());
                        break;
                    }
                case (int)DriveType.CDRom:   //CD   rom   drives       
                    {
                        //MessageBox.Show("CD   rom   drives ");  
                        break;
                    }
                case (int)DriveType.Network:   //网络驱动     
                    {
                        //MessageBox.Show("网络驱动器 ");  
                        break;
                    }
                case (int)DriveType.Ram:
                    {
                        //MessageBox.Show("驱动器是一个 RAM 磁盘 ");  
                        break;
                    }
                case (int)DriveType.NoRootDirectory:
                    {
                        //MessageBox.Show("驱动器没有根目录 ");  
                        break;
                    }
                default:   //defalut   to   folder       
                    {
                        //MessageBox.Show("驱动器类型未知 ");  
                        break;
                    }
            }

        }
        return deviceIDs;
    }


    ////获取当前计算机逻辑磁盘名称列表
    //String[] drives = Environment.GetLogicalDrives();
    //    //Console.WriteLine("GetLogicalDrives: {0}", String.Join(", ", drives));
 

}

