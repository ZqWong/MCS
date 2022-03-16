namespace OCC.Forms
{
    partial class OCC_APPDeviceBind
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
            this.TextBoxRemark = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.TextBoxAppName = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.DataGridViewDeviceBinded = new Sunny.UI.UIDataGridView();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBtm.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDeviceBinded)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 386);
            this.pnlBtm.Size = new System.Drawing.Size(694, 55);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(566, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(451, 12);
            // 
            // TextBoxRemark
            // 
            this.TextBoxRemark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxRemark.ButtonSymbol = 61761;
            this.TextBoxRemark.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxRemark.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxRemark.EnterAsTab = true;
            this.TextBoxRemark.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxRemark.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxRemark.Location = new System.Drawing.Point(98, 89);
            this.TextBoxRemark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxRemark.Maximum = 2147483647D;
            this.TextBoxRemark.Minimum = -2147483648D;
            this.TextBoxRemark.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxRemark.Name = "TextBoxRemark";
            this.TextBoxRemark.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxRemark.Size = new System.Drawing.Size(581, 29);
            this.TextBoxRemark.TabIndex = 15;
            this.TextBoxRemark.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(17, 91);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(74, 21);
            this.uiLabel2.TabIndex = 16;
            this.uiLabel2.Text = "系统描述";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxAppName
            // 
            this.TextBoxAppName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxAppName.ButtonSymbol = 61761;
            this.TextBoxAppName.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxAppName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxAppName.EnterAsTab = true;
            this.TextBoxAppName.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxAppName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxAppName.Location = new System.Drawing.Point(98, 50);
            this.TextBoxAppName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxAppName.Maximum = 2147483647D;
            this.TextBoxAppName.Minimum = -2147483648D;
            this.TextBoxAppName.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxAppName.Name = "TextBoxAppName";
            this.TextBoxAppName.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxAppName.Size = new System.Drawing.Size(581, 29);
            this.TextBoxAppName.TabIndex = 13;
            this.TextBoxAppName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(17, 52);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(58, 21);
            this.uiLabel1.TabIndex = 14;
            this.uiLabel1.Text = "系统名";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.DataGridViewDeviceBinded);
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(21, 128);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(658, 248);
            this.uiGroupBox1.TabIndex = 17;
            this.uiGroupBox1.Text = "设备绑定";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.DeviceName,
            this.Path});
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
            this.DataGridViewDeviceBinded.Location = new System.Drawing.Point(0, 32);
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
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.DataGridViewDeviceBinded.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewDeviceBinded.RowTemplate.Height = 23;
            this.DataGridViewDeviceBinded.SelectedIndex = -1;
            this.DataGridViewDeviceBinded.ShowGridLine = true;
            this.DataGridViewDeviceBinded.Size = new System.Drawing.Size(658, 216);
            this.DataGridViewDeviceBinded.TabIndex = 0;
            // 
            // DeviceName
            // 
            this.DeviceName.HeaderText = "设备名";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            // 
            // Path
            // 
            this.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Path.HeaderText = "安装路径";
            this.Path.Name = "Path";
            // 
            // OCC_APPDeviceBind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 444);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.TextBoxRemark);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.TextBoxAppName);
            this.Controls.Add(this.uiLabel1);
            this.Name = "OCC_APPDeviceBind";
            this.Text = "OCC_APPDeviceBind";
            this.Load += new System.EventHandler(this.OCC_APPDeviceBind_Load);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.TextBoxAppName, 0);
            this.Controls.SetChildIndex(this.uiLabel2, 0);
            this.Controls.SetChildIndex(this.TextBoxRemark, 0);
            this.Controls.SetChildIndex(this.uiGroupBox1, 0);
            this.pnlBtm.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDeviceBinded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UITextBox TextBoxRemark;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox TextBoxAppName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIDataGridView DataGridViewDeviceBinded;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
    }
}