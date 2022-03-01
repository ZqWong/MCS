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
    /// 处理移动端发送的获取计算机的信息
    /// </summary>
    public class M_GetComputerHander : IEventHandler<M_S_GetComputersState>
    {
        public void HandleEvent(M_S_GetComputersState eventData)
        {
            // NlogHandler.GetSingleton().Info(string.Format("移动端获取计算机状态信息"));

            //int 状态(从1开始计数)。 bit1：是否开机 bit2: bit1是否在进行 bit3：是否连接 bit4:立体和左右眼数据是否有效　bit5：是否启用立体 bit6：是否启动左右眼
            S_M_ComputersState sendData = new S_M_ComputersState();

            BitArray bta = new BitArray(8); ;

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
                {
                   

                    for (int i = 0; i < 主界面.GetSingleton().MCS_DataGridView.Rows.Count; i++)
                    {
                        bta.SetAll(false);

                        string _ip = 主界面.GetSingleton().MCS_DataGridView.Rows[i]
                            .Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();

                        string _name = 主界面.GetSingleton().MCS_DataGridView.Rows[i]
                            .Cells[ExaminationPCModel.ColumnName_ExamPCName].Value.ToString();

                        if (eventData.ipList != null)
                        {
                            if (eventData.ipList.Contains(_ip))
                            {
                            }
                            else
                            {
                                continue;
                            }
                        }

                        string pcState = 主界面.GetSingleton().MCS_DataGridView.Rows[i]
                            .Cells[ExaminationPCModel.ColumnName_OpenOrClosePCState].Tag.ToString();

                        switch (pcState)
                        {
                            case Const.Tag_OpenOrClosePCState_Open:
                                bta.Set(0,true);
                                break;

                            case Const.Tag_OpenOrClosePCState_Closed:
                                bta.Set(0, false);
                                break;

                            case Const.Tag_OpenOrClosePCState_Opening:
                                bta.Set(0, true);
                                bta.Set(1, true);
                                break;

                            case Const.Tag_OpenOrClosePCState_Closing:
                                bta.Set(0, false);
                                bta.Set(1, true);
                                break;

                            default:
                                break;
                        }

                        string connectState = 主界面.GetSingleton().MCS_DataGridView.Rows[i]
                            .Cells[ExaminationPCModel.ColumnName_ConnectionState].Tag.ToString();

                        switch (connectState)
                        {
                            case Const.Tag_ConnectionState_Connected:
                                bta.Set(2, true);
                                break;

                            case Const.Tag_ConnectionState_NoConnection:
                                bta.Set(2, false);
                                break;

                            default:
                                break;
                        }

                        object stereoState = 主界面.GetSingleton().MCS_DataGridView.Rows[i]
                            .Cells[ExaminationPCModel.ColumnName_Stereo].Value;

                        object leftRightState = 主界面.GetSingleton().MCS_DataGridView.Rows[i]
                            .Cells[ExaminationPCModel.ColumnName_LeftRight].Value;

                        if (stereoState == null || leftRightState == null)
                        {
                            bta.Set(3, false);
                        }
                        else
                        {
                            bta.Set(3, true);

                            switch (stereoState)
                            {
                                case "开":
                                    bta.Set(4, true);
                                    break;

                                case "关":
                                    bta.Set(4, false);
                                    break;

                                default:
                                    break;
                            }

                            switch (leftRightState)
                            {
                                case "开":
                                    bta.Set(5, true);
                                    break;

                                case "关":
                                    bta.Set(5, false);
                                    break;

                                default:
                                    break;
                            }
                        }
                        List<object> temp = new List<object>();
                        temp.Add(_ip);
                        temp.Add(BitToInt(bta));
                        sendData.computerState.Add(_name, temp);

                    };
                    // 发送数据到移动端
                    RabbitMQEventBus.GetSingleton().Trigger<S_M_ComputersState>(sendData); //直接通过事件总线触发

                });
            主界面.GetSingleton().BeginInvoke(mi);
        }


        public int BitToInt(BitArray bit)
        {
            int[] res = new int[1];

            for (int i = 0; i < bit.Count; i++)
            {
                bit.CopyTo(res, 0);
            }

            return res[0];
        }

    }
}
