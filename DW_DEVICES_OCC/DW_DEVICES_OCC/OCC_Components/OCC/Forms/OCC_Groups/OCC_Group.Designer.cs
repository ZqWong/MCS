namespace OCC.Forms
{
    partial class OCC_Group
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
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.DataGridViewDeviceBinded = new Sunny.UI.UIDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonEditExecute = new Sunny.UI.UIButton();
            this.ButtonDeleteExecute = new Sunny.UI.UIButton();
            this.ButtonAddExecute = new Sunny.UI.UIButton();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.DataGridViewGroup = new Sunny.UI.UIDataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonEditGroup = new Sunny.UI.UIButton();
            this.ButtonRemoveGroup = new Sunny.UI.UIButton();
            this.ButtonAddGroup = new Sunny.UI.UIButton();
            this.ExecuteSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Execute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDeviceBinded)).BeginInit();
            this.panel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewGroup)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1156, 737);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.DataGridViewDeviceBinded);
            this.uiGroupBox2.Controls.Add(this.panel1);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 373);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(1148, 359);
            this.uiGroupBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "设备操作";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataGridViewDeviceBinded
            // 
            this.DataGridViewDeviceBinded.AllowUserToAddRows = false;
            this.DataGridViewDeviceBinded.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridViewDeviceBinded.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewDeviceBinded.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewDeviceBinded.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDeviceBinded.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewDeviceBinded.ColumnHeadersHeight = 32;
            this.DataGridViewDeviceBinded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewDeviceBinded.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExecuteSelected,
            this.DeviceName,
            this.Delay,
            this.Execute,
            this.Sort});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewDeviceBinded.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewDeviceBinded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewDeviceBinded.EnableHeadersVisualStyles = false;
            this.DataGridViewDeviceBinded.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataGridViewDeviceBinded.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridViewDeviceBinded.Location = new System.Drawing.Point(0, 77);
            this.DataGridViewDeviceBinded.Name = "DataGridViewDeviceBinded";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDeviceBinded.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridViewDeviceBinded.RowHeadersVisible = false;
            this.DataGridViewDeviceBinded.RowHeight = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.DataGridViewDeviceBinded.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewDeviceBinded.RowTemplate.Height = 40;
            this.DataGridViewDeviceBinded.SelectedIndex = -1;
            this.DataGridViewDeviceBinded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewDeviceBinded.ShowGridLine = true;
            this.DataGridViewDeviceBinded.Size = new System.Drawing.Size(1148, 282);
            this.DataGridViewDeviceBinded.Style = Sunny.UI.UIStyle.Custom;
            this.DataGridViewDeviceBinded.TabIndex = 3;
            this.DataGridViewDeviceBinded.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewDeviceBinded_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ButtonEditExecute);
            this.panel1.Controls.Add(this.ButtonDeleteExecute);
            this.panel1.Controls.Add(this.ButtonAddExecute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1148, 45);
            this.panel1.TabIndex = 2;
            // 
            // ButtonEditExecute
            // 
            this.ButtonEditExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonEditExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonEditExecute.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditExecute.Location = new System.Drawing.Point(221, 5);
            this.ButtonEditExecute.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonEditExecute.Name = "ButtonEditExecute";
            this.ButtonEditExecute.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonEditExecute.Size = new System.Drawing.Size(100, 35);
            this.ButtonEditExecute.Style = Sunny.UI.UIStyle.Custom;
            this.ButtonEditExecute.TabIndex = 2;
            this.ButtonEditExecute.Text = "编辑操作";
            this.ButtonEditExecute.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditExecute.Click += new System.EventHandler(this.ButtonEditExecute_Click);
            // 
            // ButtonDeleteExecute
            // 
            this.ButtonDeleteExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonDeleteExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDeleteExecute.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonDeleteExecute.Location = new System.Drawing.Point(113, 5);
            this.ButtonDeleteExecute.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonDeleteExecute.Name = "ButtonDeleteExecute";
            this.ButtonDeleteExecute.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonDeleteExecute.Size = new System.Drawing.Size(100, 35);
            this.ButtonDeleteExecute.Style = Sunny.UI.UIStyle.Custom;
            this.ButtonDeleteExecute.TabIndex = 1;
            this.ButtonDeleteExecute.Text = "删除操作";
            this.ButtonDeleteExecute.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonDeleteExecute.Click += new System.EventHandler(this.ButtonDeleteExecute_Click);
            // 
            // ButtonAddExecute
            // 
            this.ButtonAddExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddExecute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddExecute.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddExecute.Location = new System.Drawing.Point(5, 5);
            this.ButtonAddExecute.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonAddExecute.Name = "ButtonAddExecute";
            this.ButtonAddExecute.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonAddExecute.Size = new System.Drawing.Size(100, 35);
            this.ButtonAddExecute.Style = Sunny.UI.UIStyle.Custom;
            this.ButtonAddExecute.TabIndex = 0;
            this.ButtonAddExecute.Text = "添加操作";
            this.ButtonAddExecute.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddExecute.Click += new System.EventHandler(this.ButtonAddExecute_Click);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.DataGridViewGroup);
            this.uiGroupBox1.Controls.Add(this.panel2);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1148, 358);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 0;
            this.uiGroupBox1.Text = "分组管理";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataGridViewGroup
            // 
            this.DataGridViewGroup.AllowUserToAddRows = false;
            this.DataGridViewGroup.AllowUserToDeleteRows = false;
            this.DataGridViewGroup.AllowUserToResizeColumns = false;
            this.DataGridViewGroup.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridViewGroup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridViewGroup.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewGroup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DataGridViewGroup.ColumnHeadersHeight = 32;
            this.DataGridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.GroupName,
            this.Remark});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewGroup.DefaultCellStyle = dataGridViewCellStyle8;
            this.DataGridViewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewGroup.EnableHeadersVisualStyles = false;
            this.DataGridViewGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataGridViewGroup.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridViewGroup.Location = new System.Drawing.Point(0, 77);
            this.DataGridViewGroup.Name = "DataGridViewGroup";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DataGridViewGroup.RowHeadersVisible = false;
            this.DataGridViewGroup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridViewGroup.RowHeight = 40;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.DataGridViewGroup.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DataGridViewGroup.RowTemplate.Height = 40;
            this.DataGridViewGroup.SelectedIndex = -1;
            this.DataGridViewGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewGroup.ShowGridLine = true;
            this.DataGridViewGroup.Size = new System.Drawing.Size(1148, 281);
            this.DataGridViewGroup.Style = Sunny.UI.UIStyle.Custom;
            this.DataGridViewGroup.TabIndex = 2;
            this.DataGridViewGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewGroup_CellClick);
            // 
            // Selected
            // 
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            this.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GroupName
            // 
            this.GroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GroupName.HeaderText = "分组名";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GroupName.Width = 82;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.HeaderText = "分组描述";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.ButtonEditGroup);
            this.panel2.Controls.Add(this.ButtonRemoveGroup);
            this.panel2.Controls.Add(this.ButtonAddGroup);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1148, 45);
            this.panel2.TabIndex = 1;
            // 
            // ButtonEditGroup
            // 
            this.ButtonEditGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonEditGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonEditGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditGroup.Location = new System.Drawing.Point(221, 5);
            this.ButtonEditGroup.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonEditGroup.Name = "ButtonEditGroup";
            this.ButtonEditGroup.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonEditGroup.Size = new System.Drawing.Size(100, 35);
            this.ButtonEditGroup.Style = Sunny.UI.UIStyle.Custom;
            this.ButtonEditGroup.TabIndex = 2;
            this.ButtonEditGroup.Text = "编辑分组";
            this.ButtonEditGroup.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditGroup.Click += new System.EventHandler(this.ButtonEditGroup_Click);
            // 
            // ButtonRemoveGroup
            // 
            this.ButtonRemoveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonRemoveGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonRemoveGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonRemoveGroup.Location = new System.Drawing.Point(113, 5);
            this.ButtonRemoveGroup.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonRemoveGroup.Name = "ButtonRemoveGroup";
            this.ButtonRemoveGroup.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonRemoveGroup.Size = new System.Drawing.Size(100, 35);
            this.ButtonRemoveGroup.Style = Sunny.UI.UIStyle.Custom;
            this.ButtonRemoveGroup.TabIndex = 1;
            this.ButtonRemoveGroup.Text = "删除分组";
            this.ButtonRemoveGroup.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonRemoveGroup.Click += new System.EventHandler(this.ButtonRemoveGroup_Click);
            // 
            // ButtonAddGroup
            // 
            this.ButtonAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddGroup.Location = new System.Drawing.Point(5, 5);
            this.ButtonAddGroup.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonAddGroup.Name = "ButtonAddGroup";
            this.ButtonAddGroup.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonAddGroup.Size = new System.Drawing.Size(100, 35);
            this.ButtonAddGroup.Style = Sunny.UI.UIStyle.Custom;
            this.ButtonAddGroup.TabIndex = 0;
            this.ButtonAddGroup.Text = "添加分组";
            this.ButtonAddGroup.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddGroup.Click += new System.EventHandler(this.ButtonAddGroup_Click);
            // 
            // ExecuteSelected
            // 
            this.ExecuteSelected.HeaderText = "选择";
            this.ExecuteSelected.Name = "ExecuteSelected";
            this.ExecuteSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // DeviceName
            // 
            this.DeviceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceName.HeaderText = "设备名";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Delay
            // 
            this.Delay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Delay.HeaderText = "延迟";
            this.Delay.Name = "Delay";
            this.Delay.ReadOnly = true;
            this.Delay.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Execute
            // 
            this.Execute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Execute.HeaderText = "操作";
            this.Execute.Name = "Execute";
            this.Execute.ReadOnly = true;
            this.Execute.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Sort
            // 
            this.Sort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sort.HeaderText = "排序";
            this.Sort.Name = "Sort";
            this.Sort.ReadOnly = true;
            // 
            // OCC_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1156, 737);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OCC_Group";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "OCC_Groups";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDeviceBinded)).EndInit();
            this.panel1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewGroup)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UIButton ButtonEditGroup;
        private Sunny.UI.UIButton ButtonRemoveGroup;
        private Sunny.UI.UIButton ButtonAddGroup;
        private Sunny.UI.UIDataGridView DataGridViewGroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private Sunny.UI.UIDataGridView DataGridViewDeviceBinded;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UIButton ButtonEditExecute;
        private Sunny.UI.UIButton ButtonDeleteExecute;
        private Sunny.UI.UIButton ButtonAddExecute;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ExecuteSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Execute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sort;
    }
}