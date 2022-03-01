using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MCS
{
    public partial class 考试成绩查询 : Form
    {
        PageBLL _PageBLL = new PageBLL();
        ExaminationSubjectBLL _ExaminationSubjectBLL = new ExaminationSubjectBLL();
        ExamineeCompanyBLL _ExamineeCompanyBLL = new ExamineeCompanyBLL();
        ExaminationBLL _ExaminationBLL = new ExaminationBLL();
        ExaminationResultBLL _ExaminationResultBLL = new ExaminationResultBLL();

        // 总记录数
        public int _RecordCount = 0;

        // 分页查询Where条件
        string strWhere = "";

        /// <summary>
        /// 是否包含自定义查询条件
        /// </summary>
        private bool _IsHasCustomSelectCondition = false;

        public 考试成绩查询()
        {
            InitializeComponent();

            // 加载公司信息
            LoadExamineeCompanyInfo();
            // 加载考试信息
            LoadExaminationInfo();

            // 加载考试结果信息数据
            BindDataWithPage(1, 10);

            // add by wuxin at 2019/12/02 - start
            // 起止日期暂时设置为本月第一天和最后一天
            this.dateTimePickerFrom.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            this.dateTimePickerTo.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);
            // add by wuxin at 2019/12/02 - end
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
            // add by wuxin at 2020/01/06 - start
            // 重置界面控件状态
            ResetFormControlState();
            // add by wuxin at 2020/01/06 - start

            this.pageControl1.PageIndex = index;
            this.pageControl1.PageSize = pageSize;

            PageModel pm = new PageModel();
            pm.Columns = "*";
            // upd by wuxin at 2020/1/8 - start
            // inner join 改为 left join
            pm.TableName = "t_examination_result_info a left join t_examinee_info b on a.ExamineeID = b.ExamineeID left join t_examination_info c on a.ExaminationID = c.ExaminationID left join t_examinee_company_info d on b.ExamineeCompanyID = d.ExamineeCompanyID";
            // upd by wuxin at 2020/1/8 - end

            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = "1=1";
            }

            pm.Where = strWhere;
            pm.OrderBy = "a.ExaminationDate desc"; // a.ExaminationResultID 
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

                    // add by wuxin at 2020/1/18 - start
                    // 身份证号
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_IDCardNum].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_IDCardNum].ToString();
                    // add by wuxin at 2020/1/18 - end

                    // 所属公司
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExamineeCompanyName].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExamineeCompanyName].ToString();
                    // add by wuxin at 2020/1/8 - start
                    // 班别
                    this.dgvExaminationResultInfo.Rows[i].Cells[ExamineeModel.ColumnName_ClassType].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ClassType].ToString();
                    // add by wuxin at 2020/1/8 - end
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
                // add by wuxin at 2019/12/02 - start
                this.dgvExaminationResultInfo.Rows.Clear();

                _RecordCount = 0;

                // add by wuxin at 2019/12/02 - end

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

                    // add by wuxin at 2020/1/18 - start
                    // 身份证号
                    string IDCardNum = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_IDCardNum].Value.ToString();
                    // add by wuxin at 2020/1/18 - end

                    // 所属公司
                    string examineeCompanyName = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExamineeCompanyName].Value.ToString();
                    // add by wuxin at 2020/1/8 - start
                    // 班别
                    string classType = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ClassType].Value.ToString();
                    // add by wuxin at 2020/1/8 - end
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
                    // add by wuxin at 2020/1/18 - start
                    erm.IDCardNum = IDCardNum;
                    // add by wuxin at 2020/1/18 - END
                    erm.ExamineeCompanyName = examineeCompanyName;
                    erm.ExaminationName = examinationName;
                    erm.ExaminationDate = examinationDate;
                    erm.FinalScore = finalScore;
                    erm.FinalScore2 = finalScore2;
                    erm.ExaminationSubjectIDs = examinationSubjectIDs;
                    erm.ExaminationSubjects = examinationSubjects;
                    erm.ExaminationResult = examinationResult;
                    // add by wuxin at 2020/1/8 - start
                    erm.ClassType = classType;
                    // add by wuxin at 2020/1/8 - end

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

                // 包含自定义查询条件
                if (_IsHasCustomSelectCondition)
                {
                    strWhere = strWhere + " AND " + "a.ExaminationDate >= '" + this.dateTimePickerFrom.Value + "' AND " + "a.ExaminationDate <= '" + this.dateTimePickerTo.Value + "'";
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
                // add by wuxin at 2020/1/18 - start
                // 身份证号
                string IDCardNum = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_IDCardNum].Value.ToString();
                // add by wuxin at 2020/1/18 - end
                // 所属公司
                string examineeCompanyName = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExamineeCompanyName].Value.ToString();
                // add by wuxin at 2020/1/8 - start
                // 班别
                string classType = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ClassType].Value.ToString();
                // add by wuxin at 2020/1/8 - end
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
                // add by wuxin at 2020/1/18 - start
                erm.IDCardNum = IDCardNum;
                // add by wuxin at 2020/1/18 - END
                erm.ExamineeCompanyName = examineeCompanyName;
                erm.ExaminationName = examinationName;
                erm.ExaminationDate = examinationDate;
                erm.FinalScore = finalScore;
                erm.FinalScore2 = finalScore2;
                erm.ExaminationSubjectIDs = examinationSubjectIDs;
                erm.ExaminationSubjects = examinationSubjects;
                erm.ExaminationResult = examinationResult;
                // add by wuxin at 2020/1/8 - start
                erm.ClassType = classType;
                // add by wuxin at 2020/1/8 - end

                考试成绩详情 form = new 考试成绩详情(erm);
                form.ShowDialog(this);
            }
        }

        private void btnAllDel_Click(object sender, EventArgs e)
        {
            if (Alert.confirm("是否确认删除？"))
            {
                int count = _SelectedPKList.Count;

                //MessageBox.Show(count.ToString());

                if (count > 0)
                {
                    int result = 0;

                    for (int i = 0; i < count; i++)
                    {
                        int errorCount = _ExaminationResultBLL.DelExaminationResultInfo(_SelectedPKList[i]);
                        if (errorCount == 0)
                        {
                            result++;
                        }
                    }

                    if (result == count)
                    {
                        Alert.noteMsg("删除成功！");

                        // 重置界面控件状态
                        ResetFormControlState();

                        // 重新查询
                        btnSelect_Click(null, null);
                    }
                    else
                    {
                        Alert.errorMsg("删除失败！");
                    }

                }
            }
        }

        // add by wuxin at 2018/6/5 - end

        // add by wuxin at 2019/12/02 - start
        /// <summary>
        /// 是否包含自定义条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbIsHasCustomSelectCondition_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbIsHasCustomSelectCondition.Checked)
            {
                _IsHasCustomSelectCondition = true;

                this.dateTimePickerFrom.Enabled = true;
                this.dateTimePickerTo.Enabled = true;
            }
            else
            {
                _IsHasCustomSelectCondition = false;

                this.dateTimePickerFrom.Enabled = false;
                this.dateTimePickerTo.Enabled = false;
            }

            //MessageBox.Show(_IsHasCustomSelectCondition.ToString());
        }

        /// <summary>
        /// 批量导出前检查
        /// </summary>
        private bool CheckBeforeBatchExport()
        {
            bool checkResult = true;

            if (this.dgvExaminationResultInfo.Rows.Count > 0)
            {
                checkResult = true;
            }
            else
            {
                checkResult = false;
            }

            return checkResult;

        }

        /// <summary>
        /// 批量导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatchExport_Click(object sender, EventArgs e)
        {
            bool checkResult = CheckBeforeBatchExport();

            if (checkResult)
            {
                this.folderBrowserDialog1.Description = "请选择保存路径";

                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    PageModel pm = new PageModel();
                    pm.Columns = "*";
                    pm.TableName = "t_examination_result_info a left join t_examinee_info b on a.ExamineeID = b.ExamineeID left join t_examination_info c on a.ExaminationID = c.ExaminationID left join t_examinee_company_info d on b.ExamineeCompanyID = d.ExamineeCompanyID";

                    if (string.IsNullOrEmpty(strWhere))
                    {
                        strWhere = "1=1";
                    }

                    pm.Where = strWhere;
                    pm.OrderBy = "a.ExaminationDate desc";

                    DataSet ds = _ExaminationResultBLL.GetAllExaminationResultInfoByCustomCondition(pm);

                    int count = ds.Tables[0].Rows.Count;

                    if (count > 0)
                    {
                        // 清空进度条
                        this.ExcelExportProgressBar.Value = 0;
                        this.ExcelExportProgressBar.Visible = true;

                        this.ExcelExportProgressBar.Minimum = 0;
                        this.ExcelExportProgressBar.Maximum = count;

                        // upd by wuxin at 2020/1/15 - start

                        string strExcelSaveFolderPath = this.folderBrowserDialog1.SelectedPath;

                        string strExcelTemplatePath = Const.ExcelTemplatePath; // ……/ExelTemplate.xlsx0

                        string strNowDateFolder = strExcelSaveFolderPath + "/" + "考试成绩批量导出" + DateTime.Now.Date.ToString(Const.DATE_FORMART_YYYYMMDD);

                        string strNewFilePath = "";

                        // 1.在Excels文件夹下创建当天日期的文件夹（如果存在，不创建）
                        if (!Directory.Exists(strNowDateFolder))
                        {
                            Directory.CreateDirectory(strNowDateFolder);
                        }

                        // 2.复制Excel模板到当天日期的文件夹下，并修改文件名，文件名格式 考生编号_考生姓名_日期（20180520）.xlsx（如果存在先删除再复制）
                        try
                        {
                            strNewFilePath = strNowDateFolder + "/" + "考试成绩批量导出" + "_" + DateTime.Now.ToString(Const.DATE_FORMART_yyyy_MM_dd_HH_mm_ss) + ".xlsx";//.xls

                            if (File.Exists(strNewFilePath))
                            {
                                File.Delete(strNewFilePath);
                            }

                            File.Copy(strExcelTemplatePath, strNewFilePath, true);
                        }

                        catch (Exception ex)
                        {
                            LogHelper.WriteErrorLog("复制ExcelTemplate.xlsx出错！");
                            LogHelper.WriteErrorLog("错误信息：" + ex.ToString());

                            Alert.errorMsg("复制ExcelTemplate.xlsx出错！错误信息:" + ex.ToString());
                        }

                        // 4.写入数据
                        if (File.Exists(strNewFilePath))
                        {
                            bool returnb = false;
                            XSSFWorkbook wk = null;

                            //将数据保存到文件
                            try
                            {
                                using (FileStream fs = File.Open(strNewFilePath, FileMode.Open, FileAccess.Read))
                                {
                                    // 把xls文件读入workbook变量里，之后就可以关闭了
                                    wk = new XSSFWorkbook(fs);
                                }

                                // 获取第一个工作薄
                                ISheet sheet = wk.GetSheetAt(0);

                                //// 序号
                                //sheet.CreateRow(count + 4);



                                for (int i = 0; i < count; i++)
                                {
                                    // 序号
                                    sheet.CreateRow(i + 4).CreateCell(0).SetCellValue(i + 1);

                                    // 姓名
                                    sheet.GetRow(i + 4).CreateCell(1).SetCellValue(ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeName].ToString());

                                    // 身份证号
                                    sheet.GetRow(i + 4).CreateCell(2).SetCellValue(ds.Tables[0].Rows[i][ExamineeModel.ColumnName_IDCardNum].ToString());

                                    // 单位
                                    sheet.GetRow(i + 4).CreateCell(3).SetCellValue(ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeCompanyName].ToString());

                                    // 班别
                                    sheet.GetRow(i + 4).CreateCell(4).SetCellValue(ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ClassType].ToString());

                                    // 考试名称
                                    sheet.GetRow(i + 4).CreateCell(5).SetCellValue(ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationName].ToString());

                                    // 考试日期
                                    sheet.GetRow(i + 4).CreateCell(6).SetCellValue(ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationDate].ToString());

                                    // 成绩
                                    sheet.GetRow(i + 4).CreateCell(7).SetCellValue(ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_FinalScore2].ToString());

                                    // 考试结果
                                    string strExaminationResult = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationResult].ToString();
                                    sheet.GetRow(i + 4).CreateCell(8).SetCellValue(strExaminationResult);

                                    this.ExcelExportProgressBar.Value += 1;

                                    Thread.Sleep(50);
                                }

                                // 加外边框
                                AddRengionBorder(wk, sheet, 4, 4 + count, 0, 9);

                                using (FileStream fileStream = File.Open(strNewFilePath, FileMode.Create, FileAccess.Write))
                                {
                                    wk.Write(fileStream);

                                    fileStream.Close();
                                }

                                if (this.ExcelExportProgressBar.Maximum == count)
                                {
                                    Alert.noteMsg("导出成功！");
                                    this.ExcelExportProgressBar.Visible = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                returnb = false;
                                //throw;

                                Alert.errorMsg("导出成绩单出错！错误信息:" + ex.ToString());

                                LogHelper.WriteErrorLog("导出成绩单出错！");
                                LogHelper.WriteErrorLog("错误信息：" + ex.ToString());
                            }

                        }


                        // upd by wuxin at 2020/1/15 - end

                        //for (int i = 0; i < count; i++)
                        //{
                        //    // 4.写入数据

                        //    if (File.Exists(strNewFilePath))
                        //    {
                        //        bool returnb = false;

                        //        XSSFWorkbook wk = null;

                        //        //将数据保存到文件
                        //        try
                        //        {
                        //            using (FileStream fs = File.Open(strNewFilePath, FileMode.Open, FileAccess.Read))
                        //            {
                        //                //把xls文件读入workbook变量里，之后就可以关闭了  
                        //                wk = new XSSFWorkbook(fs);
                        //                fs.Close();
                        //            }

                        //            ISheet sheet = wk.GetSheet("成绩单");

                        //            // 成绩单
                        //            sheet.GetRow(1).GetCell(1).SetCellValue("成绩单");

                        //            // 考生编号
                        //            sheet.GetRow(2).GetCell(2).SetCellValue(ds.Tables[0].Rows[i]["ExamineeID"].ToString().Trim());

                        //            // 考生姓名
                        //            sheet.GetRow(2).GetCell(4).SetCellValue(ds.Tables[0].Rows[i]["ExamineeName"].ToString().Trim());

                        //            // 所属公司
                        //            sheet.GetRow(2).GetCell(6).SetCellValue(ds.Tables[0].Rows[i]["ExamineeCompanyName"].ToString().Trim());

                        //            // 考试名称
                        //            sheet.GetRow(3).GetCell(2).SetCellValue(ds.Tables[0].Rows[i]["ExaminationName"].ToString().Trim());

                        //            // 考试日期
                        //            sheet.GetRow(4).GetCell(2).SetCellValue(ds.Tables[0].Rows[i]["ExaminationDate"].ToString().Trim());

                        //            // 得分,需要拆分，相加得出最后结果，23分 = 14分(K1) + 9分(K2)，
                        //            // 检查K1,K2的怎么来的，要是写死的那就有问题，因为别的考试会有K3...

                        //            // upd by wuxin at 2019/12/03 - start
                        //            // 得分
                        //            // 100 = 50(K1) + 50(K2)
                        //            string strFinalScore2 = ds.Tables[0].Rows[i]["FinalScore2"].ToString();

                        //            // 根据考试科目编号获取考试科目名称
                        //            string strExaminationSubjectIDs = ds.Tables[0].Rows[i]["ExaminationSubjectIDs"].ToString();// 1,2

                        //            string[] examinationSubjectIDs = strExaminationSubjectIDs.Split(',');

                        //            string[] examinationSubjectNames = new string[2];

                        //            ArrayList _ExaminationSubjectList = new ArrayList();

                        //            for (int n = 0; n < examinationSubjectIDs.Length; n++)
                        //            {
                        //                examinationSubjectNames[n] = _ExaminationSubjectBLL.GetExaminationSubjectShortNameByExamineeSubjectID(examinationSubjectIDs[n]);

                        //                ExaminationSubjectModel examinationSubjectModel = new ExaminationSubjectModel();
                        //                examinationSubjectModel.ExaminationSubjectID = examinationSubjectIDs[n];
                        //                examinationSubjectModel.ExaminationSubjectShortName = examinationSubjectNames[n];

                        //                _ExaminationSubjectList.Add(examinationSubjectModel);
                        //            }

                        //            // 拆开显示分数
                        //            string strFinalScore = ds.Tables[0].Rows[i]["FinalScore"].ToString();// 10+30

                        //            string[] finalScores = strFinalScore.Split('+');


                        //            if (finalScores.Length == examinationSubjectNames.Length)
                        //            {
                        //                string txtFinalScoreText = strFinalScore2 + " = " + finalScores[0] + "分" + "(" + examinationSubjectNames[0] + ")" + " + " + finalScores[1] + "分" + "(" + examinationSubjectNames[1] + ")";
                        //                sheet.GetRow(5).GetCell(2).SetCellValue(txtFinalScoreText);
                        //            }
                        //            // upd by wuxin at 2019/12/03 - end

                        //            // 考试结果
                        //            sheet.GetRow(6).GetCell(2).SetCellValue(ds.Tables[0].Rows[i]["ExaminationResult"].ToString().Trim());

                        //            //if (this.txtExaminationResult.Text.Trim() == "通过")
                        //            //{
                        //            //    XSSFFont ffont = (XSSFFont)wk.CreateFont();
                        //            //    ffont.Color = HSSFColor.Green.Index;
                        //            //    sheet.GetRow(6).GetCell(2).CellStyle.SetFont(ffont);
                        //            //}
                        //            //else
                        //            //{
                        //            //    XSSFFont ffont = (XSSFFont)wk.CreateFont();
                        //            //    ffont.Color = HSSFColor.Red.Index;
                        //            //    sheet.GetRow(6).GetCell(2).CellStyle.SetFont(ffont);
                        //            //}


                        //            using (FileStream fileStream = File.Open(strNewFilePath, FileMode.Create, FileAccess.Write))
                        //            {
                        //                wk.Write(fileStream);
                        //                fileStream.Close();
                        //            }
                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            returnb = false;
                        //            //throw;

                        //            Alert.errorMsg("导出成绩单出错！");

                        //            LogHelper.WriteErrorLog("导出成绩单出错！");
                        //            LogHelper.WriteErrorLog("错误信息：" + ex.ToString());
                        //        }

                        //    }

                        //    this.ExcelExportProgressBar.Value += 1;

                        //    Thread.Sleep(50);
                        //}

                        //if (this.ExcelExportProgressBar.Maximum == count)
                        //{
                        //    Alert.noteMsg("导出成功！");
                        //    this.ExcelExportProgressBar.Visible = false;
                        //}

                    }
                }

            }
            else
            {
                Alert.noteMsg("无数据！");
            }


        }

        // add by wuxin at 2020/1/17 - start

        /// <summary>
        /// 加范围边框并设置CellStyle
        /// </summary>
        /// <param name="firstRow">起始行</param>
        /// <param name="lastRow">结束行</param>
        /// <param name="firstCell">起始列</param>
        /// <param name="lastCell">结束列</param>
        /// <returns></returns>
        public void AddRengionBorder(XSSFWorkbook wk, ISheet sheet, int firstRow, int lastRow, int firstCell, int lastCell)
        {
            for (int i = firstRow; i < lastRow; i++)
            {
                for (int n = firstCell; n < lastCell; n++)
                {
                    ICell cell;
                    cell = sheet.GetRow(i).GetCell(n);
                    if (cell == null)
                    {
                        cell = sheet.GetRow(i).CreateCell(n);
                        cell.SetCellValue(" ");
                    }

                    ICellStyle Style = wk.CreateCellStyle() as ICellStyle;

                    if (i >= firstRow && i <= lastRow) // && i >= firstCell && i <= lastCell
                    {
                        Style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                        Style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                        Style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                        Style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    }

                    // 居中
                    Style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

                    // 设置单元格格式
                    Style.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");

                    if (n == 8)
                    {
                        string strExaminationResult = sheet.GetRow(i).GetCell(8).StringCellValue;

                        if (strExaminationResult == "通过")
                        {
                            XSSFFont ffont = (XSSFFont)wk.CreateFont();
                            ffont.Color = HSSFColor.Green.Index;
                            Style.SetFont(ffont);
                        }
                        else
                        {
                            XSSFFont ffont = (XSSFFont)wk.CreateFont();
                            ffont.Color = HSSFColor.Red.Index;
                            Style.SetFont(ffont);
                        }
                    }

                    cell.CellStyle = Style;

                }
            }
        }


        // add by wuxin at 2020/1/17 - end

        // add by wuxin at 2020/01/06 - start
        private void dgvExaminationResultInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvExaminationResultInfo.IsCurrentCellDirty)
            {
                this.dgvExaminationResultInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //为什么要使用this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit); 
                //因为当我们对 checkbox 的 cell 进行编辑后，你会看到在 RowHeader 上显示一个笔的形状的东西，这说明此列正在编辑，如果直接用 Value 获取值，则会获得在编辑之前的值，
                //使用了 CommitEdit 方法后，我们再调用 Value 属性就会获得你看到的值，当然这句话也可以放在 dataGridView 的事件里面进行处理，就不需要再每次遍历之前执行这句了。
            }
        }

        // 选中数据的主键集合
        private List<string> _SelectedPKList = new List<string>();

        private void dgvExaminationResultInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = this.dgvExaminationResultInfo.Columns[e.ColumnIndex];

                if (column.Name.Equals("CheckBox"))
                {
                    // 考试结果ID
                    string pk = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_ExaminationResultID].Value.ToString();

                    // 获得checkbox 列单元格
                    DataGridViewCheckBoxCell dgvCheckBoxCell = this.dgvExaminationResultInfo.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                    bool flag = Convert.ToBoolean(dgvCheckBoxCell.Value);

                    if (flag)
                    {
                        _SelectedPKList.Add(pk);
                        //MessageBox.Show(_SelectedPKList.Count.ToString());
                        // 设置全部删除按钮状态
                        SetAllDelButtonState();
                    }
                    else
                    {
                        _SelectedPKList.Remove(pk);
                        //MessageBox.Show(_SelectedPKList.Count.ToString());
                        // 设置全部删除按钮状态
                        SetAllDelButtonState();
                    }
                }
            }
        }

        /// <summary>
        /// 设置全部删除按钮状态
        /// </summary>
        private void SetAllDelButtonState()
        {
            if (_SelectedPKList.Count > 0)
            {
                this.btnAllDel.Enabled = true;
            }
            else
            {
                this.btnAllDel.Enabled = false;
            }
        }

        /// <summary>
        /// 重置界面控件状态
        /// </summary>
        private void ResetFormControlState()
        {
            this._SelectedPKList.Clear();
            this.cbAllSelect.Checked = false;
            this.btnAllDel.Enabled = false;
        }

        // add by wuxin at 2020/01/06 - end

        // 测试用Sql语句
        //SELECT* FROM t_examination_result_info a inner join t_examinee_info b on a.ExamineeID = b.ExamineeID inner join t_examination_info c on a.ExaminationID = c.ExaminationID inner join t_examinee_company_info d on b.ExamineeCompanyID = d.ExamineeCompanyID
        // add by wuxin at 2019/12/02 - end
    }
}
