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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DevicesGroupBox = new System.Windows.Forms.GroupBox();
            this.DeviceList = new System.Windows.Forms.DataGridView();
            this.DevicesMenuStrip = new System.Windows.Forms.MenuStrip();
            this.AddDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AujustUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenOrClosePCState = new System.Windows.Forms.DataGridViewImageColumn();
            this.ConnectionState = new System.Windows.Forms.DataGridViewImageColumn();
            this.BootTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPURatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoryRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPURatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPUMemory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StereoState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeftRightEyeState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessSate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PingTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.DevicesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).BeginInit();
            this.DevicesMenuStrip.SuspendLayout();
            this.DeviceRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DevicesGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 508);
            this.panel1.TabIndex = 0;
            // 
            // DevicesGroupBox
            // 
            this.DevicesGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.DevicesGroupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DevicesGroupBox.Controls.Add(this.DeviceList);
            this.DevicesGroupBox.Controls.Add(this.DevicesMenuStrip);
            this.DevicesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevicesGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DevicesGroupBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DevicesGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DevicesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.DevicesGroupBox.Name = "DevicesGroupBox";
            this.DevicesGroupBox.Size = new System.Drawing.Size(749, 508);
            this.DevicesGroupBox.TabIndex = 1;
            this.DevicesGroupBox.TabStop = false;
            this.DevicesGroupBox.Text = "设备管理";
            // 
            // DeviceList
            // 
            this.DeviceList.AllowUserToAddRows = false;
            this.DeviceList.AllowUserToDeleteRows = false;
            this.DeviceList.AllowUserToResizeColumns = false;
            this.DeviceList.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeviceList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.DeviceList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.DeviceList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeviceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DeviceList.ColumnHeadersHeight = 30;
            this.DeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DeviceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.DeviceName,
            this.Ip,
            this.OpenOrClosePCState,
            this.ConnectionState,
            this.BootTime,
            this.CPURatio,
            this.MemoryRatio,
            this.GPURatio,
            this.GPUMemory,
            this.NetDelay,
            this.StereoState,
            this.LeftRightEyeState,
            this.ProcessSate,
            this.Remark});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DeviceList.DefaultCellStyle = dataGridViewCellStyle16;
            this.DeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceList.EnableHeadersVisualStyles = false;
            this.DeviceList.GridColor = System.Drawing.Color.DimGray;
            this.DeviceList.Location = new System.Drawing.Point(3, 44);
            this.DeviceList.Name = "DeviceList";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeviceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.DeviceList.RowHeadersVisible = false;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            this.DeviceList.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.DeviceList.RowTemplate.Height = 23;
            this.DeviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DeviceList.Size = new System.Drawing.Size(743, 461);
            this.DeviceList.TabIndex = 0;
            this.DeviceList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DeviceList_CellMouseUp);
            // 
            // DevicesMenuStrip
            // 
            this.DevicesMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.DevicesMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDeviceToolStripMenuItem,
            this.DeleteDeviceToolStripMenuItem});
            this.DevicesMenuStrip.Location = new System.Drawing.Point(3, 19);
            this.DevicesMenuStrip.Name = "DevicesMenuStrip";
            this.DevicesMenuStrip.Size = new System.Drawing.Size(743, 25);
            this.DevicesMenuStrip.TabIndex = 1;
            this.DevicesMenuStrip.Text = "menuStrip1";
            // 
            // AddDeviceToolStripMenuItem
            // 
            this.AddDeviceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.AddDeviceToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddDeviceToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.AddDeviceToolStripMenuItem.Name = "AddDeviceToolStripMenuItem";
            this.AddDeviceToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.AddDeviceToolStripMenuItem.Text = "添加设备";
            this.AddDeviceToolStripMenuItem.Click += new System.EventHandler(this.AddDeviceToolStripMenuItem_Click);
            // 
            // DeleteDeviceToolStripMenuItem
            // 
            this.DeleteDeviceToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.DeleteDeviceToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteDeviceToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DeleteDeviceToolStripMenuItem.Name = "DeleteDeviceToolStripMenuItem";
            this.DeleteDeviceToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.DeleteDeviceToolStripMenuItem.Text = "批量删除";
            this.DeleteDeviceToolStripMenuItem.Click += new System.EventHandler(this.DeleteDeviceToolStripMenuItem_Click);
            // 
            // DeviceRightClick
            // 
            this.DeviceRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteUserInfoToolStripMenuItem,
            this.AujustUserInfoToolStripMenuItem});
            this.DeviceRightClick.Name = "UserRightClick";
            this.DeviceRightClick.Size = new System.Drawing.Size(125, 48);
            // 
            // DeleteUserInfoToolStripMenuItem
            // 
            this.DeleteUserInfoToolStripMenuItem.Name = "DeleteUserInfoToolStripMenuItem";
            this.DeleteUserInfoToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.DeleteUserInfoToolStripMenuItem.Text = "删除设备";
            this.DeleteUserInfoToolStripMenuItem.Click += new System.EventHandler(this.DeleteDeiveInfoToolStripMenuItem_Click);
            // 
            // AujustUserInfoToolStripMenuItem
            // 
            this.AujustUserInfoToolStripMenuItem.Name = "AujustUserInfoToolStripMenuItem";
            this.AujustUserInfoToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.AujustUserInfoToolStripMenuItem.Text = "编辑设备";
            this.AujustUserInfoToolStripMenuItem.Click += new System.EventHandler(this.AujustDeviceInfoToolStripMenuItem_Click);
            // 
            // Selected
            // 
            this.Selected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            this.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Selected.ToolTipText = "选择编辑";
            this.Selected.Width = 40;
            // 
            // DeviceName
            // 
            this.DeviceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeviceName.DefaultCellStyle = dataGridViewCellStyle15;
            this.DeviceName.HeaderText = "名称";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeviceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DeviceName.ToolTipText = "用户的昵称";
            this.DeviceName.Width = 37;
            // 
            // Ip
            // 
            this.Ip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ip.HeaderText = "IP地址";
            this.Ip.Name = "Ip";
            this.Ip.ReadOnly = true;
            this.Ip.Width = 68;
            // 
            // OpenOrClosePCState
            // 
            this.OpenOrClosePCState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OpenOrClosePCState.HeaderText = "开/关机状态";
            this.OpenOrClosePCState.Name = "OpenOrClosePCState";
            this.OpenOrClosePCState.ReadOnly = true;
            this.OpenOrClosePCState.Width = 79;
            // 
            // ConnectionState
            // 
            this.ConnectionState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ConnectionState.HeaderText = "连接状态";
            this.ConnectionState.Name = "ConnectionState";
            this.ConnectionState.ReadOnly = true;
            this.ConnectionState.Width = 61;
            // 
            // BootTime
            // 
            this.BootTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BootTime.HeaderText = "开机时间";
            this.BootTime.Name = "BootTime";
            this.BootTime.ReadOnly = true;
            this.BootTime.Width = 80;
            // 
            // CPURatio
            // 
            this.CPURatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CPURatio.HeaderText = "CPU%";
            this.CPURatio.Name = "CPURatio";
            this.CPURatio.ReadOnly = true;
            this.CPURatio.Width = 68;
            // 
            // MemoryRatio
            // 
            this.MemoryRatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MemoryRatio.HeaderText = "可用内存%";
            this.MemoryRatio.Name = "MemoryRatio";
            this.MemoryRatio.ReadOnly = true;
            this.MemoryRatio.Width = 91;
            // 
            // GPURatio
            // 
            this.GPURatio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GPURatio.HeaderText = "GPU%";
            this.GPURatio.Name = "GPURatio";
            this.GPURatio.ReadOnly = true;
            this.GPURatio.Width = 69;
            // 
            // GPUMemory
            // 
            this.GPUMemory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GPUMemory.HeaderText = "显存占用";
            this.GPUMemory.Name = "GPUMemory";
            this.GPUMemory.ReadOnly = true;
            this.GPUMemory.Width = 80;
            // 
            // NetDelay
            // 
            this.NetDelay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NetDelay.HeaderText = "Ping(ms)";
            this.NetDelay.Name = "NetDelay";
            this.NetDelay.ReadOnly = true;
            this.NetDelay.Width = 88;
            // 
            // StereoState
            // 
            this.StereoState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StereoState.HeaderText = "立体状态";
            this.StereoState.Name = "StereoState";
            this.StereoState.ReadOnly = true;
            this.StereoState.Width = 80;
            // 
            // LeftRightEyeState
            // 
            this.LeftRightEyeState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LeftRightEyeState.HeaderText = "左右眼状态";
            this.LeftRightEyeState.Name = "LeftRightEyeState";
            this.LeftRightEyeState.ReadOnly = true;
            this.LeftRightEyeState.Width = 92;
            // 
            // ProcessSate
            // 
            this.ProcessSate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProcessSate.HeaderText = "运行进程";
            this.ProcessSate.Name = "ProcessSate";
            this.ProcessSate.ReadOnly = true;
            this.ProcessSate.Width = 80;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 56;
            // 
            // PingTimer
            // 
            this.PingTimer.Tick += new System.EventHandler(this.PingTimer_Tick);
            // 
            // OCC_Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 508);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.DevicesMenuStrip;
            this.Name = "OCC_Device";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCC_Users";
            this.Load += new System.EventHandler(this.OCC_Device_Load);
            this.panel1.ResumeLayout(false);
            this.DevicesGroupBox.ResumeLayout(false);
            this.DevicesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceList)).EndInit();
            this.DevicesMenuStrip.ResumeLayout(false);
            this.DevicesMenuStrip.PerformLayout();
            this.DeviceRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DeviceList;
        private System.Windows.Forms.GroupBox DevicesGroupBox;
        private System.Windows.Forms.MenuStrip DevicesMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteDeviceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip DeviceRightClick;
        private System.Windows.Forms.ToolStripMenuItem DeleteUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AujustUserInfoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ip;
        private System.Windows.Forms.DataGridViewImageColumn OpenOrClosePCState;
        private System.Windows.Forms.DataGridViewImageColumn ConnectionState;
        private System.Windows.Forms.DataGridViewTextBoxColumn BootTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPURatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoryRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPURatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPUMemory;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn StereoState;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeftRightEyeState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessSate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.Timer PingTimer;
    }
}