using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCC.Core
{
    public class OCC_Global : SingletonClass<OCC_Global>
    {
        /// <summary>
        /// 记录登陆界面开启状态
        /// </summary>
        public bool OCCLoginUIActived { get; set; }




    }
}
