using Common.Model;
using System;
using System.Data;

namespace MCS.DB.BLL
{
    /// <summary>
    /// 考试信息相关业务逻辑
    /// </summary>
    public class ExaminationBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 查看所有考试信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllExaminationInfo()
        {
            string cmdText = StoredProcedureName.GetAllExaminationInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        /// <summary>
        /// 根据考试编号获取考试信息
        /// </summary>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        public DataSet GetExaminationInfoByExaminationID(string examinationID)
        {
            string cmdText = StoredProcedureName.GetExaminationInfoByExaminationID;
            string[] para = { ExaminationModel.ParamName_ExaminationID };
            object[] value = { examinationID };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            return ds;
        }

        // add by wuxin at 2019/12/03 - start
        /// <summary>
        /// 获取最新的考试编号
        /// </summary>
        /// <returns></returns>
        public int GetLatestExaminationID()
        {
            string cmdText = StoredProcedureName.GetLatestExaminationID;
            //string[] para = { };
            //object[] value = { };
            object count = SqlHelper.ExecuteSqlForCount(CommandType.StoredProcedure, cmdText, null, null);

            if (count != DBNull.Value)
            {
                return Convert.ToInt32(count);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 添加考试信息
        /// </summary>
        /// <returns></returns>
        public int AddExaminationInfo(ExaminationModel model)
        {
            string cmdText = StoredProcedureName.AddExaminationInfo;
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

        // add by wuxin at 2019/12/03 - end

        // add by wuxin at 2019/12/10 - start
        /// <summary>
        /// 删除考试信息
        /// </summary>
        /// <returns></returns>
        public int DelExaminationInfo(string id)
        {
            string cmdText = StoredProcedureName.DelExaminationInfo;
            string[] para = {
                            ExaminationModel.ParamName_ExaminationID,
                            };
            object[] value = {
                            id
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }
        // add by wuxin at 2019/12/10 - end
    }
}
