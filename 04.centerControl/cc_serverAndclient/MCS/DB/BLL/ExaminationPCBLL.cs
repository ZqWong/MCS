using Common.Model;
using System.Data;

namespace MCS.DB.BLL
{
    public class ExaminationPCBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 添加考试机信息
        /// </summary>
        /// <returns></returns>
        public int AddExaminationPCInfo(ExaminationPCModel ePCModel)
        {
            string cmdText = StoredProcedureName.AddExaminationPCInfo;
            string[] para = {
                ExaminationPCModel.ParamName_Name,
                ExaminationPCModel.ParamName_IP,
                ExaminationPCModel.ParamName_Port,
                ExaminationPCModel.ParamName_Mac,
                // add by wuxin at 2018/10/14 - start
                ExaminationPCModel.ParamName_Type
                // add by wuxin at 2018/10/14 - end
            };

            object[] value = {
                ePCModel.ExamPCName,
                ePCModel.IP,
                ePCModel.Port,
                ePCModel.Mac,
                // add by wuxin at 2018/10/14 - start
                ePCModel.Type
                // add by wuxin at 2018/10/14 - en
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 查看所有考试机信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllExaminationPCInfo()
        {
            string cmdText = StoredProcedureName.GetAllExaminationPCInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);
            return ds;
        }

        /// <summary>
        /// 修改考试机信息
        /// </summary>
        /// <returns></returns>
        public int UpdExaminationPCInfo(ExaminationPCModel ePCModel)
        {
            string cmdText = StoredProcedureName.UpdExaminationPCInfo;
            string[] para = {
                            ExaminationPCModel.ParamName_ID,
                            ExaminationPCModel.ParamName_Name,
                            ExaminationPCModel.ParamName_IP,
                            ExaminationPCModel.ParamName_Port,
                            ExaminationPCModel.ParamName_Mac,
                            // add by wuxin at 2018/10/14 - start
                            ExaminationPCModel.ParamName_Type
                            // add by wuxin at 2018/10/14 - end
                            };
            object[] value = {
                            ePCModel.ID,
                            ePCModel.ExamPCName,
                            ePCModel.IP,
                            ePCModel.Port,
                            ePCModel.Mac,
                            // add by wuxin at 2018/10/14 - start
                            ePCModel.Type
                            // add by wuxin at 2018/10/14 - en
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 删除考试机信息
        /// </summary>
        /// <returns></returns>
        public int DelExaminationPCInfo(string id)
        {
            string cmdText = StoredProcedureName.DelExaminationPCInfo;
            string[] para = {
                            ExaminationPCModel.ParamName_ID,
                            };
            object[] value = {
                            id
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }
    }
}
