/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:    ExaminationResultModel.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:         
 *Description:   
 *History:  
**********************************************************************************/

namespace Common.Model
{
    /// <summary>
    /// 考试结果
    /// </summary>
    public class ExaminationResultModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_examination_result_info";
        /// <summary>
        /// 列名：考试结果编号
        /// </summary>
        public static string ColumnName_ExaminationResultID = "ExaminationResultID";
        /// <summary>
        /// 列名：考生编号
        /// </summary>
        public static string ColumnName_ExamineeID = "ExamineeID";
        /// <summary>
        /// 列名：考生姓名
        /// </summary>
        public static string ColumnName_ExamineeName = "ExamineeName";

        // add by wuxin at 2020/1/18 - start
        /// <summary>
        /// 列名：身份证号
        /// </summary>
        public static string ColumnName_IDCardNum = "IDCardNum";
        // add by wuxin at 2020/1/18 - end

        /// <summary>
        /// 列名：所属公司编号
        /// </summary>
        public static string ColumnName_ExamineeCompanyID = "ExamineeCompanyID";
        /// <summary>
        /// 列名：所属公司名称
        /// </summary>
        public static string ColumnName_ExamineeCompanyName = "ExamineeCompanyName";
        /// <summary>
        /// 列名：考试名称
        /// </summary>
        public static string ColumnName_ExaminationName = "ExaminationName";
        /// <summary>
        /// 列名：考试科目编号集合
        /// </summary>
        public static string ColumnName_ExaminationSubjectIDs = "ExaminationSubjectIDs";
        /// <summary>
        /// 列名：考试科目名称集合
        /// </summary>
        public static string ColumnName_ExaminationSubjects = "ExaminationSubjects";
        /// <summary>
        /// 列名：最终分数1
        /// </summary>
        public static string ColumnName_FinalScore = "FinalScore";
        /// <summary>
        /// 列名：最终分数2
        /// </summary>
        public static string ColumnName_FinalScore2 = "FinalScore2";
        /// <summary>
        /// 列名：考试结果
        /// </summary>
        public static string ColumnName_ExaminationResult = "ExaminationResult";
        /// <summary>
        /// 列名：考试日期
        /// </summary>
        public static string ColumnName_ExaminationDate = "ExaminationDate";

        /// <summary>
        /// 列名：序号
        /// </summary>
        public static string ColumnName_No = "No";
        /// <summary>
        /// 列名：考试项目
        /// </summary>
        public static string ColumnName_ExaminationItem = "ExaminationItem";
        /// <summary>
        /// 列名：操作内容与步骤——Title
        /// </summary>
        public static string ColumnName_ExaminationContentAndStep_Title = "ExaminationContentAndStep_Title";
        /// <summary>
        /// 列名：操作内容与步骤——Detail
        /// </summary>
        public static string ColumnName_ExaminationContentAndStep_Detail = "ExaminationContentAndStep_Detail";
        ///// <summary>
        ///// 列名：分值
        ///// </summary>
        //public static string ColumnName_ScoreValue = "ScoreValue";
        ///// <summary>
        ///// 列名：评分标准
        ///// </summary>
        //public static string ColumnName_EvaluationStandard = "EvaluationStandard";
        /// <summary>
        /// 列名：扣分情况
        /// </summary>
        public static string ColumnName_DeductionCondition = "DeductionCondition";
        ///// <summary>
        ///// 列名：扣分原因
        ///// </summary>
        //public static string ColumnName_DeductionReason = "DeductionReason";

        /// <summary>
        /// 参数名：考试结果编号
        /// </summary>
        public static string ParamName_ExaminationResultID = "_ExaminationResultID";
        /// <summary>
        /// 参数名：考试科目编号
        /// </summary>
        public static string ParamName_ExaminationSubjectID = "_ExaminationSubjectID";
        /// <summary>
        /// 参数名：
        /// </summary>
        public static string ParamName_ExamineeID = "_ExamineeID";
        /// <summary>
        /// 参数名：
        /// </summary>
        public static string ParamName_ExaminationID = "_ExaminationID";
        /// <summary>
        /// 参数名：
        /// </summary>
        public static string ParamName_ExaminationSubjectIDs = "_ExaminationSubjectIDs";
        /// <summary>
        /// 参数名：
        /// </summary>
        public static string ParamName_ExaminationDate = "_ExaminationDate";

