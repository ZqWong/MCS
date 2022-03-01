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
    /// 处理移动端发送的获取计算机的应用信息
    /// </summary>
    public class M_GetProgramInfoHander : IEventHandler<M_S_GetProgramInfo>
    {
        public void HandleEvent(M_S_GetProgramInfo eventData)
        {
            NlogHandler.GetSingleton().Info(string.Format("移动端获取应用信息"));

            S_M_ProgramInfo sendData = new S_M_ProgramInfo();

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                string processName;

                for (int i = 0; i < 主界面.GetSingleton().comboBox_process.Items.Count; i++)
                {
                    processName = 主界面.GetSingleton().comboBox_process.GetItemText(主界面.GetSingleton().comboBox_process.Items[i]);

                    if (processName != "")
                    {
                        sendData.progressInfo.Add(processName);
                    }
                }

                // 发送数据
                RabbitMQEventBus.GetSingleton().Trigger<S_M_ProgramInfo>(sendData); //直接通过事件总线触发

            });
            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
