//using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 读配置
        /// </summary>
        /// <returns></returns>
        public static string[] ReadFromText()
        {
            string FileName = Application.StartupPath + @"\DBConfig.ini";
            ArrayList list = new ArrayList();
            if (File.Exists(FileName))
            {
                StreamReader sr = new StreamReader(FileName, Encoding.Default);
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    list.Add(s);
                }
            }
            return (string[])list.ToArray(typeof(string));
        }

        /// <summary>
        /// 备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            string[] ary = ReadFromText();

            string host = ary[0];
            string port = ary[1];
            string user = ary[2];
            string password = ary[3];
            string database = ary[4];
            string fileName = database + "_bak_" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string bakPath = Application.StartupPath + "\\DBBackup\\" + fileName + ".sql";

            string mysqldumpPath = Application.StartupPath;

            string cmdStr = "/c " + mysqldumpPath + "\\mysqldump -h" + host + " -P" + port + " -u" + user + " -p" + password + " -R -E " + database + " > " + bakPath;

            try
            {
                //String appDirecroty = System.Windows.Forms.Application.StartupPath + "\\";
                //Cmd.StartCmd(appDirecroty, cmdStr);

                System.Diagnostics.Process.Start("cmd", cmdStr);

                MessageBox.Show("数据库备份成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据库备份失败！{ex}");
            }
        }

        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                string[] ary = ReadFromText();

                string host = ary[0];
                string port = ary[1];
                string user = ary[2];
                string password = ary[3];
                string database = ary[4];

                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dbFilePath = openFileDialog.FileName;

                    string mysqldumpPath = Application.StartupPath;

                    //string cmdStr = "/c " + mysqldumpPath + "\\mysqldump -h" + host + " -P" + port + " -u" + user + " -p" + password + " -R -E " + database + " > " + bakPath;

                    string cmdStr = "/c " + mysqldumpPath + "\\mysql --force -h" + host + " -P" + port + " -u" + user + " -p" + password + " " + database + " < " + dbFilePath;

                    DialogResult result = MessageBox.Show("您是否真的想覆盖以前的数据库吗？那么以前的数据库数据将丢失！！！", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        //Cmd.StartCmd(appDirecroty, command);

                        System.Diagnostics.Process.Start("cmd", cmdStr);

                        MessageBox.Show("数据库还原成功！");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库还原失败！");
            }
        }

        //    public class Cmd
        //    {
        //        /// <summary>
        //        /// 执行Cmd命令
        //        /// </summary>
        //        /// <param name="workingDirectory">要启动的进程的目录</param>
        //        /// <param name="command">要执行的命令</param>
        //        public static void StartCmd(String workingDirectory, String command)
        //        {
        //            Process p = new Process();
        //            p.StartInfo.FileName = "cmd.exe";
        //            p.StartInfo.WorkingDirectory = workingDirectory;
        //            p.StartInfo.UseShellExecute = false;
        //            p.StartInfo.RedirectStandardInput = true;
        //            p.StartInfo.RedirectStandardOutput = true;
        //            p.StartInfo.RedirectStandardError = true;
        //            p.StartInfo.CreateNoWindow = true;
        //            p.Start();
        //            p.StandardInput.WriteLine(command);
        //            p.StandardInput.WriteLine("exit");
        //        }
        //    }
        //}
    }
}
