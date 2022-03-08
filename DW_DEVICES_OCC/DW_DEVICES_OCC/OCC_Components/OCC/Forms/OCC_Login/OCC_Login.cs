using DataModel;
using OCC.Core;
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

#if DEBUG
            TextUsername.Text = "admin";
            TextPassword.Text = "duowei";
#endif
        }

        private void OCC_Login_Load(object sender, EventArgs e)
        {
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            UserDataModel userData = null;
            if (DataBaseCRUDManager.Instance.TryGetUserData(TextUsername.Text, TextPassword.Text, out userData))
            {
                DataManager.Instance.CurrentLoginUserData = userData;

                if (!DataBaseCRUDManager.Instance.TryGetUserAuthById(DataManager.Instance.CurrentLoginUserData.UserType, out DataManager.Instance.CurrentUserAuthData))
                {
                    Debug.Error($"DataBaseCRUDManager TryGetUserAuthById Failed Type: {DataManager.Instance.CurrentLoginUserData.UserType}");
                } 
                this.Hide();
                OCC occ = new OCC();
                occ.ShowDialog();                
            }
        }
    }
}
  
