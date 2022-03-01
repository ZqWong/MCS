using Common;
using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MCS
{
    public partial class 考生信息添加界面 : Form
    {
        #region 全局变量
        /// <summary>
        /// 当前逻辑
        /// </summary>
        private string _CurrentLogic = "";

        ExamineeCompanyBLL _ExamineeCompanyBLL = new ExamineeCompanyBLL();
        ExamineeBLL _ExamineeBLL = new ExamineeBLL();

        //private ExamineeModel _Temp_ExamineeModel;

        // add by wuxin at 2018/6/2 - start
        private Thread _WatchingReadingCardThread = null;
        // add by wuxin at 2018/6/2 - end

        #endregion

        public 考生信息添加界面()
        {
            InitializeComponent();

            // 加载新ID
            LoadNewIDFromExamineeInfoTable();

            // del by wuxin at 2020/01/07 - start
            //// 加载公司信息
            //LoadExamineeCompanyInfo();
            // del by wuxin at 2020/01/07 - end
        }

        public 考生信息添加界面(string todoLogic, ExamineeModel em)
        {
            InitializeComponent();

            // 表示不对错误线程的调用进行捕获
            Control.CheckForIllegalCrossThreadCalls = false;

            if (todoLogic == "add")
            {
                this.Text = "考生添加界面";
                this.txtExamineeID.Enabled = false;
                this.lblTip.Visible = true;
                this.btnAddExamineeInfo.Text = "添 加";
                this.btnDelete.Visible = false;

                // 加载新ID
                LoadNewIDFromExamineeInfoTable();

                // del by wuxin at 2020/01/07 - start
                //// 加载公司信息
                //LoadExamineeCompanyInfo();
                // del by wuxin at 2020/01/07 - start

                // add by wuxin at 2018/6/2 - start
                // 身份证阅读器相关
                // 初始化端口
                bool result = IDCardReader.InitializePort();

                // 初始化成功
                if (result)
                {
                    _WatchingReadingCardThread = new Thread(new ThreadStart(ReadingCard));
                    _WatchingReadingCardThread.IsBackground = true;
                    _WatchingReadingCardThread.Name = "_WatchingReadingCardThread";
                    _WatchingReadingCardThread.Start();

                    LogHelper.WriteLog("服务器线程开启：监视身份证阅读器线程已开启。");
                }
                else
                {
                    Alert.errorMsg("身份证阅读器初始化失败！");
                    LogHelper.WriteErrorLog("身份证阅读器初始化失败！");
                }
                // add by wuxin at 2018/6/2 - end

            }
            else if (todoLogic == "upd")
            {
                this.Text = "考生修改界面";
                //this.txtExamineeID.Enabled = true; // 考生编号不可更改
                this.lblTip.Text = "(*)考生编号不可修改！";
                this.btnAddExamineeInfo.Text = "修 改";
                this.btnDelete.Visible = true;

                // add by wuxin at 2018/09/10 - start
                this.tagPage_Batch.Parent = null;
                // add by wuxin at 2018/09/10 - end

                //this.cbWriteCard.Checked = false;
                //this.cbWriteCard.Enabled = false;

                // del by wuxin at 2020/01/07 - start
                //// 加载公司信息
                //LoadExamineeCompanyInfo();
                // del by wuxin at 2020/01/07 - start

                // 设置考生信息
                SetExamineeInfo(em);
            }

            _CurrentLogic = todoLogic;
        }

        // add by wuxin at 2018/6/2 - start
        /// <summary>
        /// 读卡中……
        /// </summary>
        public void ReadingCard()
        {
            while (true)
            {
                // 读卡中
                ExamineeModel em = IDCardReader.ReadingCard();

                if (em != null)
                {
                    // 姓名
                    this.txtExamineeName.Text = em.ExamineeName;
                    // 身份证号码
                    this.txtIDCardNum.Text = em.IDCardNum;
                }

                Thread.Sleep(500);
            }
        }
        // add by wuxin at 2018/6/2 - end

        /// <summary>
        /// 加载新ID
        /// </summary>
        private void LoadNewIDFromExamineeInfoTable()
        {
            // upd by wuxin at 2018/5/30 - start
            //int count = _ExamineeBLL.GetNewIDFromExamineeInfoTable();
            //this.txtExamineeID.Text = count.ToString();

            // 在数据库中存在的最后一个ExamineeID
            int lastExamineeID = _ExamineeBLL.GetLastExamineeID();

            // 新ID
            int newExamineeID = lastExamineeID + 1;

            this.txtExamineeID.Text = newExamineeID.ToString();
            // upd by wuxin at 2018/5/30 - end
        }

        /// <summary>
        /// 设置考生信息
        /// </summary>
        /// <param name="em"></param>
        private void SetExamineeInfo(ExamineeModel em)
        {
            this.txtExamineeID.Text = em.ExamineeID;
            this.txtExamineeName.Text = em.ExamineeName;
            // add by wuxin at 2018/6/2 - start
            this.txtIDCardNum.Text = em.IDCardNum;
            // add by wuxin at 2018/6/2 - end

            // upd by wuxin at 2020/01/07 - start
            //this.cbExamineeCompany.SelectedValue = em.ExamineeCompanyID;

            // add by wuxin at 2020/1/8 - start
            this.lblClassType.Text = em.ClassType;
            // add by wuxin at 2020/1/8 - end

            string examineeCompanyID = em.ExamineeCompanyID;

            if (!String.IsNullOrEmpty(examineeCompanyID.Trim()))
            {
                this._examineeCompanyID = examineeCompanyID;
                this.txtExamineeCompanyName.Text = _ExamineeCompanyBLL.GetExamineeCompanyNameByExamineeCompanyID(examineeCompanyID);
            }

            // upd by wuxin at 2020/01/07 - end
        }

        // del by wuxin at 2020/01/07 - start
        ///// <summary>
        ///// 加载考生所属公司信息
        ///// </summary>
        //private void LoadExamineeCompanyInfo()
        //{
        //    //this.cbExamineeCompany.Items.Clear();

        //    //DataSet ds = _ExamineeCompanyBLL.GetAllExamineeCompany();

        //    //this.cbExamineeCompany.DataSource = ds.Tables[0];
        //    //cbExamineeCompany.DisplayMember = ExamineeCompanyModel.ColumnName_ExamineeCompanyName;
        //    //cbExamineeCompany.ValueMember = ExamineeCompanyModel.ColumnName_ExamineeCompanyID;

        //    //int count = ds.Tables[0].Rows.Count;

        //    //if (count > 0)
        //    //{
        //    //    for (int i = 0; i < count; i++)
        //    //    {
        //    //        int examineeCompanyID = (int)ds.Tables[0].Rows[i][ExamineeCompanyModel.ColumnName_ExamineeCompanyID];
        //    //        string examineeCompanyName = ds.Tables[0].Rows[i][ExamineeCompanyModel.ColumnName_ExamineeCompanyName].ToString();
        //    //    }
        //    //}
        //}
        // del by wuxin at 2020/01/07 - end

        #region 逻辑验证
        /// <summary>
        /// 添加考试子科目前验证
        /// </summary>
        /// <returns>true验证通过，false验证失败</returns>
        private bool CheckBeforeAddExamineeInfo()
        {
            bool checkResult = true;

            // 验证控件是否为空
            checkResult = Check.isEmpty(this.txtExamineeName, "考生姓名");

            if (!checkResult) return checkResult;

            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtExamineeName, "考生姓名");

            if (!checkResult) return checkResult;

            // add by wuxin at 2018/6/2 - start
            // 验证控件是否为空
            checkResult = Check.isEmpty(this.txtIDCardNum, "考生身份证号码");

            if (!checkResult) return checkResult;

            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtIDCardNum, "考生身份证号码");

            if (!checkResult) return checkResult;
            // add by wuxin at 2018/6/2 - end

            // add by wuxin at 2020/1/8 - start
            // 验证控件是否包含特殊字符
            checkResult = Check.CheckSpecialCharacters(this.txtClassType, "班别");
            if (!checkResult) return checkResult;
            // add by wuxin at 2020/1/8 - end

            return checkResult;
        }

        #endregion

        #region Button点击事件
        /// <summary>
        /// 添加考生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddExamineeInfo_Click(object sender, EventArgs e)
        {
            bool checkResult = CheckBeforeAddExamineeInfo();

            // 验证通过
            if (checkResult)
            {
                // 执行添加操作
                if (_CurrentLogic == "add")
                {
                    // del by wuxin at 2018/6/2 - start
                    //// 写卡
                    //if (this.cbWriteCard.Checked)
                    //{
                    //    bool result = ICCardWriterAndReader.Write(this.txtExamineeID.Text);

                    //    if (result)
                    //    {
                    //        Alert.noteMsg("IC卡写入成功！");
                    //    }
                    //    else
                    //    {
                    //        return;
                    //    }
                    //}
                    // del by wuxin at 2018/6/2 - end

                    ExamineeModel em = new ExamineeModel();
                    //em.ExamineeID = this.txtExamineeID.Text.Trim(); 自更新，不用设置
                    em.ExamineeName = this.txtExamineeName.Text.Trim();

                    // add by wuxin at 2018/6/2 - start
                    em.IDCardNum = this.txtIDCardNum.Text.Trim();
                    // add by wuxin at 2018/6/2 - end

                    // upd by wuxin at 2020/1/7 - start
                    //em.ExamineeCompanyID = this.cbExamineeCompany.SelectedValue.ToString();
                    em.ExamineeCompanyID = this._examineeCompanyID;
                    // upd by wuxin at 2020/1/7 - end

                    // add by wuxin at at 2020/1/8 - start
                    em.ClassType = this.lblClassType.Text;
                    // add by wuxin at 2020/1/8 - end

                    int count = _ExamineeBLL.AddExamineeInfo(em);

                    if (count > 0)
                    {
                        Alert.noteMsg("添加成功！");

                        考生信息管理界面 parentForm = (考生信息管理界面)this.Owner;

                        parentForm.ChildFormClose("add");

                        this.Close();
                    }
                    else
                    {
                        Alert.errorMsg("添加失败！");
                    }

                }
                // 执行修改操作
                else if (_CurrentLogic == "upd")
                {
                    // del by wuxin at 2018/6/2 - start
                    //// 写卡
                    //if (this.cbWriteCard.Checked)
                    //{
                    //    bool result = ICCardWriterAndReader.Write(this.txtExamineeID.Text);

                    //    if (result)
                    //    {
                    //        Alert.noteMsg("IC卡写入成功！");
                    //    }
                    //    else
                    //    {
                    //        return;
                    //    }
                    //}
                    // del by wuxin at 2018/6/2 - end

                    ExamineeModel em = new ExamineeModel();
                    em.ExamineeID = this.txtExamineeID.Text.Trim();
                    em.ExamineeName = this.txtExamineeName.Text.Trim();
                    // add by wuxin at 2018/6/2 - start
                    em.IDCardNum = this.txtIDCardNum.Text.Trim();
                    // add by wuxin at 2018/6/2 - end

                    // upd by wuxin at 2020/01/07 - start
                    //em.ExamineeCompanyID = this.cbExamineeCompany.SelectedValue.ToString();
                    em.ExamineeCompanyID = this._examineeCompanyID;
                    // upd by wuxin at 2020/01/07 - end

                    // add by wuxin at at 2020/1/8 - start
                    em.ClassType = this.lblClassType.Text;
                    // add by wuxin at 2020/1/8 - end

                    int count = _ExamineeBLL.UpdExamineeInfo(em);

                    if (count > 0)
                    {
                        Alert.noteMsg("修改成功！");

                        考生信息管理界面 parentForm = (考生信息管理界面)this.Owner;

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
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool choice = Alert.confirm("是否确认删除？");

            if (choice)
            {
                string examineeID = this.txtExamineeID.Text.Trim();

                int count = _ExamineeBLL.DelExamineeInfo(examineeID);

                if (count > 0)
                {
                    考生信息管理界面 parentForm = (考生信息管理界面)this.Owner;

                    Alert.noteMsg("删除成功！");

                    parentForm.ChildFormClose("del");

                    this.Close();
                }
                else
                {
                    Alert.errorMsg("删除失败！");
                }
            }
        }

        private void btnOpenExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择Excel文件...";
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Excel文件|*.xls;*.xlsx";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                this.txtFilePath.Text = fileName;
                //File fileOpen = new File(fName);
                //isFileHaveName = true;
                //richTextBox1.Text = fileOpen.ReadFile();
            }
        }
        #endregion

        //private void txtExamineeName_TextChanged(object sender, EventArgs e)
        //{
        //    CheckBeforeAddExamineeInfo();
        //}

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (this.txtFilePath.Text == "")
            {
                Alert.alert("请先选择Excel文件路径！");
            }
            else
            {
                ReadFromExcelFile(this.txtFilePath.Text);
            }
        }

        private List<ExamineeModel> _BatchAddExamineeList = new List<ExamineeModel>();

        /// <summary>
        /// 从指定路径的Excel读取数据
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadFromExcelFile(string filePath)
        {
            int importDataSuccessCount = 0;

            int importDataCount = 0;

            IWorkbook wk = null;
            string extension = System.IO.Path.GetExtension(filePath);
            try
            {
                FileStream fs = File.OpenRead(filePath);
                if (extension.Equals(".xls"))
                {
                    //把xls文件中的数据写入wk中
                    wk = new HSSFWorkbook(fs);
                }
                else
                {
                    //把xlsx文件中的数据写入wk中
                    wk = new XSSFWorkbook(fs);
                }

                fs.Close();
                //读取当前表数据
                ISheet sheet = wk.GetSheetAt(0);

                IRow row = sheet.GetRow(0);  //读取当前行数据
                                             //LastRowNum 是当前表的总行数-1（注意）

                importDataCount = sheet.LastRowNum + 1 - 5;

                this.progressBar1.Maximum = importDataCount;
                this.progressBar1.Value = 0;

                // 班别
                string classType = sheet.GetRow(3).GetCell(1).ToString();

                for (int i = 5; i <= sheet.LastRowNum; i++)
                {
                    row = sheet.GetRow(i);  //读取当前行数据
                    if (row != null)
                    {
                        // 考生名称
                        string examineeName = row.GetCell(0).ToString();
                        // 身份证号
                        string IDCardNum = row.GetCell(1).ToString();
                        // 公司
                        string examineeCompanyName = row.GetCell(2).ToString();

                        //MessageBox.Show(examineeName + "," + IDCardNum + "," + examineeCompanyName);

                        // 1、通过身份证号获取考生信息，确定该考生信息是否存在
                        DataSet ds = _ExamineeBLL.GetExamineeInfoByIDCardNum(IDCardNum);

                        bool isExist = Convert.ToBoolean(ds.Tables[0].Rows.Count);

                        // 1-2、如果身份证号已存在
                        if (isExist)
                        {
                            // 1-2-1、并且，公司名一样
                            if (examineeCompanyName == ds.Tables[0].Rows[0]["ExamineeCompanyName"].ToString())
                            {
                                //  + "考生信息已存在，是否放弃导入该条数据？", "考生信息确认", MessageBoxButtons.YesNo
                                Alert.noteMsg("姓名：" + examineeName + "\n" + "身份证号：" + IDCardNum + "\n" + "所属公司：" + examineeCompanyName + "\n" + " \n" + "考生信息异常：考生信息已存在！");
                            }
                            // 1-2-2、但，公司名不一样
                            else
                            {
                                // 确认是否继续导入
                                if (Alert.confirm("姓名：" + examineeName + "\n" + "身份证号：" + IDCardNum + "\n" + "所属公司：" + examineeCompanyName + "\n" + " \n" + "考生信息异常：考生姓名、身份证号与数据库一致，所属公司与数据库不一致，请确认是否继续导入该条数据？", "考生导入信息确认", MessageBoxButtons.YesNo))
                                {
                                    // 判断所属公司名称在数据中是否存在，如果存在，获取编号，如果不存在，先添加到数据库中，再获取编号
                                    string id = _ExamineeCompanyBLL.GetExamineeCompanyIDByExamineeCompanyName(examineeCompanyName);

                                    // 所属公司ID存在
                                    if (id != "")
                                    {
                                        ExamineeModel em = new ExamineeModel();
                                        em.ExamineeName = examineeName;
                                        em.IDCardNum = IDCardNum;

                                        em.ExamineeCompanyID = id;

                                        em.ClassType = classType;

                                        int count = _ExamineeBLL.AddExamineeInfo(em);

                                        if (count > 0)
                                        {
                                            importDataSuccessCount++;
                                        }
                                    }
                                    // 所属公司ID不存在
                                    else
                                    {
                                        // 添加新所属公司，并获取编号
                                        ExamineeCompanyModel ecm = new ExamineeCompanyModel();
                                        ecm.ExamineeCompanyName = examineeCompanyName;

                                        _ExamineeCompanyBLL.AddExamineeCompanyInfo(ecm);

                                        id = _ExamineeCompanyBLL.GetExamineeCompanyIDByExamineeCompanyName(examineeCompanyName);

                                        // 考生信息录入
                                        ExamineeModel em = new ExamineeModel();
                                        em.ExamineeName = examineeName;
                                        em.IDCardNum = IDCardNum;

                                        em.ExamineeCompanyID = id;

                                        em.ClassType = classType;

                                        int count = _ExamineeBLL.AddExamineeInfo(em);

                                        if (count > 0)
                                        {
                                            importDataSuccessCount++;
                                        }

                                    }
                                }
                                // 放弃导入
                                else
                                {
                                    break;
                                }
                            }
                        }
                        // 1-2、如果身份证号不存在
                        else
                        {

                        }

                        //Alert.noteMsg("导入成功！");

                        //ExamineeModel em = new ExamineeModel();
                        //em.ExamineeName = row.GetCell(0).ToString();
                        //em.IDCardNum = row.GetCell(1).ToString();
                        //string examineeCompanyName = row.GetCell(2).ToString();

                        //string examineeCompanyID = _ExamineeCompanyBLL.GetExamineeCompanyIDByExamineeCompanyName(examineeCompanyName);
                        //em.ExamineeCompanyID = examineeCompanyID;

                        //_BatchAddExamineeList.Add(em);

                        //LastCellNum 是当前行的总列数
                        //for (int j = 0; j < row.LastCellNum; j++)
                        //{
                        //    //读取该行的第j列数据
                        //    string value = row.GetCell(j).ToString();
                        //    //Console.Write(value.ToString() + " ");
                        //}
                        //Console.WriteLine("\n");
                    }

                    if (this.progressBar1.Value <= this.progressBar1.Maximum)
                    {
                        this.progressBar1.Value++;
                    }

                }

                this.progressBar1.Value = this.progressBar1.Maximum;

                Alert.noteMsg("导入成功！");

                考生信息管理界面 parentForm = (考生信息管理界面)this.Owner;
                parentForm.ChildFormClose("");

                // 关闭窗口
                this.Close();
            }
            catch (Exception e)
            {
                LogHelper.WriteErrorLog("批量导入考生信息出错！");
                LogHelper.WriteErrorLog("错误信息：" + e.ToString());

                // add by wuxin at 2020/1/18 - start
                Alert.errorMsg("批量导入考生信息出错！错误信息:" + e.ToString());
                // add by wuxin at 2020/1/18 - end

            }
        }
        // add by wuxin at 2018/6/2 - start
        // add by wuxin at 2018/6/2 - start
        private void 考生信息添加界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_WatchingReadingCardThread != null)
            {
                _WatchingReadingCardThread.Abort();

                LogHelper.WriteLog("服务器线程关闭：监视身份证阅读器线程已关闭。");

                // 关闭端口
                IDCardReader.ClosePort();
            }
        }

        // add by wuxin at 2018/6/2 - end

        // add by wuxin at 2018/09/10 - start
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.tabControl1.SelectedIndex.ToString());

            if (this.tabControl1.SelectedIndex == 0)
            {
                this.btnAddExamineeInfo.Visible = true;
                this.btnClose.Visible = true;
            }
            else if (this.tabControl1.SelectedIndex == 1)
            {
                this.btnAddExamineeInfo.Visible = false;
                this.btnClose.Visible = false;
            }
        }

        // add by wuxin at 2018/09/10 - end

        // add by wuxin at 2020/01/07 - start
        /// <summary>
        /// 选择考生所属公司
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoiceExamineeCompanyName_Click(object sender, EventArgs e)
        {
            选择考生所属公司界面 form = new 选择考生所属公司界面();
            form.ShowDialog(this);
        }

        // 存储考生所在公司编号
        private string _examineeCompanyID;

        /// <summary>
        /// 考生所属公司选择完成
        /// </summary>
        /// <param name="ecm"></param>
        public void ChildFormClose(ExamineeCompanyModel ecm)
        {
            _examineeCompanyID = ecm.ExamineeCompanyID;
            this.txtExamineeCompanyName.Text = ecm.ExamineeCompanyName;
        }

        private void txtClassType_TextChanged(object sender, EventArgs e)
        {
            if (Check.CheckSpecialCharacters(this.txtClassType, "班别"))
            {
                if (!string.IsNullOrEmpty(this.txtClassType.Text.Trim()))
                {
                    string temp = "";

                    if (LibUtilities.IsNumeric(this.txtClassType.Text))
                    {
                        temp = LibUtilities.NumberToChinese(Convert.ToInt32(this.txtClassType.Text.Trim())) + "期";
                    }
                    else
                    {
                        temp = this.txtClassType.Text;
                    }

                    this.lblClassType.Text = temp;
                }
                else
                {
                    this.lblClassType.Text = "";
                }
            }
        }

        private void txtExamineeName_TextChanged(object sender, EventArgs e)
        {
            Check.CheckSpecialCharacters(this.txtExamineeName, "考生姓名");
        }

        private void txtIDCardNum_TextChanged(object sender, EventArgs e)
        {
            Check.CheckSpecialCharacters(this.txtIDCardNum, "考生身份证号码");
        }

        // add by wuxin at 2020/01/07 - end
    }
}
