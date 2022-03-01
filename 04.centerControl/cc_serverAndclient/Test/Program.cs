using System;
using DW_CC_NET.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            string currentPath = System.Environment.CurrentDirectory;

            Console.WriteLine(string.Format("当前路径 ：{0}", currentPath));

            Console.WriteLine(string.Format("父目录全路径 ：{0}", ComFunc.GetSingleton().GetParentPath(currentPath)));

            Console.WriteLine(string.Format("父目录文件夹名称 ：{0}", ComFunc.GetSingleton().GetParentFolderName(currentPath)));

            string currentFullName = Application.ExecutablePath;

            Console.WriteLine(string.Format("当前进程fullName ：{0}", currentFullName));

            Console.WriteLine(string.Format("父目录全路径 ：{0}", ComFunc.GetSingleton().GetParentPath(currentFullName)));

            Console.WriteLine(string.Format("父目录文件夹名称 ：{0}", ComFunc.GetSingleton().GetParentFolderName(currentFullName)));

            Console.WriteLine(string.Format("执行文件名称 ：{0}", ComFunc.GetSingleton().GetName(currentFullName)));

            Console.ReadLine();

        }
    }
}
