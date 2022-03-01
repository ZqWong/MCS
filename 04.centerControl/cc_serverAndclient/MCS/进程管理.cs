using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Model;
using DW_CC_NET.RabbitMQ;
using MCS.Common;
using MCS.DB.BLL;
using UserEventData;

namespace MCS
{
    public partial class 进程管理 : Form
    {
        private static readonly object syslock = new object();

        private static 进程管理 _instance;
        private static SynchronizationContext _uiContext;

        public static 进程管理 GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new 进程管理();
                    }
                }
            }

            return _instance;
        }

        public SynchronizationContext GetSyncContext()
        {
            return _uiContext;
        }


        public ExaminationPCBLL _ExaminationPCBLL = new ExaminationPCBLL();
        public ProcessControlAppInfoBLL _GetAllAppInfoBLL = new ProcessControlAppInfoBLL();

        private 进程管理()
        {
            _uiContext = SynchronizationContext.Current;
            InitializeComponent();
            编辑运行地址ToolStripMenuItem_Click(null, null);
        }
        
        private void 进程管理_Load(object sender, EventArgs e)
        {
            checkBox_checkAll.CheckState = CheckState.Unchecked;
        }

        private void 编辑运行地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_edit.Visible = true;
            DataSet ds;

            ds = _GetAllAppInfoBLL.GetAppName();

            comboBox_appName.ValueMember = ProcessControlModel.DB_Name;
            comboBox_appName.DisplayMember = ProcessControlModel.DB_Name;
            comboBox_appName.DataSource = ds.Tables[0];

        }

        private void comboBox_appName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.checkBox_checkAll.Checked = false;

            DataSet ds_pc, ds_app;

            ds_pc = _ExaminationPCBLL.GetAllExaminationPCInfo();

            ds_app = _GetAllAppInfoBLL.GetAllAppinfoByName(comboBox_appName.SelectedValue.ToString());

            int count = ds_pc.Tables[0].Rows.Count;

            this.dataGridView_process_edit.Rows.Clear();

            if (count > 0)
            {
                this.dataGridView_process_edit.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {


                    string ip = ds_pc.Tables[0].Rows[i][ExaminationPCModel.ColumnName_IP].ToString();

                    this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_IP].Value = ip;

                    this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Name].Value = comboBox_appName.SelectedValue.ToString();

                    DataRow[] temp = ds_app.Tables[0].Select(string.Format("{0} = '{1}'", ProcessControlModel.DB_IP, ip));
                    if (temp.Length > 0)
                    {
                        this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Path].Value =
                            temp[0][ProcessControlModel.DB_Path].ToString();

                        this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_ID].Value =
                            temp[0][ProcessControlModel.DB_ID].ToString();
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


        /// <summary>
        /// 判断DS是否为空
        /// </summary>
        /// <param name="ds">需要判断的ds</param>
        /// <returns>如果ds为空，返回true</returns>
        private bool JudgeDsEmpty(DataSet ds)
        {
            bool Flag = false;
            if ((ds == null) || (ds.Tables.Count == 0) || (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0))
            {
                Flag = true;
            }
            return Flag;
        }

        private void checkBox_checkAll_CheckedChanged(object sender, EventArgs e)
        {
            int row = dataGridView_process_edit.Rows.Count;//得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (checkBox_checkAll.CheckState == CheckState.Checked)
                    dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.CheckBox].Value = true;
                else if (checkBox_checkAll.CheckState == CheckState.Unchecked)
                    dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.CheckBox].Value = false;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 增加应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            增加应用 form = new 增加应用();
            form.ShowDialog();
        }

        private void 删除应用ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            删除应用 form = new 删除应用();
            form.ShowDialog();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要保存修改吗?", "保存修改", messButton);

            if (dr == DialogResult.Cancel)//如果点击“确定”按钮
            {
                return;
            }


            ProcessControlModel model = new ProcessControlModel();

            int row = dataGridView_process_edit.Rows.Count;//得到总行数  

            for (int i = 0; i < row; i++)//得到总行数并在之内循环  
            {
                // todo 判断id是否为null
                if (dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_ID].Value == null)
                {
                    model.ID = null;
                }
                else
                {
                    model.ID = dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_ID].Value.ToString();
                }

                if (dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Path].Value == null)
                {
                    model.Path = null;
                }
                else
                {
                    model.Path = dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Path].Value.ToString();
                }


                model.AppName = dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Name].Value.ToString();
                model.IP = dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_IP].Value.ToString();

                _GetAllAppInfoBLL.AddOrUpdateProgressControlInfo(model);

            }
        }

        private void 运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView_process_edit.EndEdit();

            int row = dataGridView_process_edit.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (Convert.ToBoolean(dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.CheckBox].Value) == true)
                {
                    string ip = this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_IP].Value.ToString();
                    string processName = this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Name].Value.ToString();
                    string processFilePathName = this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Path].Value.ToString();

                    if (dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Path].Value.ToString() == "")
                        MessageBox.Show(string.Format("请指定客户端IP :{0}，的APP文件执行路径", ip));

                    LogHelper.WriteLog(string.Format("目标计算机 ip: {0} 开启进程 {1}", ip, processName));

                    RabbitMQEventBus.GetSingleton()
                        .Trigger<R_C_ControlProcessData
                        >(ip, new R_C_ControlProcessData(processFilePathName, true)); //直接通过事件总线触发
                }
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView_process_edit.EndEdit();

            int row = dataGridView_process_edit.Rows.Count; //得到总行数  

            for (int i = 0; i < row; i++) //得到总行数并在之内循环  
            {
                if (Convert.ToBoolean(dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.CheckBox].Value) == true)
                {
                    string ip = this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_IP].Value.ToString();
                    string processName = this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Name].Value.ToString();
                    string processFilePathName = this.dataGridView_process_edit.Rows[i].Cells[ProcessControlModel.ColumnName_Edit_Path].Value.ToString();

                    //List<string> temp;
                    //if (processDict.TryGetValue(ip, out temp))
                    //{
                    //    if (temp.Contains(processName))
                    //    {
                    //        temp.Remove(processName);
                    //    }
                    //}
                    //else
                    //{
                    //}

                    LogHelper.WriteLog(string.Format("目标计算机 ip: {0} 关闭进程 {1}", ip, processName));

                    RabbitMQEventBus.GetSingleton()
                        .Trigger<R_C_ControlProcessData
                        >(ip, new R_C_ControlProcessData(processFilePathName, false)); //直接通过事件总线触发
                }
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            编辑运行地址ToolStripMenuItem_Click(null, null);
        }
    }
}

