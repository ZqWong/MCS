using EventGroup;
using EventGroup.RabbitMQ;
using System;
using System.Windows.Forms;
using SqlSugar;
using Sunny.UI;
using OCC.Forms.OCC_Login;
using OCC.Core.LocalConfig;

namespace OCC
{
    public partial class OCC : UIForm
    {
        public OCC()
        {
            InitializeComponent();
        }

        private void OCC_MAIN_Load(object sender, EventArgs e)
        {
            DataBaseInitialize();

            if (LocalConifgManager.Instance.SystemConfig.DataModel.ShowLoginForm)
            {
                ShowForm(new OCC_Login());
            }
            else
            {
                //TODO : 如果配置不显示登陆界面，则直接显示内容并且自动登录admin账号.
            }
        }

        public void DataBaseInitialize()
        {
#if DEBUG
            string server = "127.0.0.1";
#else
            //TODO: 通过配置读取真正的服务器地址
            string server = "192.168.0.198"; 
#endif
            var connectionString = string.Format(
                DataBaseConst.SQL_SUGAR_CONNECTION_STRING_FORMAT,
                server,
                "occ",
                "root",
                "duowei",
                null,
                true);

            DataBaseManager.Instance.Initialize(connectionString, true, DbType.MySql, true);
        }

        private void ShowForm(Form form)
        {
            MainFormContent.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Parent = this.MainFormContent;
            form.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            RabbitMQManager.Instance.Trigger<R_C_ControlProcessData>("192.168.0.72", new R_C_ControlProcessData(@"C:\Program Files (x86)\Tencent\QQ\Bin\QQScLauncher.exe", true));
        }
    }
}
