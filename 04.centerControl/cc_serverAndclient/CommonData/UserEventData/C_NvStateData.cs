using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{

    public class C_NvStateData : EventData
    {
        // 左右眼翻转以及立体开关状态
        public int m_swapEye;
        public int m_stereoOn;

    }

}
