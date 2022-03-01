using Common.Model;
using MCS.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace MCS.DB.BLL
{
    public class ExaminationResultBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();
        ExaminationSubjectBLL _ExaminationSubjectBLL = new ExaminationSubjectBLL();

        /// <summary>
        /// 添加考试结果信息
        /// </summary>
        /// <returns></returns>
        public int AddExaminationResultInfo(ExaminationResultModel model)
        {
            string cmdText = StoredProcedureName.AddExaminationResultInfo;
            string[] para = {
                ExaminationResultModel.ParamName_ExamineeID,
                ExaminationResultModel.ParamName_ExaminationID,
                ExaminationResultModel.ParamName_ExaminationSubjectIDs,
                ExaminationResultModel.ParamName_ExaminationDate
            };

            object[] value = {
                model.ExamineeID,
                model.ExaminationID,
                model.ExaminationSubjectIDs,
                model.ExaminationDate
            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        // upd by wuxin at 2018/5/30 - start
        ///// <summary>
        ///// 获取最新ID
        ///// </summary>
        ///// <returns></returns>
        //public int GetNewExaminationResultID()
        //{
        //    string cmdText = StoredProcedureName.GetNewExaminationResultID;
        //    //string[] para = { };
        //    //object[] value = { };
        //    object count = SqlHelper.ExecuteSqlForCount(CommandType.StoredProcedure, cmdText, null, null);

        //    // del by wuxin at 2018/05/25 - start
        //    // return int.Parse(count.ToString());
        //    // del by wuxin at 2018/05/25 - end

        //    // add by wuxin at at 2018/05/25 - start 
        //    // 修复BUG:当获取考试结果新ID获取时，之前如果无数据，获取不到最新ID的BUG。
        //    if (count != DBNull.Value)
        //    {
        //        return Convert.ToInt32(count);
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //    // add by wuxin at 2018/05/25 - end
        //}

        /// <summary>
        /// 获取最后一个ExaminationResultID
        /// </summary>
        /// <returns></returns>
        public int GetLastExaminationResultID()
        {
            string cmdText = StoredProcedureName.GetLastExaminationResultID;
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
        // upd by wuxin at 2018/5/30 - end

        /// <summary>
        /// 获取考试所有科目并根据组卷方式生成组合试卷
        /// </summary>
        /// <returns></returns>
        public string GetExaminationSubjectIDs(string examinationID)
        {
            string strExaminationSubjectIDs = "";

            // 必考
            List<string> compulsorySubjectList = new List<string>();
            // 随机
            List<string> randomSubjectList = new List<string>();

            DataSet ds = _ExaminationSubjectBLL.GetAllExaminationSubjectInfoByExaminationID(examinationID);

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                // 获取指定考试编号下的所有考试科目信息，将必考科目存到必考科目集合，将随机科目存到随机科目集合中
                for (int i = 0; i < count; i++)
                {
                    // 是否包含子科目，暂时默认不包含子科目
                    // TODO:暂时不考虑包含子科目的情况，只有【监测监控】包含子科目，做【监测监控】的时候再实现
                    string paperCompilingMode = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_PaperCompilingMode].ToString();
                    string examinationSubjectID = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectID].ToString();

                    if (paperCompilingMode == Const.PAPER_COMPILING_MODE_COMPULSORY)
                    {
                        compulsorySubjectList.Add(examinationSubjectID);
                    }
                    else
                    {
                        randomSubjectList.Add(examinationSubjectID);
                    }
                }


                // 如果必考题够2套，那么不用再管是否有随机题（也不可能有这种情况）
                if (compulsorySubjectList.Count == 2)
                {
                    for (int i = 0; i < compulsorySubjectList.Count; i++)
                    {
                        if (i == 0)
                        {
                            strExaminationSubjectIDs = compulsorySubjectList[i];
                        }
                        else
                        {
                            strExaminationSubjectIDs = strExaminationSubjectIDs + "," + compulsorySubjectList[i];
                        }
                    }
                }
                // upd by wuxin at 2019/12/06 - start
                //else
                //{
                //    // 必考题
                //    for (int m = 0; m < compulsorySubjectList.Count; m++)
                //    {
                //        if (m == 0)
                //        {
                //            strExaminationSubjectIDs = compulsorySubjectList[m];
                //        }
                //        else
                //        {
                //            strExaminationSubjectIDs = strExaminationSubjectIDs + "," + compulsorySubjectList[m];
                //        }
                //    }

                //    Random rd = new Random();
                //    int randomValue = rd.Next(0, randomSubjectList.Count);

                //    strExaminationSubjectIDs = strExaminationSubjectIDs + "," + randomSubjectList[randomValue];
                //}
                // 一个必考科目 + 一个随机科目的情况
                else if (compulsorySubjectList.Count == 1)
                {
                    // 必考科目
                    strExaminationSubjectIDs = compulsorySubjectList[0];

                    // 随机科目随机抽取一个
                    Random rd = new Random(); // Next(int min Value,int max Value)：产生一个 minValue~maxValue 的正整数，但不包含 maxValue
                    int randomValue = rd.Next(0, randomSubjectList.Count);

                    strExaminationSubjectIDs = strExaminationSubjectIDs + "," + randomSubjectList[randomValue];
                }
                // 没有必考科目，随机科目抽取两个的情况
                else if (compulsorySubjectList.Count == 0)
                {
                    // 随机科目数必须>=2
                    if (randomSubjectList.Count >= 2)
                    {
                        Random ramdomSubejct = new Random();
                        int randomValue1 = ramdomSubejct.Next(0, randomSubjectList.Count);

                        strExaminationSubjectIDs = randomSubjectList[randomValue1];

                        int randomValue2 = randomValue1;

                        // 随机数相同，重新生成随机数
                        while (randomValue2 == randomValue1)
                        {
                            randomValue2 = ramdomSubejct.Next(0, randomSubjectList.Count);
                        }

                        strExaminationSubjectIDs = strExaminationSubjectIDs + "," + randomSubjectList[randomValue2];

                    }
                    else
                    {
                        return null;
                    }
                }
                // upd by wuxin at 2019/12/06 - end
            }

            return strExaminationSubjectIDs;
        }

        // add by wuxin at 2018/10/14 - start
        /// <summary>
        /// 删除考试结果信息
        /// </summary>
        /// <returns></returns>
        public int DelExaminationResultInfo(string id)
        {
            string cmdText = StoredProcedureName.DelExaminationResultInfo;
            string[] para = {
                            ExaminationResultModel.ParamName_ExaminationResultID,
                            };
            object[] value = {
                            id
                            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }
        // add by wuxin at 2018/10/14 - end

        // add by wuxin at 2019/12/02 - start
        /// <summary>
        /// 分页获取数据信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetAllExaminationResultInfoByCustomCondition(PageModel pm)
        {
            string cmdText = StoredProcedureName.GetData;
            string[] para = {
                PageModel.ParamName_Columns,
                PageModel.ParamName_TableName,
                PageModel.ParamName_Where,
                PageModel.ParamName_OrderBy,
            };
            object[] value = {
                pm.Columns,
                pm.TableName,
                pm.Where,
                pm.OrderBy,
            };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, para, value);
            return ds;
        }
        // add by wuxin at 2019/12/02 - end
    }
}
