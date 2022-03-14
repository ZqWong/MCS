using System;

namespace OCC.Forms.OCC_Devices
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DeviceList = new Sunny.UI.UIDataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonEditDevice = new Sunny.UI.UIButton();
            this.ButtonRemoveDevice = new Sunny.UI.UIButton();
            this.ButtonAddDevice = new Sunny.UI.UIButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.OpenOrClosePCState = new System.Windows.Forms.DataGridViewImageColumn();
            this.ConnectionState = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).BeginInit();
            this.panel2.SuspendLayout();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DeviceList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DeviceList.BackgroundColor = System.Drawing.Color.White;
            this.DeviceList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeviceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DeviceList.DefaultCellStyle = dataGridViewCellStyle3;
            this.DeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceList.EnableHeadersVisualStyles = false;
            this.DeviceList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeviceList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DeviceList.Location = new System.Drawing.Point(0, 0);
            this.DeviceList.Name = "DeviceList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeviceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DeviceList.RowHeadersVisible = false;
            this.DeviceList.RowHeight = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.DeviceList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DeviceList.RowTemplate.Height = 40;
            this.DeviceList.SelectedIndex = -1;
            this.DeviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DeviceList.ShowGridLine = true;
            this.DeviceList.Size = new System.Drawing.Size(1121, 390);
            this.DeviceList.TabIndex = 0;
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
            this.DeviceName.Width = 66;
            // 
            // CPURatio
            // 
            this.CPURatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CPURatio.FillWeight = 86.21924F;
            this.CPURatio.HeaderText = "CPU%";
            this.CPURatio.Name = "CPURatio";
            this.CPURatio.ReadOnly = true;
            // 
            // BootTime
            // 
            this.BootTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BootTime.FillWeight = 103.7138F;
            this.BootTime.HeaderText = "开机时间";
            this.BootTime.MinimumWidth = 15;
            this.BootTime.Name = "BootTime";
            this.BootTime.ReadOnly = true;
            // 
            // MemoryRatio
            // 
            this.MemoryRatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MemoryRatio.FillWeight = 86.21924F;
            this.MemoryRatio.HeaderText = "内存%";
            this.MemoryRatio.Name = "MemoryRatio";
            this.MemoryRatio.ReadOnly = true;
            // 
            // GPURatio
            // 
            this.GPURatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GPURatio.FillWeight = 86.21924F;
            this.GPURatio.HeaderText = "GPU%";
            this.GPURatio.Name = "GPURatio";
            this.GPURatio.ReadOnly = true;
            // 
            // GPUMemory
            // 
            this.GPUMemory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GPUMemory.FillWeight = 105.1556F;
            this.GPUMemory.HeaderText = "显存占用";
            this.GPUMemory.MinimumWidth = 15;
            this.GPUMemory.Name = "GPUMemory";
            this.GPUMemory.ReadOnly = true;
            // 
            // NetDelay
            // 
            this.NetDelay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NetDelay.FillWeight = 106.7163F;
            this.NetDelay.HeaderText = "Ping( ms)";
            this.NetDelay.MinimumWidth = 15;
            this.NetDelay.Name = "NetDelay";
            this.NetDelay.ReadOnly = true;
            // 
            // StereoState
            // 
            this.StereoState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StereoState.FillWeight = 108.4056F;
            this.StereoState.HeaderText = "立体状态";
            this.StereoState.MinimumWidth = 15;
            this.StereoState.Name = "StereoState";
            this.StereoState.ReadOnly = true;
            // 
            // LeftRightEyeState
            // 
            this.LeftRightEyeState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LeftRightEyeState.FillWeight = 134.498F;
            this.LeftRightEyeState.HeaderText = "左右眼状态";
            this.LeftRightEyeState.MinimumWidth = 18;
            this.LeftRightEyeState.Name = "LeftRightEyeState";
            this.LeftRightEyeState.ReadOnly = true;
            // 
            // ProcessSate
            // 
            this.ProcessSate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProcessSate.FillWeight = 114.2132F;
            this.ProcessSate.HeaderText = "运行进程";
            this.ProcessSate.MinimumWidth = 15;
            this.ProcessSate.Name = "ProcessSate";
            this.ProcessSate.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.FillWeight = 86.21924F;
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IP.FillWeight = 86.21924F;
            this.IP.HeaderText = "IP地址";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
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
            this.ButtonEditDevice.Location = new System.Drawing.Point(217, 5);
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
            this.ButtonRemoveDevice.Location = new System.Drawing.Point(111, 5);
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
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
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
            // OCC_Device
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1129, 717);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OCC_Device";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCC_Users";
            this.Load += new System.EventHandler(this.OCC_Device_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
    }
}