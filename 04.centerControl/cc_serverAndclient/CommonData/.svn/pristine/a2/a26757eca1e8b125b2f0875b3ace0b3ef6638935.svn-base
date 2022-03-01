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
    /// PC端向移动端发送投影信息和控制码和投影机状态
    /// </summary>
    public class S_M_ProjectState : EventData
    {
        public S_M_ProjectState(Dictionary<string, KeyValuePair<string, bool>> projectDict)
        {
            this.projectDict = projectDict;

        }

        /// <summary>
        /// projectDict            key：名称 value: ip、连接状态
        /// </summary>
        public Dictionary<string, KeyValuePair<string, bool>> projectDict;

    }
}
