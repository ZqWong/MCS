namespace MCS
{
    partial class 考试成绩详情
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(考试成绩详情));
            this.gbSelectReault = new System.Windows.Forms.GroupBox();
            this.dgvExaminationResultDetailInfo = new System.Windows.Forms.DataGridView();
            this.ExaminationSubjectShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationContentAndStep_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationContentAndStep_Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeductionCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSelectCondition = new System.Windows.Forms.GroupBox();
            this.txtClassType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ExcelExportProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnExport2Excel = new System.Windows.Forms.Button();
            this.txtExaminationResult = new System.Windows.Forms.Label();
            this.lblExaminationResult = new System.Windows.Forms.Label();
            this.txtFinalScore = new System.Windows.Forms.Label();
            this.lblFinalScore = new System.Windows.Forms.Label();
            this.txtExaminationDate = new System.Windows.Forms.Label();
            this.txtExaminationName = new System.Windows.Forms.Label();
            this.txtExamineeCompany = new System.Windows.Forms.Label();
            this.txtExamineeName = new System.Windows.Forms.Label();
            this.txtExamineeID = new System.Windows.Forms.Label();
            this.lblExaminationDate = new System.Windows.Forms.Label();
            this.lblExaminationName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblExamineeCompany = new System.Windows.Forms.Label();
            this.lblExamineeName = new System.Windows.Forms.Label();
            this.lblExamineeID = new System.Windows.Forms.Label();
            this.cbExaminationSubject = new System.Windows.Forms.ComboBox();
            this.lblExaminationSubject = new System.Windows.Forms.Label();
            this.pageControl2 = new MCS.PageControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDCardNum = new System.Windows.Forms.Label();
            this.gbSelectReault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationResultDetailInfo)).BeginInit();
            this.gbSelectCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelectReault
            // 
            this.gbSelectReault.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectReault.Controls.Add(this.dgvExaminationResultDetailInfo);
            this.gbSelectReault.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSelectReault.Location = new System.Drawing.Point(14, 216);
            this.gbSelectReault.Name = "gbSelectReault";
            this.gbSelectReault.Size = new System.Drawing.Size(1056, 500);
            this.gbSelectReault.TabIndex = 10;
            this.gbSelectReault.TabStop = false;
            this.gbSelectReault.Text = "考试科目成绩扣分详情";
            // 
            // dgvExaminationResultDetailInfo
            // 
            this.dgvExaminationResultDetailInfo.AllowUserToAddRows = false;
            this.dgvExaminationResultDetailInfo.AllowUserToDeleteRows = false;
            this.dgvExaminationResultDetailInfo.AllowUserToResizeColumns = false;
            this.dgvExaminationResultDetailInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExaminationResultDetailInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExaminationResultDetailInfo.ColumnHeadersHeight = 32;
            this.dgvExaminationResultDetailInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExaminationResultDetailInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExaminationSubjectShortName,
            this.No,
            this.ExaminationItem,
            this.ExaminationContentAndStep_Title,
            this.ExaminationContentAndStep_Detail,
            this.DeductionCondition});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExaminationResultDetailInfo.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvExaminationResultDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExaminationResultDetailInfo.Location = new System.Drawing.Point(3, 21);
            this.dgvExaminationResultDetailInfo.Name = "dgvExaminationResultDetailInfo";
            this.dgvExaminationResultDetailInfo.RowHeadersVisible = false;
            this.dgvExaminationResultDetailInfo.RowHeadersWidth = 40;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dgvExaminationResultDetailInfo.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvExaminationResultDetailInfo.RowTemplate.Height = 35;
            this.dgvExaminationResultDetailInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExaminationResultDetailInfo.Size = new System.Drawing.Size(1050, 476);
            this.dgvExaminationResultDetailInfo.TabIndex = 0;
            this.dgvExaminationResultDetailInfo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvExaminationResultDetailInfo_CellPainting);
            // 
            // ExaminationSubjectShortName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExaminationSubjectShortName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExaminationSubjectShortName.HeaderText = "考试科目";
            this.ExaminationSubjectShortName.MinimumWidth = 100;
            this.ExaminationSubjectShortName.Name = "ExaminationSubjectShortName";
            this.ExaminationSubjectShortName.ReadOnly = true;
            this.ExaminationSubjectShortName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationSubjectShortName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // No
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.No.DefaultCellStyle = dataGridViewCellStyle3;
            this.No.HeaderText = "序号";
            this.No.MinimumWidth = 50;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 50;
            // 
            // ExaminationItem
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExaminationItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.ExaminationItem.HeaderText = "考试项目";
            this.ExaminationItem.MinimumWidth = 150;
            this.ExaminationItem.Name = "ExaminationItem";
            this.ExaminationItem.ReadOnly = true;
            this.ExaminationItem.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationItem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExaminationItem.Width = 150;
            // 
            // ExaminationContentAndStep_Title
            // 
            this.ExaminationContentAndStep_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ExaminationContentAndStep_Title.DefaultCellStyle = dataGridViewCellStyle5;
            this.ExaminationContentAndStep_Title.HeaderText = "考试内容与步骤(题目)";
            this.ExaminationContentAndStep_Title.MinimumWidth = 200;
            this.ExaminationContentAndStep_Title.Name = "ExaminationContentAndStep_Title";
            this.ExaminationContentAndStep_Title.ReadOnly = true;
            this.ExaminationContentAndStep_Title.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationContentAndStep_Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExaminationContentAndStep_Detail
            // 
            this.ExaminationContentAndStep_Detail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ExaminationContentAndStep_Detail.DefaultCellStyle = dataGridViewCellStyle6;
            this.ExaminationContentAndStep_Detail.HeaderText = "考试内容与步骤(项目)";
            this.ExaminationContentAndStep_Detail.MinimumWidth = 300;
            this.ExaminationContentAndStep_Detail.Name = "ExaminationContentAndStep_Detail";
            this.ExaminationContentAndStep_Detail.ReadOnly = true;
            this.ExaminationContentAndStep_Detail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationContentAndStep_Detail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DeductionCondition
            // 
            this.DeductionCondition.HeaderText = "扣分情况";
            this.DeductionCondition.MinimumWidth = 100;
            this.DeductionCondition.Name = "DeductionCondition";
            this.DeductionCondition.ReadOnly = true;
            this.DeductionCondition.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeductionCondition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gbSelectCondition
            // 
            this.gbSelectCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectCondition.Controls.Add(this.txtIDCardNum);
            this.gbSelectCondition.Controls.Add(this.label2);
            this.gbSelectCondition.Controls.Add(this.txtClassType);
            this.gbSelectCondition.Controls.Add(this.label1);
            this.gbSelectCondition.Controls.Add(this.ExcelExportProgressBar);
            this.gbSelectCondition.Controls.Add(this.txtExaminationResult);
            this.gbSelectCondition.Controls.Add(this.lblExaminationResult);
            this.gbSelectCondition.Controls.Add(this.txtFinalScore);
            this.gbSelectCondition.Controls.Add(this.lblFinalScore);
            this.gbSelectCondition.Controls.Add(this.txtExaminationDate);
            this.gbSelectCondition.Controls.Add(this.txtExaminationName);
            this.gbSelectCondition.Controls.Add(this.txtExamineeCompany);
            this.gbSelectCondition.Controls.Add(this.txtExamineeName);
            this.gbSelectCondition.Controls.Add(this.txtExamineeID);
            this.gbSelectCondition.Controls.Add(this.lblExaminationDate);
            this.gbSelectCondition.Controls.Add(this.lblExaminationName);
            this.gbSelectCondition.Controls.Add(this.lblExamineeCompany);
            this.gbSelectCondition.Controls.Add(this.lblExamineeName);
            this.gbSelectCondition.Controls.Add(this.lblExamineeID);
            this.gbSelectCondition.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSelectCondition.Location = new System.Drawing.Point(14, 12);
            this.gbSelectCondition.Name = "gbSelectCondition";
            this.gbSelectCondition.Size = new System.Drawing.Size(1056, 138);
            this.gbSelectCondition.TabIndex = 8;
            this.gbSelectCondition.TabStop = false;
            this.gbSelectCondition.Text = "成绩单";
            // 
            // txtClassType
            // 
            this.txtClassType.AutoSize = true;
            this.txtClassType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClassType.Location = new System.Drawing.Point(940, 34);
            this.txtClassType.Name = "txtClassType";
            this.txtClassType.Size = new System.Drawing.Size(50, 21);
            this.txtClassType.TabIndex = 22;
            this.txtClassType.Text = "        ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(889, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "班别：";
            // 
            // ExcelExportProgressBar
            // 
            this.ExcelExportProgressBar.Location = new System.Drawing.Point(1171, 81);
            this.ExcelExportProgressBar.Name = "ExcelExportProgressBar";
            this.ExcelExportProgressBar.Size = new System.Drawing.Size(366, 30);
            this.ExcelExportProgressBar.TabIndex = 19;
            this.ExcelExportProgressBar.Visible = false;
            // 
            // btnExport2Excel
            // 
            this.btnExport2Excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport2Excel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport2Excel.Location = new System.Drawing.Point(861, 171);
            this.btnExport2Excel.Name = "btnExport2Excel";
            this.btnExport2Excel.Size = new System.Drawing.Size(100, 30);
            this.btnExport2Excel.TabIndex = 20;
            this.btnExport2Excel.Text = "导出";
            this.btnExport2Excel.UseVisualStyleBackColor = true;
            this.btnExport2Excel.Click += new System.EventHandler(this.btnExport2Excel_Click);
            // 
            // txtExaminationResult
            // 
            this.txtExaminationResult.AutoSize = true;
            this.txtExaminationResult.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExaminationResult.Location = new System.Drawing.Point(640, 105);
            this.txtExaminationResult.Name = "txtExaminationResult";
            this.txtExaminationResult.Size = new System.Drawing.Size(50, 21);
            this.txtExaminationResult.TabIndex = 19;
            this.txtExaminationResult.Text = "        ";
            // 
            // lblExaminationResult
            // 
            this.lblExaminationResult.AutoSize = true;
            this.lblExaminationResult.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationResult.Location = new System.Drawing.Point(560, 105);
            this.lblExaminationResult.Name = "lblExaminationResult";
            this.lblExaminationResult.Size = new System.Drawing.Size(90, 21);
            this.lblExaminationResult.TabIndex = 18;
            this.lblExaminationResult.Text = "考试结果：";
            // 
            // txtFinalScore
            // 
            this.txtFinalScore.AutoSize = true;
            this.txtFinalScore.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFinalScore.Location = new System.Drawing.Point(95, 105);
            this.txtFinalScore.Name = "txtFinalScore";
            this.txtFinalScore.Size = new System.Drawing.Size(50, 21);
            this.txtFinalScore.TabIndex = 17;
            this.txtFinalScore.Text = "        ";
            // 
            // lblFinalScore
            // 
            this.lblFinalScore.AutoSize = true;
            this.lblFinalScore.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFinalScore.Location = new System.Drawing.Point(15, 105);
            this.lblFinalScore.Name = "lblFinalScore";
            this.lblFinalScore.Size = new System.Drawing.Size(88, 21);
            this.lblFinalScore.TabIndex = 16;
            this.lblFinalScore.Text = "得      分：";
            // 
            // txtExaminationDate
            // 
            this.txtExaminationDate.AutoSize = true;
            this.txtExaminationDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExaminationDate.Location = new System.Drawing.Point(640, 69);
            this.txtExaminationDate.Name = "txtExaminationDate";
            this.txtExaminationDate.Size = new System.Drawing.Size(50, 21);
            this.txtExaminationDate.TabIndex = 15;
            this.txtExaminationDate.Text = "        ";
            // 
            // txtExaminationName
            // 
            this.txtExaminationName.AutoSize = true;
            this.txtExaminationName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExaminationName.Location = new System.Drawing.Point(95, 69);
            this.txtExaminationName.Name = "txtExaminationName";
            this.txtExaminationName.Size = new System.Drawing.Size(50, 21);
            this.txtExaminationName.TabIndex = 14;
            this.txtExaminationName.Text = "        ";
            // 
            // txtExamineeCompany
            // 
            this.txtExamineeCompany.AutoSize = true;
            this.txtExamineeCompany.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeCompany.Location = new System.Drawing.Point(640, 34);
            this.txtExamineeCompany.Name = "txtExamineeCompany";
            this.txtExamineeCompany.Size = new System.Drawing.Size(50, 21);
            this.txtExamineeCompany.TabIndex = 13;
            this.txtExamineeCompany.Text = "        ";
            // 
            // txtExamineeName
            // 
            this.txtExamineeName.AutoSize = true;
            this.txtExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeName.Location = new System.Drawing.Point(228, 34);
            this.txtExamineeName.Name = "txtExamineeName";
            this.txtExamineeName.Size = new System.Drawing.Size(50, 21);
            this.txtExamineeName.TabIndex = 12;
            this.txtExamineeName.Text = "        ";
            // 
            // txtExamineeID
            // 
            this.txtExamineeID.AutoSize = true;
            this.txtExamineeID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeID.Location = new System.Drawing.Point(95, 33);
            this.txtExamineeID.Name = "txtExamineeID";
            this.txtExamineeID.Size = new System.Drawing.Size(50, 21);
            this.txtExamineeID.TabIndex = 11;
            this.txtExamineeID.Text = "        ";
            // 
            // lblExaminationDate
            // 
            this.lblExaminationDate.AutoSize = true;
            this.lblExaminationDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationDate.Location = new System.Drawing.Point(560, 69);
            this.lblExaminationDate.Name = "lblExaminationDate";
            this.lblExaminationDate.Size = new System.Drawing.Size(90, 21);
            this.lblExaminationDate.TabIndex = 10;
            this.lblExaminationDate.Text = "考试日期：";
            // 
            // lblExaminationName
            // 
            this.lblExaminationName.AutoSize = true;
            this.lblExaminationName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationName.Location = new System.Drawing.Point(15, 69);
            this.lblExaminationName.Name = "lblExaminationName";
            this.lblExaminationName.Size = new System.Drawing.Size(90, 21);
            this.lblExaminationName.TabIndex = 8;
            this.lblExaminationName.Text = "考试名称：";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(967, 171);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblExamineeCompany
            // 
            this.lblExamineeCompany.AutoSize = true;
            this.lblExamineeCompany.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeCompany.Location = new System.Drawing.Point(560, 34);
            this.lblExamineeCompany.Name = "lblExamineeCompany";
            this.lblExamineeCompany.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeCompany.TabIndex = 4;
            this.lblExamineeCompany.Text = "所属公司：";
            // 
            // lblExamineeName
            // 
            this.lblExamineeName.AutoSize = true;
            this.lblExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeName.Location = new System.Drawing.Point(148, 34);
            this.lblExamineeName.Name = "lblExamineeName";
            this.lblExamineeName.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeName.TabIndex = 2;
            this.lblExamineeName.Text = "考生姓名：";
            // 
            // lblExamineeID
            // 
            this.lblExamineeID.AutoSize = true;
            this.lblExamineeID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeID.Location = new System.Drawing.Point(15, 33);
            this.lblExamineeID.Name = "lblExamineeID";
            this.lblExamineeID.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeID.TabIndex = 0;
            this.lblExamineeID.Text = "考生编号：";
            // 
            // cbExaminationSubject
            // 
            this.cbExaminationSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExaminationSubject.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExaminationSubject.FormattingEnabled = true;
            this.cbExaminationSubject.Items.AddRange(new object[] {
            "全部",
            "K1",
            "K2"});
            this.cbExaminationSubject.Location = new System.Drawing.Point(97, 166);
            this.cbExaminationSubject.Name = "cbExaminationSubject";
            this.cbExaminationSubject.Size = new System.Drawing.Size(196, 31);
            this.cbExaminationSubject.TabIndex = 11;
            this.cbExaminationSubject.TextChanged += new System.EventHandler(this.cbExaminationSubject_TextChanged);
            // 
            // lblExaminationSubject
            // 
            this.lblExaminationSubject.AutoSize = true;
            this.lblExaminationSubject.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationSubject.Location = new System.Drawing.Point(17, 171);
            this.lblExaminationSubject.Name = "lblExaminationSubject";
            this.lblExaminationSubject.Size = new System.Drawing.Size(78, 21);
            this.lblExaminationSubject.TabIndex = 18;
            this.lblExaminationSubject.Text = "考试科目:";
            // 
            // pageControl2
            // 
            this.pageControl2.BtnTextNext = "下页";
            this.pageControl2.BtnTextPrevious = "上页";
            this.pageControl2.DisplayStyle = MCS.PageControl.DisplayStyleEnum.文字;
            this.pageControl2.Location = new System.Drawing.Point(0, 61);
            this.pageControl2.Name = "pageControl2";
            this.pageControl2.PageCount = 0;
            this.pageControl2.RecordCount = 0;
            this.pageControl2.Size = new System.Drawing.Size(909, 41);
            this.pageControl2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(300, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "身份证号：";
            // 
            // txtIDCardNum
            // 
            this.txtIDCardNum.AutoSize = true;
            this.txtIDCardNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIDCardNum.Location = new System.Drawing.Point(382, 34);
            this.txtIDCardNum.Name = "txtIDCardNum";
            this.txtIDCardNum.Size = new System.Drawing.Size(50, 21);
            this.txtIDCardNum.TabIndex = 24;
            this.txtIDCardNum.Text = "        ";
            // 
            // 考试成绩详情
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1082, 728);
            this.Controls.Add(this.lblExaminationSubject);
            this.Controls.Add(this.gbSelectReault);
            this.Controls.Add(this.gbSelectCondition);
            this.Controls.Add(this.pageControl2);
            this.Controls.Add(this.cbExaminationSubject);
            this.Controls.Add(this.btnExport2Excel);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "考试成绩详情";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试成绩详情";
            this.gbSelectReault.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationResultDetailInfo)).EndInit();
            this.gbSelectCondition.ResumeLayout(false);
            this.gbSelectCondition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelectReault;
        private System.Windows.Forms.DataGridView dgvExaminationResultDetailInfo;
        private System.Windows.Forms.GroupBox gbSelectCondition;
        private System.Windows.Forms.Label lblExaminationDate;
        private System.Windows.Forms.Label lblExaminationName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblExamineeCompany;
        private System.Windows.Forms.Label lblExamineeName;
        private System.Windows.Forms.Label lblExamineeID;
        private PageControl pageControl2;
        private System.Windows.Forms.Label txtExamineeID;
        private System.Windows.Forms.Label txtExamineeName;
        private System.Windows.Forms.Label txtExamineeCompany;
        private System.Windows.Forms.Label txtExaminationName;
        private System.Windows.Forms.Label txtExaminationDate;
        private System.Windows.Forms.Label lblFinalScore;
        private System.Windows.Forms.Label txtFinalScore;
        private System.Windows.Forms.ComboBox cbExaminationSubject;
        private System.Windows.Forms.Label lblExaminationSubject;
        private System.Windows.Forms.Label lblExaminationResult;
        private System.Windows.Forms.Label txtExaminationResult;
        private System.Windows.Forms.Button btnExport2Excel;
        private System.Windows.Forms.ProgressBar ExcelExportProgressBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationSubjectShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationContentAndStep_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationContentAndStep_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeductionCondition;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtClassType;
        private System.Windows.Forms.Label txtIDCardNum;
        private System.Windows.Forms.Label label2;
    }
}