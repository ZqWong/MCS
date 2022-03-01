using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using MCS;
using NPOI.SS.Formula.Functions;
using UserEventData;
using Utilities;

namespace cc_server
{
    /// <summary>
    /// 重命名，客户端的反馈
    /// </summary>
    public class RenameContentHandler : IEventHandler<C_RenameContentData>
    {
        public void HandleEvent(C_RenameContentData eventData)
        {
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (eventData.ErorrOccured)
                {
                    NlogHandler.GetSingleton().Error(string.Format("重命名出现异常，异常:{0}", eventData.ErrorMessage));
                }
                else
                {
                    传输文件.GetSingleton().button_refresh_Click(null, null);
                }
            });

            传输文件.GetSingleton().BeginInvoke(mi);

        }
    }
}
