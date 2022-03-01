using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using UserEventData;

namespace cc_clinet
{
    /// <summary>
    /// 获取文件属性
    /// </summary>
    public class GetContentInfoHandler : IEventHandler<R_C_GetContentInfoData>
    {
        public void HandleEvent(R_C_GetContentInfoData eventData)
        {

            C_GetContentInfoData sendData = new C_GetContentInfoData();

            try
            {
                sendData.InfoList = new List<B_TextInfoData>();
                Content content = new Content(eventData.ContentPath);
                switch (content.Type)
                {
                    case Content.TYPE_NOT_FOUND:
                        throw new KnownException("路径 " + content.Path + " 代表的不是一个驱动器、文件或目录，无法获取信息。");
                    case Content.TYPE_DRIVER:
                        DriveInfo driveInfo = new DriveInfo(content.Path);
                        sendData.InfoList.Add(new B_TextInfoData("AvailableFreeSpace", driveInfo.AvailableFreeSpace.ToString() + " Bytes"));
                        sendData.InfoList.Add(new B_TextInfoData("AvailableFreDriveFormateSpace", driveInfo.DriveFormat.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("DriveType", driveInfo.DriveType.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("IsReady", driveInfo.IsReady.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Name", driveInfo.Name.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("RootDirectory", driveInfo.RootDirectory.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("TotalFreeSpace", driveInfo.TotalFreeSpace.ToString() + " Bytes"));
                        sendData.InfoList.Add(new B_TextInfoData("TotalSize", driveInfo.TotalSize.ToString() + " Bytes"));
                        sendData.InfoList.Add(new B_TextInfoData("VolumeLabel", driveInfo.VolumeLabel.ToString()));
                        break;
                    case Content.TYPE_FILE:
                        FileInfo fileInfo = new FileInfo(content.Path);
                        sendData.InfoList.Add(new B_TextInfoData("Attributes", fileInfo.Attributes.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("CreationTime", fileInfo.CreationTime.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("CreationTimeUtc", fileInfo.CreationTimeUtc.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Directory", fileInfo.Directory.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("DirectoryName", fileInfo.DirectoryName.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Exists", fileInfo.Exists.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Extension", fileInfo.Extension.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("FullName", fileInfo.FullName.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("IsReadOnly", fileInfo.IsReadOnly.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("LastAccessTime", fileInfo.LastAccessTime.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("LastAccessTime", fileInfo.LastAccessTimeUtc.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("LastWriteTime", fileInfo.LastWriteTime.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("LastWriteTimeUtc", fileInfo.LastWriteTimeUtc.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Length", FileProcess.ConverSizeToLarge(fileInfo.Length)));
                        sendData.InfoList.Add(new B_TextInfoData("Name", fileInfo.Name.ToString()));
                        break;
                    case Content.TYPE_DIRECTORY:
                        DirectoryInfo directoryInfo = new DirectoryInfo(content.Path);
                        sendData.InfoList.Add(new B_TextInfoData("Attributes", directoryInfo.Attributes.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("CreationTime", directoryInfo.CreationTime.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("CreationTimeUtc", directoryInfo.CreationTimeUtc.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Exists", directoryInfo.Exists.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Extension", directoryInfo.Extension.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("FullName", directoryInfo.FullName.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("LastAccessTime", directoryInfo.LastAccessTime.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("LastAccessTime", directoryInfo.LastAccessTimeUtc.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("LastWriteTime", directoryInfo.LastWriteTime.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("LastWriteTimeUtc", directoryInfo.LastWriteTimeUtc.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Name", directoryInfo.Name.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Parent", directoryInfo.Parent.FullName.ToString()));
                        sendData.InfoList.Add(new B_TextInfoData("Root", directoryInfo.Root.ToString()));
                        long length = 0;
                        FileProcess.GetFilesLenInFolderRescusively(directoryInfo.GetDirectories(), directoryInfo.GetFiles(),ref length);
                        sendData.InfoList.Add(new B_TextInfoData("Length", FileProcess.ConverSizeToLarge(length)));
                        break;
                }


            }
            catch (Exception e)
            {
                sendData.ErorrOccured = true;
                sendData.ErrorMessage = e.Message;

            }


            RabbitMQEventBus.GetSingleton().Trigger<C_GetContentInfoData>(eventData.fromIp, sendData);//直接通过事件总线触发
        }
    }
}
