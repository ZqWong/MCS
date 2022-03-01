using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{

    public class R_C_ControlPowerData : EventData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_state"> 0：关机 1：重启 </param>
        public R_C_ControlPowerData(int _state)
        {
            state = _state;
        }

        public int state;
    }



}
