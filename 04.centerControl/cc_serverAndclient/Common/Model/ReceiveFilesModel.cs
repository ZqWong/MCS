/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:    ExaminationPCModel.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:         
 *Description:   
 *History:  
**********************************************************************************/

using System;

namespace Common.Model
{

    [Serializable()]
    public class ReceiveFilesModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_receive_files_info";

        public static string ColumnName_ID = "ID";
        public static string ColumnName_Name = "AppName";
        public static string ColumnName_IP = "IP";
        public static string ColumnName_Path = "FilePath";
        public static string ColumnName_DestPath = "DestPath";

        public static string ColumnName_Edit_ID = "Edit_ID";
        public static string ColumnName_Edit_Name = "Edit_AppName";
        public static string ColumnName_Edit_IP = "Edit_IP";
        public static string ColumnName_Edit_Path = "Edit_FilePath";
        public static string ColumnName_Edit_DestPath = "Edit_DestPath";

        public static string ParamName_ID = "_ID";
        public static string ParamName_Name = "_AppName";
        public static string ParamName_IP = "_IP";
        public static string ParamName_Path = "_FilePath";
        public static string ParamName_DestPath = "_DestPath";

        public static string DB_ID = "ID";
        public static string DB_Name = "AppName";
        public static string DB_IP = "IP";
        public static string DB_Path = "FilePath";
        public static string DB_DestPath = "DestPath";

        public static string CheckBox = "CheckBox";


        public string ID { get; set; }

        public string AppName { get; set; }

        public string IP { get; set; }

        public string Path { get; set; }

        public string DestPath { get; set; }





    }
}
