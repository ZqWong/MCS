using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceControl
{
    // 设备结构体
    public class DeviceStruct
    {
        // 设备名称
        public string deviceName;
        // 设备类型名称
        public string deviceClassName;
        // 控制类型 网口:0 串口:1
        public int controlType;
        // 是否使用16进制形式进行控制码输入
        // public bool isHex;
        // IP地址
        public string ip;
        // 端口地址
        public string port;
        // 串口端口号
        public string serialPort;
        // 波特率
        public int buad;
    }

    // 控制码结构体
    public class CodeStruct
    {
        // 类型名称
        public string className;
        // 控制码名称
        public string codeName;
        // 控制码
        public string code;
        // 设备控制启动后延迟时间
        public float delay;
        // 自动执行间隔
        public float autoExecInterval;

    }
}
