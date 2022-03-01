/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:    ExamineeModel.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:         
 *Description:   
 *History:  
**********************************************************************************/

namespace Common.Model
{
    /// <summary>
    /// 考生
    /// </summary>
    public class ExamineeModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_examinee_info";
        /// <summary>
        /// 列名：考生编号
        /// </summary>
        public static string ColumnName_ExamineeID = "ExamineeID";
        /// <summary>
        /// 列名：考生姓名
        /// </summary>
        public static string ColumnName_ExamineeName = "ExamineeName";

        // add by wuxin at 2018/6/2 - start
        /// <summary>
        /// 列名：身份证号
        /// </summary>
        public static string ColumnName_IDCardNum = "IDCardNum";
        // add by wuxin at 2018/6/2 - end

        /// <summary>
        /// 列名：所属公司编号
        /// </summary>
        public static string ColumnName_ExamineeCompanyID = "ExamineeCompanyID";
        /// <summary>
        /// 列名：所属公司名称
        /// </summary>
        public static string ColumnName_ExamineeCompanyName = "ExamineeCompanyName";

        // add by wuxin at 2020/1/7 - start
        /// <summary>
        /// 列名：班别
        /// </summary>
        public static string ColumnName_ClassType = "ClassType";
        // add by wuxin at 2020/1/7 - end

        /// <summary>
        /// 参数名：考生编号
        /// </summary>
        public static string ParamName_ExamineeID = "_ExamineeID";
        /// <summary>
        /// 参数名：考生姓名
        /// </summary>
        public static string ParamName_ExamineeName = "_ExamineeName";

        // add by wuxin at 2018/6/2 - start
        /// <summary>
        /// 参数名：身份证号
        /// </summary>
        public static string ParamName_IDCardNum = "_IDCardNum";
        // add by wuxin at 2018/6/2 - end

        /// <summary>
        /// 参数名：所属公司编号
        /// </summary>
        public static string ParamName_ExamineeCompanyID = "_ExamineeCompanyID";
        /// <summary>
        /// 参数名：所属公司名称
        /// </summary>
        public static string ParamName_ExamineeCompanyName = "_ExamineeCompanyName";

        // add by wuxin at 2020/1/7 - start
        /// <summary>
        /// 参数名：班别
        /// </summary>
        public static string ParamName_ClassType = "_ClassType";
        // add by wuxin at 2020/1/7 - end

        // 考生编号
        private string examineeID;

        // 考生姓名
        private string examineeName;

        // add by wuxin at 2018/6/2 - start
        // 身份证号
        private string iDCardNum;
        // add by wuxin at 2018/6/2 - end

        // 所属公司编号
        private string examineeCompanyID;

        // 所属公司名称
        private string examineeCompanyName;

        // add by wuxin at 2020/1/7 - start
        // 班别
        private string classType;
        // add by wuxin at 2020/1/7 - end

        /// <summary>
        /// 考生编号
        /// </summary>
        public string ExamineeID
        {
            get
            {
                return examineeID;
            }

            set
            {
                examineeID = value;
            }
        }

        /// <summary>
        /// 考生姓名
        /// </summary>
        public string ExamineeName
        {
            get
            {
                return examineeName;
            }

            set
            {
                examineeName = value;
            }
        }

        /// <summary>
        /// 所属公司编号
        /// </summary>
        public string ExamineeCompanyID
        {
            get
            {
                return examineeCompanyID;
            }

            set
            {
                examineeCompanyID = value;
            }
        }

        /// <summary>
        /// 所属公司名称
        /// </summary>
        public string ExamineeCompanyName
        {
            get
            {
                return examineeCompanyName;
            }

            set
            {
                examineeCompanyName = value;
            }
        }

        // add by wuxin at 2018/6/2 - start
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNum
        {
            get
            {
                return iDCardNum;
            }

            set
            {
                iDCardNum = value;
            }
        }
        // add by wuxin at 2018/6/2 - end

        // add by wuxin at 2020/1/7 - start
        /// <summary>
        /// 班别
        /// </summary>
        public string ClassType
        {
            get
            {
                return classType;
            }

            set
            {
                classType = value;
            }
        }
        // add by wuxin at 2020/1/7 - end
    }
}
