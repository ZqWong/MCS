using OCC.Core;
using OCC.Core.LocalConfig;
using OCC.Forms;
using RabbitMQEvent;
using SqlSugar;
using System;
using System.Diagnostics;
using System.Reflection;
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
                   
                    /// 数据库读取
                    try
                    {
                        DataBaseInitialize();
                    }
                    catch (Exception ex)
                    {

                        Debug.Error($"[OCC] Database Initialize failed :{ex}");
                    }

                    Debug.Info($"Lanuch");
                    if (LocalConifgManager.Instance.SystemConfig.DataModel.ShowLoginForm)
                    {
                        Application.Run(new OCC_Login());
                    }
                    else
                    {
                        Application.Run(new OCC());
                    }       
                };
                LocalConifgManager.Instance.Initialize();              
            });           
        }

        public static void DataBaseInitialize()
        {
#if DEBUG
            string server = "127.0.0.1";
#else
            //TODO: 通过配置读取真正的服务器地址
            string server = "192.168.0.198"; 
#endif
            var connectionString = string.Format(
                DataBaseConst.SQL_SUGAR_CONNECTION_STRING_FORMAT,
                server,
                "occ",
                "root",
                "duowei",
                null,
                true);

            DataBaseManager.Instance.Initialize(connectionString, true, DbType.MySql, true);
        }
    }
}
