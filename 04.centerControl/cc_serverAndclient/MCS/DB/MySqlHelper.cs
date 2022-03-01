using MCS.Common;
//using System.Configuration;
using System;
using System.Data;
using DW_CC_NET.tools;
using MySql.Data.MySqlClient;
using Utilities;

namespace MCS.DB
{
    /// <summary>
    /// MYSQLHelper的摘要说明
    /// </summary>
    public class MySqlHelper
    {
        MySqlConnection conn;
        MySqlCommand cmd;

        static string host = ConfigHelper.GetSingleton().GetAppConfig("DBhost");  //主机
        static string id = ConfigHelper.GetSingleton().GetAppConfig("DBname");  //***不要变***  
        static string pwd = ConfigHelper.GetSingleton().GetAppConfig("DBpassword");  //密码  
        static string SslMode = ConfigHelper.GetSingleton().GetAppConfig("DBSslMode");  //密码 
        static string allowPublicKeyRetrieval = ConfigHelper.GetSingleton().GetAppConfig("DBallowPublicKeyRetrieval");  //密码 
        static string database = "vrexaminationmaincontrolsystemdb";//数据库名    

        public MySqlHelper()
        {
            // 数据库连接字符串
            //string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            string connectionString = string.Format("Server = {0}; Database = {1}; User ID = {2}; Password = {3}; SslMode={4}; allowPublicKeyRetrieval={5};", host, database, id, pwd, SslMode == null ? "None":SslMode, allowPublicKeyRetrieval==null?"true": allowPublicKeyRetrieval);
            conn = new MySqlConnection(connectionString);
            cmd = conn.CreateCommand();
        }

        //// 用于缓存参数的HASH表
        //private Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 执行添加、删除、更新操作
        /// </summary>
        /// <param name="commandType">Command类型</param>
        /// <param name="cmdText">SQL语句或者存储过程名</param>
        /// <param name="para">null或者存储过程参数的集合</param>
        /// <param name="value">null或者存储过程参数值的集合</param>
        /// <returns>返回值为int类型</returns>
        public int ExecuteSql(CommandType cmdType, string cmdText, string[] para, object[] value)
        {
            PrepareCommand(cmdType, cmdText, para, value);
            int count = 0;
            try
            {
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                count = 0;

                // add by wuxin at 2020/01/06 - start
                //Alert.errorMsg("数据库操作抛错，cmdText：" + cmdText + "\nException: " + e);
                NlogHandler.GetSingleton().Error("数据库操作抛错，cmdText：" + cmdText + "\nException: " + e);
                // add by wuxin at 2020/01/06 - end
            }

            // 清除参数
            cmd.Parameters.Clear();
            conn.Close();

            return count;
        }

        /// <summary>
        /// 执行带函数的操作，如 count（*）
        /// </summary>
        /// <param name="commandType">Command类型</param>
        /// <param name="cmdText">SQL语句或者存储过程名</param>
        /// <param name="para">null或者存储过程参数的集合</param>
        /// <param name="value">null或者存储过程参数值的集合</param>
        /// <returns>返回值为object类型</returns>
        public object ExecuteSqlForCount(CommandType cmdType, string cmdText, string[] para, object[] value)
        {
            PrepareCommand(cmdType, cmdText, para, value);

            object count = null;

            try
            {
                count = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                // add by wuxin at 2020/01/06 - start
                Alert.errorMsg("数据库操作抛错，cmdText：" + cmdText + "\nException: " + e);
                // add by wuxin at 2020/01/06 - end
            }

            //清除参数
            cmd.Parameters.Clear();
            conn.Close();

            return count;
        }

        /// <summary>
        /// 执行select操作
        /// </summary>
        /// <remarks>
        /// 举例:
        ///  MySqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns>包含结果的读取器</returns>
        public MySqlDataReader ExecuteReader(CommandType cmdType, string cmdText, string[] para, object[] value)
        {
            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            //因此commandBehaviour.CloseConnection 就不会执行
            try
            {
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                PrepareCommand(cmdType, cmdText, para, value);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                //清除参数
                cmd.Parameters.Clear();
                return reader;
            }
            catch (Exception e)
            {
                // add by wuxin at 2020/01/06 - start
                Alert.errorMsg("数据库操作抛错，cmdText：" + cmdText + "\nException: " + e);
                // add by wuxin at 2020/01/06 - end

                //关闭连接，抛出异常
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="connectionString">一个有效的连接字符串</param>
        /// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
        /// <param name="cmdText">存储过程名称或者sql命令语句</param>
        /// <param name="commandParameters">执行命令所用参数的集合</param>
        /// <returns></returns>
        public DataSet GetDataSet(CommandType cmdType, string cmdText, string[] para, object[] value)
        {
            //在这里我们用一个try/catch结构执行sql文本命令/存储过程，因为如果这个方法产生一个异常我们要关闭连接，因为没有读取器存在，
            try
            {
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                PrepareCommand(cmdType, cmdText, para, value);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                //清除参数
                cmd.Parameters.Clear();
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                //throw e;
                // upd by wuxin at 2020/01/06 - start
                Alert.errorMsg("数据库操作抛错，cmdText：" + cmdText + "\nException: " + e);
                // upd by wuxin at 2020/01/06 - end
                DataSet ds = new DataSet();
                ds.Tables.Add(new DataTable());
                return ds;
            }
        }

        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmdType">命令类型例如 存储过程或者文本</param>
        /// <param name="cmdText">命令文本,例如:Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        /// <param name="cmdParms">执行命令的参数数值</param>
        private void PrepareCommand(CommandType cmdType, string cmdText, string[] para, object[] value)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            cmd.Parameters.Clear(); // 清空cmd以前的参数

            ////if (trans != null)
            ////    cmd.Transaction = trans;

            if (para != null)
            {
                for (int i = 0; i < para.Length; i++)
                    cmd.Parameters.AddWithValue(para[i], value[i]);
            }

            //int a = 0;
            //cmd.Parameters.Add("_TotalCount", MySqlDbType.Int32, 8).Value = a;
            //int b = 0;
            //cmd.Parameters.Add("_PageCount", MySqlDbType.Int32, 8).Value = b;
        }
    }
}
