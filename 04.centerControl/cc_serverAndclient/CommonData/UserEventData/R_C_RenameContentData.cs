using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET;

namespace UserEventData
{
    /// <summary>
    /// 重命名
    /// </summary>
    public class R_C_RenameContentData : EventData
    {
        public R_C_RenameContentData(string contentPath, string newContentName)
        {
            this.ContentPath = contentPath;
            this.NewContentName = newContentName;
        }

        public string ContentPath;

        public string NewContentName;

    }

}
