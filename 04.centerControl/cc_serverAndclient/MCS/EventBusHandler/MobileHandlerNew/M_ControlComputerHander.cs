using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Model;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using MCS;
using UserEventData;
using Utilities;

namespace cc_server
{
    /// <summary>
    /// 处理移动端发送的控制计算机开机或者关机
    /// </summary>
    public class M_ControlPower : IEventHandler<M_S_ControlPower>
    {
        public void HandleEvent(M_S_ControlPower eventData)
        {
            if (eventData.isQuery == 1)
            {
                // NlogHandler.GetSingleton().Info(string.Format("移动端查询整体开关机状态"));
            }
            else
            {
                NlogHandler.GetSingleton().Info(string.Format("移动端控制整体开关机 0为关机 1为开机:{0}", eventData.controlCode));
            }

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                string planName = "";
                if (eventData.isQuery == 1)
                {
                    // 发送整体开机的状态和时间
                }
                else if (eventData.isQuery == 0)
                {
                    if (eventData.controlCode == 1)
                    {
                        if (主界面.GetSingleton().button_allPowerOn.Enabled)
                        {
                            主界面.GetSingleton().button_allPowerOn_Click(null, null);
                        }

                    }
                    else if (eventData.controlCode == 0)
                    {
                        if (主界面.GetSingleton().button_allPowerOff.Enabled)
                        {
                            主界面.GetSingleton().button_allPowerOff_Click(null, null);
                        }
                    }
                }

                // 发送数据
                RabbitMQEventBus.GetSingleton()
                    .Trigger<S_M_ControlPower>(new S_M_ControlPower(Convert.ToInt32(主界面.GetSingleton().allAccomPower),
                        (int) 主界面.GetSingleton().controlPowerRemainSeconds,
                        Convert.ToInt32(主界面.GetSingleton().GetPlanExecTime(主界面.GetSingleton().comboBox_device.Text.Trim())))); //直接通过事件总线触发
            });
            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
