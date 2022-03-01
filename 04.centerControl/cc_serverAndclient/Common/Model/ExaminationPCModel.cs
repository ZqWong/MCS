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

    /// <summary>
    /// 开/关机状态
    /// </summary>
    public enum EnumOpenOrClosePCState
    {
        Close = 0,   // 关机
        Opening = 1, // 开机中
        Open = 2,    // 开机
        Closing = 3  // 关机中
    }

    /// <summary>
    /// 连接到服务器状态
    /// </summary>
    public enum EnumConnectionState
    {
        NoConnection = 0, // 未连接
        Connected = 1     // 已连接
    }

    /// <summary>
    /// 考试系统软件打开状态
    /// </summary>
    public enum EnumExamAppOpenState
    {
        Open = 0, // 打开
        Close = 1 // 关闭
    }

    /// <summary>
    /// 考试状态
    /// </summary>
    public enum EnumExamState
    {
        Empty = 0,    // 空
        NoStart = 1,  // 未开始
        Start = 2,    // 已开始
        Over = 3      // 已结束
    }

    /// <summary>
    /// 考试机状态
    /// </summary>
    public enum EnumExamPCState
    {
        Idle = 0, // 空闲
        Busy = 1  // 占用
    }

    // add by wuxin at 2018/10/14 - start
    /// <summary>
    /// 考试机类型
    /// </summary>
    public enum EnumExamPCType
    {
        Practice = 0,      // 练习
        Examination = 1    // 考试
    }
    // add by wuxin at 2018/10/14 - end

    [Serializable()]
    public class ExaminationPCModel
    {

        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_examination_pc_info";
        public static string ColumnName_ID = "ID";
        public static string ColumnName_ExamPCName = "ExamPCName";
        public static string ColumnName_IP = "IP";
        public static string ColumnName_Port = "Port";
        public static string ColumnName_Mac = "Mac";
        // add by wuxin at 2018/10/14 - start
        public static string ColumnName_Type = "Type";
        // add by wuxin at 2018/10/14 - end
        public static string ColumnName_CheckBox = "CheckBox";

        public static string ColumnName_OpenOrClosePCState = "OpenOrClosePCState";
        public static string ColumnName_ConnectionState = "ConnectionState";
        public static string ColumnName_ExamAppOpenState = "ExamAppOpenState";

        public static string ColumnName_ExaminationID = "ExaminationID";
        public static string ColumnName_ExaminationContent = "ExaminationContent";
        public static string ColumnName_ExamineeID = "ExamineeID";
        public static string ColumnName_ExamineeName = "ExamineeName";

        public static string ColumnName_CpuRatio = "cpu_ratio";
        public static string ColumnName_Memory = "memory_available";
        public static string ColumnName_TickCount = "client_system_tick_count";

        public static string ColumnName_ProcessState = "process_state";

        public static string ColumnName_ExamState = "ExamState";
        public static string ColumnName_ExamPCState = "ExamPCState";

        public static string ColumnName_Stereo = "stereo_state";
        public static string ColumnName_LeftRight = "leftRight_state";

        public static string ColumnName_GpuRatio = "gpu_ratio";
        public static string ColumnName_GpuMemoryRatio = "gpu_memory";

        public static string ColumnName_NetDelay = "netDelay";

        public static string ParamName_ID = "_ID";
        public static string ParamName_Name = "_ExamPCName";
        public static string ParamName_IP = "_IP";
        public static string ParamName_Port = "_Port";
        public static string ParamName_Mac = "_Mac";
        // add by wuxin at 2018/10/14 - start
        public static string ParamName_Type = "_Type";
        // add by wuxin at 2018/10/14 - end

        private int index;

        private string id;

        private string examPCName;

        private string iP;

        private string port;

        private string mac;
        // add by wuxin at 2018/10/14 - start
        private string type;
        // add by wuxin at 2018/10/14 - end

        // 开/关机状态
        // 0关机，1正在开机，2开机，3正在关机
        private EnumOpenOrClosePCState openOrClosePCState;

        // 连接到服务器状态
        // 0未连接，1已连接
        private EnumConnectionState connectionState;

        // 考试系统软件打开状态
        // 0关闭，1打开
        private EnumExamAppOpenState enumExamAppOpenState;

        private string examinationID;

        private string examinationSubjectIDs;

        private string examineeID;

        private string examinationResultID;

        // 考试状态
        // 0无，1未开始，2已开始，3已结束
        private EnumExamState examState;

        // 考试机状态
        // 0空闲，1占用
        private EnumExamPCState examPCState;

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

        public string IP
        {
            get
            {
                return iP;
            }

            set
            {
                iP = value;
            }
        }

        public string Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public string Mac
        {
            get
            {
                return mac;
            }

            set
            {
                mac = value;
            }
        }

        public string ExamPCName
        {
            get
            {
                return examPCName;
            }

            set
            {
                examPCName = value;
            }
        }

        /// <summary>
        /// 开/关机状态
        /// </summary>
        public EnumOpenOrClosePCState OpenOrClosePCState
        {
            get
            {
                return openOrClosePCState;
            }

            set
            {
                openOrClosePCState = value;
            }
        }

        /// <summary>
        /// 连接到服务器状态
        /// </summary>
        public EnumConnectionState ConnectionState
        {
            get
            {
                return connectionState;
            }

            set
            {
                connectionState = value;
            }
        }

        /// <summary>
        /// 考试系统软件打开状态
        /// </summary>
        public EnumExamAppOpenState EnumExamAppOpenState
        {
            get
            {
                return enumExamAppOpenState;
            }

            set
            {
                enumExamAppOpenState = value;
            }
        }

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
        /// 考试状态
        /// </summary>
        public EnumExamState ExamState
        {
            get
            {
                return examState;
            }

            set
            {
                examState = value;
            }
        }

        /// <summary>
        /// 考试机状态
        /// </summary>
        public EnumExamPCState ExamPCState
        {
            get
            {
                return examPCState;
            }

            set
            {
                examPCState = value;
            }
        }

        /// <summary>
        /// DGV_Index
        /// </summary>
        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        /// <summary>
        /// 考试科目集合
        /// </summary>
        public string ExaminationSubjectIDs
        {
            get
            {
                return examinationSubjectIDs;
            }

            set
            {
                examinationSubjectIDs = value;
            }
        }

        /// <summary>
        /// 考试结果编号
        /// </summary>
        public string ExaminationResultID
        {
            get
            {
                return examinationResultID;
            }

            set
            {
                examinationResultID = value;
            }
        }

        // add by wuxin at 2018/10/14 - start
        /// <summary>
        /// 考试机类型
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
        // add by wuxin at 2018/10/14 - end
    }
}
