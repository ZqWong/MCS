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
    /// 移动端控制灯光。比如开启或关闭灯光等
    /// </summary>
    public class M_S_LightControl : EventData
    {
        public M_S_LightControl(string lightName, string controlCode)
        {
            this.lightName = lightName;
            this.controlCode = controlCode;
        }

        /// <summary>
        /// lightName          灯光名称，移动端刚刚启动时向服务端获取
        /// queryState          灯光控制码
        /// </controlCode>
        public string lightName;
        public string controlCode;

        //全开：01 20 FF FF 00 00 00 1F
        //全关：01 20 00 00 00 00 00 21
    }
}
