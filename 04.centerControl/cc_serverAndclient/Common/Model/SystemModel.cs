/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:    SystemModel.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:        2018/09/10
 *Description:   
 *History:  
**********************************************************************************/
namespace Common.Model
{
    public class SystemModel
    {
        /// <summary>
        /// 表名：
        /// </summary>
        public static string Table_Name = "t_system_info";

        /// <summary>
        /// 列名：
        /// </summary>
        public static string ColumnName_ID = "ID";
        /// <summary>
        /// 列名：
        /// </summary>
        public static string ColumnName_LastDatabaseBackupTime = "LastDatabaseBackupTime";
        /// <summary>
        /// 列名：
        /// </summary>
        public static string ColumnName_LastSystemLogCleanupTime = "LastSystemLogCleanupTime";

        /// <summary>
        /// 参数名：
        /// </summary>
        public static string ParamName_ID = "_ID";
        /// <summary>
        /// 参数名：上次数据库备份时间
        /// </summary>
        public static string ParamName_LastDatabaseBackupTime = "_LastDatabaseBackupTime";
        /// <summary>
        /// 参数名：上次系统日志清理时间
        /// </summary>
        public static string ParamName_LastSystemLogCleanupTime = "_LastSystemLogCleanupTime";


        private string id;

        private string lastDatabaseBackupTime;

        private string lastSystemLogCleanupTime;


        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        /// <summary>
        /// 上次数据库备份时间
        /// </summary>
        public string LastDatabaseBackupTime
        {
            get
            {
                return lastDatabaseBackupTime;
            }

            set
            {
                lastDatabaseBackupTime = value;
            }
        }

        /// <summary>
        /// 上次系统日志清理时间
        /// </summary>
        public string LastSystemLogCleanupTime
        {
            get
            {
                return lastSystemLogCleanupTime;
            }

            set
            {
                lastSystemLogCleanupTime = value;
            }
        }


    }
}
