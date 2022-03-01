using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// unity 给集控发送的数据(4D座椅)
    /// </summary>
    public class U_S_DeviceData : EventData
    {
        public U_S_DeviceData()
        {

        }

        /// <summary>
        /// 座椅字节（字节长度不要超）
        ///     开启play:0x50 0x4c 0x41 0x59
        ///     停止stop:0x53 0x54 0x4f 0x50
        ///     姿态atti:0x41,0x54,0x54,0x49 + 40字节  详见协议
        ///     震动effe:0x45 0x46 0x46 0x45 + 12字节  详见协议
        ///     特效effo:0x45 0x46 0x46 0x4f + 4字节   详见协议
        /// </summary>
        public byte[] seatDatas;


    }
}
