using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [SugarTable("occ_app")]
    public class AppDataModel : DataModelBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }

        /// <summary>
        /// 应用名
        /// </summary>
        [SugarColumn(ColumnName = "app_name")]
        public string AppName { get; set; }

        /// <summary>
        /// 应用路径（绝对）
        /// </summary>
        [SugarColumn(ColumnName = "default_path")]
        public string AppPath { get; set; }

        ///// <summary>
        ///// 绑定设备ID
        ///// </summary>
        //[SugarColumn(ColumnName = "device_id")]
        //public string BindingedDeviceId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "remark")]
        public string Remark { get; set; }

    }
}
