using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{

    public class C_RemoteControlData : EventData
    {
        public C_RemoteControlData(bool isOpen, string args, int workingAreaWidth, int workingAreaHeight)
        {
            this.isOpen = isOpen;
            this.args = args;

            this.workingAreaWidth = workingAreaWidth;
            this.workingAreaHeight = workingAreaHeight;
        }

        public bool isOpen;
        public string args;

        public int workingAreaWidth;
        public int workingAreaHeight;

    }

}
