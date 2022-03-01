using MCS.Common;
using System.Windows.Forms;

namespace MCS
{
    public partial class 版本信息 : Form
    {
        public 版本信息()
        {
            InitializeComponent();

            this.lblWarningMessage.Text = Const.WarningMessage;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
