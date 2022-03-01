using Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCS.DB.BLL
{
    public class SystemBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 获取所有系统信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllSystemInfo()
        {
            string cmdText = StoredProcedureName.GetAllSystemInfo;
            string[] para = { };
            object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        /// <summary>
        /// 修改系统信息
        /// </summary>
        /// <returns></returns>
        public int UpdSystemInfo(SystemModel model)
        {
            string cmdText = StoredProcedureName.UpdSystemInfo;
            string[] para = {
                            SystemModel.ParamName_ID,
                            SystemModel.ParamName_LastDatabaseBackupTime,
                            SystemModel.ParamName_LastSystemLogCleanupTime
                            };
            object[] value = {
                            model.ID,
                            model.LastDatabaseBackupTime,
                            model.LastSystemLogCleanupTime
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }
    }
}
