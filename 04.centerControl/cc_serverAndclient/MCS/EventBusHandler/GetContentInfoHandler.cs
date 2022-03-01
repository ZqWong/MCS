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
    /// 获取客户端文件属性
    /// </summary>
    public class GetContentInfoHandler : IEventHandler<C_GetContentInfoData>
    {
        public void HandleEvent(C_GetContentInfoData eventData)
        {

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (eventData.ErorrOccured)
                {
                    MessageBox.Show(eventData.ErrorMessage.ToString(), "获取属性出现错误");
                    NlogHandler.GetSingleton().Error(string.Format("获取客户端属性出现异常，异常:{0}", eventData.ErrorMessage));
                }
                else
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (B_TextInfoData result in eventData.InfoList)
                    {
                        builder.AppendLine(result.Name + " : " + result.Value);
                    }
                    MessageBox.Show(builder.ToString(), "属性");
                }
            });

            传输文件.GetSingleton().BeginInvoke(mi);
        }
    }
}
