namespace OCC
{
    partial class OCC
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
            this.MainFormContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MainFormContent
            // 
            this.MainFormContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainFormContent.AutoScroll = true;
            this.MainFormContent.Location = new System.Drawing.Point(3, 37);
            this.MainFormContent.Margin = new System.Windows.Forms.Padding(1, 2, 1, 1);
            this.MainFormContent.Name = "MainFormContent";
            this.MainFormContent.Size = new System.Drawing.Size(1274, 727);
            this.MainFormContent.TabIndex = 0;
            // 
            // OCC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.MainFormContent);
            this.ExtendBox = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "OCC";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.Text = "OCC";
            this.Load += new System.EventHandler(this.OCC_MAIN_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainFormContent;
    }
}