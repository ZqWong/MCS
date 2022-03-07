namespace OCC
{
    partial class OCC
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.LabelAppVersion = new System.Windows.Forms.Label();
            this.SideButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LabelUserRemark = new Sunny.UI.UILabel();
            this.LabelUserName = new Sunny.UI.UILabel();
            this.TaskBar = new System.Windows.Forms.Panel();
            this.PanelContent = new System.Windows.Forms.Panel();
            this.BtnMinimized = new System.Windows.Forms.Button();
            this.BtnMaxMinStateChange = new System.Windows.Forms.Button();
            this.BtnApplicationClose = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.PictureUserIcon = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TaskBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureUserIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.SideButtonPanel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 577);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LabelAppVersion);
            this.panel3.Controls.Add(this.BtnSettings);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 504);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 73);
            this.panel3.TabIndex = 2;
            // 
            // LabelAppVersion
            // 
            this.LabelAppVersion.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LabelAppVersion.Location = new System.Drawing.Point(3, 51);
            this.LabelAppVersion.Name = "LabelAppVersion";
            this.LabelAppVersion.Size = new System.Drawing.Size(180, 19);
            this.LabelAppVersion.TabIndex = 8;
            this.LabelAppVersion.Text = "Ver-0.0.1";
            // 
            // SideButtonPanel
            // 
            this.SideButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SideButtonPanel.Location = new System.Drawing.Point(0, 144);
            this.SideButtonPanel.Name = "SideButtonPanel";
            this.SideButtonPanel.Size = new System.Drawing.Size(186, 357);
            this.SideButtonPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LabelUserRemark);
            this.panel2.Controls.Add(this.LabelUserName);
            this.panel2.Controls.Add(this.PictureUserIcon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 144);
            this.panel2.TabIndex = 0;
            // 
            // LabelUserRemark
            // 
            this.LabelUserRemark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelUserRemark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(178)))));
            this.LabelUserRemark.Location = new System.Drawing.Point(16, 112);
            this.LabelUserRemark.Name = "LabelUserRemark";
            this.LabelUserRemark.Size = new System.Drawing.Size(157, 23);
            this.LabelUserRemark.Style = Sunny.UI.UIStyle.Custom;
            this.LabelUserRemark.TabIndex = 2;
            this.LabelUserRemark.Text = "Some User Text here";
            this.LabelUserRemark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelUserName
            // 
            this.LabelUserName.BackColor = System.Drawing.Color.Transparent;
            this.LabelUserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(249)))));
            this.LabelUserName.Location = new System.Drawing.Point(12, 89);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(161, 23);
            this.LabelUserName.Style = Sunny.UI.UIStyle.Custom;
            this.LabelUserName.TabIndex = 1;
            this.LabelUserName.Text = "User Name";
            this.LabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaskBar
            // 
            this.TaskBar.Controls.Add(this.BtnMinimized);
            this.TaskBar.Controls.Add(this.BtnMaxMinStateChange);
            this.TaskBar.Controls.Add(this.BtnApplicationClose);
            this.TaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TaskBar.Location = new System.Drawing.Point(186, 0);
            this.TaskBar.Name = "TaskBar";
            this.TaskBar.Size = new System.Drawing.Size(765, 30);
            this.TaskBar.TabIndex = 1;
            // 
            // PanelContent
            // 
            this.PanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContent.Location = new System.Drawing.Point(186, 30);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(765, 547);
            this.PanelContent.TabIndex = 2;
            // 
            // BtnMinimized
            // 
            this.BtnMinimized.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMinimized.FlatAppearance.BorderSize = 0;
            this.BtnMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimized.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnMinimized.Image = global::OCC.Properties.Resources.最小化_btn;
            this.BtnMinimized.Location = new System.Drawing.Point(675, 0);
            this.BtnMinimized.Name = "BtnMinimized";
            this.BtnMinimized.Size = new System.Drawing.Size(30, 30);
            this.BtnMinimized.TabIndex = 2;
            this.BtnMinimized.UseVisualStyleBackColor = true;
            this.BtnMinimized.Click += new System.EventHandler(this.BtnMinimized_Click);
            // 
            // BtnMaxMinStateChange
            // 
            this.BtnMaxMinStateChange.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMaxMinStateChange.FlatAppearance.BorderSize = 0;
            this.BtnMaxMinStateChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMaxMinStateChange.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnMaxMinStateChange.Image = global::OCC.Properties.Resources.最大化_btn;
            this.BtnMaxMinStateChange.Location = new System.Drawing.Point(705, 0);
            this.BtnMaxMinStateChange.Name = "BtnMaxMinStateChange";
            this.BtnMaxMinStateChange.Size = new System.Drawing.Size(30, 30);
            this.BtnMaxMinStateChange.TabIndex = 1;
            this.BtnMaxMinStateChange.UseVisualStyleBackColor = true;
            this.BtnMaxMinStateChange.Click += new System.EventHandler(this.BtnMaxMinStateChange_Click);
            // 
            // BtnApplicationClose
            // 
            this.BtnApplicationClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnApplicationClose.FlatAppearance.BorderSize = 0;
            this.BtnApplicationClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApplicationClose.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnApplicationClose.Image = global::OCC.Properties.Resources.关闭_btn;
            this.BtnApplicationClose.Location = new System.Drawing.Point(735, 0);
            this.BtnApplicationClose.Name = "BtnApplicationClose";
            this.BtnApplicationClose.Size = new System.Drawing.Size(30, 30);
            this.BtnApplicationClose.TabIndex = 0;
            this.BtnApplicationClose.UseVisualStyleBackColor = true;
            this.BtnApplicationClose.Click += new System.EventHandler(this.BtnApplicationClose_Click);
            // 
            // BtnSettings
            // 
            this.BtnSettings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSettings.FlatAppearance.BorderSize = 2;
            this.BtnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(100)))));
            this.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettings.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnSettings.Image = global::OCC.Properties.Resources.设置_btn;
            this.BtnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSettings.Location = new System.Drawing.Point(3, 3);
            this.BtnSettings.MaximumSize = new System.Drawing.Size(180, 45);
            this.BtnSettings.MinimumSize = new System.Drawing.Size(180, 45);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Padding = new System.Windows.Forms.Padding(3);
            this.BtnSettings.Size = new System.Drawing.Size(180, 45);
            this.BtnSettings.TabIndex = 7;
            this.BtnSettings.Text = "设置";
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // PictureUserIcon
            // 
            this.PictureUserIcon.Location = new System.Drawing.Point(60, 22);
            this.PictureUserIcon.Name = "PictureUserIcon";
            this.PictureUserIcon.Size = new System.Drawing.Size(64, 64);
            this.PictureUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureUserIcon.TabIndex = 0;
            this.PictureUserIcon.TabStop = false;
            // 
            // OCC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.PanelContent);
            this.Controls.Add(this.TaskBar);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(951, 577);
            this.Name = "OCC";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OCC";
            this.Load += new System.EventHandler(this.OCC_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.TaskBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureUserIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PictureUserIcon;
        private Sunny.UI.UILabel LabelUserName;
        private Sunny.UI.UILabel LabelUserRemark;
        private System.Windows.Forms.FlowLayoutPanel SideButtonPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Label LabelAppVersion;
        private System.Windows.Forms.Panel TaskBar;
        private System.Windows.Forms.Button BtnApplicationClose;
        private System.Windows.Forms.Button BtnMinimized;
        private System.Windows.Forms.Button BtnMaxMinStateChange;
        private System.Windows.Forms.Panel PanelContent;
    }
}