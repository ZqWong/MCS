using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// 移动端向PC获取计算机状态.包括开关机、连接、左右眼及立体
    /// </summary>
    public class M_S_GetComputersState : EventData
    {
        public M_S_GetComputersState(List<string> ipList = null)
        {
            this.ipList = ipList;

        }
        
        /// <summary>
        /// 默认为空,为获取所有计算机状态
        /// 如果不为空，则指定返回list中的计算机状态
        /// </summary>
        public List<string> ipList;

    }



}
