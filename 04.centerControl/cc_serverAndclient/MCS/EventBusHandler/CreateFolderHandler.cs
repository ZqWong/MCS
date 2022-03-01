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
    /// 创建文件夹
    /// </summary>
    public class CreateFolderHandler : IEventHandler<C_CreateFolderContentData>
    {
        public void HandleEvent(C_CreateFolderContentData eventData)
        {
            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (eventData.ErorrOccured)
                {
                    MessageBox.Show(eventData.ErrorMessage, "新建文件夹失败");
                    NlogHandler.GetSingleton().Error(string.Format("创建文件夹出现异常，异常:{0}", eventData.ErrorMessage));
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
