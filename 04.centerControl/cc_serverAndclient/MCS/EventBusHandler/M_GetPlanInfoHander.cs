using System;
using System.Collections;
using System.Collections.Generic;
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
using MCS.Common;
using UserEventData;
using Utilities;

namespace cc_server
{
    /// <summary>
    /// 处理移动端发送的获取计算机的方案信息
    /// </summary>
    public class M_GetPlanInfoHander : IEventHandler<M_S_GetPlansInfo>
    {
        public void HandleEvent(M_S_GetPlansInfo eventData)
        {
            NlogHandler.GetSingleton().Info(string.Format("移动端获取设备信息"));

            S_M_PlanInfo sendData = new S_M_PlanInfo();

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                string deviceName;

                for (int i = 0; i < 主界面.GetSingleton().comboBox_device.Items.Count; i++)
                {
                    deviceName = 主界面.GetSingleton().comboBox_device.GetItemText(主界面.GetSingleton().comboBox_device.Items[i]);

                    if (deviceName != "")
                    {
                        sendData.planInfo.Add(deviceName);
                    }
                }

                // 发送数据
                RabbitMQEventBus.GetSingleton().Trigger<S_M_PlanInfo>(sendData); //直接通过事件总线触发

            });
            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
