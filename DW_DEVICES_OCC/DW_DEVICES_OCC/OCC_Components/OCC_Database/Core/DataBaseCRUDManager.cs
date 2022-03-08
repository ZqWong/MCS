using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

    #endregion


    #region R

    /// <summary>
    /// 获取用户基本信息
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool TryGetUserData(string username, string password, out UserDataModel userData)
    {
        bool ret = false;
        userData = null;
        try
        {
            Debug.Warn($"userName {username}  password  {password}");
            var targetUserData = DataBaseManager.Instance.DB.Queryable<UserDataModel>().First(u => u.LoginName.Equals(username));

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
    public List<UserDataModel> GetAllActivatedUserInfo()
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
    public bool CheckUsernameExist(string username)
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
    public List<DeviceDataModel> GetAllActivatedDeviceInfo()
    {
        List<DeviceDataModel> ret = new List<DeviceDataModel> ();
        try
        {
            var userTypeDatas = DataBaseManager.Instance.DB.Queryable<DeviceDataModel>().Where(d => d.DelFlag.Equals(0)).ToList();
            if (null == userTypeDatas)
            {
                Debug.Error($"Get TryGetAllActivatedDeviceInfo data failed");
            }
            ret = userTypeDatas;
        }
        catch (Exception ex)
        {
            Debug.Error($"{this} DataManager TryGetAllActivatedDeviceInfo failed {ex}");
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
    public void DeleteUserInfoById(string id)
    {
        try
        {
            DataBaseManager.Instance.DB.Deleteable<UserDataModel>().Where(u => u.Id.Equals(id)).IsLogic().ExecuteCommand("del_flag");
        }
        catch (Exception ex)
        {
            Debug.Error($"DataBaseCRUDManager DeleteUserInfoById failed {ex}");
            throw;
        }
    }

    #endregion
}