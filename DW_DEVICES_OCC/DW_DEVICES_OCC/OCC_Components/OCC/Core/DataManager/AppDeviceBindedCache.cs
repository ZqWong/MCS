using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCache
{
    /// <summary>
    /// 设备APP绑关系缓存
    /// </summary>
    public class AppDeviceBindedCache
    {
        public AppDataModel AppData;

        public List<AppDeviceBindDataModel> DeviceBindData;

        public AppDeviceBindedCache() { }

        public AppDeviceBindedCache(AppDataModel app, List<AppDeviceBindDataModel> bind) 
        {
            AppData = app;
            DeviceBindData = bind;
        }


    }
}
