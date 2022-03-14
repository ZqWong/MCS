namespace OCC.Forms.OCC_Devices
{
    partial class OCC_DeviceDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TextBoxSerial = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.TextBoxIP = new Sunny.UI.UITextBox();
            this.Label = new Sunny.UI.UILabel();
            this.TextBoxMAC = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.ComboBoxDeviceType = new Sunny.UI.UIComboBox();
            this.TextBoxDeviceName = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.TextBoxRemark = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.pnlBtm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 340);
            this.pnlBtm.Size = new System.Drawing.Size(481, 55);
            this.pnlBtm.Style = Sunny.UI.UIStyle.Custom;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(353, 12);
            this.btnCancel.Style = Sunny.UI.UIStyle.Custom;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(238, 12);
            this.btnOK.Style = Sunny.UI.UIStyle.Custom;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 360);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.TextBoxRemark);
            this.panel4.Controls.Add(this.uiLabel4);
            this.panel4.Controls.Add(this.TextBoxSerial);
            this.panel4.Controls.Add(this.uiLabel5);
            this.panel4.Controls.Add(this.TextBoxIP);
            this.panel4.Controls.Add(this.Label);
            this.panel4.Controls.Add(this.TextBoxMAC);
            this.panel4.Controls.Add(this.uiLabel3);
            this.panel4.Controls.Add(this.ComboBoxDeviceType);
            this.panel4.Controls.Add(this.TextBoxDeviceName);
            this.panel4.Controls.Add(this.uiLabel1);
            this.panel4.Controls.Add(this.uiLabel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(481, 360);
            this.panel4.TabIndex = 1;
            // 
            // TextBoxSerial
            // 
            this.TextBoxSerial.ButtonSymbol = 61761;
            this.TextBoxSerial.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxSerial.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxSerial.EnterAsTab = true;
            this.TextBoxSerial.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxSerial.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxSerial.Location = new System.Drawing.Point(115, 161);
            this.TextBoxSerial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxSerial.Maximum = 2147483647D;
            this.TextBoxSerial.Minimum = -2147483648D;
            this.TextBoxSerial.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxSerial.Name = "TextBoxSerial";
            this.TextBoxSerial.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxSerial.Size = new System.Drawing.Size(340, 29);
            this.TextBoxSerial.Style = Sunny.UI.UIStyle.Custom;
            this.TextBoxSerial.TabIndex = 4;
            this.TextBoxSerial.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.AutoSize = true;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(21, 165);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(42, 21);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 10;
            this.uiLabel5.Text = "串口";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxIP
            // 
            this.TextBoxIP.ButtonSymbol = 61761;
            this.TextBoxIP.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxIP.EnterAsTab = true;
            this.TextBoxIP.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxIP.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxIP.Location = new System.Drawing.Point(115, 83);
            this.TextBoxIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxIP.Maximum = 2147483647D;
            this.TextBoxIP.Minimum = -2147483648D;
            this.TextBoxIP.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxIP.Size = new System.Drawing.Size(340, 29);
            this.TextBoxIP.Style = Sunny.UI.UIStyle.Custom;
            this.TextBoxIP.TabIndex = 2;
            this.TextBoxIP.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextBoxIP.Leave += new System.EventHandler(this.TextBoxIP_Leave);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Label.Location = new System.Drawing.Point(21, 88);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(57, 21);
            this.Label.Style = Sunny.UI.UIStyle.Custom;
            this.Label.TabIndex = 10;
            this.Label.Text = "IP地址";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxMAC
            // 
            this.TextBoxMAC.ButtonSymbol = 61761;
            this.TextBoxMAC.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxMAC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxMAC.EnterAsTab = true;
            this.TextBoxMAC.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxMAC.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxMAC.Location = new System.Drawing.Point(115, 121);
            this.TextBoxMAC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxMAC.Maximum = 2147483647D;
            this.TextBoxMAC.Minimum = -2147483648D;
            this.TextBoxMAC.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxMAC.Name = "TextBoxMAC";
            this.TextBoxMAC.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxMAC.ReadOnly = true;
            this.TextBoxMAC.Size = new System.Drawing.Size(340, 29);
            this.TextBoxMAC.Style = Sunny.UI.UIStyle.Custom;
            this.TextBoxMAC.TabIndex = 3;
            this.TextBoxMAC.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextBoxMAC.Watermark = "输入IP后自动填充（也可自行填充）";
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(21, 126);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(80, 21);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 10;
            this.uiLabel3.Text = "MAC地址";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBoxDeviceType
            // 
            this.ComboBoxDeviceType.DataSource = null;
            this.ComboBoxDeviceType.FillColor = System.Drawing.Color.White;
            this.ComboBoxDeviceType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxDeviceType.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ComboBoxDeviceType.Location = new System.Drawing.Point(115, 9);
            this.ComboBoxDeviceType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ComboBoxDeviceType.MinimumSize = new System.Drawing.Size(63, 0);
            this.ComboBoxDeviceType.Name = "ComboBoxDeviceType";
            this.ComboBoxDeviceType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.ComboBoxDeviceType.Size = new System.Drawing.Size(340, 29);
            this.ComboBoxDeviceType.Style = Sunny.UI.UIStyle.Custom;
            this.ComboBoxDeviceType.TabIndex = 0;
            this.ComboBoxDeviceType.Text = "uiComboBox1";
            this.ComboBoxDeviceType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxDeviceName
            // 
            this.TextBoxDeviceName.ButtonSymbol = 61761;
            this.TextBoxDeviceName.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxDeviceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxDeviceName.EnterAsTab = true;
            this.TextBoxDeviceName.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxDeviceName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxDeviceName.Location = new System.Drawing.Point(115, 44);
            this.TextBoxDeviceName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxDeviceName.Maximum = 2147483647D;
            this.TextBoxDeviceName.Minimum = -2147483648D;
            this.TextBoxDeviceName.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxDeviceName.Name = "TextBoxDeviceName";
            this.TextBoxDeviceName.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxDeviceName.Size = new System.Drawing.Size(340, 29);
            this.TextBoxDeviceName.Style = Sunny.UI.UIStyle.Custom;
            this.TextBoxDeviceName.TabIndex = 1;
            this.TextBoxDeviceName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(21, 48);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(74, 21);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 8;
            this.uiLabel1.Text = "设备名称";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(21, 9);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(74, 21);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 6;
            this.uiLabel2.Text = "设备类型";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxRemark
            // 
            this.TextBoxRemark.ButtonSymbol = 61761;
            this.TextBoxRemark.ButtonSymbolOffset = new System.Drawing.Point(0, 1);
            this.TextBoxRemark.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxRemark.EnterAsTab = true;
            this.TextBoxRemark.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxRemark.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.TextBoxRemark.Location = new System.Drawing.Point(115, 200);
            this.TextBoxRemark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxRemark.Maximum = 2147483647D;
            this.TextBoxRemark.Minimum = -2147483648D;
            this.TextBoxRemark.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxRemark.Name = "TextBoxRemark";
            this.TextBoxRemark.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxRemark.Size = new System.Drawing.Size(340, 29);
            this.TextBoxRemark.Style = Sunny.UI.UIStyle.Custom;
            this.TextBoxRemark.TabIndex = 11;
            this.TextBoxRemark.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(21, 204);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(42, 21);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 12;
            this.uiLabel4.Text = "备注";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OCC_DeviceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(483, 398);
            this.Controls.Add(this.panel1);
            this.Name = "OCC_DeviceDetail";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "OCC_UserDetail";
            this.Shown += new System.EventHandler(this.OCC_UserDetail_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.pnlBtm.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox ComboBoxDeviceType;
        private Sunny.UI.UITextBox TextBoxDeviceName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TextBoxSerial;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox TextBoxIP;
        private Sunny.UI.UILabel Label;
        private Sunny.UI.UITextBox TextBoxMAC;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox TextBoxRemark;
        private Sunny.UI.UILabel uiLabel4;
    }
}