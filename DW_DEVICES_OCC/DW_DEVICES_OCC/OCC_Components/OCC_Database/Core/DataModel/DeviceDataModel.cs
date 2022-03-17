using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [SugarTable("occ_device")]
    public class DeviceDataModel : DataModelBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }

        /// <summary>
        /// 公司名
        /// </summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "remark")]
        public string Remark { get; set; }

        /// <summary>
        /// ip地址
        /// </summary>
        [SugarColumn(ColumnName = "ip")]
        public string IP { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        [SugarColumn(ColumnName = "port")]
        public string Port { get; set; }

        /// <summary>
        /// 串口号
        /// </summary>
        [SugarColumn(ColumnName = "serial")]
        public string Serial { get; set; }

        /// <summary>
        /// MAC地址
        /// </summary>
        [SugarColumn(ColumnName = "mac")]
        public string MAC { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        [SugarColumn(ColumnName = "type")]
        public int DeviceType { get; set; }
    }
}
