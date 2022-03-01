using Common.Model;
using MCS.Common;
using MCS.DB.BLL;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MCS
{
    public partial class 考试成绩详情 : Form
    {
        ExaminationSubjectBLL _ExaminationSubjectBLL = new ExaminationSubjectBLL();

        ExaminationResultDetailBLL _ExaminationResultDetailBLL = new ExaminationResultDetailBLL();

        ArrayList _ExaminationSubjectList = new ArrayList();

        private string _ExaminationResultID = "";

        ExaminationResultModel _ExaminationResultModel = new ExaminationResultModel();

        public 考试成绩详情()
        {
            InitializeComponent();
        }

        public 考试成绩详情(ExaminationResultModel examinationResultModel)
        {
            InitializeComponent();

            _ExaminationResultModel = examinationResultModel;

            ExaminationSubjectModel defaultEsm = new ExaminationSubjectModel();
            defaultEsm.ExaminationSubjectID = "*";
            defaultEsm.ExaminationSubjectShortName = "全部";

            _ExaminationSubjectList.Add(defaultEsm);

            // 加载考试结果信息
            LoadExaminationResultInfo(examinationResultModel);

            // 考试科目下拉框赋值
            SetExaminationSubjectValue();

            // 加载考试结果详情信息
            LoadExaminationResultDetailInfo();
        }

        /// <summary>
        /// 加载考试结果信息
        /// </summary>
        /// <param name="examinationResultModel"></param>
        private void LoadExaminationResultInfo(ExaminationResultModel examinationResultModel)
        {
            // 考试结果编号
            _ExaminationResultID = examinationResultModel.ExaminationResultID;

            // 考生编号
            this.txtExamineeID.Text = examinationResultModel.ExamineeID;
            // 考生姓名
            this.txtExamineeName.Text = examinationResultModel.ExamineeName;

            // add by wuxin at 2020/1/18 - start
            // 身份证号
            this.txtIDCardNum.Text = examinationResultModel.IDCardNum;
            // add by wuxin at 2020/1/18 - end

            // 所属公司
            this.txtExamineeCompany.Text = examinationResultModel.ExamineeCompanyName;
            // add by wuxin at 2020/1/8 - start
            // 班别
            this.txtClassType.Text = examinationResultModel.ClassType;
            // add by wuxin at 2020/1/8 - end
            // 考试名称
            this.txtExaminationName.Text = examinationResultModel.ExaminationName;
            // 考试日期
            this.txtExaminationDate.Text = examinationResultModel.ExaminationDate;

            // 得分
            // 100 = 50(K1) + 50(K2)
            string strFinalScore2 = examinationResultModel.FinalScore2;

            // 根据考试科目编号获取考试科目名称
            string strExaminationSubjectIDs = examinationResultModel.ExaminationSubjectIDs;// 1,2

            string[] examinationSubjectIDs = strExaminationSubjectIDs.Split(',');

            string[] examinationSubjectNames = new string[2];

            for (int n = 0; n < examinationSubjectIDs.Length; n++)
            {
                examinationSubjectNames[n] = _ExaminationSubjectBLL.GetExaminationSubjectShortNameByExamineeSubjectID(examinationSubjectIDs[n]);

                ExaminationSubjectModel examinationSubjectModel = new ExaminationSubjectModel();
                examinationSubjectModel.ExaminationSubjectID = examinationSubjectIDs[n];
                examinationSubjectModel.ExaminationSubjectShortName = examinationSubjectNames[n];

                _ExaminationSubjectList.Add(examinationSubjectModel);
            }

            // 拆开显示分数
            string strFinalScore = examinationResultModel.FinalScore;// 10+30

            string[] finalScores = strFinalScore.Split('+');


            if (finalScores.Length == examinationSubjectNames.Length)
            {
                string txtFinalScoreText = strFinalScore2 + " = " + finalScores[0] + "分" + "(" + examinationSubjectNames[0] + ")" + " + " + finalScores[1] + "分" + "(" + examinationSubjectNames[1] + ")";


                this.txtFinalScore.Text = txtFinalScoreText;
            }

            // 考试结果
            string strExaminationResult = examinationResultModel.ExaminationResult;

            if (strExaminationResult == Const.ExaminationResult_Yes)
            {
                this.txtExaminationResult.ForeColor = Color.Green;
            }
            else
            {
                this.txtExaminationResult.ForeColor = Color.Red;
            }

            this.txtExaminationResult.Text = strExaminationResult;
        }

        /// <summary>
        /// 考试科目下拉框赋值
        /// </summary>
        private void SetExaminationSubjectValue()
        {
            this.cbExaminationSubject.Items.Clear();

            if (_ExaminationSubjectList.Count > 0)
            {
                this.cbExaminationSubject.DataSource = _ExaminationSubjectList;
                this.cbExaminationSubject.DisplayMember = ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName;
                this.cbExaminationSubject.ValueMember = ExaminationSubjectModel.ColumnName_ExaminationSubjectID;

                //注册TextChanged事件  
                cbExaminationSubject.TextChanged += new EventHandler(Combo_TextChanged);
            }
        }

        private void Combo_TextChanged(object sender, EventArgs e)
        {
            // 加载考试结果详情信息
            LoadExaminationResultDetailInfo();
        }

        /// <summary>
        /// 加载考试结果详情信息
        /// </summary>
        private void LoadExaminationResultDetailInfo()
        {
            // 考试科目编号
            string strExaminationSubjectID = this.cbExaminationSubject.SelectedValue.ToString();

            DataSet ds;

            if (strExaminationSubjectID == "*")
            {
                ds = _ExaminationResultDetailBLL.GetExamResultDetailByExamResultID(_ExaminationResultID);
            }
            else
            {
                ds = _ExaminationResultDetailBLL.GetExamResultDetailByExamResultIDAndExamSubjectID(_ExaminationResultID, strExaminationSubjectID);
            }

            int count = ds.Tables[0].Rows.Count;

            this.dgvExaminationResultDetailInfo.Rows.Clear();

            if (count > 0)
            {
                this.dgvExaminationResultDetailInfo.Rows.Add(count);

                for (int i = 0; i < count; i++)
                {
                    this.dgvExaminationResultDetailInfo.Rows[i].Cells[ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName].Value = ds.Tables[0].Rows[i][ExaminationSubjectModel.ColumnName_ExaminationSubjectShortName].ToString();

                    this.dgvExaminationResultDetailInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_No].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_No].ToString();

                    this.dgvExaminationResultDetailInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExaminationItem].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationItem].ToString();

                    this.dgvExaminationResultDetailInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExaminationContentAndStep_Title].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationContentAndStep_Title].ToString();

                    this.dgvExaminationResultDetailInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ExaminationContentAndStep_Detail].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ExaminationContentAndStep_Detail].ToString();

                    //this.dgvExaminationResultDetailInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_ScoreValue].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_ScoreValue].ToString() + "分";

                    //this.dgvExaminationResultDetailInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_EvaluationStandard].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_EvaluationStandard].ToString();

                    this.dgvExaminationResultDetailInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_DeductionCondition].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_DeductionCondition].ToString();

                    //this.dgvExaminationResultDetailInfo.Rows[i].Cells[ExaminationResultModel.ColumnName_DeductionReason].Value = ds.Tables[0].Rows[i][ExaminationResultModel.ColumnName_DeductionReason].ToString();

                    if (i % 2 != 0)
                    {
                        this.dgvExaminationResultDetailInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    }
                    else
                    {
                        this.dgvExaminationResultDetailInfo.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCyan;
                    }
                }
            }

            //MessageBox.Show(count.ToString());
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

        private void cbExaminationSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvExaminationResultDetailInfo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.dgvExaminationResultDetailInfo.Rows[e.RowIndex].Cells[ExaminationResultModel.ColumnName_DeductionCondition].Style.ForeColor = Color.Red;
            }
        }

        private void btnExport2Excel_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.Description = "请选择保存路径";

            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                string strExcelSaveFolderPath = this.folderBrowserDialog1.SelectedPath;

                string strExcelTemplatePath = Const.ExcelTemplatePath; // ……/ExelTemplate.xlsx0

                string strNowDateFolder = strExcelSaveFolderPath + "/" + _ExaminationResultModel.ExamineeName + "_" + "考试成绩导出" + DateTime.Now.Date.ToString(Const.DATE_FORMART_YYYYMMDD);

                string strNewFilePath = "";

                // 1.在Excels文件夹下创建当天日期的文件夹（如果存在，不创建）
                if (!Directory.Exists(strNowDateFolder))
                {
                    Directory.CreateDirectory(strNowDateFolder);
                }

                // 2.复制Excel模板到当天日期的文件夹下，并修改文件名，文件名格式 考生编号_考生姓名_日期（20180520）.xlsx（如果存在先删除再复制）
                try
                {
                    strNewFilePath = strNowDateFolder + "/" + _ExaminationResultModel.ExamineeName + "_" + "考试成绩导出" + "_" + DateTime.Now.ToString(Const.DATE_FORMART_yyyy_MM_dd_HH_mm_ss) + ".xlsx";//.xls

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

                        // 序号
                        sheet.CreateRow(4).CreateCell(0).SetCellValue(1);

                        // 姓名
                        sheet.GetRow(4).CreateCell(1).SetCellValue(_ExaminationResultModel.ExamineeName);

                        // 身份证号
                        sheet.GetRow(4).CreateCell(2).SetCellValue(_ExaminationResultModel.IDCardNum);

                        // 单位
                        sheet.GetRow(4).CreateCell(3).SetCellValue(_ExaminationResultModel.ExamineeCompanyName);

                        // 班别
                        sheet.GetRow(4).CreateCell(4).SetCellValue(_ExaminationResultModel.ClassType);

                        // 考试名称
                        sheet.GetRow(4).CreateCell(5).SetCellValue(_ExaminationResultModel.ExaminationName);

                        // 考试日期
                        sheet.GetRow(4).CreateCell(6).SetCellValue(_ExaminationResultModel.ExaminationDate);

                        // 成绩
                        sheet.GetRow(4).CreateCell(7).SetCellValue(_ExaminationResultModel.FinalScore2);

                        // 考试结果
                        string strExaminationResult = _ExaminationResultModel.ExaminationResult;
                        sheet.GetRow(4).CreateCell(8).SetCellValue(strExaminationResult);

                        // 加外边框
                        AddRengionBorder(wk, sheet, 4, 5, 0, 9);

                        using (FileStream fileStream = File.Open(strNewFilePath, FileMode.Create, FileAccess.Write))
                        {
                            wk.Write(fileStream);
                            fileStream.Close();
                        }


                        Alert.noteMsg("导出成功！");

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
            }
        }
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

        // del by wuxin at 2020/1/18 - start
        //// upd by wuxin at 2019/12/02 - start
        //this.folderBrowserDialog1.Description = "请选择保存路径";

        //if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //{
        //    string strExcelSaveFolderPath = this.folderBrowserDialog1.SelectedPath;

        //    this.ExcelExportProgressBar.Visible = true;

        //    string strExcelTemplatePath = Const.ExcelTemplatePath; // ……/ExelTemplate.xlsx

        //    //string strExcelSaveFolderPath = Const.ExcelSaveFolderPath; // ……/Excels/

        //    string strNowDateFolder = strExcelSaveFolderPath + "/" + DateTime.Now.Date.ToString(Const.DATE_FORMART_YYYYMMDD);

        //    string strNewFilePath = "";

        //    // 1.在Excels文件夹下创建当天日期的文件夹（如果存在，不创建）
        //    if (!Directory.Exists(strNowDateFolder))
        //    {
        //        Directory.CreateDirectory(strNowDateFolder);
        //    }

        //    // 2.复制Excel模板到当天日期的文件夹下，并修改文件名，文件名格式 考生编号_考生姓名_日期（20180520）.xlsx（如果存在先删除再复制）
        //    try
        //    {
        //        strNewFilePath = strNowDateFolder + "/" + _ExaminationResultID + "_" + this.txtExamineeID.Text + "_" + this.txtExamineeName.Text + "_" + DateTime.Now.Date.ToString(Const.DATE_FORMART_YYYYMMDD) + ".xlsx"; //xls

        //        if (File.Exists(strNewFilePath))
        //        {
        //            File.Delete(strNewFilePath);
        //        }

        //        File.Copy(strExcelTemplatePath, strNewFilePath, true);
        //    }

        //    catch (Exception ex)
        //    {
        //        LogHelper.WriteErrorLog("复制ExcelTemplate.xls出错！");
        //        LogHelper.WriteErrorLog("错误信息：" + ex.ToString());
        //    }


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

        //            this.ExcelExportProgressBar.Maximum = 8;
        //            this.ExcelExportProgressBar.Value = 0;

        //            // 成绩单
        //            sheet.GetRow(1).GetCell(1).SetCellValue("成绩单");
        //            this.ExcelExportProgressBar.Value++;
        //            // 考生编号
        //            sheet.GetRow(2).GetCell(2).SetCellValue(this.txtExamineeID.Text.Trim());
        //            this.ExcelExportProgressBar.Value++;
        //            // 考生姓名
        //            sheet.GetRow(2).GetCell(4).SetCellValue(this.txtExamineeName.Text.Trim());
        //            this.ExcelExportProgressBar.Value++;
        //            // 所属公司
        //            sheet.GetRow(2).GetCell(6).SetCellValue(this.txtExamineeCompany.Text.Trim());
        //            this.ExcelExportProgressBar.Value++;
        //            // 考试名称
        //            sheet.GetRow(3).GetCell(2).SetCellValue(this.txtExaminationName.Text.Trim());
        //            this.ExcelExportProgressBar.Value++;
        //            // 考试日期
        //            sheet.GetRow(4).GetCell(2).SetCellValue(this.txtExaminationDate.Text.Trim());
        //            this.ExcelExportProgressBar.Value++;
        //            // 得分
        //            sheet.GetRow(5).GetCell(2).SetCellValue(this.txtFinalScore.Text.Trim());
        //            this.ExcelExportProgressBar.Value++;
        //            // 考试结果
        //            sheet.GetRow(6).GetCell(2).SetCellValue(this.txtExaminationResult.Text.Trim());

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

        //            this.ExcelExportProgressBar.Value++;

        //            using (FileStream fileStream = File.Open(strNewFilePath, FileMode.Create, FileAccess.Write))
        //            {
        //                wk.Write(fileStream);
        //                fileStream.Close();
        //            }

        //            Alert.noteMsg("导出成功！");
        //            this.ExcelExportProgressBar.Visible = false;

        //        }
        //        catch (Exception ex)
        //        {
        //            returnb = false;
        //            //throw;
        //            LogHelper.WriteErrorLog("导出成绩单出错！");
        //            LogHelper.WriteErrorLog("错误信息：" + ex.ToString());
        //        }

        //    }
        //}
        //// upd by wuxin at 2019/12/02 - end
        // del by wuxin at 2020/1/18 - end
    }

}

