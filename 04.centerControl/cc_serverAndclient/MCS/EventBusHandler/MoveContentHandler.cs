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
    /// 剪切或者复制时间，客户端的反馈
    /// </summary>
    public class MoveContentHandler : IEventHandler<C_MoveContentData>
    {
        public void HandleEvent(C_MoveContentData eventData)
        {
            bool allRight = true;
            // 客户端发送过来的如果包含异常或者其他错误信息，则打印log
            foreach (var result in eventData.MoveResults)
            {
                if (result != null)
                {
                    allRight = false;
                    NlogHandler.GetSingleton().Error(string.Format("粘贴出现问题，操作类型:{0}, 文件： {1}", eventData.ParseType, result));
                }
            }

            if (eventData.ErorrOccured)
            {
                allRight = false;
                NlogHandler.GetSingleton().Error(string.Format("粘贴出现异常，操作类型:{0}, 异常:{1}", eventData.ParseType, eventData.ErrorMessage));
            }

            if (allRight)
            {
                // 跨线程修改winform
                MethodInvoker mi = new MethodInvoker(() =>
                {
                    NlogHandler.GetSingleton().Info(string.Format("粘贴操作完成 : {0}",eventData.fromIp));
                    // MessageBox.Show("粘贴操作完成");

                    传输文件.GetSingleton().button_refresh_Click(null, null);

                });

                传输文件.GetSingleton().BeginInvoke(mi);
            }
        }
    }
}
