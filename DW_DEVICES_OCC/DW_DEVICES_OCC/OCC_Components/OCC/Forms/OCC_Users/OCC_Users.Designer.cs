namespace OCC.Forms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.UserRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AujustUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.UserList = new Sunny.UI.UIDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonEditUser = new Sunny.UI.UIButton();
            this.ButtonDeleteUser = new Sunny.UI.UIButton();
            this.ButtonAddUser = new Sunny.UI.UIButton();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AuthLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserRightClick.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserRightClick
            // 
            this.UserRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteUserInfoToolStripMenuItem,
            this.AujustUserInfoToolStripMenuItem});
            this.UserRightClick.Name = "UserRightClick";
            this.UserRightClick.Size = new System.Drawing.Size(125, 48);
            // 
            // DeleteUserInfoToolStripMenuItem
            // 
            this.DeleteUserInfoToolStripMenuItem.Name = "DeleteUserInfoToolStripMenuItem";
            this.DeleteUserInfoToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.DeleteUserInfoToolStripMenuItem.Text = "删除用户";
            // 
            // AujustUserInfoToolStripMenuItem
            // 
            this.AujustUserInfoToolStripMenuItem.Name = "AujustUserInfoToolStripMenuItem";
            this.AujustUserInfoToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.AujustUserInfoToolStripMenuItem.Text = "编辑用户";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.uiGroupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(749, 508);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.UserList);
            this.uiGroupBox1.Controls.Add(this.panel1);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 5);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(741, 498);
            this.uiGroupBox1.TabIndex = 6;
            this.uiGroupBox1.Text = "用户管理";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserList
            // 
            this.UserList.AllowUserToAddRows = false;
            this.UserList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.UserList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.UserList.BackgroundColor = System.Drawing.Color.White;
            this.UserList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.UserList.ColumnHeadersHeight = 32;
            this.UserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.UserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.AuthLevel,
            this.Username,
            this.Sex,
            this.Company,
            this.IdentityId,
            this.Remark});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UserList.DefaultCellStyle = dataGridViewCellStyle3;
            this.UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserList.EnableHeadersVisualStyles = false;
            this.UserList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.UserList.Location = new System.Drawing.Point(0, 77);
            this.UserList.Name = "UserList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.UserList.RowHeadersVisible = false;
            this.UserList.RowHeight = 40;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.UserList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.UserList.RowTemplate.Height = 40;
            this.UserList.SelectedIndex = -1;
            this.UserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserList.ShowGridLine = true;
            this.UserList.Size = new System.Drawing.Size(741, 421);
            this.UserList.TabIndex = 8;
            this.UserList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserList_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.ButtonEditUser);
            this.panel1.Controls.Add(this.ButtonDeleteUser);
            this.panel1.Controls.Add(this.ButtonAddUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(741, 45);
            this.panel1.TabIndex = 7;
            // 
            // ButtonEditUser
            // 
            this.ButtonEditUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonEditUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditUser.Location = new System.Drawing.Point(221, 5);
            this.ButtonEditUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonEditUser.Name = "ButtonEditUser";
            this.ButtonEditUser.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonEditUser.Size = new System.Drawing.Size(100, 35);
            this.ButtonEditUser.TabIndex = 2;
            this.ButtonEditUser.Text = "编辑用户";
            this.ButtonEditUser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonEditUser.Click += new System.EventHandler(this.ButtonEditUser_Click);
            // 
            // ButtonDeleteUser
            // 
            this.ButtonDeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDeleteUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonDeleteUser.Location = new System.Drawing.Point(113, 5);
            this.ButtonDeleteUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonDeleteUser.Name = "ButtonDeleteUser";
            this.ButtonDeleteUser.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonDeleteUser.Size = new System.Drawing.Size(100, 35);
            this.ButtonDeleteUser.TabIndex = 1;
            this.ButtonDeleteUser.Text = "删除用户";
            this.ButtonDeleteUser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonDeleteUser.Click += new System.EventHandler(this.ButtonDeleteUser_Click);
            // 
            // ButtonAddUser
            // 
            this.ButtonAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddUser.Location = new System.Drawing.Point(5, 5);
            this.ButtonAddUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.ButtonAddUser.Name = "ButtonAddUser";
            this.ButtonAddUser.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonAddUser.Size = new System.Drawing.Size(100, 35);
            this.ButtonAddUser.TabIndex = 0;
            this.ButtonAddUser.Text = "创建用户";
            this.ButtonAddUser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonAddUser.Click += new System.EventHandler(this.ButtonAddUser_Click);
            // 
            // Selected
            // 
            this.Selected.HeaderText = "选择";
            this.Selected.Name = "Selected";
            this.Selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Selected.Width = 75;
            // 
            // AuthLevel
            // 
            this.AuthLevel.HeaderText = "权限类型";
            this.AuthLevel.Name = "AuthLevel";
            this.AuthLevel.ReadOnly = true;
            this.AuthLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AuthLevel.Width = 80;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Username.HeaderText = "用户名";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Width = 82;
            // 
            // Sex
            // 
            this.Sex.HeaderText = "性别";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            this.Sex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sex.Width = 60;
            // 
            // Company
            // 
            this.Company.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Company.HeaderText = "所属公司";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            this.Company.Width = 98;
            // 
            // IdentityId
            // 
            this.IdentityId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdentityId.HeaderText = "身份证号";
            this.IdentityId.Name = "IdentityId";
            this.IdentityId.ReadOnly = true;
            this.IdentityId.Width = 98;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.HeaderText = "描述";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // OCC_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OCC_Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCC_Users";
            this.Load += new System.EventHandler(this.OCC_Users_Load);
            this.UserRightClick.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip UserRightClick;
        private System.Windows.Forms.ToolStripMenuItem DeleteUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AujustUserInfoToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIDataGridView UserList;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UIButton ButtonEditUser;
        private Sunny.UI.UIButton ButtonDeleteUser;
        private Sunny.UI.UIButton ButtonAddUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}