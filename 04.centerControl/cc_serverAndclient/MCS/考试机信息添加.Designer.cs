namespace MCS
{
    partial class 考试机添加界面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(考试机添加界面));
            this.gbButton = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbExamineeInfo = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnPrac = new System.Windows.Forms.RadioButton();
            this.rdBtnExam = new System.Windows.Forms.RadioButton();
            this.lblType = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnGetMac = new System.Windows.Forms.Button();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.lblMac = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.gbButton.SuspendLayout();
            this.gbExamineeInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbButton
            // 
            this.gbButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbButton.Controls.Add(this.btnClose);
            this.gbButton.Controls.Add(this.btnAdd);
            this.gbButton.Location = new System.Drawing.Point(12, 250);
            this.gbButton.Name = "gbButton";
            this.gbButton.Size = new System.Drawing.Size(468, 73);
            this.gbButton.TabIndex = 1;
            this.gbButton.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(243, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(126, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添 加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbExamineeInfo
            // 
            this.gbExamineeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExamineeInfo.Controls.Add(this.groupBox1);
            this.gbExamineeInfo.Controls.Add(this.lblType);
            this.gbExamineeInfo.Controls.Add(this.txtID);
            this.gbExamineeInfo.Controls.Add(this.txtName);
            this.gbExamineeInfo.Controls.Add(this.lblName);
            this.gbExamineeInfo.Controls.Add(this.btnGetMac);
            this.gbExamineeInfo.Controls.Add(this.txtMac);
            this.gbExamineeInfo.Controls.Add(this.lblMac);
            this.gbExamineeInfo.Controls.Add(this.txtIP);
            this.gbExamineeInfo.Controls.Add(this.lblIP);
            this.gbExamineeInfo.Location = new System.Drawing.Point(12, 12);
            this.gbExamineeInfo.Name = "gbExamineeInfo";
            this.gbExamineeInfo.Size = new System.Drawing.Size(468, 232);
            this.gbExamineeInfo.TabIndex = 0;
            this.gbExamineeInfo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBtnPrac);
            this.groupBox1.Controls.Add(this.rdBtnExam);
            this.groupBox1.Location = new System.Drawing.Point(95, 143);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(161, 58);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // rdBtnPrac
            // 
            this.rdBtnPrac.AutoSize = true;
            this.rdBtnPrac.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdBtnPrac.Location = new System.Drawing.Point(82, 18);
            this.rdBtnPrac.Margin = new System.Windows.Forms.Padding(2);
            this.rdBtnPrac.Name = "rdBtnPrac";
            this.rdBtnPrac.Size = new System.Drawing.Size(76, 25);
            this.rdBtnPrac.TabIndex = 10;
            this.rdBtnPrac.Text = "练习机";
            this.rdBtnPrac.UseVisualStyleBackColor = true;
            // 
            // rdBtnExam
            // 
            this.rdBtnExam.AutoSize = true;
            this.rdBtnExam.Checked = true;
            this.rdBtnExam.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdBtnExam.Location = new System.Drawing.Point(8, 18);
            this.rdBtnExam.Margin = new System.Windows.Forms.Padding(2);
            this.rdBtnExam.Name = "rdBtnExam";
            this.rdBtnExam.Size = new System.Drawing.Size(76, 25);
            this.rdBtnExam.TabIndex = 9;
            this.rdBtnExam.TabStop = true;
            this.rdBtnExam.Text = "考试机";
            this.rdBtnExam.UseVisualStyleBackColor = true;
            this.rdBtnExam.Visible = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblType.Location = new System.Drawing.Point(39, 162);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(62, 21);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type：";
            this.lblType.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(263, 21);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(61, 29);
            this.txtID.TabIndex = 2;
            this.txtID.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(95, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 29);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(25, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 21);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name：";
            // 
            // btnGetMac
            // 
            this.btnGetMac.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetMac.ForeColor = System.Drawing.Color.Black;
            this.btnGetMac.Location = new System.Drawing.Point(263, 109);
            this.btnGetMac.Name = "btnGetMac";
            this.btnGetMac.Size = new System.Drawing.Size(162, 29);
            this.btnGetMac.TabIndex = 7;
            this.btnGetMac.Text = "根据IP获取Mac";
            this.btnGetMac.UseVisualStyleBackColor = true;
            this.btnGetMac.Click += new System.EventHandler(this.btnGetMac_Click);
            // 
            // txtMac
            // 
            this.txtMac.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMac.Location = new System.Drawing.Point(95, 110);
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(162, 29);
            this.txtMac.TabIndex = 6;
            // 
            // lblMac
            // 
            this.lblMac.AutoSize = true;
            this.lblMac.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMac.Location = new System.Drawing.Point(38, 113);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(59, 21);
            this.lblMac.TabIndex = 5;
            this.lblMac.Text = "Mac：";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIP.Location = new System.Drawing.Point(95, 65);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(162, 29);
            this.txtIP.TabIndex = 4;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIP.Location = new System.Drawing.Point(56, 68);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(41, 21);
            this.lblIP.TabIndex = 3;
            this.lblIP.Text = "IP：";
            // 
            // 考试机添加界面
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(492, 335);
            this.Controls.Add(this.gbButton);
            this.Controls.Add(this.gbExamineeInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "考试机添加界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "计算机添加界面";
            this.gbButton.ResumeLayout(false);
            this.gbExamineeInfo.ResumeLayout(false);
            this.gbExamineeInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbButton;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbExamineeInfo;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.Label lblMac;
        private System.Windows.Forms.Button btnGetMac;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton rdBtnPrac;
        private System.Windows.Forms.RadioButton rdBtnExam;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}