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
    /// PC向移动端发送控制执行信息
    /// </summary>
    public class S_M_ControlReplay : EventData
    {
        public S_M_ControlReplay(string controlName)
        {
            this.controlName = controlName;
        }

        /// <summary>
        /// controlName  由移动端发送的控制项的大类名称：Computer、 Plan、 Program、Group
        /// </summary>
        public string controlName;

    }



}
