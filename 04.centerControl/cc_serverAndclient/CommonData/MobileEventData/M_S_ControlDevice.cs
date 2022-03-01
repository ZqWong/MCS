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
    /// 移动端向PC获取发送请求控制其他设备
    /// </summary>
    public class M_S_ControlDevice : EventData
    {
        public M_S_ControlDevice()
        {
            
        }

        /// <summary>
        /// deviceName：设备名称
        /// isOn:是否开启
        /// </summary>
        public string deviceName;
        public bool isOn;

    }



}
