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
    /// PC向移动端发送计算机状态.包括开关机、连接、左右眼及立体
    /// </summary>
    public class S_M_ComputersState : EventData
    {
        public S_M_ComputersState()
        {

        }

        /// <summary>
        /// key:计算机名称
        /// List<object>[0]: string ip
        /// List<object>[1]: int 状态(从1开始计数)。 bit1：是否开机 bit2: bit1是否在进行 bit3：是否连接 bit4:立体和左右眼数据是否有效　bit5：是否启用立体 bit6：是否启动左右眼
        /// </summary>
        public Dictionary<string, List<object>> computerState = new Dictionary<string, List<object>>();

    }



}
