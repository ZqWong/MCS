using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using System;
using System.Windows.Forms;

namespace MCS
{
    public partial class 考生所属公司信息添加 : Form
    {
        #region 全局变量
        /// <summary>
        /// 当前逻辑
        /// </summary>
        private string _CurrentLogic = "";

        ExamineeCompanyBLL _ExamineeCompanyBLL = new ExamineeCompanyBLL();

        private ExamineeCompanyModel _Temp_ExamineeCompanyModel;

        #endregion

        public 考生所属公司信息添加()
        {
            InitializeComponent();
        }

        public 考生所属公司信息添加(string todoLogic, ExamineeCompanyModel ecm)
        {
            InitializeComponent();

            if (todoLogic == "add")
            {
                this.Text = "考生所属公司添加界面";
                this.btnAddExamineeCompanyInfo.Text = "添 加";
                this.btnDelete.Visible = false;
            }
            else if (todoLogic == "upd")
            {
                this.Text = "考生所属公司修改界面";
                this.btnAddExamineeCompanyInfo.Text = "修 改";
                this.btnDelete.Visible = true;

                this.txtExamineeCompanyName.Text = ecm.ExamineeCompanyName;

                _Temp_ExamineeCompanyModel = ecm;
            }

            _CurrentLogic = todoLogic;
        }


        #region 逻辑验证
        /// <summary>
        /// 添加考试子科目前验证
        /// </summary>
        /// <returns>true验证通过，false验证失败</returns>
        private bool CheckBeforeAddExamineeCompanyInfo()
        {
            bool checkResult = true;

            // 验证控件是否为空
            checkResult = Check.isEmpty(this.txtExamineeCompanyName, "考生所属公司名称");

            if (!checkResult) return checkResult;

            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtExamineeCompanyName, "考生所属公司名称");

            if (!checkResult) return checkResult;

            return checkResult;
        }

        #endregion

        #region Button点击事件
        /// <summary>
        /// 添加考生所属公司信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddExamineeCompanyInfo_Click(object sender, EventArgs e)
        {
            // 添加考试子科目前验证
            bool checkResult = CheckBeforeAddExamineeCompanyInfo();

            // 验证通过
            if (checkResult)
            {
                // 执行添加操作
                if (_CurrentLogic == "add")
                {
                    ExamineeCompanyModel ecmForAdd = new ExamineeCompanyModel();
                    ecmForAdd.ExamineeCompanyName = this.txtExamineeCompanyName.Text.Trim();

                    int count = _ExamineeCompanyBLL.AddExamineeCompanyInfo(ecmForAdd);

                    if (count > 0)
                    {
                        Alert.noteMsg("添加成功！");

                        考生所属公司信息管理 parentForm = (考生所属公司信息管理)this.Owner;

                        parentForm.ChildFormClose("add");

                        this.Close();
                    }
                    else
                    {
                        Alert.errorMsg("添加失败！可能原因：公司名称重复。");
                    }
                }
                // 执行修改操作
                else if (_CurrentLogic == "upd")
                {
                    ExamineeCompanyModel ecmForUpd = new ExamineeCompanyModel();
                    ecmForUpd.ExamineeCompanyName = this.txtExamineeCompanyName.Text.Trim();
                    ecmForUpd.ExamineeCompanyID = _Temp_ExamineeCompanyModel.ExamineeCompanyID;

                    int count = _ExamineeCompanyBLL.UpdExamineeCompanyInfo(ecmForUpd);

                    if (count > 0)
                    {
                        Alert.noteMsg("修改成功！");

                        考生所属公司信息管理 parentForm = (考生所属公司信息管理)this.Owner;

                        parentForm.ChildFormClose("upd");

                        this.Close();
                    }
                    else
                    {
                        Alert.errorMsg("修改失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Child");
            this.Close();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Alert.confirm("是否确认删除？"))
            {
                int count = _ExamineeCompanyBLL.DelExamineeCompanyInfo(_Temp_ExamineeCompanyModel.ExamineeCompanyID);

                if (count > 0)
                {
                    Alert.noteMsg("删除成功！");

                    考生所属公司信息管理 parentForm = (考生所属公司信息管理)this.Owner;

                    parentForm.ChildFormClose("del");

                    this.Close();
                }
                else
                {
                    Alert.errorMsg("删除失败！");
                }
            }

        }

        private void txtExamineeCompanyName_TextChanged(object sender, EventArgs e)
        {
            Check.CheckSpecialCharacters(this.txtExamineeCompanyName, "考生所属公司名称");
        }

        #endregion

        //private void txtExamineeCompanyName_TextChanged(object sender, EventArgs e)
        //{
        //    CheckBeforeAddExamineeCompanyInfo();
        //}
    }
}
