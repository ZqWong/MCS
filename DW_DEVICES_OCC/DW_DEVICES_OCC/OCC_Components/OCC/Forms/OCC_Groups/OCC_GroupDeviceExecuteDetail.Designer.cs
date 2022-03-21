namespace OCC.Forms
{
    partial class OCC_GroupDeviceExecuteDetail
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
            this.ComboBoxGroupDevice = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.ComboBoxExecute = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.TextBoxDelay = new Sunny.UI.UITextBox();
            this.TextBoxSort = new Sunny.UI.UITextBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.pnlBtm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBtm
            // 
            this.pnlBtm.Location = new System.Drawing.Point(1, 284);
            this.pnlBtm.Size = new System.Drawing.Size(475, 55);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(347, 12);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(232, 12);
            // 
            // ComboBoxGroupDevice
            // 
            this.ComboBoxGroupDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxGroupDevice.DataSource = null;
            this.ComboBoxGroupDevice.FillColor = System.Drawing.Color.White;
            this.ComboBoxGroupDevice.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ComboBoxGroupDevice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxGroupDevice.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ComboBoxGroupDevice.Location = new System.Drawing.Point(112, 49);
            this.ComboBoxGroupDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ComboBoxGroupDevice.MinimumSize = new System.Drawing.Size(63, 0);
            this.ComboBoxGroupDevice.Name = "ComboBoxGroupDevice";
            this.ComboBoxGroupDevice.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.ComboBoxGroupDevice.Size = new System.Drawing.Size(340, 29);
            this.ComboBoxGroupDevice.TabIndex = 17;
            this.ComboBoxGroupDevice.Text = "请选择操作设备";
            this.ComboBoxGroupDevice.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComboBoxGroupDevice.SelectedValueChanged += new System.EventHandler(this.ComboBoxGroupDevice_SelectedValueChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(18, 52);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(74, 21);
            this.uiLabel2.TabIndex = 18;
            this.uiLabel2.Text = "选择设备";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBoxExecute
            // 
            this.ComboBoxExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxExecute.DataSource = null;
            this.ComboBoxExecute.FillColor = System.Drawing.Color.White;
            this.ComboBoxExecute.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ComboBoxExecute.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ComboBoxExecute.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.ComboBoxExecute.Location = new System.Drawing.Point(112, 88);
            this.ComboBoxExecute.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ComboBoxExecute.MinimumSize = new System.Drawing.Size(63, 0);
            this.ComboBoxExecute.Name = "ComboBoxExecute";
            this.ComboBoxExecute.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.ComboBoxExecute.Size = new System.Drawing.Size(340, 29);
            this.ComboBoxExecute.TabIndex = 19;
            this.ComboBoxExecute.Text = "请选择操作";
            this.ComboBoxExecute.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(18, 91);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(74, 21);
            this.uiLabel1.TabIndex = 20;
            this.uiLabel1.Text = "选择操作";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(18, 130);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(42, 21);
            this.uiLabel3.TabIndex = 22;
            this.uiLabel3.Text = "延迟";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxDelay
            // 
            this.TextBoxDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxDelay.ButtonSymbol = 61761;
            this.TextBoxDelay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxDelay.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxDelay.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxDelay.Location = new System.Drawing.Point(112, 127);
            this.TextBoxDelay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxDelay.Maximum = 2147483647D;
            this.TextBoxDelay.Minimum = -2147483648D;
            this.TextBoxDelay.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxDelay.Name = "TextBoxDelay";
            this.TextBoxDelay.Size = new System.Drawing.Size(340, 29);
            this.TextBoxDelay.TabIndex = 23;
            this.TextBoxDelay.Text = " ";
            this.TextBoxDelay.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxSort
            // 
            this.TextBoxSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxSort.ButtonSymbol = 61761;
            this.TextBoxSort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxSort.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.TextBoxSort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxSort.Location = new System.Drawing.Point(112, 166);
            this.TextBoxSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxSort.Maximum = 2147483647D;
            this.TextBoxSort.Minimum = -2147483648D;
            this.TextBoxSort.MinimumSize = new System.Drawing.Size(1, 16);
            this.TextBoxSort.Name = "TextBoxSort";
            this.TextBoxSort.Size = new System.Drawing.Size(340, 29);
            this.TextBoxSort.TabIndex = 25;
            this.TextBoxSort.Text = " ";
            this.TextBoxSort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel4.AutoSize = true;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(18, 169);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(42, 21);
            this.uiLabel4.TabIndex = 24;
            this.uiLabel4.Text = "排序";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OCC_GroupDeviceExecuteDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 342);
            this.Controls.Add(this.TextBoxSort);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.TextBoxDelay);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.ComboBoxExecute);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.ComboBoxGroupDevice);
            this.Controls.Add(this.uiLabel2);
            this.Name = "OCC_GroupDeviceExecuteDetail";
            this.Text = "OCC_GroupDeviceExecuteDetail";
            this.Controls.SetChildIndex(this.uiLabel2, 0);
            this.Controls.SetChildIndex(this.ComboBoxGroupDevice, 0);
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.ComboBoxExecute, 0);
            this.Controls.SetChildIndex(this.uiLabel3, 0);
            this.Controls.SetChildIndex(this.TextBoxDelay, 0);
            this.Controls.SetChildIndex(this.uiLabel4, 0);
            this.Controls.SetChildIndex(this.TextBoxSort, 0);
            this.pnlBtm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIComboBox ComboBoxGroupDevice;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox ComboBoxExecute;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox TextBoxDelay;
        private Sunny.UI.UITextBox TextBoxSort;
        private Sunny.UI.UILabel uiLabel4;
    }
}