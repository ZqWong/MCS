namespace OCC.Forms.OCC_Login
{
    partial class OCC_Login
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.TextPassword = new Sunny.UI.UITextBox();
            this.TextUsername = new Sunny.UI.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(691, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 577);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel2.Controls.Add(this.BtnCancel);
            this.panel2.Controls.Add(this.BtnConfirm);
            this.panel2.Controls.Add(this.TextPassword);
            this.panel2.Controls.Add(this.TextUsername);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 241);
            this.panel2.TabIndex = 0;
            // 
            // TextPassword
            // 
            this.TextPassword.ButtonSymbol = 61761;
            this.TextPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextPassword.Location = new System.Drawing.Point(7, 114);
            this.TextPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextPassword.Maximum = 2147483647D;
            this.TextPassword.Minimum = -2147483648D;
            this.TextPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.PasswordChar = '*';
            this.TextPassword.Size = new System.Drawing.Size(234, 29);
            this.TextPassword.TabIndex = 2;
            this.TextPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextPassword.Watermark = "请输入密码";
            // 
            // TextUsername
            // 
            this.TextUsername.ButtonSymbol = 61761;
            this.TextUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextUsername.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextUsername.Location = new System.Drawing.Point(7, 64);
            this.TextUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextUsername.Maximum = 2147483647D;
            this.TextUsername.Minimum = -2147483648D;
            this.TextUsername.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextUsername.Name = "TextUsername";
            this.TextUsername.Size = new System.Drawing.Size(234, 29);
            this.TextUsername.TabIndex = 1;
            this.TextUsername.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextUsername.Watermark = "请输入用户名";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "登录";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnCancel.FlatAppearance.BorderSize = 2;
            this.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(100)))));
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnCancel.Image = global::OCC.Properties.Resources.取消_icon;
            this.BtnCancel.Location = new System.Drawing.Point(131, 172);
            this.BtnCancel.MaximumSize = new System.Drawing.Size(180, 45);
            this.BtnCancel.MinimumSize = new System.Drawing.Size(50, 20);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Padding = new System.Windows.Forms.Padding(3);
            this.BtnCancel.Size = new System.Drawing.Size(110, 40);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "  取消";
            this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnConfirm.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnConfirm.FlatAppearance.BorderSize = 2;
            this.BtnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(100)))));
            this.BtnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirm.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnConfirm.Image = global::OCC.Properties.Resources.对号_icon;
            this.BtnConfirm.Location = new System.Drawing.Point(7, 172);
            this.BtnConfirm.MaximumSize = new System.Drawing.Size(180, 45);
            this.BtnConfirm.MinimumSize = new System.Drawing.Size(50, 20);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Padding = new System.Windows.Forms.Padding(3);
            this.BtnConfirm.Size = new System.Drawing.Size(110, 40);
            this.BtnConfirm.TabIndex = 8;
            this.BtnConfirm.Text = "  登录";
            this.BtnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // OCC_Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OCC_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UITextBox TextUsername;
        private Sunny.UI.UITextBox TextPassword;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Button BtnCancel;
    }
}