using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class SystemHelper
{
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
    /// 启动外部应用程序 设置窗体
    /// </summary>
    /// <param name="appPath"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public static Process StartExternalProcess(string appPath, ProcessWindowStyle style)
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

    /// <summary>
    /// 启动外部应用程序 带参数
    /// </summary>
    /// <param name="appPath"></param>
    /// <param name="arguments"></param>
    /// <returns></returns>
    public static Process StartExternalProcess(string appPath, string arguments)
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
    /// 关闭应用程序
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
    /// 关闭外部进程
    /// </summary>
    /// <param name="proc"></param>
    public static void CloseExternalProcess(Process proc)
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


    /// <summary>
    /// 设置开机自动运行
    /// </summary>
    /// <param name="executablePath">Application.ExecutablePath</param>
    /// <param name="isAutoRun">是否开机自动运行</param>
    public static void SetAutoRun(string executablePath, bool isAutoRun)
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
}

