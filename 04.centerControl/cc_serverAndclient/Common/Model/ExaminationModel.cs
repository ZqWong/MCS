/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:     ExaminationModel.cs
 *Author:       wuxin
 *Version:      1.0
 *Date:         2018-05-11
 *Description:   
 *History:  
**********************************************************************************/

namespace Common.Model
{
    /// <summary>
    /// 考试
    /// </summary>
    public class ExaminationModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_examination_info";
        /// <summary>
        /// 考试编号
        /// </summary>
        public static string ColumnName_ExaminationID = "ExaminationID";
        /// <summary>
        /// 考试名称
        /// </summary>
        public static string ColumnName_ExaminationName = "ExaminationName";
        /// <summary>
        /// 组卷方式
        /// </summary>
        public static string ColumnName_PaperCompilingMode = "PaperCompilingMode";
        /// <summary>
        /// 总分
        /// </summary>
        public static string ColumnName_TotalScore = "TotalScore";
        /// <summary>
        /// 合格分
        /// </summary>
        public static string ColumnName_ExaminationPassScore = "ExaminationPassScore";
        /// <summary>
        /// 考试时间
        /// </summary>
        public static string ColumnName_ExaminationTime = "ExaminationTime";

        /// <summary>
        /// _ExaminationID
        /// </summary>
        public static string ParamName_ExaminationID = "_ExaminationID";
        public static string ParamName_ExaminationName = "_ExaminationName";
        public static string ParamName_PaperCompilingMode = "_PaperCompilingMode";
        public static string ParamName_TotalScore = "_TotalScore";
        public static string ParamName_ExaminationPassScore = "_ExaminationPassScore";
        public static string ParamName_ExaminationTime = "_ExaminationTime";

        // 考试编号
        private string examinationID;
        // 考试名称
        private string examinationName;
        // 组卷方式
        private string paperCompilingMode;
        // 总分
        private string totalScore;
        // 合格分
        private string examinationPassScore;
        // 考试时间
        private string examinationTime;

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

        /// <summary>
        /// 考试名称
        /// </summary>
        public string ExaminationName
        {
            get
            {
                return examinationName;
            }

            set
            {
                examinationName = value;
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
        public string TotalScore
        {
            get
            {
                return totalScore;
            }

            set
            {
                totalScore = value;
            }
        }

        /// <summary>
        /// 合格分
        /// </summary>
        public string ExaminationPassScore
        {
            get
            {
                return examinationPassScore;
            }

            set
            {
                examinationPassScore = value;
            }
        }

        /// <summary>
        /// 考试时间
        /// </summary>
        public string ExaminationTime
        {
            get
            {
                return examinationTime;
            }

            set
            {
                examinationTime = value;
            }
        }
    }
}
