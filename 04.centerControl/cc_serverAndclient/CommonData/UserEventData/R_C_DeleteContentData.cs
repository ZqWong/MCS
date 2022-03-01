using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// 向客户端发送删除消息
    /// </summary>
    public class R_C_DeleteContentData : EventData
    {

        public List<string> ContentPaths;
    }



}
