namespace MCS
{
    partial class 考生信息添加界面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(考生信息添加界面));
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTipNeedInput = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.lblExamineeID = new System.Windows.Forms.Label();
            this.lblExamineeCompany = new System.Windows.Forms.Label();
            this.txtExamineeName = new System.Windows.Forms.TextBox();
            this.lblExamineeName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tagPage_Single = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblClassType = new System.Windows.Forms.Label();
            this.txtClassType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExamineeCompanyName = new System.Windows.Forms.TextBox();
            this.btnChoiceExamineeCompanyName = new System.Windows.Forms.Button();
            this.txtExamineeID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDCardNum = new System.Windows.Forms.TextBox();
            this.lblIDCardNum = new System.Windows.Forms.Label();
            this.tagPage_Batch = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.lblChoiceFile = new System.Windows.Forms.Label();
            this.btnOpenExcelFile = new System.Windows.Forms.Button();
            this.gbButton = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddExamineeInfo = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tagPage_Single.SuspendLayout();
            this.tagPage_Batch.SuspendLayout();
            this.gbButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(499, 24);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删 除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTipNeedInput
            // 
            this.lblTipNeedInput.AutoSize = true;
            this.lblTipNeedInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipNeedInput.ForeColor = System.Drawing.Color.Red;
            this.lblTipNeedInput.Location = new System.Drawing.Point(336, 79);
            this.lblTipNeedInput.Name = "lblTipNeedInput";
            this.lblTipNeedInput.Size = new System.Drawing.Size(75, 21);
            this.lblTipNeedInput.TabIndex = 5;
            this.lblTipNeedInput.Text = "(*)必填。";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.ForeColor = System.Drawing.Color.Red;
            this.lblTip.Location = new System.Drawing.Point(214, 39);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(91, 21);
            this.lblTip.TabIndex = 2;
            this.lblTip.Text = "(*)自动生成";
            // 
            // lblExamineeID
            // 
            this.lblExamineeID.AutoSize = true;
            this.lblExamineeID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeID.Location = new System.Drawing.Point(63, 39);
            this.lblExamineeID.Name = "lblExamineeID";
            this.lblExamineeID.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeID.TabIndex = 0;
            this.lblExamineeID.Text = "考生编号：";
            // 
            // lblExamineeCompany
            // 
            this.lblExamineeCompany.AutoSize = true;
            this.lblExamineeCompany.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeCompany.Location = new System.Drawing.Point(63, 164);
            this.lblExamineeCompany.Name = "lblExamineeCompany";
            this.lblExamineeCompany.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeCompany.TabIndex = 9;
            this.lblExamineeCompany.Text = "所属公司：";
            // 
            // txtExamineeName
            // 
            this.txtExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeName.Location = new System.Drawing.Point(143, 76);
            this.txtExamineeName.Name = "txtExamineeName";
            this.txtExamineeName.Size = new System.Drawing.Size(187, 29);
            this.txtExamineeName.TabIndex = 4;
            this.txtExamineeName.TextChanged += new System.EventHandler(this.txtExamineeName_TextChanged);
            // 
            // lblExamineeName
            // 
            this.lblExamineeName.AutoSize = true;
            this.lblExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeName.Location = new System.Drawing.Point(63, 79);
            this.lblExamineeName.Name = "lblExamineeName";
            this.lblExamineeName.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeName.TabIndex = 3;
            this.lblExamineeName.Text = "考生姓名：";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tagPage_Single);
            this.tabControl1.Controls.Add(this.tagPage_Batch);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 315);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tagPage_Single
            // 
            this.tagPage_Single.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tagPage_Single.Controls.Add(this.label3);
            this.tagPage_Single.Controls.Add(this.lblClassType);
            this.tagPage_Single.Controls.Add(this.txtClassType);
            this.tagPage_Single.Controls.Add(this.label1);
            this.tagPage_Single.Controls.Add(this.txtExamineeCompanyName);
            this.tagPage_Single.Controls.Add(this.btnChoiceExamineeCompanyName);
            this.tagPage_Single.Controls.Add(this.txtExamineeID);
            this.tagPage_Single.Controls.Add(this.label2);
            this.tagPage_Single.Controls.Add(this.txtIDCardNum);
            this.tagPage_Single.Controls.Add(this.lblIDCardNum);
            this.tagPage_Single.Controls.Add(this.lblTipNeedInput);
            this.tagPage_Single.Controls.Add(this.txtExamineeName);
            this.tagPage_Single.Controls.Add(this.lblExamineeName);
            this.tagPage_Single.Controls.Add(this.lblExamineeCompany);
            this.tagPage_Single.Controls.Add(this.lblTip);
            this.tagPage_Single.Controls.Add(this.lblExamineeID);
            this.tagPage_Single.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tagPage_Single.Location = new System.Drawing.Point(4, 28);
            this.tagPage_Single.Name = "tagPage_Single";
            this.tagPage_Single.Padding = new System.Windows.Forms.Padding(3);
            this.tagPage_Single.Size = new System.Drawing.Size(607, 283);
            this.tagPage_Single.TabIndex = 0;
            this.tagPage_Single.Text = "单次操作";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(336, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "(*)可直接输入数字。";
            // 
            // lblClassType
            // 
            this.lblClassType.AutoSize = true;
            this.lblClassType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClassType.Location = new System.Drawing.Point(139, 244);
            this.lblClassType.Name = "lblClassType";
            this.lblClassType.Size = new System.Drawing.Size(0, 21);
            this.lblClassType.TabIndex = 14;
            // 
            // txtClassType
            // 
            this.txtClassType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClassType.Location = new System.Drawing.Point(143, 202);
            this.txtClassType.Name = "txtClassType";
            this.txtClassType.Size = new System.Drawing.Size(187, 29);
            this.txtClassType.TabIndex = 13;
            this.txtClassType.TextChanged += new System.EventHandler(this.txtClassType_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(95, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "班别：";
            // 
            // txtExamineeCompanyName
            // 
            this.txtExamineeCompanyName.Enabled = false;
            this.txtExamineeCompanyName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeCompanyName.Location = new System.Drawing.Point(143, 160);
            this.txtExamineeCompanyName.Name = "txtExamineeCompanyName";
            this.txtExamineeCompanyName.ReadOnly = true;
            this.txtExamineeCompanyName.Size = new System.Drawing.Size(304, 29);
            this.txtExamineeCompanyName.TabIndex = 10;
            // 
            // btnChoiceExamineeCompanyName
            // 
            this.btnChoiceExamineeCompanyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChoiceExamineeCompanyName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChoiceExamineeCompanyName.Location = new System.Drawing.Point(455, 160);
            this.btnChoiceExamineeCompanyName.Name = "btnChoiceExamineeCompanyName";
            this.btnChoiceExamineeCompanyName.Size = new System.Drawing.Size(122, 30);
            this.btnChoiceExamineeCompanyName.TabIndex = 11;
            this.btnChoiceExamineeCompanyName.Text = "选择所属公司";
            this.btnChoiceExamineeCompanyName.UseVisualStyleBackColor = true;
            this.btnChoiceExamineeCompanyName.Click += new System.EventHandler(this.btnChoiceExamineeCompanyName_Click);
            // 
            // txtExamineeID
            // 
            this.txtExamineeID.Enabled = false;
            this.txtExamineeID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeID.Location = new System.Drawing.Point(143, 36);
            this.txtExamineeID.Name = "txtExamineeID";
            this.txtExamineeID.Size = new System.Drawing.Size(69, 29);
            this.txtExamineeID.TabIndex = 1;
            this.txtExamineeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(336, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "(*)必填。";
            // 
            // txtIDCardNum
            // 
            this.txtIDCardNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIDCardNum.Location = new System.Drawing.Point(143, 118);
            this.txtIDCardNum.Name = "txtIDCardNum";
            this.txtIDCardNum.Size = new System.Drawing.Size(187, 29);
            this.txtIDCardNum.TabIndex = 7;
            this.txtIDCardNum.TextChanged += new System.EventHandler(this.txtIDCardNum_TextChanged);
            // 
            // lblIDCardNum
            // 
            this.lblIDCardNum.AutoSize = true;
            this.lblIDCardNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIDCardNum.Location = new System.Drawing.Point(63, 121);
            this.lblIDCardNum.Name = "lblIDCardNum";
            this.lblIDCardNum.Size = new System.Drawing.Size(90, 21);
            this.lblIDCardNum.TabIndex = 6;
            this.lblIDCardNum.Text = "身份证号：";
            // 
            // tagPage_Batch
            // 
            this.tagPage_Batch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tagPage_Batch.Controls.Add(this.progressBar1);
            this.tagPage_Batch.Controls.Add(this.btnImport);
            this.tagPage_Batch.Controls.Add(this.txtFilePath);
            this.tagPage_Batch.Controls.Add(this.lblChoiceFile);
            this.tagPage_Batch.Controls.Add(this.btnOpenExcelFile);
            this.tagPage_Batch.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.tagPage_Batch.Location = new System.Drawing.Point(4, 28);
            this.tagPage_Batch.Name = "tagPage_Batch";
            this.tagPage_Batch.Padding = new System.Windows.Forms.Padding(3);
            this.tagPage_Batch.Size = new System.Drawing.Size(607, 283);
            this.tagPage_Batch.TabIndex = 1;
            this.tagPage_Batch.Text = "批量操作";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(101, 82);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(367, 25);
            this.progressBar1.TabIndex = 3;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.Location = new System.Drawing.Point(484, 80);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 30);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(101, 20);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(367, 25);
            this.txtFilePath.TabIndex = 1;
            // 
            // lblChoiceFile
            // 
            this.lblChoiceFile.AutoSize = true;
            this.lblChoiceFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChoiceFile.Location = new System.Drawing.Point(21, 20);
            this.lblChoiceFile.Name = "lblChoiceFile";
            this.lblChoiceFile.Size = new System.Drawing.Size(90, 21);
            this.lblChoiceFile.TabIndex = 0;
            this.lblChoiceFile.Text = "选择文件：";
            // 
            // btnOpenExcelFile
            // 
            this.btnOpenExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenExcelFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenExcelFile.Location = new System.Drawing.Point(484, 18);
            this.btnOpenExcelFile.Name = "btnOpenExcelFile";
            this.btnOpenExcelFile.Size = new System.Drawing.Size(100, 30);
            this.btnOpenExcelFile.TabIndex = 2;
            this.btnOpenExcelFile.Text = "浏览...";
            this.btnOpenExcelFile.UseVisualStyleBackColor = true;
            this.btnOpenExcelFile.Click += new System.EventHandler(this.btnOpenExcelFile_Click);
            // 
            // gbButton
            // 
            this.gbButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbButton.Controls.Add(this.btnClose);
            this.gbButton.Controls.Add(this.btnAddExamineeInfo);
            this.gbButton.Controls.Add(this.btnDelete);
            this.gbButton.Location = new System.Drawing.Point(4, 323);
            this.gbButton.Name = "gbButton";
            this.gbButton.Size = new System.Drawing.Size(607, 73);
            this.gbButton.TabIndex = 1;
            this.gbButton.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(306, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAddExamineeInfo
            // 
            this.btnAddExamineeInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddExamineeInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddExamineeInfo.Location = new System.Drawing.Point(200, 24);
            this.btnAddExamineeInfo.Name = "btnAddExamineeInfo";
            this.btnAddExamineeInfo.Size = new System.Drawing.Size(100, 30);
            this.btnAddExamineeInfo.TabIndex = 0;
            this.btnAddExamineeInfo.Text = "添 加";
            this.btnAddExamineeInfo.UseVisualStyleBackColor = true;
            this.btnAddExamineeInfo.Click += new System.EventHandler(this.btnAddExamineeInfo_Click);
            // 
            // 考生信息添加界面
            // 
            this.AcceptButton = this.btnAddExamineeInfo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(615, 408);
            this.Controls.Add(this.gbButton);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "考生信息添加界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "考生信息添加";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.考生信息添加界面_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tagPage_Single.ResumeLayout(false);
            this.tagPage_Single.PerformLayout();
            this.tagPage_Batch.ResumeLayout(false);
            this.tagPage_Batch.PerformLayout();
            this.gbButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblExamineeCompany;
        private System.Windows.Forms.TextBox txtExamineeName;
        private System.Windows.Forms.Label lblExamineeName;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.Label lblExamineeID;
        private System.Windows.Forms.Label lblTipNeedInput;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tagPage_Single;
        private System.Windows.Forms.TabPage tagPage_Batch;
        private System.Windows.Forms.Button btnOpenExcelFile;
        private System.Windows.Forms.Label lblChoiceFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblIDCardNum;
        private System.Windows.Forms.TextBox txtIDCardNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExamineeID;
        private System.Windows.Forms.GroupBox gbButton;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddExamineeInfo;
        private System.Windows.Forms.Button btnChoiceExamineeCompanyName;
        private System.Windows.Forms.TextBox txtExamineeCompanyName;
        private System.Windows.Forms.TextBox txtClassType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClassType;
        private System.Windows.Forms.Label label3;
    }
}