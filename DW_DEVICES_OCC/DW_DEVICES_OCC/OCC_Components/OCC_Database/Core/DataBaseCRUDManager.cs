using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 统一一下注释, 添加异常抛出
/// </summary>

public class DataBaseCRUDManager : LockedSingletonClass<DataBaseCRUDManager>
{
    #region C

    /// <summary>
    /// 创建新用户
    /// </summary>
    /// <param name="userData"></param>
    /// <returns></returns>
    public bool TryCreateUserInfo(UserDataModel userData)
    {
        bool ret = false;
        try
        {
            int newUser = DataBaseManager.Instance.DB.Insertable(userData).ExecuteCommand();
            if (newUser >= 1)
                ret = true;
        }
        catch (Exception)
        {

            throw;
        }     
        return ret;
    }

    /// <summary>
    /// 创建新设备
    /// </summary>
    /// <param name="deviceData"></param>
    /// <returns></returns>
    public bool TryCreateOrUpdateDeviceInfo(DeviceDataModel deviceData)
    {
        bool ret = false;
        try
        {
            int execute = 0;
            var x = DataBaseManager.Instance.DB.Storageable<DeviceDataModel>(deviceData).ToStorage();
            execute = x.AsUpdateable.ExecuteCommand();
            execute = x.AsInsertable.ExecuteCommand();

            //int newDevice =DataBaseManager.Instance.DB.Insertable(deviceData).ExecuteCommand();
            if (execute >= 1)
                ret = true;
        }
        catch (Exception)
        {

            throw;
        }
        return ret;
    }

    /// <summary>
    /// 创建新APP
    /// </summary>
    /// <param name="deviceData"></param>
    /// <returns></returns>
    public bool TryCreateOrUpdateAppInfo(AppDataModel appData)
    {
        bool ret = false;
        try
        {
            int newDevice = DataBaseManager.Instance.DB.Insertable(appData).ExecuteCommand();
            if (newDevice >= 1)
                ret = true;
        }
        catch (Exception)
        {

            throw;
        }
        return ret;
    }

    /// <summary>
    /// 创建新的设备系统绑定
    /// </summary>
    /// <param name="appDeviceData"></param>
    /// <returns></returns>
    public bool TryCreateAppAndDeviceBindInfo(List<AppDeviceBindDataModel> appDeviceData)
    {
        bool ret = false;
        try
        {
            int newData = DataBaseManager.Instance.DB.Insertable(appDeviceData).ExecuteCommand();
            if (newData >= 1)
            {
                ret = true;
            }
        }
        catch (Exception)
        {

            throw;
        }
        return ret;
    }
    

    
    #endregion 


    #region R

    /// <summary>
    /// 获取用户基本信息
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool TryGetUserInfo(string username, string password, out UserDataModel userData)
    {
        bool ret = false;
        userData = null;
        try
        {
            Debug.Warn($"userName {username}  password  {password}");
            var targetUserData = DataBaseManager.Instance.DB.Queryable<UserDataModel>().First(u => u.LoginName.Equals(username) && u.DelFlag.Equals(0));

            if (null != targetUserData)
            {
                if (targetUserData.Password.Equals(password))
                {
                    userData = targetUserData;
                    ret = true;
                }
            }
            else
            {
                Debug.Error($"Get user data failed, username : {username} password : {password}");
                // TODO: 添加弹出提示框
            }
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager GetUserData failed {ex}");
        }
        return ret;
    }

    /// <summary>
    /// 获取所有激活状态的用户信息
    /// </summary>
    /// <returns></returns>
    public List<UserDataModel> TryGetAllUserInfo()
    {
        List<UserDataModel> ret = new List<UserDataModel>();
        try
        {
            ret = DataBaseManager.Instance.DB.Queryable<UserDataModel>().Where(u => u.DelFlag.Equals(0)).ToList();
        }
        catch (Exception ex)
        {
            Debug.Error($"DataBaseCRUDManager TryGetUserData failed {ex}");
            throw;
        }
        return ret;
       
    }

