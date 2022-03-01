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
    public partial class 类型管理 : Form
    {
        public 类型管理()
        {
            InitializeComponent();
        }

        private void 类型管理_Load(object sender, EventArgs e)
        {

            DataSet ds;

            ds = 其他设备控制.GetSingleton()._GetDeviceInfoBLL.GetDeviceClassNameInfo();

            // 添加一个空行
            DataRow row1 = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.InsertAt(row1, 0);

            comboBox_class.ValueMember = DeviceControlModel.DB_CLASS;
            comboBox_class.DisplayMember = DeviceControlModel.DB_CLASS;
            comboBox_class.DataSource = ds.Tables[0];
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string messageboxShow = "确定 ";

            if (this.textBox_className.Text != "")
            {
                messageboxShow += "添加" + this.textBox_className.Text + "  ";
            }

            if (this.comboBox_class.Text != "")
            {
                messageboxShow += "删除" + this.comboBox_class.Text + "  ";
            }

            messageboxShow += "?";

            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show(messageboxShow, "确定", messButton);

            if (dr == DialogResult.Cancel) //如果点击“确定”按钮
            {
                return;
            }

            if (this.textBox_className.Text != "")
            {
                DeviceControlModel model = new DeviceControlModel();

                model.ID = null;
                model.NAME = this.textBox_className.Text + "1";
                model.IP = null;
                model.CLASS = this.textBox_className.Text;
                model.SERIAL = null;

                其他设备控制.GetSingleton()._GetDeviceInfoBLL.AddOrUpdateDeviceInfo(model);
            }
            
            if (this.comboBox_class.Text != "")
            {
                其他设备控制.GetSingleton()._GetDeviceInfoBLL.DelDeviceInfoByClassName(this.comboBox_class.Text);
            }
        }


        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
