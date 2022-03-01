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
    /// 删除客户端文件
    /// </summary>
    public class DeleteContentHandler : IEventHandler<C_DeleteContentData>
    {
        public void HandleEvent(C_DeleteContentData eventData)
        {

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (eventData.ErorrOccured)
                {
                    StringBuilder builder = new StringBuilder();

                    builder.AppendLine(string.Format("IP:{0}", eventData.fromIp));

                    foreach (string result in eventData.DeleteResults)
                    {
                        if (result != null)
                        {
                            builder.AppendLine(result);
                        }
                    }

                    MessageBox.Show(builder.ToString(), "删除出现错误");
                    NlogHandler.GetSingleton().Error(string.Format("删除出现异常，异常:{0}", eventData.ErrorMessage));
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
