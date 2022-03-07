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
            if (DataManager.Instance.GetUserData(TextUsername.Text, TextPassword.Text))
            {
                this.Hide();
                OCC occ = new OCC();
                occ.ShowDialog();                
            }
        }
    }
}
  
