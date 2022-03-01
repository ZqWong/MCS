using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using LibNvDriverSetting;
using LibUtilitiesNameSpace;
using UserEventData;
using Utilities;


namespace cc_clinet
{
    /// <summary>
    /// 关机和重启
    /// </summary>
    /// </summary>
    public class ControlPowerHandle : IEventHandler<R_C_ControlPowerData>
    {

        public void HandleEvent(R_C_ControlPowerData eventData)
        {

            switch (eventData.state)
            {
                case 0:
                    NlogHandler.GetSingleton().Info("响应关机");
                    Process.Start("shutdown.exe", "-s");//关机
                    break;
                case 1:
                    NlogHandler.GetSingleton().Info("响应重启");
                    Process.Start("shutdown.exe", "-r");//重启
                    break;
                default:
                    break;
            }
        }

    }
}
