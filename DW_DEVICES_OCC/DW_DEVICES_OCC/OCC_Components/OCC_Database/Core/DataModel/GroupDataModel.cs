using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [SugarTable("occ_group")]
    public class GroupDataModel : DataModelBase
    {

        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 分组名
        /// </summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }

        ///// <summary>
        ///// 设备Id
        ///// </summary>
        //[SugarColumn(ColumnName = "device_id")]
        //public int DeviceId { get; set; }

        /// <summary>
        /// 所属公司信息
        /// </summary>
        [SugarColumn(ColumnName = "company_id")]
        public int CompanyId { get; set; }

        /// <summary>
        /// 延迟
        /// </summary>
        //[SugarColumn(ColumnName = "delay")]
        //public int Delay { get; set; }

        ///// <summary>
        ///// 操作ID
        ///// </summary>
        //[SugarColumn(ColumnName = "execute_id")]
        //public int ExecuteId { get; set; }

        ///// <summary>
        ///// 排序
        ///// </summary>
        //[SugarColumn(ColumnName = "sort_id")]
        //public int SortId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(ColumnName = "remark")]
        public string Remark { get; set; }

    }
}
