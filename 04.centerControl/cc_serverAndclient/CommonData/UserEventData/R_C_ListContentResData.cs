using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// 向客户端发送获取目录列表
    /// </summary>
    public class R_C_ListContentResData : EventData
    {
        public R_C_ListContentResData(string path)
        {
            this.DriverOrDirectoryPath = path;
        }

        public string DriverOrDirectoryPath;

    }



}
