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
    public partial class 增加应用 : Form
    {
        public 增加应用()
        {
            InitializeComponent();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            DataSet ds_app_name = 进程管理.GetSingleton()._GetAllAppInfoBLL.GetAppName();
            DataRow[] rows = ds_app_name.Tables[0]
                .Select(string.Format("{0} = '{1}'", ProcessControlModel.DB_Name, textBox_appName.Text));

            if (rows.Length > 0)
            {
                MessageBox.Show(string.Format("不能重复添加应用：{0} ", textBox_appName.Text));
                return;
            }
            else
            {
                DataSet ds_pc_info = 进程管理.GetSingleton()._ExaminationPCBLL.GetAllExaminationPCInfo();

                int count = ds_pc_info.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string ip = ds_pc_info.Tables[0].Rows[i][ExaminationPCModel.ColumnName_IP].ToString();

                    ProcessControlModel model = new ProcessControlModel();
                    model.ID = null;
                    model.Path = textBox_defaultPath.Text;
                    model.IP = ip;
                    model.AppName = textBox_appName.Text;

                    进程管理.GetSingleton()._GetAllAppInfoBLL.AddOrUpdateProgressControlInfo(model);
                }
                MessageBox.Show(string.Format("保存到数据库完成：{0} ", textBox_appName.Text));
            }
            //进程管理.GetSingleton().编辑运行地址ToolStripMenuItem_Click(null, null);
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_defaultPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void 增加应用_Load(object sender, EventArgs e)
        {

        }
    }
}
