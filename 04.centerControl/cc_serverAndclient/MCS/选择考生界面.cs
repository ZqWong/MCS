using Common;
using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace MCS
{
    public partial class 选择考生界面 : Form
    {
        ExamineeBLL _ExamineeBLL = new ExamineeBLL();
        ExamineeCompanyBLL _ExamineeCompanyBLL = new ExamineeCompanyBLL();
        PageBLL _PageBLL = new PageBLL();

        string strWhere = "";

        public 选择考生界面()
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

        //private void Combo_TextChanged(object sender, EventArgs e)
        //{
        //    //if (_TextChanged != null)
        //    //{
        //    //    //_TextChanged(sender, e);

        //    //    Check.CheckSpecialCharacters(this.cbExamineeCompany, "所属单位");
        //    //}

        //    Check.CheckSpecialCharacters(this.cbExamineeCompany, "所属单位");
        //}

        //private void cbExamineeCompany_TextChanged(object sender, EventArgs e)
        //{

        //}

        //总记录数
        public int _RecordCount = 0;

        /// <summary>
        /// 绑定第Index页的数据
        /// </summary>
        /// <param name="Index"></param>
        private void BindDataWithPage(int index, int pageSize)
        {
            this.pageControl2.PageIndex = index;
            this.pageControl2.PageSize = pageSize;

            PageModel pm = new PageModel();
            pm.Columns = "a.*, b.*";
            // upd by wuxin at 2020/1/8 - start
            //pm.TableName = "t_examinee_info a inner join t_examinee_company_info b On a.ExamineeCompanyID = b.ExamineeCompanyID";
            pm.TableName = "t_examinee_info a left join t_examinee_company_info b On a.ExamineeCompanyID = b.ExamineeCompanyID";
            // upd by wuxin at 2020/1/8 - end
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

                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_IDCardNum].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_IDCardNum].ToString();

                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_ExamineeCompanyID].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeCompanyID].ToString();

                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_ExamineeCompanyName].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ExamineeCompanyName].ToString();

                    // add by wuxin at 2020/1/8 - start
                    this.dgvExamineeInfo.Rows[i].Cells[ExamineeModel.ColumnName_ClassType].Value = ds.Tables[0].Rows[i][ExamineeModel.ColumnName_ClassType].ToString();
                    // add by wuxin at 2020/1/8 - end

                    this.dgvExamineeInfo.Rows[i].Cells["btnChoice"].Value = "选择";

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

            // add by wuxin at 2020/1/8 - start
            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtClassType, "班别");

            if (!checkResult) return checkResult;
            // add by wuxin at 2020/1/8 - end

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
                if (string.IsNullOrEmpty(this.txtExamineeID.Text.Trim()) &&
                    string.IsNullOrEmpty(this.txtExamineeName.Text.Trim()) &&
                    string.IsNullOrEmpty(this.cbExamineeCompany.Text) &&
                    // add by wuxin at 2020/1/8 - start
                    string.IsNullOrEmpty(this.txtClassType.Text.Trim())
                    // add by wuxin at 2020/1/8 - end
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

                // add by wuxin at 2020/1/8 - start
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
                // add by wuxin at 2020/1/8 - end

                BindDataWithPage(1, pageControl2.PageSize);
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

        private void txtExamineeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        #region 特殊字符检查
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

        private void dgvExamineeInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = this.dgvExamineeInfo.Columns[e.ColumnIndex];
                //if (column is DataGridViewButtonColumn)
                //{
                // 考生编号
                string examineeID = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeID].Value.ToString();
                // 考生姓名
                string examineeName = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeName].Value.ToString();
                // 身份证号
                string idCardNum = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_IDCardNum].Value.ToString();
                // 考生所属公司
                string examineeCompanyName = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeCompanyName].Value.ToString();
                // add by wuxin at 2020/1/8 - start
                // 班别
                string classType = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ClassType].Value.ToString();
                // add by wuxin at 2020/1/8 - end

                ExamineeModel em = new ExamineeModel();
                em.ExamineeID = examineeID;
                em.ExamineeName = examineeName;
                em.IDCardNum = idCardNum;
                em.ExamineeCompanyName = examineeCompanyName;
                // add by wuxin at 2020/1/8 - start
                em.ClassType = classType;
                // add by wuxin at 2020/1/8 - end

                回收分配界面 form = (回收分配界面)this.Owner;

                form.ChildFormClose(em);

                this.Close();
                //}
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
                    string examineeCompanyName = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ExamineeCompanyName].Value.ToString();
                    // add by wuxin at 2020/1/8 - start
                    // 班别
                    string classType = this.dgvExamineeInfo.Rows[e.RowIndex].Cells[ExamineeModel.ColumnName_ClassType].Value.ToString();
                    // add by wuxin at 2020/1/8 - end

                    ExamineeModel em = new ExamineeModel();
                    em.ExamineeID = examineeID;
                    em.ExamineeName = examineeName;
                    em.IDCardNum = idCardNum;
                    em.ExamineeCompanyName = examineeCompanyName;
                    // add by wuxin at 2020/1/8 - start
                    em.ClassType = classType;
                    // add by wuxin at 2020/1/8 - end

                    回收分配界面 form = (回收分配界面)this.Owner;

                    form.ChildFormClose(em);

                    this.Close();
                }
            }
        }


    }
}
