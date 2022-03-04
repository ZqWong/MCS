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
            this.LoginContentPanel = new Sunny.UI.UIPanel();
            this.Password = new Sunny.UI.UITextBox();
            this.Username = new Sunny.UI.UITextBox();
            this.LoginTitle = new Sunny.UI.UIMarkLabel();
            this.LoginButton = new Sunny.UI.UISymbolButton();
            this.CanelButton = new Sunny.UI.UISymbolButton();
            this.LoginContentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginContentPanel
            // 
            this.LoginContentPanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LoginContentPanel.Controls.Add(this.CanelButton);
            this.LoginContentPanel.Controls.Add(this.LoginButton);
            this.LoginContentPanel.Controls.Add(this.Password);
            this.LoginContentPanel.Controls.Add(this.Username);
            this.LoginContentPanel.Controls.Add(this.LoginTitle);
            this.LoginContentPanel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginContentPanel.Location = new System.Drawing.Point(858, 203);
            this.LoginContentPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoginContentPanel.MinimumSize = new System.Drawing.Size(1, 1);
            this.LoginContentPanel.Name = "LoginContentPanel";
            this.LoginContentPanel.Size = new System.Drawing.Size(270, 300);
            this.LoginContentPanel.TabIndex = 0;
            this.LoginContentPanel.Text = null;
            this.LoginContentPanel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Password
            // 
            this.Password.ButtonSymbol = 61761;
            this.Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Password.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Password.Location = new System.Drawing.Point(20, 200);
            this.Password.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.Password.Maximum = 2147483647D;
            this.Password.Minimum = -2147483648D;
            this.Password.MinimumSize = new System.Drawing.Size(1, 16);
            this.Password.Name = "Password";
            this.Password.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(230, 30);
            this.Password.TabIndex = 3;
            this.Password.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Password.Watermark = "请输入密码";
            // 
            // Username
            // 
            this.Username.ButtonSymbol = 61761;
            this.Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Username.EnterAsTab = true;
            this.Username.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.Username.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Username.Location = new System.Drawing.Point(20, 150);
            this.Username.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.Username.Maximum = 2147483647D;
            this.Username.Minimum = -2147483648D;
            this.Username.MinimumSize = new System.Drawing.Size(1, 16);
            this.Username.Name = "Username";
            this.Username.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.Username.Size = new System.Drawing.Size(230, 30);
            this.Username.TabIndex = 1;
            this.Username.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.Username.Watermark = "请输入用户名";
            // 
            // LoginTitle
            // 
            this.LoginTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LoginTitle.BackColor = System.Drawing.Color.Transparent;
            this.LoginTitle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginTitle.Location = new System.Drawing.Point(82, 100);
            this.LoginTitle.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.LoginTitle.MarkPos = Sunny.UI.UIMarkLabel.UIMarkPos.Bottom;
            this.LoginTitle.Name = "LoginTitle";
            this.LoginTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.LoginTitle.Size = new System.Drawing.Size(100, 30);
            this.LoginTitle.Style = Sunny.UI.UIStyle.Custom;
            this.LoginTitle.TabIndex = 0;
            this.LoginTitle.Text = "用户登录";
            this.LoginTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LoginButton
            // 
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginButton.Location = new System.Drawing.Point(20, 250);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.LoginButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(110, 30);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.Text = "登录";
            this.LoginButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // CanelButton
            // 
            this.CanelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CanelButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CanelButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CanelButton.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.CanelButton.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.CanelButton.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.CanelButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CanelButton.Location = new System.Drawing.Point(140, 250);
            this.CanelButton.Margin = new System.Windows.Forms.Padding(20, 10, 20, 20);
            this.CanelButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.CanelButton.Name = "CanelButton";
            this.CanelButton.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.CanelButton.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.CanelButton.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.CanelButton.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.CanelButton.Size = new System.Drawing.Size(110, 30);
            this.CanelButton.Style = Sunny.UI.UIStyle.Red;
            this.CanelButton.Symbol = 61453;
            this.CanelButton.TabIndex = 4;
            this.CanelButton.Text = "取消";
            this.CanelButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // OCC_Login
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1274, 727);
            this.Controls.Add(this.LoginContentPanel);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OCC_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.LoginContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel LoginContentPanel;
        private Sunny.UI.UIMarkLabel LoginTitle;
        private Sunny.UI.UITextBox Password;
        private Sunny.UI.UITextBox Username;
        private Sunny.UI.UISymbolButton LoginButton;
        private Sunny.UI.UISymbolButton CanelButton;
    }
}