using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCache;
using DataModel;
using OCC.Forms.OCC_Controls;

namespace OCC.Core
{
    public class DataManager : LockedSingletonClass<DataManager>
    {
        #region App Data

        public List<AppDeviceBindedCache> AppDeviceBindedCollection = new List<AppDeviceBindedCache>();

        /// <summary>
        /// App数据
        /// </summary>
        private List<AppDataModel> AppInfoCollection = new List<AppDataModel>();
        /// <summary>
        /// APP与设备绑定数据
        /// </summary>
        private List<AppDeviceBindDataModel> AppDeviceBindCollection = new List<AppDeviceBindDataModel>();

        public void GetAppData()
        {
            try
            {
                AppDeviceBindedCollection.Clear();
                AppInfoCollection.Clear();
                if(DataBaseCRUDManager.Instance.TryGetAllAppDataInfo(out AppInfoCollection))
                {      
                    foreach (AppDataModel app in AppInfoCollection)
                    {
                        AppDeviceBindCollection.Clear();
                        AppDeviceBindedCache cache = new AppDeviceBindedCache();
                        cache.AppData = app;
                        if (DataBaseCRUDManager.Instance.TryGetAppDeviceBindDataInfoByAppId(app.Id, out AppDeviceBindCollection))
                        {                                                     
                            cache.DeviceBindData = AppDeviceBindCollection;                        
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





        public List<DeviceTypeDataModel> DeviceTypeCollection = new List<DeviceTypeDataModel>();
        public void GetDeviceTypes()
        {
            if (DataBaseCRUDManager.Instance.TryGetAllDeviceTypeInfo(out DeviceTypeCollection))
            {

            }            
        }

        #endregion



        #region UserData

        public UserDataModel CurrentLoginUserData;


        public UserTypeDataModel CurrentUserAuthData;




        #endregion

        #region Commom Info

        public List<CompanyDataModel> CompanyDatas;

        public List<UserTypeDataModel> UserTypeDatas;

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
        }



        
      
        #endregion

    }
}
