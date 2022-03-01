using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// 服务端与客户端之间收发文件的数据结构
    /// </summary>
    public class R_C_FileData : EventData
    {
        public string name;
        public string destPath;
        public string fileMD5;
        public int totalCount;
        public int currentCount;
        public byte[] FileData;

        // 发送所有文件或文件夹的总大小
        public long totalSize;

        // 已发送总大小(包括所有已发送的文件（包含当前文件）)
        public long alreadySendSize;
    }
}
