namespace MCS
{
    partial class 用户管理
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(用户管理));
            this.lblTip = new System.Windows.Forms.Label();
            this.UserList = new System.Windows.Forms.ListBox();
            this.lblExaminationChildSubject = new System.Windows.Forms.Label();
            this.gbExamineeCompany = new System.Windows.Forms.GroupBox();
            this.lblUserList = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbButton = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbExamineeCompany.SuspendLayout();
            this.gbButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.ForeColor = System.Drawing.Color.Red;
            this.lblTip.Location = new System.Drawing.Point(59, 234);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(267, 21);
            this.lblTip.TabIndex = 3;
            this.lblTip.Text = "(*)双击用户名进行修改和删除操作。";
            // 
            // UserList
            // 
            this.UserList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserList.FormattingEnabled = true;
            this.UserList.ItemHeight = 21;
            this.UserList.Location = new System.Drawing.Point(86, 17);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(201, 214);
            this.UserList.TabIndex = 1;
            this.UserList.DoubleClick += new System.EventHandler(this.UserList_DoubleClick);
            // 
            // lblExaminationChildSubject
            // 
            this.lblExaminationChildSubject.AutoSize = true;
            this.lblExaminationChildSubject.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExaminationChildSubject.Location = new System.Drawing.Point(-30, -84);
            this.lblExaminationChildSubject.Name = "lblExaminationChildSubject";
            this.lblExaminationChildSubject.Size = new System.Drawing.Size(58, 21);
            this.lblExaminationChildSubject.TabIndex = 7;
            this.lblExaminationChildSubject.Text = "子科目";
            // 
            // gbExamineeCompany
            // 
            this.gbExamineeCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExamineeCompany.Controls.Add(this.lblUserList);
            this.gbExamineeCompany.Controls.Add(this.lblTip);
            this.gbExamineeCompany.Controls.Add(this.btnAdd);
            this.gbExamineeCompany.Controls.Add(this.UserList);
            this.gbExamineeCompany.Controls.Add(this.lblExaminationChildSubject);
            this.gbExamineeCompany.Location = new System.Drawing.Point(12, 12);
            this.gbExamineeCompany.Name = "gbExamineeCompany";
            this.gbExamineeCompany.Size = new System.Drawing.Size(424, 270);
            this.gbExamineeCompany.TabIndex = 0;
            this.gbExamineeCompany.TabStop = false;
            // 
            // lblUserList
            // 
            this.lblUserList.AutoSize = true;
            this.lblUserList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserList.Location = new System.Drawing.Point(6, 17);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(78, 21);
            this.lblUserList.TabIndex = 0;
            this.lblUserList.Text = "用户列表:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(309, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添 加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddExamineeCompanyInfo_Click);
            // 
            // gbButton
            // 
            this.gbButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbButton.Controls.Add(this.btnClose);
            this.gbButton.Location = new System.Drawing.Point(12, 287);
            this.gbButton.Name = "gbButton";
            this.gbButton.Size = new System.Drawing.Size(424, 60);
            this.gbButton.TabIndex = 1;
            this.gbButton.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(156, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // 用户管理
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(448, 359);
            this.Controls.Add(this.gbButton);
            this.Controls.Add(this.gbExamineeCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "用户管理";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.用户管理_Load);
            this.gbExamineeCompany.ResumeLayout(false);
            this.gbExamineeCompany.PerformLayout();
            this.gbButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.Label lblExaminationChildSubject;
        private System.Windows.Forms.GroupBox gbExamineeCompany;
        private System.Windows.Forms.GroupBox gbButton;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblUserList;
    }
}