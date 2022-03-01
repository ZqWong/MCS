namespace MCS
{
    partial class 考生所属公司信息管理
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(考生所属公司信息管理));
            this.btnAllDel = new System.Windows.Forms.Button();
            this.cbAllSelect = new System.Windows.Forms.CheckBox();
            this.gbPage = new System.Windows.Forms.GroupBox();
            this.pageControl2 = new MCS.PageControl();
            this.btnAddExamineeCompanyInfo = new System.Windows.Forms.Button();
            this.gbSelectReault = new System.Windows.Forms.GroupBox();
            this.dgvExamineeCompanyInfo = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ExamineeCompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbSelectCondition = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtExamineeCompanyName = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblExamineeCompanyName = new System.Windows.Forms.Label();
            this.gbPage.SuspendLayout();
            this.gbSelectReault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamineeCompanyInfo)).BeginInit();
            this.gbSelectCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAllDel
            // 
            this.btnAllDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAllDel.Enabled = false;
            this.btnAllDel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllDel.Location = new System.Drawing.Point(105, 545);
            this.btnAllDel.Name = "btnAllDel";
            this.btnAllDel.Size = new System.Drawing.Size(100, 30);
            this.btnAllDel.TabIndex = 4;
            this.btnAllDel.Text = "批量删除";
            this.btnAllDel.UseVisualStyleBackColor = true;
            this.btnAllDel.Click += new System.EventHandler(this.btnAllDel_Click);
            // 
            // cbAllSelect
            // 
            this.cbAllSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAllSelect.AutoSize = true;
            this.cbAllSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbAllSelect.Location = new System.Drawing.Point(38, 548);
            this.cbAllSelect.Name = "cbAllSelect";
            this.cbAllSelect.Size = new System.Drawing.Size(61, 25);
            this.cbAllSelect.TabIndex = 3;
            this.cbAllSelect.Text = "全选";
            this.cbAllSelect.UseVisualStyleBackColor = true;
            this.cbAllSelect.CheckedChanged += new System.EventHandler(this.cbAllSelect_CheckedChanged);
            // 
            // gbPage
            // 
            this.gbPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPage.Controls.Add(this.pageControl2);
            this.gbPage.Location = new System.Drawing.Point(14, 574);
            this.gbPage.Name = "gbPage";
            this.gbPage.Size = new System.Drawing.Size(1059, 55);
            this.gbPage.TabIndex = 5;
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
            this.pageControl2.Size = new System.Drawing.Size(1054, 41);
            this.pageControl2.TabIndex = 0;
            this.pageControl2.PageIndexChanged += new MCS.PageControl.EventHandler(this.pageControl2_PageIndexChanged);
            // 
            // btnAddExamineeCompanyInfo
            // 
            this.btnAddExamineeCompanyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExamineeCompanyInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddExamineeCompanyInfo.Location = new System.Drawing.Point(967, 102);
            this.btnAddExamineeCompanyInfo.Name = "btnAddExamineeCompanyInfo";
            this.btnAddExamineeCompanyInfo.Size = new System.Drawing.Size(100, 30);
            this.btnAddExamineeCompanyInfo.TabIndex = 1;
            this.btnAddExamineeCompanyInfo.Text = "添加";
            this.btnAddExamineeCompanyInfo.UseVisualStyleBackColor = true;
            this.btnAddExamineeCompanyInfo.Click += new System.EventHandler(this.btnAddExamineeCompanyInfo_Click);
            // 
            // gbSelectReault
            // 
            this.gbSelectReault.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectReault.Controls.Add(this.dgvExamineeCompanyInfo);
            this.gbSelectReault.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSelectReault.Location = new System.Drawing.Point(15, 134);
            this.gbSelectReault.Name = "gbSelectReault";
            this.gbSelectReault.Size = new System.Drawing.Size(1058, 408);
            this.gbSelectReault.TabIndex = 2;
            this.gbSelectReault.TabStop = false;
            this.gbSelectReault.Text = "查询结果";
            // 
            // dgvExamineeCompanyInfo
            // 
            this.dgvExamineeCompanyInfo.AllowUserToAddRows = false;
            this.dgvExamineeCompanyInfo.AllowUserToDeleteRows = false;
            this.dgvExamineeCompanyInfo.AllowUserToResizeColumns = false;
            this.dgvExamineeCompanyInfo.AllowUserToResizeRows = false;
            this.dgvExamineeCompanyInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExamineeCompanyInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExamineeCompanyInfo.ColumnHeadersHeight = 32;
            this.dgvExamineeCompanyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExamineeCompanyInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.ExamineeCompanyID,
            this.ExamineeCompanyName,
            this.btnUpdate});
            this.dgvExamineeCompanyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExamineeCompanyInfo.Location = new System.Drawing.Point(3, 21);
            this.dgvExamineeCompanyInfo.Name = "dgvExamineeCompanyInfo";
            this.dgvExamineeCompanyInfo.RowHeadersVisible = false;
            this.dgvExamineeCompanyInfo.RowHeadersWidth = 40;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dgvExamineeCompanyInfo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExamineeCompanyInfo.RowTemplate.Height = 35;
            this.dgvExamineeCompanyInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExamineeCompanyInfo.Size = new System.Drawing.Size(1052, 384);
            this.dgvExamineeCompanyInfo.TabIndex = 0;
            this.dgvExamineeCompanyInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamineeCompanyInfo_CellClick);
            this.dgvExamineeCompanyInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamineeCompanyInfo_CellContentClick);
            this.dgvExamineeCompanyInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamineeCompanyInfo_CellDoubleClick);
            this.dgvExamineeCompanyInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExamineeCompanyInfo_CellValueChanged);
            this.dgvExamineeCompanyInfo.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvExamineeCompanyInfo_CurrentCellDirtyStateChanged);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.MinimumWidth = 50;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CheckBox.Width = 50;
            // 
            // ExamineeCompanyID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamineeCompanyID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExamineeCompanyID.HeaderText = "所属公司编号";
            this.ExamineeCompanyID.MinimumWidth = 80;
            this.ExamineeCompanyID.Name = "ExamineeCompanyID";
            this.ExamineeCompanyID.ReadOnly = true;
            this.ExamineeCompanyID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeCompanyID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExamineeCompanyID.Visible = false;
            this.ExamineeCompanyID.Width = 80;
            // 
            // ExamineeCompanyName
            // 
            this.ExamineeCompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExamineeCompanyName.HeaderText = "所属公司名称";
            this.ExamineeCompanyName.MinimumWidth = 300;
            this.ExamineeCompanyName.Name = "ExamineeCompanyName";
            this.ExamineeCompanyName.ReadOnly = true;
            this.ExamineeCompanyName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeCompanyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnUpdate
            // 
            this.btnUpdate.HeaderText = "";
            this.btnUpdate.MinimumWidth = 100;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gbSelectCondition
            // 
            this.gbSelectCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelectCondition.Controls.Add(this.btnClose);
            this.gbSelectCondition.Controls.Add(this.txtExamineeCompanyName);
            this.gbSelectCondition.Controls.Add(this.btnSelect);
            this.gbSelectCondition.Controls.Add(this.lblExamineeCompanyName);
            this.gbSelectCondition.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSelectCondition.Location = new System.Drawing.Point(14, 11);
            this.gbSelectCondition.Name = "gbSelectCondition";
            this.gbSelectCondition.Size = new System.Drawing.Size(1059, 81);
            this.gbSelectCondition.TabIndex = 0;
            this.gbSelectCondition.TabStop = false;
            this.gbSelectCondition.Text = "查询条件";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(953, 29);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtExamineeCompanyName
            // 
            this.txtExamineeCompanyName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeCompanyName.Location = new System.Drawing.Point(126, 30);
            this.txtExamineeCompanyName.Name = "txtExamineeCompanyName";
            this.txtExamineeCompanyName.Size = new System.Drawing.Size(321, 29);
            this.txtExamineeCompanyName.TabIndex = 1;
            this.txtExamineeCompanyName.TextChanged += new System.EventHandler(this.txtExamineeCompanyName_TextChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Location = new System.Drawing.Point(453, 29);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 30);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblExamineeCompanyName
            // 
            this.lblExamineeCompanyName.AutoSize = true;
            this.lblExamineeCompanyName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeCompanyName.Location = new System.Drawing.Point(15, 33);
            this.lblExamineeCompanyName.Name = "lblExamineeCompanyName";
            this.lblExamineeCompanyName.Size = new System.Drawing.Size(122, 21);
            this.lblExamineeCompanyName.TabIndex = 0;
            this.lblExamineeCompanyName.Text = "所属公司名称：";
            // 
            // 考生所属公司信息管理
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1087, 641);
            this.Controls.Add(this.btnAllDel);
            this.Controls.Add(this.cbAllSelect);
            this.Controls.Add(this.gbPage);
            this.Controls.Add(this.btnAddExamineeCompanyInfo);
            this.Controls.Add(this.gbSelectReault);
            this.Controls.Add(this.gbSelectCondition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "考生所属公司信息管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考生所属公司管理";
            this.gbPage.ResumeLayout(false);
            this.gbSelectReault.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamineeCompanyInfo)).EndInit();
            this.gbSelectCondition.ResumeLayout(false);
            this.gbSelectCondition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAllDel;
        private System.Windows.Forms.CheckBox cbAllSelect;
        private System.Windows.Forms.GroupBox gbPage;
        private PageControl pageControl2;
        private System.Windows.Forms.Button btnAddExamineeCompanyInfo;
        private System.Windows.Forms.GroupBox gbSelectReault;
        private System.Windows.Forms.DataGridView dgvExamineeCompanyInfo;
        private System.Windows.Forms.GroupBox gbSelectCondition;
        private System.Windows.Forms.TextBox txtExamineeCompanyName;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblExamineeCompanyName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeCompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeCompanyName;
        private System.Windows.Forms.DataGridViewButtonColumn btnUpdate;
        private System.Windows.Forms.Button btnClose;
    }
}
