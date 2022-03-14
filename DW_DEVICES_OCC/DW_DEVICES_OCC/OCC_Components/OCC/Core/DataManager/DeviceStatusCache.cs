using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCache
{

    /// <summary>
    /// 开机状态枚举
    /// </summary>
    public enum DevicePowerStatus
    {
        OPENED = 0,  //开机状态
        CLOSED,      //关机状态
        CLOSEING,    //关机中
        OPENING      //开机中
    }

    /// <summary>
    /// 设备数据绑定结构
    /// </summary>
    public class DeviceStatusCache
    {
        public DeviceStatusCache() { }
        public DeviceStatusCache(int index, DevicePowerStatus powerStatus, DeviceDataModel dataModel)
        {
            Index = index;
            PowerStatus = powerStatus;
            DataModel = dataModel;
        }

        public int Index;
        public DevicePowerStatus PowerStatus = DevicePowerStatus.CLOSED;
        public DeviceDataModel DataModel;
        public string Ping;
    }
    
}
