using DataModel;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms.OCC_Login
{
    public partial class OCC_Login : Form
    {
        public OCC_Login()
        {
            InitializeComponent();
        }

        private void OCC_Login_Load(object sender, EventArgs e)
        {

        }


        private bool OCC_Login_OnLogin(string userName, string password)
        {
            Debug.Warn($"userName {userName}  password  {password}");
            var targetUserData = DataBaseManager.Instance.DB.Queryable<UserDataModel>().First(u => u.LoginName.Equals(userName));
            if (targetUserData == null) return false;
            return targetUserData.Password.Equals(password);            
        }

    }
}
