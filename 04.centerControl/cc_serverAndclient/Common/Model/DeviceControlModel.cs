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
    public class DeviceControlModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_device_control_info";

        public static string ColumnName_ID = "ID";
        public static string ColumnName_Name = "name";
        public static string ColumnName_IP = "IP";
        public static string ColumnName_CLASS = "category";
        public static string ColumnName_PORT = "PORT";
        public static string ColumnName_INTERNET_ON_CODEL = "internet_on_code";
        public static string ColumnName_INTERNET_OFF_CODE = "internet_off_code";
        public static string ColumnName_SERIAL = "SERIAL_PORT";
        public static string ColumnName_SERIA_ON_CODEL = "Serial_on_code";
        public static string ColumnName_SERIAL_OFF_CODE = "Serial_off_code";
        public static string ColumnName_BAUD = "BAUD";
        public static string ColumnName_USERS232 = "USE_RS232";
        public static string ColumnName_DELAY = "DELAY";

        public static string ColumnName_CheckBox = "CheckBox";



        public static string ParamName_ID = "_ID";
        public static string ParamName_Name = "_NAME";
        public static string ParamName_IP = "_IP";
        public static string ParamName_CLASS = "_CLASS";
        public static string ParamName_PORT = "_PORT";
        public static string ParamName_INTERNET_ON_CODE = "_INTERNET_ON_CODE";
        public static string ParamName_INTERNET_OFF_CODE = "_INTERNET_OFF_CODE";
        public static string ParamName_SERIAL = "_SERIAL";
        public static string ParamName_SERIAL_ON_CODE = "_SERIAL_ON_CODE";
        public static string ParamName_SERIAL_OFF_CODE = "_SERIAL_OFF_CODE";
        public static string ParamName_BAUD = "_BAUD";
        public static string ParamName_USERS232 = "_USE_RS232";
        public static string ParamName_DELAY = "_DELAY";

        public static string DB_ID = "ID";
        public static string DB_Name = "NAME";
        public static string DB_IP = "IP";
        public static string DB_CLASS = "CLASS";
        public static string DB_PORT = "PORT";
        public static string DB_INTERNET_ON_CODE = "INTERNET_ON_CODE";
        public static string DB_INTERNET_OFF_CODE = "INTERNET_OFF_CODE";
        public static string DB_SERIAL = "SERIAL";
        public static string DB_SERIAL_ON_CODE = "SERIAL_ON_CODE";
        public static string DB_SERIAL_OFF_CODE = "SERIAL_OFF_CODE";
        public static string DB_BAUD = "BAUD";
        public static string DB_USERS232 = "USE_RS232";
        public static string DB_DELAY = "DELAY";


        public string ID { get; set; }
        public string NAME { get; set; }
        public string IP { get; set; }
        public string CLASS { get; set; }
        public string PORT { get; set; }
        public string INTERNET_ON_CODE { get; set; }
        public string INTERNET_OFF_CODE { get; set; }
        public string SERIAL { get; set; }
        public string SERIAL_ON_CODE { get; set; }
        public string SERIAL_OFF_CODE { get; set; }
        public string BUAD { get; set; }
        public string USERS232 { get; set; }
        public string DELAY { get; set; }
    }
}
