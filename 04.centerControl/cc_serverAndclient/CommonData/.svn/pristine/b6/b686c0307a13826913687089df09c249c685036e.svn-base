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
    /// 移动端控制执行整体开机命令或整体关机命令
    /// 移动端查询PC端的当前状态
    /// </summary>
    public class M_S_ControlPower : EventData
    {
        public M_S_ControlPower(int controlCode, int isQuery)
        {
            this.controlCode = controlCode;
            this.isQuery = isQuery;
        }

        /// <summary>
        /// controlCode  0： 关机 1：开机
        /// queryState   0:  执行控制，不查询   1：不执行控制，查询状态
        /// </summary>
        public int controlCode;
        public int isQuery;
    }
}
