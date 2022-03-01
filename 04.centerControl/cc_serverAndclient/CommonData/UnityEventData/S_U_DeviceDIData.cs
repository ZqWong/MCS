using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// 集控发送到unity的设备采集数据
    /// </summary>
    public class S_U_DeviceDIData : EventData
    {
        public S_U_DeviceDIData()
        {

        }

        // 设备名称
        public string name;
        // 数字量
        public byte[] DIDatas;
    }
}