    /// <summary>
    /// 检测用户名重复
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public bool TryCheckUsernameExist(string username)
    {
        bool ret = false;
        try
        {
            Debug.Warn($"userName {username}");

            // 检测用户名重复，且用户不能被删除
            var targetUserData = DataBaseManager.Instance.DB.Queryable<UserDataModel>().First(u => u.LoginName.Equals(username) && u.DelFlag.Equals(0));

            if (null != targetUserData)
            {
                ret = true;
            }
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager CheckUsernameExist failed {ex}");
            return false;
        }
        return ret;
    }

    /// <summary>
    /// 获取用户权限信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool TryGetUserAuthById(int id, out UserTypeDataModel authData)
    {
        bool ret = false;
        try
        {
            var targetUserTypeData = DataBaseManager.Instance.DB.Queryable<UserTypeDataModel>().First(a => a.Id.Equals(id));
            if (null == targetUserTypeData)
            {
                Debug.Error($"Get user auth data failed, auth table id {id}");
                // TODO: 添加弹出提示框
            }
            authData = targetUserTypeData;
            ret = true;
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager GetUserAuthById failed {ex}");
            throw;
        }
        return ret;
    }


    /// <summary>
    /// 获取企业信息
    /// </summary>
    /// <returns></returns>
    public bool TryGetAllCompanyInfo(out List<CompanyDataModel> companysInfo)
    {
        bool ret = false;
        try
        {
            var companys = DataBaseManager.Instance.DB.Queryable<CompanyDataModel>().ToList();
            if (null == companys)
            {
                Debug.Error($"Get company info data failed");
                // TODO: 添加弹出提示框
            }
            companysInfo = companys;
            ret = true;
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager GetCompanyInfo failed {ex}");
            throw;
        }
        return ret;
    }


    /// <summary>
    /// 获取用户类型信息
    /// </summary>
    /// <returns></returns>
    public bool TryGetAllUserTypeInfo(out List<UserTypeDataModel> authData)
    {
        bool ret = false;
        try
        {
            var userTypeDatas = DataBaseManager.Instance.DB.Queryable<UserTypeDataModel>().ToList();
            if (null == userTypeDatas)
            {
                Debug.Error($"Get company info data failed");
                // TODO: 添加弹出提示框
            }
            authData = userTypeDatas;
            ret = true;
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager GetCompanyInfo failed {ex}");
            throw;
        }
        return ret;
    }


    /// <summary>
    /// 硬件设备信息
    /// </summary>
    /// <param name="deviceDatas"></param>
    /// <returns></returns>
    public bool TryGetAllDeviceInfo(out List<DeviceDataModel> deviceData)
    {
        bool ret = false;
        try
        {
            var deviceDatas = DataBaseManager.Instance.DB.Queryable<DeviceDataModel>().Where(d => d.DelFlag.Equals(0)).ToList();
            if (null == deviceDatas)
            {
                Debug.Error($"Get TryGetAllActivatedDeviceInfo data failed");
            }
            deviceData = deviceDatas;
            ret = true;
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager TryGetAllActivatedDeviceInfo failed {ex}");
            throw;
        }
        return ret;
    }

    /// <summary>
    /// 获取设备类型数据
    /// </summary>
    /// <returns></returns>
    public bool TryGetAllDeviceTypeInfo(out List<DeviceTypeDataModel> deviceTypeData)
    {
        bool ret = false;      
        try
        {
            var types = DataBaseManager.Instance.DB.Queryable<DeviceTypeDataModel>().Where(t => t.DelFlag.Equals(0)).ToList();
            if (null == types)
            {
                Debug.Error($"{this} Get GetAllDeviceTypeInfo data failed");
            }
            deviceTypeData = types;
            ret = true;
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager GetAllDeviceTypeInfo failed {ex}");
            throw;
        }
        return ret;
    }


