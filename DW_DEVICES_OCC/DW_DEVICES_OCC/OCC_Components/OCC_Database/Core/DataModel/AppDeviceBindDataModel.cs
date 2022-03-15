using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [SugarTable("occ_app_device_bind")]
    public class AppDeviceBindDataModel : DataModelBase
    {

        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// APPId
        /// </summary>
        [SugarColumn(ColumnName = "app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// 设备Id
        /// </summary>
        [SugarColumn(ColumnName = "device_id")]
        public string DeviceId { get; set; }


        /// <summary>
        /// 安装路径
        /// </summary>
        [SugarColumn(ColumnName = "path")]
        public string Path { get; set; }
    }
}
