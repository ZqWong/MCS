/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:    PageModel.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:         
 *Description:   
 *History:  
**********************************************************************************/

namespace Common.Model
{
    /// <summary>
    /// 分页用
    /// </summary>
    public class PageModel
    {

        /// <summary>
        /// 列名：总记录数
        /// </summary>
        public static string ColumnName_TotalCount = "TotalCount";
        /// <summary>
        /// 列名：总页数
        /// </summary>
        public static string ColumnName_PageCount = "PageCount";

        /// <summary>
        /// 参数名：要查询的字段用逗号隔开，全部字段就为*
        /// </summary>
        public static string ParamName_Columns = "_Columns";
        /// <summary>
        /// 参数名：表名,多表是请使用 tA a inner join tB b On a.AID = b.AID 
        /// </summary>
        public static string ParamName_TableName = "_TableName";
        /// <summary>
        /// 参数名：Where条件
        /// </summary>
        public static string ParamName_Where = "_Where";
        /// <summary>
        /// 参数名：排序
        /// </summary>
        public static string ParamName_OrderBy = "_OrderBy";
        /// <summary>
        /// 参数名：当前页
        /// </summary>
        public static string ParamName_PageIndex = "_PageIndex";
        /// <summary>
        /// 参数名：每页大小
        /// </summary>
        public static string ParamName_PageSize = "_PageSize";
        /// <summary>
        /// 参数名：总记录数
        /// </summary>
        public static string ParamName_TotalCount = "TotalCount";
        /// <summary>
        /// 参数名：总页数
        /// </summary>
        public static string ParamName_PageCount = "PageCount";

        // 要查询的字段用逗号隔开，全部字段就为*
        private string columns;
        // 表名,多表是请使用 tA a inner join tB b On a.AID = b.AID 
        private string tableName;
        // Where条件
        private string where;
        // 排序
        private string orderBy;
        // 当前页
        private string pageIndex;
        // 每页大小
        private string pageSize;
        // 总记录数
        private string totalCount;
        // 总页数
        private string pageCount;

        /// <summary>
        /// 要查询的字段用逗号隔开，全部字段就为*
        /// </summary>
        public string Columns
        {
            get
            {
                return columns;
            }

            set
            {
                columns = value;
            }
        }

        /// <summary>
        /// 表名,多表是请使用 tA a inner join tB b On a.AID = b.AID 
        /// </summary>
        public string TableName
        {
            get
            {
                return tableName;
            }

            set
            {
                tableName = value;
            }
        }

        /// <summary>
        /// Where条件
        /// </summary>
        public string Where
        {
            get
            {
                return where;
            }

            set
            {
                where = value;
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy
        {
            get
            {
                return orderBy;
            }

            set
            {
                orderBy = value;
            }
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public string PageIndex
        {
            get
            {
                return pageIndex;
            }

            set
            {
                pageIndex = value;
            }
        }

        /// <summary>
        /// 每页大小
        /// </summary>
        public string PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public string TotalCount
        {
            get
            {
                return totalCount;
            }

            set
            {
                totalCount = value;
            }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public string PageCount
        {
            get
            {
                return pageCount;
            }

            set
            {
                pageCount = value;
            }
        }


    }
}