/*
 * //1.读取Excel到FileStream
            using (FileStream fs = File.OpenRead("MyExcel.xls"))
            {
                //2.根据文件流fs,创建一个Workbook
                IWorkbook wk = new HSSFWorkbook(fs);

                //循环获取工作表的个数
                //wk.NumberOfSheets获取当前“工作薄”中的工作表的个数
                for (int i = 0; i < wk.NumberOfSheets; i++)
                {
                    //循环获取每一个工作表
                    ISheet sheet = wk.GetSheetAt(i);

                    Console.WriteLine("========================={0}======================", sheet.SheetName);

                    //循环获取当前“工作表”中的每一行。
                    //sheet.LastRowNum【获取最后一行的索引】
                    prg.Maximum = sheet.LastRowNum;
                    prg.Value = 0;
                    for (int r = 0; r <= sheet.LastRowNum; r++)
                    {
                        //获取每一行
                        IRow row = sheet.GetRow(r);

                        //获取行中的单元格
                        //row.LastCellNum获取最后一个单元格的索引
                        for (int c = 0; c < row.LastCellNum; c++)
                        {
                            //获取每行中的每个单元格。
                            ICell cell = row.GetCell(c);
                            //Console.Write(cell.ToString() + "\t");        //打印到屏幕上的时候会导致速度很慢，可考虑在此处进行优化
                        }
                        Console.WriteLine();
                        if (prg.Value < prg.Maximum)
                        {
                            prg.Value++;
                        }
                    }
                    prg.Value = prg.Maximum;
                }
                MessageBox.Show("读取Excel成功");
            }

    */
