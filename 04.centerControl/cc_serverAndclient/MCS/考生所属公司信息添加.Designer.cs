namespace MCS
{
    partial class 考生所属公司信息添加
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(考生所属公司信息添加));
            this.gbExamineeCompany = new System.Windows.Forms.GroupBox();
            this.lblTipNeedInput = new System.Windows.Forms.Label();
            this.txtExamineeCompanyName = new System.Windows.Forms.TextBox();
            this.lblExamineeCompanyName = new System.Windows.Forms.Label();
            this.gbButton = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddExamineeCompanyInfo = new System.Windows.Forms.Button();
            this.gbExamineeCompany.SuspendLayout();
            this.gbButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbExamineeCompany
            // 
            this.gbExamineeCompany.Controls.Add(this.lblTipNeedInput);
            this.gbExamineeCompany.Controls.Add(this.txtExamineeCompanyName);
            this.gbExamineeCompany.Controls.Add(this.lblExamineeCompanyName);
            this.gbExamineeCompany.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbExamineeCompany.Location = new System.Drawing.Point(12, 12);
            this.gbExamineeCompany.Name = "gbExamineeCompany";
            this.gbExamineeCompany.Size = new System.Drawing.Size(559, 70);
            this.gbExamineeCompany.TabIndex = 0;
            this.gbExamineeCompany.TabStop = false;
            // 
            // lblTipNeedInput
            // 
            this.lblTipNeedInput.AutoSize = true;
            this.lblTipNeedInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipNeedInput.ForeColor = System.Drawing.Color.Red;
            this.lblTipNeedInput.Location = new System.Drawing.Point(481, 23);
            this.lblTipNeedInput.Name = "lblTipNeedInput";
            this.lblTipNeedInput.Size = new System.Drawing.Size(75, 21);
            this.lblTipNeedInput.TabIndex = 2;
            this.lblTipNeedInput.Text = "(*)必填。";
            // 
            // txtExamineeCompanyName
            // 
            this.txtExamineeCompanyName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExamineeCompanyName.Location = new System.Drawing.Point(154, 20);
            this.txtExamineeCompanyName.Name = "txtExamineeCompanyName";
            this.txtExamineeCompanyName.Size = new System.Drawing.Size(325, 29);
            this.txtExamineeCompanyName.TabIndex = 1;
            this.txtExamineeCompanyName.TextChanged += new System.EventHandler(this.txtExamineeCompanyName_TextChanged);
            // 
            // lblExamineeCompanyName
            // 
            this.lblExamineeCompanyName.AutoSize = true;
            this.lblExamineeCompanyName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExamineeCompanyName.Location = new System.Drawing.Point(10, 23);
            this.lblExamineeCompanyName.Name = "lblExamineeCompanyName";
            this.lblExamineeCompanyName.Size = new System.Drawing.Size(154, 21);
            this.lblExamineeCompanyName.TabIndex = 0;
            this.lblExamineeCompanyName.Text = "考生所属公司名称：";
            // 
            // gbButton
            // 
            this.gbButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbButton.Controls.Add(this.btnDelete);
            this.gbButton.Controls.Add(this.btnClose);
            this.gbButton.Controls.Add(this.btnAddExamineeCompanyInfo);
            this.gbButton.Location = new System.Drawing.Point(12, 88);
            this.gbButton.Name = "gbButton";
            this.gbButton.Size = new System.Drawing.Size(559, 75);
            this.gbButton.TabIndex = 1;
            this.gbButton.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(453, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "删 除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(296, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddExamineeCompanyInfo
            // 
            this.btnAddExamineeCompanyInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddExamineeCompanyInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddExamineeCompanyInfo.Location = new System.Drawing.Point(176, 25);
            this.btnAddExamineeCompanyInfo.Name = "btnAddExamineeCompanyInfo";
            this.btnAddExamineeCompanyInfo.Size = new System.Drawing.Size(100, 30);
            this.btnAddExamineeCompanyInfo.TabIndex = 0;
            this.btnAddExamineeCompanyInfo.Text = "添 加";
            this.btnAddExamineeCompanyInfo.UseVisualStyleBackColor = true;
            this.btnAddExamineeCompanyInfo.Click += new System.EventHandler(this.btnAddExamineeCompanyInfo_Click);
            // 
            // 考生所属公司信息添加
            // 
            this.AcceptButton = this.btnAddExamineeCompanyInfo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(582, 175);
            this.Controls.Add(this.gbButton);
            this.Controls.Add(this.gbExamineeCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "考生所属公司信息添加";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "考生所属公司信息添加";
            this.gbExamineeCompany.ResumeLayout(false);
            this.gbExamineeCompany.PerformLayout();
            this.gbButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbExamineeCompany;
        private System.Windows.Forms.Label lblTipNeedInput;
        private System.Windows.Forms.TextBox txtExamineeCompanyName;
        private System.Windows.Forms.Label lblExamineeCompanyName;
        private System.Windows.Forms.GroupBox gbButton;
        private System.Windows.Forms.Button btnAddExamineeCompanyInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
    }
}
