using Common;
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
    public partial class 考生信息管理界面 : Form
    {
        ExamineeBLL _ExamineeBLL = new ExamineeBLL();
        ExamineeCompanyBLL _ExamineeCompanyBLL = new ExamineeCompanyBLL();
        PageBLL _PageBLL = new PageBLL();

        /// <summary>
        /// 当前选中行Index
        /// </summary>
        private int _CurrentSelectedRowIndex = -1;

        public 考生信息管理界面()
        {
            InitializeComponent();

            // 加载公司信息
            LoadExamineeCompanyInfo();

            // 加载考生信息数据
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
                cbExamineeCompany.TextChanged += new EventHandler(Combo_TextChanged);
            }

        }

        /// <summary>
        /// 子窗体关闭
        /// </summary>
        public void ChildFormClose(string logic)
        {
            ResetFormControlState();

            if (logic == "add")
            {
                // 加载考生所属公司信息数据
                BindDataWithPage(1, 10);
            }
            else if (logic == "upd")
            {
                // 加载考生所属公司信息数据
                BindDataWithPage(pageControl2.PageIndex, pageControl2.PageSize);

                if (_CurrentSelectedRowIndex != -1)
                {
                    this.dgvExamineeInfo.ClearSelection();
                    this.dgvExamineeInfo.Rows[_CurrentSelectedRowIndex].Selected = true;
                }
            }
            // del
            else
            {
                // 加载考生所属公司信息数据
                BindDataWithPage(1, 10);
            }
        }

        #region Button点击事件
        /// <summary>
        /// 添加考生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddExamineeInfo_Click(object sender, EventArgs e)
        {
            考生信息添加界面 form = new 考生信息添加界面("add", null);
            form.ShowDialog(this);
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
        #endregion

        //总记录数
        public int _RecordCount = 0;

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

            this.pageControl2.PageIndex = index;
            this.pageControl2.PageSize = pageSize;

            PageModel pm = new PageModel();
            pm.Columns = "a.*, b.*";
            pm.TableName = "t_examinee_info a left join t_examinee_company_info b On a.ExamineeCompanyID = b.ExamineeCompanyID";

            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = "1=1";
            }

            pm.Where = strWhere;
            pm.OrderBy = "a.ExamineeID desc";
            pm.PageIndex = index.ToString();
            pm.PageSize = pageSize.ToString();

            DataSet ds = GetData(pm);

            if (ds != null)
            {
                int count = ds.Tables[0].Rows.Count;

                this.dgvExamineeInfo.Rows.Clear();
                this.dgvExamineeInfo.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_ExamineeID].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeID].ToString();

                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_ExamineeName].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeName].ToString();

                    // add by wuxin at 2018/6/2 - start
                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_IDCardNum].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_IDCardNum].ToString();
                    // add by wuxin at 2018/6/2 - end

                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_ExamineeCompanyID].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeCompanyID].ToString();

                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_ExamineeCompanyName].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeCompanyName].ToString();

                    // add by wuxin at 2020/1/7 - start
                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_ClassType].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ClassType].ToString();
                    // add by wuxin at 2020/1/7 - end

                    this.dgvExamineeInfo.Rows[i].Cells["btnUpdate"].Value = "修改";

                    if (i % 2 != 0)
                    {
                        this.dgvExamineeInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dgvExamineeInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }
                }

                int.TryParse(ds.Tables[2].Rows[0][PageModel.ColumnName_TotalCount].ToString(), out _RecordCount);

                // 获取并设置总记录数
                this.pageControl2.RecordCount = _RecordCount;

                this.pageControl2.ResetPageControl();
            }
            // add by wuxin at 2018/09/10 - start
            else
            {
                this.pageControl2.RecordCount = 0;

                this.pageControl2.ResetPageControl();
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

            // upd by wuxin at 2020/1/8 - start
            //if (ds.Tables[0].Rows.Count <= 0)
            //{
            //    // add by wuxin at 2018/09/10 - start
            //    this.dgvExamineeInfo.Rows.Clear();
            //    // add by wuxin at 2018/09/10 - end

            //    Alert.noteMsg("无数据！");

            //    return null;
            //}
            if (ds.Tables[0].Rows.Count <= 0)
            {
                this.dgvExamineeInfo.Rows.Clear();

                _RecordCount = 0;

                Alert.noteMsg("无数据！");

                return null;
            }
            // upd by wuxin at 2020/1/8 - end

            return ds;
        }

        private void pageControl2_PageIndexChanged(object sender, EventArgs e)
        {
            BindDataWithPage(pageControl2.PageIndex, pageControl2.PageSize);
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

            // add by wuxin at 2020/1/7 - start
            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtClassType, "班别");

            if (!checkResult) return checkResult;
            // add by wuxin at 2020/1/7 - end

            return checkResult;

        }

        string strWhere = "";

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
                if (string.IsNullOrEmpty(this.txtExamineeID.Text.Trim()) &&
                    string.IsNullOrEmpty(this.txtExamineeName.Text.Trim()) &&
                    string.IsNullOrEmpty(this.cbExamineeCompany.Text) &&
                    // add by wuxin at 2020/1/7 - start
                    string.IsNullOrEmpty(this.txtClassType.Text.Trim())
                    // add by wuxin at 2020/1/7 - end
                    )
                {
                    strWhere = "1=1";
                }

                // 根据考生编号模糊查询
                if (!string.IsNullOrEmpty(this.txtExamineeID.Text.Trim()))
                {
                    strWhere = strWhere + " AND " + "a." + ExamineeModel.ColumnName_ExamineeID + " like '%" + this.txtExamineeID.Text.Trim() + "%'";
                }

                // 根据考生姓名模糊查询
                if (!string.IsNullOrEmpty(this.txtExamineeName.Text.Trim()))
                {
                    strWhere = strWhere + " AND " + "a." + ExamineeModel.ColumnName_ExamineeName + " like '%" + this.txtExamineeName.Text.Trim() + "%'";
                }

                // 根据考生所属公司模糊查询
                if (!string.IsNullOrEmpty(this.cbExamineeCompany.Text.Trim()))
                {
                    strWhere = strWhere + " AND " + "b." + ExamineeModel.ColumnName_ExamineeCompanyName + " like '%" + this.cbExamineeCompany.Text + "%'";
                }

                // add by wuxin at 2020/1/7 - start
                // 根据班别模糊查询
                if (!string.IsNullOrEmpty(this.txtClassType.Text.Trim()))
                {
                    string temp = "";

                    // 判断是否为数字
                    if (LibUtilities.IsNumeric(this.txtClassType.Text))
                    {
                        temp = LibUtilities.NumberToChinese(Convert.ToInt32(this.txtClassType.Text.Trim()));
                    }
                    else
                    {
                        temp = this.txtClassType.Text;
                    }

                    strWhere = strWhere + " AND " + "a." + ExamineeModel.ColumnName_ClassType + " like '%" + temp + "%'";
                }
                // add by wuxin at 2020/1/7 - end

                BindDataWithPage(1, pageControl2.PageSize);
            }
        }

        /// <summary>
        /// 智能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtExaminationID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        #region 特殊字符检查
        //private void txtExaminationName_TextChanged(object sender, EventArgs e)
        //{
        //    Check.CheckSpecialCharacters(this.txtExamineeName, "考生姓名");
        //}

        private void txtExamineeName_TextChanged(object sender, EventArgs e)
        {
            Check.CheckSpecialCharacters(this.txtExamineeName, "考生姓名");
        }

        private void txtClassType_TextChanged(object sender, EventArgs e)
        {
            Check.CheckSpecialCharacters(this.txtClassType, "班别");
        }

        private void Combo_TextChanged(object sender, EventArgs e)
        {
            //if (_TextChanged != null)
            //{
            //    //_TextChanged(sender, e);

            //    Check.CheckSpecialCharacters(this.cbExamineeCompany, "所属单位");
            //}

            Check.CheckSpecialCharacters(this.cbExamineeCompany, "所属单位");
        }

        private void cbExamineeCompany_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void dgvExamineeInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvExamineeInfo.IsCurrentCellDirty)
            {

                this.dgvExamineeInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //为什么要使用this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit); 
                //因为当我们对 checkbox 的 cell 进行编辑后，你会看到在 RowHeader 上显示一个笔的形状的东西，这说明此列正在编辑，如果直接用 Value 获取值，则会获得在编辑之前的值，
                //使用了 CommitEdit 方法后，我们再调用 Value 属性就会获得你看到的值，当然这句话也可以放在 dataGridView 的事件里面进行处理，就不需要再每次遍历之前执行这句了。
            }

        }

        // 选中数据的主键集合
        private List<string> _SelectedPKList = new List<string>();

        /// <summary>
        /// CheckBox选中状态判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvExamineeInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = this.dgvExamineeInfo.Columns[e.ColumnIndex];

                if (column.Name.Equals("CheckBox"))
                {
                    // 考生ID
                    string pk = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeID].Value.ToString();

                    // 获得checkbox 列单元格
                    DataGridViewCheckBoxCell dgvCheckBoxCell = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

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
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            int count = this.dgvExamineeInfo.Rows.Count;

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
            int count = this.dgvExamineeInfo.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                this.dgvExamineeInfo.Rows[i].Cells[0].Value = flag;
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

                if (count > 0)
                {
                    int result = 0;

                    for (int i = 0; i < count; i++)
                    {
                        result = result + _ExamineeBLL.DelExamineeInfo(_SelectedPKList[i]);
                    }

                    if (result == count)
                    {
                        Alert.noteMsg("删除成功！");
                    }
                    else
                    {
                        Alert.errorMsg("删除失败！");
                    }

                    this.ChildFormClose("del");
                }
            }
        }

        private void dgvExamineeInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 考生编号
                string examineeID = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeID].Value.ToString();
                // 考生姓名
                string examineeName = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeName].Value.ToString();

                // 身份证号
                string idCardNum = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_IDCardNum].Value.ToString();

                // 考生所属公司
                string examineeCompanyID = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeCompanyID].Value.ToString();

                // add by wuxin at 2020/1/8 - start
                // 班别
                string classType = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ClassType].Value.ToString();
                // add by wuxin at 2020/1/8 - end

                ExamineeModel em = new ExamineeModel();
                em.ExamineeID = examineeID;
                em.ExamineeName = examineeName;
                em.IDCardNum = idCardNum;
                em.ExamineeCompanyID = examineeCompanyID;
                // add by wuxin at 2020/1/8 - start
                em.ClassType = classType;
                // add by wuxin at 2020/1/8 - end

                考生信息添加界面 form = new 考生信息添加界面("upd", em);
                form.ShowDialog(this);
            }
        }

        private void dgvExamineeInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = this.dgvExamineeInfo.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    // 考生编号
                    string examineeID = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeID].Value.ToString();
                    // 考生姓名
                    string examineeName = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeName].Value.ToString();

                    // 身份证号
                    string idCardNum = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_IDCardNum].Value.ToString();

                    // 考生所属公司
                    string examineeCompanyID = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeCompanyID].Value.ToString();

                    // add by wuxin at 2020/1/8 - start
                    // 班别
                    string classType = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ClassType].Value.ToString();
                    // add by wuxin at 2020/1/8 - end

                    ExamineeModel em = new ExamineeModel();
                    em.ExamineeID = examineeID;
                    em.ExamineeName = examineeName;
                    em.IDCardNum = idCardNum;
                    em.ExamineeCompanyID = examineeCompanyID;
                    // add by wuxin at 2020/1/8 - start
                    em.ClassType = classType;
                    // add by wuxin at 2020/1/8 - end

                    考生信息添加界面 form = new 考生信息添加界面("upd", em);
                    form.ShowDialog(this);
                }
            }

        }

        private void dgvExamineeInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            //{
            //    //DataGridViewCheckBoxCell
            //    ////this.dgvExamineeInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].
            //    //this.dgvExamineeInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;

            //    DataGridViewCheckBoxCell dgvCheckBoxCell = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
            //    dgvCheckBoxCell.Value = true;
            //}

            if (e.RowIndex >= 0)
            {
                //MessageBox.Show(e.RowIndex.ToString());
                _CurrentSelectedRowIndex = e.RowIndex;
            }
        }
        // add by wuxin at 2018/6/5 - end

        // add by wuxin at 2020/01/06 - start
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
    }
}
