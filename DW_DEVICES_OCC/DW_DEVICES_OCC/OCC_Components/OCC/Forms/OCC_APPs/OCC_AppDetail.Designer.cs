namespace OCC.Forms.OCC_Users
{
    partial class OCC_AppDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.TextBoxAPPPath = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxAPPName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 396);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.TextBoxAPPName);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.TextBoxAPPPath);
            this.panel4.Controls.Add(this.UserNameLabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(384, 396);
            this.panel4.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(316, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "*";
            // 
            // TextBoxAPPPath
            // 
            this.TextBoxAPPPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxAPPPath.Location = new System.Drawing.Point(110, 41);
            this.TextBoxAPPPath.Name = "TextBoxAPPPath";
            this.TextBoxAPPPath.Size = new System.Drawing.Size(200, 23);
            this.TextBoxAPPPath.TabIndex = 1;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.UserNameLabel.Location = new System.Drawing.Point(4, 41);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Padding = new System.Windows.Forms.Padding(3);
            this.UserNameLabel.Size = new System.Drawing.Size(74, 23);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "应用路径：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnConfirm);
            this.panel3.Controls.Add(this.BtnCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(384, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.panel3.Size = new System.Drawing.Size(120, 396);
            this.panel3.TabIndex = 0;
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnConfirm.FlatAppearance.BorderSize = 2;
            this.BtnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(100)))));
            this.BtnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirm.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConfirm.Location = new System.Drawing.Point(0, 296);
            this.BtnConfirm.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.BtnConfirm.MaximumSize = new System.Drawing.Size(180, 45);
            this.BtnConfirm.MinimumSize = new System.Drawing.Size(100, 45);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Padding = new System.Windows.Forms.Padding(3);
            this.BtnConfirm.Size = new System.Drawing.Size(110, 45);
            this.BtnConfirm.TabIndex = 9;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnCancel.FlatAppearance.BorderSize = 2;
            this.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(100)))));
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(0, 341);
            this.BtnCancel.MaximumSize = new System.Drawing.Size(180, 45);
            this.BtnCancel.MinimumSize = new System.Drawing.Size(100, 45);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Padding = new System.Windows.Forms.Padding(3);
            this.BtnCancel.Size = new System.Drawing.Size(110, 45);
            this.BtnCancel.TabIndex = 8;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(316, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "*";
            // 
            // TextBoxAPPName
            // 
            this.TextBoxAPPName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxAPPName.Location = new System.Drawing.Point(110, 12);
            this.TextBoxAPPName.Name = "TextBoxAPPName";
            this.TextBoxAPPName.Size = new System.Drawing.Size(200, 23);
            this.TextBoxAPPName.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(4, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(62, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "应用名：";
            // 
            // OCC_AppDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(504, 396);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "OCC_AppDetail";
            this.Text = "OCC_UserDetail";
            this.Load += new System.EventHandler(this.OCC_AppDetail_Load);
            this.Shown += new System.EventHandler(this.OCC_AppDetail_Shown);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox TextBoxAPPPath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxAPPName;
        private System.Windows.Forms.Label label2;
    }
}