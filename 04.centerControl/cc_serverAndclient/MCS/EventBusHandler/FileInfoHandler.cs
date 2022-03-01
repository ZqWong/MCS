using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using MCS;
using UserEventData;

namespace cc_server
{
    /// <summary>
    /// 传输事件处理
    /// </summary>

    public class FileInfoHandler : IEventHandler<C_FileInfoData>
    {
        public void HandleEvent(C_FileInfoData eventData)
        {

            //Console.WriteLine("客户端IP :{0}, 进程名称 :{1} 运行的进程数 {2}, 进程路径 :{3}", eventData.client_ip, eventData.ProcessName, eventData.ProcessCount, eventData.FilePathName);

        }
    }
}
