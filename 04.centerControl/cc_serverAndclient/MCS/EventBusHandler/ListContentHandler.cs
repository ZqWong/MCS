using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Model;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using MCS;
using UserEventData;

namespace cc_server
{
    /// <summary>
    /// 获取客户端的目录信息
    /// </summary>

    public class ListContentHandler : IEventHandler<C_ListContentResData>
    {
        public void HandleEvent(C_ListContentResData eventData)
        {

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                if (eventData.ErorrOccured)
                {
                    传输文件.GetSingleton().label_error.Text = eventData.ErrorMessage;
                    传输文件.GetSingleton().label_error.Show();
                    传输文件.GetSingleton().listView_content.Items.Clear();
                }
                else
                {
                    传输文件.GetSingleton().label_error.Text = "";
                    传输文件.GetSingleton().label_error.Hide();
                    传输文件.GetSingleton().listView_content.Items.Clear();

                    if (eventData.Drivers != null && eventData.Drivers.Length > 0)
                    {
                        foreach (string driver in eventData.Drivers)
                        {
                            ListViewItem item = new ListViewItem();
                            item.ImageKey = "driver.png";
                            item.Text = driver;
                            传输文件.GetSingleton().listView_content.Items.Add(item);
                        }
                    }

                    if (eventData.Directories != null && eventData.Directories.Length > 0)
                    {
                        foreach (string directory in eventData.Directories)
                        {
                            ListViewItem item = new ListViewItem();
                            item.ImageKey = "folder.png";
                            item.Text = Path.GetFileName(directory);
                            传输文件.GetSingleton().listView_content.Items.Add(item);
                        }
                    }

                    if (eventData.Files != null && eventData.Files.Length > 0)
                    {
                        foreach (string file in eventData.Files)
                        {
                            ListViewItem item = new ListViewItem();
                            item.ImageKey = "file.png";
                            item.Text = Path.GetFileName(file);
                            传输文件.GetSingleton().listView_content.Items.Add(item);
                        }
                    }
                }

            });
            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
