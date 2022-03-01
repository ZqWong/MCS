using Common.Model;
using System;
using System.Data;

namespace MCS.DB.BLL
{
    /// <summary>
    /// 跟新客户端信息
    /// </summary>
    public class UpdateClientAppInfoBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 查看所有考试信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllUpdateClientinfo()
        {
            string cmdText = StoredProcedureName.GetUpdateClientInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }




        /// <summary>
        /// 添加或修改进程管理信息。
        /// 修改通过ID 控制 如果id为空，则添加新行
        /// </summary>
        /// <returns></returns>
        public int AddOrUpdateUpdateClientInfo(UpdateClientModel model)
        {
            string cmdText = StoredProcedureName.AddOrUpdateUpdateClientInfo;
            string[] para = {
                UpdateClientModel.ParamName_ID,
                UpdateClientModel.ParamName_Path,
                UpdateClientModel.ParamName_IP,

            };

            object[] value = {
                model.ID,
                model.Path,
                model.IP,
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }
    }
}
