using Common.Model;
using System.Data;

namespace MCS.DB.BLL
{
    public class ExaminationResultDetailBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetExamResultDetailByExamResultID(string examinationResultID)
        {
            string cmdText = StoredProcedureName.GetExamResultDetailByExamResultID;

            string[] para = { ExaminationResultModel.ParamName_ExaminationResultID };
            object[] value = { examinationResultID };

            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet GetExamResultDetailByExamResultIDAndExamSubjectID(string examinationResultID, string examinationSubjectID)
        {
            string cmdText = StoredProcedureName.GetExamResultDetailByExamResultIDAndExamSubjectID;

            string[] para = { ExaminationResultModel.ParamName_ExaminationResultID, ExaminationResultModel.ParamName_ExaminationSubjectID };
            object[] value = { examinationResultID, examinationSubjectID };

            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            return ds;
        }
    }
}
