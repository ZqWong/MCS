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
    /// PC向移动端发送设备信息
    /// </summary>
    public class S_M_PlanInfo : EventData
    {
        public S_M_PlanInfo()
        {

        }
        
        /// <summary>
        /// list 为设备名称列表
        /// </summary>
        public List<string> planInfo = new List<string>();

    }



}
