using EventGroup.RabbitMQ;
using OCC.Core;
using OCC.Core.LocalConfig;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.Error($"OCC System loading...");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ProcessInstanceCheck.InstanceCheck(() =>
            {       
                LocalConifgManager.Instance.OnInitialized = () =>
                {
                    try
                    {
                        //RabbitMQManager.Instance.Initialize("event_bus", GetIP(), Process.GetCurrentProcess().ProcessName, "topic", "client_duowei", "192.169.0.198", "duowei");
                        //RabbitMQManager.Instance.Initialize("event_bus", NetworkHelper.GetIP(), Process.GetCurrentProcess().ProcessName, "topic", "client_duowei", "127.0.0.1", "duowei");

                        RabbitMQManager.Instance.Initialize(
                            LocalConifgManager.Instance.SystemConfig.DataModel.RabbitMQBrokerName,
                            NetworkHelper.GetIP(),
                            Process.GetCurrentProcess().ProcessName,
                            LocalConifgManager.Instance.SystemConfig.DataModel.RabbitMQExchangeType,
                            LocalConifgManager.Instance.SystemConfig.DataModel.Username,
                            "127.0.0.1",
                            //"192.169.0.198",
                            LocalConifgManager.Instance.SystemConfig.DataModel.Password);


                        RabbitMQManager.Instance.RegisterAllEventHandlerFromAssembly(Assembly.GetExecutingAssembly());
                        RabbitMQManager.Instance.CreatePluginEventConsumerChannel();
                    }
                    catch (Exception ex)
                    {
                        Debug.Error($"[OCC] RabbitMQ Initialize failed :{ex}");
                    }

                    Debug.Info($"Lanuch");
                    Application.Run(new OCC());
                };
                LocalConifgManager.Instance.Initialize();              
            });           
        }
    }
}
