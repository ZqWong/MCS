using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserEventData;

namespace DW_CC_NET.tools
{
    /// <summary>
    /// 这个类因为引用了自定义的usereventData数据类型来发送数据，所以不具有commontool的普世性。
    /// 仅仅是针对当前项目的优化和抽象
    /// </summary>
    public class SendFiles : Singleton<SendFiles>
    {
        public void SendFile<TEventData>(string sourPath, string destPath, Action<string, TEventData> sendTrigger, TEventData sendData, string ip="") where TEventData : R_C_FileData
        {

            sendData.fileMD5 = GetFileMD5Hash.GetSingleton().GetMD5HashFromFile(sourPath);

            //创建一个文件对象
            FileInfo EzoneFile = new FileInfo(sourPath);
            //打开文件流
            FileStream EzoneStream = EzoneFile.OpenRead();

            //包的大小524288
            int PacketSize = 1048576;

            //包的数量
            int PacketCount = (int)(EzoneStream.Length / ((long)PacketSize));

            //最后一个包的大小
            int LastDataPacket = (int)(EzoneStream.Length - ((long)(PacketSize * PacketCount)));

            if (LastDataPacket > 0)
            {
                PacketCount += 1;
            }

            string[] name = sourPath.Split('\\'); // 一定是单引 

            sendData.destPath = destPath;
            sendData.name = name[name.Length - 1];
            sendData.totalCount = PacketCount;

            bool isCut = false;
            //数据包
            byte[] data = new byte[PacketSize];

            //开始循环发送数据包
            for (int i = 0; i < PacketCount - 1; i++)
            {
                //从文件流读取数据并填充数据包
                EzoneStream.Read(data, 0, data.Length);
                sendData.FileData = data;
                //发送数据包

                sendData.currentCount = i + 1;

                sendData.alreadySendSize += sendData.FileData.Length;

                
                sendTrigger(ip, sendData);
            }

            //如果还有多余的数据包，则应该发送完毕！
            if (LastDataPacket != 0)
            {
                data = new byte[LastDataPacket];
                EzoneStream.Read(data, 0, data.Length);
                sendData.FileData = data;

                sendData.currentCount = PacketCount;

                sendData.alreadySendSize += sendData.FileData.Length;

                sendTrigger(ip, sendData);

                EzoneStream.Close();

            }
        }


        /// <summary>
            /// 递归获取文件夹下所有文件的fullName.
            /// </summary>
            /// <param name="dir"></param>
            /// <returns></returns>
            public List<string> GetAllFiles(List<string> FileList, DirectoryInfo dir)
        {

            FileInfo[] allFile = dir.GetFiles();
            foreach (FileInfo fi in allFile)
            {
                FileList.Add(fi.FullName);
            }

            DirectoryInfo[] allDir = dir.GetDirectories();
            foreach (DirectoryInfo d in allDir)
            {
                GetAllFiles(FileList, d);
            }

            return FileList;
        }

        /// <summary>
        /// 获取所有文件的长度
        /// </summary>
        /// <returns></returns>
        public long GetAllFileLength(List<string> fileList)
        {
            long retLen = 0;

            int nFiles = fileList.Count;
            for (int i = 0; i < nFiles; i++)
            {
                FileInfo fileInfo = new FileInfo(fileList[i]);
                retLen += fileInfo.Length;
            }

            return retLen;
        }

    }
}
