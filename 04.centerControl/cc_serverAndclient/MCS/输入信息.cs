using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS
{
    public partial class 输入信息 : Form
    {
        public 输入信息()
        {
            InitializeComponent();
        }

        private void 输入信息_Load(object sender, EventArgs e)
        {

        }

        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public bool AllowEmpty
        {
            get;
            set;
        }

        public string Result
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public int SelectionStart
        {
            get { return textBox1.SelectionStart; }
            set { textBox1.SelectionStart = value; }
        }

        public int SelectionLength
        {
            get { return textBox1.SelectionLength; }
            set { textBox1.SelectionLength = value; }
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!AllowEmpty && textBox1.Text == "")
                return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
