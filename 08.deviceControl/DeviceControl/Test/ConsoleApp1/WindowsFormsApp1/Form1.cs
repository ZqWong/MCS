using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DeviceControl;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DeviceControlClass dc = new DeviceControlClass();

        public Form1()
        {
            InitializeComponent();

            InitDevice();
        }

        public void InitDevice()
        {
            dc.OnReceiveNet += ReceiveNet;
            dc.OnReceiveNetOnErr += ReceiveNetOnErr;
            dc.OnReceiveNetOnServerDown += ReceiveNetOnServerDown;

            Control c1;
            foreach (Control c in groupBox1.Controls)
            {
                if (c.Name.Contains("ip"))
                {
                    DeviceStruct pj = new DeviceStruct();
                    pj.ip = c.Text; // ConfigHelper.GetSingleton().GetAppConfig("DBname");
                    pj.port = this.textBox_port.Text;
                    pj.serialPort = "COM1";
                    pj.buad = 9600;
                    pj.controlType = 0;
                    pj.deviceClassName = "Project";
                    pj.deviceName = c.Text;

                    dc.deviceDict.Add(pj.deviceName, pj);
                }
            }
        }

        private System.Windows.Forms.Control findControl(System.Windows.Forms.Control control, string controlName)
        {
            Control c1;
            foreach (Control c in control.Controls)
            {
                if (c.Name == controlName)
                {
                    return c;
                }
                else if (c.Controls.Count > 0)
                {
                    c1 = findControl(c, controlName);
                    if (c1 != null)
                    {
                        return c1;
                    }
                }
            }

            return null;
        }

        public static void ReceiveNet(object msg, string name)
        {
            string returnCode = msg.ToString();

            Console.WriteLine(string.Format("return from :{0}, code: {1}", name, returnCode));
        }

        public static void ReceiveNetOnErr(object msg, string name)
        {
            string returnCode = msg.ToString();
            Console.WriteLine(string.Format("err :{0}, code: {1}", name, returnCode));
        }

        public static void ReceiveNetOnServerDown(object msg, string name)
        {
            string returnCode = msg.ToString();
            Console.WriteLine(string.Format("server down :{0}, code: {1}", name, returnCode));
        }

        private void DeviceControl(object sender, EventArgs e)
        {
            string buttonString = ((Button) sender).Name;
            string[] buttonStringArray = buttonString.Split('_');
            if (buttonStringArray.Length > 0)
            {
                string textBoxIpStr = "textBox_ip_" + buttonStringArray[buttonStringArray.Length - 1];
                string TextBoxCodeStr = "textBox_code_" + buttonStringArray[buttonStringArray.Length - 1];

                if (textBoxIpStr != "" && TextBoxCodeStr != "")
                {
                    var textBoxIpTmp = findControl(this.groupBox1, textBoxIpStr);
                    var textBoxCodeTmp = findControl(this.groupBox1, TextBoxCodeStr);

                    dc.Control(dc.deviceDict[textBoxIpTmp.Text].deviceName , textBoxCodeTmp.Text);
                }
            }

            

            // textBox_ip_     textBox_code_

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_send_1_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_2_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_3_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_4_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_5_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_6_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_7_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_8_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_9_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_10_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_11_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_12_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_13_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_14_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_15_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_16_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_17_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_18_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_19_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_20_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_21_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_22_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_23_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void button_send_24_Click(object sender, EventArgs e)
        {
            DeviceControl(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox_port_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
