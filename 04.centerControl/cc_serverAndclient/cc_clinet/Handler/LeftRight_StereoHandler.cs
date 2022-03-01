using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
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
    /// 左右眼和立体控制
    /// </summary>
    public class LeftRight_StereoHandler : IEventHandler<C_NvStateData>
    {
        public static NamedPipeServerStream server = null;

        public async void HandleEvent(C_NvStateData eventData)
        {
            try
            {
                //LibNvDriverSetting.LibNvDriverSetting.SwapEyes(Convert.ToBoolean(eventData.m_swapEye));

                //LibNvDriverSetting.LibNvDriverSetting.EnableStereo(Convert.ToBoolean(eventData.m_stereoOn));

                string pipeString = "SetStereo" + eventData.m_stereoOn + eventData.m_swapEye;

                GetCltStereoHandler.startStereoProcess(ref server);

                await server.WaitForConnectionAsync();

                string recData = "";

                GetCltStereoHandler.pipeMessage(server, pipeString, ref recData);

                GetCltStereoHandler.server.Close();

                NlogHandler.GetSingleton().Info("当前显卡设置状态：立体->" + recData.Substring(pipeString.Length,1) + ", 左右眼->" + recData.Substring(pipeString.Length + 1, 1));

            }
            catch (System.Exception ex)
            {
                NlogHandler.GetSingleton().Error("LeftRight_StereoHandler : " + ex.Message);
            }
        }
    }
}
