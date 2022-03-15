namespace OCC.Forms
{
    partial class OCC_Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCC_Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.BtnGroupStart = new Sunny.UI.UIButton();
            this.ComboBoxGroup = new Sunny.UI.UIComboBox();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.BtnAppStart = new Sunny.UI.UIButton();
            this.ComboBoxApp = new Sunny.UI.UIComboBox();
            this.GroupBoxDeviceGroup = new Sunny.UI.UIGroupBox();
            this.DataGridViewDevice = new Sunny.UI.UIDataGridView();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SwitchButton = new System.Windows.Forms.DataGridViewImageColumn();
            this.ConnectionStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.DeviceStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.PowerSwitchImage = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.GroupBoxDeviceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.GroupBoxDeviceGroup, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 921);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.BtnGroupStart);
            this.uiGroupBox3.Controls.Add(this.ComboBoxGroup);
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.Location = new System.Drawing.Point(4, 586);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(1256, 90);
            this.uiGroupBox3.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox3.TabIndex = 2;
            this.uiGroupBox3.Text = "选择分组";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnGroupStart
            // 
            this.BtnGroupStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGroupStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGroupStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGroupStart.Location = new System.Drawing.Point(1098, 37);
            this.BtnGroupStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnGroupStart.Name = "BtnGroupStart";
            this.BtnGroupStart.Size = new System.Drawing.Size(150, 35);
            this.BtnGroupStart.Style = Sunny.UI.UIStyle.Custom;
            this.BtnGroupStart.TabIndex = 2;
            this.BtnGroupStart.Text = "开始培训";
            this.BtnGroupStart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnGroupStart.Click += new System.EventHandler(this.BtnGroupStart_Click);
            // 
            // ComboBoxGroup
            // 
            this.ComboBoxGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxGroup.DataSource = null;
            this.ComboBoxGroup.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ComboBoxGroup.FillColor = System.Drawing.Color.White;
            this.ComboBoxGroup.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ComboBoxGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxGroup.ItemHeight = 30;
            this.ComboBoxGroup.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ComboBoxGroup.Location = new System.Drawing.Point(9, 37);
            this.ComboBoxGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ComboBoxGroup.MinimumSize = new System.Drawing.Size(63, 0);
            this.ComboBoxGroup.Name = "ComboBoxGroup";
            this.ComboBoxGroup.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.ComboBoxGroup.Size = new System.Drawing.Size(1082, 35);
            this.ComboBoxGroup.Style = Sunny.UI.UIStyle.Custom;
            this.ComboBoxGroup.TabIndex = 1;
            this.ComboBoxGroup.Text = "uiComboBox2";
            this.ComboBoxGroup.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComboBoxGroup.Watermark = "选择要启动的分组";
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.BtnAppStart);
            this.uiGroupBox2.Controls.Add(this.ComboBoxApp);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(4, 486);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(1256, 90);
            this.uiGroupBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox2.TabIndex = 1;
            this.uiGroupBox2.Text = "选择系统";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnAppStart
            // 
            this.BtnAppStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAppStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAppStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAppStart.Location = new System.Drawing.Point(1098, 37);
            this.BtnAppStart.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.BtnAppStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnAppStart.Name = "BtnAppStart";
            this.BtnAppStart.Size = new System.Drawing.Size(150, 35);
            this.BtnAppStart.Style = Sunny.UI.UIStyle.Custom;
            this.BtnAppStart.TabIndex = 1;
            this.BtnAppStart.Text = "开始培训";
            this.BtnAppStart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAppStart.Click += new System.EventHandler(this.BtnAppStart_Click);
            // 
            // ComboBoxApp
            // 
            this.ComboBoxApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxApp.DataSource = null;
            this.ComboBoxApp.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.ComboBoxApp.FillColor = System.Drawing.Color.White;
            this.ComboBoxApp.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ComboBoxApp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxApp.ItemHeight = 30;
            this.ComboBoxApp.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ComboBoxApp.Location = new System.Drawing.Point(9, 37);
            this.ComboBoxApp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ComboBoxApp.MinimumSize = new System.Drawing.Size(63, 0);
            this.ComboBoxApp.Name = "ComboBoxApp";
            this.ComboBoxApp.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.ComboBoxApp.Size = new System.Drawing.Size(1082, 35);
            this.ComboBoxApp.Style = Sunny.UI.UIStyle.Custom;
            this.ComboBoxApp.TabIndex = 0;
            this.ComboBoxApp.Text = "uiComboBox2";
            this.ComboBoxApp.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComboBoxApp.Watermark = "选择要培训的系统";
            // 
            // GroupBoxDeviceGroup
            // 
            this.GroupBoxDeviceGroup.Controls.Add(this.DataGridViewDevice);
            this.GroupBoxDeviceGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBoxDeviceGroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupBoxDeviceGroup.Location = new System.Drawing.Point(4, 5);
            this.GroupBoxDeviceGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupBoxDeviceGroup.MinimumSize = new System.Drawing.Size(1, 1);
            this.GroupBoxDeviceGroup.Name = "GroupBoxDeviceGroup";
            this.GroupBoxDeviceGroup.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.GroupBoxDeviceGroup.Size = new System.Drawing.Size(1256, 471);
            this.GroupBoxDeviceGroup.Style = Sunny.UI.UIStyle.Custom;
            this.GroupBoxDeviceGroup.TabIndex = 0;
            this.GroupBoxDeviceGroup.Text = "设备名称";
            this.GroupBoxDeviceGroup.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataGridViewDevice
            // 
            this.DataGridViewDevice.AllowUserToAddRows = false;
            this.DataGridViewDevice.AllowUserToDeleteRows = false;
            this.DataGridViewDevice.AllowUserToResizeColumns = false;
            this.DataGridViewDevice.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridViewDevice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewDevice.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewDevice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDevice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewDevice.ColumnHeadersHeight = 32;
            this.DataGridViewDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeviceName,
            this.Selected,
            this.SwitchButton,
            this.ConnectionStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewDevice.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewDevice.EnableHeadersVisualStyles = false;
            this.DataGridViewDevice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataGridViewDevice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridViewDevice.Location = new System.Drawing.Point(0, 32);
            this.DataGridViewDevice.Name = "DataGridViewDevice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDevice.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridViewDevice.RowHeadersVisible = false;
            this.DataGridViewDevice.RowHeight = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.DataGridViewDevice.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewDevice.RowTemplate.Height = 40;
            this.DataGridViewDevice.SelectedIndex = -1;
            this.DataGridViewDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewDevice.ShowGridLine = true;
            this.DataGridViewDevice.Size = new System.Drawing.Size(1256, 439);
            this.DataGridViewDevice.Style = Sunny.UI.UIStyle.Custom;
            this.DataGridViewDevice.TabIndex = 0;
            this.DataGridViewDevice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewDevice_CellContentClick);
            // 
            // DeviceName
            // 
            this.DeviceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceName.HeaderText = "设备名称";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            // 
            // Selected
            // 
            this.Selected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Selected.HeaderText = "选定设备";
            this.Selected.Name = "Selected";
            // 
            // SwitchButton
            // 
            this.SwitchButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SwitchButton.HeaderText = "启动开关";
            this.SwitchButton.Image = global::OCC.Properties.Resources.switch_关;
            this.SwitchButton.Name = "SwitchButton";
            this.SwitchButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ConnectionStatus
            // 
            this.ConnectionStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ConnectionStatus.HeaderText = "连接状态";
            this.ConnectionStatus.Image = global::OCC.Properties.Resources.switch_关;
            this.ConnectionStatus.Name = "ConnectionStatus";
            this.ConnectionStatus.ReadOnly = true;
            this.ConnectionStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox4.Location = new System.Drawing.Point(4, 686);
            this.uiGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox4.Size = new System.Drawing.Size(1256, 230);
            this.uiGroupBox4.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox4.TabIndex = 3;
            this.uiGroupBox4.Text = "实时控制";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeviceStatusTimer
            // 
            this.DeviceStatusTimer.Tick += new System.EventHandler(this.DeviceStatusTimer_Tick);
            // 
            // PowerSwitchImage
            // 
            this.PowerSwitchImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PowerSwitchImage.ImageStream")));
            this.PowerSwitchImage.TransparentColor = System.Drawing.Color.Transparent;
            this.PowerSwitchImage.Images.SetKeyName(0, "switch-关.png");
            this.PowerSwitchImage.Images.SetKeyName(1, "switch-开.png");
            this.PowerSwitchImage.Images.SetKeyName(2, "关闭中.png");
            // 
            // OCC_Main
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 921);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OCC_Main";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "OCC_Main";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.GroupBoxDeviceGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDevice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UIGroupBox uiGroupBox4;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIGroupBox GroupBoxDeviceGroup;
        private Sunny.UI.UIComboBox ComboBoxGroup;
        private Sunny.UI.UIComboBox ComboBoxApp;
        private Sunny.UI.UIButton BtnGroupStart;
        private Sunny.UI.UIButton BtnAppStart;
        private System.Windows.Forms.Timer DeviceStatusTimer;
        private System.Windows.Forms.ImageList PowerSwitchImage;
        public Sunny.UI.UIDataGridView DataGridViewDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewImageColumn SwitchButton;
        private System.Windows.Forms.DataGridViewImageColumn ConnectionStatus;
    }
}