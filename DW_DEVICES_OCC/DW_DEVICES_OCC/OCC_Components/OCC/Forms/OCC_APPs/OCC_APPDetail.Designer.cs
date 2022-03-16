namespace OCC.Forms
{
    partial class OCC_APPDetail
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
            this.TextBoxAppName = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.TextBoxRemark = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.TextBoxPath = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.DataGridViewDeviceBind = new Sunny.UI.UIDataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBtm.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDeviceBind)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 425);
            this.pnlBtm.Size = new System.Drawing.Size(465, 55);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(337, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(222, 12);
            // 
            // TextBoxAppName
            // 
            this.TextBoxAppName.ButtonSymbol = 61761;
            this.TextBoxAppName.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxAppName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxAppName.EnterAsTab = true;
            this.TextBoxAppName.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxAppName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxAppName.Location = new System.Drawing.Point(102, 50);
            this.TextBoxAppName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxAppName.Maximum = 2147483647D;
            this.TextBoxAppName.Minimum = -2147483648D;
            this.TextBoxAppName.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxAppName.Name = "TextBoxAppName";
            this.TextBoxAppName.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxAppName.Size = new System.Drawing.Size(340, 29);
            this.TextBoxAppName.TabIndex = 9;
            this.TextBoxAppName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(21, 52);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(58, 21);
            this.uiLabel1.TabIndex = 10;
            this.uiLabel1.Text = "系统名";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxRemark
            // 
            this.TextBoxRemark.ButtonSymbol = 61761;
            this.TextBoxRemark.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxRemark.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxRemark.EnterAsTab = true;
            this.TextBoxRemark.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxRemark.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxRemark.Location = new System.Drawing.Point(102, 89);
            this.TextBoxRemark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxRemark.Maximum = 2147483647D;
            this.TextBoxRemark.Minimum = -2147483648D;
            this.TextBoxRemark.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxRemark.Name = "TextBoxRemark";
            this.TextBoxRemark.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxRemark.Size = new System.Drawing.Size(340, 29);
            this.TextBoxRemark.TabIndex = 11;
            this.TextBoxRemark.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(21, 91);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(74, 21);
            this.uiLabel2.TabIndex = 12;
            this.uiLabel2.Text = "系统描述";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxPath
            // 
            this.TextBoxPath.ButtonSymbol = 61761;
            this.TextBoxPath.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxPath.EnterAsTab = true;
            this.TextBoxPath.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxPath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxPath.Location = new System.Drawing.Point(102, 128);
            this.TextBoxPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxPath.Maximum = 2147483647D;
            this.TextBoxPath.Minimum = -2147483648D;
            this.TextBoxPath.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxPath.Size = new System.Drawing.Size(340, 29);
            this.TextBoxPath.TabIndex = 14;
            this.TextBoxPath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(21, 130);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(74, 21);
            this.uiLabel3.TabIndex = 15;
            this.uiLabel3.Text = "默认路径";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.DataGridViewDeviceBind);
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(25, 167);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(413, 248);
            this.uiGroupBox1.TabIndex = 16;
            this.uiGroupBox1.Text = "绑定设备选择";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataGridViewDeviceBind
            // 
            this.DataGridViewDeviceBind.AllowUserToAddRows = false;
            this.DataGridViewDeviceBind.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.DataGridViewDeviceBind.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewDeviceBind.BackgroundColor = System.Drawing.Color.White;
            this.DataGridViewDeviceBind.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDeviceBind.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewDeviceBind.ColumnHeadersHeight = 32;
            this.DataGridViewDeviceBind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataGridViewDeviceBind.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.DeviceName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewDeviceBind.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewDeviceBind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewDeviceBind.EnableHeadersVisualStyles = false;
            this.DataGridViewDeviceBind.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DataGridViewDeviceBind.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.DataGridViewDeviceBind.Location = new System.Drawing.Point(0, 32);
            this.DataGridViewDeviceBind.Name = "DataGridViewDeviceBind";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDeviceBind.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridViewDeviceBind.RowHeadersVisible = false;
            this.DataGridViewDeviceBind.RowHeight = 30;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.DataGridViewDeviceBind.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewDeviceBind.RowTemplate.Height = 30;
            this.DataGridViewDeviceBind.SelectedIndex = -1;
            this.DataGridViewDeviceBind.ShowGridLine = true;
            this.DataGridViewDeviceBind.Size = new System.Drawing.Size(413, 216);
            this.DataGridViewDeviceBind.TabIndex = 0;
            // 
            // Selected
            // 
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            // 
            // DeviceName
            // 
            this.DeviceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DeviceName.HeaderText = "设备名";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            // 
            // OCC_APPDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 483);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.TextBoxPath);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.TextBoxRemark);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.TextBoxAppName);
            this.Controls.Add(this.uiLabel1);
            this.ExtendBox = true;
            this.ExtendSymbol = 61529;
            this.Name = "OCC_APPDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCC_APPDetail";
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.TextBoxAppName, 0);
            this.Controls.SetChildIndex(this.uiLabel2, 0);
            this.Controls.SetChildIndex(this.TextBoxRemark, 0);
            this.Controls.SetChildIndex(this.uiLabel3, 0);
            this.Controls.SetChildIndex(this.TextBoxPath, 0);
            this.Controls.SetChildIndex(this.uiGroupBox1, 0);
            this.pnlBtm.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDeviceBind)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UITextBox TextBoxAppName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TextBoxRemark;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox TextBoxPath;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIDataGridView DataGridViewDeviceBind;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
    }
}