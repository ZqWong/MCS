using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using MCS;
using UserEventData;
using Utilities;

namespace cc_server
{
    /// <summary>
    /// 传输事件处理
    /// </summary>


    public class GetFileHandler : IEventHandler<C_FileData>
    {
        private static Dictionary<string, FileStream> _myFileStreamDict = new Dictionary<string, FileStream>();
        private static FileStream _currentFile = null;

        private string _fullPath = "";

        public void HandleEvent(C_FileData eventData)
        {

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
                _myFileStreamDict.Add(_fullPath, _currentFile);

                NlogHandler.GetSingleton().Info(string.Format("文件 {0} 开始传输", eventData.name));

            }

            //将接收到的数据包写入到文件流对象   
            _currentFile.Write(eventData.FileData, 0, eventData.FileData.Length);

            if (eventData.totalCount > 20)
            {
                if (eventData.currentCount % (eventData.totalCount / 20) == 0)
                {
                    int _receive_ratio = (int)((100.0f) * eventData.currentCount / eventData.totalCount);

                }
            }

            if (eventData.currentCount == eventData.totalCount)
            {
                //关闭文件流   
                _currentFile.Close();

                _myFileStreamDict.Remove(_fullPath);
                _currentFile = null;

                NlogHandler.GetSingleton().Info(string.Format("文件 {0} 传输完成", eventData.name));
            }

            // 传输完成
            if (eventData.alreadySendSize == eventData.totalSize)
            {
                传输文件.client_receive_progress_Args args = new 传输文件.client_receive_progress_Args()
                {
                    ip = eventData.fromIp,
                    totalSize = eventData.totalSize,
                    alreadySendSize = eventData.alreadySendSize
                };

                传输文件.GetSingleton().GetSyncContext().Post(传输文件.GetSingleton().client_receive_progress, args);
            }

        }
    }
}
