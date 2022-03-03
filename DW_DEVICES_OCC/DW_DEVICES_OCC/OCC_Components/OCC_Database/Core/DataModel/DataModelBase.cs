using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace DataModel
{
    public class DataModelBase
    {
        /// <summary>
        /// 创建者
        /// </summary>
        [SugarColumn(ColumnName = "create_by", IsOnlyIgnoreUpdate = true)]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>        
        [SugarColumn(ColumnName = "create_time", IsOnlyIgnoreUpdate = true)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 最后更新者
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string Updateby { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [SugarColumn(ColumnName = "del_flag")]
        public string DelFlag { get; set; }

    }
}
