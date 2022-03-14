namespace OCC.Forms.OCC_APPs
{
    partial class OCC_APPs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.APPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonEditApp = new Sunny.UI.UIButton();
            this.ButtonDeleteApp = new Sunny.UI.UIButton();
            this.ButtonAddApp = new Sunny.UI.UIButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.uiDataGridView2 = new Sunny.UI.UIDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonDeleteDeviceBind = new Sunny.UI.UIButton();
            this.ButtonAddDeviceBind = new Sunny.UI.UIButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1138, 775);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.uiDataGridView1);
            this.uiGroupBox1.Controls.Add(this.panel1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1130, 377);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "系统管理";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiDataGridView1
            // 
            this.uiDataGridView1.AllowUserToAddRows = false;
            this.uiDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.APPName,
            this.Remark});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle18;
            this.uiDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 77);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.uiDataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.uiDataGridView1.RowTemplate.Height = 23;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.ShowGridLine = true;
            this.uiDataGridView1.Size = new System.Drawing.Size(1130, 300);
            this.uiDataGridView1.TabIndex = 1;
            // 
            // Selected
            // 
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            // 
            // APPName
            // 
            this.APPName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.APPName.HeaderText = "系统名";
            this.APPName.Name = "APPName";
            this.APPName.ReadOnly = true;
            this.APPName.Width = 82;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.HeaderText = "系统描述";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ButtonEditApp);
            this.panel1.Controls.Add(this.ButtonDeleteApp);
            this.panel1.Controls.Add(this.ButtonAddApp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 45);
            this.panel1.TabIndex = 0;
            // 
            // ButtonEditApp
            // 
            this.ButtonEditApp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonEditApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonEditApp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditApp.Location = new System.Drawing.Point(219, 5);
            this.ButtonEditApp.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonEditApp.Name = "ButtonEditApp";
            this.ButtonEditApp.Size = new System.Drawing.Size(100, 35);
            this.ButtonEditApp.TabIndex = 2;
            this.ButtonEditApp.Text = "编辑系统";
            this.ButtonEditApp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // ButtonDeleteApp
            // 
            this.ButtonDeleteApp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonDeleteApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDeleteApp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonDeleteApp.Location = new System.Drawing.Point(113, 5);
            this.ButtonDeleteApp.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonDeleteApp.Name = "ButtonDeleteApp";
            this.ButtonDeleteApp.Size = new System.Drawing.Size(100, 35);
            this.ButtonDeleteApp.TabIndex = 1;
            this.ButtonDeleteApp.Text = "删除系统";
            this.ButtonDeleteApp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // ButtonAddApp
            // 
            this.ButtonAddApp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddApp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddApp.Location = new System.Drawing.Point(5, 5);
            this.ButtonAddApp.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonAddApp.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonAddApp.Name = "ButtonAddApp";
            this.ButtonAddApp.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonAddApp.Size = new System.Drawing.Size(100, 35);
            this.ButtonAddApp.TabIndex = 0;
            this.ButtonAddApp.Text = "添加系统";
            this.ButtonAddApp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.uiDataGridView2);
            this.uiGroupBox2.Controls.Add(this.panel2);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 392);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(1130, 378);
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "设备绑定管理";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiDataGridView2
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.uiDataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.uiDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView2.DefaultCellStyle = dataGridViewCellStyle13;
            this.uiDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView2.EnableHeadersVisualStyles = false;
            this.uiDataGridView2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView2.Location = new System.Drawing.Point(0, 77);
            this.uiDataGridView2.Name = "uiDataGridView2";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            this.uiDataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.uiDataGridView2.RowTemplate.Height = 23;
            this.uiDataGridView2.SelectedIndex = -1;
            this.uiDataGridView2.ShowGridLine = true;
            this.uiDataGridView2.Size = new System.Drawing.Size(1130, 301);
            this.uiDataGridView2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ButtonDeleteDeviceBind);
            this.panel2.Controls.Add(this.ButtonAddDeviceBind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1130, 45);
            this.panel2.TabIndex = 0;
            // 
            // ButtonDeleteDeviceBind
            // 
            this.ButtonDeleteDeviceBind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDeleteDeviceBind.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonDeleteDeviceBind.Location = new System.Drawing.Point(113, 5);
            this.ButtonDeleteDeviceBind.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonDeleteDeviceBind.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonDeleteDeviceBind.Name = "ButtonDeleteDeviceBind";
            this.ButtonDeleteDeviceBind.Size = new System.Drawing.Size(100, 35);
            this.ButtonDeleteDeviceBind.TabIndex = 1;
            this.ButtonDeleteDeviceBind.Text = "删除绑定设备";
            this.ButtonDeleteDeviceBind.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // ButtonAddDeviceBind
            // 
            this.ButtonAddDeviceBind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddDeviceBind.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddDeviceBind.Location = new System.Drawing.Point(5, 5);
            this.ButtonAddDeviceBind.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonAddDeviceBind.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonAddDeviceBind.Name = "ButtonAddDeviceBind";
            this.ButtonAddDeviceBind.Size = new System.Drawing.Size(100, 35);
            this.ButtonAddDeviceBind.TabIndex = 0;
            this.ButtonAddDeviceBind.Text = "添加绑定设备";
            this.ButtonAddDeviceBind.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // OCC_APPs
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1138, 775);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OCC_APPs";
            this.Text = "OCC_Apps";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UIButton ButtonAddApp;
        private Sunny.UI.UIButton ButtonEditApp;
        private Sunny.UI.UIButton ButtonDeleteApp;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn APPName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UIButton ButtonAddDeviceBind;
        private Sunny.UI.UIDataGridView uiDataGridView2;
        private Sunny.UI.UIButton ButtonDeleteDeviceBind;
    }
}