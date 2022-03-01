namespace MCS
{
    partial class 回收分配界面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(回收分配界面));
            this.gbButton = new System.Windows.Forms.GroupBox();
            this.lblExamOrPrac = new System.Windows.Forms.Label();
            this.btnReExam = new System.Windows.Forms.Button();
            this.btnAllotExam = new System.Windows.Forms.Button();
            this.btnRecycleExam = new System.Windows.Forms.Button();
            this.gbExamineeInfo = new System.Windows.Forms.GroupBox();
            this.txtIDCardNum = new System.Windows.Forms.TextBox();
            this.lblIDCardNum = new System.Windows.Forms.Label();
            this.imgExamState = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblExaminationState = new System.Windows.Forms.Label();
            this.cbExaminationName = new System.Windows.Forms.ComboBox();
            this.lblExaminationName = new System.Windows.Forms.Label();
            this.txtExamineeCompanyName = new System.Windows.Forms.TextBox();
            this.btnChoiceExaminee = new System.Windows.Forms.Button();
            this.txtExamineeID = new System.Windows.Forms.TextBox();
            this.lblExamineeID = new System.Windows.Forms.Label();
            this.lblExamineeCompany = new System.Windows.Forms.Label();
            this.txtExamineeName = new System.Windows.Forms.TextBox();
            this.lblExamineeName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExamPCState = new System.Windows.Forms.Label();
            this.lblExaminationPCState = new System.Windows.Forms.Label();
            this.txtExamPCName = new System.Windows.Forms.Label();
            this.lblExaminationPC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassType = new System.Windows.Forms.TextBox();
            this.gbButton.SuspendLayout();
            this.gbExamineeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgExamState)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbButton
            // 
            this.gbButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbButton.Controls.Add(this.lblExamOrPrac);
            this.gbButton.Controls.Add(this.btnReExam);
            this.gbButton.Controls.Add(this.btnAllotExam);
            this.gbButton.Controls.Add(this.btnRecycleExam);
            this.gbButton.Location = new System.Drawing.Point(12, 460);
            this.gbButton.Name = "gbButton";
            this.gbButton.Size = new System.Drawing.Size(506, 66);
            this.gbButton.TabIndex = 0;
            this.gbButton.TabStop = false;
            // 
            // lblExamOrPrac
            // 
            this.lblExamOrPrac.AutoSize = true;
            this.lblExamOrPrac.BackColor = System.Drawing.Color.Yellow;
            this.lblExamOrPrac.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamOrPrac.ForeColor = System.Drawing.Color.Red;
            this.lblExamOrPrac.Location = new System.Drawing.Point(31, 18);
            this.lblExamOrPrac.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExamOrPrac.Name = "lblExamOrPrac";
            this.lblExamOrPrac.Size = new System.Drawing.Size(69, 35);
            this.lblExamOrPrac.TabIndex = 3;
            this.lblExamOrPrac.Text = "练习";
            // 
            // btnReExam
            // 
            this.btnReExam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReExam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReExam.Location = new System.Drawing.Point(399, 21);
            this.btnReExam.Name = "btnReExam";
            this.btnReExam.Size = new System.Drawing.Size(100, 30);
            this.btnReExam.TabIndex = 2;
            this.btnReExam.Text = "重  考";
            this.btnReExam.UseVisualStyleBackColor = true;
            this.btnReExam.Click += new System.EventHandler(this.btnReExam_Click);
            // 
            // btnAllotExam
            // 
            this.btnAllotExam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAllotExam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllotExam.Location = new System.Drawing.Point(256, 21);
            this.btnAllotExam.Name = "btnAllotExam";
            this.btnAllotExam.Size = new System.Drawing.Size(100, 30);
            this.btnAllotExam.TabIndex = 1;
            this.btnAllotExam.Text = "分  配";
            this.btnAllotExam.UseVisualStyleBackColor = true;
            this.btnAllotExam.Click += new System.EventHandler(this.btnAllotExam_Click);
            // 
            // btnRecycleExam
            // 
            this.btnRecycleExam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRecycleExam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecycleExam.Location = new System.Drawing.Point(150, 21);
            this.btnRecycleExam.Name = "btnRecycleExam";
            this.btnRecycleExam.Size = new System.Drawing.Size(100, 30);
            this.btnRecycleExam.TabIndex = 0;
            this.btnRecycleExam.Text = "回  收";
            this.btnRecycleExam.UseVisualStyleBackColor = true;
            this.btnRecycleExam.Click += new System.EventHandler(this.btnRecycleExam_Click);
            // 
            // gbExamineeInfo
            // 
            this.gbExamineeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExamineeInfo.Controls.Add(this.txtClassType);
            this.gbExamineeInfo.Controls.Add(this.label1);
            this.gbExamineeInfo.Controls.Add(this.txtIDCardNum);
            this.gbExamineeInfo.Controls.Add(this.lblIDCardNum);
            this.gbExamineeInfo.Controls.Add(this.imgExamState);
            this.gbExamineeInfo.Controls.Add(this.btnClose);
            this.gbExamineeInfo.Controls.Add(this.lblExaminationState);
            this.gbExamineeInfo.Controls.Add(this.cbExaminationName);
            this.gbExamineeInfo.Controls.Add(this.lblExaminationName);
            this.gbExamineeInfo.Controls.Add(this.txtExamineeCompanyName);
            this.gbExamineeInfo.Controls.Add(this.btnChoiceExaminee);
            this.gbExamineeInfo.Controls.Add(this.txtExamineeID);
            this.gbExamineeInfo.Controls.Add(this.lblExamineeID);
            this.gbExamineeInfo.Controls.Add(this.lblExamineeCompany);
            this.gbExamineeInfo.Controls.Add(this.txtExamineeName);
            this.gbExamineeInfo.Controls.Add(this.lblExamineeName);
            this.gbExamineeInfo.Location = new System.Drawing.Point(12, 12);
            this.gbExamineeInfo.Name = "gbExamineeInfo";
            this.gbExamineeInfo.Size = new System.Drawing.Size(506, 375);
            this.gbExamineeInfo.TabIndex = 1;
            this.gbExamineeInfo.TabStop = false;
            // 
            // txtIDCardNum
            // 
            this.txtIDCardNum.Enabled = false;
            this.txtIDCardNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIDCardNum.Location = new System.Drawing.Point(99, 99);
            this.txtIDCardNum.Name = "txtIDCardNum";
            this.txtIDCardNum.Size = new System.Drawing.Size(261, 29);
            this.txtIDCardNum.TabIndex = 15;
            // 
            // lblIDCardNum
            // 
            this.lblIDCardNum.AutoSize = true;
            this.lblIDCardNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIDCardNum.Location = new System.Drawing.Point(19, 102);
            this.lblIDCardNum.Name = "lblIDCardNum";
            this.lblIDCardNum.Size = new System.Drawing.Size(90, 21);
            this.lblIDCardNum.TabIndex = 14;
            this.lblIDCardNum.Text = "身份证号：";
            // 
            // imgExamState
            // 
            this.imgExamState.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgExamState.Location = new System.Drawing.Point(97, 270);
            this.imgExamState.Name = "imgExamState";
            this.imgExamState.Size = new System.Drawing.Size(171, 50);
            this.imgExamState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgExamState.TabIndex = 13;
            this.imgExamState.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(399, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "关  闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblExaminationState
            // 
            this.lblExaminationState.AutoSize = true;
            this.lblExaminationState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationState.Location = new System.Drawing.Point(17, 270);
            this.lblExaminationState.Name = "lblExaminationState";
            this.lblExaminationState.Size = new System.Drawing.Size(90, 21);
            this.lblExaminationState.TabIndex = 10;
            this.lblExaminationState.Text = "考试状态：";
            // 
            // cbExaminationName
            // 
            this.cbExaminationName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExaminationName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbExaminationName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbExaminationName.FormattingEnabled = true;
            this.cbExaminationName.Location = new System.Drawing.Point(97, 224);
            this.cbExaminationName.MaxDropDownItems = 50;
            this.cbExaminationName.Name = "cbExaminationName";
            this.cbExaminationName.Size = new System.Drawing.Size(403, 29);
            this.cbExaminationName.TabIndex = 9;
            // 
            // lblExaminationName
            // 
            this.lblExaminationName.AutoSize = true;
            this.lblExaminationName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationName.Location = new System.Drawing.Point(17, 227);
            this.lblExaminationName.Name = "lblExaminationName";
            this.lblExaminationName.Size = new System.Drawing.Size(90, 21);
            this.lblExaminationName.TabIndex = 8;
            this.lblExaminationName.Text = "考试名称：";
            // 
            // txtExamineeCompanyName
            // 
            this.txtExamineeCompanyName.Enabled = false;
            this.txtExamineeCompanyName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeCompanyName.Location = new System.Drawing.Point(97, 142);
            this.txtExamineeCompanyName.Name = "txtExamineeCompanyName";
            this.txtExamineeCompanyName.Size = new System.Drawing.Size(261, 29);
            this.txtExamineeCompanyName.TabIndex = 7;
            // 
            // btnChoiceExaminee
            // 
            this.btnChoiceExaminee.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChoiceExaminee.Location = new System.Drawing.Point(205, 16);
            this.btnChoiceExaminee.Name = "btnChoiceExaminee";
            this.btnChoiceExaminee.Size = new System.Drawing.Size(100, 30);
            this.btnChoiceExaminee.TabIndex = 1;
            this.btnChoiceExaminee.Text = "选择考生";
            this.btnChoiceExaminee.UseVisualStyleBackColor = true;
            this.btnChoiceExaminee.Click += new System.EventHandler(this.btnChoiceExaminee_Click);
            // 
            // txtExamineeID
            // 
            this.txtExamineeID.Enabled = false;
            this.txtExamineeID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeID.Location = new System.Drawing.Point(99, 17);
            this.txtExamineeID.Name = "txtExamineeID";
            this.txtExamineeID.Size = new System.Drawing.Size(100, 29);
            this.txtExamineeID.TabIndex = 3;
            // 
            // lblExamineeID
            // 
            this.lblExamineeID.AutoSize = true;
            this.lblExamineeID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeID.Location = new System.Drawing.Point(19, 20);
            this.lblExamineeID.Name = "lblExamineeID";
            this.lblExamineeID.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeID.TabIndex = 2;
            this.lblExamineeID.Text = "考生编号：";
            // 
            // lblExamineeCompany
            // 
            this.lblExamineeCompany.AutoSize = true;
            this.lblExamineeCompany.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeCompany.Location = new System.Drawing.Point(19, 145);
            this.lblExamineeCompany.Name = "lblExamineeCompany";
            this.lblExamineeCompany.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeCompany.TabIndex = 6;
            this.lblExamineeCompany.Text = "所属公司：";
            // 
            // txtExamineeName
            // 
            this.txtExamineeName.Enabled = false;
            this.txtExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeName.Location = new System.Drawing.Point(99, 57);
            this.txtExamineeName.Name = "txtExamineeName";
            this.txtExamineeName.Size = new System.Drawing.Size(100, 29);
            this.txtExamineeName.TabIndex = 5;
            // 
            // lblExamineeName
            // 
            this.lblExamineeName.AutoSize = true;
            this.lblExamineeName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeName.Location = new System.Drawing.Point(19, 60);
            this.lblExamineeName.Name = "lblExamineeName";
            this.lblExamineeName.Size = new System.Drawing.Size(90, 21);
            this.lblExamineeName.TabIndex = 4;
            this.lblExamineeName.Text = "考生姓名：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtExamPCState);
            this.groupBox1.Controls.Add(this.lblExaminationPCState);
            this.groupBox1.Controls.Add(this.txtExamPCName);
            this.groupBox1.Controls.Add(this.lblExaminationPC);
            this.groupBox1.Location = new System.Drawing.Point(12, 393);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtExamPCState
            // 
            this.txtExamPCState.AutoSize = true;
            this.txtExamPCState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamPCState.Location = new System.Drawing.Point(290, 23);
            this.txtExamPCState.Name = "txtExamPCState";
            this.txtExamPCState.Size = new System.Drawing.Size(81, 21);
            this.txtExamPCState.TabIndex = 3;
            this.txtExamPCState.Text = "空闲/占用";
            // 
            // lblExaminationPCState
            // 
            this.lblExaminationPCState.AutoSize = true;
            this.lblExaminationPCState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationPCState.Location = new System.Drawing.Point(199, 23);
            this.lblExaminationPCState.Name = "lblExaminationPCState";
            this.lblExaminationPCState.Size = new System.Drawing.Size(106, 21);
            this.lblExaminationPCState.TabIndex = 2;
            this.lblExaminationPCState.Text = "考试机状态：";
            // 
            // txtExamPCName
            // 
            this.txtExamPCName.AutoSize = true;
            this.txtExamPCName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamPCName.Location = new System.Drawing.Point(95, 23);
            this.txtExamPCName.Name = "txtExamPCName";
            this.txtExamPCName.Size = new System.Drawing.Size(35, 21);
            this.txtExamPCName.TabIndex = 1;
            this.txtExamPCName.Text = "1号";
            // 
            // lblExaminationPC
            // 
            this.lblExaminationPC.AutoSize = true;
            this.lblExaminationPC.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationPC.Location = new System.Drawing.Point(33, 23);
            this.lblExaminationPC.Name = "lblExaminationPC";
            this.lblExaminationPC.Size = new System.Drawing.Size(74, 21);
            this.lblExaminationPC.TabIndex = 0;
            this.lblExaminationPC.Text = "考试机：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(49, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "班别：";
            // 
            // txtClassType
            // 
            this.txtClassType.Enabled = false;
            this.txtClassType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClassType.Location = new System.Drawing.Point(99, 183);
            this.txtClassType.Name = "txtClassType";
            this.txtClassType.Size = new System.Drawing.Size(261, 29);
            this.txtClassType.TabIndex = 17;
            // 
            // 回收分配界面
            // 
            this.AcceptButton = this.btnAllotExam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(530, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbButton);
            this.Controls.Add(this.gbExamineeInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "回收分配界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "回收分配";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.回收分配界面_FormClosing);
            this.gbButton.ResumeLayout(false);
            this.gbButton.PerformLayout();
            this.gbExamineeInfo.ResumeLayout(false);
            this.gbExamineeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgExamState)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbButton;
        private System.Windows.Forms.Button btnAllotExam;
        private System.Windows.Forms.Button btnRecycleExam;
        private System.Windows.Forms.GroupBox gbExamineeInfo;
        private System.Windows.Forms.TextBox txtExamineeID;
        private System.Windows.Forms.Label lblExamineeID;
        private System.Windows.Forms.Label lblExamineeCompany;
        private System.Windows.Forms.TextBox txtExamineeName;
        private System.Windows.Forms.Label lblExamineeName;
        private System.Windows.Forms.Button btnChoiceExaminee;
        private System.Windows.Forms.TextBox txtExamineeCompanyName;
        private System.Windows.Forms.ComboBox cbExaminationName;
        private System.Windows.Forms.Label lblExaminationName;
        private System.Windows.Forms.Label lblExaminationState;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtExamPCName;
        private System.Windows.Forms.Label lblExaminationPC;
        private System.Windows.Forms.Label txtExamPCState;
        private System.Windows.Forms.Label lblExaminationPCState;
        private System.Windows.Forms.PictureBox imgExamState;
        private System.Windows.Forms.TextBox txtIDCardNum;
        private System.Windows.Forms.Label lblIDCardNum;
        private System.Windows.Forms.Button btnReExam;
        private System.Windows.Forms.Label lblExamOrPrac;
        private System.Windows.Forms.TextBox txtClassType;
        private System.Windows.Forms.Label label1;
    }
}