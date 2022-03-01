namespace MCS
{
    partial class 分组管理
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
            this.checkedListBox_Group = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox_All = new System.Windows.Forms.CheckedListBox();
            this.button_right = new System.Windows.Forms.Button();
            this.button_left = new System.Windows.Forms.Button();
            this.comboBox_Group = new System.Windows.Forms.ComboBox();
            this.button_create = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBox_Group
            // 
            this.checkedListBox_Group.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkedListBox_Group.FormattingEnabled = true;
            this.checkedListBox_Group.Location = new System.Drawing.Point(39, 79);
            this.checkedListBox_Group.MultiColumn = true;
            this.checkedListBox_Group.Name = "checkedListBox_Group";
            this.checkedListBox_Group.Size = new System.Drawing.Size(238, 310);
            this.checkedListBox_Group.Sorted = true;
            this.checkedListBox_Group.TabIndex = 0;
            this.checkedListBox_Group.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_Group_ItemCheck);
            // 
            // checkedListBox_All
            // 
            this.checkedListBox_All.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkedListBox_All.FormattingEnabled = true;
            this.checkedListBox_All.Location = new System.Drawing.Point(372, 79);
            this.checkedListBox_All.Name = "checkedListBox_All";
            this.checkedListBox_All.Size = new System.Drawing.Size(238, 310);
            this.checkedListBox_All.Sorted = true;
            this.checkedListBox_All.TabIndex = 1;
            // 
            // button_right
            // 
            this.button_right.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_right.Location = new System.Drawing.Point(307, 122);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(39, 31);
            this.button_right.TabIndex = 2;
            this.button_right.Text = "→";
            this.button_right.UseVisualStyleBackColor = true;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            // 
            // button_left
            // 
            this.button_left.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_left.Location = new System.Drawing.Point(307, 283);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(39, 31);
            this.button_left.TabIndex = 3;
            this.button_left.Text = "←";
            this.button_left.UseVisualStyleBackColor = true;
            this.button_left.Click += new System.EventHandler(this.button_left_Click);
            // 
            // comboBox_Group
            // 
            this.comboBox_Group.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_Group.FormattingEnabled = true;
            this.comboBox_Group.Location = new System.Drawing.Point(88, 19);
            this.comboBox_Group.Name = "comboBox_Group";
            this.comboBox_Group.Size = new System.Drawing.Size(175, 28);
            this.comboBox_Group.TabIndex = 4;
            this.comboBox_Group.SelectedIndexChanged += new System.EventHandler(this.comboBox_Group_SelectedIndexChanged);
            // 
            // button_create
            // 
            this.button_create.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_create.Location = new System.Drawing.Point(303, 19);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(75, 31);
            this.button_create.TabIndex = 5;
            this.button_create.Text = "创建分组";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_delete
            // 
            this.button_delete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_delete.Location = new System.Drawing.Point(419, 19);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 31);
            this.button_delete.TabIndex = 6;
            this.button_delete.Text = "删除分组";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_refresh.Location = new System.Drawing.Point(535, 19);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 31);
            this.button_refresh.TabIndex = 7;
            this.button_refresh.Text = "刷新";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_save.Location = new System.Drawing.Point(419, 419);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 31);
            this.button_save.TabIndex = 8;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel.Location = new System.Drawing.Point(535, 419);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 31);
            this.button_cancel.TabIndex = 9;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(35, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "分组：";
            // 
            // 分组管理
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 471);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.comboBox_Group);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.checkedListBox_All);
            this.Controls.Add(this.checkedListBox_Group);
            this.Name = "分组管理";
            this.Text = "分组管理";
            this.Load += new System.EventHandler(this.分组管理_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_Group;
        private System.Windows.Forms.CheckedListBox checkedListBox_All;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.ComboBox comboBox_Group;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label1;
    }
}