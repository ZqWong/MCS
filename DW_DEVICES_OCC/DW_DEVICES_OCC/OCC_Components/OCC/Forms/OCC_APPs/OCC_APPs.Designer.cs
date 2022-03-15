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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.DataGridViewApp = new Sunny.UI.UIDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonEditApp = new Sunny.UI.UIButton();
            this.ButtonDeleteApp = new Sunny.UI.UIButton();
            this.ButtonAddApp = new Sunny.UI.UIButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.DataGridViewDeviceBinded = new Sunny.UI.UIDataGridView();
            this.SelectedApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InstalledPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonEditDeviceBind = new Sunny.UI.UIButton();
            this.ButtonDeleteDeviceBind = new Sunny.UI.UIButton();
            this.ButtonAddDeviceBind = new Sunny.UI.UIButton();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewApp)).BeginInit();
            this.panel1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDeviceBinded)).BeginInit();
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
            this.uiGroupBox1.Controls.Add(this.DataGridViewApp);
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
            // DataGridViewApp
            // 
            this.DataGridViewApp.AllowUserToAddRows = false;
            this.DataGridViewApp.AllowUserToDeleteRows = false;
            this.DataGridViewApp.AllowUserToResizeColumns = false;
            this.DataGridViewApp.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridViewApp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewApp.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewApp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewApp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewApp.ColumnHeadersHeight = 32;
            this.DataGridViewApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewApp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.AppName,
            this.Remark});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewApp.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewApp.EnableHeadersVisualStyles = false;
            this.DataGridViewApp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataGridViewApp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridViewApp.Location = new System.Drawing.Point(0, 77);
            this.DataGridViewApp.MultiSelect = false;
            this.DataGridViewApp.Name = "DataGridViewApp";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewApp.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridViewApp.RowHeadersVisible = false;
            this.DataGridViewApp.RowHeight = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.DataGridViewApp.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewApp.RowTemplate.Height = 40;
            this.DataGridViewApp.SelectedIndex = -1;
            this.DataGridViewApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewApp.ShowGridLine = true;
            this.DataGridViewApp.Size = new System.Drawing.Size(1130, 300);
            this.DataGridViewApp.TabIndex = 1;
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
            this.ButtonEditApp.Click += new System.EventHandler(this.ButtonEditApp_Click);
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
            this.ButtonDeleteApp.Click += new System.EventHandler(this.ButtonDeleteApp_Click);
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
            this.ButtonAddApp.Click += new System.EventHandler(this.ButtonAddApp_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.DataGridViewDeviceBinded);
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
            // DataGridViewDeviceBinded
            // 
            this.DataGridViewDeviceBinded.AllowUserToAddRows = false;
            this.DataGridViewDeviceBinded.AllowUserToDeleteRows = false;
            this.DataGridViewDeviceBinded.AllowUserToResizeColumns = false;
            this.DataGridViewDeviceBinded.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridViewDeviceBinded.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridViewDeviceBinded.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewDeviceBinded.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDeviceBinded.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridViewDeviceBinded.ColumnHeadersHeight = 32;
            this.DataGridViewDeviceBinded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewDeviceBinded.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedApp,
            this.DeviceName,
            this.InstalledPath});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewDeviceBinded.DefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridViewDeviceBinded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewDeviceBinded.EnableHeadersVisualStyles = false;
            this.DataGridViewDeviceBinded.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataGridViewDeviceBinded.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridViewDeviceBinded.Location = new System.Drawing.Point(0, 77);
            this.DataGridViewDeviceBinded.MultiSelect = false;
            this.DataGridViewDeviceBinded.Name = "DataGridViewDeviceBinded";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDeviceBinded.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DataGridViewDeviceBinded.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.DataGridViewDeviceBinded.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DataGridViewDeviceBinded.RowTemplate.Height = 23;
            this.DataGridViewDeviceBinded.SelectedIndex = -1;
            this.DataGridViewDeviceBinded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewDeviceBinded.ShowGridLine = true;
            this.DataGridViewDeviceBinded.Size = new System.Drawing.Size(1130, 301);
            this.DataGridViewDeviceBinded.TabIndex = 1;
            // 
            // SelectedApp
            // 
            this.SelectedApp.HeaderText = "选择";
            this.SelectedApp.Name = "SelectedApp";
            // 
            // DeviceName
            // 
            this.DeviceName.HeaderText = "设备名";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            // 
            // InstalledPath
            // 
            this.InstalledPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InstalledPath.HeaderText = "安装路径";
            this.InstalledPath.Name = "InstalledPath";
            this.InstalledPath.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ButtonEditDeviceBind);
            this.panel2.Controls.Add(this.ButtonDeleteDeviceBind);
            this.panel2.Controls.Add(this.ButtonAddDeviceBind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1130, 45);
            this.panel2.TabIndex = 0;
            // 
            // ButtonEditDeviceBind
            // 
            this.ButtonEditDeviceBind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonEditDeviceBind.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditDeviceBind.Location = new System.Drawing.Point(219, 5);
            this.ButtonEditDeviceBind.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonEditDeviceBind.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonEditDeviceBind.Name = "ButtonEditDeviceBind";
            this.ButtonEditDeviceBind.Size = new System.Drawing.Size(100, 35);
            this.ButtonEditDeviceBind.TabIndex = 2;
            this.ButtonEditDeviceBind.Text = "编辑绑定设备";
            this.ButtonEditDeviceBind.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditDeviceBind.Click += new System.EventHandler(this.ButtonEditDeviceBind_Click);
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
            this.ButtonDeleteDeviceBind.Click += new System.EventHandler(this.ButtonDeleteDeviceBind_Click);
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
            this.ButtonAddDeviceBind.Click += new System.EventHandler(this.ButtonAddDeviceBind_Click);
            // 
            // Selected
            // 
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            // 
            // AppName
            // 
            this.AppName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AppName.HeaderText = "系统名";
            this.AppName.Name = "AppName";
            this.AppName.ReadOnly = true;
            this.AppName.Width = 82;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.HeaderText = "系统描述";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewApp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDeviceBinded)).EndInit();
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
        private Sunny.UI.UIDataGridView DataGridViewApp;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UIButton ButtonAddDeviceBind;
        private Sunny.UI.UIDataGridView DataGridViewDeviceBinded;
        private Sunny.UI.UIButton ButtonDeleteDeviceBind;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InstalledPath;
        private Sunny.UI.UIButton ButtonEditDeviceBind;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}