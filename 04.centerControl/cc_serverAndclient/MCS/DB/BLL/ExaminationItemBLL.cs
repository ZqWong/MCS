using Common.Model;
using System;
using System.Data;

namespace MCS.DB.BLL
{
    public class ExaminationItemBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 添加考试项目信息
        /// </summary>
        /// <returns></returns>
        public int AddExaminationItemInfo(ExaminationItemModel model)
        {
            string cmdText = StoredProcedureName.AddExaminationItemInfo;
            string[] para = {
                ExaminationItemModel.ParamName_No,
                ExaminationItemModel.ParamName_ExaminationItemName,
                ExaminationItemModel.ParamName_OperationContentAndStep,
                ExaminationItemModel.ParamName_Type,
                ExaminationItemModel.ParamName_ExaminationWay,
                ExaminationItemModel.ParamName_ScoreValue,
                ExaminationItemModel.ParamName_ScoreStandard,
                ExaminationItemModel.ParamName_ScoreStandardText,
                ExaminationItemModel.ParamName_ExaminationSubjectID
            };

            object[] value = {
                model.No,
                model.ExaminationItemName,
                model.OperationContentAndStep,
                model.Type,
                model.ExaminationWay,
                model.ScoreValue,
                model.ScoreStandard,
                model.ScoreStandardText,
                model.ExaminationSubjectID
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 获取最新的考试项目编号
        /// </summary>
        /// <returns></returns>
        public int GetLatestExaminationItemID()
        {
            string cmdText = StoredProcedureName.GetLatestExaminationItemID;
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
        /// 添加考试项目详情信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddExaminationItemDetailInfo(ExaminationItemDetailModel model)
        {
            string cmdText = StoredProcedureName.AddExaminationItemDetailInfo;
            string[] para = {
                ExaminationItemDetailModel.ParamName_ContentOrStepDetail,
                ExaminationItemDetailModel.ParamName_ExaminationItemID
            };

            object[] value = {
                model.ContentOrStepDetail,
                model.ExaminationItemID
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 根据考试科目编号获取考试项目信息
        /// </summary>
        /// <param name="examinationSubjectID"></param>
        /// <returns></returns>
        public DataSet GetExaminationItemInfoByExaminationSubjectID(string examinationSubjectID)
        {
            string cmdText = StoredProcedureName.GetExaminationItemInfoByExaminationSubjectID;
            string[] para = { ExaminationItemModel.ParamName_ExaminationSubjectID };
            object[] value = { examinationSubjectID };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            return ds;
        }

        /// <summary>
        /// 根据考试项目编号获取考试项目详情信息
        /// </summary>
        /// <param name="examinationItemID"></param>
        /// <returns></returns>
        public DataSet GetExaminationItemDetailInfoByExaminationItemID(string examinationItemID)
        {
            string cmdText = StoredProcedureName.GetExaminationItemDetailInfoByExaminationItemID;
            string[] para = { ExaminationItemDetailModel.ParamName_ExaminationItemID };
            object[] value = { examinationItemID };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);

            return ds;
        }

        /// <summary>
        /// 删除考试项目信息，连带删除考试项目详情信息
        /// </summary>
        /// <returns></returns>
        public int DelExaminationItemInfo(string id)
        {
            string cmdText = StoredProcedureName.DelExaminationItemInfo;
            string[] para = {
                            ExaminationItemModel.ParamName_ExaminationItemID,
                            };
            object[] value = {
                            id
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }
    }
}
