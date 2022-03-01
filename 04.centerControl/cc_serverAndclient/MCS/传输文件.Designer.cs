namespace MCS
{
    partial class 传输文件
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(传输文件));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_all = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_clientList = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProgressCur = new System.Windows.Forms.Label();
            this.progressBarTotal = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog_ForSaveFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.opnFlDlgSrc = new System.Windows.Forms.OpenFileDialog();
            this.opnFldBrowserSrc = new System.Windows.Forms.FolderBrowserDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_error = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_cip = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBox_currentDirectoryEditor = new System.Windows.Forms.ComboBox();
            this.button_gohome = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.listView_content = new System.Windows.Forms.ListView();
            this.mContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.发送文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.文件夹ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.发送文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.远程执行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加应用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_clientList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_all);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.dataGridView_clientList);
            this.groupBox4.Controls.Add(this.lblProgressCur);
            this.groupBox4.Controls.Add(this.progressBarTotal);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 680);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // checkBox_all
            // 
            this.checkBox_all.AutoSize = true;
            this.checkBox_all.Location = new System.Drawing.Point(10, 659);
            this.checkBox_all.Name = "checkBox_all";
            this.checkBox_all.Size = new System.Drawing.Size(51, 21);
            this.checkBox_all.TabIndex = 13;
            this.checkBox_all.Text = "全选";
            this.checkBox_all.UseVisualStyleBackColor = true;
            this.checkBox_all.CheckedChanged += new System.EventHandler(this.checkBox_all_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "客户端列表：";
            // 
            // dataGridView_clientList
            // 
            this.dataGridView_clientList.AllowUserToAddRows = false;
            this.dataGridView_clientList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_clientList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_clientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_clientList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.ID,
            this.IP,
            this.progress});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_clientList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_clientList.Location = new System.Drawing.Point(10, 95);
            this.dataGridView_clientList.Name = "dataGridView_clientList";
            this.dataGridView_clientList.RowTemplate.Height = 23;
            this.dataGridView_clientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_clientList.Size = new System.Drawing.Size(348, 558);
            this.dataGridView_clientList.TabIndex = 11;
            this.dataGridView_clientList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_clientList_CellContentClick);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.MinimumWidth = 30;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckBox.Width = 30;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ID.FillWeight = 20F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 46;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.Width = 44;
            // 
            // progress
            // 
            this.progress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.progress.HeaderText = "进度";
            this.progress.Name = "progress";
            // 
            // lblProgressCur
            // 
            this.lblProgressCur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressCur.AutoSize = true;
            this.lblProgressCur.Location = new System.Drawing.Point(7, 16);
            this.lblProgressCur.Name = "lblProgressCur";
            this.lblProgressCur.Size = new System.Drawing.Size(32, 17);
            this.lblProgressCur.TabIndex = 10;
            this.lblProgressCur.Text = "进度";
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarTotal.Location = new System.Drawing.Point(10, 35);
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(348, 23);
            this.progressBarTotal.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarTotal.TabIndex = 9;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "driver.png");
            this.imageList1.Images.SetKeyName(1, "file.png");
            this.imageList1.Images.SetKeyName(2, "folder.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_error);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.comboBox_currentDirectoryEditor);
            this.groupBox1.Controls.Add(this.button_gohome);
            this.groupBox1.Controls.Add(this.button_refresh);
            this.groupBox1.Controls.Add(this.button_back);
            this.groupBox1.Controls.Add(this.listView_content);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(386, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 680);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "资源浏览：";
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(224, 334);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(356, 17);
            this.label_error.TabIndex = 10;
            this.label_error.Text = "无法显示当前文件夹，可能是因为文件夹不存在或没有权限读取。";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_cip});
            this.statusStrip1.Location = new System.Drawing.Point(3, 655);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(733, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel1.Text = "客户端ip：";
            // 
            // toolStripStatusLabel_cip
            // 
            this.toolStripStatusLabel_cip.Name = "toolStripStatusLabel_cip";
            this.toolStripStatusLabel_cip.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel_cip.Text = "toolStripStatusLabel2";
            // 
            // comboBox_currentDirectoryEditor
            // 
            this.comboBox_currentDirectoryEditor.FormattingEnabled = true;
            this.comboBox_currentDirectoryEditor.Location = new System.Drawing.Point(96, 33);
            this.comboBox_currentDirectoryEditor.Name = "comboBox_currentDirectoryEditor";
            this.comboBox_currentDirectoryEditor.Size = new System.Drawing.Size(461, 25);
            this.comboBox_currentDirectoryEditor.TabIndex = 8;
            // 
            // button_gohome
            // 
            this.button_gohome.Location = new System.Drawing.Point(656, 30);
            this.button_gohome.Name = "button_gohome";
            this.button_gohome.Size = new System.Drawing.Size(75, 28);
            this.button_gohome.TabIndex = 7;
            this.button_gohome.Text = "主页";
            this.button_gohome.UseVisualStyleBackColor = true;
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(569, 30);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 28);
            this.button_refresh.TabIndex = 6;
            this.button_refresh.Text = "刷新";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(9, 34);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 24);
            this.button_back.TabIndex = 5;
            this.button_back.Text = "后退";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // listView_content
            // 
            this.listView_content.ContextMenuStrip = this.mContextMenu;
            this.listView_content.HideSelection = false;
            this.listView_content.LargeImageList = this.imageList1;
            this.listView_content.Location = new System.Drawing.Point(6, 95);
            this.listView_content.Name = "listView_content";
            this.listView_content.Size = new System.Drawing.Size(789, 558);
            this.listView_content.TabIndex = 1;
            this.listView_content.UseCompatibleStateImageBehavior = false;
            this.listView_content.DoubleClick += new System.EventHandler(this.listView_content_DoubleClick);
            // 
            // mContextMenu
            // 
            this.mContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发送文件ToolStripMenuItem,
            this.发送文件夹ToolStripMenuItem,
            this.toolStripSeparator1,
            this.剪切ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.toolStripSeparator2,
            this.重命名ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.新建文件夹ToolStripMenuItem,
            this.属性ToolStripMenuItem,
            this.复制路径ToolStripMenuItem,
            this.toolStripSeparator3,
            this.远程执行ToolStripMenuItem,
            this.添加应用ToolStripMenuItem});
            this.mContextMenu.Name = "contextMenuStrip1";
            this.mContextMenu.Size = new System.Drawing.Size(137, 286);
            // 
            // 发送文件ToolStripMenuItem
            // 
            this.发送文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem1,
            this.文件夹ToolStripMenuItem1});
            this.发送文件ToolStripMenuItem.Name = "发送文件ToolStripMenuItem";
            this.发送文件ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.发送文件ToolStripMenuItem.Text = "发送";
            // 
            // 文件ToolStripMenuItem1
            // 
            this.文件ToolStripMenuItem1.Name = "文件ToolStripMenuItem1";
            this.文件ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.文件ToolStripMenuItem1.Text = "文件";
            this.文件ToolStripMenuItem1.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // 文件夹ToolStripMenuItem1
            // 
            this.文件夹ToolStripMenuItem1.Name = "文件夹ToolStripMenuItem1";
            this.文件夹ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.文件夹ToolStripMenuItem1.Text = "文件夹";
            this.文件夹ToolStripMenuItem1.Click += new System.EventHandler(this.文件夹ToolStripMenuItem1_Click);
            // 
            // 发送文件夹ToolStripMenuItem
            // 
            this.发送文件夹ToolStripMenuItem.Name = "发送文件夹ToolStripMenuItem";
            this.发送文件夹ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.发送文件夹ToolStripMenuItem.Text = "获取";
            this.发送文件夹ToolStripMenuItem.Click += new System.EventHandler(this.发送文件夹ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            this.剪切ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.剪切ToolStripMenuItem.Text = "剪切";
            this.剪切ToolStripMenuItem.Click += new System.EventHandler(this.剪切ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 新建文件夹ToolStripMenuItem
            // 
            this.新建文件夹ToolStripMenuItem.Name = "新建文件夹ToolStripMenuItem";
            this.新建文件夹ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.新建文件夹ToolStripMenuItem.Text = "新建文件夹";
            this.新建文件夹ToolStripMenuItem.Click += new System.EventHandler(this.新建文件夹ToolStripMenuItem_Click);
            // 
            // 属性ToolStripMenuItem
            // 
            this.属性ToolStripMenuItem.Name = "属性ToolStripMenuItem";
            this.属性ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.属性ToolStripMenuItem.Text = "属性";
            this.属性ToolStripMenuItem.Click += new System.EventHandler(this.属性ToolStripMenuItem_Click);
            // 
            // 复制路径ToolStripMenuItem
            // 
            this.复制路径ToolStripMenuItem.Name = "复制路径ToolStripMenuItem";
            this.复制路径ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.复制路径ToolStripMenuItem.Text = "复制路径";
            this.复制路径ToolStripMenuItem.Click += new System.EventHandler(this.复制路径ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // 远程执行ToolStripMenuItem
            // 
            this.远程执行ToolStripMenuItem.Name = "远程执行ToolStripMenuItem";
            this.远程执行ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.远程执行ToolStripMenuItem.Text = "远程执行";
            this.远程执行ToolStripMenuItem.Click += new System.EventHandler(this.远程执行ToolStripMenuItem_Click);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.文件ToolStripMenuItem.Text = "文件";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // 文件夹ToolStripMenuItem
            // 
            this.文件夹ToolStripMenuItem.Name = "文件夹ToolStripMenuItem";
            this.文件夹ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 添加应用ToolStripMenuItem
            // 
            this.添加应用ToolStripMenuItem.Name = "添加应用ToolStripMenuItem";
            this.添加应用ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加应用ToolStripMenuItem.Text = "添加应用";
            this.添加应用ToolStripMenuItem.Click += new System.EventHandler(this.添加应用ToolStripMenuItem_Click);
            // 
            // 传输文件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 704);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "传输文件";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资源管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.传输文件_FormClosing);
            this.Load += new System.EventHandler(this.传输文件_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_clientList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblProgressCur;
        private System.Windows.Forms.ProgressBar progressBarTotal;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_ForSaveFolder;
        private System.Windows.Forms.OpenFileDialog opnFlDlgSrc;
        private System.Windows.Forms.FolderBrowserDialog opnFldBrowserSrc;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridView_clientList;
        private System.Windows.Forms.CheckBox checkBox_all;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn progress;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListView listView_content;
        private System.Windows.Forms.ComboBox comboBox_currentDirectoryEditor;
        private System.Windows.Forms.Button button_gohome;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_cip;
        public System.Windows.Forms.Label label_error;
        private System.Windows.Forms.ContextMenuStrip mContextMenu;
        private System.Windows.Forms.ToolStripMenuItem 发送文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发送文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制路径ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 远程执行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 文件夹ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加应用ToolStripMenuItem;
    }
}