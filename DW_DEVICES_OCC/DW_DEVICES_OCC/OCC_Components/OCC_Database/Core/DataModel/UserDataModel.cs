using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace DataModel
{
    [SugarTable("occ_user")]
    public class UserDataModel : DataModelBase
    {
        //public UserDataModel(string userName, string loginName, string password, int userType, string sex, string companyId, string phonenumber, string remark, string email)
        //{
        //    UserName = userName;
        //    LoginName = loginName;
        //    Password = password;
        //    UserType = userType;
        //    Sex = sex;
        //    CompanyId = companyId;
        //    Phonenumber = phonenumber;
        //    Remark = remark;
        //    Email = email;
        //}

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
        public int UserType { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [SugarColumn(ColumnName = "identity_id")]
        public string IdentityId { get; set; }

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
        /// 所属公司ID
        /// </summary>
        [SugarColumn(ColumnName = "company_id")]
        public string CompanyId{ get; set; }

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
