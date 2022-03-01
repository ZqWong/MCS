namespace MCS
{
    partial class 更新客户端
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
            this.dataGridView_process_edit = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit_FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_newClientPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog_ForSaveFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.button_update = new System.Windows.Forms.Button();
            this.checkBox_checkAll = new System.Windows.Forms.CheckBox();
            this.button_cancle = new System.Windows.Forms.Button();
            this.button_updateToDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_process_edit)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_process_edit
            // 
            this.dataGridView_process_edit.AllowUserToAddRows = false;
            this.dataGridView_process_edit.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_process_edit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_process_edit.ColumnHeadersHeight = 30;
            this.dataGridView_process_edit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_process_edit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.Edit_ID,
            this.Edit_IP,
            this.Edit_FilePath});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_process_edit.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_process_edit.Location = new System.Drawing.Point(12, 99);
            this.dataGridView_process_edit.Name = "dataGridView_process_edit";
            this.dataGridView_process_edit.RowHeadersWidth = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_process_edit.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_process_edit.RowTemplate.Height = 40;
            this.dataGridView_process_edit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_process_edit.Size = new System.Drawing.Size(865, 565);
            this.dataGridView_process_edit.TabIndex = 3;
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.MinimumWidth = 30;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CheckBox.Width = 30;
            // 
            // Edit_ID
            // 
            this.Edit_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Edit_ID.FillWeight = 20F;
            this.Edit_ID.HeaderText = "ID";
            this.Edit_ID.Name = "Edit_ID";
            this.Edit_ID.Visible = false;
            this.Edit_ID.Width = 49;
            // 
            // Edit_IP
            // 
            this.Edit_IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Edit_IP.HeaderText = "IP";
            this.Edit_IP.Name = "Edit_IP";
            this.Edit_IP.Width = 47;
            // 
            // Edit_FilePath
            // 
            this.Edit_FilePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Edit_FilePath.HeaderText = "执行路径";
            this.Edit_FilePath.Name = "Edit_FilePath";
            // 
            // textBox_newClientPath
            // 
            this.textBox_newClientPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_newClientPath.Location = new System.Drawing.Point(126, 33);
            this.textBox_newClientPath.Name = "textBox_newClientPath";
            this.textBox_newClientPath.Size = new System.Drawing.Size(595, 26);
            this.textBox_newClientPath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "新版客户端地址：";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(727, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.SystemColors.Control;
            this.button_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_update.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_update.ForeColor = System.Drawing.Color.Black;
            this.button_update.Location = new System.Drawing.Point(645, 681);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(101, 34);
            this.button_update.TabIndex = 11;
            this.button_update.Text = "更新";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_saveToDB_Click);
            // 
            // checkBox_checkAll
            // 
            this.checkBox_checkAll.AutoSize = true;
            this.checkBox_checkAll.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_checkAll.Location = new System.Drawing.Point(12, 69);
            this.checkBox_checkAll.Name = "checkBox_checkAll";
            this.checkBox_checkAll.Size = new System.Drawing.Size(56, 24);
            this.checkBox_checkAll.TabIndex = 12;
            this.checkBox_checkAll.Text = "全选";
            this.checkBox_checkAll.UseVisualStyleBackColor = true;
            this.checkBox_checkAll.CheckedChanged += new System.EventHandler(this.checkBox_checkAll_CheckedChanged);
            // 
            // button_cancle
            // 
            this.button_cancle.BackColor = System.Drawing.SystemColors.Control;
            this.button_cancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancle.ForeColor = System.Drawing.Color.Black;
            this.button_cancle.Location = new System.Drawing.Point(776, 681);
            this.button_cancle.Name = "button_cancle";
            this.button_cancle.Size = new System.Drawing.Size(101, 34);
            this.button_cancle.TabIndex = 13;
            this.button_cancle.Text = "取消";
            this.button_cancle.UseVisualStyleBackColor = false;
            this.button_cancle.Click += new System.EventHandler(this.button_cancle_Click);
            // 
            // button_updateToDB
            // 
            this.button_updateToDB.BackColor = System.Drawing.SystemColors.Control;
            this.button_updateToDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_updateToDB.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_updateToDB.ForeColor = System.Drawing.Color.Black;
            this.button_updateToDB.Location = new System.Drawing.Point(776, 33);
            this.button_updateToDB.Name = "button_updateToDB";
            this.button_updateToDB.Size = new System.Drawing.Size(101, 28);
            this.button_updateToDB.TabIndex = 14;
            this.button_updateToDB.Text = "保存";
            this.button_updateToDB.UseVisualStyleBackColor = false;
            this.button_updateToDB.Click += new System.EventHandler(this.button_updateToDB_Click);
            // 
            // 更新客户端
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 727);
            this.Controls.Add(this.button_updateToDB);
            this.Controls.Add(this.button_cancle);
            this.Controls.Add(this.checkBox_checkAll);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_newClientPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_process_edit);
            this.Name = "更新客户端";
            this.Text = "更新客户端";
            this.Load += new System.EventHandler(this.更新客户端_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_process_edit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_process_edit;
        private System.Windows.Forms.TextBox textBox_newClientPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_ForSaveFolder;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.CheckBox checkBox_checkAll;
        private System.Windows.Forms.Button button_cancle;
        private System.Windows.Forms.Button button_updateToDB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit_FilePath;
    }
}