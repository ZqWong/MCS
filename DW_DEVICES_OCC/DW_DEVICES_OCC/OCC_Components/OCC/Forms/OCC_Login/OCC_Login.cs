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

namespace OCC.Forms
{
    public partial class OCC_Login : UIForm
    {
        public Action LoginCompleteAction;

        public OCC_Login()
        {
            InitializeComponent();

#if DEBUG
            TextUsername.Text = "admin";
            TextPassword.Text = "duowei";
#endif
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            UserDataModel userData = null;
            if (DataBaseCRUDManager.Instance.TryGetUserInfo(TextUsername.Text, TextPassword.Text, out userData))
            {
                DataManager.Instance.CurrentLoginUserData = userData;

                if (!DataBaseCRUDManager.Instance.TryGetUserAuthById(DataManager.Instance.CurrentLoginUserData.UserType, out DataManager.Instance.CurrentUserAuthData))
                {
                    Debug.Error($"DataBaseCRUDManager TryGetUserAuthById Failed Type: {DataManager.Instance.CurrentLoginUserData.UserType}");
                }
                LoginCompleteAction?.Invoke();
            }
        }
    }
}
  
