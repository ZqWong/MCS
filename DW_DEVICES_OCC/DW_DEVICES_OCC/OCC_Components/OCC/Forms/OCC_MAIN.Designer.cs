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
            this.MainFormContent = new System.Windows.Forms.Panel();
            this.SettingDropDownMenu = new Sunny.UI.UIContextMenuStrip();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingDropDownMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormContent
            // 
            this.MainFormContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainFormContent.AutoScroll = true;
            this.MainFormContent.Location = new System.Drawing.Point(3, 37);
            this.MainFormContent.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.MainFormContent.Name = "MainFormContent";
            this.MainFormContent.Size = new System.Drawing.Size(1274, 727);
            this.MainFormContent.TabIndex = 0;
            // 
            // SettingDropDownMenu
            // 
            this.SettingDropDownMenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SettingDropDownMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统设置ToolStripMenuItem});
            this.SettingDropDownMenu.Name = "SettingDropDownMenu";
            this.SettingDropDownMenu.Size = new System.Drawing.Size(145, 30);
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // OCC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.MainFormContent);
            this.ExtendBox = true;
            this.ExtendMenu = this.SettingDropDownMenu;
            this.ExtendSymbol = 61459;
            this.ExtendSymbolOffset = new System.Drawing.Point(0, 1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "OCC";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.Text = "OCC";
            this.Load += new System.EventHandler(this.OCC_MAIN_Load);
            this.SettingDropDownMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainFormContent;
        private Sunny.UI.UIContextMenuStrip SettingDropDownMenu;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
    }
}