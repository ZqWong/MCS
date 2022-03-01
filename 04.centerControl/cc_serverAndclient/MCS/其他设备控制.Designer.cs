namespace MCS
{
    partial class 其他设备控制
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIAL_PORT = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox_projector = new System.Windows.Forms.CheckBox();
            this.checkBox_audio = new System.Windows.Forms.CheckBox();
            this.checkBox_light = new System.Windows.Forms.CheckBox();
            this.checkBox_all = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存到数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.类别管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.方案管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输入查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d座椅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.执行控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_class = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_group = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_deviceControl = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.name,
            this.category,
            this.IP,
            this.SERIAL_PORT,
            this.ID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 66);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1300, 495);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // CheckBox
            // 
            this.CheckBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CheckBox.HeaderText = "";
            this.CheckBox.MinimumWidth = 30;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 30;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.name.DataPropertyName = "NAME";
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.name.Width = 62;
            // 
            // category
            // 
            this.category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.category.DataPropertyName = "CLASS";
            this.category.HeaderText = "类别";
            this.category.Name = "category";
            this.category.Width = 43;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IP.Width = 47;
            // 
            // SERIAL_PORT
            // 
            this.SERIAL_PORT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SERIAL_PORT.HeaderText = "串口";
            this.SERIAL_PORT.Name = "SERIAL_PORT";
            this.SERIAL_PORT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SERIAL_PORT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SERIAL_PORT.Width = 62;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // checkBox_projector
            // 
            this.checkBox_projector.AutoSize = true;
            this.checkBox_projector.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_projector.Location = new System.Drawing.Point(337, 567);
            this.checkBox_projector.Name = "checkBox_projector";
            this.checkBox_projector.Size = new System.Drawing.Size(84, 24);
            this.checkBox_projector.TabIndex = 5;
            this.checkBox_projector.Text = "全部投影";
            this.checkBox_projector.UseVisualStyleBackColor = true;
            this.checkBox_projector.Visible = false;
            this.checkBox_projector.CheckedChanged += new System.EventHandler(this.checkBox_projector_CheckedChanged);
            // 
            // checkBox_audio
            // 
            this.checkBox_audio.AutoSize = true;
            this.checkBox_audio.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_audio.Location = new System.Drawing.Point(408, 567);
            this.checkBox_audio.Name = "checkBox_audio";
            this.checkBox_audio.Size = new System.Drawing.Size(56, 24);
            this.checkBox_audio.TabIndex = 6;
            this.checkBox_audio.Text = "音响";
            this.checkBox_audio.UseVisualStyleBackColor = true;
            this.checkBox_audio.Visible = false;
            this.checkBox_audio.CheckedChanged += new System.EventHandler(this.checkBox_audio_CheckedChanged);
            // 
            // checkBox_light
            // 
            this.checkBox_light.AutoSize = true;
            this.checkBox_light.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_light.Location = new System.Drawing.Point(479, 567);
            this.checkBox_light.Name = "checkBox_light";
            this.checkBox_light.Size = new System.Drawing.Size(56, 24);
            this.checkBox_light.TabIndex = 7;
            this.checkBox_light.Text = "灯光";
            this.checkBox_light.UseVisualStyleBackColor = true;
            this.checkBox_light.Visible = false;
            this.checkBox_light.CheckedChanged += new System.EventHandler(this.checkBox_light_CheckedChanged);
            // 
            // checkBox_all
            // 
            this.checkBox_all.AutoSize = true;
            this.checkBox_all.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_all.Location = new System.Drawing.Point(12, 578);
            this.checkBox_all.Name = "checkBox_all";
            this.checkBox_all.Size = new System.Drawing.Size(56, 24);
            this.checkBox_all.TabIndex = 8;
            this.checkBox_all.Text = "全选";
            this.checkBox_all.UseVisualStyleBackColor = true;
            this.checkBox_all.CheckedChanged += new System.EventHandler(this.checkBox_all_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.保存到数据库ToolStripMenuItem,
            this.类别管理ToolStripMenuItem,
            this.方案管理ToolStripMenuItem,
            this.输入查看ToolStripMenuItem,
            this.执行控制ToolStripMenuItem,
            this.d座椅ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1322, 29);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.刷新ToolStripMenuItem.Text = "显示刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 保存到数据库ToolStripMenuItem
            // 
            this.保存到数据库ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.保存到数据库ToolStripMenuItem.Name = "保存到数据库ToolStripMenuItem";
            this.保存到数据库ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.保存到数据库ToolStripMenuItem.Text = "保存数据";
            this.保存到数据库ToolStripMenuItem.Click += new System.EventHandler(this.保存到数据库ToolStripMenuItem_Click);
            // 
            // 类别管理ToolStripMenuItem
            // 
            this.类别管理ToolStripMenuItem.Name = "类别管理ToolStripMenuItem";
            this.类别管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.类别管理ToolStripMenuItem.Text = "类别管理";
            this.类别管理ToolStripMenuItem.Click += new System.EventHandler(this.类别管理ToolStripMenuItem_Click);
            // 
            // 方案管理ToolStripMenuItem
            // 
            this.方案管理ToolStripMenuItem.Name = "方案管理ToolStripMenuItem";
            this.方案管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.方案管理ToolStripMenuItem.Text = "方案管理";
            this.方案管理ToolStripMenuItem.Click += new System.EventHandler(this.方案管理ToolStripMenuItem_Click);
            // 
            // 输入查看ToolStripMenuItem
            // 
            this.输入查看ToolStripMenuItem.Name = "输入查看ToolStripMenuItem";
            this.输入查看ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.输入查看ToolStripMenuItem.Text = "输入查看";
            this.输入查看ToolStripMenuItem.Click += new System.EventHandler(this.输入查看ToolStripMenuItem_Click);
            // 
            // d座椅ToolStripMenuItem
            // 
            this.d座椅ToolStripMenuItem.Name = "d座椅ToolStripMenuItem";
            this.d座椅ToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.d座椅ToolStripMenuItem.Text = "4D座椅";
            this.d座椅ToolStripMenuItem.Visible = false;
            this.d座椅ToolStripMenuItem.Click += new System.EventHandler(this.d座椅ToolStripMenuItem_Click);
            // 
            // 执行控制ToolStripMenuItem
            // 
            this.执行控制ToolStripMenuItem.Name = "执行控制ToolStripMenuItem";
            this.执行控制ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.执行控制ToolStripMenuItem.Text = "执行控制";
            this.执行控制ToolStripMenuItem.Click += new System.EventHandler(this.执行控制ToolStripMenuItem_Click);
            // 
            // comboBox_class
            // 
            this.comboBox_class.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.comboBox_class.FormattingEnabled = true;
            this.comboBox_class.Location = new System.Drawing.Point(58, 32);
            this.comboBox_class.Name = "comboBox_class";
            this.comboBox_class.Size = new System.Drawing.Size(152, 27);
            this.comboBox_class.TabIndex = 10;
            this.comboBox_class.SelectedIndexChanged += new System.EventHandler(this.comboBox_class_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "类别:";
            // 
            // comboBox_group
            // 
            this.comboBox_group.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.comboBox_group.FormattingEnabled = true;
            this.comboBox_group.Location = new System.Drawing.Point(322, 32);
            this.comboBox_group.Name = "comboBox_group";
            this.comboBox_group.Size = new System.Drawing.Size(153, 27);
            this.comboBox_group.TabIndex = 16;
            this.comboBox_group.SelectedIndexChanged += new System.EventHandler(this.comboBox_group_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(246, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "分组信息:";
            // 
            // comboBox_deviceControl
            // 
            this.comboBox_deviceControl.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.comboBox_deviceControl.FormattingEnabled = true;
            this.comboBox_deviceControl.Location = new System.Drawing.Point(571, 32);
            this.comboBox_deviceControl.Name = "comboBox_deviceControl";
            this.comboBox_deviceControl.Size = new System.Drawing.Size(153, 27);
            this.comboBox_deviceControl.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.Location = new System.Drawing.Point(497, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "选择控制:";
            // 
            // 其他设备控制
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 614);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_deviceControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_group);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_class);
            this.Controls.Add(this.checkBox_all);
            this.Controls.Add(this.checkBox_light);
            this.Controls.Add(this.checkBox_audio);
            this.Controls.Add(this.checkBox_projector);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "其他设备控制";
            this.Text = "其他设备控制";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.其他设备控制_FormClosing);
            this.Load += new System.EventHandler(this.其他设备控制_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.其他设备控制_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBox_projector;
        private System.Windows.Forms.CheckBox checkBox_audio;
        private System.Windows.Forms.CheckBox checkBox_light;
        private System.Windows.Forms.CheckBox checkBox_all;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存到数据库ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_class;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_group;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_deviceControl;
        private System.Windows.Forms.ToolStripMenuItem 执行控制ToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem 类别管理ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewComboBoxColumn SERIAL_PORT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.ToolStripMenuItem 方案管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输入查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d座椅ToolStripMenuItem;
    }
}