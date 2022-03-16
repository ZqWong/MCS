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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCC_APPDetail));
            this.TextBoxAppName = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.TextBoxRemark = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.CheckBoxGroupDevice = new Sunny.UI.UICheckBoxGroup();
            this.TextBoxPath = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.pnlBtm.SuspendLayout();
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
            // CheckBoxGroupDevice
            // 
            this.CheckBoxGroupDevice.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CheckBoxGroupDevice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckBoxGroupDevice.Location = new System.Drawing.Point(25, 167);
            this.CheckBoxGroupDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckBoxGroupDevice.MinimumSize = new System.Drawing.Size(1, 1);
            this.CheckBoxGroupDevice.Name = "CheckBoxGroupDevice";
            this.CheckBoxGroupDevice.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.CheckBoxGroupDevice.SelectedIndexes = ((System.Collections.Generic.List<int>)(resources.GetObject("CheckBoxGroupDevice.SelectedIndexes")));
            this.CheckBoxGroupDevice.Size = new System.Drawing.Size(417, 248);
            this.CheckBoxGroupDevice.TabIndex = 13;
            this.CheckBoxGroupDevice.Text = "适配设备";
            this.CheckBoxGroupDevice.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            // OCC_APPDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 483);
            this.Controls.Add(this.TextBoxPath);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.CheckBoxGroupDevice);
            this.Controls.Add(this.TextBoxRemark);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.TextBoxAppName);
            this.Controls.Add(this.uiLabel1);
            this.ExtendBox = true;
            this.ExtendSymbol = 61529;
            this.Name = "OCC_APPDetail";
            this.Text = "OCC_APPDetail";
            this.Controls.SetChildIndex(this.pnlBtm, 0);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Controls.SetChildIndex(this.TextBoxAppName, 0);
            this.Controls.SetChildIndex(this.uiLabel2, 0);
            this.Controls.SetChildIndex(this.TextBoxRemark, 0);
            this.Controls.SetChildIndex(this.CheckBoxGroupDevice, 0);
            this.Controls.SetChildIndex(this.uiLabel3, 0);
            this.Controls.SetChildIndex(this.TextBoxPath, 0);
            this.pnlBtm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UITextBox TextBoxAppName;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox TextBoxRemark;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UICheckBoxGroup CheckBoxGroupDevice;
        private Sunny.UI.UITextBox TextBoxPath;
        private Sunny.UI.UILabel uiLabel3;
    }
}