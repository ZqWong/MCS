namespace MCS
{
    partial class PageControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageControl));
            this.btnToPageIndex = new System.Windows.Forms.Button();
            this.lbEnd = new System.Windows.Forms.Label();
            this.cbPageSize = new System.Windows.Forms.ComboBox();
            this.txtToPageIndex = new System.Windows.Forms.TextBox();
            this.lbPre = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblPager = new System.Windows.Forms.Label();
            this.imglstPager = new System.Windows.Forms.ImageList(this.components);
            this.lblPager2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnToPageIndex
            // 
            this.btnToPageIndex.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnToPageIndex.Location = new System.Drawing.Point(848, 7);
            this.btnToPageIndex.Name = "btnToPageIndex";
            this.btnToPageIndex.Size = new System.Drawing.Size(50, 30);
            this.btnToPageIndex.TabIndex = 26;
            this.btnToPageIndex.Text = "跳转";
            this.btnToPageIndex.UseVisualStyleBackColor = true;
            this.btnToPageIndex.Click += new System.EventHandler(this.btnToPageIndex_Click);
            // 
            // lbEnd
            // 
            this.lbEnd.AutoSize = true;
            this.lbEnd.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbEnd.Location = new System.Drawing.Point(816, 12);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(23, 20);
            this.lbEnd.TabIndex = 25;
            this.lbEnd.Text = "页";
            // 
            // cbPageSize
            // 
            this.cbPageSize.DisplayMember = "10";
            this.cbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPageSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPageSize.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPageSize.FormattingEnabled = true;
            this.cbPageSize.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20"});
            this.cbPageSize.Location = new System.Drawing.Point(320, 9);
            this.cbPageSize.Name = "cbPageSize";
            this.cbPageSize.Size = new System.Drawing.Size(50, 27);
            this.cbPageSize.TabIndex = 28;
            this.cbPageSize.TextChanged += new System.EventHandler(this.cbPageSize_TextChanged);
            // 
            // txtToPageIndex
            // 
            this.txtToPageIndex.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtToPageIndex.Location = new System.Drawing.Point(752, 9);
            this.txtToPageIndex.Name = "txtToPageIndex";
            this.txtToPageIndex.Size = new System.Drawing.Size(58, 25);
            this.txtToPageIndex.TabIndex = 24;
            this.txtToPageIndex.Text = "1";
            this.txtToPageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtToPageIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToPageIndex_KeyPress);
            // 
            // lbPre
            // 
            this.lbPre.AutoSize = true;
            this.lbPre.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPre.Location = new System.Drawing.Point(720, 12);
            this.lbPre.Name = "lbPre";
            this.lbPre.Size = new System.Drawing.Size(23, 20);
            this.lbPre.TabIndex = 23;
            this.lbPre.Text = "第";
            // 
            // btnLast
            // 
            this.btnLast.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLast.Location = new System.Drawing.Point(664, 7);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(50, 30);
            this.btnLast.TabIndex = 22;
            this.btnLast.Text = "末页";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(578, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 30);
            this.btnNext.TabIndex = 21;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrevious.Location = new System.Drawing.Point(492, 7);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(80, 30);
            this.btnPrevious.TabIndex = 20;
            this.btnPrevious.Text = "上一页";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFirst.Location = new System.Drawing.Point(436, 8);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(50, 30);
            this.btnFirst.TabIndex = 19;
            this.btnFirst.Text = "首页";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // lblPager
            // 
            this.lblPager.AutoSize = true;
            this.lblPager.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPager.Location = new System.Drawing.Point(27, 13);
            this.lblPager.Name = "lblPager";
            this.lblPager.Size = new System.Drawing.Size(287, 20);
            this.lblPager.TabIndex = 18;
            this.lblPager.Text = "总共{0}条记录，当前第{0}页，共{0}页，每页";
            // 
            // imglstPager
            // 
            this.imglstPager.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstPager.ImageStream")));
            this.imglstPager.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstPager.Images.SetKeyName(0, "first.gif");
            this.imglstPager.Images.SetKeyName(1, "prev.gif");
            this.imglstPager.Images.SetKeyName(2, "next.gif");
            this.imglstPager.Images.SetKeyName(3, "last.gif");
            // 
            // lblPager2
            // 
            this.lblPager2.AutoSize = true;
            this.lblPager2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPager2.Location = new System.Drawing.Point(376, 14);
            this.lblPager2.Name = "lblPager2";
            this.lblPager2.Size = new System.Drawing.Size(51, 20);
            this.lblPager2.TabIndex = 27;
            this.lblPager2.Text = "条记录";
            // 
            // PageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPageSize);
            this.Controls.Add(this.lblPager2);
            this.Controls.Add(this.btnToPageIndex);
            this.Controls.Add(this.lbEnd);
            this.Controls.Add(this.txtToPageIndex);
            this.Controls.Add(this.lbPre);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.lblPager);
            this.Name = "PageControl";
            this.Size = new System.Drawing.Size(966, 45);
            this.Load += new System.EventHandler(this.PageControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToPageIndex;
        private System.Windows.Forms.Label lbEnd;
        private System.Windows.Forms.TextBox txtToPageIndex;
        private System.Windows.Forms.Label lbPre;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lblPager;
        private System.Windows.Forms.ImageList imglstPager;
        private System.Windows.Forms.Label lblPager2;
        private System.Windows.Forms.ComboBox cbPageSize;
    }
}
