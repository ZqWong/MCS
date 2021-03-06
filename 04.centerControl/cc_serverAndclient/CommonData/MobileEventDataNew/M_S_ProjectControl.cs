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
    /// 移动端控制执行PC端的投影控制。比如3D开启、翻转等
    /// </summary>
    public class M_S_ProjectControl : EventData
    {
        public M_S_ProjectControl(List<string> projectIPList, string controlCode)
        {
            this.projectIPList = projectIPList;
            this.controlCode = controlCode;
        }

        /// <summary>
        /// projectNameList            需要被控制的设备的IP
        /// controlCode          执行的控制码
        /// </summary>
        public List<string> projectIPList;
        public string controlCode;

        //4K10投影机3D翻转命令：
        //开: (tdi 1)
        //关: (tdi 0)

        //光闸控制命令：
        //开: (shu 0)
        //关: (shu 1)
    }
}
