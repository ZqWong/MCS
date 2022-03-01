using System;

namespace MCS
{
    partial class 主界面
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbAllSelect = new System.Windows.Forms.CheckBox();
            this.btnControlExamPC = new System.Windows.Forms.Button();
            this.MCS_DataGridView = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamPCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenOrClosePCState = new System.Windows.Forms.DataGridViewImageColumn();
            this.ConnectionState = new System.Windows.Forms.DataGridViewImageColumn();
            this.ExamAppOpenState = new System.Windows.Forms.DataGridViewImageColumn();
            this.ExaminationContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamState = new System.Windows.Forms.DataGridViewImageColumn();
            this.ExamPCState = new System.Windows.Forms.DataGridViewImageColumn();
            this.Client_system_tick_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResetButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationResultID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExaminationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpu_ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memory_available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpu_ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpu_memory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stereo_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftRight_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.process_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbControlMainArea = new System.Windows.Forms.GroupBox();
            this.cbAction = new System.Windows.Forms.ComboBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.刷新StripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.播放管理toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.考试成绩管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.考题管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.考试相关信息录入界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.考生管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.考生所属公司管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.备份数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还原数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分组信息StripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统日志管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开系统日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.考试机配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.传输文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新客户端toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.远程控制StripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进程管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试配置文件xmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他设备控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.版本信息ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_server = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_stereo = new System.Windows.Forms.Button();
            this.button_leftRight = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_delay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_process_off = new System.Windows.Forms.Button();
            this.comboBox_process = new System.Windows.Forms.ComboBox();
            this.button_process_on = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_device = new System.Windows.Forms.ComboBox();
            this.button_device_on = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox_groupInfo = new System.Windows.Forms.GroupBox();
            this.button_groupOff = new System.Windows.Forms.Button();
            this.comboBox_group = new System.Windows.Forms.ComboBox();
            this.button_groupOn = new System.Windows.Forms.Button();
            this.button_allPowerOn = new System.Windows.Forms.Button();
            this.button_allPowerOff = new System.Windows.Forms.Button();
            this.timer_power = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_playOn = new System.Windows.Forms.Button();
            this.comboBox_playList = new System.Windows.Forms.ComboBox();
            this.button_playOff = new System.Windows.Forms.Button();
            this.button_last = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_last = new System.Windows.Forms.Label();
            this.label_cur = new System.Windows.Forms.Label();
            this.label_next = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.MCS_DataGridView)).BeginInit();
            this.gbControlMainArea.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox_groupInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAllSelect
            // 
            this.cbAllSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAllSelect.AutoSize = true;
            this.cbAllSelect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbAllSelect.Location = new System.Drawing.Point(234, 928);
            this.cbAllSelect.Name = "cbAllSelect";
            this.cbAllSelect.Size = new System.Drawing.Size(61, 25);
            this.cbAllSelect.TabIndex = 8;
            this.cbAllSelect.Text = "全选";
            this.cbAllSelect.UseVisualStyleBackColor = true;
            this.cbAllSelect.CheckedChanged += new System.EventHandler(this.cbAllSelect_CheckedChanged);
            // 
            // btnControlExamPC
            // 
            this.btnControlExamPC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnControlExamPC.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnControlExamPC.Location = new System.Drawing.Point(6, 76);
            this.btnControlExamPC.Name = "btnControlExamPC";
            this.btnControlExamPC.Size = new System.Drawing.Size(82, 30);
            this.btnControlExamPC.TabIndex = 9;
            this.btnControlExamPC.Text = "应用";
            this.btnControlExamPC.UseVisualStyleBackColor = true;
            this.btnControlExamPC.Click += new System.EventHandler(this.btnControlExamPC_Click);
            // 
            // MCS_DataGridView
            // 
            this.MCS_DataGridView.AllowUserToAddRows = false;
            this.MCS_DataGridView.AllowUserToDeleteRows = false;
            this.MCS_DataGridView.AllowUserToResizeColumns = false;
            this.MCS_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MCS_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MCS_DataGridView.ColumnHeadersHeight = 30;
            this.MCS_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.MCS_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.No,
            this.ExamPCName,
            this.IP,
            this.OpenOrClosePCState,
            this.ConnectionState,
            this.ExamAppOpenState,
            this.ExaminationContent,
            this.ExamineeName,
            this.ExamState,
            this.ExamPCState,
            this.Client_system_tick_count,
            this.ResetButton,
            this.Mac,
            this.Type,
            this.ExaminationResultID,
            this.ExaminationID,
            this.ExamineeID,
            this.cpu_ratio,
            this.memory_available,
            this.gpu_ratio,
            this.gpu_memory,
            this.netDelay,
            this.stereo_state,
            this.leftRight_state,
            this.process_state});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MCS_DataGridView.DefaultCellStyle = dataGridViewCellStyle13;
            this.MCS_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MCS_DataGridView.Location = new System.Drawing.Point(3, 17);
            this.MCS_DataGridView.Name = "MCS_DataGridView";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 10F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MCS_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.MCS_DataGridView.RowHeadersVisible = false;
            this.MCS_DataGridView.RowHeadersWidth = 40;
            this.MCS_DataGridView.RowTemplate.Height = 40;
            this.MCS_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MCS_DataGridView.Size = new System.Drawing.Size(1060, 879);
            this.MCS_DataGridView.TabIndex = 4;
            this.MCS_DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MCS_DataGridView_CellContentClick);
            this.MCS_DataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.MCS_DataGridView_CellValueChanged);
            this.MCS_DataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.MCS_DataGridView_CurrentCellDirtyStateChanged);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.MinimumWidth = 30;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CheckBox.Width = 30;
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.No.DefaultCellStyle = dataGridViewCellStyle2;
            this.No.HeaderText = "编号";
            this.No.MinimumWidth = 10;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Visible = false;
            this.No.Width = 38;
            // 
            // ExamPCName
            // 
            this.ExamPCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamPCName.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExamPCName.HeaderText = "名称";
            this.ExamPCName.MinimumWidth = 10;
            this.ExamPCName.Name = "ExamPCName";
            this.ExamPCName.ReadOnly = true;
            this.ExamPCName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamPCName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExamPCName.Width = 38;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IP.DefaultCellStyle = dataGridViewCellStyle4;
            this.IP.HeaderText = "IP地址";
            this.IP.MinimumWidth = 10;
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IP.Width = 49;
            // 
            // OpenOrClosePCState
            // 
            this.OpenOrClosePCState.HeaderText = "开/关机状态";
            this.OpenOrClosePCState.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.OpenOrClosePCState.MinimumWidth = 90;
            this.OpenOrClosePCState.Name = "OpenOrClosePCState";
            this.OpenOrClosePCState.ReadOnly = true;
            this.OpenOrClosePCState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OpenOrClosePCState.Width = 90;
            // 
            // ConnectionState
            // 
            this.ConnectionState.HeaderText = "连接状态";
            this.ConnectionState.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ConnectionState.MinimumWidth = 90;
            this.ConnectionState.Name = "ConnectionState";
            this.ConnectionState.ReadOnly = true;
            this.ConnectionState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ConnectionState.Width = 90;
            // 
            // ExamAppOpenState
            // 
            this.ExamAppOpenState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ExamAppOpenState.HeaderText = "考试系统状态";
            this.ExamAppOpenState.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ExamAppOpenState.MinimumWidth = 100;
            this.ExamAppOpenState.Name = "ExamAppOpenState";
            this.ExamAppOpenState.ReadOnly = true;
            this.ExamAppOpenState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamAppOpenState.Visible = false;
            // 
            // ExaminationContent
            // 
            this.ExaminationContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExaminationContent.HeaderText = "考试内容";
            this.ExaminationContent.MinimumWidth = 300;
            this.ExaminationContent.Name = "ExaminationContent";
            this.ExaminationContent.ReadOnly = true;
            this.ExaminationContent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExaminationContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExaminationContent.Visible = false;
            // 
            // ExamineeName
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ExamineeName.DefaultCellStyle = dataGridViewCellStyle5;
            this.ExamineeName.HeaderText = "考生姓名";
            this.ExamineeName.MinimumWidth = 100;
            this.ExamineeName.Name = "ExamineeName";
            this.ExamineeName.ReadOnly = true;
            this.ExamineeName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExamineeName.Visible = false;
            // 
            // ExamState
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExamState.DefaultCellStyle = dataGridViewCellStyle6;
            this.ExamState.HeaderText = "考试状态";
            this.ExamState.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ExamState.MinimumWidth = 100;
            this.ExamState.Name = "ExamState";
            this.ExamState.ReadOnly = true;
            this.ExamState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamState.Visible = false;
            // 
            // ExamPCState
            // 
            this.ExamPCState.HeaderText = "考试机状态";
            this.ExamPCState.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.ExamPCState.MinimumWidth = 90;
            this.ExamPCState.Name = "ExamPCState";
            this.ExamPCState.ReadOnly = true;
            this.ExamPCState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamPCState.Visible = false;
            this.ExamPCState.Width = 90;
            // 
            // Client_system_tick_count
            // 
            this.Client_system_tick_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Client_system_tick_count.DefaultCellStyle = dataGridViewCellStyle7;
            this.Client_system_tick_count.HeaderText = "  开机时间  ";
            this.Client_system_tick_count.Name = "Client_system_tick_count";
            this.Client_system_tick_count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Client_system_tick_count.Width = 78;
            // 
            // ResetButton
            // 
            this.ResetButton.HeaderText = "";
            this.ResetButton.MinimumWidth = 100;
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ResetButton.Visible = false;
            // 
            // Mac
            // 
            this.Mac.HeaderText = "Mac";
            this.Mac.Name = "Mac";
            this.Mac.Visible = false;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.Visible = false;
            // 
            // ExaminationResultID
            // 
            this.ExaminationResultID.HeaderText = "ExaminationResultID";
            this.ExaminationResultID.Name = "ExaminationResultID";
            this.ExaminationResultID.Visible = false;
            // 
            // ExaminationID
            // 
            this.ExaminationID.HeaderText = "ExaminationID";
            this.ExaminationID.Name = "ExaminationID";
            this.ExaminationID.Visible = false;
            // 
            // ExamineeID
            // 
            this.ExamineeID.HeaderText = "ExamineeID";
            this.ExamineeID.Name = "ExamineeID";
            this.ExamineeID.Visible = false;
            // 
            // cpu_ratio
            // 
            this.cpu_ratio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cpu_ratio.DefaultCellStyle = dataGridViewCellStyle8;
            this.cpu_ratio.HeaderText = "CPU %";
            this.cpu_ratio.Name = "cpu_ratio";
            this.cpu_ratio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cpu_ratio.Width = 53;
            // 
            // memory_available
            // 
            this.memory_available.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.memory_available.DefaultCellStyle = dataGridViewCellStyle9;
            this.memory_available.HeaderText = "可用内存(G)";
            this.memory_available.Name = "memory_available";
            this.memory_available.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.memory_available.Width = 79;
            // 
            // gpu_ratio
            // 
            this.gpu_ratio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gpu_ratio.HeaderText = "GPU %";
            this.gpu_ratio.Name = "gpu_ratio";
            this.gpu_ratio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gpu_ratio.Width = 54;
            // 
            // gpu_memory
            // 
            this.gpu_memory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gpu_memory.HeaderText = "显存占用 %";
            this.gpu_memory.Name = "gpu_memory";
            this.gpu_memory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gpu_memory.Width = 77;
            // 
            // netDelay
            // 
            this.netDelay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.netDelay.HeaderText = "PING ms";
            this.netDelay.Name = "netDelay";
            this.netDelay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.netDelay.Width = 65;
            // 
            // stereo_state
            // 
            this.stereo_state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.stereo_state.DefaultCellStyle = dataGridViewCellStyle10;
            this.stereo_state.HeaderText = "立体状态";
            this.stereo_state.Name = "stereo_state";
            this.stereo_state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stereo_state.Width = 62;
            // 
            // leftRight_state
            // 
            this.leftRight_state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.leftRight_state.DefaultCellStyle = dataGridViewCellStyle11;
            this.leftRight_state.HeaderText = "左右眼状态";
            this.leftRight_state.Name = "leftRight_state";
            this.leftRight_state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.leftRight_state.Width = 74;
            // 
            // process_state
            // 
            this.process_state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.process_state.DefaultCellStyle = dataGridViewCellStyle12;
            this.process_state.HeaderText = "运行进程";
            this.process_state.Name = "process_state";
            this.process_state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gbControlMainArea
            // 
            this.gbControlMainArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControlMainArea.Controls.Add(this.MCS_DataGridView);
            this.gbControlMainArea.Location = new System.Drawing.Point(231, 32);
            this.gbControlMainArea.Name = "gbControlMainArea";
            this.gbControlMainArea.Size = new System.Drawing.Size(1066, 899);
            this.gbControlMainArea.TabIndex = 10;
            this.gbControlMainArea.TabStop = false;
            // 
            // cbAction
            // 
            this.cbAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbAction.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Items.AddRange(new object[] {
            "",
            "开机",
            "关机",
            "重启"});
            this.cbAction.Location = new System.Drawing.Point(6, 24);
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(189, 25);
            this.cbAction.TabIndex = 11;
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新StripMenuItem1,
            this.播放管理toolStripMenuItem,
            this.考试成绩管理ToolStripMenuItem,
            this.考题管理ToolStripMenuItem,
            this.考生管理ToolStripMenuItem,
            this.考生所属公司管理ToolStripMenuItem,
            this.用户管理ToolStripMenuItem,
            this.数据库管理ToolStripMenuItem,
            this.分组信息StripMenuItem,
            this.系统日志管理ToolStripMenuItem,
            this.系统管理ToolStripMenuItem,
            this.传输文件ToolStripMenuItem,
            this.测试ToolStripMenuItem,
            this.更新客户端toolStripMenuItem,
            this.远程控制StripMenuItem,
            this.进程管理ToolStripMenuItem,
            this.测试配置文件xmlToolStripMenuItem,
            this.其他设备控制ToolStripMenuItem,
            this.帮助ToolStripMenuItem1,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1309, 29);
            this.menuStrip.TabIndex = 12;
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // 刷新StripMenuItem1
            // 
            this.刷新StripMenuItem1.Name = "刷新StripMenuItem1";
            this.刷新StripMenuItem1.Size = new System.Drawing.Size(86, 25);
            this.刷新StripMenuItem1.Text = "显示刷新";
            this.刷新StripMenuItem1.Click += new System.EventHandler(this.刷新StripMenuItem1_Click);
            // 
            // 播放管理toolStripMenuItem
            // 
            this.播放管理toolStripMenuItem.Name = "播放管理toolStripMenuItem";
            this.播放管理toolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.播放管理toolStripMenuItem.Text = "播放管理";
            this.播放管理toolStripMenuItem.Click += new System.EventHandler(this.播放管理toolStripMenuItem_Click);
            // 
            // 考试成绩管理ToolStripMenuItem
            // 
            this.考试成绩管理ToolStripMenuItem.Name = "考试成绩管理ToolStripMenuItem";
            this.考试成绩管理ToolStripMenuItem.Size = new System.Drawing.Size(118, 25);
            this.考试成绩管理ToolStripMenuItem.Text = "考试成绩查询";
            this.考试成绩管理ToolStripMenuItem.Visible = false;
            this.考试成绩管理ToolStripMenuItem.Click += new System.EventHandler(this.考试成绩管理ToolStripMenuItem_Click);
            // 
            // 考题管理ToolStripMenuItem
            // 
            this.考题管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.考试相关信息录入界面ToolStripMenuItem});
            this.考题管理ToolStripMenuItem.Name = "考题管理ToolStripMenuItem";
            this.考题管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.考题管理ToolStripMenuItem.Text = "考题管理";
            this.考题管理ToolStripMenuItem.Visible = false;
            this.考题管理ToolStripMenuItem.Click += new System.EventHandler(this.考题管理ToolStripMenuItem_Click);
            // 
            // 考试相关信息录入界面ToolStripMenuItem
            // 
            this.考试相关信息录入界面ToolStripMenuItem.Name = "考试相关信息录入界面ToolStripMenuItem";
            this.考试相关信息录入界面ToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.考试相关信息录入界面ToolStripMenuItem.Text = "考试相关信息录入界面";
            this.考试相关信息录入界面ToolStripMenuItem.Click += new System.EventHandler(this.考试相关信息录入界面ToolStripMenuItem_Click);
            // 
            // 考生管理ToolStripMenuItem
            // 
            this.考生管理ToolStripMenuItem.Name = "考生管理ToolStripMenuItem";
            this.考生管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.考生管理ToolStripMenuItem.Text = "考生管理";
            this.考生管理ToolStripMenuItem.Visible = false;
            this.考生管理ToolStripMenuItem.Click += new System.EventHandler(this.考生管理ToolStripMenuItem_Click);
            // 
            // 考生所属公司管理ToolStripMenuItem
            // 
            this.考生所属公司管理ToolStripMenuItem.Name = "考生所属公司管理ToolStripMenuItem";
            this.考生所属公司管理ToolStripMenuItem.Size = new System.Drawing.Size(150, 25);
            this.考生所属公司管理ToolStripMenuItem.Text = "考生所属公司管理";
            this.考生所属公司管理ToolStripMenuItem.Visible = false;
            this.考生所属公司管理ToolStripMenuItem.Click += new System.EventHandler(this.考生所属公司管理ToolStripMenuItem_Click);
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.用户管理ToolStripMenuItem.Text = "用户管理";
            this.用户管理ToolStripMenuItem.Visible = false;
            this.用户管理ToolStripMenuItem.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
            // 
            // 数据库管理ToolStripMenuItem
            // 
            this.数据库管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.备份数据库ToolStripMenuItem,
            this.还原数据库ToolStripMenuItem});
            this.数据库管理ToolStripMenuItem.Name = "数据库管理ToolStripMenuItem";
            this.数据库管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.数据库管理ToolStripMenuItem.Text = "数据管理";
            // 
            // 备份数据库ToolStripMenuItem
            // 
            this.备份数据库ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.备份数据库ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.备份数据库ToolStripMenuItem.Name = "备份数据库ToolStripMenuItem";
            this.备份数据库ToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.备份数据库ToolStripMenuItem.Text = "备份数据库";
            this.备份数据库ToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.备份数据库ToolStripMenuItem.Click += new System.EventHandler(this.备份数据库ToolStripMenuItem_Click);
            // 
            // 还原数据库ToolStripMenuItem
            // 
            this.还原数据库ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.还原数据库ToolStripMenuItem.Name = "还原数据库ToolStripMenuItem";
            this.还原数据库ToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.还原数据库ToolStripMenuItem.Text = "还原数据库";
            this.还原数据库ToolStripMenuItem.Click += new System.EventHandler(this.还原数据库ToolStripMenuItem_Click);
            // 
            // 分组信息StripMenuItem
            // 
            this.分组信息StripMenuItem.Name = "分组信息StripMenuItem";
            this.分组信息StripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.分组信息StripMenuItem.Text = "分组信息";
            this.分组信息StripMenuItem.Click += new System.EventHandler(this.分组信息StripMenuItem_Click);
            // 
            // 系统日志管理ToolStripMenuItem
            // 
            this.系统日志管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开系统日志ToolStripMenuItem});
            this.系统日志管理ToolStripMenuItem.Name = "系统日志管理ToolStripMenuItem";
            this.系统日志管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.系统日志管理ToolStripMenuItem.Text = "查看日志";
            // 
            // 打开系统日志ToolStripMenuItem
            // 
            this.打开系统日志ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.打开系统日志ToolStripMenuItem.Name = "打开系统日志ToolStripMenuItem";
            this.打开系统日志ToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
            this.打开系统日志ToolStripMenuItem.Text = "打开系统日志";
            this.打开系统日志ToolStripMenuItem.Click += new System.EventHandler(this.打开系统日志ToolStripMenuItem_Click);
            // 
            // 系统管理ToolStripMenuItem
            // 
            this.系统管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.考试机配置ToolStripMenuItem});
            this.系统管理ToolStripMenuItem.Name = "系统管理ToolStripMenuItem";
            this.系统管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.系统管理ToolStripMenuItem.Text = "系统管理";
            // 
            // 考试机配置ToolStripMenuItem
            // 
            this.考试机配置ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.考试机配置ToolStripMenuItem.Name = "考试机配置ToolStripMenuItem";
            this.考试机配置ToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.考试机配置ToolStripMenuItem.Text = "客户端计算机配置";
            this.考试机配置ToolStripMenuItem.Click += new System.EventHandler(this.考试机配置ToolStripMenuItem_Click);
            // 
            // 传输文件ToolStripMenuItem
            // 
            this.传输文件ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.传输文件ToolStripMenuItem.Name = "传输文件ToolStripMenuItem";
            this.传输文件ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.传输文件ToolStripMenuItem.Text = "资源管理";
            this.传输文件ToolStripMenuItem.Click += new System.EventHandler(this.传输文件ToolStripMenuItem_Click);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.测试ToolStripMenuItem.Text = "测试";
            this.测试ToolStripMenuItem.Visible = false;
            this.测试ToolStripMenuItem.Click += new System.EventHandler(this.测试ToolStripMenuItem_Click);
            // 
            // 更新客户端toolStripMenuItem
            // 
            this.更新客户端toolStripMenuItem.Name = "更新客户端toolStripMenuItem";
            this.更新客户端toolStripMenuItem.Size = new System.Drawing.Size(134, 25);
            this.更新客户端toolStripMenuItem.Text = "更新集控客户端";
            this.更新客户端toolStripMenuItem.Visible = false;
            this.更新客户端toolStripMenuItem.Click += new System.EventHandler(this.更新客户端toolStripMenuItem_Click);
            // 
            // 远程控制StripMenuItem
            // 
            this.远程控制StripMenuItem.Name = "远程控制StripMenuItem";
            this.远程控制StripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.远程控制StripMenuItem.Text = "远程控制";
            this.远程控制StripMenuItem.Click += new System.EventHandler(this.远程控制StripMenuItem_Click);
            // 
            // 进程管理ToolStripMenuItem
            // 
            this.进程管理ToolStripMenuItem.Name = "进程管理ToolStripMenuItem";
            this.进程管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.进程管理ToolStripMenuItem.Text = "应用管理";
            this.进程管理ToolStripMenuItem.Click += new System.EventHandler(this.进程管理ToolStripMenuItem_Click);
            // 
            // 测试配置文件xmlToolStripMenuItem
            // 
            this.测试配置文件xmlToolStripMenuItem.Enabled = false;
            this.测试配置文件xmlToolStripMenuItem.Name = "测试配置文件xmlToolStripMenuItem";
            this.测试配置文件xmlToolStripMenuItem.Size = new System.Drawing.Size(145, 25);
            this.测试配置文件xmlToolStripMenuItem.Text = "测试配置文件xml";
            this.测试配置文件xmlToolStripMenuItem.Visible = false;
            this.测试配置文件xmlToolStripMenuItem.Click += new System.EventHandler(this.测试配置文件xmlToolStripMenuItem_Click);
            // 
            // 其他设备控制ToolStripMenuItem
            // 
            this.其他设备控制ToolStripMenuItem.Name = "其他设备控制ToolStripMenuItem";
            this.其他设备控制ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.其他设备控制ToolStripMenuItem.Text = "设备控制";
            this.其他设备控制ToolStripMenuItem.Click += new System.EventHandler(this.其他设备管理ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem2,
            this.版本信息ToolStripMenuItem1});
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(86, 25);
            this.帮助ToolStripMenuItem1.Text = "帮助信息";
            // 
            // 帮助ToolStripMenuItem2
            // 
            this.帮助ToolStripMenuItem2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.帮助ToolStripMenuItem2.Name = "帮助ToolStripMenuItem2";
            this.帮助ToolStripMenuItem2.Size = new System.Drawing.Size(135, 24);
            this.帮助ToolStripMenuItem2.Text = "帮助";
            this.帮助ToolStripMenuItem2.Click += new System.EventHandler(this.帮助ToolStripMenuItem2_Click);
            // 
            // 版本信息ToolStripMenuItem1
            // 
            this.版本信息ToolStripMenuItem1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.版本信息ToolStripMenuItem1.Name = "版本信息ToolStripMenuItem1";
            this.版本信息ToolStripMenuItem1.Size = new System.Drawing.Size(135, 24);
            this.版本信息ToolStripMenuItem1.Text = "版本信息";
            this.版本信息ToolStripMenuItem1.Click += new System.EventHandler(this.版本信息ToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel_server});
            this.statusStrip1.Location = new System.Drawing.Point(0, 955);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1309, 25);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(153, 20);
            this.toolStripStatusLabel1.Text = "欢迎使用多维集控系统 ";
            // 
            // toolStripStatusLabel_server
            // 
            this.toolStripStatusLabel_server.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.toolStripStatusLabel_server.Name = "toolStripStatusLabel_server";
            this.toolStripStatusLabel_server.Size = new System.Drawing.Size(152, 20);
            this.toolStripStatusLabel_server.Text = "toolStripStatusLabel2";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_refresh
            // 
            this.button_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_refresh.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_refresh.Location = new System.Drawing.Point(11, 36);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(82, 30);
            this.button_refresh.TabIndex = 14;
            this.button_refresh.Text = "刷新翻转";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_stereo
            // 
            this.button_stereo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_stereo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_stereo.Location = new System.Drawing.Point(11, 72);
            this.button_stereo.Name = "button_stereo";
            this.button_stereo.Size = new System.Drawing.Size(82, 30);
            this.button_stereo.TabIndex = 15;
            this.button_stereo.Text = "立体开/关";
            this.button_stereo.UseVisualStyleBackColor = true;
            this.button_stereo.Click += new System.EventHandler(this.button_stereo_Click);
            // 
            // button_leftRight
            // 
            this.button_leftRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_leftRight.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_leftRight.Location = new System.Drawing.Point(113, 36);
            this.button_leftRight.Name = "button_leftRight";
            this.button_leftRight.Size = new System.Drawing.Size(82, 30);
            this.button_leftRight.TabIndex = 16;
            this.button_leftRight.Text = "左右眼翻转";
            this.button_leftRight.UseVisualStyleBackColor = true;
            this.button_leftRight.Click += new System.EventHandler(this.button_leftRight_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_delay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbAction);
            this.groupBox1.Controls.Add(this.btnControlExamPC);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 121);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计算机管理";
            // 
            // textBox_delay
            // 
            this.textBox_delay.Location = new System.Drawing.Point(155, 79);
            this.textBox_delay.Name = "textBox_delay";
            this.textBox_delay.Size = new System.Drawing.Size(40, 26);
            this.textBox_delay.TabIndex = 13;
            this.textBox_delay.Text = "1";
            this.textBox_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "延时s:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_process_off);
            this.groupBox2.Controls.Add(this.comboBox_process);
            this.groupBox2.Controls.Add(this.button_process_on);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 701);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 121);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "应用管理";
            // 
            // button_process_off
            // 
            this.button_process_off.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_process_off.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_process_off.Location = new System.Drawing.Point(113, 76);
            this.button_process_off.Name = "button_process_off";
            this.button_process_off.Size = new System.Drawing.Size(82, 30);
            this.button_process_off.TabIndex = 12;
            this.button_process_off.Text = "关闭";
            this.button_process_off.UseVisualStyleBackColor = true;
            this.button_process_off.Click += new System.EventHandler(this.button_process_off_Click);
            // 
            // comboBox_process
            // 
            this.comboBox_process.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_process.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_process.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.comboBox_process.FormattingEnabled = true;
            this.comboBox_process.Items.AddRange(new object[] {
            "",
            "开机",
            "关机",
            "重启"});
            this.comboBox_process.Location = new System.Drawing.Point(6, 24);
            this.comboBox_process.Name = "comboBox_process";
            this.comboBox_process.Size = new System.Drawing.Size(189, 25);
            this.comboBox_process.TabIndex = 11;
            // 
            // button_process_on
            // 
            this.button_process_on.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_process_on.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_process_on.Location = new System.Drawing.Point(6, 76);
            this.button_process_on.Name = "button_process_on";
            this.button_process_on.Size = new System.Drawing.Size(82, 30);
            this.button_process_on.TabIndex = 9;
            this.button_process_on.Text = "启动";
            this.button_process_on.UseVisualStyleBackColor = true;
            this.button_process_on.Click += new System.EventHandler(this.button_process_on_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_device);
            this.groupBox3.Controls.Add(this.button_device_on);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(12, 573);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 121);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "方案控制";
            // 
            // comboBox_device
            // 
            this.comboBox_device.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_device.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_device.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.comboBox_device.FormattingEnabled = true;
            this.comboBox_device.Location = new System.Drawing.Point(6, 24);
            this.comboBox_device.Name = "comboBox_device";
            this.comboBox_device.Size = new System.Drawing.Size(189, 25);
            this.comboBox_device.TabIndex = 11;
            // 
            // button_device_on
            // 
            this.button_device_on.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_device_on.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_device_on.Location = new System.Drawing.Point(6, 69);
            this.button_device_on.Name = "button_device_on";
            this.button_device_on.Size = new System.Drawing.Size(82, 30);
            this.button_device_on.TabIndex = 13;
            this.button_device_on.Text = "启动";
            this.button_device_on.UseVisualStyleBackColor = true;
            this.button_device_on.Click += new System.EventHandler(this.button_device_on_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_refresh);
            this.groupBox4.Controls.Add(this.button_stereo);
            this.groupBox4.Controls.Add(this.button_leftRight);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(12, 829);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 121);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "显示控制";
            // 
            // groupBox_groupInfo
            // 
            this.groupBox_groupInfo.Controls.Add(this.button_groupOff);
            this.groupBox_groupInfo.Controls.Add(this.comboBox_group);
            this.groupBox_groupInfo.Controls.Add(this.button_groupOn);
            this.groupBox_groupInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_groupInfo.Location = new System.Drawing.Point(12, 445);
            this.groupBox_groupInfo.Name = "groupBox_groupInfo";
            this.groupBox_groupInfo.Size = new System.Drawing.Size(208, 121);
            this.groupBox_groupInfo.TabIndex = 20;
            this.groupBox_groupInfo.TabStop = false;
            this.groupBox_groupInfo.Text = "分组控制";
            // 
            // button_groupOff
            // 
            this.button_groupOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_groupOff.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_groupOff.Location = new System.Drawing.Point(113, 69);
            this.button_groupOff.Name = "button_groupOff";
            this.button_groupOff.Size = new System.Drawing.Size(82, 30);
            this.button_groupOff.TabIndex = 14;
            this.button_groupOff.Text = "关闭";
            this.button_groupOff.UseVisualStyleBackColor = true;
            this.button_groupOff.Click += new System.EventHandler(this.button_groupOff_Click);
            // 
            // comboBox_group
            // 
            this.comboBox_group.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_group.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_group.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.comboBox_group.FormattingEnabled = true;
            this.comboBox_group.Items.AddRange(new object[] {
            "",
            "开机",
            "关机",
            "重启"});
            this.comboBox_group.Location = new System.Drawing.Point(6, 24);
            this.comboBox_group.Name = "comboBox_group";
            this.comboBox_group.Size = new System.Drawing.Size(189, 25);
            this.comboBox_group.TabIndex = 11;
            this.comboBox_group.SelectedIndexChanged += new System.EventHandler(this.comboBox_group_SelectedIndexChanged);
            // 
            // button_groupOn
            // 
            this.button_groupOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_groupOn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_groupOn.Location = new System.Drawing.Point(6, 69);
            this.button_groupOn.Name = "button_groupOn";
            this.button_groupOn.Size = new System.Drawing.Size(82, 30);
            this.button_groupOn.TabIndex = 13;
            this.button_groupOn.Text = "启动";
            this.button_groupOn.UseVisualStyleBackColor = true;
            this.button_groupOn.Click += new System.EventHandler(this.button_groupOn_Click);
            // 
            // button_allPowerOn
            // 
            this.button_allPowerOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_allPowerOn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_allPowerOn.Location = new System.Drawing.Point(6, 10);
            this.button_allPowerOn.Name = "button_allPowerOn";
            this.button_allPowerOn.Size = new System.Drawing.Size(82, 30);
            this.button_allPowerOn.TabIndex = 21;
            this.button_allPowerOn.Text = "整体开机";
            this.button_allPowerOn.UseVisualStyleBackColor = true;
            this.button_allPowerOn.Click += new System.EventHandler(this.button_allPowerOn_Click);
            // 
            // button_allPowerOff
            // 
            this.button_allPowerOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_allPowerOff.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_allPowerOff.Location = new System.Drawing.Point(113, 10);
            this.button_allPowerOff.Name = "button_allPowerOff";
            this.button_allPowerOff.Size = new System.Drawing.Size(82, 30);
            this.button_allPowerOff.TabIndex = 22;
            this.button_allPowerOff.Text = "整体关机";
            this.button_allPowerOff.UseVisualStyleBackColor = true;
            this.button_allPowerOff.Click += new System.EventHandler(this.button_allPowerOff_Click);
            // 
            // timer_power
            // 
            this.timer_power.Interval = 1000;
            this.timer_power.Tick += new System.EventHandler(this.timer_power_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_allPowerOn);
            this.panel1.Controls.Add(this.button_allPowerOff);
            this.panel1.Location = new System.Drawing.Point(12, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 55);
            this.panel1.TabIndex = 23;
            // 
            // button_playOn
            // 
            this.button_playOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_playOn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_playOn.Location = new System.Drawing.Point(6, 110);
            this.button_playOn.Name = "button_playOn";
            this.button_playOn.Size = new System.Drawing.Size(82, 30);
            this.button_playOn.TabIndex = 9;
            this.button_playOn.Text = "播放";
            this.button_playOn.UseVisualStyleBackColor = true;
            this.button_playOn.Click += new System.EventHandler(this.button_playOn_Click);
            // 
            // comboBox_playList
            // 
            this.comboBox_playList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_playList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_playList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_playList.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.comboBox_playList.FormattingEnabled = true;
            this.comboBox_playList.Items.AddRange(new object[] {
            "",
            "开机",
            "关机",
            "重启"});
            this.comboBox_playList.Location = new System.Drawing.Point(6, 27);
            this.comboBox_playList.Name = "comboBox_playList";
            this.comboBox_playList.Size = new System.Drawing.Size(194, 25);
            this.comboBox_playList.TabIndex = 11;
            // 
            // button_playOff
            // 
            this.button_playOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_playOff.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_playOff.Location = new System.Drawing.Point(113, 110);
            this.button_playOff.Name = "button_playOff";
            this.button_playOff.Size = new System.Drawing.Size(82, 30);
            this.button_playOff.TabIndex = 12;
            this.button_playOff.Text = "停止";
            this.button_playOff.UseVisualStyleBackColor = true;
            this.button_playOff.Click += new System.EventHandler(this.button_playOff_Click);
            // 
            // button_last
            // 
            this.button_last.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_last.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_last.Location = new System.Drawing.Point(6, 62);
            this.button_last.Name = "button_last";
            this.button_last.Size = new System.Drawing.Size(82, 30);
            this.button_last.TabIndex = 13;
            this.button_last.Text = "上一部";
            this.button_last.UseVisualStyleBackColor = true;
            this.button_last.Click += new System.EventHandler(this.button_last_Click);
            // 
            // button_next
            // 
            this.button_next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_next.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button_next.Location = new System.Drawing.Point(113, 62);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(82, 30);
            this.button_next.TabIndex = 14;
            this.button_next.Text = "下一部";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "上一部：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "当前部：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "下一部：";
            // 
            // label_last
            // 
            this.label_last.AutoSize = true;
            this.label_last.Location = new System.Drawing.Point(66, 153);
            this.label_last.Name = "label_last";
            this.label_last.Size = new System.Drawing.Size(0, 20);
            this.label_last.TabIndex = 18;
            // 
            // label_cur
            // 
            this.label_cur.AutoSize = true;
            this.label_cur.Location = new System.Drawing.Point(66, 174);
            this.label_cur.Name = "label_cur";
            this.label_cur.Size = new System.Drawing.Size(0, 20);
            this.label_cur.TabIndex = 19;
            // 
            // label_next
            // 
            this.label_next.AutoSize = true;
            this.label_next.Location = new System.Drawing.Point(66, 195);
            this.label_next.Name = "label_next";
            this.label_next.Size = new System.Drawing.Size(0, 20);
            this.label_next.TabIndex = 20;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label_next);
            this.groupBox5.Controls.Add(this.label_cur);
            this.groupBox5.Controls.Add(this.label_last);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.button_next);
            this.groupBox5.Controls.Add(this.button_last);
            this.groupBox5.Controls.Add(this.button_playOff);
            this.groupBox5.Controls.Add(this.comboBox_playList);
            this.groupBox5.Controls.Add(this.button_playOn);
            this.groupBox5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(12, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(208, 223);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "播放管理";
            // 
            // 主界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 980);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox_groupInfo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbControlMainArea);
            this.Controls.Add(this.cbAllSelect);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "主界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多维集控";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.主界面_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.主界面_FormClosed);
            this.Load += new System.EventHandler(this.主界面_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.主界面_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MCS_DataGridView)).EndInit();
            this.gbControlMainArea.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox_groupInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.CheckBox cbAllSelect;
        private System.Windows.Forms.Button btnControlExamPC;
        public System.Windows.Forms.DataGridView MCS_DataGridView;
        private System.Windows.Forms.GroupBox gbControlMainArea;
        public System.Windows.Forms.ComboBox cbAction;

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 考试成绩管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 考生管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 考生所属公司管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备份数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还原数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统日志管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开系统日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 考试机配置ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 传输文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 考题管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 考试相关信息录入界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lnkyzhangToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 进程管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试配置文件xmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他设备控制ToolStripMenuItem;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_stereo;
        private System.Windows.Forms.Button button_leftRight;
        private System.Windows.Forms.ToolStripMenuItem 远程控制StripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新客户端toolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_process_off;
        public System.Windows.Forms.ComboBox comboBox_process;
        private System.Windows.Forms.Button button_process_on;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ComboBox comboBox_device;
        private System.Windows.Forms.Button button_device_on;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_delay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_server;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 版本信息ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 分组信息StripMenuItem;
        private System.Windows.Forms.GroupBox groupBox_groupInfo;
        private System.Windows.Forms.Button button_groupOff;
        public System.Windows.Forms.ComboBox comboBox_group;
        private System.Windows.Forms.Button button_groupOn;
        private System.Windows.Forms.ToolStripMenuItem 刷新StripMenuItem1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamPCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewImageColumn OpenOrClosePCState;
        private System.Windows.Forms.DataGridViewImageColumn ConnectionState;
        private System.Windows.Forms.DataGridViewImageColumn ExamAppOpenState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeName;
        private System.Windows.Forms.DataGridViewImageColumn ExamState;
        private System.Windows.Forms.DataGridViewImageColumn ExamPCState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client_system_tick_count;
        private System.Windows.Forms.DataGridViewButtonColumn ResetButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationResultID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExaminationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpu_ratio;
        private System.Windows.Forms.DataGridViewTextBoxColumn memory_available;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpu_ratio;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpu_memory;
        private System.Windows.Forms.DataGridViewTextBoxColumn netDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn stereo_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftRight_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn process_state;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 播放管理toolStripMenuItem;
        public System.Windows.Forms.Button button_allPowerOn;
        public System.Windows.Forms.Button button_allPowerOff;
        private System.Windows.Forms.Timer timer_power;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_playOn;
        public System.Windows.Forms.ComboBox comboBox_playList;
        private System.Windows.Forms.Button button_playOff;
        private System.Windows.Forms.Button button_last;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_last;
        private System.Windows.Forms.Label label_cur;
        private System.Windows.Forms.Label label_next;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}