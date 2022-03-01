using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace MCS
{
    public partial class 考试机配置 : Form
    {
        ExaminationPCBLL _ExaminationPCBLL = new ExaminationPCBLL();

        public 考试机配置()
        {
            InitializeComponent();

            // 加载考试机信息
            LoadExaminationPCInfo();
        }

        /// <summary>
        /// 加载考试机信息
        /// </summary>
        private void LoadExaminationPCInfo()
        {
            DataSet ds;

            ds = _ExaminationPCBLL.GetAllExaminationPCInfo();

            int count = ds.Tables[0].Rows.Count;

            this.dgvExaminationPCInfo.Rows.Clear();

            if (count > 0)
            {
                this.dgvExaminationPCInfo.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    this.dgvExaminationPCInfo.Rows[i].Cells["No"].Value = i + 1;

                    this.dgvExaminationPCInfo.Rows[i].Cells[ExaminationPCModel.ColumnName_ExamPCName].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_ExamPCName].ToString();

                    this.dgvExaminationPCInfo.Rows[i].Cells[ExaminationPCModel.ColumnName_IP].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_IP].ToString();

                    //this.dgvExaminationPCInfo.Rows[i].Cells[ExaminationPCModel.ColumnName_Port].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_Port].ToString();

                    this.dgvExaminationPCInfo.Rows[i].Cells[ExaminationPCModel.ColumnName_Mac].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_Mac].ToString();

                    // add by wuxin at 2019/12/02 - start
                    string type = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_Type].ToString();

                    if (type == Const.EXAMINATION_PC_TYPE_EXAM)
                    {
                        this.dgvExaminationPCInfo.Rows[i].Cells[ExaminationPCModel.ColumnName_Type].Value = Const.EXAMINATION_PC_TYPE_EXAM_NAME;
                    }
                    else if (type == Const.EXAMINATION_PC_TYPE_PRAC)
                    {
                        this.dgvExaminationPCInfo.Rows[i].Cells[ExaminationPCModel.ColumnName_Type].Value = Const.EXAMINATION_PC_TYPE_PRAC_NAME;
                    }
                    // add by wuxin at 2019/12/02 - end

                    // del by wuxin at 2019/12/02 - start
                    //// add by wuxin at 2018/10/14 - start
                    //this.dgvExaminationPCInfo.Rows[i].Cells[ExaminationPCModel.ColumnName_Type].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_Type].ToString();
                    //// add by wuxin at 2018/10/14 - end
                    // del by wuxin at 2019/12/02 - end

                    this.dgvExaminationPCInfo.Rows[i].Cells[ExaminationPCModel.ColumnName_ID].Value = ds.Tables[0].Rows[i][ExaminationPCModel.ColumnName_ID].ToString();

                    this.dgvExaminationPCInfo.Rows[i].Cells["btnUpd"].Value = "修改";

                    this.dgvExaminationPCInfo.Rows[i].Cells["btnDel"].Value = "删除";

                    // del by wuxin at 2019/12/02 - start
                    //this.dgvExaminationPCInfo.Rows[i].Cells["TestWakeUpPC"].Value = "测试开机";

                    //this.dgvExaminationPCInfo.Rows[i].Cells["TestShutDownPC"].Value = "测试关机";

                    //this.dgvExaminationPCInfo.Rows[i].Cells["TestRestartPC"].Value = "测试重启";
                    // del by wuxin at 2019/12/02 - end

                    if (i % 2 != 0)
                    {
                        this.dgvExaminationPCInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dgvExaminationPCInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            考试机添加界面 form = new 考试机添加界面("add", null);
            form.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 子窗体关闭
        /// </summary>
        public void ChildFormClose()
        {
            // 加载考试机信息
            LoadExaminationPCInfo();
        }

        private void dgvExaminationPCInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ID].Value.ToString();

                DataGridViewColumn column = this.dgvExaminationPCInfo.Columns[e.ColumnIndex];

                if (column is DataGridViewButtonColumn)
                {
                    if (column.Name == "btnUpd")
                    {
                        ExaminationPCModel ePCModel = new ExaminationPCModel();
                        ePCModel.ID = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ID].Value.ToString();
                        ePCModel.ExamPCName = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_ExamPCName].Value.ToString();
                        ePCModel.IP = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();
                        //ePCModel.Port = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_Port].Value.ToString();
                        ePCModel.Mac = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_Mac].Value.ToString();

                        // add by wuxin at 2019/12/02 - start

                        string type = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_Type].Value.ToString();

                        if (type == Const.EXAMINATION_PC_TYPE_EXAM_NAME)
                        {
                            ePCModel.Type = "1";
                        }
                        else if (type == Const.EXAMINATION_PC_TYPE_PRAC_NAME)
                        {
                            ePCModel.Type = "0";
                        }

                        // add by wuxin at 2019/12/02 - end

                        // del by wuxin at 2019/12/02 - start
                        //// add by wuxin at 2018/10/14 - start
                        //ePCModel.Type = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_Type].Value.ToString();
                        //// add by wuxin at 2018/10/14 - end
                        // del by wuxin at 2019/12/02 - end

                        考试机添加界面 form = new 考试机添加界面("upd", ePCModel);
                        form.ShowDialog(this);
                    }
                    else if (column.Name == "btnDel")
                    {
                        bool choice = Alert.confirm("是否确认删除？");

                        if (choice)
                        {
                            int count = _ExaminationPCBLL.DelExaminationPCInfo(id);

                            if (count > 0)
                            {
                                Alert.noteMsg("删除成功！");

                                LoadExaminationPCInfo();
                            }
                            else
                            {
                                Alert.errorMsg("删除失败！");
                            }
                        }
                    }
                    // del by wuxin at 2019/12/02 - start
                    //else if (column.Name == "TestWakeUpPC")
                    //{
                    //    string mac = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_Mac].Value.ToString();

                    //    MyTool.WakeUpComputer(mac);
                    //}
                    //else if (column.Name == "TestShutDownPC")
                    //{
                    //    string ip = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();
                    //    MyTool.ShutDownComputer(ip);
                    //}
                    //else if (column.Name == "TestRestartPC")
                    //{
                    //    string ip = this.dgvExaminationPCInfo.Rows[e.RowIndex].Cells[ExaminationPCModel.ColumnName_IP].Value.ToString();
                    //    MyTool.RestartComputer(ip);
                    //}
                    // del by wuxin at 2019/12/02 - end
                }
            }
        }

        private void 考试机信息管理_FormClosing(object sender, FormClosingEventArgs e)
        {
            主界面 parentForm = (主界面)this.Owner;

            parentForm.ChildFormClose();
        }
    }
}
