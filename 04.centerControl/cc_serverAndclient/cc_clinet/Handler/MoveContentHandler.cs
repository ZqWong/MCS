using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using NvAPIWrapper;
using NvAPIWrapper.GPU;
using UserEventData;
using Utilities;

namespace cc_clinet
{
    /// <summary>
    /// 处理服务端发送的剪切或者复制文件的指令
    /// 如果客户端指令执行发生异常或者错误，传递回服务端
    /// </summary>
    public class MoveContentHandler : IEventHandler<R_C_MoveContentData>
    {
        private void CopyFile(Content content, Content containerContent)
        {
            string copiedFilePath = FileProcess.GetCopiedFilePath(content.Path, containerContent.Path);
            Content copiedFileContent = new Content(copiedFilePath);
            if (copiedFileContent.Type != Content.TYPE_NOT_FOUND)
            {
                throw new KnownException("容器中已经存在同名文件或目录，不能复制到此容器中。");
            }
            File.Copy(content.Path, copiedFilePath);
        }

        private void CopyDirectory(Content content, Content containerContent)
        {
            string copiedDirectoryPath = FileProcess.GetCopiedDirectoryPath(content.Path, containerContent.Path);
            Content copiedDirectoryContent = new Content(copiedDirectoryPath);
            if (copiedDirectoryContent.Type != Content.TYPE_NOT_FOUND)
            {
                throw new KnownException("容器中已经存在同名文件或目录，不能复制到此容器中。");
            }
            Directory.CreateDirectory(copiedDirectoryPath);
            string[] files = Directory.GetFiles(content.Path);
            foreach (string file in files)
            {
                Content fileContent = new Content(file);
                CopyFile(fileContent, copiedDirectoryContent);
            }
            string[] directories = Directory.GetDirectories(content.Path);
            foreach (string directory in directories)
            {
                Content directoryContent = new Content(directory);
                CopyDirectory(directoryContent, copiedDirectoryContent);
            }
        }

        public void HandleEvent(R_C_MoveContentData eventData)
        {
            Content containerContent = new Content(eventData.Container);

            C_MoveContentData sendData = new C_MoveContentData();
            sendData.ParseType = eventData.PasteType;

            try
            {
                switch (containerContent.Type)
                {
                    case Content.TYPE_NOT_FOUND:
                        throw new KnownException("找不到路径 " + containerContent.Path + " 所代表的容器。");
                    case Content.TYPE_FILE:
                        throw new KnownException("路径 " + containerContent.Path + " 代表的是一个文件，不能作为容器。");
                }
                sendData.MoveResults = new string[eventData.ContentPaths.Count];
                for (int i = 0; i < eventData.ContentPaths.Count; i++)
                {
                    Content content = new Content(eventData.ContentPaths[i]);
                    try
                    {
                        switch (content.Type)
                        {
                            case Content.TYPE_NOT_FOUND:
                                throw new KnownException("找不到此路径所代表的内容。");
                            case Content.TYPE_DRIVER:
                                throw new KnownException("此路径所代表的是一个驱动器，不能被移动。");
                            case Content.TYPE_FILE:
                                if (eventData.PasteType == "Cut")
                                {
                                    if (FileProcess.IsInTheSameDriver(content.Path, containerContent.Path) == false)
                                    {
                                        throw new KnownException("无法在不同的驱动器之间移动文件，可以先复制后删除。");
                                    }
                                    string movedFilePath = FileProcess.GetMovedFilePath(content.Path, containerContent.Path);
                                    if (new Content(movedFilePath).Type != Content.TYPE_NOT_FOUND)
                                    {
                                        throw new KnownException("容器中已经存在同名文件或目录，不能移动到此容器中。");
                                    }
                                    File.Move(content.Path, movedFilePath);
                                }
                                else if (eventData.PasteType == "Copy")
                                {
                                    CopyFile(content, containerContent);
                                }
                                break;
                            case Content.TYPE_DIRECTORY:
                                if (eventData.PasteType == "Cut")
                                {
                                    if (FileProcess.IsInTheSameDriver(content.Path, containerContent.Path) == false)
                                    {
                                        throw new KnownException("无法在不同的驱动器之间移动目录，可以先复制后删除。");
                                    }
                                    string movedDirectoryPath = FileProcess.GetMovedDirectoryPath(content.Path, containerContent.Path);
                                    if (new Content(movedDirectoryPath).Type != Content.TYPE_NOT_FOUND)
                                    {
                                        throw new KnownException("容器中已经存在同名文件或目录，不能移动到此容器中。");
                                    }
                                    Directory.Move(content.Path, movedDirectoryPath);
                                }
                                else if (eventData.PasteType == "Copy")
                                {
                                    CopyDirectory(content, containerContent);
                                }
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        sendData.MoveResults[i] = content.Path + " " + e.Message;
                    }
                }
            }
            catch (Exception e)
            {
                sendData.ErorrOccured = true;
                sendData.ErrorMessage = e.Message;
            }


            RabbitMQEventBus.GetSingleton().Trigger<C_MoveContentData>(eventData.fromIp, sendData);//直接通过事件总线触发
        }
    }
}
