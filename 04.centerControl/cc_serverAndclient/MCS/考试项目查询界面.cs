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
    public partial class 考试项目查询界面 : Form
    {
        ExaminationBLL _ExaminationBLL = new ExaminationBLL();
        ExaminationSubjectBLL _ExaminationSubjectBLL = new ExaminationSubjectBLL();
        ExaminationItemBLL _ExaminationItemBLL = new ExaminationItemBLL();

        /// <summary>
        /// 选中数据的主键集合
        /// </summary>
        private List<string> _SelectedPKList = new List<string>();

        public 考试项目查询界面()
        {
            InitializeComponent();

            // 加载考试信息
            LoadExaminationInfo();

            // 加载考试科目信息
            LoadExaminationSubjectInfo();

            // 加载考试项目信息
            LoadExaminationItemInfo();
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
        /// 加载考试科目信息
        /// </summary>
        private void LoadExaminationSubjectInfo()
        {
            string examinationID = this.cbExaminationName.SelectedValue.ToString();

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

                this.cbExaminationSujectName.DataSource = list;
                this.cbExaminationSujectName.DisplayMember = ExaminationSubjectModel.ColumnName_ExaminationSubjectName;
                this.cbExaminationSujectName.ValueMember = ExaminationSubjectModel.ColumnName_ExaminationSubjectID;

                this.cbExaminationSujectName.TextChanged += new EventHandler(Combo2_TextChanged);
            }
        }

        private void Combo_TextChanged(object sender, EventArgs e)
        {
            LoadExaminationSubjectInfo();
        }

        private void Combo2_TextChanged(object sender, EventArgs e)
        {

            LoadExaminationItemInfo();
        }

        /// <summary>
        /// 加载考试项目信息
        /// </summary>
        public void LoadExaminationItemInfo()
        {
            this.dgvExaminationItemInfo.Rows.Clear();

            // 根据考试科目编号，获取考试项目信息
            string examinationSubjectID = this.cbExaminationSujectName.SelectedValue.ToString();

            DataSet ds = _ExaminationItemBLL.GetExaminationItemInfoByExaminationSubjectID(examinationSubjectID);

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                this.dgvExaminationItemInfo.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    // 考试项目编号
                    this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_ExaminationItemID].Value = ds.Tables[0].Rows[i][ExaminationItemModel.ColumnName_ExaminationItemID].ToString();
                    // 序号
                    this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_No].Value = ds.Tables[0].Rows[i][ExaminationItemModel.ColumnName_No].ToString();
                    // 考试项目名称
                    this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_ExaminationItemName].Value = ds.Tables[0].Rows[i][ExaminationItemModel.ColumnName_ExaminationItemName].ToString();
                    // 操作内容与步骤
                    this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_OperationContentAndStep].Value = ds.Tables[0].Rows[i][ExaminationItemModel.ColumnName_OperationContentAndStep].ToString();
                    // 考试方式
                    this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_ExaminationWay].Value = ds.Tables[0].Rows[i][ExaminationItemModel.ColumnName_ExaminationWay].ToString();
                    // 分值
                    this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_ScoreValue].Value = ds.Tables[0].Rows[i][ExaminationItemModel.ColumnName_ScoreValue].ToString();
                    // 每项（步）分数
                    this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_ScoreStandard].Value = ds.Tables[0].Rows[i][ExaminationItemModel.ColumnName_ScoreStandard].ToString();
                    // 操作类型
                    string operationType = ds.Tables[0].Rows[i][ExaminationItemModel.ColumnName_Type].ToString();
                    if (operationType == Const.OPERATION_TYPE_CONTENT)
                    {
                        this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_Type].Value = "内容";
                    }
                    else
                    {
                        this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_Type].Value = "步骤";
                    }
                    // 评分标准
                    this.dgvExaminationItemInfo.Rows[i].Cells[ExaminationItemModel.ColumnName_ScoreStandardText].Value = ds.Tables[0].Rows[i][ExaminationItemModel.ColumnName_ScoreStandardText].ToString();

                    if (i % 2 != 0)
                    {
                        this.dgvExaminationItemInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dgvExaminationItemInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }

                }

                LoadExaminationItemDetailInfo(this.dgvExaminationItemInfo.SelectedRows[0].Index);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 加载考试项目详情信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvExaminationItemInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadExaminationItemDetailInfo(e.RowIndex);
            }

        }

        /// <summary>
        /// 加载考试项目详情信息
        /// </summary>
        public void LoadExaminationItemDetailInfo(int index)
        {
            this.dgvExaminationItemDetailInfo.Rows.Clear();

            string id = this.dgvExaminationItemInfo.Rows[index].Cells[ExaminationItemModel.ColumnName_ExaminationItemID].Value.ToString();

            //MessageBox.Show(id.ToString());

            DataSet ds = _ExaminationItemBLL.GetExaminationItemDetailInfoByExaminationItemID(id);

            int count = ds.Tables[0].Rows.Count;

            if (count > 0)
            {
                this.dgvExaminationItemDetailInfo.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    // 考试项目详情编号
                    this.dgvExaminationItemDetailInfo.Rows[i].Cells[ExaminationItemDetailModel.ColumnName_ID].Value = ds.Tables[0].Rows[i][ExaminationItemDetailModel.ColumnName_ID].ToString();
                    // 考试内容和步骤详情
                    this.dgvExaminationItemDetailInfo.Rows[i].Cells[ExaminationItemDetailModel.ColumnName_ContentOrStepDetail].Value = ds.Tables[0].Rows[i][ExaminationItemDetailModel.ColumnName_ContentOrStepDetail].ToString();

                    if (i % 2 != 0)
                    {
                        this.dgvExaminationItemDetailInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dgvExaminationItemDetailInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }

                }
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string examinationName = this.cbExaminationName.Text.ToString();

            string examinationSubjectName = this.cbExaminationSujectName.Text.ToString();

            //MessageBox.Show(examinationName + "," + examinationSubjectName);

            // 加载考试信息
            LoadExaminationInfo();

            this.cbExaminationName.Text = examinationName;
            this.cbExaminationSujectName.Text = examinationSubjectName;
        }

        private void cbAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            int count = this.dgvExaminationItemInfo.Rows.Count;

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
            int count = this.dgvExaminationItemInfo.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                this.dgvExaminationItemInfo.Rows[i].Cells[0].Value = flag;
            }

            //MessageBox.Show(_SelectedPKList.Count.ToString());
        }

        private void dgvExaminationItemInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //MessageBox.Show("1");

                if (this.dgvExaminationItemInfo.Columns[e.ColumnIndex].Name.Equals("CheckBox"))
                {
                    // 考试项目编号
                    string pk = this.dgvExaminationItemInfo.Rows[e.RowIndex].Cells[ExaminationItemModel.ColumnName_ExaminationItemID].Value.ToString();

                    // 获得checkbox 列单元格
                    DataGridViewCheckBoxCell dgvCheckBoxCell = this.dgvExaminationItemInfo.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

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

        private void dgvExaminationItemInfo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvExaminationItemInfo.IsCurrentCellDirty)
            {

                this.dgvExaminationItemInfo.CommitEdit(DataGridViewDataErrorContexts.Commit);
                //为什么要使用this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit); 
                //因为当我们对 checkbox 的 cell 进行编辑后，你会看到在 RowHeader 上显示一个笔的形状的东西，这说明此列正在编辑，如果直接用 Value 获取值，则会获得在编辑之前的值，
                //使用了 CommitEdit 方法后，我们再调用 Value 属性就会获得你看到的值，当然这句话也可以放在 dataGridView 的事件里面进行处理，就不需要再每次遍历之前执行这句了。
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
                        int errorCount = _ExaminationItemBLL.DelExaminationItemInfo(_SelectedPKList[i]);
                        if (errorCount == 0)
                        {
                            result++;
                        }
                    }

                    if (result == count)
                    {
                        Alert.noteMsg("删除成功！");

                        btnRefresh_Click(null, null);
                    }
                    else
                    {
                        Alert.errorMsg("删除失败！");
                    }

                }
            }
        }
    }
}
