using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DeviceTypeDataModel : DataModelBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
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
    }
}
