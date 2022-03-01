using Common.Model;
using System.Data;

namespace MCS.DB.BLL
{
    public class ExaminationSubjectBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 获取所有考试科目信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllExaminationSubjectInfo()
        {
            string cmdText = StoredProcedureName.GetAllExaminationSubjectInfo;
            string[] para = { };
            object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        /// <summary>
        /// 根据考试编号，获取该考试编号对应的所有考试科目信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllExaminationSubjectInfoByExaminationID(string examinationID)
        {
            string cmdText = StoredProcedureName.GetAllExaminationSubjectInfoByExaminationID;
            string[] para = { ExaminationModel.ParamName_ExaminationID };
            object[] value = { examinationID };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            return ds;
        }

        /// <summary>
        /// 获取考试科目信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public string GetExaminationSubjectShortNameByExamineeSubjectID(string examineeSubjectID)
        {
            string examinationSubjectShortName = "";

            string cmdText = StoredProcedureName.GetExaminationSubjectInfoByExamineeSubjectID;
            string[] para = { ExaminationSubjectModel.ParamName_ExaminationSubjectID };
            object[] value = { examineeSubjectID };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            if (ds.Tables[0].Rows.Count > 0)
            {
                examinationSubjectShortName = ds.Tables[0].Rows[0][ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName].ToString();
            }

            return examinationSubjectShortName;
        }

        /// <summary>
        /// 获取考试科目信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public string GetExaminationSubjectNameWithShortNameByExamineeSubjectID(string examineeSubjectID)
        {
            string strExaminationSubjectName = "";

            string cmdText = StoredProcedureName.GetExaminationSubjectInfoByExamineeSubjectID;
            string[] para = { ExaminationSubjectModel.ParamName_ExaminationSubjectID };
            object[] value = { examineeSubjectID };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            if (ds.Tables[0].Rows.Count > 0)
            {
                strExaminationSubjectName = ds.Tables[0].Rows[0][ExaminationSubjectModel.ColumnName_ExaminationSubjectName].ToString() + "（" + "简称：" + ds.Tables[0].Rows[0][ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName].ToString() + "）";
            }

            return strExaminationSubjectName;
        }

        // add by wuxin at 2019/12/04 - start
        /// <summary>
        /// 添加考试科目信息
        /// </summary>
        /// <returns></returns>
        public int AddExaminationSubjectInfo(ExaminationSubjectModel model)
        {
            string cmdText = StoredProcedureName.AddExaminationSubjectInfo;
            string[] para = {
                ExaminationSubjectModel.ParamName_ExaminationSubjectName,
                ExaminationSubjectModel.ParamName_ExaminationSubjectShortName,
                ExaminationSubjectModel.ParamName_ExaminationSubjectScore,
                ExaminationSubjectModel.ParamName_ExaminationSubjectTime,
                ExaminationSubjectModel.ParamName_PaperCompilingMode,
                ExaminationSubjectModel.ParamName_IsHasChildSubject,
                ExaminationSubjectModel.ParamName_ExaminationID,
            };

            object[] value = {
                model.ExaminationSubjectName,
                model.ExaminationSubjectShortName,
                model.ExaminationSubjectScore,
                model.ExaminationSubjectTime,
                model.PaperCompilingMode,
                model.IsHasChildSubject,
                model.ExaminationID,
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 删除考试科目信息
        /// </summary>
        /// <returns></returns>
        public int DelExaminationSubjectInfo(string id)
        {
            string cmdText = StoredProcedureName.DelExaminationSubjectInfo;
            string[] para = {
                            ExaminationSubjectModel.ParamName_ExaminationSubjectID,
                            };
            object[] value = {
                            id
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        // add by wuxin at 2019/12/04 - end
    }
}
