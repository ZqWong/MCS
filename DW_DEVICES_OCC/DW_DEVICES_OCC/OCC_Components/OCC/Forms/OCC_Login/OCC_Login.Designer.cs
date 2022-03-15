namespace OCC.Forms
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonCancel = new Sunny.UI.UIButton();
            this.BtnConfirm = new Sunny.UI.UIButton();
            this.TextPassword = new Sunny.UI.UITextBox();
            this.TextUsername = new Sunny.UI.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.ButtonCancel);
            this.panel2.Controls.Add(this.BtnConfirm);
            this.panel2.Controls.Add(this.TextPassword);
            this.panel2.Controls.Add(this.TextUsername);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(706, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 577);
            this.panel2.TabIndex = 1;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonCancel.Location = new System.Drawing.Point(131, 305);
            this.ButtonCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Radius = 15;
            this.ButtonCancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonCancel.Size = new System.Drawing.Size(110, 35);
            this.ButtonCancel.Style = Sunny.UI.UIStyle.Custom;
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "取消";
            this.ButtonCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnConfirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnConfirm.Location = new System.Drawing.Point(7, 305);
            this.BtnConfirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Radius = 15;
            this.BtnConfirm.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnConfirm.Size = new System.Drawing.Size(110, 35);
            this.BtnConfirm.Style = Sunny.UI.UIStyle.Custom;
            this.BtnConfirm.TabIndex = 3;
            this.BtnConfirm.Text = "确认";
            this.BtnConfirm.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // TextPassword
            // 
            this.TextPassword.ButtonSymbol = 61761;
            this.TextPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextPassword.Location = new System.Drawing.Point(7, 268);
            this.TextPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextPassword.Maximum = 2147483647D;
            this.TextPassword.Minimum = -2147483648D;
            this.TextPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.PasswordChar = '*';
            this.TextPassword.Radius = 15;
            this.TextPassword.Size = new System.Drawing.Size(234, 29);
            this.TextPassword.Style = Sunny.UI.UIStyle.Custom;
            this.TextPassword.TabIndex = 2;
            this.TextPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextPassword.Watermark = "请输入密码";
            // 
            // TextUsername
            // 
            this.TextUsername.ButtonSymbol = 61761;
            this.TextUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextUsername.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextUsername.Location = new System.Drawing.Point(7, 229);
            this.TextUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextUsername.Maximum = 2147483647D;
            this.TextUsername.Minimum = -2147483648D;
            this.TextUsername.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextUsername.Name = "TextUsername";
            this.TextUsername.Radius = 15;
            this.TextUsername.Size = new System.Drawing.Size(234, 29);
            this.TextUsername.Style = Sunny.UI.UIStyle.Custom;
            this.TextUsername.TabIndex = 1;
            this.TextUsername.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextUsername.Watermark = "请输入用户名";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 149);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(234, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "登录";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OCC_Login
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OCC_Login";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UIButton ButtonCancel;
        private Sunny.UI.UIButton BtnConfirm;
        private Sunny.UI.UITextBox TextPassword;
        private Sunny.UI.UITextBox TextUsername;
        private System.Windows.Forms.Label label1;
    }
}