using EventGroup;
using EventGroup.RabbitMQ;
using OCC_Login;
using System;
using System.Windows.Forms;
using SqlSugar;

namespace OCC
{
    public partial class OCC_MAIN : Form
    {
        public OCC_MAIN()
        {
            InitializeComponent();
        }

        private void OCC_MAIN_Load(object sender, EventArgs e)
        {
            DataBaseInitialize();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //在panel中打开窗体
            OCC_Login_Main_Panel login_Main_Panel = new OCC_Login_Main_Panel();
            login_Main_Panel.FormBorderStyle = FormBorderStyle.None;
            login_Main_Panel.TopLevel = false;
            panel1.Controls.Add(login_Main_Panel);
            login_Main_Panel.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RabbitMQManager.Instance.Trigger<R_C_ControlProcessData>("192.168.0.72", new R_C_ControlProcessData(@"C:\Program Files (x86)\Tencent\QQ\Bin\QQScLauncher.exe", true));
        }

        public void ProgressControls(bool isOn)
        {

        }
    }
}
