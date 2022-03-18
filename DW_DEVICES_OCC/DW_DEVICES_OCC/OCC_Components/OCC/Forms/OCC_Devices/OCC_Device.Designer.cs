using System;

namespace OCC.Forms
{
    partial class OCC_Device
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DeviceList = new Sunny.UI.UIDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonEditDevice = new Sunny.UI.UIButton();
            this.ButtonRemoveDevice = new Sunny.UI.UIButton();
            this.ButtonAddDevice = new Sunny.UI.UIButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.ProcessBarCpuRatio = new Sunny.UI.UIProcessBar();
            this.ProcessBarMemoryRatio = new Sunny.UI.UIProcessBar();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.ProcessBarGpuRatio = new Sunny.UI.UIProcessBar();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.ProcessBarGpuUsed = new Sunny.UI.UIProcessBar();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.LabelBootTime = new Sunny.UI.UILabel();
            this.LabelPing = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.LabelRemark = new Sunny.UI.UILabel();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenOrClosePCState = new System.Windows.Forms.DataGridViewImageColumn();
            this.ConnectionState = new System.Windows.Forms.DataGridViewImageColumn();
            this.CPURatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BootTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoryRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPURatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPUMemory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StereoState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeftRightEyeState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessSate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).BeginInit();
            this.panel2.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1129, 717);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.panel1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1121, 467);
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "设备列表";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 435);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DeviceList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1121, 390);
            this.panel3.TabIndex = 1;
            // 
            // DeviceList
            // 
            this.DeviceList.AllowUserToAddRows = false;
            this.DeviceList.AllowUserToDeleteRows = false;
            this.DeviceList.AllowUserToResizeColumns = false;
            this.DeviceList.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DeviceList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.DeviceList.BackgroundColor = System.Drawing.Color.White;
            this.DeviceList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeviceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DeviceList.ColumnHeadersHeight = 32;
            this.DeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DeviceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.DeviceName,
            this.OpenOrClosePCState,
            this.ConnectionState,
            this.CPURatio,
            this.BootTime,
            this.MemoryRatio,
            this.GPURatio,
            this.GPUMemory,
            this.NetDelay,
            this.StereoState,
            this.LeftRightEyeState,
            this.ProcessSate,
            this.Remark,
            this.IP});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DeviceList.DefaultCellStyle = dataGridViewCellStyle13;
            this.DeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceList.EnableHeadersVisualStyles = false;
            this.DeviceList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeviceList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DeviceList.Location = new System.Drawing.Point(0, 0);
            this.DeviceList.Name = "DeviceList";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeviceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DeviceList.RowHeadersVisible = false;
            this.DeviceList.RowHeight = 40;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            this.DeviceList.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.DeviceList.RowTemplate.Height = 40;
            this.DeviceList.SelectedIndex = -1;
            this.DeviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DeviceList.ShowGridLine = true;
            this.DeviceList.Size = new System.Drawing.Size(1121, 390);
            this.DeviceList.TabIndex = 0;
            this.DeviceList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeviceList_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ButtonEditDevice);
            this.panel2.Controls.Add(this.ButtonRemoveDevice);
            this.panel2.Controls.Add(this.ButtonAddDevice);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1121, 45);
            this.panel2.TabIndex = 0;
            // 
            // ButtonEditDevice
            // 
            this.ButtonEditDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonEditDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonEditDevice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditDevice.Location = new System.Drawing.Point(221, 5);
            this.ButtonEditDevice.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonEditDevice.Name = "ButtonEditDevice";
            this.ButtonEditDevice.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonEditDevice.Size = new System.Drawing.Size(100, 35);
            this.ButtonEditDevice.TabIndex = 2;
            this.ButtonEditDevice.Text = "编辑设备";
            this.ButtonEditDevice.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditDevice.Click += new System.EventHandler(this.ButtonEditDevice_Click);
            // 
            // ButtonRemoveDevice
            // 
            this.ButtonRemoveDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonRemoveDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonRemoveDevice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonRemoveDevice.Location = new System.Drawing.Point(113, 5);
            this.ButtonRemoveDevice.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonRemoveDevice.Name = "ButtonRemoveDevice";
            this.ButtonRemoveDevice.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonRemoveDevice.Size = new System.Drawing.Size(100, 35);
            this.ButtonRemoveDevice.TabIndex = 1;
            this.ButtonRemoveDevice.Text = "删除设备";
            this.ButtonRemoveDevice.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonRemoveDevice.Click += new System.EventHandler(this.ButtonRemoveDevice_Click);
            // 
            // ButtonAddDevice
            // 
            this.ButtonAddDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddDevice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddDevice.Location = new System.Drawing.Point(5, 5);
            this.ButtonAddDevice.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonAddDevice.Name = "ButtonAddDevice";
            this.ButtonAddDevice.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonAddDevice.Size = new System.Drawing.Size(100, 35);
            this.ButtonAddDevice.TabIndex = 0;
            this.ButtonAddDevice.Text = "添加设备";
            this.ButtonAddDevice.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddDevice.Click += new System.EventHandler(this.ButtonAddDevice_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.LabelRemark);
            this.uiGroupBox2.Controls.Add(this.uiLabel11);
            this.uiGroupBox2.Controls.Add(this.LabelPing);
            this.uiGroupBox2.Controls.Add(this.uiLabel9);
            this.uiGroupBox2.Controls.Add(this.LabelBootTime);
            this.uiGroupBox2.Controls.Add(this.uiLabel6);
            this.uiGroupBox2.Controls.Add(this.ProcessBarGpuUsed);
            this.uiGroupBox2.Controls.Add(this.uiLabel5);
            this.uiGroupBox2.Controls.Add(this.ProcessBarGpuRatio);
            this.uiGroupBox2.Controls.Add(this.uiLabel4);
            this.uiGroupBox2.Controls.Add(this.ProcessBarMemoryRatio);
            this.uiGroupBox2.Controls.Add(this.uiLabel3);
            this.uiGroupBox2.Controls.Add(this.ProcessBarCpuRatio);
            this.uiGroupBox2.Controls.Add(this.uiLabel2);
            this.uiGroupBox2.Controls.Add(this.uiLabel1);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 482);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(1121, 230);
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "设备信息";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.FillWeight = 121.3812F;
            this.dataGridViewImageColumn1.HeaderText = "开关机状态";
            this.dataGridViewImageColumn1.Image = global::OCC.Properties.Resources.switch_关;
            this.dataGridViewImageColumn1.MinimumWidth = 18;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn2.FillWeight = 102.3817F;
            this.dataGridViewImageColumn2.HeaderText = "连接状态";
            this.dataGridViewImageColumn2.Image = global::OCC.Properties.Resources.switch_关;
            this.dataGridViewImageColumn2.MinimumWidth = 15;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(8, 138);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(62, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "CPU%";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(132, 207);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(8, 8);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "uiLabel2";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProcessBarCpuRatio
            // 
            this.ProcessBarCpuRatio.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.ProcessBarCpuRatio.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProcessBarCpuRatio.Location = new System.Drawing.Point(13, 164);
            this.ProcessBarCpuRatio.MinimumSize = new System.Drawing.Size(50, 3);
            this.ProcessBarCpuRatio.Name = "ProcessBarCpuRatio";
            this.ProcessBarCpuRatio.Size = new System.Drawing.Size(50, 54);
            this.ProcessBarCpuRatio.TabIndex = 2;
            this.ProcessBarCpuRatio.Text = "uiProcessBar1";
            // 
            // ProcessBarMemoryRatio
            // 
            this.ProcessBarMemoryRatio.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.ProcessBarMemoryRatio.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProcessBarMemoryRatio.Location = new System.Drawing.Point(91, 164);
            this.ProcessBarMemoryRatio.MinimumSize = new System.Drawing.Size(50, 3);
            this.ProcessBarMemoryRatio.Name = "ProcessBarMemoryRatio";
            this.ProcessBarMemoryRatio.Size = new System.Drawing.Size(50, 54);
            this.ProcessBarMemoryRatio.TabIndex = 4;
            this.ProcessBarMemoryRatio.Text = "uiProcessBar2";
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(86, 138);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(62, 23);
            this.uiLabel3.TabIndex = 3;
            this.uiLabel3.Text = "内存%";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProcessBarGpuRatio
            // 
            this.ProcessBarGpuRatio.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.ProcessBarGpuRatio.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProcessBarGpuRatio.Location = new System.Drawing.Point(164, 164);
            this.ProcessBarGpuRatio.MinimumSize = new System.Drawing.Size(50, 3);
            this.ProcessBarGpuRatio.Name = "ProcessBarGpuRatio";
            this.ProcessBarGpuRatio.Size = new System.Drawing.Size(50, 54);
            this.ProcessBarGpuRatio.TabIndex = 6;
            this.ProcessBarGpuRatio.Text = "uiProcessBar3";
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(157, 138);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(62, 23);
            this.uiLabel4.TabIndex = 5;
            this.uiLabel4.Text = "GPU%";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProcessBarGpuUsed
            // 
            this.ProcessBarGpuUsed.Direction = Sunny.UI.UILine.LineDirection.Vertical;
            this.ProcessBarGpuUsed.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ProcessBarGpuUsed.Location = new System.Drawing.Point(235, 164);
            this.ProcessBarGpuUsed.MinimumSize = new System.Drawing.Size(50, 3);
            this.ProcessBarGpuUsed.Name = "ProcessBarGpuUsed";
            this.ProcessBarGpuUsed.Size = new System.Drawing.Size(50, 54);
            this.ProcessBarGpuUsed.TabIndex = 8;
            this.ProcessBarGpuUsed.Text = "uiProcessBar4";
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(230, 138);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(62, 23);
            this.uiLabel5.TabIndex = 7;
            this.uiLabel5.Text = "显存%";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(9, 32);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(94, 23);
            this.uiLabel6.TabIndex = 9;
            this.uiLabel6.Text = "开机时间：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelBootTime
            // 
            this.LabelBootTime.BackColor = System.Drawing.Color.Transparent;
            this.LabelBootTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelBootTime.Location = new System.Drawing.Point(87, 32);
            this.LabelBootTime.Name = "LabelBootTime";
            this.LabelBootTime.Size = new System.Drawing.Size(198, 23);
            this.LabelBootTime.TabIndex = 10;
            this.LabelBootTime.Text = "无法获取";
            this.LabelBootTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelPing
            // 
            this.LabelPing.BackColor = System.Drawing.Color.Transparent;
            this.LabelPing.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelPing.Location = new System.Drawing.Point(87, 67);
            this.LabelPing.Name = "LabelPing";
            this.LabelPing.Size = new System.Drawing.Size(198, 23);
            this.LabelPing.TabIndex = 12;
            this.LabelPing.Text = "无法获取";
            this.LabelPing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel9
            // 
            this.uiLabel9.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(9, 67);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(94, 23);
            this.uiLabel9.TabIndex = 11;
            this.uiLabel9.Text = "Ping(ms)";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelRemark
            // 
            this.LabelRemark.BackColor = System.Drawing.Color.Transparent;
            this.LabelRemark.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelRemark.Location = new System.Drawing.Point(369, 32);
            this.LabelRemark.Name = "LabelRemark";
            this.LabelRemark.Size = new System.Drawing.Size(730, 23);
            this.LabelRemark.TabIndex = 14;
            this.LabelRemark.Text = "1h";
            this.LabelRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel11
            // 
            this.uiLabel11.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.Location = new System.Drawing.Point(291, 32);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(72, 23);
            this.uiLabel11.TabIndex = 13;
            this.uiLabel11.Text = "备注：";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Selected
            // 
            this.Selected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Selected.FillWeight = 86.21924F;
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            // 
            // DeviceName
            // 
            this.DeviceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeviceName.FillWeight = 86.21924F;
            this.DeviceName.HeaderText = "名称";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DeviceName.Width = 47;
            // 
            // OpenOrClosePCState
            // 
            this.OpenOrClosePCState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OpenOrClosePCState.FillWeight = 121.3812F;
            this.OpenOrClosePCState.HeaderText = "开关机状态";
            this.OpenOrClosePCState.Image = global::OCC.Properties.Resources.switch_关;
            this.OpenOrClosePCState.MinimumWidth = 18;
            this.OpenOrClosePCState.Name = "OpenOrClosePCState";
            this.OpenOrClosePCState.ReadOnly = true;
            // 
            // ConnectionState
            // 
            this.ConnectionState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ConnectionState.FillWeight = 102.3817F;
            this.ConnectionState.HeaderText = "连接状态";
            this.ConnectionState.Image = global::OCC.Properties.Resources.switch_关;
            this.ConnectionState.MinimumWidth = 15;
            this.ConnectionState.Name = "ConnectionState";
            this.ConnectionState.ReadOnly = true;
            // 
            // CPURatio
            // 
            this.CPURatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CPURatio.FillWeight = 86.21924F;
            this.CPURatio.HeaderText = "CPU%";
            this.CPURatio.Name = "CPURatio";
            this.CPURatio.ReadOnly = true;
            this.CPURatio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CPURatio.Visible = false;
            // 
            // BootTime
            // 
            this.BootTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BootTime.FillWeight = 103.7138F;
            this.BootTime.HeaderText = "开机时间";
            this.BootTime.MinimumWidth = 15;
            this.BootTime.Name = "BootTime";
            this.BootTime.ReadOnly = true;
            this.BootTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BootTime.Visible = false;
            // 
            // MemoryRatio
            // 
            this.MemoryRatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MemoryRatio.FillWeight = 86.21924F;
            this.MemoryRatio.HeaderText = "内存%";
            this.MemoryRatio.Name = "MemoryRatio";
            this.MemoryRatio.ReadOnly = true;
            this.MemoryRatio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MemoryRatio.Visible = false;
            // 
            // GPURatio
            // 
            this.GPURatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GPURatio.FillWeight = 86.21924F;
            this.GPURatio.HeaderText = "GPU%";
            this.GPURatio.Name = "GPURatio";
            this.GPURatio.ReadOnly = true;
            this.GPURatio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GPURatio.Visible = false;
            // 
            // GPUMemory
            // 
            this.GPUMemory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GPUMemory.FillWeight = 105.1556F;
            this.GPUMemory.HeaderText = "显存占用";
            this.GPUMemory.MinimumWidth = 15;
            this.GPUMemory.Name = "GPUMemory";
            this.GPUMemory.ReadOnly = true;
            this.GPUMemory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GPUMemory.Visible = false;
            // 
            // NetDelay
            // 
            this.NetDelay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NetDelay.FillWeight = 106.7163F;
            this.NetDelay.HeaderText = "Ping( ms)";
            this.NetDelay.MinimumWidth = 15;
            this.NetDelay.Name = "NetDelay";
            this.NetDelay.ReadOnly = true;
            this.NetDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NetDelay.Visible = false;
            // 
            // StereoState
            // 
            this.StereoState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StereoState.FillWeight = 108.4056F;
            this.StereoState.HeaderText = "立体状态";
            this.StereoState.MinimumWidth = 15;
            this.StereoState.Name = "StereoState";
            this.StereoState.ReadOnly = true;
            this.StereoState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LeftRightEyeState
            // 
            this.LeftRightEyeState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LeftRightEyeState.FillWeight = 134.498F;
            this.LeftRightEyeState.HeaderText = "左右眼状态";
            this.LeftRightEyeState.MinimumWidth = 18;
            this.LeftRightEyeState.Name = "LeftRightEyeState";
            this.LeftRightEyeState.ReadOnly = true;
            this.LeftRightEyeState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProcessSate
            // 
            this.ProcessSate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProcessSate.FillWeight = 114.2132F;
            this.ProcessSate.HeaderText = "运行进程";
            this.ProcessSate.MinimumWidth = 15;
            this.ProcessSate.Name = "ProcessSate";
            this.ProcessSate.ReadOnly = true;
            this.ProcessSate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.FillWeight = 86.21924F;
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Remark.Visible = false;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IP.FillWeight = 86.21924F;
            this.IP.HeaderText = "IP地址";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OCC_Device
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1129, 717);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OCC_Device";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCC_Users";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UIButton ButtonRemoveDevice;
        private Sunny.UI.UIButton ButtonAddDevice;
        public Sunny.UI.UIDataGridView DeviceList;
        private Sunny.UI.UIButton ButtonEditDevice;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIProcessBar ProcessBarCpuRatio;
        private Sunny.UI.UIProcessBar ProcessBarMemoryRatio;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIProcessBar ProcessBarGpuRatio;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIProcessBar ProcessBarGpuUsed;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel LabelBootTime;
        private Sunny.UI.UILabel LabelPing;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel LabelRemark;
        private Sunny.UI.UILabel uiLabel11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewImageColumn OpenOrClosePCState;
        private System.Windows.Forms.DataGridViewImageColumn ConnectionState;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPURatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn BootTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoryRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPURatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPUMemory;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn StereoState;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeftRightEyeState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessSate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
    }
}