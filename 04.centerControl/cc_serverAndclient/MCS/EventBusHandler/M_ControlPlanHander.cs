using System;
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
using MCS;
using UserEventData;
using Utilities;

namespace cc_server
{
    /// <summary>
    /// 处理移动端发送的控制设备方案信息
    /// </summary>
    public class M_ControlPlanHander : IEventHandler<M_S_ControlPlane>
    {
        //todo 更改为了方案控制  需要重写
        public void HandleEvent(M_S_ControlPlane eventData)
        {
            NlogHandler.GetSingleton().Info(string.Format("移动端控制方案:{0}", eventData.planeName));

            // 接收数据判断
            if (主界面.GetSingleton().comboBox_device.FindString(eventData.planeName) != -1)
            {

                // 跨线程修改winform
                MethodInvoker mi = new MethodInvoker(() =>
                {
                    int a = 主界面.GetSingleton().comboBox_device.FindString(eventData.planeName);

                    主界面.GetSingleton().comboBox_device.SelectedIndex = 主界面.GetSingleton().comboBox_device.FindString(eventData.planeName);

                    主界面.GetSingleton().button_device_on_Click(null, null);

                    // 发送数据
                    RabbitMQEventBus.GetSingleton()
                        .Trigger<S_M_ControlReplay
                        >(new S_M_ControlReplay("Plan")); //直接通过事件总线触发
                });
                主界面.GetSingleton().BeginInvoke(mi);
            }
        }
    }
}
