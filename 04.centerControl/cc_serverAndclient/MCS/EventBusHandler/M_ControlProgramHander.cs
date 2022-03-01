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
    /// 处理移动端发送的控制应用信息
    /// </summary>
    public class M_ControlProgramHander : IEventHandler<M_S_ControlProgram>
    {
        public void HandleEvent(M_S_ControlProgram eventData)
        {
            NlogHandler.GetSingleton().Info(string.Format("移动端控制应用:{0}， 被控计算机:{1}", eventData.programName, eventData.ipList));

            // 接收数据判断
            if (eventData.ipList.Count > 0 && 主界面.GetSingleton().comboBox_process.FindString(eventData.programName) != -1)
            {

                // 跨线程修改winform
                MethodInvoker mi = new MethodInvoker(() =>
                    {
                        主界面.GetSingleton().comboBox_process.SelectedIndex = 主界面.GetSingleton().comboBox_process.FindString(eventData.programName);

                        for (int i = 0; i < 主界面.GetSingleton().MCS_DataGridView.Rows.Count; i++)
                        {
                            string _ip = 主界面.GetSingleton().MCS_DataGridView.Rows[i]
                                .Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                            if (eventData.ipList.Contains(_ip))
                            {
                                主界面.GetSingleton().MCS_DataGridView.Rows[i]
                                    .Cells[ExaminationPCModel.ColumnName_CheckBox].Value = true;
                            }
                            else
                            {
                                主界面.GetSingleton().MCS_DataGridView.Rows[i]
                                    .Cells[ExaminationPCModel.ColumnName_CheckBox].Value = false;
                            }
                        };

                        主界面.GetSingleton().ProgressControls(eventData.isOn);

                        // 发送数据
                        RabbitMQEventBus.GetSingleton()
                            .Trigger<S_M_ControlReplay
                            >(new S_M_ControlReplay("Program")); //直接通过事件总线触发

                    });
                主界面.GetSingleton().BeginInvoke(mi);
            }
        }
    }
}
