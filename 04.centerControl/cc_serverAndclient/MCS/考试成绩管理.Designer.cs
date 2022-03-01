namespace MCS
{
    partial class 考试成绩管理
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(考试成绩管理));
            this.btnAllDel = new System.Windows.Forms.Button();
            this.cbAllSelect = new System.Windows.Forms.CheckBox();
            this.gbSelectReault = new System.Windows.Forms.GroupBox();
            this.dgvExaminationResultInfo = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ExaminationResultID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationSubjectIDs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationSubjects = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalScore2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbSelectCondition = new System.Windows.Forms.GroupBox();
            this.cbExaminationName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.lblExaminationDate = new System.Windows.Forms.Label();
            this.lblExaminationName = new System.Windows.Forms.Label();
            this.cbExamineeCompany = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbExamineeCompany = new System.Windows.Forms.Label();
            this.lblExamineeName = new System.Windows.Forms.Label();
            this.txtExamineeName = new System.Windows.Forms.TextBox();
            this.lblExamineeID = new System.Windows.Forms.Label();
            this.txtExamineeID = new System.Windows.Forms.TextBox();
            this.gbPage = new System.Windows.Forms.GroupBox();
            this.pageControl1 = new MCS.PageControl();
            this.gbSelectReault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationResultInfo)).BeginInit();
            this.gbSelectCondition.SuspendLayout();
            this.gbPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAllDel
            // 
            this.btnAllDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAllDel.Enabled = false;
            this.btnAllDel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllDel.Location = new System.Drawing.Point(865, 78);
            this.btnAllDel.Name = "btnAllDel";
            this.btnAllDel.Size = new System.Drawing.Size(100, 30);
            this.btnAllDel.TabIndex = 3;
            this.btnAllDel.Text = "批量删除";
            this.btnAllDel.UseVisualStyleBackColor = true;
            this.btnAllDel.Visible = false;
            // 
            // cbAllSelect
            // 
            this.cbAllSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAllSelect.AutoSize = true;
            this.cbAllSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbAllSelect.Location = new System.Drawing.Point(798, 81);
            this.cbAllSelect.Name = "cbAllSelect";
            this.cbAllSelect.Size = new System.Drawing.Size(61, 25);
            this.cbAllSelect.TabIndex = 2;
            this.cbAllSelect.Text = "全选";
            this.cbAllSelect.UseVisualStyleBackColor = true;
            this.cbAllSelect.Visible = false;
            this.cbAllSelect.CheckedChanged += new System.EventHandler(this.cbAllSelect_CheckedChanged);
            // 
            // gbSelectReault
            // 
            this.gbSelectReault.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectReault.Controls.Add(this.dgvExaminationResultInfo);
            this.gbSelectReault.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSelectReault.Location = new System.Drawing.Point(13, 168);
            this.gbSelectReault.Name = "gbSelectReault";
            this.gbSelectReault.Size = new System.Drawing.Size(1621, 491);
            this.gbSelectReault.TabIndex = 1;
            this.gbSelectReault.TabStop = false;
            // 
            // dgvExaminationResultInfo
            // 
            this.dgvExaminationResultInfo.AllowUserToAddRows = false;
            this.dgvExaminationResultInfo.AllowUserToDeleteRows = false;
            this.dgvExaminationResultInfo.AllowUserToResizeColumns = false;
            this.dgvExaminationResultInfo.AllowUserToResizeRows = false;
            this.dgvExaminationResultInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExaminationResultInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExaminationResultInfo.ColumnHeadersHeight = 32;
            this.dgvExaminationResultInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExaminationResultInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.ExaminationResultID,
            this.FinalScore,
            this.ExaminationSubjectIDs,
            this.ExamineeID,
            this.ExamineeName,
            this.ExamineeCompanyName,
            this.ExaminationName,
            this.ExaminationSubjects,
            this.FinalScore2,
            this.ExaminationResult,
            this.ExaminationDate,
            this.btnDetail});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExaminationResultInfo.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvExaminationResultInfo.Location = new System.Drawing.Point(3, 21);
            this.dgvExaminationResultInfo.Name = "dgvExaminationResultInfo";
            this.dgvExaminationResultInfo.RowHeadersVisible = false;
            this.dgvExaminationResultInfo.RowHeadersWidth = 40;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExaminationResultInfo.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvExaminationResultInfo.RowTemplate.Height = 45;
            this.dgvExaminationResultInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExaminationResultInfo.Size = new System.Drawing.Size(1612, 467);
            this.dgvExaminationResultInfo.TabIndex = 0;
            this.dgvExaminationResultInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExaminationResultInfo_CellContentClick);
            this.dgvExaminationResultInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExaminationResultInfo_CellDoubleClick);
            this.dgvExaminationResultInfo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvExaminationResultInfo_CellPainting);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.MinimumWidth = 50;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CheckBox.Visible = false;
            this.CheckBox.Width = 50;
            // 
            // ExaminationResultID
            // 
            this.ExaminationResultID.HeaderText = "考试结果ID";
            this.ExaminationResultID.Name = "ExaminationResultID";
            this.ExaminationResultID.Visible = false;
            // 
            // FinalScore
            // 
            this.FinalScore.HeaderText = "分数1";
            this.FinalScore.Name = "FinalScore";
            this.FinalScore.Visible = false;
            // 
            // ExaminationSubjectIDs
            // 
            this.ExaminationSubjectIDs.HeaderText = "考试科目IDs";
            this.ExaminationSubjectIDs.Name = "ExaminationSubjectIDs";
            this.ExaminationSubjectIDs.Visible = false;
            // 
            // ExamineeID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamineeID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExamineeID.HeaderText = "考生编号";
            this.ExamineeID.MinimumWidth = 80;
            this.ExamineeID.Name = "ExamineeID";
            this.ExamineeID.ReadOnly = true;
            this.ExamineeID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExamineeID.Width = 80;
            // 
            // ExamineeName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamineeName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExamineeName.HeaderText = "考生姓名";
            this.ExamineeName.MinimumWidth = 80;
            this.ExamineeName.Name = "ExamineeName";
            this.ExamineeName.ReadOnly = true;
            this.ExamineeName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExamineeName.Width = 80;
            // 
            // ExamineeCompanyName
            // 
            this.ExamineeCompanyName.HeaderText = "所属公司";
            this.ExamineeCompanyName.MinimumWidth = 300;
            this.ExamineeCompanyName.Name = "ExamineeCompanyName";
            this.ExamineeCompanyName.ReadOnly = true;
            this.ExamineeCompanyName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeCompanyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExamineeCompanyName.Width = 300;
            // 
            // ExaminationName
            // 
            this.ExaminationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ExaminationName.DefaultCellStyle = dataGridViewCellStyle4;
            this.ExaminationName.HeaderText = "考试名称";
            this.ExaminationName.MinimumWidth = 300;
            this.ExaminationName.Name = "ExaminationName";
            this.ExaminationName.ReadOnly = true;
            this.ExaminationName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExaminationName.Width = 300;
            // 
            // ExaminationSubjects
            // 
            this.ExaminationSubjects.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ExaminationSubjects.DefaultCellStyle = dataGridViewCellStyle5;
            this.ExaminationSubjects.FillWeight = 200F;
            this.ExaminationSubjects.HeaderText = "考试科目";
            this.ExaminationSubjects.MinimumWidth = 300;
            this.ExaminationSubjects.Name = "ExaminationSubjects";
            this.ExaminationSubjects.ReadOnly = true;
            this.ExaminationSubjects.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationSubjects.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FinalScore2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FinalScore2.DefaultCellStyle = dataGridViewCellStyle6;
            this.FinalScore2.HeaderText = "得分";
            this.FinalScore2.MinimumWidth = 100;
            this.FinalScore2.Name = "FinalScore2";
            this.FinalScore2.ReadOnly = true;
            this.FinalScore2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FinalScore2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExaminationResult
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExaminationResult.DefaultCellStyle = dataGridViewCellStyle7;
            this.ExaminationResult.HeaderText = "考试结果";
            this.ExaminationResult.MinimumWidth = 100;
            this.ExaminationResult.Name = "ExaminationResult";
            this.ExaminationResult.ReadOnly = true;
            this.ExaminationResult.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExaminationDate
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExaminationDate.DefaultCellStyle = dataGridViewCellStyle8;
            this.ExaminationDate.HeaderText = "考试日期";
            this.ExaminationDate.MinimumWidth = 200;
            this.ExaminationDate.Name = "ExaminationDate";
            this.ExaminationDate.ReadOnly = true;
            this.ExaminationDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExaminationDate.Width = 200;
            // 
            // btnDetail
            // 
            this.btnDetail.HeaderText = "";
            this.btnDetail.MinimumWidth = 100;
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gbSelectCondition
            // 
            this.gbSelectCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectCondition.Controls.Add(this.cbExaminationName);
            this.gbSelectCondition.Controls.Add(this.btnAllDel);
            this.gbSelectCondition.Controls.Add(this.cbAllSelect);
            this.gbSelectCondition.Controls.Add(this.label1);
            this.gbSelectCondition.Controls.Add(this.dateTimePickerTo);
            this.gbSelectCondition.Controls.Add(this.dateTimePickerFrom);
            this.gbSelectCondition.Controls.Add(this.lblExaminationDate);
            this.gbSelectCondition.Controls.Add(this.lblExaminationName);
            this.gbSelectCondition.Controls.Add(this.cbExamineeCompany);
            this.gbSelectCondition.Controls.Add(this.btnSelect);
            this.gbSelectCondition.Controls.Add(this.btnClose);
            this.gbSelectCondition.Controls.Add(this.lbExamineeCompany);
            this.gbSelectCondition.Controls.Add(this.lblExamineeName);
            this.gbSelectCondition.Controls.Add(this.txtExamineeName);
            this.gbSelectCondition.Controls.Add(this.lblExamineeID);
            this.gbSelectCondition.Controls.Add(this.txtExamineeID);
            this.gbSelectCondition.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSelectCondition.Location = new System.Drawing.Point(12, 12);
            this.gbSelectCondition.Name = "gbSelectCondition";
            this.gbSelectCondition.Size = new System.Drawing.Size(1622, 150);
            this.gbSelectCondition.TabIndex = 0;
            this.gbSelectCondition.TabStop = false;
            this.gbSelectCondition.Text = "查询条件";
            // 
            // cbExaminationName
            // 
            this.cbExaminationName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbExaminationName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExaminationName.FormattingEnabled = true;
            this.cbExaminationName.Location = new System.Drawing.Point(95, 84);
            this.cbExaminationName.MaxDropDownItems = 50;
            this.cbExaminationName.Name = "cbExaminationName";
            this.cbExaminationName.Size = new System.Drawing.Size(343, 29);
            this.cbExaminationName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1023, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "~";
            this.label1.Visible = false;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(1065, 30);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(143, 25);
            this.dateTimePickerTo.TabIndex = 11;
            this.dateTimePickerTo.Visible = false;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(865, 31);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(143, 25);
            this.dateTimePickerFrom.TabIndex = 9;
            this.dateTimePickerFrom.Visible = false;
            // 
            // lblExaminationDate
            // 
            this.lblExaminationDate.AutoSize = true;
            this.lblExaminationDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationDate.Location = new System.Drawing.Point(785, 34);
            this.lblExaminationDate.Name = "lblExaminationDate";
            this.lblExaminationDate.Size = new System.Drawing.Size(78, 21);
            this.lblExaminationDate.TabIndex = 8;
            this.lblExaminationDate.Text = "考试日期:";
            this.lblExaminationDate.Visible = false;
            // 
            // lblExaminationName
            // 
            this.lblExaminationName.AutoSize = true;
            this.lblExaminationName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationName.Location = new System.Drawing.Point(15, 87);
            this.lblExaminationName.Name = "lblExaminationName";
            this.lblExaminationName.Size = new System.Drawing.Size(78, 21);
            this.lblExaminationName.TabIndex = 6;
            this.lblExaminationName.Text = "考试名称:";
            // 
            // cbExamineeCompany
            // 
            this.cbExamineeCompany.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbExamineeCompany.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExamineeCompany.FormattingEnabled = true;
            this.cbExamineeCompany.Location = new System.Drawing.Point(467, 30);
            this.cbExamineeCompany.MaxDropDownItems = 50;
            this.cbExamineeCompany.Name = "cbExamineeCompany";
            this.cbExamineeCompany.Size = new System.Drawing.Size(282, 31);
            this.cbExamineeCompany.TabIndex = 5;
            this.cbExamineeCompany.TextChanged += new System.EventHandler(this.cbExamineeCompany_TextChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Location = new System.Drawing.Point(467, 82);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 30);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(573, 82);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbExamineeCompany
            // 
            this.lbExamineeCompany.AutoSize = true;
            this.lbExamineeCompany.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbExamineeCompany.Location = new System.Drawing.Point(387, 34);
            this.lbExamineeCompany.Name = "lbExamineeCompany";
            this.lbExamineeCompany.Size = new System.Drawing.Size(78, 21);
            this.lbExamineeCompany.TabIndex = 4;
            this.lbExamineeCompany.Text = "所属公司:";
            // 
            // lblExamineeName
            // 
            this.lblExamineeName.AutoSize = true;
            this.lblExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeName.Location = new System.Drawing.Point(201, 34);
            this.lblExamineeName.Name = "lblExamineeName";
            this.lblExamineeName.Size = new System.Drawing.Size(78, 21);
            this.lblExamineeName.TabIndex = 2;
            this.lblExamineeName.Text = "考生姓名:";
            // 
            // txtExamineeName
            // 
            this.txtExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeName.Location = new System.Drawing.Point(281, 30);
            this.txtExamineeName.Name = "txtExamineeName";
            this.txtExamineeName.Size = new System.Drawing.Size(100, 29);
            this.txtExamineeName.TabIndex = 3;
            this.txtExamineeName.TextChanged += new System.EventHandler(this.txtExamineeName_TextChanged);
            // 
            // lblExamineeID
            // 
            this.lblExamineeID.AutoSize = true;
            this.lblExamineeID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeID.Location = new System.Drawing.Point(15, 33);
            this.lblExamineeID.Name = "lblExamineeID";
            this.lblExamineeID.Size = new System.Drawing.Size(78, 21);
            this.lblExamineeID.TabIndex = 0;
            this.lblExamineeID.Text = "考生编号:";
            // 
            // txtExamineeID
            // 
            this.txtExamineeID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeID.Location = new System.Drawing.Point(95, 30);
            this.txtExamineeID.Name = "txtExamineeID";
            this.txtExamineeID.Size = new System.Drawing.Size(100, 29);
            this.txtExamineeID.TabIndex = 1;
            this.txtExamineeID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamineeID_KeyPress);
            // 
            // gbPage
            // 
            this.gbPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPage.Controls.Add(this.pageControl1);
            this.gbPage.Location = new System.Drawing.Point(13, 665);
            this.gbPage.Name = "gbPage";
            this.gbPage.Size = new System.Drawing.Size(1618, 55);
            this.gbPage.TabIndex = 4;
            this.gbPage.TabStop = false;
            // 
            // pageControl1
            // 
            this.pageControl1.BtnTextNext = "下页";
            this.pageControl1.BtnTextPrevious = "上页";
            this.pageControl1.DisplayStyle = MCS.PageControl.DisplayStyleEnum.文字;
            this.pageControl1.Location = new System.Drawing.Point(2, 10);
            this.pageControl1.Name = "pageControl1";
            this.pageControl1.PageCount = 0;
            this.pageControl1.RecordCount = 0;
            this.pageControl1.Size = new System.Drawing.Size(909, 41);
            this.pageControl1.TabIndex = 0;
            this.pageControl1.PageIndexChanged += new MCS.PageControl.EventHandler(this.pageControl1_PageIndexChanged);
            // 
            // 考试成绩管理
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1646, 732);
            this.Controls.Add(this.gbPage);
            this.Controls.Add(this.gbSelectReault);
            this.Controls.Add(this.gbSelectCondition);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "考试成绩管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "考试成绩管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbSelectReault.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationResultInfo)).EndInit();
            this.gbSelectCondition.ResumeLayout(false);
            this.gbSelectCondition.PerformLayout();
            this.gbPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllDel;
        private System.Windows.Forms.CheckBox cbAllSelect;
        private System.Windows.Forms.GroupBox gbSelectReault;
        private System.Windows.Forms.GroupBox gbSelectCondition;
        private System.Windows.Forms.ComboBox cbExamineeCompany;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbExamineeCompany;
        private System.Windows.Forms.Label lblExamineeName;
        private System.Windows.Forms.TextBox txtExamineeName;
        private System.Windows.Forms.Label lblExamineeID;
        private System.Windows.Forms.TextBox txtExamineeID;
        private System.Windows.Forms.GroupBox gbPage;
        private PageControl pageControl1;
        private System.Windows.Forms.Label lblExaminationName;
        private System.Windows.Forms.DataGridView dgvExaminationResultInfo;
        private System.Windows.Forms.Label lblExaminationDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbExaminationName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationResultID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationSubjectIDs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalScore2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationDate;
        private System.Windows.Forms.DataGridViewButtonColumn btnDetail;
    }
}