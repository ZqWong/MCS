using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MCS
{
    public partial class 考试相关信息录入界面 : Form
    {
        ExaminationBLL _ExaminationBLL = new ExaminationBLL();
        ExaminationSubjectBLL _ExaminationSubjectBLL = new ExaminationSubjectBLL();
        ExaminationItemBLL _ExaminationItemBLL = new ExaminationItemBLL();

        /// <summary>
        /// 当前逻辑
        /// </summary>
        private string _CurrentExaminationLogic = "ExaminationAdd";
        private string _CurrentExaminationSubjectLogic = "ExaminationSubjectAdd";
        private string _CurrentExaminationItemLogic = "ExaminationItemAdd";

        ///// <summary>
        ///// 考试信息是否提交完成
        ///// </summary>
        //private bool _IsExaminationInfoAdded = false;

        /// <summary>
        /// 选中数据的主键集合
        /// </summary>
        private List<string> _SelectedPKList = new List<string>();

        public 考试相关信息录入界面()
        {
            InitializeComponent();

            this.txtExaminationID.Text = GetLatestExaminationID().ToString();

            // 步骤一：加载考试列表信息
            LoadExaminationInfoForDGV();

            // 加载考试信息
            LoadExaminationInfo();

            // 加载考试科目信息
            LoadExaminationSubjectInfoByExaminationID();

            // 步骤三：加载考试信息、考试科目信息下拉列表
            LoadExaminationInfo2();
        }

        /// <summary>
        /// 步骤一：加载考试信息
        /// </summary>
        public void LoadExaminationInfoForDGV()
        {
            this._SelectedExaminationPKList.Clear();
            this.cbSelectAllExaminationInfo.Checked = false;
            this.btnDelExaminationInfo.Enabled = false;
            this.dgvExaminationInfo.Rows.Clear();

            DataSet ds = _ExaminationBLL.GetAllExaminationInfo();

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                this.dgvExaminationInfo.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    // 考试编号
                    this.dgvExaminationInfo.Rows[i].Cells[ExaminationModel.ColumnName_ExaminationID].Value = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationID].ToString();
                    // 考试名称
                    this.dgvExaminationInfo.Rows[i].Cells[ExaminationModel.ColumnName_ExaminationName].Value = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationName].ToString();
                    // 组卷方式
                    this.dgvExaminationInfo.Rows[i].Cells[ExaminationModel.ColumnName_PaperCompilingMode + "2"].Value = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_PaperCompilingMode].ToString();
                    // 总分
                    this.dgvExaminationInfo.Rows[i].Cells[ExaminationModel.ColumnName_TotalScore].Value = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_TotalScore].ToString();
                    // 合格分数
                    this.dgvExaminationInfo.Rows[i].Cells[ExaminationModel.ColumnName_ExaminationPassScore].Value = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationPassScore].ToString();
                    // 考试时间
                    this.dgvExaminationInfo.Rows[i].Cells[ExaminationModel.ColumnName_ExaminationTime].Value = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationTime].ToString();


                    //// 考试科目名称
                    //this.dgvExaminationInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectName].Value = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectName].ToString();
                    //// 简称
                    //this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName].Value = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName].ToString();

                    //// 考试时间
                    //this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectTime].Value = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectTime].ToString();
                    //// 参与组卷方式
                    //string paperCompilingMode = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_PaperCompilingMode].ToString();

                    //if (paperCompilingMode == Const.PAPER_COMPILING_MODE_COMPULSORY)
                    //{
                    //    this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_PaperCompilingMode].Value = "必考";
                    //}
                    //else if (paperCompilingMode == Const.PAPER_COMPILING_MODE_RANDOM)
                    //{
                    //    this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_PaperCompilingMode].Value = "随机";
                    //}
                    //// 是否包含子科目
                    //string isHasChildSubject = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_IsHasChildSubject].ToString();

                    //if (isHasChildSubject == "0")
                    //{
                    //    this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_IsHasChildSubject].Value = "否";
                    //}
                    //else if (isHasChildSubject == "1")
                    //{
                    //    this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_IsHasChildSubject].Value = "是";
                    //}

                    //this.dgvExaminationSujectInfo.Rows[i].Cells["btnUpdate"].Value = "修改";


                    if (i % 2 != 0)
                    {
                        this.dgvExaminationInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dgvExaminationInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }

                }
            }
        }

        //public 考试信息添加界面(string todoLogic, ExaminationModel model)
        //{
        //    InitializeComponent();

        //    if (todoLogic == "add")
        //    {
        //        this.Text = "考生信息录入界面";
        //        //this.btnAdd.Text = "添 加";

        //        this.txtExaminationID.Text = GetLatestExaminationID().ToString();
        //    }
        //    else if (todoLogic == "upd")
        //    {
        //        this.Text = "考试信息修改界面";
        //        //this.btnAdd.Text = "修 改";

        //        //// 设置考生信息
        //        //SetExaminationPCInfo(ePCModel);
        //    }

        //    _CurrentLogic = todoLogic;
        //}

        /// <summary>
        /// 获取最新的考试编号
        /// </summary>
        public int GetLatestExaminationID()
        {
            int newID = _ExaminationBLL.GetLatestExaminationID() + 1;

            return newID;
        }

        #region 逻辑验证
        /// <summary>
        /// 添加考试信息前验证
        /// </summary>
        /// <returns>true验证通过，false验证失败</returns>
        private bool CheckBeforeAddExamination()
        {
            // 验证控件是否为空
            if (!Check.isEmpty(this.txtExaminationName, "考试名称"))
            {
                return false;
            }

            // 验证控件是否为空
            if (!Check.isEmpty(this.txtTotalScore, "总分"))
            {
                return false;
            }

            // 验证控件是否为空
            if (!Check.isEmpty(this.txtExaminationPassScore, "合格分数"))
            {
                return false;
            }

            // 验证控件是否为空
            if (!Check.isEmpty(this.txtExaminationTime, "考试时间"))
            {
                return false;
            }

            //TODO:需要验证一下数据库中是否有相同名称的考试名称存在，如果存在两个相同名称的考试名称，会造成混淆

            return true;
        }

        /// <summary>
        /// 添加考试科目信息前验证
        /// </summary>
        /// <returns>true验证通过，false验证失败</returns>
        private bool CheckBeforeAddExaminationSubject()
        {
            // 验证控件是否为空
            if (!Check.isEmpty(this.txtExaminationSubjectName, "考试科目名称"))
            {
                return false;
            }

            // 验证控件是否为空
            if (!Check.isEmpty(this.txtExaminationSubjectShortName, "简称"))
            {
                return false;
            }

            // 验证控件是否为空
            if (!Check.isEmpty(this.txtExaminationSubjectScore, "总分"))
            {
                return false;
            }

            // 验证控件是否为空
            if (!Check.isEmpty(this.txtExaminationSubjectTime, "考试时间"))
            {
                return false;
            }

            // 验证控件是否为空
            if (!this.rbtnRandom.Checked && !this.rbtnCompulsory.Checked)
            {
                Alert.alert("参与组卷方式未选择！");
                return false;
            }

            return true;
        }
        #endregion

        /// <summary>
        /// 考试信息录入/修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOrUpd_Click(object sender, EventArgs e)
        {
            if (_CurrentExaminationLogic == "ExaminationAdd")
            {
                bool checkResult = CheckBeforeAddExamination();

                if (checkResult)
                {
                    ExaminationModel model = new ExaminationModel();
                    // 考试编号
                    model.ExaminationID = this.txtExaminationID.Text.Trim();
                    // 考试名称
                    model.ExaminationName = this.txtExaminationName.Text.Trim();
                    // 组卷方式
                    model.PaperCompilingMode = this.txtPaperCompilingMode.Text.Trim();
                    // 总分
                    model.TotalScore = this.txtTotalScore.Text.Trim();
                    // 合格分数
                    model.ExaminationPassScore = this.txtExaminationPassScore.Text.Trim();
                    // 考试时间
                    model.ExaminationTime = this.txtExaminationTime.Text.Trim();

                    int result = _ExaminationBLL.AddExaminationInfo(model);

                    if (result > 0)
                    {
                        Alert.noteMsg("录入成功！");

                        this.txtExaminationID.Text = GetLatestExaminationID().ToString();

                        this.txtExaminationName.Text = "";
                        this.txtPaperCompilingMode.Text = "";
                        this.txtTotalScore.Text = "";
                        this.txtExaminationPassScore.Text = "";
                        this.txtExaminationTime.Text = "";

                        // 重新加载考试信息列表
                        LoadExaminationInfoForDGV();

                        LoadExaminationInfo();

                        LoadExaminationInfo2();
                    }
                    else
                    {
                        Alert.errorMsg("录入失败！");
                    }
                }
            }
            else if (_CurrentExaminationLogic == "ExaminationUpd")
            {
                bool checkResult2 = CheckBeforeAddExamination();

                if (checkResult2)
                {
                    ExaminationModel model = new ExaminationModel();
                    // 考试编号
                    model.ExaminationID = this.txtExaminationID.Text.Trim();
                    // 考试名称
                    model.ExaminationName = this.txtExaminationName.Text.Trim();
                    // 组卷方式
                    model.PaperCompilingMode = this.txtPaperCompilingMode.Text.Trim();
                    // 总分
                    model.TotalScore = this.txtTotalScore.Text.Trim();
                    // 合格分数
                    model.ExaminationPassScore = this.txtExaminationPassScore.Text.Trim();
                    // 考试时间
                    model.ExaminationTime = this.txtExaminationTime.Text.Trim();

                    int result = _ExaminationBLL.UpdExaminationInfo(model);

                    if (result > 0)
                    {
                        Alert.noteMsg("修改成功！");
                    }
                    else
                    {
                        Alert.errorMsg("修改失败！");
                    }
                }
            }

            _IsTabControl1FirstSelected = true;
        }

        /// <summary>
        /// 考试科目信息录入/修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExamSubjectAddOrUpd_Click(object sender, EventArgs e)
        {
            if (_CurrentExaminationSubjectLogic == "ExaminationSubjectAdd")
            {
                bool checkResult = CheckBeforeAddExaminationSubject();

                if (checkResult)
                {
                    ExaminationSubjectModel _ExaminationSubjectModel = new ExaminationSubjectModel();
                    // 考试科目名称
                    _ExaminationSubjectModel.ExaminationSubjectName = this.txtExaminationSubjectName.Text.Trim();
                    // 简称
                    _ExaminationSubjectModel.ExaminationSubjectShortName = this.txtExaminationSubjectShortName.Text.Trim();
                    // 总分
                    _ExaminationSubjectModel.ExaminationSubjectScore = this.txtExaminationSubjectScore.Text.Trim();
                    // 考试时间
                    _ExaminationSubjectModel.ExaminationSubjectTime = this.txtExaminationSubjectTime.Text.Trim();
                    // 参与组卷方式
                    if (this.rbtnCompulsory.Checked)
                    {
                        _ExaminationSubjectModel.PaperCompilingMode = Const.PAPER_COMPILING_MODE_COMPULSORY;
                    }
                    else if (this.rbtnRandom.Checked)
                    {
                        _ExaminationSubjectModel.PaperCompilingMode = Const.PAPER_COMPILING_MODE_RANDOM;
                    }
                    // 是否包含子科目
                    if (this.rbtnIsHasChildSubject_Yes.Checked)
                    {
                        _ExaminationSubjectModel.IsHasChildSubject = "1";
                    }
                    else if (this.rbtnIsHasChildSubject_No.Checked)
                    {
                        _ExaminationSubjectModel.IsHasChildSubject = "0";
                    }

                    // 考试编号
                    _ExaminationSubjectModel.ExaminationID = this.cbExaminationName.SelectedValue.ToString();

                    int count = _ExaminationSubjectBLL.AddExaminationSubjectInfo(_ExaminationSubjectModel);

                    if (count > 0)
                    {
                        Alert.noteMsg("添加成功！");
                    }
                    else
                    {
                        Alert.errorMsg("添加失败！请先录入考试信息！");
                    }

                    // 加载考试科目信息
                    LoadExaminationSubjectInfoByExaminationID();
                    // 加载考试信息
                    LoadExaminationInfo2();
                }
            }
            else if (_CurrentExaminationSubjectLogic == "ExaminationSubjectUpd")
            {

            }


        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 通过考试编号获取所属所有考试科目信息
        /// </summary>
        /// <param name="id"></param>
        public void LoadExaminationSubjectInfoByExaminationID()
        {
            this._SelectedPKList.Clear();
            this.cbAllSelect.Checked = false;
            this.btnAllDel.Enabled = false;

            this.dgvExaminationSubjectInfo.Rows.Clear();

            string examinationID = this.cbExaminationName.SelectedValue.ToString();

            DataSet ds = _ExaminationSubjectBLL.GetAllExaminationSubjectInfoByExaminationID(examinationID);

            //MessageBox.Show(ds.Tables[0].Rows.Count.ToString());

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                this.dgvExaminationSubjectInfo.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    // 考试科目编号
                    this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectID].Value = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectID].ToString();
                    // 考试科目名称
                    this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectName].Value = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectName].ToString();
                    // 简称
                    this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName].Value = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName].ToString();
                    // 总分
                    this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectScore].Value = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectScore].ToString();
                    // 考试时间
                    this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectTime].Value = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectTime].ToString();
                    // 参与组卷方式
                    string paperCompilingMode = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_PaperCompilingMode].ToString();

                    if (paperCompilingMode == Const.PAPER_COMPILING_MODE_COMPULSORY)
                    {
                        this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_PaperCompilingMode].Value = "必考";
                    }
                    else if (paperCompilingMode == Const.PAPER_COMPILING_MODE_RANDOM)
                    {
                        this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_PaperCompilingMode].Value = "随机";
                    }
                    // 是否包含子科目
                    string isHasChildSubject = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_IsHasChildSubject].ToString();

                    if (isHasChildSubject == "0")
                    {
                        this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_IsHasChildSubject].Value = "否";
                    }
                    else if (isHasChildSubject == "1")
                    {
                        this.dgvExaminationSubjectInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_IsHasChildSubject].Value = "是";
                    }

                    //this.dgvExaminationSujectInfo.Rows[i].Cells["btnUpdate"].Value = "修改";


                    if (i % 2 != 0)
                    {
                        this.dgvExaminationSubjectInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dgvExaminationSubjectInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }

                }
            }
        }

        /// <summary>
        /// 全选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            int count = this.dgvExaminationSubjectInfo.Rows.Count;

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
            int count = this.dgvExaminationSubjectInfo.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                this.dgvExaminationSubjectInfo.Rows[i].Cells[0].Value = flag;
            }

            //MessageBox.Show(_SelectedPKList.Count.ToString());
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        result = result + _ExaminationSubjectBLL.DelExaminationSubjectInfo(_SelectedPKList[i]);
                    }

                    if (result == count)
                    {
                        Alert.noteMsg("删除成功！");

                        // 刷新第三步下拉列表
                        LoadExaminationInfo2();

                    }
                    else
                    {
                        Alert.errorMsg("删除失败！");
                    }

                    LoadExaminationSubjectInfoByExaminationID();
                }
            }
        }

        /// <summary>
        /// 是否包含子科目-是
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnIsHasChildSubject_Yes_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 是否包含子科目-否
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnIsHasChildSubject_No_CheckedChanged(object sender, EventArgs e)
        {

        }

        #region 只允许输入数字
        private void txtTotalScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtExaminationPassScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtExaminationTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtExaminationSubjectScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtExaminationSubjectTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        #endregion

        /// <summary>
        /// CheckBox选中状态判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvExaminationSujectInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //MessageBox.Show("1");

                if (this.dgvExaminationSubjectInfo.Columns[e.ColumnIndex].Name.Equals("CheckBox"))
                {
                    // 考生科目编号
                    string pk = this.dgvExaminationSubjectInfo.Rows[e.RowIndex].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectID].Value.ToString();

                    // 获得checkbox 列单元格
                    DataGridViewCheckBoxCell dgvCheckBoxCell = this.dgvExaminationSubjectInfo.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

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

        private void dgvExaminationSujectInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    MessageBox.Show("update");
            //    //    // 考生编号
            //    //    string examineeID = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeID].Value.ToString();
            //    //    // 考生姓名
            //    //    string examineeName = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeName].Value.ToString();

            //    //    // 身份证号
            //    //    string idCardNum = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_IDCardNum].Value.ToString();

            //    //    // 考生所属公司
            //    //    string examineeCompanyID = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeCompanyID].Value.ToString();

            //    //    ExamineeModel em = new ExamineeModel();
            //    //    em.ExamineeID = examineeID;
            //    //    em.ExamineeName = examineeName;
            //    //    em.IDCardNum = idCardNum;
            //    //    em.ExamineeCompanyID = examineeCompanyID;

            //    //    考生信息添加界面 form = new 考生信息添加界面("upd", em);
            //    //    form.ShowDialog(this);
            //}
        }

        private void dgvExaminationSujectInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvExaminationSubjectInfo.IsCurrentCellDirty)
            {

                this.dgvExaminationSubjectInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //为什么要使用this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit); 
                //因为当我们对 checkbox 的 cell 进行编辑后，你会看到在 RowHeader 上显示一个笔的形状的东西，这说明此列正在编辑，如果直接用 Value 获取值，则会获得在编辑之前的值，
                //使用了 CommitEdit 方法后，我们再调用 Value 属性就会获得你看到的值，当然这句话也可以放在 dataGridView 的事件里面进行处理，就不需要再每次遍历之前执行这句了。
            }
        }

        private void dgvExaminationSujectInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex + "," + e.ColumnIndex);

            if (e.RowIndex >= 0)
            {
                //if (e.ColumnIndex == 0)
                //{
                //    MessageBox.Show("CheckBox");
                //}

                //if (this.dgvExaminationSujectInfo.Columns[e.ColumnIndex].Name.Equals("btnUpdate"))
                //{
                //    MessageBox.Show("update");
                //}

                //// 考生编号
                //string examineeID = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeID].Value.ToString();
                //// 考生姓名
                //string examineeName = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeName].Value.ToString();

                //// 身份证号
                //string idCardNum = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_IDCardNum].Value.ToString();

                //// 考生所属公司
                //string examineeCompanyID = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeCompanyID].Value.ToString();

                //ExamineeModel em = new ExamineeModel();
                //em.ExamineeID = examineeID;
                //em.ExamineeName = examineeName;
                //em.IDCardNum = idCardNum;
                //em.ExamineeCompanyID = examineeCompanyID;

                //考生信息添加界面 form = new 考生信息添加界面("upd", em);
                //form.ShowDialog(this);
            }
        }

        private void dgvExaminationSujectInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ////MessageBox.Show(e.RowIndex + "," + e.ColumnIndex);

            //if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            //{
            //    this.dgvExaminationSujectInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            //}

        }

        private bool _IsTabControl1FirstSelected = true;
        private bool _IsTabControl2FirstSelected = true;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.tabControl1.SelectedIndex.ToString());

            if (this.tabControl1.SelectedIndex == 0)
            {

            }
            else if (this.tabControl1.SelectedIndex == 1)
            {
                if (_IsTabControl1FirstSelected)
                {
                    //// 加载考试信息
                    //LoadExaminationInfo();

                    //// 加载考试科目信息
                    //LoadExaminationSubjectInfoByExaminationID();

                    _IsTabControl1FirstSelected = false;
                }
            }
            else if (this.tabControl1.SelectedIndex == 2)
            {
                if (_IsTabControl2FirstSelected)
                {
                    //// 加载考试信息
                    //LoadExaminationInfo2();

                    _IsTabControl2FirstSelected = false;
                }
                //if (this.cbExaminationName.SelectedIndex == -1)
                //{
                //    this.cbExaminationNameForItem.SelectedIndex = this.cbExaminationName.SelectedIndex;
                //}
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

                for (int i = count - 1; i >= 0; i--)
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

                //this.cbExaminationNameForItem.DataSource = list2;
                //this.cbExaminationNameForItem.DisplayMember = ExaminationModel.ColumnName_ExaminationName;
                //this.cbExaminationNameForItem.ValueMember = ExaminationModel.ColumnName_ExaminationID;

                //注册TextChanged事件  
                this.cbExaminationName.TextChanged += new EventHandler(Combo_TextChanged);
                //this.cbExaminationNameForItem.TextChanged += new EventHandler(Combo_TextChanged2);
            }
        }

        /// <summary>
        /// 加载考试信息
        /// </summary>
        private void LoadExaminationInfo2()
        {

            DataSet ds = _ExaminationBLL.GetAllExaminationInfo();

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                ArrayList list = new ArrayList();

                for (int i = count - 1; i >= 0; i--)
                {
                    string examinationID = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationID].ToString();
                    string examinationName = ds.Tables[0].Rows[i][ExaminationModel.ColumnName_ExaminationName].ToString();

                    ExaminationModel em = new ExaminationModel();
                    em.ExaminationID = examinationID;
                    em.ExaminationName = examinationName;

                    list.Add(em);
                }

                this.cbExaminationNameForItem.DataSource = list;
                this.cbExaminationNameForItem.DisplayMember = ExaminationModel.ColumnName_ExaminationName;
                this.cbExaminationNameForItem.ValueMember = ExaminationModel.ColumnName_ExaminationID;

                //注册TextChanged事件  
                this.cbExaminationNameForItem.TextChanged += new EventHandler(Combo_TextChanged2);

                Combo_TextChanged2(null, null);
            }
        }

        private void Combo_TextChanged(object sender, EventArgs e)
        {
            LoadExaminationSubjectInfoByExaminationID();

            // tab1和tab2考试科目保持同步
            this.cbExaminationNameForItem.SelectedIndex = this.cbExaminationName.SelectedIndex;
        }

        private void Combo_TextChanged2(object sender, EventArgs e)
        {
            string examinationID = this.cbExaminationNameForItem.SelectedValue.ToString();

            DataSet ds = _ExaminationSubjectBLL.GetAllExaminationSubjectInfoByExaminationID(examinationID);

            //MessageBox.Show(ds.Tables[0].Rows.Count.ToString());

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                ArrayList list = new ArrayList();

                for (int i = count - 1; i >= 0; i--)
                {
                    string examinationSubjectID = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectID].ToString();
                    string examinationSubjectName = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectName].ToString();

                    string shortName = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName].ToString();

                    ExaminationSubjectModel esm = new ExaminationSubjectModel();
                    esm.ExaminationSubjectID = examinationSubjectID;
                    esm.ExaminationSubjectName = examinationSubjectName + "(" + shortName + ")";

                    list.Add(esm);
                }

                this.cbExaminationSujectNameForItem.DataSource = list;
                this.cbExaminationSujectNameForItem.DisplayMember = ExaminationSubjectModel.ColumnName_ExaminationSubjectName;
                this.cbExaminationSujectNameForItem.ValueMember = ExaminationSubjectModel.ColumnName_ExaminationSubjectID;
            }

            // tab1和tab2考试科目保持同步
            this.cbExaminationName.SelectedIndex = this.cbExaminationNameForItem.SelectedIndex;
        }

        /// <summary>
        /// 操作类型-内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnOperationType_Content_CheckedChanged(object sender, EventArgs e)
        {
            _OperationType = "内容";

            if (this.txtScoreStandard.Text.Trim() != "")
            {
                SetScoreStandardText(_OperationType, this.txtScoreStandard.Text.Trim());
            }
        }

        private string _OperationType = "";

        /// <summary>
        /// 操作类型-步骤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnOperationType_Step_CheckedChanged(object sender, EventArgs e)
        {
            _OperationType = "步骤";

            if (this.txtScoreStandard.Text.Trim() != "")
            {
                SetScoreStandardText(_OperationType, this.txtScoreStandard.Text.Trim());
            }
        }

        private void txtScoreStandard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 分数标准
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScoreStandard_TextChanged(object sender, EventArgs e)
        {
            if (this.txtScoreStandard.Text.Trim() != "" && (this.rbtnOperationType_Content.Checked || this.rbtnOperationType_Step.Checked))
            {
                SetScoreStandardText(_OperationType, this.txtScoreStandard.Text.Trim());
            }
        }

        /// <summary>
        /// 设置考试标准
        /// </summary>
        private void SetScoreStandardText(string operationType, string scoreStandard)
        {
            string temp = "";

            if (operationType == "内容")
            {
                temp = "项";
            }
            else if (operationType == "步骤")
            {
                temp = "步";
            }

            string scoreStandardText = string.Format("操作{0}每{1}{2}分，每缺一{1}或一{1}不正确扣{2}分。", operationType, temp, scoreStandard);

            this.txtScoreStandardText.Text = scoreStandardText;
        }

        /// <summary>
        /// 内容/步骤列表 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbContentOrStepList_DoubleClick(object sender, EventArgs e)
        {
            this.lbContentOrStepList.Items.Remove(this.lbContentOrStepList.SelectedItem);
        }

        /// <summary>
        /// 添加操作内容与步骤到列表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddOperationContentOrStep_Click(object sender, EventArgs e)
        {
            if (Check.isEmpty(this.txtOperationContentAndStepDetail, "操作内容与步骤"))
            {
                this.lbContentOrStepList.Items.Add(this.txtOperationContentAndStepDetail.Text.Trim());
                this.txtOperationContentAndStepDetail.Text = "";
                this.txtOperationContentAndStepDetail.Focus();
            }
        }

        // add by wuxin at 2019/12/06 - start
        /// <summary>
        /// 
        /// </summary>
        /// <returns>true验证通过，false验证失败</returns>
        private bool CheckBeforeAddExaminationItem()
        {
            // 验证控件是否为空
            if (!Check.isEmpty(this.txtNo, "序号"))
            {
                return false;
            }

            // 验证控件是否为空
            if (!Check.isEmpty(this.txtExaminationItemName, "考试项目名称"))
            {
                return false;
            }

            // 验证控件是否为空
            if (lbContentOrStepList.Items.Count <= 0)
            {
                Alert.alert("操作内容与步骤不能为空！");
                return false;
            }

            // 验证控件是否为空
            if (!Check.isEmpty(this.txtScoreValue, "分值"))
            {
                return false;
            }


            // 验证控件是否为空
            if (!Check.isEmpty(this.txtScoreValue, "分值"))
            {
                return false;
            }

            // 验证控件是否为空
            if (!this.rbtnOperationType_Content.Checked && !this.rbtnOperationType_Step.Checked)
            {
                Alert.alert("操作类型不能为空！");
                return false;
            }

            // 验证控件是否为空
            if (!Check.isEmpty(this.txtScoreStandard, "每项（步）分数"))
            {
                return false;
            }

            int totalScore = Convert.ToInt32(this.txtScoreValue.Text);
            int currentTotalScore = Convert.ToInt32(this.txtScoreStandard.Text) * this.lbContentOrStepList.Items.Count;

            if (totalScore != currentTotalScore)
            {
                Alert.alert("每项(步)分数 × 内容(步骤)数 ≠ 分值，请重新设置分值或每项(步)分数！");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 考试项目录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExaminationItemAdd_Click(object sender, EventArgs e)
        {
            if (_CurrentExaminationItemLogic == "ExaminationItemAdd")
            {
                bool checkResult = CheckBeforeAddExaminationItem();

                if (checkResult)
                {
                    ExaminationItemModel examinationItemModel = new ExaminationItemModel();
                    // 考试科目编号
                    examinationItemModel.ExaminationSubjectID = this.cbExaminationSujectNameForItem.SelectedValue.ToString();
                    // 序号
                    examinationItemModel.No = this.txtNo.Text.Trim();
                    // 考试项目名称
                    examinationItemModel.ExaminationItemName = this.txtExaminationItemName.Text.Trim();
                    // 操作内容与步骤名称
                    examinationItemModel.OperationContentAndStep = this.txtOperationContentAndStep.Text.Trim();
                    // 考试方式
                    examinationItemModel.ExaminationWay = this.txtExaminationWay.Text.Trim();
                    // 分值
                    examinationItemModel.ScoreValue = this.txtScoreValue.Text.Trim();
                    // 操作类型
                    if (this.rbtnOperationType_Content.Checked)
                    {
                        examinationItemModel.Type = Const.OPERATION_TYPE_CONTENT;
                    }
                    else if (this.rbtnOperationType_Step.Checked)
                    {
                        examinationItemModel.Type = Const.OPERATION_TYPE_STEP;
                    }

                    // 考核分值
                    examinationItemModel.ScoreStandard = this.txtScoreStandard.Text.Trim();
                    // 考核标准
                    examinationItemModel.ScoreStandardText = this.txtScoreStandardText.Text.Trim();

                    int count = _ExaminationItemBLL.AddExaminationItemInfo(examinationItemModel);

                    // 考试项目信息添加结果
                    bool examinationItemAddResult = true;

                    if (count > 0)
                    {
                        //Alert.noteMsg("添加成功！");
                    }
                    else
                    {
                        Alert.errorMsg("考试项目信息添加失败！");

                        examinationItemAddResult = false;
                    }

                    if (examinationItemAddResult)
                    {
                        // 添加考试项目信息详情
                        // 1.获取新添加的考试项目ID
                        int latestExaminationID = _ExaminationItemBLL.GetLatestExaminationItemID();

                        // 2.添加考试项目详情信息
                        int contentOrStepListCount = this.lbContentOrStepList.Items.Count;

                        int tempCount = 0;

                        if (contentOrStepListCount > 0)
                        {
                            for (int i = 0; i < contentOrStepListCount; i++)
                            {
                                ExaminationItemDetailModel examinationItemDetailModel = new ExaminationItemDetailModel();
                                examinationItemDetailModel.ContentOrStepDetail = this.lbContentOrStepList.Items[i].ToString();
                                examinationItemDetailModel.ExaminationItemID = latestExaminationID.ToString();

                                int examinationItemDetailAddResult = _ExaminationItemBLL.AddExaminationItemDetailInfo(examinationItemDetailModel);

                                tempCount++;
                            }

                            if (contentOrStepListCount == tempCount)
                            {
                                Alert.noteMsg("添加成功！");

                                this.txtOperationContentAndStep.Focus();

                                // 清空内容与步骤列表
                                this.lbContentOrStepList.Items.Clear();
                            }
                            else
                            {
                                Alert.errorMsg("考试项目详细信息添加失败！(" + tempCount + "/" + contentOrStepListCount + ")");
                            }

                        }


                        // 3.1、2都OK，操作完成
                    }
                }
            }
        }

        private void btnNoImage_Click(object sender, EventArgs e)
        {
            参考图片查看界面 form = new 参考图片查看界面("No");
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                this.txtNo.Focus();
            }
        }

        private void btnExaminationItemNameImage_Click(object sender, EventArgs e)
        {
            参考图片查看界面 form = new 参考图片查看界面("ExaminationItemName");
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                this.txtExaminationItemName.Focus();
            }
        }

        private void btnOperationContentAndStepImage_Click(object sender, EventArgs e)
        {
            参考图片查看界面 form = new 参考图片查看界面("OperationContentAndStep");
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                this.txtOperationContentAndStep.Focus();
            }

        }

        private void btnOperationContentAndStepDetailImage_Click(object sender, EventArgs e)
        {
            参考图片查看界面 form = new 参考图片查看界面("OperationContentAndStepDetail");
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                this.txtOperationContentAndStepDetail.Focus();
            }
        }

        private void btnScoreValueImage_Click(object sender, EventArgs e)
        {
            参考图片查看界面 form = new 参考图片查看界面("ScoreValue");
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                this.txtScoreValue.Focus();
            }

        }

        private void btnScoreStandard_Click(object sender, EventArgs e)
        {
            参考图片查看界面 form = new 参考图片查看界面("ScoreStandard");
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                this.txtScoreStandard.Focus();
            }
        }

        // 清除录入过程中的空格，方便数据录入
        private void txtExaminationItemName_TextChanged(object sender, EventArgs e)
        {
            string str = this.txtExaminationItemName.Text.Trim();

            str = str.Replace("\n", "");

            this.txtExaminationItemName.Text = str;
        }

        // 清除录入过程中的空格，方便数据录入
        private void txtOperationContentAndStepDetail_TextChanged(object sender, EventArgs e)
        {
            string str = this.txtOperationContentAndStepDetail.Text.Trim();

            str = str.Replace("\n", "");

            this.txtOperationContentAndStepDetail.Text = str;
        }

        /// <summary>
        /// 打开考试项目查询界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenExamItemSelectForm_Click(object sender, EventArgs e)
        {
            考试项目查询界面 form = new 考试项目查询界面();
            form.Show();
        }

        private void cbSelectAllExaminationInfo_CheckedChanged(object sender, EventArgs e)
        {
            int count = this.dgvExaminationInfo.Rows.Count;

            if (count > 0)
            {
                if (this.cbSelectAllExaminationInfo.Checked)
                {
                    //MessageBox.Show("全选");
                    SetGVAllCheckBoxState2(true);
                }
                else
                {
                    //MessageBox.Show("全不选");
                    SetGVAllCheckBoxState2(false);
                }
            }
        }

        /// <summary>
        /// 设置当前GV所有CheckBox状态
        /// </summary>
        /// <param name="flag"></param>
        private void SetGVAllCheckBoxState2(bool flag)
        {
            int count = this.dgvExaminationInfo.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                this.dgvExaminationInfo.Rows[i].Cells[0].Value = flag;
            }

            //MessageBox.Show(_SelectedPKList.Count.ToString());
        }

        /// <summary>
        /// 选中数据的主键集合
        /// </summary>
        private List<string> _SelectedExaminationPKList = new List<string>();

        private void dgvExaminationInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //MessageBox.Show("1");

                if (this.dgvExaminationInfo.Columns[e.ColumnIndex].Name.Equals("CheckBox1"))
                {
                    // 考生编号
                    string pk = this.dgvExaminationInfo.Rows[e.RowIndex].Cells[ExaminationModel.ColumnName_ExaminationID].Value.ToString();

                    // 获得checkbox 列单元格
                    DataGridViewCheckBoxCell dgvCheckBoxCell = this.dgvExaminationInfo.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                    bool flag = Convert.ToBoolean(dgvCheckBoxCell.Value);

                    if (flag)
                    {
                        _SelectedExaminationPKList.Add(pk);
                        //MessageBox.Show(_SelectedPKList.Count.ToString());
                        // 设置全部删除按钮状态
                        SetAllDelButtonState2();
                    }
                    else
                    {
                        _SelectedExaminationPKList.Remove(pk);
                        //MessageBox.Show(_SelectedPKList.Count.ToString());
                        // 设置全部删除按钮状态
                        SetAllDelButtonState2();
                    }
                }
            }
        }

        /// <summary>
        /// 设置全部删除按钮状态
        /// </summary>
        private void SetAllDelButtonState2()
        {
            if (_SelectedExaminationPKList.Count > 0)
            {
                this.btnDelExaminationInfo.Enabled = true;
            }
            else
            {
                this.btnDelExaminationInfo.Enabled = false;
            }
        }

        private void dgvExaminationInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvExaminationInfo.IsCurrentCellDirty)
            {

                this.dgvExaminationInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //为什么要使用this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit); 
                //因为当我们对 checkbox 的 cell 进行编辑后，你会看到在 RowHeader 上显示一个笔的形状的东西，这说明此列正在编辑，如果直接用 Value 获取值，则会获得在编辑之前的值，
                //使用了 CommitEdit 方法后，我们再调用 Value 属性就会获得你看到的值，当然这句话也可以放在 dataGridView 的事件里面进行处理，就不需要再每次遍历之前执行这句了。
            }
        }

        private void btnDelExaminationInfo_Click(object sender, EventArgs e)
        {
            if (Alert.confirm("是否确认删除？"))
            {
                int count = _SelectedExaminationPKList.Count;

                //MessageBox.Show(count.ToString());

                if (count > 0)
                {
                    int result = 0;

                    for (int i = 0; i < count; i++)
                    {
                        result = result + _ExaminationBLL.DelExaminationInfo(_SelectedExaminationPKList[i]);
                    }

                    if (result > 0)
                    {
                        Alert.noteMsg("删除完成！(" + result + "/" + count + ")");

                        // 重新加载考试信息列表
                        LoadExaminationInfoForDGV();

                        LoadExaminationInfo();

                        LoadExaminationInfo2();

                    }
                    else
                    {
                        Alert.errorMsg("部分删除失败！");
                    }
                }
            }
        }
        // add by wuxin at 2019/12/06 - end
    }
}
