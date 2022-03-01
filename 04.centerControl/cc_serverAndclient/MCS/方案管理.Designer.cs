namespace MCS
{
    partial class 方案管理
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DeviceClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DeviceControlName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新建方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox_plan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.DeviceClass,
            this.DeviceControlName,
            this.Delay});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(25, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(445, 364);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // GroupName
            // 
            this.GroupName.HeaderText = "分组名称";
            this.GroupName.Name = "GroupName";
            // 
            // DeviceClass
            // 
            this.DeviceClass.HeaderText = "设备类别";
            this.DeviceClass.Name = "DeviceClass";
            // 
            // DeviceControlName
            // 
            this.DeviceControlName.HeaderText = "控制名称";
            this.DeviceControlName.Name = "DeviceControlName";
            // 
            // Delay
            // 
            this.Delay.HeaderText = "延迟时间";
            this.Delay.Name = "Delay";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建方案ToolStripMenuItem,
            this.保存数据ToolStripMenuItem,
            this.刷新数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新建方案ToolStripMenuItem
            // 
            this.新建方案ToolStripMenuItem.Name = "新建方案ToolStripMenuItem";
            this.新建方案ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.新建方案ToolStripMenuItem.Text = "新建方案";
            this.新建方案ToolStripMenuItem.Click += new System.EventHandler(this.新建方案ToolStripMenuItem_Click);
            // 
            // 保存数据ToolStripMenuItem
            // 
            this.保存数据ToolStripMenuItem.Name = "保存数据ToolStripMenuItem";
            this.保存数据ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.保存数据ToolStripMenuItem.Text = "保存数据";
            this.保存数据ToolStripMenuItem.Click += new System.EventHandler(this.保存数据ToolStripMenuItem_Click);
            // 
            // 刷新数据ToolStripMenuItem
            // 
            this.刷新数据ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.刷新数据ToolStripMenuItem.Name = "刷新数据ToolStripMenuItem";
            this.刷新数据ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.刷新数据ToolStripMenuItem.Text = "刷新数据";
            this.刷新数据ToolStripMenuItem.Click += new System.EventHandler(this.刷新数据ToolStripMenuItem_Click);
            // 
            // comboBox_plan
            // 
            this.comboBox_plan.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.comboBox_plan.FormattingEnabled = true;
            this.comboBox_plan.Location = new System.Drawing.Point(77, 39);
            this.comboBox_plan.Name = "comboBox_plan";
            this.comboBox_plan.Size = new System.Drawing.Size(152, 27);
            this.comboBox_plan.TabIndex = 11;
            this.comboBox_plan.SelectedIndexChanged += new System.EventHandler(this.comboBox_plan_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "方案:";
            // 
            // 方案管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_plan);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "方案管理";
            this.Text = "方案管理";
            this.Load += new System.EventHandler(this.方案管理_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新数据ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox_plan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewComboBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewComboBoxColumn DeviceClass;
        private System.Windows.Forms.DataGridViewComboBoxColumn DeviceControlName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
    }
}