namespace MCS_Client
{
    partial class ClientForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.MyNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MyGroupBox = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.HeartCheck = new System.Windows.Forms.Timer(this.components);
            this.MyContextMenuStrip.SuspendLayout();
            this.MyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyNotifyIcon
            // 
            this.MyNotifyIcon.ContextMenuStrip = this.MyContextMenuStrip;
            this.MyNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MyNotifyIcon.Icon")));
            this.MyNotifyIcon.Text = "服务器客户端";
            this.MyNotifyIcon.Visible = true;
            this.MyNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MyNotifyIcon_MouseDoubleClick);
            // 
            // MyContextMenuStrip
            // 
            this.MyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.退出ToolStripMenuItem});
            this.MyContextMenuStrip.Name = "MyContextMenuStrip";
            this.MyContextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem2.Text = " ";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // MyGroupBox
            // 
            this.MyGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyGroupBox.Controls.Add(this.button3);
            this.MyGroupBox.Controls.Add(this.txtMessage);
            this.MyGroupBox.Controls.Add(this.lblMessage);
            this.MyGroupBox.Controls.Add(this.button2);
            this.MyGroupBox.Controls.Add(this.button1);
            this.MyGroupBox.Controls.Add(this.lblNote);
            this.MyGroupBox.Location = new System.Drawing.Point(12, 3);
            this.MyGroupBox.Name = "MyGroupBox";
            this.MyGroupBox.Size = new System.Drawing.Size(1004, 441);
            this.MyGroupBox.TabIndex = 1;
            this.MyGroupBox.TabStop = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(838, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 43);
            this.button3.TabIndex = 5;
            this.button3.Text = "清空";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(93, 77);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage.Size = new System.Drawing.Size(739, 332);
            this.txtMessage.TabIndex = 4;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMessage.Location = new System.Drawing.Point(13, 77);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(90, 21);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "运行日志：";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(838, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "测试考试结束";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(838, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "测试考试开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNote
            // 
            this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNote.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Location = new System.Drawing.Point(399, 26);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(123, 35);
            this.lblNote.TabIndex = 0;
            this.lblNote.Text = "请勿关闭";
            // 
            // HeartCheck
            // 
            this.HeartCheck.Enabled = true;
            this.HeartCheck.Interval = 3000;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 454);
            this.Controls.Add(this.MyGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器客户端C#Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ClientForm_SizeChanged);
            this.MyContextMenuStrip.ResumeLayout(false);
            this.MyGroupBox.ResumeLayout(false);
            this.MyGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon MyNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip MyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.GroupBox MyGroupBox;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Timer HeartCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button button3;
    }
}

