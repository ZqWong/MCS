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
    /// PC响应移动端M_S_PlayListControl。
    ///
    /// </summary>
    public class S_M_PlayListControl : EventData
    {
        public S_M_PlayListControl(List<string> playList, string playingListName, string playingName, string prePlayName, string nextPlayName,int playVideoIntervalMS)
        {
            this.playList = playList;
            this.playingName = playingName;
            this.prePlayName = prePlayName;
            this.nextPlayName = nextPlayName;
            this.playingListName = playingListName;
            this.playVideoIntervalMS = playVideoIntervalMS;
        }

        /// <summary>
        /// playList  播放列表
        /// playingListName   当前正在播放的播放列表名称
        /// playingName   当前正在播放video名称
        /// prePlayName   上一部名称
        /// nextPlayName   下一部名称
        /// playVideoIntervalMS  上一部 下一部  播放等 操作延迟时间 毫秒
        /// </summary>
        public List<string> playList;
        public string playingListName;
        public string playingName;
        public string prePlayName;
        public string nextPlayName;
        public int playVideoIntervalMS;
    }
}
