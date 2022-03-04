using DataModel;
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
            user.UserType = "1";
            user.Password = "duowei";
            user.CreateBy = "wzq";
            user.CreateTime = DataBaseManager.Instance.DB.GetDate();
            user.UpdateTime = DataBaseManager.Instance.DB.GetDate();
            user.Updateby = "wzq";
            user.DelFlag = "0";

            DataBaseManager.Instance.DB.Insertable<UserDataModel>(user).ExecuteCommand();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBaseManager.Instance.DB.Queryable<UserDataModel>().ToList().ForEach(x =>
            {
                Debug.Error(x.CreateBy);
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CompanyDataModel company = new CompanyDataModel();
            company.Id = Guid.NewGuid().ToString();
            company.Remark = "辽宁多维科技有限公司";
            company.Name = "辽宁多维科技有限公司";
            company.CreateBy = "wzq";
            company.CreateTime = DataBaseManager.Instance.DB.GetDate();
            company.UpdateTime = DataBaseManager.Instance.DB.GetDate();
            company.Updateby = "wzq";
            company.DelFlag = "0";

            DataBaseManager.Instance.DB.Insertable<CompanyDataModel>(company).ExecuteCommand();
        }
    }
}
