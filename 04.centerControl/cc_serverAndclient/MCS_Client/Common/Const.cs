using System.Configuration;

namespace MCS_Client.Common
{
    public class Const
    {
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public static string ServerIPAddress = ConfigurationManager.AppSettings["ServerIPAddress"];
        /// <summary>
        /// 服务器端口
        /// </summary>
        public static string ServerPort = ConfigurationManager.AppSettings["ServerPort"];

        // upd by wuxin at 2019/12/10 - start
        /// <summary>
        /// VR考试一期Unity客户端名
        /// </summary>
        public static string L1UnityClientName = ConfigurationManager.AppSettings["L1UnityClientName"];
        /// <summary>
        /// VR考试一期Unity客户端路径
        /// </summary>
        public static string L1UnityClientPath = ConfigurationManager.AppSettings["L1UnityClientPath"];
        /// <summary>
        /// VR考试一期Unity客户端配置文件路径
        /// </summary>
        public static string L1UnityClientConfigFilePath = ConfigurationManager.AppSettings["L1UnityClientConfigFilePath"];
        // upd by wuxin at 2019/12/10 - end

        // add by wuxin at 2019/12/10 - start
        /// <summary>
        /// VR考试一期Unity客户端名
        /// </summary>
        public static string L2UnityClientName = ConfigurationManager.AppSettings["L2UnityClientName"];
        /// <summary>
        /// VR考试一期Unity客户端路径
        /// </summary>
        public static string L2UnityClientPath = ConfigurationManager.AppSettings["L2UnityClientPath"];
        /// <summary>
        /// VR考试一期Unity客户端配置文件路径
        /// </summary>
        public static string L2UnityClientConfigFilePath = ConfigurationManager.AppSettings["L2UnityClientConfigFilePath"];
        // add by wuxin at 2019/12/10 - end
    }
}
