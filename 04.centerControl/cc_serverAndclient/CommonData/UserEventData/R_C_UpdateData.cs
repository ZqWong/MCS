using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{

    public class R_C_UpdateData : EventData
    {
        public R_C_UpdateData(string oldFolder, string newFolder, string updateClientFullName, string clientFullName)
        {
            this.oldFolder = oldFolder;
            this.newFolder = newFolder;
            this.updateClientFullName = updateClientFullName;
            this.clientFullName = clientFullName;

        }

        public string oldFolder;
        public string newFolder;
        // 更新客户端的exe的路径 updateClientPath
        public string updateClientFullName;
        // 当前client的运行路径
        public string clientFullName;

    }



}
