using MCS.Common;
using System;
using System.Windows.Forms;

namespace MCS
{
    public partial class 参考图片查看界面 : Form
    {
        public 参考图片查看界面()
        {
            InitializeComponent();

            //this.pictureBox1.Load(Const.CanKaoImagePath + "CK_ContentOrStep.jpg");
        }

        public 参考图片查看界面(string logic)
        {
            InitializeComponent();

            this.pictureBox1.Load(Const.CanKaoImagePath + "CK_" + logic + ".jpg");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
