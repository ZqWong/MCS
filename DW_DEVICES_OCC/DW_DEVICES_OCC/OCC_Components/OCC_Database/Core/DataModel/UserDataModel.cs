using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace DataModel
{
    [SugarTable("occ_user")]
    public class UserDataModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [SugarColumn(IsPrimaryKey =true)]
        public string Id { get; set; }
        
        /// <summary>
        /// 登陆账号
        /// </summary>
        [SugarColumn(ColumnName = "login_name")]
        public string LoginName { get; set; }
        
        /// <summary>
        /// 用户昵称
        /// </summary>
        [SugarColumn(ColumnName = "user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [SugarColumn(ColumnName = "user_type")]
        public string UserType { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [SugarColumn(ColumnName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(ColumnName = "sex")]
        public string Sex{ get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [SugarColumn(ColumnName = "dept_id")]
        public string DeptId{ get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(ColumnName = "password")]
        public string Password{ get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        [SugarColumn(ColumnName = "login_ip")]
        public string LoginIp { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        [SugarColumn(ColumnName = "login_date")]
        public string loginDate{ get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [SugarColumn(ColumnName = "create_by", IsOnlyIgnoreUpdate = true)]
        public string CreateBy{ get; set; }

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
        public string Updateby{ get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [SugarColumn(ColumnName = "del_flag")]
        public string DelFlag{ get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "remark")]
        public string Remark{ get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [SugarColumn(ColumnName = "phonenumber")]
        public string Phonenumber { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        [SugarColumn(ColumnName = "user_status")]
        public string UserStatus{ get; set; }


    }
}
