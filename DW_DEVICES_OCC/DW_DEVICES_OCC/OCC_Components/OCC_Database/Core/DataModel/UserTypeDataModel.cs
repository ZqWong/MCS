using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [SugarTable("occ_user_type")]
    public class UserTypeDataModel : DataModelBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public int Id { get; set; }

        /// <summary>
        /// 用户类型名称
        /// </summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 用户类型2进制码
        /// </summary>
        [SugarColumn(ColumnName = "authority_level")]
        public int AuthLevel { get; set; }
    }
}
