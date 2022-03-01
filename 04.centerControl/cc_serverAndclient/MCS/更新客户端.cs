using System;
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
using Common.Model;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using MCS.DB.BLL;
using UserEventData;
using Utilities;

namespace MCS
{


    public partial class 更新客户端 : Form
    {

        public ExaminationPCBLL _ExaminationPCBLL = new ExaminationPCBLL();
        public UpdateClientAppInfoBLL _GetUpdateClientInfoBLL = new UpdateClientAppInfoBLL();

        public 更新客户端()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.folderBrowserDialog_ForSaveFolder.ShowDialog())
            {
                string _SaveFolder = this.folderBrowserDialog_ForSaveFolder.SelectedPath;

                textBox_newClientPath.Text = _SaveFolder;
            }
        }

        private void 更新客户端_Load(object sender, EventArgs e)
        {
            DataSet ds_pc, ds_app;

            ds_pc = _ExaminationPCBLL.GetAllExaminationPCInfo();

            ds_app = _GetUpdateClientInfoBLL.GetAllUpdateClientinfo();

            int count = ds_pc.Tables[0].Rows.Count;

            this.dataGridView_process_edit.Rows.Clear();

            if (count > 0)
            {
                this.dataGridView_process_edit.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {


                    string ip = ds_pc.Tables[0].Rows[i][ExaminationPCModel.ColumnName_IP].ToString();

                    this.dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_IP].Value = ip;

                    DataRow[] temp = ds_app.Tables[0].Select(string.Format("{0} = '{1}'", UpdateClientModel.DB_IP, ip));
                    if (temp.Length > 0)
                    {
                        this.dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_Path].Value =
                            temp[0][UpdateClientModel.DB_Path].ToString();

                        this.dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_ID].Value =
                            temp[0][UpdateClientModel.DB_ID].ToString();
                    }


                    if (i % 2 != 0)
                    {
                        this.dataGridView_process_edit.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dataGridView_process_edit.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }


                    string type = ds_pc.Tables[0].Rows[i][ExaminationPCModel.ColumnName_Type].ToString();

                    if (type == "0")
                    {
                        this.dataGridView_process_edit.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }

                }
            }
        }

        private void button_saveToDB_Click(object sender, EventArgs e)
        {
            dataGridView_process_edit.EndEdit();

            // 开始更新客户端
            if (MessageBox.Show("开始更新客户端，过程中会关闭现在运行的客户端进程！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
            }
            else
            {
                return;
            }

            if (dataGridView_process_edit.SelectedRows.Count > 0)
            {

            }
            else
            {
                MessageBox.Show("请选择客户端!");
            }

            // 发送新版客户端到客户端
            string sourPath = textBox_newClientPath.Text;

            List<string> fileList = new List<string>();

            if (File.Exists(sourPath))
            {
                // 是文件
                FileInfo fif = new FileInfo(sourPath);
                fileList.Add(fif.FullName);

            }
            else if (Directory.Exists(sourPath))
            {
                // 是文件夹
                SendFiles.GetSingleton().GetAllFiles(fileList, new System.IO.DirectoryInfo(sourPath));

            }
            else
            {
                // 没有
                return;
            }

            long totalSize = SendFiles.GetSingleton().GetAllFileLength(fileList);

            foreach (string filePath in fileList)
            {
                // 发送到updateFolder文件夹
                string relative_path = @"\updateFolder" + filePath.Substring(sourPath.Length, filePath.LastIndexOf(@"\") - sourPath.Length);

                var sendData = new R_C_FileData();
                sendData.totalSize = totalSize;

                // 发送处理
                int row = dataGridView_process_edit.Rows.Count;//得到总行数  

                for (int i = 0; i < row; i++)//得到总行数并在之内循环  
                {
                    if (Convert.ToBoolean(dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_CheckBox].Value) == true)
                    {
                        string ip = dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_IP].Value.ToString();

                        string destPath = dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_Path].Value.ToString();

                        SendFiles.GetSingleton().SendFile(filePath, destPath + relative_path, sendTrigger, sendData, ip);
                    }
                }
            }

            MessageBox.Show("发送client完成");

            

            for (int i = 0; i < dataGridView_process_edit.Rows.Count; i++)//得到总行数并在之内循环  
            {
                if (Convert.ToBoolean(dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_CheckBox].Value) == true)
                {
                    string ip = dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_IP].Value.ToString();

                    string destPath = dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_Path].Value.ToString();

                    string updateClientFullName = destPath + @"\updateProgress\cc_client_update.exe";
                    string clientFullName = destPath + @"\cc_client.exe";
                    string newFolderPath = destPath + @"\updateFolder";

                    RabbitMQEventBus.GetSingleton().Trigger<R_C_UpdateData>(ip, new R_C_UpdateData(destPath, newFolderPath, updateClientFullName, clientFullName)); //直接通过事件总线触    
                }
            }

            MessageBox.Show("更新client完成");
        }

        private void sendTrigger(string ip, R_C_FileData _sendData)
        {
            if (ip == "")
            {

            }
            else
            {
                RabbitMQEventBus.GetSingleton().Trigger<R_C_FileData>(ip, _sendData); //直接通过事件总线触           
            }
        }

        private void checkBox_checkAll_CheckedChanged(object sender, EventArgs e)
        {
            int row = dataGridView_process_edit.Rows.Count;//得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (checkBox_checkAll.CheckState == CheckState.Checked)
                    dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_CheckBox].Value = true;
                else if (checkBox_checkAll.CheckState == CheckState.Unchecked)
                    dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_CheckBox].Value = false;
            }
        }

        private void button_updateToDB_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要保存修改吗?", "保存修改", messButton);

            if (dr == DialogResult.Cancel)//如果点击“确定”按钮
            {
                return;
            }


            UpdateClientModel model = new UpdateClientModel();

            int row = dataGridView_process_edit.Rows.Count;//得到总行数  

            for (int i = 0; i < row; i++)//得到总行数并在之内循环  
            {
                // todo 判断id是否为null
                if (dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_ID].Value == null)
                {
                    model.ID = null;
                }
                else
                {
                    model.ID = dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_ID].Value.ToString();
                }

                if (dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_Path].Value == null)
                {
                    model.Path = null;
                }
                else
                {
                    model.Path = dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_Path].Value.ToString();
                }


                model.IP = dataGridView_process_edit.Rows[i].Cells[UpdateClientModel.ColumnName_Edit_IP].Value.ToString();

                _GetUpdateClientInfoBLL.AddOrUpdateUpdateClientInfo(model);

            }

            更新客户端_Load(null, null);
        }

        private void button_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
