namespace MCS
{
    partial class 考试机配置
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(考试机配置));
            this.dgvExaminationPCInfo = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamPCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationPCInfo)).BeginInit();
            this.gb2.SuspendLayout();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvExaminationPCInfo
            // 
            this.dgvExaminationPCInfo.AllowUserToAddRows = false;
            this.dgvExaminationPCInfo.AllowUserToDeleteRows = false;
            this.dgvExaminationPCInfo.AllowUserToResizeColumns = false;
            this.dgvExaminationPCInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExaminationPCInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExaminationPCInfo.ColumnHeadersHeight = 32;
            this.dgvExaminationPCInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExaminationPCInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.ExamPCName,
            this.IP,
            this.Mac,
            this.Type,
            this.ID,
            this.btnUpd,
            this.btnDel});
            this.dgvExaminationPCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExaminationPCInfo.Location = new System.Drawing.Point(3, 21);
            this.dgvExaminationPCInfo.Name = "dgvExaminationPCInfo";
            this.dgvExaminationPCInfo.RowHeadersVisible = false;
            this.dgvExaminationPCInfo.RowHeadersWidth = 40;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dgvExaminationPCInfo.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvExaminationPCInfo.RowTemplate.Height = 35;
            this.dgvExaminationPCInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExaminationPCInfo.Size = new System.Drawing.Size(1003, 574);
            this.dgvExaminationPCInfo.TabIndex = 2;
            this.dgvExaminationPCInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExaminationPCInfo_CellContentClick);
            // 
            // No
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.No.DefaultCellStyle = dataGridViewCellStyle2;
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 50;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 50;
            // 
            // ExamPCName
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamPCName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExamPCName.HeaderText = "Name";
            this.ExamPCName.MinimumWidth = 150;
            this.ExamPCName.Name = "ExamPCName";
            this.ExamPCName.ReadOnly = true;
            this.ExamPCName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamPCName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExamPCName.Width = 150;
            // 
            // IP
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IP.DefaultCellStyle = dataGridViewCellStyle4;
            this.IP.HeaderText = "IP";
            this.IP.MinimumWidth = 150;
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IP.Width = 150;
            // 
            // Mac
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Mac.DefaultCellStyle = dataGridViewCellStyle5;
            this.Mac.HeaderText = "Mac";
            this.Mac.MinimumWidth = 150;
            this.Mac.Name = "Mac";
            this.Mac.ReadOnly = true;
            this.Mac.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Mac.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Mac.Width = 150;
            // 
            // Type
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Type.DefaultCellStyle = dataGridViewCellStyle6;
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 150;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Type.Width = 150;
            // 
            // ID
            // 
            this.ID.HeaderText = "";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // btnUpd
            // 
            this.btnUpd.HeaderText = "";
            this.btnUpd.MinimumWidth = 100;
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnDel
            // 
            this.btnDel.HeaderText = "";
            this.btnDel.MinimumWidth = 100;
            this.btnDel.Name = "btnDel";
            this.btnDel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gb2
            // 
            this.gb2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb2.Controls.Add(this.dgvExaminationPCInfo);
            this.gb2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb2.Location = new System.Drawing.Point(12, 48);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(1009, 598);
            this.gb2.TabIndex = 2;
            this.gb2.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(918, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gb1
            // 
            this.gb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb1.Controls.Add(this.btnClose);
            this.gb1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb1.Location = new System.Drawing.Point(15, 658);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(1009, 63);
            this.gb1.TabIndex = 3;
            this.gb1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(454, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // 考试机配置
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1033, 733);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gb2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "考试机配置";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "计算机配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.考试机信息管理_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExaminationPCInfo)).EndInit();
            this.gb2.ResumeLayout(false);
            this.gb1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvExaminationPCInfo;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamPCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewButtonColumn btnUpd;
        private System.Windows.Forms.DataGridViewButtonColumn btnDel;
    }
}