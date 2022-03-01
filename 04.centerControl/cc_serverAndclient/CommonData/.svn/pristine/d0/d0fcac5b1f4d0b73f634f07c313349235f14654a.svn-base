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
    /// 移动端发送M_S_ControlPower，pc端返回
    /// 
    /// </summary>
    public class S_M_ControlPower : EventData
    {
        public S_M_ControlPower(int powerState, int remainTime, int totalTime)
        {
            this.powerState = powerState;
            this.remainTime = remainTime;
            this.totalTime = totalTime;
        }

        /// <summary>
        /// powerState   0： 关机 1：开机
        /// remainTime   开机剩余时间
        /// </summary>
        public int powerState;

        public int remainTime;
        public int totalTime;
    }
}
