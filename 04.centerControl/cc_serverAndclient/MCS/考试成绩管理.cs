using MCS.Common;
using Common.Model;
using MCS.DB.BLL;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MCS
{
    public partial class 考试成绩管理 : Form
    {
        PageBLL _PageBLL = new PageBLL();
        ExaminationSubjectBLL _ExaminationSubjectBLL = new ExaminationSubjectBLL();
        ExamineeCompanyBLL _ExamineeCompanyBLL = new ExamineeCompanyBLL();
        ExaminationBLL _ExaminationBLL = new ExaminationBLL();

        // 总记录数
        public int _RecordCount = 0;

        // 分页查询Where条件
        string strWhere = "";

        public 考试成绩管理()
        {
            InitializeComponent();

            // 加载公司信息
            LoadExamineeCompanyInfo();
            // 加载考试信息
            LoadExaminationInfo();

            // 加载考试结果信息数据
            BindDataWithPage(1, 10);
        }

        /// <summary>
        /// 加载考生所属公司信息
        /// </summary>
        private void LoadExamineeCompanyInfo()
        {
            this.cbExamineeCompany.Items.Clear();

            DataSet ds = _ExamineeCompanyBLL.GetAllExamineeCompany();

            //this.cbExamineeCompany.DataSource = ds.Tables[0];
            //cbExamineeCompany.DisplayMember = ExamineeCompanyModel.ColumnName_ExamineeCompanyName;
            //cbExamineeCompany.ValueMember = ExamineeCompanyModel.ColumnName_ExamineeCompanyID;

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                ArrayList list = new ArrayList();

                ExamineeCompanyModel defaultEcm = new ExamineeCompanyModel();
                defaultEcm.ExamineeCompanyID = "";
                defaultEcm.ExamineeCompanyName = "";

                list.Add(defaultEcm);

                for (int i = 0; i < count; i++)
                {
                    string examineeCompanyID = ds.Tables[0].Rows[i][ExamineeCompanyModel.ColumnName_ExamineeCompanyID].ToString();
                    string examineeCompanyName = ds.Tables[0].Rows[i][ExamineeCompanyModel.ColumnName_ExamineeCompanyName].ToString();

                    ExamineeCompanyModel ecm = new ExamineeCompanyModel();
                    ecm.ExamineeCompanyID = examineeCompanyID;
                    ecm.ExamineeCompanyName = examineeCompanyName;

                    list.Add(ecm);
                }

                this.cbExamineeCompany.DataSource = list;
                this.cbExamineeCompany.DisplayMember = ExamineeCompanyModel.ColumnName_ExamineeCompanyName;
                this.cbExamineeCompany.ValueMember = ExamineeCompanyModel.ColumnName_ExamineeCompanyID;

                //注册TextChanged事件  
                this.cbExamineeCompany.TextChanged += new EventHandler(Combo_TextChanged);
            }

        }

        private void Combo_TextChanged(object sender, EventArgs e)
        {
            //if (_TextChanged != null)
            //{
            //    //_TextChanged(sender, e);

            //    Check.CheckSpecialCharacters(this.cbExamineeCompany, "所属单位");
            //}

            Check.CheckSpecialCharacters(this.cbExamineeCompany, "所属单位");

            Check.CheckSpecialCharacters(this.cbExaminationName, "考试名称");
        }

        /// <summary>
        /// 绑定第Index页的数据
        /// </summary>
        /// <param name="Index"></param>
        private void BindDataWithPage(int index, int pageSize)
        {
            this.pageControl1.PageIndex = index;
            this.pageControl1.PageSize = pageSize;

            PageModel pm = new PageModel();
            pm.Columns = "*";
            pm.TableName = "t_examination_result_info a inner join t_examinee_info b on a.ExamineeID = b.ExamineeID inner join t_examination_info c on a.ExaminationID = c.ExaminationID inner join t_examinee_company_info d on b.ExamineeCompanyID = d.ExamineeCompanyID";

            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = "1=1";
            }

            pm.Where = strWhere;
            pm.OrderBy = "a.ExaminationDate desc";
            pm.PageIndex = index.ToString();
            pm.PageSize = pageSize.ToString();

            DataSet ds = GetData(pm);

            if (ds != null)
            {
                int count = ds.Tables[0].Rows.Count;

                this.dgvExaminationResultInfo.Rows.Clear();
                this.dgvExaminationResultInfo.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    // 考生编号
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExamineeID].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExamineeID].ToString();
                    // 考生姓名
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExamineeName].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExamineeName].ToString();
                    // 所属公司
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExamineeCompanyName].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExamineeCompanyName].ToString();
                    // 考试名称
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExaminationName].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationName].ToString();


                    // 考试科目
                    string strExaminationSubjectIDs = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationSubjectIDs].ToString();

                    string[] examinationSubjectIDs = strExaminationSubjectIDs.Split(',');

                    string strExaminationSubjectNames = "";

                    for (int n = 0; n < examinationSubjectIDs.Length; n++)
                    {
                        string strExaminationSubjectName = _ExaminationSubjectBLL.GetExaminationSubjectNameWithShortNameByExamineeSubjectID(examinationSubjectIDs[n]);
                        strExaminationSubjectNames = strExaminationSubjectNames + strExaminationSubjectName + "\n";
                    }

                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExaminationSubjects].Value = strExaminationSubjectNames;


                    // 得分2
                    string FinalScore2 = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_FinalScore2].ToString();

                    if (!string.IsNullOrEmpty(FinalScore2))
                    {
                        FinalScore2 = FinalScore2 + "分";
                    }

                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_FinalScore2].Value = FinalScore2;

                    // 考试结果
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExaminationResult].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationResult].ToString();

                    // 考试日期
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExaminationDate].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationDate].ToString();

                    this.dgvExaminationResultInfo.Rows[i].Cells["btnDetail"].Value = "详情";

                    // 考生结果编号(不可见)
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExaminationResultID].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationResultID].ToString();
                    // 考试科目IDs(不可见)
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExaminationSubjectIDs].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationSubjectIDs].ToString();
                    // 得分(不可见)
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_FinalScore].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_FinalScore].ToString();

                    if (i % 2 != 0)
                    {
                        this.dgvExaminationResultInfo.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        this.dgvExaminationResultInfo.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                    }
                }

                int.TryParse(ds.Tables[2].Rows[0][PageModel.ColumnName_TotalCount].ToString(), out _RecordCount);

                // 获取并设置总记录数
                this.pageControl1.RecordCount = _RecordCount;

                this.pageControl1.ResetPageControl();
            }
            // add by wuxin at 2018/09/10 - start
            else
            {
                this.pageControl1.RecordCount = 0;

                this.pageControl1.ResetPageControl();
            }
            // add by wuxin at 2018/09/10 - end
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        private DataSet GetData(PageModel pm)
        {
            DataSet ds = _PageBLL.GetAllDataInfo(pm);

            if (ds.Tables[0].Rows.Count <= 0)
            {
                Alert.noteMsg("无数据！");

                return null;
            }

            return ds;
        }

        private void dgvExaminationResultInfo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string strExaminationResult = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationResult].Value.ToString();

                // 通过
                if (strExaminationResult == Const.ExaminationResult_Yes)
                {
                    this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationResult].Style.ForeColor = Color.Green;
                }
                else
                {
                    this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationResult].Style.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvExaminationResultInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = this.dgvExaminationResultInfo.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    // 考试结果编号
                    string examinationResultID = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationResultID].Value.ToString();
                    // 考生编号
                    string examineeID = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExamineeID].Value.ToString();
                    // 考生姓名
                    string examineeName = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExamineeName].Value.ToString();
                    // 所属公司
                    string examineeCompanyName = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExamineeCompanyName].Value.ToString();
                    // 考试名称
                    string examinationName = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationName].Value.ToString();
                    // 考试日期
                    string examinationDate = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationDate].Value.ToString();
                    // 得分
                    string finalScore = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_FinalScore].Value.ToString();
                    // 得分2
                    string finalScore2 = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_FinalScore2].Value.ToString();
                    // 考试科目IDs
                    string examinationSubjectIDs = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationSubjectIDs].Value.ToString();
                    // 考试科目s
                    string examinationSubjects = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationSubjects].Value.ToString();
                    // 考试结果
                    string examinationResult = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationResult].Value.ToString();

                    ExaminationResultModel erm = new ExaminationResultModel();
                    erm.ExaminationResultID = examinationResultID;
                    erm.ExamineeID = examineeID;
                    erm.ExamineeName = examineeName;
                    erm.ExamineeCompanyName = examineeCompanyName;
                    erm.ExaminationName = examinationName;
                    erm.ExaminationDate = examinationDate;
                    erm.FinalScore = finalScore;
                    erm.FinalScore2 = finalScore2;
                    erm.ExaminationSubjectIDs = examinationSubjectIDs;
                    erm.ExaminationSubjects = examinationSubjects;
                    erm.ExaminationResult = examinationResult;


                    考试成绩详情 form = new 考试成绩详情(erm);
                    form.ShowDialog(this);
                }
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void cbExamineeCompany_TextChanged(object sender, System.EventArgs e)
        {

        }

        /// <summary>
        /// 查询前检查
        /// </summary>
        private bool CheckBeforeSelect()
        {
            bool checkResult = true;

            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtExamineeName, "考生姓名");

            if (!checkResult) return checkResult;

            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.cbExamineeCompany, "所属单位");

            if (!checkResult) return checkResult;

            //// 验证控件是否包含特殊字符
            //checkResult = Check.CheckSpecialCharacters(this.txtExaminationName, "");

            //if (!checkResult) return checkResult;

            return checkResult;

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            bool checkResult = CheckBeforeSelect();

            if (checkResult)
            {
                strWhere = "1=1";

                // 全部查询
                if (string.IsNullOrEmpty(this.txtExamineeID.Text.Trim()) && string.IsNullOrEmpty(this.txtExamineeName.Text.Trim()) && string.IsNullOrEmpty(this.cbExamineeCompany.Text) && string.IsNullOrEmpty(this.cbExaminationName.Text))
                {
                    strWhere = "1=1";
                }

                // 根据考生编号模糊查询
                if (!string.IsNullOrEmpty(this.txtExamineeID.Text.Trim()))
                {
                    strWhere = strWhere + " AND " + "b." + ExamineeModel.ColumnName_ExamineeID + " like '%" + this.txtExamineeID.Text.Trim() + "%'";
                }

                // 根据考生姓名模糊查询
                if (!string.IsNullOrEmpty(this.txtExamineeName.Text.Trim()))
                {
                    strWhere = strWhere + " AND " + "b." + ExamineeModel.ColumnName_ExamineeName + " like '%" + this.txtExamineeName.Text.Trim() + "%'";
                }

                // 根据考生所属公司模糊查询
                if (!string.IsNullOrEmpty(this.cbExamineeCompany.Text.Trim()))
                {
                    strWhere = strWhere + " AND " + "d." + ExamineeModel.ColumnName_ExamineeCompanyName + " like '%" + this.cbExamineeCompany.Text + "%'";
                }

                // 根据考试名称模糊查询
                if (!string.IsNullOrEmpty(this.cbExaminationName.Text.Trim()))
                {
                    strWhere = strWhere + " AND " + "c." + ExaminationModel.ColumnName_ExaminationName + " like '%" + this.cbExaminationName.Text + "%'";
                }

                BindDataWithPage(1, pageControl1.PageSize);
            }
        }

        private void txtExamineeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 加载考试信息
        /// </summary>
        private void LoadExaminationInfo()
        {
            DataSet ds = _ExaminationBLL.GetAllExaminationInfo();

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                //this.cbExaminationInfo.DataSource = ds.Tables[0];
                //this.cbExaminationInfo.DisplayMember = ExaminationModel.ColumnName_ExaminationName;
                //this.cbExaminationInfo.ValueMember = ExaminationModel.ColumnName_ExaminationID;

                ArrayList list = new ArrayList();

                ExaminationModel defaultEm = new ExaminationModel();
                defaultEm.ExaminationID = "";
                defaultEm.ExaminationName = "";

                list.Add(defaultEm);

                for (int i = 0; i < count; i++)
                {
                    string examinationID = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationID].ToString();
                    string examinationName = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationName].ToString();

                    ExaminationModel em = new ExaminationModel();
                    em.ExaminationID = examinationID;
                    em.ExaminationName = examinationName;

                    list.Add(em);
                }

                this.cbExaminationName.DataSource = list;
                this.cbExaminationName.DisplayMember = ExaminationModel.ColumnName_ExaminationName;
                this.cbExaminationName.ValueMember = ExaminationModel.ColumnName_ExaminationID;

                //注册TextChanged事件  
                this.cbExaminationName.TextChanged += new EventHandler(Combo_TextChanged);
            }
        }

        private void txtExamineeName_TextChanged(object sender, EventArgs e)
        {
            Check.CheckSpecialCharacters(this.txtExamineeName, "考生姓名");
        }

        private void cbAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            int count = this.dgvExaminationResultInfo.Rows.Count;

            if (count > 0)
            {
                if (this.cbAllSelect.Checked)
                {
                    //MessageBox.Show("全选");
                    SetGVAllCheckBoxState(true);
                }
                else
                {
                    //MessageBox.Show("全不选");
                    SetGVAllCheckBoxState(false);
                }
            }
        }


        /// <summary>
        /// 设置当前GV所有CheckBox状态
        /// </summary>
        /// <param name="flag"></param>
        private void SetGVAllCheckBoxState(bool flag)
        {
            int count = this.dgvExaminationResultInfo.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                this.dgvExaminationResultInfo.Rows[i].Cells[0].Value = flag;
            }

            //MessageBox.Show(_SelectedPKList.Count.ToString());
        }

        /// <summary>
        /// 分页控件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageControl1_PageIndexChanged(object sender, EventArgs e)
        {
            BindDataWithPage(pageControl1.PageIndex, pageControl1.PageSize);
        }

        // add by wuxin at 2018/6/5 - start
        private void dgvExaminationResultInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 考试结果编号
                string examinationResultID = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationResultID].Value.ToString();
                // 考生编号
                string examineeID = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExamineeID].Value.ToString();
                // 考生姓名
                string examineeName = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExamineeName].Value.ToString();
                // 所属公司
                string examineeCompanyName = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExamineeCompanyName].Value.ToString();
                // 考试名称
                string examinationName = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationName].Value.ToString();
                // 考试日期
                string examinationDate = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationDate].Value.ToString();
                // 得分
                string finalScore = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_FinalScore].Value.ToString();
                // 得分2
                string finalScore2 = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_FinalScore2].Value.ToString();
                // 考试科目IDs
                string examinationSubjectIDs = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationSubjectIDs].Value.ToString();
                // 考试科目s
                string examinationSubjects = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationSubjects].Value.ToString();
                // 考试结果
                string examinationResult = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationResult].Value.ToString();

                ExaminationResultModel erm = new ExaminationResultModel();
                erm.ExaminationResultID = examinationResultID;
                erm.ExamineeID = examineeID;
                erm.ExamineeName = examineeName;
                erm.ExamineeCompanyName = examineeCompanyName;
                erm.ExaminationName = examinationName;
                erm.ExaminationDate = examinationDate;
                erm.FinalScore = finalScore;
                erm.FinalScore2 = finalScore2;
                erm.ExaminationSubjectIDs = examinationSubjectIDs;
                erm.ExaminationSubjects = examinationSubjects;
                erm.ExaminationResult = examinationResult;

                考试成绩详情 form = new 考试成绩详情(erm);
                form.ShowDialog(this);
            }
        }
        // add by wuxin at 2018/6/5 - end
    }
}
