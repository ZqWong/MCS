namespace Common
{
    /// <summary>
    /// 通信协议
    /// </summary>
    public class Protocol
    {
        public enum Type
        {
            /// <summary>
            /// 系统
            /// </summary>
            SYSTEM = 0,
            /// <summary>
            /// 考试
            /// </summary>
            EXAM = 1,
            /// <summary>
            /// 心跳检测
            /// </summary>
            HEART_CHECK = 2,
            /// <summary>
            /// 发送文件
            /// </summary>
            SendFiles = 3,
        }

        public enum Area
        {

        }

        public enum Command
        {
            /// <summary>
            /// 应用程序打开状态
            /// </summary>
            ApplicationOpenState = 0,
            // 开始考试
            StartExam = 1,
            /// <summary>
            /// 考试开始
            /// </summary>
            ExamStart = 2,
            /// <summary>
            /// 考试结束
            /// </summary>
            ExamOver = 3,
            /// <summary>
            /// 回收
            /// </summary>
            Recycle = 4,
            /// <summary>
            /// 发送文件-保存地址
            /// </summary>
            SendFiles_SavePath,
            /// <summary>
            /// 发送文件-所有的文件名
            /// </summary>
            SendFiles_FileNames,
            /// <summary>
            /// 发送文件-所有的文件长度
            /// </summary>
            SendFiles_FileLengths,
            /// <summary>
            /// 发送文件-所有的文件长度
            /// </summary>
            SendFiles_SendFile,
        }

    }
}
