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
    public class M_ProjectControlHander : IEventHandler<M_S_ProjectControl>
    {
        public void HandleEvent(M_S_ProjectControl eventData)
        {

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(async () =>
            {
                string deviceClassName = "投影";

                string deviceIPs = "";
                string deviceNames = "";

                foreach (string deviceInfo in eventData.projectIPList)
                {
                    if (deviceInfo.Contains(","))
                    {
                        deviceIPs += string.Format("'{0}',", deviceInfo.Split(',')[0]);
                        deviceNames += string.Format("'{0}',", deviceInfo.Split(',')[1]);
                    }
                    else
                    {
                        deviceIPs += string.Format("'{0}',", deviceInfo);
                    }
                }

                if (eventData.projectIPList.Count == 0)
                {
                    return;
                }

                // 删除最后一个逗号
                deviceIPs = deviceIPs.Substring(0, deviceIPs.Length - 1);
                DataRow[] dr;
                if (deviceNames == "")
                {
                    dr = 其他设备控制.GetSingleton().ds_device_all.Tables[0].Select(string.Format("{0} = '{1}' and {2} in ({3})", DeviceControlModel.DB_CLASS, deviceClassName, DeviceControlModel.DB_IP, deviceIPs));
                }
                else
                {
                    deviceNames = deviceNames.Substring(0, deviceNames.Length - 1);
                    dr = 其他设备控制.GetSingleton().ds_device_all.Tables[0].Select(string.Format("{0} = '{1}' and {2} in ({3}) and {4} in ({5})", DeviceControlModel.DB_CLASS, deviceClassName, DeviceControlModel.DB_IP, deviceIPs, DeviceControlModel.ColumnName_Name, deviceNames));
                }


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
                        
                    if (其他设备控制.GetSingleton().deviceDict.ContainsKey(deviceClassName))
                    {
                        List<string> condeNameList = 其他设备控制.GetSingleton().deviceDict[deviceClassName].controlCodeDict
                            .Where(q => q.Value.code == eventData.controlCode).Select(q => q.Key).ToList();

                        if (condeNameList.Count != 1)
                        {
                            return;
                        }
                        else
                        {
                            await Task.Run(() => 其他设备控制.GetSingleton().DeviceControl(deviceList, condeNameList[0]));

                            RabbitMQEventBus.GetSingleton()
                                .Trigger<S_M_ProjectControlReply>(new S_M_ProjectControlReply(eventData.controlCode)); //直接通过事件总线触发
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    
                }

            });
            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
