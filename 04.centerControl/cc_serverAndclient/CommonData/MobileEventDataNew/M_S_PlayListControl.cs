using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// 移动端控制播放
    /// </summary>
    public class M_S_PlayListControl : EventData
    {
        public M_S_PlayListControl(string playPlayListName, int playControl)
        {
            this.playPlayListName = playPlayListName;
            this.playControl = playControl;
        }

        /// <summary>
        /// playPlayListName  播放列表名称
        /// playControl   播放控制。  1：上一部  2：下一步  3：停止播放  4：开始播放
        /// </summary>
        public string playPlayListName;
        public int playControl;
    }
}
