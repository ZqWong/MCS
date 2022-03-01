using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace LibUtilitiesNameSpace
{
    public class LibUtilities
    {
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
                String name = executablePath.Substring(executablePath.LastIndexOf(@"\") + 1);
                string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                reg = Registry.LocalMachine.OpenSubKey(subkey, true);
                if (reg == null)
                    reg = Registry.LocalMachine.CreateSubKey(subkey);
                if (isAutoRun)
                    reg.SetValue(name, executablePath);
                else
                    reg.SetValue(name, false);
            }
            catch
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
                String name = executablePath.Substring(executablePath.LastIndexOf(@"\") + 1);
                string subkey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                reg = Registry.LocalMachine.OpenSubKey(subkey, true);
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
    }
}
