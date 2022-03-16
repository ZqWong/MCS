using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

/// <summary>
/// 创建一个全局的数据库管理类
/// </summary>
public class DataBaseManager: LockedSingletonClass<DataBaseManager>
{
    public SqlSugarClient DB;
    public bool Initialize(string connectionString, bool isAutoCloseConnection = true, DbType dbType = DbType.MySql, bool needLogExecutingSql = false)
    {
        try
        {
            Initialize(connectionString, isAutoCloseConnection, dbType);

            DB.Aop.OnLogExecuting = (sql, pars) =>
            {
                Debug.Info($"执行 sql : {sql} \n pars: {pars}");
            };

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }     
    }

    public void Initialize(string connectionString, bool isAutoCloseConnection = true, DbType dbType = DbType.MySql)
    {
        try
        {
            DB = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                IsAutoCloseConnection = isAutoCloseConnection,
                DbType = dbType
            });
        }
        catch (Exception ex)
        {
            throw ex;
        }        
    }
}

