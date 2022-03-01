/*********************************************************************************
 *Copyright(C) 2019 by wuxin
 *All rights reserved.
 *FileName:    ExaminationItemModel.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:         
 *Description:   
 *History:  
**********************************************************************************/

namespace Common.Model
{
    public class ExaminationItemModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_examination_subject_item_info";
        /// <summary>
        /// 列名：考试项目编号
        /// </summary>
        public static string ColumnName_ExaminationItemID = "ExaminationItemID";
        /// <summary>
        /// 列名：序号
        /// </summary>
        public static string ColumnName_No = "No";
        /// <summary>
        /// 列名：考试项目名称
        /// </summary>
        public static string ColumnName_ExaminationItemName = "ExaminationItemName";
        /// <summary>
        /// 列名：操作内容与步骤
        /// </summary>
        public static string ColumnName_OperationContentAndStep = "OperationContentAndStep";
        /// <summary>
        /// 列名：操作类型
        /// </summary>
        public static string ColumnName_Type = "Type";
        /// <summary>
        /// 列名：考试方式
        /// </summary>
        public static string ColumnName_ExaminationWay = "ExaminationWay";
        /// <summary>
        /// 列名：分值
        /// </summary>
        public static string ColumnName_ScoreValue = "ScoreValue";
        /// <summary>
        /// 列名：每项（步）X分
        /// </summary>
        public static string ColumnName_ScoreStandard = "ScoreStandard";
        /// <summary>
        /// 列名：评分标准
        /// </summary>
        public static string ColumnName_ScoreStandardText = "ScoreStandardText";
        /// <summary>
        /// 列名：考试科目编号
        /// </summary>
        public static string ColumnName_ExaminationSubjectID = "ExaminationSubjectID";

        // ---------------------------------------------------------------------------------------

        /// <summary>
        /// 参数名：考试项目编号
        /// </summary>
        public static string ParamName_ExaminationItemID = "_ExaminationItemID";
        /// <summary>
        /// 参数名：序号
        /// </summary>
        public static string ParamName_No = "_No";
        /// <summary>
        /// 参数名：考试项目名称
        /// </summary>
        public static string ParamName_ExaminationItemName = "_ExaminationItemName";
        /// <summary>
        /// 列名：操作内容与步骤
        /// </summary>
        public static string ParamName_OperationContentAndStep = "_OperationContentAndStep";
        /// <summary>
        /// 列名：操作类型
        /// </summary>
        public static string ParamName_Type = "_Type";
        /// <summary>
        /// 列名：考试方式
        /// </summary>
        public static string ParamName_ExaminationWay = "_ExaminationWay";
        /// <summary>
        /// 列名：分值
        /// </summary>
        public static string ParamName_ScoreValue = "_ScoreValue";
        /// <summary>
        /// 列名：每项（步）X分
        /// </summary>
        public static string ParamName_ScoreStandard = "_ScoreStandard";
        /// <summary>
        /// 列名：评分标准
        /// </summary>
        public static string ParamName_ScoreStandardText = "_ScoreStandardText";
        /// <summary>
        /// 列名：考试科目编号
        /// </summary>
        public static string ParamName_ExaminationSubjectID = "_ExaminationSubjectID";

        private string examinationItemID;
        private string no;
        private string examinationItemName;
        private string operationContentAndStep;
        private string type;
        private string examinationWay;
        private string scoreValue;
        private string scoreStandard;
        private string scoreStandardText;
        private string examinationSubjectID;

        /// <summary>
        /// 考试项目编号
        /// </summary>
        public string ExaminationItemID
        {
            get
            {
                return examinationItemID;
            }

            set
            {
                examinationItemID = value;
            }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public string No
        {
            get
            {
                return no;
            }

            set
            {
                no = value;
            }
        }

        /// <summary>
        /// 考试项目名称
        /// </summary>
        public string ExaminationItemName
        {
            get
            {
                return examinationItemName;
            }

            set
            {
                examinationItemName = value;
            }
        }

        /// <summary>
        /// 操作内容与步骤
        /// </summary>
        public string OperationContentAndStep
        {
            get
            {
                return operationContentAndStep;
            }

            set
            {
                operationContentAndStep = value;
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        /// <summary>
        /// 考试方式
        /// </summary>
        public string ExaminationWay
        {
            get
            {
                return examinationWay;
            }

            set
            {
                examinationWay = value;
            }
        }

        /// <summary>
        /// 分值
        /// </summary>
        public string ScoreValue
        {
            get
            {
                return scoreValue;
            }

            set
            {
                scoreValue = value;
            }
        }

        /// <summary>
        /// 每项（步）X分
        /// </summary>
        public string ScoreStandard
        {
            get
            {
                return scoreStandard;
            }

            set
            {
                scoreStandard = value;
            }
        }

        /// <summary>
        /// 评分标准
        /// </summary>
        public string ScoreStandardText
        {
            get
            {
                return scoreStandardText;
            }

            set
            {
                scoreStandardText = value;
            }
        }

        /// <summary>
        /// 考试科目编号
        /// </summary>
        public string ExaminationSubjectID
        {
            get
            {
                return examinationSubjectID;
            }

            set
            {
                examinationSubjectID = value;
            }
        }
    }
}
