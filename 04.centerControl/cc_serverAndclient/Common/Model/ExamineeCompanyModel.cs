/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:    ExamineeCompanyModel.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:         
 *Description:   
 *History:  
**********************************************************************************/

namespace Common.Model
{
    /// <summary>
    /// 考生所属公司
    /// </summary>
    public class ExamineeCompanyModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_examinee_company_info";

        /// <summary>
        /// 列名：考生所属公司编号
        /// </summary>
        public static string ColumnName_ExamineeCompanyID = "ExamineeCompanyID";
        /// <summary>
        /// 列名：考生所属公司名称
        /// </summary>
        public static string ColumnName_ExamineeCompanyName = "ExamineeCompanyName";

        /// <summary>
        /// 参数名：考生所属公司编号
        /// </summary>
        public static string ParamName_ExamineeCompanyID = "_ExamineeCompanyID";
        /// <summary>
        /// 参数名：考生所属公司名称
        /// </summary>
        public static string ParamName_ExamineeCompanyName = "_ExamineeCompanyName";

        // 考生所属公司编号
        private string examineeCompanyID;

        // 考生所属公司名称
        private string examineeCompanyName;

        /// <summary>
        /// 考生所属公司编号
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
        /// 考生所属公司名称
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
    }
}
