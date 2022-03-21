using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCache;
using DataModel;
using OCC.Core.LocalConfig;

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
                throw ex;
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
                throw ex;
            }            
        }

        /// <summary>
        /// 通过ID获取设备信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeviceStatusCache GetDeviceDataById(int id)
        {
            return DeviceInfoCollection.FirstOrDefault(d => d.DataModel.Id.Equals(id));
        }

        public DeviceStatusCache GetDeviceDataByName(string name)
        {
            return DeviceInfoCollection.FirstOrDefault(d => d.DataModel.Name.Equals(name));
        }

        /// <summary>
        /// 通过ID获取设备操作信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeviceExecuteDataModel GetDeviceExecuteById(int id)
        {
            return DeviceExecuteCollection.FirstOrDefault(e => e.Id.Equals(id));
        }

        public DeviceExecuteDataModel GetDeviceExecuteByName(string name)
        {
            return DeviceExecuteCollection.FirstOrDefault(e => e.Name.Equals(name));
        }

        #endregion

        #region Group Data

        private List<GroupDataModel> groupInfo = new List<GroupDataModel>();
        public List<GroupDataCache> GroupInfoCollection = new List<GroupDataCache>();

        public void GetGroupData()
        {
            try
            {
                GroupInfoCollection.Clear();

                bool ret = false;

                ret = LocalConifgManager.Instance.SystemConfig.DataModel.GroupInfoByCompany ?
                    DataBaseCRUDManager.Instance.TryGetAllGroupInfo(out groupInfo) :
                    DataBaseCRUDManager.Instance.TryGetAllGroupInfoByCompanyId(DataManager.Instance.CurrentLoginUserData.CompanyId, out groupInfo);

                if (ret)
                {
                    foreach (GroupDataModel group in groupInfo)
                    {                      
                        if (!GroupInfoCollection.Exists(g => g.GroupId.Equals(group.Id)))
                        {
                            List<GroupDeviceExecuteDataModel> groupDeviceExecutes = new List<GroupDeviceExecuteDataModel>();
                            GroupDataCache cache = new GroupDataCache();
                            cache.GroupId = group.Id;
                            cache.GroupName = group.Name;
                            cache.GroupData = group;
                            DataBaseCRUDManager.Instance.TryGetAllGroupDeviceExecuteInfoByGroupId(group.Id, out groupDeviceExecutes);
                            cache.GroupExecuteDatas = groupDeviceExecutes;
                            GroupInfoCollection.Add(cache);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Error($"{this} GetDeviceData failed : {ex}");
                throw ex;
            }
        }

        public GroupDataCache GetGroupDataByName(string name)
        {
            return GroupInfoCollection.FirstOrDefault(g => g.GroupName.Equals(name));
        }

        public GroupDataCache GetGroupDataById(int id)
        {
            return GroupInfoCollection.FirstOrDefault(g => g.GroupId.Equals(id));
        }

        #endregion

        #region User Data

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
        /// 设备操作列表
        /// </summary>
        public List<DeviceExecuteDataModel> DeviceExecuteCollection;

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
            DeviceExecuteCollection = new List<DeviceExecuteDataModel>();
            if (DataBaseCRUDManager.Instance.TryGetAllExecuteDataInfo(out DeviceExecuteCollection))
            {

            }
        }

              
        public int GetCompanyIdByName(string companyName)
        {
            int ret = -1;

            var company = CompanyDatas.FirstOrDefault(c => c.Name.Equals(companyName));
            if (null != company)
            {
                ret = company.Id;
            }
            return ret;
        }

        public string GetCompanyNameById(int id)
        {
            string ret = string.Empty;

            var company = CompanyDatas.FirstOrDefault(c => c.Id.Equals(id));
            if (null != company)
            {
                ret = company.Name;
            }
            return ret;
        }

        public List<DeviceExecuteDataModel> GetTargetDeiveExecuteByDeviceTypeId(int deviceTypeId)
        {
            return DeviceExecuteCollection.FindAll(e => e.DeviceTypeId.Equals(deviceTypeId));
        }

        #endregion

    }
}
