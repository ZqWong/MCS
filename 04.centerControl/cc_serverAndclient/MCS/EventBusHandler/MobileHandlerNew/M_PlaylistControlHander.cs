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
    public class M_PlaylistControlHander : IEventHandler<M_S_PlayListControl>
    {
        public void HandleEvent(M_S_PlayListControl eventData)
        {
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (eventData.playPlayListName != "" && 主界面.GetSingleton().GetPalyGroupButtonEnableState())
                {
                    NlogHandler.GetSingleton().Debug(string.Format("收到数据 playlistName {0}, controlCode {1}", eventData.playPlayListName, eventData.playControl));

                    switch (eventData.playControl)
                    {

                        case 1:
                            主界面.GetSingleton().button_last_Click(null, null);
                            // NlogHandler.GetSingleton().Debug("接收移动端上一部控制");

                            break;
                        case 2:
                            主界面.GetSingleton().button_next_Click(null, null);

                            break;
                        case 3:
                            if (主界面.GetSingleton().GetComboxCurPlayingListNameText() != "")
                            {
                                主界面.GetSingleton().button_playOff_Click(null, null);
                            }
                            break;
                        case 4:
                            if (主界面.GetSingleton().GetLableCurPlayText() != "")
                            {
                                NlogHandler.GetSingleton().Error(string.Format("移动端更改播放列表时 :{0}，有正在播放的video {1}", eventData.playPlayListName, 主界面.GetSingleton().GetLableCurPlayText()));
                            }
                            else
                            {
                                主界面.GetSingleton().SetComboxPlayList(eventData.playPlayListName);
                                主界面.GetSingleton().button_playOn_Click(null, null);
                            }
                            break;
                        default:
                            break;

                    }
                }



                S_M_PlayListControl sendData = new S_M_PlayListControl(
                    主界面.GetSingleton().GetPlayListName(),
                    主界面.GetSingleton().GetComboxCurPlayingListNameText(),
                    主界面.GetSingleton().GetLableCurPlayText(),
                    主界面.GetSingleton().GetLableProPlayText(),
                    主界面.GetSingleton().GetLableNextPlayText(),
                    主界面.GetSingleton().GetplayVideoIntervalMS()
                    );

                // 发送数据
                RabbitMQEventBus.GetSingleton()
                    .Trigger<S_M_PlayListControl>(sendData); //直接通过事件总线触发
            });
            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
