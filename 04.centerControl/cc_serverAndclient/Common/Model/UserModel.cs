namespace Common.Model
{
    public enum EnumUserLevel
    {
        Admin = 0,
        Normal = 1
    }


    public class UserModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public static string Table_Name = "t_user_info";
        /// <summary>
        /// 列名：
        /// </summary>
        public static string ColumnName_ID = "ID";
        /// <summary>
        /// 列名：
        /// </summary>
        public static string ColumnName_UserName = "UserName";
        /// <summary>
        /// 列名：
        /// </summary>
        public static string ColumnName_Password = "Password";
        /// <summary>
        /// 列名：
        /// </summary>
        public static string ColumnName_Level = "Level";


        /// <summary>
        /// 参数名：
        /// </summary>
        public static string ParamName_ID = "_ID";
        /// <summary>
        /// 参数名：
        /// </summary>
        public static string ParamName_UserName = "_UserName";
        /// <summary>
        /// 参数名：
        /// </summary>
        public static string ParamName_Password = "_Password";
        /// <summary>
        /// 参数名：
        /// </summary>
        public static string ParamName_Level = "_Level";


        private string id;

        private string userName;

        private string password;

        private string level;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }
    }
}
