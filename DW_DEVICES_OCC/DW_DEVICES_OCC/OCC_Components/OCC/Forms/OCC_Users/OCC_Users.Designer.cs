namespace OCC.Forms.OCC_Users
{
    partial class OCC_Users
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UsersGroupBox = new System.Windows.Forms.GroupBox();
            this.UserList = new System.Windows.Forms.DataGridView();
            this.UsersMenuStrip = new System.Windows.Forms.MenuStrip();
            this.AddUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AujustUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.UsersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserList)).BeginInit();
            this.UsersMenuStrip.SuspendLayout();
            this.UserRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UsersGroupBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 508);
            this.panel1.TabIndex = 0;
            // 
            // UsersGroupBox
            // 
            this.UsersGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.UsersGroupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UsersGroupBox.Controls.Add(this.UserList);
            this.UsersGroupBox.Controls.Add(this.UsersMenuStrip);
            this.UsersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsersGroupBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UsersGroupBox.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.UsersGroupBox.Location = new System.Drawing.Point(0, 0);
            this.UsersGroupBox.Name = "UsersGroupBox";
            this.UsersGroupBox.Size = new System.Drawing.Size(749, 508);
            this.UsersGroupBox.TabIndex = 1;
            this.UsersGroupBox.TabStop = false;
            this.UsersGroupBox.Text = "用户管理";
            // 
            // UserList
            // 
            this.UserList.AllowUserToAddRows = false;
            this.UserList.AllowUserToDeleteRows = false;
            this.UserList.AllowUserToResizeColumns = false;
            this.UserList.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.UserList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.UserList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.UserList.ColumnHeadersHeight = 30;
            this.UserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.UserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.Username,
            this.AuthLevel,
            this.Company,
            this.Sex,
            this.PhoneNumber,
            this.Email,
            this.UserStatus,
            this.Remark});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UserList.DefaultCellStyle = dataGridViewCellStyle22;
            this.UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserList.EnableHeadersVisualStyles = false;
            this.UserList.GridColor = System.Drawing.Color.DimGray;
            this.UserList.Location = new System.Drawing.Point(3, 44);
            this.UserList.Name = "UserList";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserList.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.UserList.RowHeadersVisible = false;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.White;
            this.UserList.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.UserList.RowTemplate.Height = 23;
            this.UserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserList.Size = new System.Drawing.Size(743, 461);
            this.UserList.TabIndex = 0;
            this.UserList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UserList_CellMouseUp);
            // 
            // UsersMenuStrip
            // 
            this.UsersMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.UsersMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddUserToolStripMenuItem,
            this.DeleteUserToolStripMenuItem});
            this.UsersMenuStrip.Location = new System.Drawing.Point(3, 19);
            this.UsersMenuStrip.Name = "UsersMenuStrip";
            this.UsersMenuStrip.Size = new System.Drawing.Size(743, 25);
            this.UsersMenuStrip.TabIndex = 1;
            this.UsersMenuStrip.Text = "menuStrip1";
            // 
            // AddUserToolStripMenuItem
            // 
            this.AddUserToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.AddUserToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AddUserToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem";
            this.AddUserToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.AddUserToolStripMenuItem.Text = "添加用户";
            this.AddUserToolStripMenuItem.Click += new System.EventHandler(this.AddUserToolStripMenuItem_Click);
            // 
            // DeleteUserToolStripMenuItem
            // 
            this.DeleteUserToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.DeleteUserToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeleteUserToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DeleteUserToolStripMenuItem.Name = "DeleteUserToolStripMenuItem";
            this.DeleteUserToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.DeleteUserToolStripMenuItem.Text = "批量删除";
            this.DeleteUserToolStripMenuItem.Click += new System.EventHandler(this.DeleteUserToolStripMenuItem_Click);
            // 
            // UserRightClick
            // 
            this.UserRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteUserInfoToolStripMenuItem,
            this.AujustUserInfoToolStripMenuItem});
            this.UserRightClick.Name = "UserRightClick";
            this.UserRightClick.Size = new System.Drawing.Size(181, 70);
            // 
            // DeleteUserInfoToolStripMenuItem
            // 
            this.DeleteUserInfoToolStripMenuItem.Name = "DeleteUserInfoToolStripMenuItem";
            this.DeleteUserInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteUserInfoToolStripMenuItem.Text = "删除用户";
            this.DeleteUserInfoToolStripMenuItem.Click += new System.EventHandler(this.DeleteUserInfoToolStripMenuItem_Click);
            // 
            // AujustUserInfoToolStripMenuItem
            // 
            this.AujustUserInfoToolStripMenuItem.Name = "AujustUserInfoToolStripMenuItem";
            this.AujustUserInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AujustUserInfoToolStripMenuItem.Text = "编辑用户";
            this.AujustUserInfoToolStripMenuItem.Click += new System.EventHandler(this.AujustUserInfoToolStripMenuItem_Click);
            // 
            // Selected
            // 
            this.Selected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            this.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Selected.ToolTipText = "选择编辑";
            this.Selected.Width = 40;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Username.DefaultCellStyle = dataGridViewCellStyle21;
            this.Username.HeaderText = "名称";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Username.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Username.ToolTipText = "用户的昵称";
            this.Username.Width = 37;
            // 
            // AuthLevel
            // 
            this.AuthLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AuthLevel.HeaderText = "用户类型";
            this.AuthLevel.Name = "AuthLevel";
            this.AuthLevel.ReadOnly = true;
            this.AuthLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AuthLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AuthLevel.Width = 61;
            // 
            // Company
            // 
            this.Company.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Company.HeaderText = "公司";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            this.Company.Width = 56;
            // 
            // Sex
            // 
            this.Sex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sex.HeaderText = "性别";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            this.Sex.Width = 56;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PhoneNumber.HeaderText = "联系方式";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.Width = 80;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Email.Width = 47;
            // 
            // UserStatus
            // 
            this.UserStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UserStatus.HeaderText = "账号状态";
            this.UserStatus.Name = "UserStatus";
            this.UserStatus.ReadOnly = true;
            this.UserStatus.Width = 80;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 56;
            // 
            // OCC_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 508);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.UsersMenuStrip;
            this.Name = "OCC_Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCC_Users";
            this.Load += new System.EventHandler(this.OCC_Users_Load);
            this.panel1.ResumeLayout(false);
            this.UsersGroupBox.ResumeLayout(false);
            this.UsersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserList)).EndInit();
            this.UsersMenuStrip.ResumeLayout(false);
            this.UsersMenuStrip.PerformLayout();
            this.UserRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView UserList;
        private System.Windows.Forms.GroupBox UsersGroupBox;
        private System.Windows.Forms.MenuStrip UsersMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteUserToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip UserRightClick;
        private System.Windows.Forms.ToolStripMenuItem DeleteUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AujustUserInfoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}