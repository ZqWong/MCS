using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




    }
}
