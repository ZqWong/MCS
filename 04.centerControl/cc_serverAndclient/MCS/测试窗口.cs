using MCS.DB.BLL;
using System;
using System.Windows.Forms;

namespace MCS
{
    public partial class 测试窗口 : Form
    {
        public 测试窗口()
        {
            InitializeComponent();
        }

        // 测试用
        private void btnTest_Click(object sender, EventArgs e)
        {
            ExaminationResultBLL examinationResultBLL = new ExaminationResultBLL();

            if (!String.IsNullOrEmpty(this.txtTestExamID.Text.Trim()))
            {
                string test = examinationResultBLL.GetExaminationSubjectIDs(this.txtTestExamID.Text.Trim());
                MessageBox.Show(test);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
