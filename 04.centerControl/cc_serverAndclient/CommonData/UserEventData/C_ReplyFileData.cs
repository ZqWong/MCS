using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;
using UserEventData;

namespace UserEventData
{

    public class C_ReplyFileData : EventData
    {
        public string fileName;
        public int receive_ratio;
        public bool verify_complete;

        // 发送所有文件或问价夹的总大小
        public long totalSize;

        // 以发送总大小(包括所有已发送的文件)
        public long alreadySendSize;

    }



}
