using Common.Model;
using System;
using System.Data;

namespace MCS.DB.BLL
{

    /// <summary>
    /// 接收文件信息
    /// </summary>
    public class ReceiveFilesInfoBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 查看所有文件信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetFileAppInfo()
        {
            string cmdText = StoredProcedureName.GetFileAppInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        public DataSet GetFileAppinfoByName(string name)
        {
            string cmdText = StoredProcedureName.GetFileAppinfoByName;
            string[] para = { ReceiveFilesModel.ParamName_Name };
            object[] value = { name };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            return ds;
        }

        public DataSet GetFileAppName()
        {
            string cmdText = StoredProcedureName.GetFileAppName;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        /// <summary>
        /// 添加或修改信息。
        /// 修改通过ID 控制 如果id为空，则添加新行
        /// </summary>
        /// <returns></returns>
        public int AddOrUpdateFileInfo(ReceiveFilesModel model)
        {
            string cmdText = StoredProcedureName.AddOrUpdateFileInfo;
            string[] para = {
                ReceiveFilesModel.ParamName_ID,
                ReceiveFilesModel.ParamName_Name,
                ReceiveFilesModel.ParamName_Path,
                ReceiveFilesModel.ParamName_IP,
                ReceiveFilesModel.ParamName_DestPath,

            };

            object[] value = {
                model.ID,
                model.AppName,
                model.Path,
                model.IP,
                model.DestPath,
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns></returns>
        public int DeleteFileInfo(string name)
        {
            string cmdText = StoredProcedureName.DeleteFileInfo;
            string[] para = {
                ReceiveFilesModel.ParamName_Name,
            };
            object[] value = {
                name
            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }


    }
}
