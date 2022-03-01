// ******************************************************************
// 概  述：全局常量类
// 作  者：伍鑫
// 创建日期：2013/11/28
// 版本号：V1.0
// 版本信息:
// V1.0 新建
// ******************************************************************
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace MCS.Common
{
    public class Const
    {

        public static string MySqlConnection = ConfigurationManager.AppSettings["MySqlConnection"];

        public static string LogPath = Application.StartupPath + @"\Log\Service_Log.txt";

        public static string ExcelTemplatePath = Application.StartupPath + @"\ExcelTemplate\ExcelTemplate.xlsx"; // xlsx / xls
        public static string ExcelSaveFolderPath = Application.StartupPath + @"\Excels";

        public static string ExaminationResult_Yes = "通过";
        public static string ExaminationResult_No = "未通过";

        public const string ComputerClosingPicRPath = "\\Images\\closing.png";  // 关机中
        public const string ComputerOpeningPicRPath = "\\Images\\opening.png";  // 开机中
        public const string ComputerClosedPicRPath = "\\Images\\closed.png";    // 关机
        public const string ComputerOpenPicRPath = "\\Images\\opened.png";      // 开机

        public const string ConnectionState_NoConnection_PicRPath = "\\Images\\NoConnection.png";    // 未连接
        public const string ConnectionState_Connected_PicRPath = "\\Images\\Connected.png";      // 已连接

        public const string ExamAppOpenState_Open_PicRPath = "\\Images\\open.png";    // 打开
        public const string ExamAppOpenState_Close_PicRPath = "\\Images\\close.png";      // 关闭

        public const string ExamState_Empty_PicRPath = "\\Images\\empty.png";        // 空
        public const string ExamState_NoStart_PicRPath = "\\Images\\nostart.png";    // 未开始
        public const string ExamState_Start_PicRPath = "\\Images\\start.png";        // 已开始
        public const string ExamState_Over_PicRPath = "\\Images\\over.png";          // 已结束

        public const string ExamPCState_Idle_PicRPath = "\\Images\\idle.png";        // 空闲
        public const string ExamPCState_Busy_PicRPath = "\\Images\\busy.png";        // 占用

        public static string CanKaoImagePath = Application.StartupPath + "\\Images\\CK\\";

        public const string Tag_OpenOrClosePCState_Closing = "closing";
        public const string Tag_OpenOrClosePCState_Opening = "opening";
        public const string Tag_OpenOrClosePCState_Closed = "close";
        public const string Tag_OpenOrClosePCState_Open = "open";

        public const string Tag_ConnectionState_NoConnection = "noconnection";
        public const string Tag_ConnectionState_Connected = "connected";

        public const string Tag_ExamAppOpenState_Open = "open";
        public const string Tag_ExamAppOpenState_Close = "close";

        public const string Tag_ExamState_Empty = "empty";
        public const string Tag_ExamState_NoStart = "nostart";
        public const string Tag_ExamState_Start = "start";
        public const string Tag_ExamState_Over = "over";

        public const string Tag_ExamPCState_Idle = "idle";
        public const string Tag_ExamPCState_Busy = "busy";

        ///// <summary>
        ///// 必考
        ///// </summary>
        //public const string PaperCompilingMode_Compulsory = "Compulsory";
        ///// <summary>
        ///// 随机
        ///// </summary>
        //public const string PaperCompilingMode_Random = "Random";


        //public const string ConnectionState_NoConnection = "未连接";
        //public const string ConnectionState_Connected = "已连接";

        public const string WarningMessage = "警告：本计算机程序受著作权法保护。如未经授权而擅自复制或传播本程序（或其中任何部分），\n将受到严厉的民事和刑事制裁，并将在法律许可的最大限度内收到起诉。";

        /** 区域颜色 Error**/
        public static Color ERROR_FIELD_COLOR = Color.Red;

        /** 区域颜色 No_Error **/
        public static Color NO_ERROR_FIELD_COLOR = Color.White;

        /** 未绑定导线巷道背景颜色 **/
        public static Color NO_WIRE_TUNNEL_COLOR = Color.Silver;

        /**绑定导线巷道背景颜色**/
        public static Color WIRED_TUNNEL_COLOR = Color.White;

        /** 定义为掘进巷道的巷道背景颜色**/
        public static Color JJ_TUNNEL_COLOR = Color.LightSalmon;

        /** 定义为回采巷道的巷道背景颜色 **/
        public static Color HC_TUNNEL_COLOR = Color.LightGreen;

        public const string MSG_YES = "是";

        public const string MSG_NO = "否";

        /** 提交成功MSG **/
        public const String SUCCESS_MSG = "提交成功！";

        /** 提交失败MSG **/
        public const String FAILURE_MSG = "提交失败！";

        /** 预警值 **/
        public const Double WARN_VALUE = 4.5;

        /** 删除成功MSG **/
        public const String DEL_SUCCESS_MSG = "删除成功！";

        /** 删除失败MSG **/
        public const String DEL_FAILURE_MSG = "删除失败！";

        /** 日期格式 **/
        public const String DATE_FORMART_YYYY_MM_DD = "yyyy/MM/dd HH:mm:ss";

        /** 日期格式 **/
        public const String DATE_FORMART_YYYY_MM = "yyyy年MM月";

        /** 日期格式 **/
        public const String DATE_FORMART_YYYYMMDD = "yyyyMMdd";

        // add by wuxin at 2020/1/6 - start
        /** 日期格式 **/
        public const String DATE_FORMART_yyyy_MM_dd_HH_mm_ss = "yyyyMMddHHmmss";
        // add by wuxin at 2020/1/6 - end

        /** 日期格式 **/
        public const String DATE_FORMART_H_MM_SS = "yyyy-MM-dd H:mm:ss";

        /** 导出成功MSG **/
        public const String EXPORT_SUCCESS_MSG = "导出成功！";

        /** 导出失败MSG **/
        public const String EXPORT_FAILURE_MSG = "导出失败！";

        /** Double值空值时的默认值 **/
        public const String DOUBLE_DEFAULT_VALUE = "0.000";

        /** 单行颜色 **/
        public static Color SINGLE_LINE = Color.DarkCyan;

        /** 双行颜色 **/
        public static Color DOUBLE_LINE = Color.LightCyan;

        /** 删除确认信息 **/
        public const String DEL_CONFIRM_MSG = "确认删除？";

        /**非空**/
        public const string MSG_NOT_NULL = "不能为空";

        /**数字验证**/
        public const string MSG_MUST_NUMBER = "应为数字";

        /**特殊字符验证**/
        public const string MSG_SP_CHAR = "不能包含特殊字符";

        /**已存在**/
        public const string MSG_ALREADY_HAVE = "已存在";

        /**重复**/
        public const string MSG_DOUBLE_EXISTS = "重复";

        /**请选择**/
        public const string MSG_PLEASE_CHOOSE = "请选择";

        /**请输入**/
        public const string MSG_PLEASE_TYPE_IN = "请输入";

        /**！**/
        public const char SIGN_EXCLAMATION_MARK = '！';

        /**数据获取失败**/
        public const string DATA_GET_FAILURE = "";

        /**空值**/
        public const string DATA_NULL = "";

        //Farpoint默认行数
        public const int FARPOINT_DEFAULT_ROW_COUNT = 50;

        //Farpoint默认列数
        public const int FARPOINT_DEFAULT_COLUMN_COUNT = 25;

        /** 处理标识位 **/
        public const int DISPOSE_FLAG_ZERO = 0;
        public const int DISPOSE_FLAG_ONE = 1;

        /** combox默认不选index **/
        public const int UN_SELECT_INDEX = -1;

        /** number **/
        public const int NUM_ZERO = 0;

        public const string NOTES = "提示";

        /// <summary>
        /// 第N行，X列不能为空
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="columnName">列索引</param>
        /// <returns>提示信息</returns>
        public static string rowNotNull(int rowIndex, string columnName)
        {
            string msg = "第" + (rowIndex + 1) + "行，" + columnName + "不能为空！";
            return msg;
        }

        /// <summary>
        /// 第N行，X列必须为数字
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="columnName">列索引</param>
        /// <returns>提示信息</returns>
        public static string rowMustBeNumber(int rowIndex, string columnName)
        {
            string msg = "第" + (rowIndex + 1) + "行, " + columnName + " 必须为数字！";
            return msg;
        }

        #region 用户登录信息界面相关信息
        public const string LOGIN_NAME_IS_WRONG = "用户名不能为空,且不能包含特殊字符！";

        public const string PASS_WORD_IS_WRONG = "密码不能为空,且不能包含特殊字符！";

        public const string CONFIRM_PASSWORD_IS_WRONG = "确认密码与输入密码不相同！";

        public const string PERMISSION_IS_WRONG = "用户权限不能为空！";

        public const string LOGIN_NAME_EXIST = "用户登录名已存在！";

        public const char PASSWORD_CHAR = '*';

        public const string YES = "√";

        public const string NO = "×";
        #endregion

        public const string EXAMINATION_PC_TYPE_EXAM_NAME = "考试机";
        public const string EXAMINATION_PC_TYPE_PRAC_NAME = "练习机";

        /// <summary>
        /// 考试机类型-考试机
        /// </summary>
        public const string EXAMINATION_PC_TYPE_EXAM = "1";
        /// <summary>
        /// 考试机类型-练习机
        /// </summary>
        public const string EXAMINATION_PC_TYPE_PRAC = "0";

        /// <summary>
        /// 必考
        /// </summary>
        public const string PAPER_COMPILING_MODE_COMPULSORY = "Compulsory";

        /// <summary>
        /// 随机
        /// </summary>
        public const string PAPER_COMPILING_MODE_RANDOM = "Random";

        /// <summary>
        /// 操作类型-内容
        /// </summary>
        public const string OPERATION_TYPE_CONTENT = "content";

        /// <summary>
        ///  操作类型-步骤
        /// </summary>
        public const string OPERATION_TYPE_STEP = "step";
    }
}
