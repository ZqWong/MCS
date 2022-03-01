using Common.Model;
using System;
using System.Data;

namespace MCS.DB.BLL
{
    /// <summary>
    /// 考试信息相关业务逻辑
    /// </summary>
    public class ProcessControlAppInfoBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 查看所有考试信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllAppinfo()
        {
            string cmdText = StoredProcedureName.GetAllAppInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        public DataSet GetAllAppinfoByName(string name)
        {
            string cmdText = StoredProcedureName.GetAllAppInfoByName;
            string[] para = { ProcessControlModel.ParamName_Name };
            object[] value = { name };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            return ds;
        }

        public DataSet GetAppName()
        {
            string cmdText = StoredProcedureName.GetProcessControlAppName;
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
        public int AddOrUpdateProgressControlInfo(ProcessControlModel model)
        {
            string cmdText = StoredProcedureName.AddOrUpdateProcessControlInfo;
            string[] para = {
                ProcessControlModel.ParamName_ID,
                ProcessControlModel.ParamName_Name,
                ProcessControlModel.ParamName_Path,
                ProcessControlModel.ParamName_IP,

            };

            object[] value = {
                model.ID,
                model.AppName,
                model.Path,
                model.IP,
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 删除考试信息
        /// </summary>
        /// <returns></returns>
        public int DelProcessControlInfoByAppName(string name)
        {
            string cmdText = StoredProcedureName.DelProcessControlInfoByAppName;
            string[] para = {
                ProcessControlModel.ParamName_Name,
            };
            object[] value = {
                name
            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }


        /// <summary>
        /// 修改考试信息
        /// </summary>
        /// <returns></returns>
        public int UpdExaminationInfo(ExaminationModel model)
        {
            string cmdText = StoredProcedureName.UpdExaminationInfo;
            string[] para = {
                ExaminationModel.ParamName_ExaminationID,
                ExaminationModel.ParamName_ExaminationName,
                ExaminationModel.ParamName_PaperCompilingMode,
                ExaminationModel.ParamName_TotalScore,
                ExaminationModel.ParamName_ExaminationPassScore,
                ExaminationModel.ParamName_ExaminationTime,
            };

            object[] value = {
                model.ExaminationID,
                model.ExaminationName,
                model.PaperCompilingMode,
                model.TotalScore,
                model.ExaminationPassScore,
                model.ExaminationTime
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

    }
}
