namespace MCS
{
    partial class 播放列表
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
            this.dataGridView_playlistName = new System.Windows.Forms.DataGridView();
            this.Column_plName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_plDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_appName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_playListName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_playlistName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView_playlistName);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 626);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView_playlistName
            // 
            this.dataGridView_playlistName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_playlistName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_plName,
            this.Column_plDelete});
            this.dataGridView_playlistName.Location = new System.Drawing.Point(16, 14);
            this.dataGridView_playlistName.MultiSelect = false;
            this.dataGridView_playlistName.Name = "dataGridView_playlistName";
            this.dataGridView_playlistName.RowTemplate.Height = 23;
            this.dataGridView_playlistName.Size = new System.Drawing.Size(458, 239);
            this.dataGridView_playlistName.TabIndex = 8;
            this.dataGridView_playlistName.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_playlistName_CellClick);
            // 
            // Column_plName
            // 
            this.Column_plName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_plName.DataPropertyName = "PlayListName";
            this.Column_plName.HeaderText = "播放列表名称";
            this.Column_plName.Name = "Column_plName";
            // 
            // Column_plDelete
            // 
            this.Column_plDelete.HeaderText = "删除";
            this.Column_plDelete.Name = "Column_plDelete";
            this.Column_plDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_plDelete.Text = "删除";
            this.Column_plDelete.UseColumnTextForButtonValue = true;
            this.Column_plDelete.Width = 40;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(252, 579);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(106, 579);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 6;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_index,
            this.Column_appName,
            this.Column_time,
            this.Column_delete,
            this.Column_ID,
            this.Column_playListName});
            this.dataGridView1.Location = new System.Drawing.Point(16, 301);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(458, 238);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column_index
            // 
            this.Column_index.DataPropertyName = "No";
            this.Column_index.HeaderText = "序号";
            this.Column_index.Name = "Column_index";
            // 
            // Column_appName
            // 
            this.Column_appName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_appName.DataPropertyName = "VideoName ";
            this.Column_appName.HeaderText = "应用名称";
            this.Column_appName.Name = "Column_appName";
            // 
            // Column_time
            // 
            this.Column_time.DataPropertyName = "Time";
            this.Column_time.HeaderText = "播放时间";
            this.Column_time.Name = "Column_time";
            // 
            // Column_delete
            // 
            this.Column_delete.HeaderText = "删除";
            this.Column_delete.Name = "Column_delete";
            this.Column_delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_delete.Text = "删除";
            this.Column_delete.UseColumnTextForButtonValue = true;
            this.Column_delete.Width = 40;
            // 
            // Column_ID
            // 
            this.Column_ID.DataPropertyName = "ID";
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.Visible = false;
            // 
            // Column_playListName
            // 
            this.Column_playListName.DataPropertyName = "PlayListName";
            this.Column_playListName.HeaderText = "播放列表名称";
            this.Column_playListName.Name = "Column_playListName";
            this.Column_playListName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "注：点击下方空行添加";
            // 
            // 播放列表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 646);
            this.Controls.Add(this.panel1);
            this.Name = "播放列表";
            this.Text = "播放列表";
            this.Load += new System.EventHandler(this.播放列表_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_playlistName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_index;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_appName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_time;
        private System.Windows.Forms.DataGridViewButtonColumn Column_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_playListName;
        private System.Windows.Forms.DataGridView dataGridView_playlistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_plName;
        private System.Windows.Forms.DataGridViewButtonColumn Column_plDelete;
        private System.Windows.Forms.Label label1;
    }
}