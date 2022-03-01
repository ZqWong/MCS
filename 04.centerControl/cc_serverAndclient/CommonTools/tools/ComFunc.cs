using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DW_CC_NET.tools
{
    public class ComFunc : Singleton<ComFunc>
    {
        public string GetMainModuleFilepath(int processId)
        {
            string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                    if (mo != null)
                    {
                        return (string)mo["ExecutablePath"];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 删除文件夹（及文件夹下所有子文件夹和文件）
        /// </summary>
        /// <param name="directoryPath"></param>
        public void DeleteFolder(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                return;
            }


            foreach (string d in Directory.GetFileSystemEntries(directoryPath))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);     //删除文件   
                }
                else
                    DeleteFolder(d);    //删除文件夹
            }
            Directory.Delete(directoryPath);    //删除空文件夹
        }

        /// <summary>
        /// 删除文件夹,除了某个文件夹
        /// </summary>
        /// <param name="directoryPath"></param>
        public void DeleteFolder(string directoryPath, List<string> exceptPathList)
        {
            if (!Directory.Exists(directoryPath))
            {
                return;
            }

            if (exceptPathList.Contains(directoryPath))
            {
                return;
            }


            foreach (string d in Directory.GetFileSystemEntries(directoryPath))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    try
                    {
                        File.Delete(d);     //删除文件  
                    }
                    catch (Exception e)
                    {
                        NlogHandler.GetSingleton().Info(string.Format("删除文件 {0} 失败. error {1}",d,e.Message.ToString()));
                    }
                     
                }
                else
                    DeleteFolder(d, exceptPathList);    //删除文件夹
            }

            try
            {
                Directory.Delete(directoryPath);    //删除空文件夹，获取删除非空文件夹的异常
            }
            catch (Exception e)
            {

            }

        }

        // 复制文件夹
        public void directoryCopy(string sourceDirectory, string targetDirectory)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirectory);
                //获取目录下（不包含子目录）的文件和子目录
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {
                        if (!Directory.Exists(targetDirectory + "\\" + i.Name))
                        {
                            //目标目录下不存在此文件夹即创建子文件夹
                            Directory.CreateDirectory(targetDirectory + "\\" + i.Name);
                        }
                        //递归调用复制子文件夹
                        directoryCopy(i.FullName, targetDirectory + "\\" + i.Name);
                    }
                    else
                    {
                        //不是文件夹即复制文件，true表示可以覆盖同名文件
                        File.Copy(i.FullName, targetDirectory + "\\" + i.Name, true);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 获取输入路径的父目录
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public string GetParentPath(string fullName)
        {
            string parentPath;

            if (File.Exists(fullName))
            {
                // 是文件
                parentPath = Path.GetDirectoryName(fullName);
            }

            else if (Directory.Exists(fullName))
            {
                // 是文件夹
                parentPath = Path.GetDirectoryName(fullName + @"\");
            }

            else
            {
                // 都不是
                parentPath = "";
            }

            return parentPath;
        }

        /// <summary>
        /// 获取输入路径的父文件夹名称
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public string GetParentFolderName(string fullName)
        {
            string parentPath;

            if (File.Exists(fullName))
            {
                // 是文件
                DirectoryInfo info = new DirectoryInfo(GetParentPath(fullName));
                return info.Parent.Name;
            }

            else if (Directory.Exists(fullName))
            {
                // 是文件夹
                DirectoryInfo info = new DirectoryInfo(fullName);
                return info.Parent.Name;
            }

            else
            {
                // 都不是
                parentPath = "";
            }

            return parentPath;
        }

        /// <summary>
        /// 根据输入的路径获取执行文件的名字
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public string GetName(string fullName)
        {
            if (File.Exists(fullName))
            {
                // 是文件
                return Path.GetFileName(fullName);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取文件夹大小
        /// </summary>
        /// <param name="dirs"></param>
        /// <param name="fileInfos"></param>
        /// <param name="retLen"></param>
        public void GetFilesLenInFolderRescusively(DirectoryInfo[] dirs, FileInfo[] fileInfos, ref long retLen)
        {
            int nFiles = fileInfos.Length;
            for (int i = 0; i < nFiles; i++)
            {
                retLen += fileInfos[i].Length;
            }

            int nFolders = dirs.Length;
            for (int i = 0; i < nFolders; i++)
            {
                DirectoryInfo[] subDirs = dirs[i].GetDirectories();
                FileInfo[] subFileInfos = dirs[i].GetFiles();
                GetFilesLenInFolderRescusively(subDirs, subFileInfos, ref retLen);
            }
        }


    }
}
