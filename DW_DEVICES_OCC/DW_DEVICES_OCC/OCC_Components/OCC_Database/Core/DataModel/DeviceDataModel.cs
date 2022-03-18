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
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

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

        /// <summary>
        /// 连接类型 0 网口 1串口
        /// </summary>
        [SugarColumn(ColumnName = "connect_type")]
        public int ConnectType { get; set; }

        /// <summary>
        /// 串口连接波特率
        /// </summary>
        [SugarColumn(ColumnName = "buad")]
        public int Buad { get; set; }        
    }
}
