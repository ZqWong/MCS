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
    /// 移动端向PC获取发送请求控制计算机
    /// 包括开机、关机、重启、左右眼切换、立体切换
    /// </summary>
    public class M_S_ControlComputer : EventData
    {
        public M_S_ControlComputer()
        {
            
        }

        /// <summary>
        /// ipList：被控计算机ip
        /// operationCode：执行的任务 1：开机 2：关机 3：重启 4：立体切换 5：左右眼切换 6：刷新左右眼和立体信息
        /// 刷新：PC收到刷新指定，会发送所有客户端信息到移动端，不论是否选中.如果ipList的count为1，并且ipList[0]位CCSever，且任务码为2时，则关机
        /// </summary>
        public int operationCode;
        public List<string> ipList = new List<string>();

    }



}
