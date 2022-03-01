using Common.Model;
using System;
using System.Data;

namespace MCS.DB.BLL
{
    /// <summary>
    /// 考生信息相关业务逻辑
    /// </summary>
    public class ExamineeBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        // del by wuxin at 2018/5/30 - start
        ///// <summary>
        ///// 获取最新ID
        ///// </summary>
        ///// <returns></returns>
        //public int GetNewIDFromExamineeInfoTable()
        //{
        //    //string cmdText = "SELECT MAX(ExamineeID) + 1 FROM  t_examineeinfo ORDER BY ExamineeID;";
        //    //CommandType cmdType = CommandType.StoredProcedure
        //    //CommandType cmdType = CommandType.Text

        //    string cmdText = StoredProcedureName.GetNewIDFromExamineeInfoTable;
        //    //string[] para = { };
        //    //object[] value = { };
        //    object count = SqlHelper.ExecuteSqlForCount(CommandType.StoredProcedure, cmdText, null, null);

        //    return int.Parse(count.ToString());
        //}
        // del by wuxin at 2018/5/30 - end

        // add by wuxin at 2018/5/30 - start
        /// <summary>
        /// 获取最后一个ExamineeID
        /// </summary>
        /// <returns></returns>
        public int GetLastExamineeID()
        {
            string cmdText = StoredProcedureName.GetLastExamineeID;
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
        // add by wuxin at 2018/5/30 - end

        /// <summary>
        /// 添加考生信息
        /// </summary>
        /// <returns></returns>
        public int AddExamineeInfo(ExamineeModel model)
        {
            string cmdText = StoredProcedureName.AddExamineeInfo;
            string[] para = {
                ExamineeModel.ParamName_ExamineeName,
                // add by wuxin at 2018/6/2 - start
                ExamineeModel.ParamName_IDCardNum,
                // add by wuxin at 2018/6/2 - end
                ExamineeModel.ParamName_ExamineeCompanyID,
                // add by wuxin at 2020/1/8 - start
                ExamineeModel.ParamName_ClassType
                // add by wuxin at 2018/1/8 - end
            };

            object[] value = {
                model.ExamineeName,
                // add by wuxin at 2018/6/2 - start
                model.IDCardNum,
                // add by wuxin at 2018/6/2 - end
                model.ExamineeCompanyID,
                // add by wuxin at 2020/1/8 - start
                model.ClassType
                // add by wuxin at 2018/1/8 - end
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 获取所有考生信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllExamineeInfo()
        {
            string cmdText = StoredProcedureName.GetAllExamineeInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);
            return ds;
        }

        /// <summary>
        /// 修改考生信息
        /// </summary>
        /// <returns></returns>
        public int UpdExamineeInfo(ExamineeModel model)
        {
            string cmdText = StoredProcedureName.UpdExamineeInfo;
            string[] para = {
                            ExamineeModel.ParamName_ExamineeName,
                            // add by wuxin at 2018/6/2 - start
                            ExamineeModel.ParamName_IDCardNum,
                            // add by wuxin at 2018/6/2 - end
                            ExamineeModel.ParamName_ExamineeCompanyID,
                            // add by wuxin at 2020/1/8 - start
                            ExamineeModel.ParamName_ClassType,
                            // add by wuxin at 2020/1/8 - end
                            ExamineeModel.ParamName_ExamineeID
                            };
            object[] value = {
                            model.ExamineeName,
                            // add by wuxin at 2018/6/2 - start
                            model.IDCardNum,
                            // add by wuxin at 2018/6/2 - end
                            model.ExamineeCompanyID,
                            // add by wuxin at 2020/1/8 - start
                            model.ClassType,
                            // add by wuxin at 2020/1/8 - end
                            model.ExamineeID
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 删除考生信息
        /// </summary>
        /// <returns></returns>
        public int DelExamineeInfo(string examineeID)
        {
            string cmdText = StoredProcedureName.DelExamineeInfo;
            string[] para = {
                            ExamineeModel.ParamName_ExamineeID
                            };
            object[] value = {
                            examineeID
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 获取指定考生信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetExamineeInfoByExamineeID(string examineeID)
        {
            string cmdText = StoredProcedureName.GetExamineeInfoByExamineeID;
            string[] para = { ExamineeModel.ParamName_ExamineeID };
            object[] value = { examineeID };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);
            return ds;
        }

        // add by wuxin at 2018/6/2 - start
        /// <summary>
        /// 根据身份证号码，获取指定考生信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetExamineeInfoByIDCardNum(string strIDCardNum)
        {
            string cmdText = StoredProcedureName.GetExamineeInfoByIDCardNum;
            string[] para = { ExamineeModel.ParamName_IDCardNum };
            object[] value = { strIDCardNum };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);
            return ds;
        }
        // add by wuxin at 2018/6/2 - end
    }
}
