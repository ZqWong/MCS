namespace MCS
{
    partial class 选择考生界面
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbSelectCondition = new System.Windows.Forms.GroupBox();
            this.txtExamineeName = new System.Windows.Forms.TextBox();
            this.txtExamineeID = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cbExamineeCompany = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbExamineeCompany = new System.Windows.Forms.Label();
            this.lblExamineeName = new System.Windows.Forms.Label();
            this.lblExamineeID = new System.Windows.Forms.Label();
            this.gbSelectReault = new System.Windows.Forms.GroupBox();
            this.dgvExamineeInfo = new System.Windows.Forms.DataGridView();
            this.gbPage = new System.Windows.Forms.GroupBox();
            this.pageControl2 = new MCS.PageControl();
            this.ExamineeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCardNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeCompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChoice = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblTipNeedInput = new System.Windows.Forms.Label();
            this.txtClassType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSelectCondition.SuspendLayout();
            this.gbSelectReault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamineeInfo)).BeginInit();
            this.gbPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelectCondition
            // 
            this.gbSelectCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectCondition.Controls.Add(this.lblTipNeedInput);
            this.gbSelectCondition.Controls.Add(this.txtClassType);
            this.gbSelectCondition.Controls.Add(this.label1);
            this.gbSelectCondition.Controls.Add(this.txtExamineeName);
            this.gbSelectCondition.Controls.Add(this.txtExamineeID);
            this.gbSelectCondition.Controls.Add(this.btnSelect);
            this.gbSelectCondition.Controls.Add(this.cbExamineeCompany);
            this.gbSelectCondition.Controls.Add(this.btnClose);
            this.gbSelectCondition.Controls.Add(this.lbExamineeCompany);
            this.gbSelectCondition.Controls.Add(this.lblExamineeName);
            this.gbSelectCondition.Controls.Add(this.lblExamineeID);
            this.gbSelectCondition.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSelectCondition.Location = new System.Drawing.Point(12, 12);
            this.gbSelectCondition.Name = "gbSelectCondition";
            this.gbSelectCondition.Size = new System.Drawing.Size(1059, 130);
            this.gbSelectCondition.TabIndex = 1;
            this.gbSelectCondition.TabStop = false;
            this.gbSelectCondition.Text = "查询条件";
            // 
            // txtExamineeName
            // 
            this.txtExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeName.Location = new System.Drawing.Point(281, 31);
            this.txtExamineeName.Name = "txtExamineeName";
            this.txtExamineeName.Size = new System.Drawing.Size(100, 29);
            this.txtExamineeName.TabIndex = 3;
            this.txtExamineeName.TextChanged += new System.EventHandler(this.txtExamineeName_TextChanged);
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
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Location = new System.Drawing.Point(764, 31);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 30);
            this.btnSelect.TabIndex = 9;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cbExamineeCompany
            // 
            this.cbExamineeCompany.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExamineeCompany.FormattingEnabled = true;
            this.cbExamineeCompany.Location = new System.Drawing.Point(467, 30);
            this.cbExamineeCompany.MaxDropDownItems = 50;
            this.cbExamineeCompany.Name = "cbExamineeCompany";
            this.cbExamineeCompany.Size = new System.Drawing.Size(282, 31);
            this.cbExamineeCompany.TabIndex = 5;
            this.cbExamineeCompany.TextChanged += new System.EventHandler(this.cbExamineeCompany_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(947, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 10;
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
            this.lbExamineeCompany.Size = new System.Drawing.Size(90, 21);
            this.lbExamineeCompany.TabIndex = 4;
            this.lbExamineeCompany.Text = "所属公司：";
            // 
            // lblExamineeName
            // 
            this.lblExamineeName.AutoSize = true;
            this.lblExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeName.Location = new System.Drawing.Point(201, 34);
            this.lblExamineeName.Name = "lblExamineeName";
            this.lblExamineeName.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeName.TabIndex = 2;
            this.lblExamineeName.Text = "考生名称：";
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
            // gbSelectReault
            // 
            this.gbSelectReault.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectReault.Controls.Add(this.dgvExamineeInfo);
            this.gbSelectReault.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSelectReault.Location = new System.Drawing.Point(14, 148);
            this.gbSelectReault.Name = "gbSelectReault";
            this.gbSelectReault.Size = new System.Drawing.Size(1058, 409);
            this.gbSelectReault.TabIndex = 3;
            this.gbSelectReault.TabStop = false;
            this.gbSelectReault.Text = "查询结果";
            // 
            // dgvExamineeInfo
            // 
            this.dgvExamineeInfo.AllowUserToAddRows = false;
            this.dgvExamineeInfo.AllowUserToDeleteRows = false;
            this.dgvExamineeInfo.AllowUserToResizeColumns = false;
            this.dgvExamineeInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExamineeInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvExamineeInfo.ColumnHeadersHeight = 32;
            this.dgvExamineeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExamineeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExamineeID,
            this.ExamineeName,
            this.IDCardNum,
            this.ExamineeCompanyID,
            this.ExamineeCompanyName,
            this.ClassType,
            this.btnChoice});
            this.dgvExamineeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExamineeInfo.Location = new System.Drawing.Point(3, 21);
            this.dgvExamineeInfo.Name = "dgvExamineeInfo";
            this.dgvExamineeInfo.RowHeadersVisible = false;
            this.dgvExamineeInfo.RowHeadersWidth = 40;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dgvExamineeInfo.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvExamineeInfo.RowTemplate.Height = 35;
            this.dgvExamineeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExamineeInfo.Size = new System.Drawing.Size(1052, 385);
            this.dgvExamineeInfo.TabIndex = 0;
            this.dgvExamineeInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamineeInfo_CellContentClick);
            this.dgvExamineeInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamineeInfo_CellDoubleClick);
            // 
            // gbPage
            // 
            this.gbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPage.Controls.Add(this.pageControl2);
            this.gbPage.Location = new System.Drawing.Point(16, 563);
            this.gbPage.Name = "gbPage";
            this.gbPage.Size = new System.Drawing.Size(1059, 55);
            this.gbPage.TabIndex = 6;
            this.gbPage.TabStop = false;
            // 
            // pageControl2
            // 
            this.pageControl2.BtnTextNext = "下页";
            this.pageControl2.BtnTextPrevious = "上页";
            this.pageControl2.DisplayStyle = MCS.PageControl.DisplayStyleEnum.文字;
            this.pageControl2.Location = new System.Drawing.Point(2, 10);
            this.pageControl2.Name = "pageControl2";
            this.pageControl2.PageCount = 0;
            this.pageControl2.RecordCount = 0;
            this.pageControl2.Size = new System.Drawing.Size(909, 41);
            this.pageControl2.TabIndex = 0;
            this.pageControl2.PageIndexChanged += new MCS.PageControl.EventHandler(this.pageControl2_PageIndexChanged);
            // 
            // ExamineeID
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamineeID.DefaultCellStyle = dataGridViewCellStyle23;
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
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamineeName.DefaultCellStyle = dataGridViewCellStyle24;
            this.ExamineeName.HeaderText = "考生姓名";
            this.ExamineeName.MinimumWidth = 80;
            this.ExamineeName.Name = "ExamineeName";
            this.ExamineeName.ReadOnly = true;
            this.ExamineeName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExamineeName.Width = 80;
            // 
            // IDCardNum
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IDCardNum.DefaultCellStyle = dataGridViewCellStyle25;
            this.IDCardNum.HeaderText = "身份证号";
            this.IDCardNum.MinimumWidth = 200;
            this.IDCardNum.Name = "IDCardNum";
            this.IDCardNum.ReadOnly = true;
            this.IDCardNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IDCardNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IDCardNum.Width = 200;
            // 
            // ExamineeCompanyID
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamineeCompanyID.DefaultCellStyle = dataGridViewCellStyle26;
            this.ExamineeCompanyID.HeaderText = "所属公司ID";
            this.ExamineeCompanyID.MinimumWidth = 300;
            this.ExamineeCompanyID.Name = "ExamineeCompanyID";
            this.ExamineeCompanyID.ReadOnly = true;
            this.ExamineeCompanyID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeCompanyID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExamineeCompanyID.Visible = false;
            this.ExamineeCompanyID.Width = 300;
            // 
            // ExamineeCompanyName
            // 
            this.ExamineeCompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExamineeCompanyName.HeaderText = "所属公司";
            this.ExamineeCompanyName.MinimumWidth = 300;
            this.ExamineeCompanyName.Name = "ExamineeCompanyName";
            this.ExamineeCompanyName.ReadOnly = true;
            this.ExamineeCompanyName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeCompanyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ClassType
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ClassType.DefaultCellStyle = dataGridViewCellStyle27;
            this.ClassType.HeaderText = "班别";
            this.ClassType.MinimumWidth = 100;
            this.ClassType.Name = "ClassType";
            this.ClassType.ReadOnly = true;
            this.ClassType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClassType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnChoice
            // 
            this.btnChoice.HeaderText = "";
            this.btnChoice.MinimumWidth = 100;
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // lblTipNeedInput
            // 
            this.lblTipNeedInput.AutoSize = true;
            this.lblTipNeedInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipNeedInput.ForeColor = System.Drawing.Color.Red;
            this.lblTipNeedInput.Location = new System.Drawing.Point(201, 85);
            this.lblTipNeedInput.Name = "lblTipNeedInput";
            this.lblTipNeedInput.Size = new System.Drawing.Size(155, 21);
            this.lblTipNeedInput.TabIndex = 8;
            this.lblTipNeedInput.Text = "(*)可直接输入数字。";
            // 
            // txtClassType
            // 
            this.txtClassType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClassType.Location = new System.Drawing.Point(95, 82);
            this.txtClassType.Name = "txtClassType";
            this.txtClassType.Size = new System.Drawing.Size(100, 29);
            this.txtClassType.TabIndex = 7;
            this.txtClassType.TextChanged += new System.EventHandler(this.txtClassType_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(47, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "班别：";
            // 
            // 选择考生界面
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1087, 630);
            this.Controls.Add(this.gbPage);
            this.Controls.Add(this.gbSelectReault);
            this.Controls.Add(this.gbSelectCondition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "选择考生界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择考生";
            this.gbSelectCondition.ResumeLayout(false);
            this.gbSelectCondition.PerformLayout();
            this.gbSelectReault.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamineeInfo)).EndInit();
            this.gbPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelectCondition;
        private System.Windows.Forms.TextBox txtExamineeName;
        private System.Windows.Forms.TextBox txtExamineeID;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cbExamineeCompany;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbExamineeCompany;
        private System.Windows.Forms.Label lblExamineeName;
        private System.Windows.Forms.Label lblExamineeID;
        private System.Windows.Forms.GroupBox gbSelectReault;
        private System.Windows.Forms.DataGridView dgvExamineeInfo;
        private System.Windows.Forms.GroupBox gbPage;
        private PageControl pageControl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCardNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeCompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassType;
        private System.Windows.Forms.DataGridViewButtonColumn btnChoice;
        private System.Windows.Forms.Label lblTipNeedInput;
        private System.Windows.Forms.TextBox txtClassType;
        private System.Windows.Forms.Label label1;
    }
}