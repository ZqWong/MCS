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
    /// 客户端发送信息
    /// </summary>
    public class SendFileHandler : IEventHandler<R_C_GetFileData>
    {
        // 文件list
        List<string> fileList = new List<string>();
        // 所有要发送文件的大小
        private long totalSize;
        // 当前发送文件的大小（所有）
        private long allReadySendSize;

        public void HandleEvent(R_C_GetFileData eventData)
        {
            string sourPath = eventData.sourcePath;
            string destPath = eventData.destPath;

            totalSize = 0;
            allReadySendSize = 0;

            fileList.Clear();

            if (File.Exists(sourPath))
            {
                // 是文件
                FileInfo fif = new FileInfo(sourPath); 
                fileList.Add(fif.FullName);

            }
            else if (Directory.Exists(sourPath))
            {
                // 是文件夹
                SendFiles.GetSingleton().GetAllFiles(fileList, new System.IO.DirectoryInfo(sourPath));

            }
            else
            {
                // 没有
                return;
            }

            totalSize = SendFiles.GetSingleton().GetAllFileLength(fileList);

            foreach (string filePath in fileList)
            {
                // 增加相对路径，为本机ip与路径的组合
                string relative_path = string.Format(@"\{0}", GetLocalIp.GetSingleton().GetIP()) + filePath.Substring(sourPath.LastIndexOf(@"\"),
                    filePath.LastIndexOf(@"\") - sourPath.LastIndexOf(@"\"));

                var sendData = new C_FileData();
                sendData.totalSize = totalSize;
                sendData.alreadySendSize = allReadySendSize;

                SendFiles.GetSingleton().SendFile(filePath, destPath + relative_path, _sendTrigger, sendData);

                allReadySendSize = sendData.alreadySendSize;
            }
        }

        void _sendTrigger(string ip, C_FileData _sendData)
        {
            if (ip == "")
            {
                RabbitMQEventBus.GetSingleton().Trigger<C_FileData>(_sendData);//直接通过事件总线触
            }
            else
            {
                RabbitMQEventBus.GetSingleton().Trigger<C_FileData>(ip, _sendData);//直接通过事件总线触
            }
            
        }
    }
}
