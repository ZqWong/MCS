namespace MCS
{
    partial class 设备输入数据
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
            this.textBox_distance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_distance
            // 
            this.textBox_distance.Location = new System.Drawing.Point(670, 411);
            this.textBox_distance.Name = "textBox_distance";
            this.textBox_distance.Size = new System.Drawing.Size(100, 21);
            this.textBox_distance.TabIndex = 0;
            // 
            // 设备输入数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_distance);
            this.Name = "设备输入数据";
            this.Text = "设备输入数据";
            this.Load += new System.EventHandler(this.设备输入数据_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_distance;
    }
}