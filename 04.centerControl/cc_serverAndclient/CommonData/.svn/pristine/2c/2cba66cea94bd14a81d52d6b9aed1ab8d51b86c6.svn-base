using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// 传输文件点击剪切或复制
    /// </summary>
    public class R_C_MoveContentData : EventData
    {
        public R_C_MoveContentData(string pasteType, List<string> contentPaths, string container)
        {
            this.PasteType = pasteType;
            this.ContentPaths = contentPaths;
            this.Container = container;
        }

        // 识别剪切或者复制
        public string PasteType;

        public List<string> ContentPaths;

        public string Container;

    }

}
