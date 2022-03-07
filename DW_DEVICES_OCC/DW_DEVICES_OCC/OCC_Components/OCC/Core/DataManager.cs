using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace OCC.Core
{
    public class DataManager : LockedSingletonClass<DataManager>
    {

        #region UserData

        public UserDataModel CurrentLoginUserData { get; private set; }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool GetUserData(string username, string password)
        {
            bool ret = false;
            try
            {                
                Debug.Warn($"userName {username}  password  {password}");
                var targetUserData = DataBaseManager.Instance.DB.Queryable<UserDataModel>().First(u => u.LoginName.Equals(username));

                if (null != targetUserData)
                {
                    if (targetUserData.Password.Equals(password))
                    {
                        CurrentLoginUserData = targetUserData;

                        GetUserAuthById(CurrentLoginUserData.UserType);
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


        public UserTypeDataModel CurrentUserAuthData { get; private set; }
        /// <summary>
        /// 获取用户权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GetUserAuthById(int id)
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
                CurrentUserAuthData = targetUserTypeData;
                ret = true;
            }
            catch (Exception ex)
            {
                Debug.Error($"{this} DataManager GetUserAuthById failed {ex}");
                throw;
            }
            return ret;
        }

        #endregion

    }
}
