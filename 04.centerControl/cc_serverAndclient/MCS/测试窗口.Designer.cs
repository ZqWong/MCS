namespace MCS
{
    partial class 测试窗口
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtTestExamID = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnTest);
            this.panel4.Controls.Add(this.txtTestExamID);
            this.panel4.Controls.Add(this.label26);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(304, 164);
            this.panel4.TabIndex = 31;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(96, 71);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(154, 69);
            this.btnTest.TabIndex = 27;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtTestExamID
            // 
            this.txtTestExamID.Location = new System.Drawing.Point(98, 20);
            this.txtTestExamID.Name = "txtTestExamID";
            this.txtTestExamID.Size = new System.Drawing.Size(100, 21);
            this.txtTestExamID.TabIndex = 29;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(36, 23);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 28;
            this.label26.Text = "考试编号";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(528, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "关  闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // 测试窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(640, 462);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel4);
            this.Name = "测试窗口";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "测试窗口";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtTestExamID;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnClose;
    }
}