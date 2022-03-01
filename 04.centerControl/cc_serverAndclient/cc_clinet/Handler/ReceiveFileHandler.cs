using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using UserEventData;
using Utilities;

namespace cc_clinet
{
    /// <summary>
    /// 接收文件、传输事件处理
    /// </summary>
    public class ReceiveFileHandler : IEventHandler<R_C_FileData>
    {
        private static Dictionary<string, FileStream>  _myFileStreamDict = new Dictionary<string, FileStream>();
        private static FileStream _currentFile = null;
        private static object _mylock = new Object();

        private string _fullPath = "";

        public void HandleEvent(R_C_FileData eventData)
        {
            try
            {
                lock (_mylock)
                {
                    Console.WriteLine("CurrentCount is {0}, TotalCount is {1}", eventData.currentCount, eventData.totalCount);

                    _fullPath = Path.Combine(eventData.destPath, eventData.name);

                    if (_myFileStreamDict.TryGetValue(_fullPath, out _currentFile))
                    {

                    }
                    else
                    {

                        FileInfo fi = new FileInfo(_fullPath);
                        var di = fi.Directory;
                        if (!di.Exists)
                            di.Create();

                        //创建一个新文件 
                        _currentFile = new FileStream(_fullPath, FileMode.Create, FileAccess.Write);
                        //_myFileStreamDict.Add(_currentFile.Name, _currentFile);
                        _myFileStreamDict.Add(_fullPath, _currentFile);

                        NlogHandler.GetSingleton().Info(string.Format("文件 {0} 开始传输, _currentFile.Name {1}", eventData.name, _currentFile.Name));

                    }

                    //将接收到的数据包写入到文件流对象   
                    _currentFile.Write(eventData.FileData, 0, eventData.FileData.Length);

                    if (eventData.totalCount > 20)
                    {
                        if (eventData.currentCount % (eventData.totalCount / 20) == 0)
                        {
                            int _receive_ratio = (int)((100.0f) * eventData.currentCount / eventData.totalCount);

                            if (_receive_ratio < 100)
                                ReplyToServer(_receive_ratio, "", eventData.fileMD5, eventData.name, eventData.totalSize, eventData.alreadySendSize);
                        }
                    }

                    if (eventData.currentCount == eventData.totalCount)
                    {
                        NlogHandler.GetSingleton().Info(string.Format("文件 {0} 准备关闭文件流", eventData.name));
                        //关闭文件流   
                        _currentFile.Close();
                        ReplyToServer(100, _fullPath, eventData.fileMD5, eventData.name, eventData.totalSize, eventData.alreadySendSize);
                        _myFileStreamDict.Remove(_fullPath);
                        _currentFile = null;

                        NlogHandler.GetSingleton().Info(string.Format("文件 {0} 传输完成，成功关闭文件流", eventData.name));
                    }
                }
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Info(string.Format("文件传输异常  ： {0}", e.Message.ToString()));
            }

        }

        private void ReplyToServer(int receive_ratio, string filePathName, string fileMD5 , string name, long totalSize, long alreadySendSize)
        {
            var sendData = new C_ReplyFileData();
            sendData.receive_ratio = receive_ratio;
            sendData.fileName = name;
            sendData.totalSize = totalSize;
            sendData.alreadySendSize = alreadySendSize;

            if (receive_ratio == 100)
            {
                if (GetFileMD5Hash.GetSingleton().GetMD5HashFromFile(filePathName) == fileMD5)
                    sendData.verify_complete = true;
            }
            else
            {
                sendData.verify_complete = false;
            }

            RabbitMQEventBus.GetSingleton().Trigger<C_ReplyFileData>(sendData);//直接通过事件总线触发

        }
    }
}
