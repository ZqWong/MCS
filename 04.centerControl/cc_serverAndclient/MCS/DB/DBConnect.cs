using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DW_CC_NET.tools;
using SqlSugar;

namespace MainTrain.Tools
{
    class DBConnect
    {
        private static DBConnect _instance;
        private static readonly object syslock = new object();

        public SqlSugarClient db;

        public static DBConnect GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new DBConnect();
                    }
                }
            }

            return _instance;
        }

        private DBConnect()
        {
            string host = ConfigHelper.GetSingleton().GetAppConfig("DBhost");  //主机
            string id = ConfigHelper.GetSingleton().GetAppConfig("DBname");  //***不要变***  
            string pwd = ConfigHelper.GetSingleton().GetAppConfig("DBpassword");  //密码  
            string SslMode = ConfigHelper.GetSingleton().GetAppConfig("DBSslMode");  //密码 
            string allowPublicKeyRetrieval = ConfigHelper.GetSingleton().GetAppConfig("DBallowPublicKeyRetrieval");  //密码 
            string database = "vrexaminationmaincontrolsystemdb";//数据库名    

            //todo GetAppConfig函数添加未找到值返回默认的功能
            //string host = "127.0.0.1";  //主机
            //string id = "root";  //***不要变***  
            //string pwd = "lnkyzhang";  //密码  
            //string SslMode = "None";  //密码 
            //string allowPublicKeyRetrieval = "True";  //密码 
            //string database = "930EMainTrain";//数据库名    

            string conString = string.Format(
                "Server = {0}; Database = {1}; User ID = {2}; Password = {3}; SslMode={4}; allowPublicKeyRetrieval={5};",
                host, database, id, pwd, SslMode == null ? "None" : SslMode,
                allowPublicKeyRetrieval == null ? "true" : allowPublicKeyRetrieval);
            //创建数据库对象
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = conString,//连接符字串
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute//从特性读取主键自增信息
            });
        }
    }
}
