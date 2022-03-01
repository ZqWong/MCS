using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Model;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using MainTrain.Tools;
using MCS;
using UserEventData;
using Utilities;

namespace cc_server
{
    /// <summary>
    /// 处理移动端发送的控制计算机开机或者关机
    /// </summary>
    public class M_GetLightInfoHander : IEventHandler<M_S_GetLightInfo>
    {
        public void HandleEvent(M_S_GetLightInfo eventData)
        {

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(() =>
            {
                string deviceClassName = "灯光";

                // s_device_all.Tables[0].Select(string.Format("{0} in ({1})", DeviceControlModel.DB_Name, deviceName));
                DataRow[] dr = 其他设备控制.GetSingleton().ds_device_all.Tables[0].Select(string.Format("{0} = '{1}'", DeviceControlModel.DB_CLASS, deviceClassName));

                List<string> deviceList = new List<string>();
                string controlName = "";

                if (dr.Length > 0)
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        string className = dr[i][DeviceControlModel.DB_CLASS].ToString();
                        string ip = dr[i][DeviceControlModel.DB_IP].ToString();
                        string id = dr[i][DeviceControlModel.DB_ID].ToString();
                        string name = dr[i][DeviceControlModel.DB_Name].ToString();

                        deviceList.Add(name);
                    }
                    RabbitMQEventBus.GetSingleton()
                        .Trigger<S_M_LightInfo>(new S_M_LightInfo(deviceList)); //直接通过事件总线触发
                }
                else
                {
                    
                }

            });
            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
