using OCC_TO_CLIENT;
using RabbitMQEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Core
{
    public class RemoteProcessLanuchHelper
    {

        /// <summary>
        /// 远程启动App
        /// </summary>
        public static MethodInvoker CreateRemoteLanuchAppTask(string ip, string appPath, bool isOn)
        {
            MethodInvoker ret = new MethodInvoker(() =>
            {
                RabbitMQManager.Instance.Trigger(ip, new R_C_ControlProcessData(appPath, isOn));
            });
            return ret;
        }
    }
}
