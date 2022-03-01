namespace MCS
{
    partial class 考试项目查询界面
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvExaminationItemDetailInfo = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContentOrStepDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAllDel = new System.Windows.Forms.Button();
            this.cbAllSelect = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvExaminationItemInfo = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ExaminationItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationContentAndStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationWay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreStandard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreStandardText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbExaminationSujectName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbExaminationName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationItemDetailInfo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationItemInfo)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.btnAllDel);
            this.groupBox1.Controls.Add(this.cbAllSelect);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1488, 713);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.dgvExaminationItemDetailInfo);
            this.groupBox5.Location = new System.Drawing.Point(19, 415);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1456, 229);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "考试项目详情列表";
            // 
            // dgvExaminationItemDetailInfo
            // 
            this.dgvExaminationItemDetailInfo.AllowUserToAddRows = false;
            this.dgvExaminationItemDetailInfo.AllowUserToDeleteRows = false;
            this.dgvExaminationItemDetailInfo.AllowUserToResizeColumns = false;
            this.dgvExaminationItemDetailInfo.AllowUserToResizeRows = false;
            this.dgvExaminationItemDetailInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExaminationItemDetailInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExaminationItemDetailInfo.ColumnHeadersHeight = 32;
            this.dgvExaminationItemDetailInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExaminationItemDetailInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ContentOrStepDetail});
            this.dgvExaminationItemDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExaminationItemDetailInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvExaminationItemDetailInfo.Name = "dgvExaminationItemDetailInfo";
            this.dgvExaminationItemDetailInfo.RowHeadersVisible = false;
            this.dgvExaminationItemDetailInfo.RowHeadersWidth = 40;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dgvExaminationItemDetailInfo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExaminationItemDetailInfo.RowTemplate.Height = 35;
            this.dgvExaminationItemDetailInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExaminationItemDetailInfo.Size = new System.Drawing.Size(1450, 209);
            this.dgvExaminationItemDetailInfo.TabIndex = 1;
            // 
            // ID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ID.HeaderText = "编号";
            this.ID.MinimumWidth = 100;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ContentOrStepDetail
            // 
            this.ContentOrStepDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ContentOrStepDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.ContentOrStepDetail.HeaderText = "考试内容与步骤详情";
            this.ContentOrStepDetail.MinimumWidth = 300;
            this.ContentOrStepDetail.Name = "ContentOrStepDetail";
            this.ContentOrStepDetail.ReadOnly = true;
            this.ContentOrStepDetail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ContentOrStepDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAllDel
            // 
            this.btnAllDel.Enabled = false;
            this.btnAllDel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllDel.Location = new System.Drawing.Point(107, 363);
            this.btnAllDel.Name = "btnAllDel";
            this.btnAllDel.Size = new System.Drawing.Size(100, 30);
            this.btnAllDel.TabIndex = 32;
            this.btnAllDel.Text = "批量删除";
            this.btnAllDel.UseVisualStyleBackColor = true;
            this.btnAllDel.Click += new System.EventHandler(this.btnAllDel_Click);
            // 
            // cbAllSelect
            // 
            this.cbAllSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAllSelect.AutoSize = true;
            this.cbAllSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbAllSelect.Location = new System.Drawing.Point(40, 366);
            this.cbAllSelect.Name = "cbAllSelect";
            this.cbAllSelect.Size = new System.Drawing.Size(61, 25);
            this.cbAllSelect.TabIndex = 31;
            this.cbAllSelect.Text = "全选";
            this.cbAllSelect.UseVisualStyleBackColor = true;
            this.cbAllSelect.CheckedChanged += new System.EventHandler(this.cbAllSelect_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvExaminationItemInfo);
            this.groupBox3.Location = new System.Drawing.Point(16, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1459, 230);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "考试项目列表";
            // 
            // dgvExaminationItemInfo
            // 
            this.dgvExaminationItemInfo.AllowUserToAddRows = false;
            this.dgvExaminationItemInfo.AllowUserToDeleteRows = false;
            this.dgvExaminationItemInfo.AllowUserToResizeColumns = false;
            this.dgvExaminationItemInfo.AllowUserToResizeRows = false;
            this.dgvExaminationItemInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExaminationItemInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvExaminationItemInfo.ColumnHeadersHeight = 32;
            this.dgvExaminationItemInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExaminationItemInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.ExaminationItemID,
            this.No,
            this.ExaminationItemName,
            this.OperationContentAndStep,
            this.ExaminationWay,
            this.ScoreValue,
            this.ScoreStandard,
            this.Type,
            this.ScoreStandardText});
            this.dgvExaminationItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExaminationItemInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvExaminationItemInfo.Name = "dgvExaminationItemInfo";
            this.dgvExaminationItemInfo.RowHeadersVisible = false;
            this.dgvExaminationItemInfo.RowHeadersWidth = 40;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dgvExaminationItemInfo.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvExaminationItemInfo.RowTemplate.Height = 35;
            this.dgvExaminationItemInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvExaminationItemInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExaminationItemInfo.Size = new System.Drawing.Size(1453, 210);
            this.dgvExaminationItemInfo.TabIndex = 1;
            this.dgvExaminationItemInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExaminationItemInfo_CellClick);
            this.dgvExaminationItemInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExaminationItemInfo_CellValueChanged);
            this.dgvExaminationItemInfo.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvExaminationItemInfo_CurrentCellDirtyStateChanged);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.MinimumWidth = 50;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CheckBox.Width = 50;
            // 
            // ExaminationItemID
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExaminationItemID.DefaultCellStyle = dataGridViewCellStyle6;
            this.ExaminationItemID.HeaderText = "考试项目编号";
            this.ExaminationItemID.MinimumWidth = 100;
            this.ExaminationItemID.Name = "ExaminationItemID";
            this.ExaminationItemID.ReadOnly = true;
            this.ExaminationItemID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // No
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.No.DefaultCellStyle = dataGridViewCellStyle7;
            this.No.HeaderText = "序号";
            this.No.MinimumWidth = 50;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 50;
            // 
            // ExaminationItemName
            // 
            this.ExaminationItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ExaminationItemName.DefaultCellStyle = dataGridViewCellStyle8;
            this.ExaminationItemName.HeaderText = "考试项目名称";
            this.ExaminationItemName.MinimumWidth = 250;
            this.ExaminationItemName.Name = "ExaminationItemName";
            this.ExaminationItemName.ReadOnly = true;
            this.ExaminationItemName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OperationContentAndStep
            // 
            this.OperationContentAndStep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.OperationContentAndStep.DefaultCellStyle = dataGridViewCellStyle9;
            this.OperationContentAndStep.HeaderText = "操作内容与步骤";
            this.OperationContentAndStep.MinimumWidth = 200;
            this.OperationContentAndStep.Name = "OperationContentAndStep";
            this.OperationContentAndStep.ReadOnly = true;
            this.OperationContentAndStep.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OperationContentAndStep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExaminationWay
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExaminationWay.DefaultCellStyle = dataGridViewCellStyle10;
            this.ExaminationWay.HeaderText = "考试方式";
            this.ExaminationWay.MinimumWidth = 120;
            this.ExaminationWay.Name = "ExaminationWay";
            this.ExaminationWay.ReadOnly = true;
            this.ExaminationWay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationWay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExaminationWay.Width = 120;
            // 
            // ScoreValue
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ScoreValue.DefaultCellStyle = dataGridViewCellStyle11;
            this.ScoreValue.HeaderText = "分值";
            this.ScoreValue.MinimumWidth = 100;
            this.ScoreValue.Name = "ScoreValue";
            this.ScoreValue.ReadOnly = true;
            this.ScoreValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ScoreValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ScoreStandard
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ScoreStandard.DefaultCellStyle = dataGridViewCellStyle12;
            this.ScoreStandard.HeaderText = "每项（步）分数";
            this.ScoreStandard.MinimumWidth = 100;
            this.ScoreStandard.Name = "ScoreStandard";
            this.ScoreStandard.ReadOnly = true;
            this.ScoreStandard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ScoreStandard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Type
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Type.DefaultCellStyle = dataGridViewCellStyle13;
            this.Type.HeaderText = "操作类型";
            this.Type.MinimumWidth = 100;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ScoreStandardText
            // 
            this.ScoreStandardText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ScoreStandardText.DefaultCellStyle = dataGridViewCellStyle14;
            this.ScoreStandardText.HeaderText = "评分标准";
            this.ScoreStandardText.MinimumWidth = 350;
            this.ScoreStandardText.Name = "ScoreStandardText";
            this.ScoreStandardText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ScoreStandardText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnRefresh);
            this.groupBox4.Controls.Add(this.cbExaminationSujectName);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.cbExaminationName);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(16, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1459, 99);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(500, 56);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 43;
            this.btnRefresh.Text = "刷 新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbExaminationSujectName
            // 
            this.cbExaminationSujectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExaminationSujectName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbExaminationSujectName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExaminationSujectName.FormattingEnabled = true;
            this.cbExaminationSujectName.Location = new System.Drawing.Point(131, 58);
            this.cbExaminationSujectName.MaxDropDownItems = 50;
            this.cbExaminationSujectName.Name = "cbExaminationSujectName";
            this.cbExaminationSujectName.Size = new System.Drawing.Size(343, 29);
            this.cbExaminationSujectName.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 41;
            this.label2.Text = "考试科目名称:";
            // 
            // cbExaminationName
            // 
            this.cbExaminationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExaminationName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbExaminationName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExaminationName.FormattingEnabled = true;
            this.cbExaminationName.Location = new System.Drawing.Point(131, 17);
            this.cbExaminationName.MaxDropDownItems = 50;
            this.cbExaminationName.Name = "cbExaminationName";
            this.cbExaminationName.Size = new System.Drawing.Size(343, 29);
            this.cbExaminationName.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 39;
            this.label1.Text = "考试名称:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Location = new System.Drawing.Point(12, 731);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1488, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(694, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // 考试项目查询界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1512, 821);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "考试项目查询界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "考试项目查询界面";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationItemDetailInfo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationItemInfo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbExaminationName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbExaminationSujectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAllDel;
        private System.Windows.Forms.CheckBox cbAllSelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvExaminationItemInfo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvExaminationItemDetailInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperationContentAndStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationWay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreStandard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreStandardText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContentOrStepDetail;
    }
}
