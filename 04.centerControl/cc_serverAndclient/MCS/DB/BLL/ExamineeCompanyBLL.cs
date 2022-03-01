using Common.Model;
using System.Data;

namespace MCS.DB.BLL
{
    /// <summary>
    /// 考生所属公司相关业务逻辑
    /// </summary>
    public class ExamineeCompanyBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 添加考生所属公司信息
        /// </summary>
        /// <returns></returns>
        public int AddExamineeCompanyInfo(ExamineeCompanyModel model)
        {
            string cmdText = StoredProcedureName.AddExamineeCompanyInfo;
            string[] para = { ExamineeCompanyModel.ParamName_ExamineeCompanyName };
            object[] value = { model.ExamineeCompanyName };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 查看所有考生所属公司信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllExamineeCompany()
        {
            string cmdText = StoredProcedureName.GetAllExamineeCompanyInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);
            return ds;
        }

        // add by wuxin at 2018/5/31 - start
        /// <summary>
        /// 根据考生所属公司名称获取所属公司ID
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public string GetExamineeCompanyIDByExamineeCompanyName(string strExamineeCompanyName)
        {
            string cmdText = StoredProcedureName.GetExamineeCompanyIDByExamineeCompanyName;
            string[] para = { ExamineeCompanyModel.ParamName_ExamineeCompanyName };
            object[] value = { strExamineeCompanyName };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        // add by wuxin at 2018/5/31 - end

        // add by wuxin at 2020/1/7 - start
        /// <summary>
        /// 根据考生所属公司ID获取所属公司名称
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public string GetExamineeCompanyNameByExamineeCompanyID(string strExamineeCompanyID)
        {
            string cmdText = StoredProcedureName.GetExamineeCompanyNameByExamineeCompanyID;

            string[] para = { ExamineeCompanyModel.ParamName_ExamineeCompanyID };
            object[] value = { strExamineeCompanyID };

            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        // add by wuxin at 2020/1/7 - end


        /// <summary>
        /// 修改考生所属公司信息
        /// </summary>
        /// <returns></returns>
        public int UpdExamineeCompanyInfo(ExamineeCompanyModel model)
        {
            string cmdText = StoredProcedureName.UpdExamineeCompanyInfo;
            string[] para = {
                            ExamineeCompanyModel.ParamName_ExamineeCompanyID,
                            ExamineeCompanyModel.ParamName_ExamineeCompanyName
                            };
            object[] value = {
                            model.ExamineeCompanyID,
                            model.ExamineeCompanyName
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 删除考生所属公司信息
        /// </summary>
        /// <returns></returns>
        public int DelExamineeCompanyInfo(string examineeCompanyID)
        {
            string cmdText = StoredProcedureName.DelExamineeCompanyInfo;
            string[] para = {
                            ExamineeCompanyModel.ParamName_ExamineeCompanyID
                            };
            object[] value = {
                            examineeCompanyID
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }
    }
}
