/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:    ExaminationSubjectModel.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:         
 *Description:   
 *History:  
**********************************************************************************/
namespace Common.Model
{
    /// <summary>
    /// 考试科目
    /// </summary>
    public class ExaminationSubjectModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_examination_subject_info";
        /// <summary>
        /// 列名：考试科目编号
        /// </summary>
        public static string ColumnName_ExaminationSubjectID = "ExaminationSubjectID";
        /// <summary>
        /// 列名：考试科目名称
        /// </summary>
        public static string ColumnName_ExaminationSubjectName = "ExaminationSubjectName";
        /// <summary>
        /// 列名：简称
        /// </summary>
        public static string ColumnName_ExaminationSubjectShortName = "ExaminationSubjectShortName";
        /// <summary>
        /// 列名：考试时间
        /// </summary>
        public static string ColumnName_ExaminationSubjectTime = "ExaminationSubjectTime";
        /// <summary>
        /// 列名：分数
        /// </summary>
        public static string ColumnName_ExaminationSubjectScore = "ExaminationSubjectScore";
        /// <summary>
        /// 列名：组卷方式
        /// </summary>
        public static string ColumnName_PaperCompilingMode = "PaperCompilingMode";
        /// <summary>
        /// 列名：是否包含子科目
        /// </summary>
        public static string ColumnName_IsHasChildSubject = "IsHasChildSubject";
        /// <summary>
        /// 列名：考试编号
        /// </summary>
        public static string ColumnName_ExaminationID = "ExaminationID";


        /// <summary>
        /// 参数名：考试科目编号
        /// </summary>
        public static string ParamName_ExaminationSubjectID = "_ExaminationSubjectID";
        /// <summary>
        /// 参数名：考试科目名称
        /// </summary>
        public static string ParamName_ExaminationSubjectName = "_ExaminationSubjectName";
        /// <summary>
        /// 参数名：简称
        /// </summary>
        public static string ParamName_ExaminationSubjectShortName = "_ExaminationSubjectShortName";
        /// <summary>
        /// 参数名：考试时间
        /// </summary>
        public static string ParamName_ExaminationSubjectTime = "_ExaminationSubjectTime";
        /// <summary>
        /// 参数名：分数
        /// </summary>
        public static string ParamName_ExaminationSubjectScore = "_ExaminationSubjectScore";
        /// <summary>
        /// 参数名：组卷方式
        /// </summary>
        public static string ParamName_PaperCompilingMode = "_PaperCompilingMode";
        /// <summary>
        /// 参数名：是否包含子科目
        /// </summary>
        public static string ParamName_IsHasChildSubject = "_IsHasChildSubject";
        /// <summary>
        /// 参数名：考试编号
        /// </summary>
        public static string ParamName_ExaminationID = "_ExaminationID";

        // 考试科目编号
        private string examinationSubjectID;
        // 考试科目名称
        private string examinationSubjectName;
        // 考试科目简称
        private string examinationSubjectShortName;
        // 总分
        private string examinationSubjectScore;
        // 考试时间
        private string examinationSubjectTime;
        // 组卷方式
        private string paperCompilingMode;
        // 是否包含子科目
        private string isHasChildSubject;
        // 考试编号
        private string examinationID;

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

        /// <summary>
        /// 考试科目名称
        /// </summary>
        public string ExaminationSubjectName
        {
            get
            {
                return examinationSubjectName;
            }

            set
            {
                examinationSubjectName = value;
            }
        }

        /// <summary>
        /// 考试科目简称
        /// </summary>
        public string ExaminationSubjectShortName
        {
            get
            {
                return examinationSubjectShortName;
            }

            set
            {
                examinationSubjectShortName = value;
            }
        }

        /// <summary>
        /// 是否包含子科目
        /// </summary>
        public string IsHasChildSubject
        {
            get
            {
                return isHasChildSubject;
            }

            set
            {
                isHasChildSubject = value;
            }
        }

        /// <summary>
        /// 组卷方式
        /// </summary>
        public string PaperCompilingMode
        {
            get
            {
                return paperCompilingMode;
            }

            set
            {
                paperCompilingMode = value;
            }
        }

        /// <summary>
        /// 总分
        /// </summary>
        public string ExaminationSubjectScore
        {
            get
            {
                return examinationSubjectScore;
            }

            set
            {
                examinationSubjectScore = value;
            }
        }

        /// <summary>
        /// 考试时间
        /// </summary>
        public string ExaminationSubjectTime
        {
            get
            {
                return examinationSubjectTime;
            }

            set
            {
                examinationSubjectTime = value;
            }
        }

        /// <summary>
        /// 考试编号
        /// </summary>
        public string ExaminationID
        {
            get
            {
                return examinationID;
            }

            set
            {
                examinationID = value;
            }
        }
    }
}
