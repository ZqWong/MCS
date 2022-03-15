using RabbitMQEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCC_TO_CLIENT
{ 
    public class R_C_ControlProcessData : EventData
    {
        public R_C_ControlProcessData(string pathName, bool open, string arguments=null, bool useShellExecute=true, bool redirectStandardInput=false, bool redirectStandardOutput = false, bool redirectStandardError = false, bool createNoWindow = false)
        {
            this.processFilePathName = pathName;
            this.trunOn = open;
            this.arguments = arguments;
            this.useShellExecute = useShellExecute;
            this.redirectStandardInput = redirectStandardInput;
            this.redirectStandardOutput = redirectStandardOutput;
            this.redirectStandardError = redirectStandardError;
            this.createNoWindow = createNoWindow;
        }

        public string processFilePathName;
        // 开启或关闭
        public bool trunOn;
        // 执行参数
        public string arguments;
        public bool useShellExecute;
        public bool redirectStandardInput;
        public bool redirectStandardOutput;
        public bool redirectStandardError;
        public bool createNoWindow;

    }
}
