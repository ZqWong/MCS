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
    public class M_7THControlHander : IEventHandler<M_S_7THControl>
    {
        public void HandleEvent(M_S_7THControl eventData)
        {

            // 跨线程修改winform
            MethodInvoker mi = new MethodInvoker(async () =>
            {
                string className7th = "7th主机";
                // s_device_all.Tables[0].Select(string.Format("{0} in ({1})", DeviceControlModel.DB_Name, deviceName));
                DataRow[] dr = 其他设备控制.GetSingleton().ds_device_all.Tables[0].Select(string.Format("{0} = '{1}'", DeviceControlModel.DB_CLASS, className7th));

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

                    if (其他设备控制.GetSingleton().deviceDict.ContainsKey(className7th))
                    {
                        Debug.WriteLine(eventData.controlCode);
                        Debug.WriteLine(@eventData.controlCode);
                        Debug.WriteLine("need control code :" + 其他设备控制.GetSingleton().deviceDict[className7th].controlCodeDict["双眼网格"].code);

                        List<string> condeNameList = 其他设备控制.GetSingleton().deviceDict[className7th].controlCodeDict
                            .Where(q => q.Value.code == eventData.controlCode).Select(q => q.Key).ToList();

                        if (condeNameList.Count != 1)
                        {
                            return;
                        }
                        else
                        {
                            await Task.Run(() => 其他设备控制.GetSingleton().DeviceControl(deviceList, condeNameList[0]));

                            RabbitMQEventBus.GetSingleton()
                                .Trigger<S_M_7THControlReply>(new S_M_7THControlReply(eventData.controlCode)); //直接通过事件总线触发
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    NlogHandler.GetSingleton().Error("数据库中并不存在类型名称为 7th主机 的设备类型，请添加7th主机 类型并控制");
                }

            });
            主界面.GetSingleton().BeginInvoke(mi);
        }
    }
}
