using Common.Model;
using System.Data;

namespace MCS.DB.BLL
{
    public class UserBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public int AddUserInfo(UserModel model)
        {
            string cmdText = StoredProcedureName.AddUserInfo;
            string[] para = { UserModel.ParamName_UserName, UserModel.ParamName_Password, UserModel.ParamName_Level };
            object[] value = { model.UserName, model.Password, model.Level };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 获取所有User
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllUserInfo()
        {
            string cmdText = StoredProcedureName.GetAllUserInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);
            return ds;
        }

        /// <summary>
        /// 获取指定User
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllUserInfoByID(string id)
        {
            string cmdText = StoredProcedureName.GetAllUserInfoByID;
            string[] para = { UserModel.ParamName_ID, };
            object[] value = { id };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);
            return ds;
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public int IsUserExist(UserModel model)
        {
            string cmdText = StoredProcedureName.IsUserExist;
            string[] para = { UserModel.ParamName_UserName, UserModel.ParamName_Password };
            object[] value = { model.UserName, model.Password };
            object count = SqlHelper.ExecuteSqlForCount(CommandType.StoredProcedure, cmdText, para, value);
            return int.Parse(count.ToString());
        }

        /// <summary>
        /// 判断用户名是否存在
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public int IsUserNameExist(string userName)
        {
            string cmdText = StoredProcedureName.IsUserNameExist;
            string[] para = { UserModel.ParamName_UserName };
            object[] value = { userName };
            object count = SqlHelper.ExecuteSqlForCount(CommandType.StoredProcedure, cmdText, para, value);
            return int.Parse(count.ToString());
        }

        /// <summary>
        /// 修改用户帐号和密码
        /// </summary>
        /// <returns></returns>
        public int UpdUserInfo(UserModel model)
        {
            string cmdText = StoredProcedureName.UpdUserInfo;
            string[] para = {
                            UserModel.ParamName_ID,
                            UserModel.ParamName_UserName,
                            UserModel.ParamName_Password
                            };
            object[] value = {
                            model.ID,
                            model.UserName,
                            model.Password
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 删除指定考生
        /// </summary>
        /// <returns></returns>
        public int DelUserInfo(string id)
        {
            string cmdText = StoredProcedureName.DelUserInfo;
            string[] para = {
                            UserModel.ParamName_ID
                            };
            object[] value = {
                            id
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <returns></returns>
        public string GetUserLevelByUserName(string userName)
        {
            string UserLevel = "";

            string cmdText = StoredProcedureName.GetUserLevelByUserName;
            string[] para = { UserModel.ParamName_UserName, };
            object[] value = { userName };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            if (ds.Tables[0].Rows.Count > 0)
            {
                UserLevel = ds.Tables[0].Rows[0][UserModel.ColumnName_Level].ToString();
            }

            return UserLevel;
        }
    }
}
