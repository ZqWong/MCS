namespace MCS
{
    partial class 配置文件
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
            this.dataGridView_client = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rotate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Roll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_client)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_client
            // 
            this.dataGridView_client.AllowUserToAddRows = false;
            this.dataGridView_client.AllowUserToDeleteRows = false;
            this.dataGridView_client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_client.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Client_Name,
            this.Pitch,
            this.Rotate,
            this.Roll});
            this.dataGridView_client.Location = new System.Drawing.Point(6, 116);
            this.dataGridView_client.Name = "dataGridView_client";
            this.dataGridView_client.RowTemplate.Height = 23;
            this.dataGridView_client.Size = new System.Drawing.Size(1067, 621);
            this.dataGridView_client.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Client_Name
            // 
            this.Client_Name.HeaderText = "名称";
            this.Client_Name.Name = "Client_Name";
            // 
            // Pitch
            // 
            this.Pitch.HeaderText = "pitch";
            this.Pitch.Name = "Pitch";
            // 
            // Rotate
            // 
            this.Rotate.HeaderText = "Rotate";
            this.Rotate.Name = "Rotate";
            // 
            // Roll
            // 
            this.Roll.HeaderText = "Roll";
            this.Roll.Name = "Roll";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(832, 49);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // 配置文件
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 765);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.dataGridView_client);
            this.Name = "配置文件";
            this.Text = "xml";
            this.Load += new System.EventHandler(this.xml_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_client)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_client;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pitch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rotate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Roll;
        private System.Windows.Forms.Button button_save;
    }
}