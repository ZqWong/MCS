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
    /// 移动端向PC发送控制方案执行
    /// </summary>
    public class M_S_ControlPlane : EventData
    {
        public M_S_ControlPlane()
        {
            
        }

        /// <summary>
        /// planName：方案名称

        /// </summary>
        public string planeName;
        //public bool isOn;

    }



}
