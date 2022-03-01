using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using MCS;
using UserEventData;

namespace cc_server
{
    /// <summary>
    /// 传输事件处理
    /// </summary>


    public class GetCltStereoHander : IEventHandler<C_GetCltStereo>
    {
        public void HandleEvent(C_GetCltStereo eventData)
        {
            主界面.UpdateCltSteteo_Args args = new 主界面.UpdateCltSteteo_Args()
                { ip = eventData.fromIp, m_swapEye = eventData.m_swapEye, m_stereoOn = eventData.m_stereoOn};

            主界面.GetSingleton().GetSyncContext().Post(主界面.GetSingleton().UpdateCltStereo, args);

        }
    }
}
