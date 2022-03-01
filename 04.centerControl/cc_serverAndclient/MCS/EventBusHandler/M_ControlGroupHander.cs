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
    /// 处理移动端发送的控制分组信息
    /// </summary>
    public class M_ControlGroupHander : IEventHandler<M_S_ControlGroup>
    {
        public void HandleEvent(M_S_ControlGroup eventData)
        {
            NlogHandler.GetSingleton().Info(string.Format("移动端控制分组:{0}， 是否开启:{1}", eventData.groupName, eventData.isOn));

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
                {
                    主界面.GetSingleton().comboBox_group.SelectedIndex = 主界面.GetSingleton().comboBox_group.FindString(eventData.groupName);

                    if (eventData.isOn)
                    {
                        主界面.GetSingleton().button_groupOn_Click(null,null);
                    }
                    else
                    {
                        主界面.GetSingleton().button_groupOff_Click(null, null);
                    }

                    

                    // 发送数据
                    RabbitMQEventBus.GetSingleton()
                        .Trigger<S_M_ControlReplay
                        >(new S_M_ControlReplay("Group")); //直接通过事件总线触发

                });

            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
