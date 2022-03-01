using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// 移动端控制完成后答复
    /// </summary>
    public class S_M_LightControlReply : EventData
    {
        public S_M_LightControlReply(string controlCode)
        {
            this.controlCode = controlCode;
        }

        /// <summary>
        /// controlCode          执行的控制码
        /// </summary>
        public string controlCode;
    }
}
