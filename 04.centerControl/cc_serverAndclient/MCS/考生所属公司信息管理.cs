using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MCS
{
    public partial class 考生所属公司信息管理 : Form
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int _RecordCount = 0;
        /// <summary>
        /// Where条件字符串
        /// </summary>
        string strWhere = "";
        /// <summary>
        /// 选中数据的主键集合
        /// </summary>
        private List<string> _SelectedPKList = new List<string>();

        /// <summary>
        /// 当前选中行Index
        /// </summary>
        private int _CurrentSelectedRowIndex = -1;

        // BLL
        ExamineeCompanyBLL _ExamineeCompanyBLL = new ExamineeCompanyBLL();
        PageBLL _PageBLL = new PageBLL();

        //Dictionary<string, string> _ExamineeCompanyDic = new Dictionary<string, string>();

        public 考生所属公司信息管理()
        {
            InitializeComponent();

            // 加载考生所属公司信息数据
            BindDataWithPage(1, 10);
        }

        /// <summary>
        /// 子窗体关闭
        /// </summary>
        public void ChildFormClose(string logic)
        {
            // 重置界面控件状态
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
                    this.dgvExamineeCompanyInfo.ClearSelection();
                    this.dgvExamineeCompanyInfo.Rows[_CurrentSelectedRowIndex].Selected = true;
                }
            }
            // del
            else
            {
                // 加载考生所属公司信息数据
                BindDataWithPage(1, 10);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, System.EventArgs e)
        {
            bool checkResult = CheckBeforeSelect();

            if (checkResult)
            {
                strWhere = "1=1";

                // 全部查询
                if (string.IsNullOrEmpty(this.txtExamineeCompanyName.Text.Trim()))
                {
                    strWhere = "1=1";
                }

                // 根据考生所属公司模糊查询
                if (!string.IsNullOrEmpty(this.txtExamineeCompanyName.Text.Trim()))
                {
                    strWhere = strWhere + " AND " + ExamineeCompanyModel.ColumnName_ExamineeCompanyName + " like '%" + this.txtExamineeCompanyName.Text.Trim() + "%'";
                }

                BindDataWithPage(1, pageControl2.PageSize);
            }
        }

        /// <summary>
        /// 查询前检查
        /// </summary>
        private bool CheckBeforeSelect()
        {
            bool checkResult = true;

            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtExamineeCompanyName, "所属公司名称");

            if (!checkResult) return checkResult;

            return checkResult;

        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show("Parent");
            this.Close();
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddExamineeCompanyInfo_Click(object sender, System.EventArgs e)
        {
            考生所属公司信息添加 form = new 考生所属公司信息添加("add", null);
            form.ShowDialog(this);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllDel_Click(object sender, System.EventArgs e)
        {
            if (Alert.confirm("是否确认删除？"))
            {
                int count = _SelectedPKList.Count;

                if (count > 0)
                {
                    int result = 0;

                    for (int i = 0; i < count; i++)
                    {
                        result = result + _ExamineeCompanyBLL.DelExamineeCompanyInfo(_SelectedPKList[i]);
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

        /// <summary>
        /// 重置界面控件状态
        /// </summary>
        private void ResetFormControlState()
        {
            this._SelectedPKList.Clear();
            this.cbAllSelect.Checked = false;
            this.btnAllDel.Enabled = false;
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
            //    this.dgvExamineeCompanyInfo.Rows.Clear();
            //    // add by wuxin at 2018/09/10 - end

            //    Alert.noteMsg("无数据！");

            //    return null;
            //}
            if (ds.Tables[0].Rows.Count <= 0)
            {
                this.dgvExamineeCompanyInfo.Rows.Clear();

                _RecordCount = 0;

                Alert.noteMsg("无数据！");

                return null;
            }
            // upd by wuxin at 2020/1/8 - end

            return ds;
        }

        /// <summary>
        /// 绑定第Index页的数据
        /// </summary>
        /// <param name="Index"></param>
        private void BindDataWithPage(int index, int pageSize)
        {
            // 重置界面控件状态
            ResetFormControlState();

            this.pageControl2.PageIndex = index;
            this.pageControl2.PageSize = pageSize;

            PageModel pm = new PageModel();
            pm.Columns = "*";
            pm.TableName = "t_examinee_company_info";

            if (string.IsNullOrEmpty(strWhere))
            {
                strWhere = "1=1";
            }

            pm.Where = strWhere;
            pm.OrderBy = "ExamineeCompanyID desc";
            pm.PageIndex = index.ToString();
            pm.PageSize = pageSize.ToString();

            DataSet ds = GetData(pm);

            if (ds != null)
            {
                int count = ds.Tables[0].Rows.Count;

                this.dgvExamineeCompanyInfo.Rows.Clear();
                this.dgvExamineeCompanyInfo.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    this.dgvExamineeCompanyInfo.Rows[i].Cells[ExamineeModel.ColumnName_ExamineeCompanyID].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeCompanyID].ToString();

                    this.dgvExamineeCompanyInfo.Rows[i].Cells[ExamineeModel.ColumnName_ExamineeCompanyName].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeCompanyName].ToString();

                    this.dgvExamineeCompanyInfo.Rows[i].Cells["btnUpdate"].Value = "修改";

                    if (i % 2 != 0)
                    {
                        this.dgvExamineeCompanyInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dgvExamineeCompanyInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }
                }

                int.TryParse(ds.Tables[2].Rows[0][PageModel.ColumnName_TotalCount].ToString(), out _RecordCount);

                // 获取并设置总记录数
                this.pageControl2.RecordCount = _RecordCount;

                this.pageControl2.ResetPageControl();
            }

            else
            {
                this.pageControl2.RecordCount = 0;

                this.pageControl2.ResetPageControl();
            }
        }

        private void pageControl2_PageIndexChanged(object sender, System.EventArgs e)
        {
            BindDataWithPage(pageControl2.PageIndex, pageControl2.PageSize);
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllSelect_CheckedChanged(object sender, System.EventArgs e)
        {
            int count = this.dgvExamineeCompanyInfo.Rows.Count;

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
            int count = this.dgvExamineeCompanyInfo.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                this.dgvExamineeCompanyInfo.Rows[i].Cells[0].Value = flag;
            }

            //MessageBox.Show(_SelectedPKList.Count.ToString());
        }

        private void dgvExamineeCompanyInfo_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            if (this.dgvExamineeCompanyInfo.IsCurrentCellDirty)
            {

                this.dgvExamineeCompanyInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //为什么要使用this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit); 
                //因为当我们对 checkbox 的 cell 进行编辑后，你会看到在 RowHeader 上显示一个笔的形状的东西，这说明此列正在编辑，如果直接用 Value 获取值，则会获得在编辑之前的值，
                //使用了 CommitEdit 方法后，我们再调用 Value 属性就会获得你看到的值，当然这句话也可以放在 dataGridView 的事件里面进行处理，就不需要再每次遍历之前执行这句了。
            }
        }

        private void dgvExamineeCompanyInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = this.dgvExamineeCompanyInfo.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    // 所属公司编号
                    string examineeCompanyID = this.dgvExamineeCompanyInfo.Rows[e.RowIndex].Cells[ExamineeCompanyModel.ColumnName_ExamineeCompanyID].Value.ToString();
                    // 所属公司名称
                    string examineeCompanyName = this.dgvExamineeCompanyInfo.Rows[e.RowIndex].Cells[ExamineeCompanyModel.ColumnName_ExamineeCompanyName].Value.ToString();

                    ExamineeCompanyModel ecm = new ExamineeCompanyModel();
                    ecm.ExamineeCompanyName = examineeCompanyName;
                    ecm.ExamineeCompanyID = examineeCompanyID;

                    考生所属公司信息添加 form = new 考生所属公司信息添加("upd", ecm);
                    form.ShowDialog(this);
                }
            }
        }

        private void dgvExamineeCompanyInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = this.dgvExamineeCompanyInfo.Columns[e.ColumnIndex];

                if (column.Name.Equals("CheckBox"))
                {
                    // 所属公司编号
                    string pk = this.dgvExamineeCompanyInfo.Rows[e.RowIndex].Cells[ExamineeCompanyModel.ColumnName_ExamineeCompanyID].Value.ToString();

                    // 获得checkbox 列单元格
                    DataGridViewCheckBoxCell dgvCheckBoxCell = this.dgvExamineeCompanyInfo.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                    bool flag = Convert.ToBoolean(dgvCheckBoxCell.Value);

                    if (flag)
                    {
                        _SelectedPKList.Add(pk);

                        // 设置全部删除按钮状态
                        SetAllDelButtonState();
                    }
                    else
                    {
                        _SelectedPKList.Remove(pk);

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

        private void dgvExamineeCompanyInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex == 0)

            if (e.RowIndex >= 0)
            {
                //MessageBox.Show(e.RowIndex.ToString());
                _CurrentSelectedRowIndex = e.RowIndex;
            }
        }

        private void dgvExamineeCompanyInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 所属公司编号
                string examineeCompanyID = this.dgvExamineeCompanyInfo.Rows[e.RowIndex].Cells[ExamineeCompanyModel.ColumnName_ExamineeCompanyID].Value.ToString();
                // 所属公司名称
                string examineeCompanyName = this.dgvExamineeCompanyInfo.Rows[e.RowIndex].Cells[ExamineeCompanyModel.ColumnName_ExamineeCompanyName].Value.ToString();

                ExamineeCompanyModel ecm = new ExamineeCompanyModel();
                ecm.ExamineeCompanyName = examineeCompanyName;
                ecm.ExamineeCompanyID = examineeCompanyID;

                考生所属公司信息添加 form = new 考生所属公司信息添加("upd", ecm);
                form.ShowDialog(this);
            }
        }

        private void txtExamineeCompanyName_TextChanged(object sender, EventArgs e)
        {
            Check.CheckSpecialCharacters(this.txtExamineeCompanyName, "所属公司名称");
        }

        ///// <summary>
        ///// 刷新考生所属公司列表
        ///// </summary>
        //private void RefreshExamineeCompanyListBox()
        //{
        //    LoadExamineeCompanyInfo();
        //}

        ///// <summary>
        ///// 加载考生所属公司信息
        ///// </summary>
        //private void LoadExamineeCompanyInfo()
        //{
        //    //this.lbExamineeCompany.Items.Clear();
        //    //_ExamineeCompanyDic.Clear();

        //    //DataSet ds = _ExamineeCompanyBLL.GetAllExamineeCompany();

        //    //int count = ds.Tables[0].Rows.Count;

        //    //if (count > 0)
        //    //{
        //    //    for (int i = 0; i < count; i++)
        //    //    {
        //    //        string examineeCompanyID = ds.Tables[0].Rows[i][ExamineeCompanyModel.ColumnName_ExamineeCompanyID].ToString();
        //    //        string examineeCompanyName = ds.Tables[0].Rows[i][ExamineeCompanyModel.ColumnName_ExamineeCompanyName].ToString();

        //    //        this.lbExamineeCompany.Items.Add(examineeCompanyName);

        //    //        if (!_ExamineeCompanyDic.ContainsKey(examineeCompanyName))
        //    //        {
        //    //            _ExamineeCompanyDic.Add(examineeCompanyName, examineeCompanyID);
        //    //        }
        //    //    }
        //    //}
        //}

        #region Button点击事件
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnAddExamineeCompanyInfo_Click(object sender, EventArgs e)
        //{

        //    考生所属公司信息添加 form = new 考生所属公司信息添加("add", null);
        //    form.ShowDialog(this);
        //}

        ///// <summary>
        ///// 关闭
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}


        #endregion

        ///// <summary>
        ///// 考生所属公司ListBox双击事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void lbExamineeCompany_DoubleClick(object sender, EventArgs e)
        //{
        //    if (this.lbExamineeCompany.Items.Count > 0 && this.lbExamineeCompany.SelectedItem != null)
        //    {
        //        ExamineeCompanyModel ecm = new ExamineeCompanyModel();
        //        ecm.ExamineeCompanyName = this.lbExamineeCompany.SelectedItem.ToString();

        //        string value;
        //        _ExamineeCompanyDic.TryGetValue(this.lbExamineeCompany.SelectedItem.ToString(), out value);

        //        ecm.ExamineeCompanyID = value;

        //        考生所属公司信息添加 form = new 考生所属公司信息添加("upd", ecm);
        //        form.ShowDialog(this);
        //    }
        //}
    }
}
