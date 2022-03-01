using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using LibNvDriverSetting;
using LibUtilitiesNameSpace;
using UserEventData;
using Utilities;

namespace cc_clinet
{
    /// <summary>
    /// 获取客户端文件信息
    /// </summary>
    public class FileInfoHandler : IEventHandler<R_C_FileInfoData>
    {
        public void HandleEvent(R_C_FileInfoData eventData)
        {
            C_FileInfoData sendData = new C_FileInfoData();

            sendData.nodeName = eventData.nodeName;
            sendData.driveInfoList = new List<DriveInfo>();
            sendData.fileInfoList = new List<FileInfo>();
            sendData.directoryInfoList = new List<DirectoryInfo>();

            if (eventData.nodeName == "MyComputer")
            {
                // 获取磁盘信息
                foreach (string drive in Environment.GetLogicalDrives())
                {
                    //实例化DriveInfo对象 命名空间System.IO
                    var dir = new DriveInfo(drive);
                    switch (dir.DriveType)           //判断驱动器类型
                    {
                        case DriveType.Fixed:        //仅取固定磁盘盘符 Removable-U盘
                        {
                            sendData.driveInfoList.Add(dir);

                        }
                            break;
                    }
                }
            }
            else
            {
                // 获取文件夹信息
                DirectoryInfo directory = new DirectoryInfo(eventData.nodeName);

                try//为什么要加try catch呢因为在C盘有些文件夹是拒绝我访问的，不加trycatch会报错,当然也会忽略我无法访问的文件而已  
                {

                    foreach (FileSystemInfo fsinfo in directory.GetFileSystemInfos())//得到当前文件夹中的所有文件夹与文件   directory对象有三种获得其内容的方法
                    {
                        if (fsinfo is FileInfo)
                        {
                            sendData.fileInfoList.Add(fsinfo as FileInfo);
                        }
                        else if (fsinfo is DirectoryInfo)
                        {
                            sendData.directoryInfoList.Add(fsinfo as DirectoryInfo);
                        }

                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            RabbitMQEventBus.GetSingleton().Trigger<C_FileInfoData>(sendData);//直接通过事件总线触

        }
    }
}
