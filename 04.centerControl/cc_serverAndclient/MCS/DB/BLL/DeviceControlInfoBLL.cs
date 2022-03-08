using Common.Model;
using System;
using System.Data;

namespace MCS.DB.BLL
{
    /// <summary>
    /// 考试信息相关业务逻辑
    /// </summary>
    public class DeviceControlInfoBLL
    {
        MySqlHelper SqlHelper = new MySqlHelper();

        /// <summary>
        /// 查看所有考试信息
        /// </summary>
        /// <returns>返回值类型为DataSet</returns>
        public DataSet GetDeviceInfo()
        {
            string cmdText = StoredProcedureName.GetDeviceInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        public DataSet GetDeviceClassNameInfo()
        {
            string cmdText = StoredProcedureName.GetDeviceClassNameInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        public DataSet GetDeviceIPInfo()
        {
            // GetDeviceIPInfo
            string cmdText = StoredProcedureName.GetDeviceIPInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        public DataSet GetDeviceSerialInfo()
        {
            string cmdText = StoredProcedureName.GetDeviceSerialInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        public DataSet GetDeviceBaudInfo()
        {
            string cmdText = StoredProcedureName.GetDeviceBaudInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        public DataSet GetDeviceUseSerialInfo()
        {
            string cmdText = StoredProcedureName.GetDeviceUseSerialInfo;
            //string[] para = { };
            //object[] value = { };
            DataSet ds = SqlHelper.GetDataSet(CommandType.StoredProcedure, cmdText, null, null);

            return ds;
        }

        /// <summary>
        /// 添加或修改进程管理信息。
        /// 修改通过ID 控制 如果id为空，则添加新行
        /// </summary>
        /// <returns></returns>
        public int AddOrUpdateDeviceInfo(DeviceControlModel model)
        {
            string cmdText = StoredProcedureName.AddOrUpdateDeviceInfo;
            string[] para = {
                DeviceControlModel.ParamName_ID,
                DeviceControlModel.ParamName_Name,
                DeviceControlModel.ParamName_IP,
                DeviceControlModel.ParamName_CLASS,
                DeviceControlModel.ParamName_SERIAL,

            };

            object[] value = {
                model.ID,
                model.NAME,
                model.IP,
                model.CLASS,
                model.SERIAL,

            };

            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }

        /// <summary>
        /// 删除考试信息
        /// </summary>
        /// <returns></returns>
        public int DelDeviceInfoByClassName(string className)
        {
            string cmdText = StoredProcedureName.DelDeviceInfoByClassName;
            string[] para = {
                DeviceControlModel.ParamName_CLASS,
            };
            object[] value = {
                className
            };
            int count = SqlHelper.ExecuteSql(CommandType.StoredProcedure, cmdText, para, value);

            return count;
        }


    }
}
