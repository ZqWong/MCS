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
    /// 处理移动端发送的控制计算机信息
    /// </summary>
    public class M_ControlComputerHander : IEventHandler<M_S_ControlComputer>
    {
        public void HandleEvent(M_S_ControlComputer eventData)
        {
            NlogHandler.GetSingleton().Info(string.Format("移动端控制计算机状态:{0}", eventData.operationCode));

            // 执行的任务 1：开机 2：关机 3：重启 4：立体切换 5：左右眼切换 6:刷新

            // 接收数据判断
            if (eventData.ipList.Count > 0 && eventData.operationCode <= 6 && eventData.operationCode > 0)
            {
                // 关闭集控计算机
                if (eventData.ipList.Count == 1 && eventData.ipList[0] == "CCServer" && eventData.operationCode == 2)
                {
                    NlogHandler.GetSingleton().Info("响应移动端关机");
                    Process.Start("shutdown.exe", "-s");//关机
                }

                // 跨线程修改winform
                MethodInvoker mi = new MethodInvoker(() =>
                    {

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

                        if (eventData.operationCode < 4)
                        {
                            string operationCode;

                            switch (eventData.operationCode)
                            {
                                case 1:
                                    operationCode = "开机";
                                    break;

                                case 2:
                                    operationCode = "关机";
                                    break;

                                case 3:
                                    operationCode = "重启";
                                    break;

                                default:
                                    operationCode = "";
                                    break;
                            }
                            主界面.GetSingleton().cbAction.SelectedIndex = 主界面.GetSingleton().cbAction.FindString(operationCode);

                            主界面.GetSingleton().btnControlExamPC_Click(null,null);
                        }
                        else
                        {
                            if (eventData.operationCode == 4)
                            {
                                主界面.GetSingleton().button_stereo_Click(null, null);
                            }
                            else if (eventData.operationCode == 5)
                            {
                                主界面.GetSingleton().button_leftRight_Click(null, null);
                            }
                            else if (eventData.operationCode == 6)
                            {
                                主界面.GetSingleton().button_refresh_Click(null, null);

                                // 发送数据
                                RabbitMQEventBus.GetSingleton()
                                    .Trigger<M_S_GetComputersState
                                    >(GetLocalIp.GetSingleton().GetIP(), new M_S_GetComputersState()); //直接通过事件总线触发
                            }
                        }

                        // 发送数据
                        RabbitMQEventBus.GetSingleton()
                            .Trigger<S_M_ControlReplay
                            >(new S_M_ControlReplay("Computer")); //直接通过事件总线触发
                    });
                主界面.GetSingleton().BeginInvoke(mi);
            }
        }
    }
}
