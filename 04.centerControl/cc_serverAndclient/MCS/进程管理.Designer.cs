namespace MCS
{
    partial class 进程管理
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.增加应用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除应用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_edit = new System.Windows.Forms.Panel();
            this.checkBox_checkAll = new System.Windows.Forms.CheckBox();
            this.dataGridView_process_edit = new System.Windows.Forms.DataGridView();
            this.comboBox_appName = new System.Windows.Forms.ComboBox();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit_AppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit_FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panel_edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_process_edit)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加应用ToolStripMenuItem,
            this.删除应用ToolStripMenuItem,
            this.运行ToolStripMenuItem,
            this.关闭ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.刷新ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 增加应用ToolStripMenuItem
            // 
            this.增加应用ToolStripMenuItem.Name = "增加应用ToolStripMenuItem";
            this.增加应用ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.增加应用ToolStripMenuItem.Text = "增加应用";
            this.增加应用ToolStripMenuItem.Click += new System.EventHandler(this.增加应用ToolStripMenuItem_Click);
            // 
            // 删除应用ToolStripMenuItem
            // 
            this.删除应用ToolStripMenuItem.Name = "删除应用ToolStripMenuItem";
            this.删除应用ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.删除应用ToolStripMenuItem.Text = "删除应用";
            this.删除应用ToolStripMenuItem.Click += new System.EventHandler(this.删除应用ToolStripMenuItem_Click);
            // 
            // 运行ToolStripMenuItem
            // 
            this.运行ToolStripMenuItem.Name = "运行ToolStripMenuItem";
            this.运行ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.运行ToolStripMenuItem.Text = "运行进程";
            this.运行ToolStripMenuItem.Click += new System.EventHandler(this.运行ToolStripMenuItem_Click);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.关闭ToolStripMenuItem.Text = "关闭进程";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(118, 25);
            this.保存ToolStripMenuItem.Text = "保存到数据库";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // panel_edit
            // 
            this.panel_edit.Controls.Add(this.checkBox_checkAll);
            this.panel_edit.Controls.Add(this.dataGridView_process_edit);
            this.panel_edit.Controls.Add(this.comboBox_appName);
            this.panel_edit.Location = new System.Drawing.Point(12, 48);
            this.panel_edit.Name = "panel_edit";
            this.panel_edit.Size = new System.Drawing.Size(876, 611);
            this.panel_edit.TabIndex = 3;
            this.panel_edit.Visible = false;
            // 
            // checkBox_checkAll
            // 
            this.checkBox_checkAll.AutoSize = true;
            this.checkBox_checkAll.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_checkAll.Location = new System.Drawing.Point(210, 582);
            this.checkBox_checkAll.Name = "checkBox_checkAll";
            this.checkBox_checkAll.Size = new System.Drawing.Size(56, 24);
            this.checkBox_checkAll.TabIndex = 6;
            this.checkBox_checkAll.Text = "全选";
            this.checkBox_checkAll.UseVisualStyleBackColor = true;
            this.checkBox_checkAll.CheckedChanged += new System.EventHandler(this.checkBox_checkAll_CheckedChanged);
            // 
            // dataGridView_process_edit
            // 
            this.dataGridView_process_edit.AllowUserToAddRows = false;
            this.dataGridView_process_edit.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_process_edit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_process_edit.ColumnHeadersHeight = 30;
            this.dataGridView_process_edit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_process_edit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.Edit_ID,
            this.Edit_IP,
            this.Edit_AppName,
            this.Edit_FilePath});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_process_edit.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_process_edit.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_process_edit.Name = "dataGridView_process_edit";
            this.dataGridView_process_edit.RowHeadersWidth = 40;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_process_edit.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_process_edit.RowTemplate.Height = 40;
            this.dataGridView_process_edit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_process_edit.Size = new System.Drawing.Size(865, 564);
            this.dataGridView_process_edit.TabIndex = 2;
            // 
            // comboBox_appName
            // 
            this.comboBox_appName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_appName.FormattingEnabled = true;
            this.comboBox_appName.Location = new System.Drawing.Point(3, 580);
            this.comboBox_appName.Name = "comboBox_appName";
            this.comboBox_appName.Size = new System.Drawing.Size(201, 28);
            this.comboBox_appName.TabIndex = 0;
            this.comboBox_appName.Text = "应用名称";
            this.comboBox_appName.SelectedIndexChanged += new System.EventHandler(this.comboBox_appName_SelectedIndexChanged);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.MinimumWidth = 30;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 30;
            // 
            // Edit_ID
            // 
            this.Edit_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Edit_ID.FillWeight = 20F;
            this.Edit_ID.HeaderText = "ID";
            this.Edit_ID.Name = "Edit_ID";
            this.Edit_ID.Visible = false;
            this.Edit_ID.Width = 49;
            // 
            // Edit_IP
            // 
            this.Edit_IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Edit_IP.HeaderText = "IP";
            this.Edit_IP.Name = "Edit_IP";
            this.Edit_IP.ReadOnly = true;
            this.Edit_IP.Width = 47;
            // 
            // Edit_AppName
            // 
            this.Edit_AppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Edit_AppName.HeaderText = "APP名称";
            this.Edit_AppName.Name = "Edit_AppName";
            this.Edit_AppName.Width = 90;
            // 
            // Edit_FilePath
            // 
            this.Edit_FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Edit_FilePath.HeaderText = "执行路径";
            this.Edit_FilePath.Name = "Edit_FilePath";
            // 
            // 进程管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 671);
            this.Controls.Add(this.panel_edit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "进程管理";
            this.Text = "应用管理";
            this.Load += new System.EventHandler(this.进程管理_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_edit.ResumeLayout(false);
            this.panel_edit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_process_edit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel_edit;
        private System.Windows.Forms.DataGridView dataGridView_process_edit;
        private System.Windows.Forms.ComboBox comboBox_appName;
        private System.Windows.Forms.CheckBox checkBox_checkAll;
        private System.Windows.Forms.ToolStripMenuItem 增加应用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除应用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit_AppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit_FilePath;
    }
}