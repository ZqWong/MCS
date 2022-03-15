using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCC.Forms
{
    public partial class MessageDialog : Form
    {
        public MessageDialog()
        {
            InitializeComponent();
        }

        public string Message { get; set; }

        public Action<object, EventArgs> ConfirmAction;

        public Action<object, EventArgs> CancelAction;


        private void MessageDialog_Load(object sender, EventArgs e)
        {
            LabelContent.Text = Message;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmAction?.Invoke(sender, e);
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelAction?.Invoke(sender, e);
            this.Close();
        }
    }
}