        private string _ExaminationResultID;
        private string _ExamineeID;
        private string _ExamineeName;
        // add by wuxin at 2020/1/18 - start
        private string _IDCardNum;
        // add by wuxin at 2020/1/18 - end
        private string _ExamineeCompanyName;
        private string _ExaminationID;
        private string _ExaminationName;
        private string _ExaminationSubjectIDs;
        private string _ExaminationSubjects;
        private string _FinalScore;
        private string _FinalScore2;
        private string _ExaminationResult;
        private string _ExaminationDate;

        /// <summary>
        /// 考试结果编号
        /// </summary>
        public string ExaminationResultID
        {
            get
            {
                return _ExaminationResultID;
            }

            set
            {
                _ExaminationResultID = value;
            }
        }

        /// <summary>
        /// 考生编号
        /// </summary>
        public string ExamineeID
        {
            get
            {
                return _ExamineeID;
            }

            set
            {
                _ExamineeID = value;
            }
        }

        /// <summary>
        /// 考生姓名
        /// </summary>
        public string ExamineeName
        {
            get
            {
                return _ExamineeName;
            }

            set
            {
                _ExamineeName = value;
            }
        }
        // add by wuxin at 2020/1/18 - start

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNum
        {
            get
            {
                return _IDCardNum;
            }

            set
            {
                _IDCardNum = value;
            }
        }

        // add by wuxin at 2020/1/18 - end

        /// <summary>
        /// 所属公司
        /// </summary>
        public string ExamineeCompanyName
        {
            get
            {
                return _ExamineeCompanyName;
            }

            set
            {
                _ExamineeCompanyName = value;
            }
        }

        /// <summary>
        /// 考试名称
        /// </summary>
        public string ExaminationName
        {
            get
            {
                return _ExaminationName;
            }

            set
            {
                _ExaminationName = value;
            }
        }

        /// <summary>
        /// 考试科目编号集合
        /// </summary>
        public string ExaminationSubjectIDs
        {
            get
            {
                return _ExaminationSubjectIDs;
            }

            set
            {
                _ExaminationSubjectIDs = value;
            }
        }

        /// <summary>
        /// 最终得分1
        /// </summary>
        public string FinalScore
        {
            get
            {
                return _FinalScore;
            }

            set
            {
                _FinalScore = value;
            }
        }

        /// <summary>
        /// 最终得分2
        /// </summary>
        public string FinalScore2
        {
            get
            {
                return _FinalScore2;
            }

            set
            {
                _FinalScore2 = value;
            }
        }

        /// <summary>
        /// 考试结果
        /// </summary>
        public string ExaminationResult
        {
            get
            {
                return _ExaminationResult;
            }

            set
            {
                _ExaminationResult = value;
            }
        }

        /// <summary>
        /// 考试日期
        /// </summary>
        public string ExaminationDate
        {
            get
            {
                return _ExaminationDate;
            }

            set
            {
                _ExaminationDate = value;
            }
        }

        /// <summary>
        /// 考试科目名称集合
        /// </summary>
        public string ExaminationSubjects
        {
            get
            {
                return _ExaminationSubjects;
            }

            set
            {
                _ExaminationSubjects = value;
            }
        }

        public string ExaminationID
        {
            get
            {
                return _ExaminationID;
            }

            set
            {
                _ExaminationID = value;
            }
        }

        // add by wuxin at 2020/1/8 - start
        private string _ClassType;

        /// <summary>
        /// 班别
        /// </summary>
        public string ClassType
        {
            get
            {
                return _ClassType;
            }

            set
            {
                _ClassType = value;
            }
        }
        // add by wuxin at 2020/1/8 - start
    }
}