    public bool TryGetAllAppDataInfo(out List<AppDataModel> appData)
    {
        bool ret = false;
        try
        {
            var apps = DataBaseManager.Instance.DB.Queryable<AppDataModel>().Where(a => a.DelFlag.Equals(0)).ToList();
            if (null == apps)
            {
                Debug.Error($"{this} Get TryGetAllAppDataInfo data failed");
            }
            appData = apps;
            ret = true;
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager GetAllDeviceTypeInfo failed {ex}");
            throw;
        }
        return ret;
    }

    public bool TryGetAppDeviceBindDataInfoByAppId(string appId, out List<AppDeviceBindDataModel> appDeviceBindData)
    {
        bool ret = false;
        try
        {
            var binds = DataBaseManager.Instance.DB.Queryable<AppDeviceBindDataModel>().Where(ad => ad.AppId.Equals(appId) && ad.DelFlag.Equals(0)).ToList();
            if (null == binds)
                Debug.Error($"{this} Get TryGetAppDeviceBindDataInfoByAppId data failed");
            appDeviceBindData = binds;
            ret = true;
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager TryGetAppDeviceBindDataInfoByAppId failed {ex}");
            throw;
        }
        return ret;
    }


    #endregion

    #region U

    public void TryUpdateUserInfoById(UserDataModel userData)
    {
        try
        {
            var result = DataBaseManager.Instance.DB.Updateable<UserDataModel>(userData).ExecuteCommand(); ;
        }
        catch (Exception ex)
        {
            Debug.Error($"DataBaseCRUDManager TryUpdateUserInfoById failed {ex}");
            throw;
        }
     
    }


    #endregion


    #region D

    /// <summary>
    /// 删除用户信息（假删除）
    /// </summary>
    /// <param name="id"></param>
    public bool DeleteUserInfoById(string id)
    {
        bool ret = false;
        try
        {
            int count = DataBaseManager.Instance.DB.Deleteable<UserDataModel>().Where(u => u.Id.Equals(id)).IsLogic().ExecuteCommand("del_flag");
            if (count >= 1)
            {
                ret = true; ;
            }          
        }
        catch (Exception ex)
        {
            Debug.Error($"DataBaseCRUDManager DeleteUserInfoById failed {ex}");
            throw;
        }
        return ret;
    }


    /// <summary>
    /// 删除设备信息（假删除）
    /// </summary>
    /// <param name="id"></param>
    public bool DeleteDeviceInfoById(string id)
    {
        bool ret = false;
        try
        {
            int count = DataBaseManager.Instance.DB.Deleteable<DeviceDataModel>().Where(d => d.Id.Equals(id)).IsLogic().ExecuteCommand("del_flag");
            if (count >= 1)
            {
                DataBaseManager.Instance.DB.Deleteable<AppDeviceBindDataModel>().Where(ad => ad.DeviceId.Equals(id)).IsLogic().ExecuteCommand("del_flag");
                ret = true; ;
            }            
        }
        catch (Exception ex)
        {
            Debug.Error($"DataBaseCRUDManager DeleteDeviceInfoById failed {ex}");
            throw;
        }
        return ret;
    }

    /// <summary>
    /// 删除APP信息（假删除）
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteAppInfoById(string id)
    {
        bool ret = false;
        try
        {
            int count = DataBaseManager.Instance.DB.Deleteable<AppDataModel>().Where(d => d.Id.Equals(id)).IsLogic().ExecuteCommand("del_flag");
            if (count >= 1)
            {
                DataBaseManager.Instance.DB.Deleteable<AppDeviceBindDataModel>().Where(ad => ad.AppId.Equals(id)).IsLogic().ExecuteCommand("del_flag");
                ret = true; ;
            }
        }
        catch (Exception ex)
        {
            Debug.Error($"DataBaseCRUDManager DeleteAppInfoById failed {ex}");
            throw;
        }
        return ret;
    }


    #endregion
}