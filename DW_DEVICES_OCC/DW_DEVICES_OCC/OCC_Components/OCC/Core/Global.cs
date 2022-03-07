using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Core
{
    public class Global : LockedSingletonClass<Global>
    {
        /// <summary>
        /// 获取应用路径
        /// </summary>
        public string ApplicationBasePath => AppDomain.CurrentDomain.SetupInformation.ApplicationBase;        

        /// <summary>
        /// 记录登陆界面开启状态
        /// </summary>
        public bool OCCLoginUIActived { get; set; }


        /// <summary>
        /// 获取工作区高度（不包含任务栏）
        /// </summary>
        public int ScreenHeightWithoutTaskBar => Screen.PrimaryScreen.Bounds.Height;
        /// <summary>
        /// 获取工作区宽度（不包含任务栏）
        /// </summary>
        public int ScreenWidthWithoutTaskBar => Screen.PrimaryScreen.Bounds.Width;
        /// <summary>
        /// 获取工作区高度（包含任务栏）
        /// </summary>
        public int ScreenHeightWithTaskBar => Screen.PrimaryScreen.Bounds.Height;
        /// <summary>
        /// 获取工作区宽度（包含任务栏）
        /// </summary>
        public int ScreenWidthWithTaskBar => Screen.PrimaryScreen.Bounds.Width;

    }
}
