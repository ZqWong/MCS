using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCache;
using DataModel;

namespace OCC.Core
{
    public class DataManager : LockedSingletonClass<DataManager>
    {
        #region App Data

        /// <summary>
        /// 所有系统以及绑定设备信息
        /// </summary>
        public List<AppDeviceBindedCache> AppDeviceBindedCollection = new List<AppDeviceBindedCache>();

        /// <summary>
        /// App数据
        /// </summary>
        private List<AppDataModel> app = new List<AppDataModel>();

        /// <summary>
        /// 获取系统信息
        /// </summary>
        public void GetAppData()
        {
            try
            {
                AppDeviceBindedCollection.Clear();
                app.Clear();
                if(DataBaseCRUDManager.Instance.TryGetAllAppDataInfo(out app))
                {      
                    foreach (AppDataModel app in app)
                    {
                        List<AppDeviceBindDataModel> appDeviceBinded = new List<AppDeviceBindDataModel>();
                        AppDeviceBindedCache cache = new AppDeviceBindedCache();              
                        cache.AppData = app;
                        if (DataBaseCRUDManager.Instance.TryGetAppDeviceBindDataInfoByAppId(app.Id, out appDeviceBinded))
                        {                                                     
                            cache.DeviceBindData = appDeviceBinded;                        
                        }
                        AppDeviceBindedCollection.Add(cache);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Error($"{this} AppInfoCollection failed : {ex}");
            }
        }

        /// <summary>
        /// 通过系统名获取对应绑定数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AppDeviceBindedCache GetAppDeviceBindedCacheByAppName(string name)
        {
            return AppDeviceBindedCollection.FirstOrDefault(ad => ad.AppData.AppName.Equals(name));
        }


        #endregion

        #region Device Data

        /// <summary>
        /// 设备数据
        /// </summary>
        private List<DeviceDataModel> deviceInfoCoollection = new List<DeviceDataModel>();

        /// <summary>
        /// 设备状态缓存
        /// </summary>
        public List<DeviceStatusCache> DeviceInfoCollection = new List<DeviceStatusCache>();

        /// <summary>
        /// 获取设备信息
        /// </summary>
        public void GetDeviceData()
        {
            try
            {
                deviceInfoCoollection.Clear();
                DeviceInfoCollection.Clear();

                if (DataBaseCRUDManager.Instance.TryGetAllDeviceInfo(out deviceInfoCoollection))
                {
                    if (deviceInfoCoollection.Count > 0)
                    {
                        for (int i = 0; i < deviceInfoCoollection.Count; i++)
                        {
                            // 对设备状态进行缓存
                            DeviceInfoCollection.Add(new DeviceStatusCache(i, DevicePowerStatus.CLOSED, deviceInfoCoollection[i]));
                            Debug.Info($" index {i} {deviceInfoCoollection[i].Name}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Error($"{this} GetDeviceData failed : {ex}");                
            }            
        }

        /// <summary>
        /// 通过ID获取设备信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeviceStatusCache GetDeviceDataById(string id)
        {
            return DeviceInfoCollection.FirstOrDefault(d => d.DataModel.Id.Equals(id));
        }

        #endregion



        #region UserData

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        public UserDataModel CurrentLoginUserData;

        /// <summary>
        /// 当前登录用户权限信息
        /// </summary>
        public UserTypeDataModel CurrentUserAuthData;




        #endregion

        #region Commom Info

        /// <summary>
        /// 公司信息
        /// </summary>
        public List<CompanyDataModel> CompanyDatas;

        /// <summary>
        /// 用户类型信息
        /// </summary>
        public List<UserTypeDataModel> UserTypeDatas;

        /// <summary>
        /// 设备类型列表
        /// </summary>
        public List<DeviceTypeDataModel> DeviceTypeCollection;


        /// <summary>
        /// 获取一些通用数据
        /// </summary>
        public void GetCommonInfos()
        {
            CompanyDatas = new List<CompanyDataModel>();
            if (DataBaseCRUDManager.Instance.TryGetAllCompanyInfo(out CompanyDatas))
            {
                
            }
            UserTypeDatas = new List<UserTypeDataModel>();
            if (DataBaseCRUDManager.Instance.TryGetAllUserTypeInfo(out UserTypeDatas))
            {

            }
            DeviceTypeCollection = new List<DeviceTypeDataModel>();
            if (DataBaseCRUDManager.Instance.TryGetAllDeviceTypeInfo(out DeviceTypeCollection))
            {

            }
        }

              
        #endregion

    }
}
