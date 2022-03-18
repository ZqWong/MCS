using OCC.Core;
using OCC.Core.LocalConfig;
using System;
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
            Debug.Info($"OCC System loading...");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ProcessInstanceCheck.InstanceCheck(() =>
            {       
                LocalConifgManager.Instance.OnInitialized = () =>
                {                   
                    Debug.Info($"Lanuch");
                    Application.Run(new OCC());   
                };
                LocalConifgManager.Instance.Initialize();              
            });           
        }

    }
}
