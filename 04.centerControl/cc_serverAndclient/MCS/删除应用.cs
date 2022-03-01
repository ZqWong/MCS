using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Model;

namespace MCS
{
    public partial class 删除应用 : Form
    {
        public 删除应用()
        {
            InitializeComponent();
        }

        private void comboBox_appName_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void 删除应用_Load(object sender, EventArgs e)
        {
            DataSet ds;

            ds = 进程管理.GetSingleton()._GetAllAppInfoBLL.GetAppName();

            comboBox_appName.ValueMember = ProcessControlModel.DB_Name;
            comboBox_appName.DisplayMember = ProcessControlModel.DB_Name;
            comboBox_appName.DataSource = ds.Tables[0];
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string del_app_name = comboBox_appName.Text;

            进程管理.GetSingleton()._GetAllAppInfoBLL.DelProcessControlInfoByAppName(del_app_name);

            删除应用_Load(null, null);

            MessageBox.Show(string.Format("已经删除应用:{0} ", del_app_name));
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
