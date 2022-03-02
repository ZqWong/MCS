﻿using DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC_Login
{
    public partial class OCC_Login_Main_Panel : Form
    {
        public OCC_Login_Main_Panel()
        {
            InitializeComponent();
        }

        private void OCC_Login_Main_Panel_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDataModel user = new UserDataModel();
            user.Id = Guid.NewGuid().ToString();
            user.LoginName = "admin";
            user.UserName = "多维";
            user.UserType = "00";
            user.Password = "duowei";
            user.CreateBy = "admin";
            user.CreateTime = DataBaseConnection.Instance.DB.GetDate();
            user.UpdateTime = DataBaseConnection.Instance.DB.GetDate();
            user.Updateby = "admin";
            user.DelFlag = "0";

            DataBaseConnection.Instance.DB.Insertable<UserDataModel>(user).ExecuteCommand();
        }
    }
}