using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.Formula.Functions;

namespace MCS
{
    public partial class _4D座椅 : Form
    {
        

        byte[] msgBytes = new byte[44];
        byte[] shakeBytes = new byte[16];
        byte[] effectBytes = new byte[6];

        private static readonly object syslock = new object();
        private static _4D座椅 _instance;
        private static SynchronizationContext _uiContext;

        public static _4D座椅 GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new _4D座椅();
                    }
                }
            }

            return _instance;
        }

        public SynchronizationContext GetSyncContext()
        {
            return _uiContext;
        }

        public _4D座椅()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int temp;

            int.TryParse(trackBar_pose_x.Value.ToString(), out temp);

            textBox_pose_x.Text = ((float)temp / 100.0f).ToString();


        }

        private void textBox_pose_x_TextChanged(object sender, EventArgs e)
        {
            float temp;

            bool result = float.TryParse(textBox_pose_x.Text.ToString(), out temp);

            if (result)
            {
                if ((int) temp * 100 < trackBar_pose_x.Minimum )
                {
                    trackBar_pose_x.Value = trackBar_pose_x.Minimum;
                }
                else if ((int) temp * 100 > trackBar_pose_x.Maximum)
                {
                    trackBar_pose_x.Value = trackBar_pose_x.Maximum;
                }
                else
                {
                    trackBar_pose_x.Value = (int) temp * 100;
                }
            }
        }

        private void trackBar_y_Scroll(object sender, EventArgs e)
        {
            int temp;

            int.TryParse(trackBar_pose_y.Value.ToString(), out temp);

            textBox_pose_y.Text = ((float)temp / 100.0f).ToString();
        }

        private void textBox_y_TextChanged(object sender, EventArgs e)
        {
            float temp;

            bool result = float.TryParse(textBox_pose_y.Text.ToString(), out temp);

            if (result)
            {
                if ((int)temp * 100 < trackBar_pose_y.Minimum)
                {
                    trackBar_pose_y.Value = trackBar_pose_y.Minimum;
                }
                else if ((int)temp * 100 > trackBar_pose_y.Maximum)
                {
                    trackBar_pose_y.Value = trackBar_pose_y.Maximum;
                }
                else
                {
                    trackBar_pose_y.Value = (int)temp * 100;
                }
            }
        }

        private void trackBar_z_Scroll(object sender, EventArgs e)
        {
            int temp;

            int.TryParse(trackBar_pose_z.Value.ToString(), out temp);

            textBox_pose_z.Text = ((float)temp / 100.0f).ToString();
        }

        private void textBox_z_TextChanged(object sender, EventArgs e)
        {
            float temp;

            bool result = float.TryParse(textBox_pose_z.Text.ToString(), out temp);

            if (result)
            {
                if ((int)temp * 100 < trackBar_pose_z.Minimum)
                {
                    trackBar_pose_z.Value = trackBar_pose_z.Minimum;
                }
                else if ((int)temp * 100 > trackBar_pose_z.Maximum)
                {
                    trackBar_pose_z.Value = trackBar_pose_z.Maximum;
                }
                else
                {
                    trackBar_pose_z.Value = (int)temp * 100;
                }
            }
        }

        private void trackBar_roll_Scroll(object sender, EventArgs e)
        {
            int temp;

            int.TryParse(trackBar_pose_roll.Value.ToString(), out temp);

            textBox_pose_roll.Text = ((float)temp / 100.0f).ToString();
        }

        private void textBox_roll_TextChanged(object sender, EventArgs e)
        {
            float temp;

            bool result = float.TryParse(textBox_pose_roll.Text.ToString(), out temp);

            if (result)
            {
                if ((int)temp * 100 < trackBar_pose_roll.Minimum)
                {
                    trackBar_pose_roll.Value = trackBar_pose_roll.Minimum;
                }
                else if ((int)temp * 100 > trackBar_pose_roll.Maximum)
                {
                    trackBar_pose_roll.Value = trackBar_pose_roll.Maximum;
                }
                else
                {
                    trackBar_pose_roll.Value = (int)temp * 100;
                }
            }
        }

        private void trackBar_pitch_Scroll(object sender, EventArgs e)
        {
            int temp;

            int.TryParse(trackBar_pose_pitch.Value.ToString(), out temp);

            textBox_pose_pitch.Text = ((float)temp / 100.0f).ToString();
        }

        private void textBox_pitch_TextChanged(object sender, EventArgs e)
        {
            float temp;

            bool result = float.TryParse(textBox_pose_pitch.Text.ToString(), out temp);

            if (result)
            {
                if ((int)temp * 100 < trackBar_pose_pitch.Minimum)
                {
                    trackBar_pose_pitch.Value = trackBar_pose_pitch.Minimum;
                }
                else if ((int)temp * 100 > trackBar_pose_pitch.Maximum)
                {
                    trackBar_pose_pitch.Value = trackBar_pose_pitch.Maximum;
                }
                else
                {
                    trackBar_pose_pitch.Value = (int)temp * 100;
                }
            }
        }

        private void trackBar_yaw_Scroll(object sender, EventArgs e)
        {
            int temp;

            int.TryParse(trackBar_pose_yaw.Value.ToString(), out temp);

            textBox_pose_yaw.Text = ((float)temp / 100.0f).ToString();
        }

        private void textBox_yaw_TextChanged(object sender, EventArgs e)
        {
            float temp;

            bool result = float.TryParse(textBox_pose_yaw.Text.ToString(), out temp);

            if (result)
            {
                if ((int)temp * 100 < trackBar_pose_yaw.Minimum)
                {
                    trackBar_pose_yaw.Value = trackBar_pose_yaw.Minimum;
                }
                else if ((int)temp * 100 > trackBar_pose_yaw.Maximum)
                {
                    trackBar_pose_yaw.Value = trackBar_pose_yaw.Maximum;
                }
                else
                {
                    trackBar_pose_yaw.Value = (int)temp * 100;
                }
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {

            if (tabControl.SelectedTab.Name == "tabPage_pose")
            {
                msgBytes[0] = 0x41;
                msgBytes[1] = 0x54;
                msgBytes[2] = 0x54;
                msgBytes[3] = 0x49;

                for (int i = 4; i < msgBytes.Length; i++)
                {
                    msgBytes[i] = 0x00;
                }

                MakeUdpMsg(msgBytes, textBox_pose_x.Text.ToString(), 4);
                MakeUdpMsg(msgBytes, textBox_pose_y.Text.ToString(), 8);
                MakeUdpMsg(msgBytes, textBox_pose_z.Text.ToString(), 12);
                MakeUdpMsg(msgBytes, textBox_pose_roll.Text.ToString(), 16);
                MakeUdpMsg(msgBytes, textBox_pose_pitch.Text.ToString(), 20);
                MakeUdpMsg(msgBytes, textBox_pose_yaw.Text.ToString(), 24);

                SendMsg(msgBytes);
            }
            else if (tabControl.SelectedTab.Name == "tabPage_shake")
            {
                shakeBytes[0] = 0x45;
                shakeBytes[1] = 0x46;
                shakeBytes[2] = 0x46;
                shakeBytes[3] = 0x45;

                for (int i = 4; i < shakeBytes.Length; i++)
                {
                    shakeBytes[i] = 0x00;
                }

                MakeUdpMsg(shakeBytes, textBox_pose_frame.Text.ToString(), 4);
                MakeUdpMsg(shakeBytes, textBox_pose_range.Text.ToString(), 8);
                MakeUdpMsg(shakeBytes, textBox_pose_time.Text.ToString(), 12);

                SendMsg(shakeBytes);
            }
            else if (tabControl.SelectedTab.Name == "tabPage_effect")
            {
                effectBytes[0] = 0x45;
                effectBytes[1] = 0x46;
                effectBytes[2] = 0x46;
                effectBytes[3] = 0x4F;

                for (int i = 4; i < effectBytes.Length; i++)
                {
                    effectBytes[i] = 0x00;
                }


                foreach (CheckBox control in this.tabPage_effect.Controls)
                {
                    int bitNum = int.Parse(System.Text.RegularExpressions.Regex.Replace(control.Name, @"[^0-9]+", ""));

                    int bytesCount = 0;

                    if (bitNum / 8 > 0)
                    {
                        bytesCount = bitNum / 8;
                    }
                    
                    effectBytes[4 + bytesCount] = set_bit(effectBytes[4 + bytesCount], bitNum % 8 + 1 , control.Checked);

                }

                SendMsg(effectBytes);
            }
        }

        private void MakeUdpMsg(byte[] _msg, string value, int index)
        {
            byte[] tempbyte = hexadecimal(float.Parse(value)).Reverse().ToArray();
            Array.Reverse(tempbyte);

            _msg[index] = tempbyte[0];
            _msg[index + 1] = tempbyte[1];
            _msg[index + 2] = tempbyte[2];
            _msg[index + 3] = tempbyte[3];
        }

        /// <summary>
        /// 设置某一位的值
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index">要设置的位， 值从低到高为 1-8</param>
        /// <param name="flag">要设置的值 true / false</param>
        /// <returns></returns>
        byte set_bit(byte data, int index, bool flag)
        {
            if (index > 8 || index < 1)
                throw new ArgumentOutOfRangeException();
            int v = index < 2 ? index : (2 << (index - 2));
            return flag ? (byte)(data | v) : (byte)(data & ~v);
        }

        public static byte[] hexadecimal(float changeData)
        {
            float n = changeData;
            var b = BitConverter.GetBytes(n);
            //Debug.Log(b.Length);
            return b;
            //return BitConverter.ToString(b.Reverse().ToArray()).Replace("-", "");
        }


        //发送消息
        public void SendMsg(string _msg)
        {
            string ip = textBox_udpip.Text.ToString();
            string port = textBox_udpport.Text.ToString();

            IPEndPoint remotePoint = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));

            // IPEndPoint remotePoint = new IPEndPoint(ip, port);//实例化一个远程端点

            if (_msg != null)
            {
                byte[] sendData = Encoding.Default.GetBytes(_msg);
                UdpClient client = new UdpClient();
                client.Send(sendData, sendData.Length, remotePoint);//将数据发送到远程端点
                client.Close();//关闭连接
            }
        }

        //发送消息
        public void SendMsg(byte[] _msg)
        {
            string ip = textBox_udpip.Text.ToString();
            string port = textBox_udpport.Text.ToString();

            IPEndPoint remotePoint = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));

            if (_msg != null)
            {
                byte[] sendData = _msg;
                UdpClient client = new UdpClient();
                client.Send(sendData, sendData.Length, remotePoint);//将数据发送到远程端点
                client.Close();//关闭连接
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_pose_x.Text = "0";
            textBox_pose_y.Text = "0";
            textBox_pose_z.Text = "0";
            textBox_pose_roll.Text = "0";
            textBox_pose_pitch.Text = "0";
            textBox_pose_yaw.Text = "0";
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            SendMsg("PLAY");
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            SendMsg("STOP");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void trackBar_pose_frame_Scroll(object sender, EventArgs e)
        {
            int temp;

            int.TryParse(trackBar_pose_frame.Value.ToString(), out temp);

            textBox_pose_frame.Text = ((float)temp).ToString();
        }

        private void textBox_pose_frame_TextChanged(object sender, EventArgs e)
        {
            float temp;

            bool result = float.TryParse(textBox_pose_frame.Text.ToString(), out temp);

            if (result)
            {
                if ((int)temp < trackBar_pose_frame.Minimum)
                {
                    trackBar_pose_frame.Value = trackBar_pose_frame.Minimum;
                }
                else if ((int)temp > trackBar_pose_frame.Maximum)
                {
                    trackBar_pose_frame.Value = trackBar_pose_frame.Maximum;
                }
                else
                {
                    trackBar_pose_frame.Value = (int)temp;
                }
            }
        }

        private void trackBar_pose_range_Scroll(object sender, EventArgs e)
        {
            int temp;

            int.TryParse(trackBar_pose_range.Value.ToString(), out temp);

            textBox_pose_range.Text = ((float)temp).ToString();
        }

        private void textBox_pose_range_TextChanged(object sender, EventArgs e)
        {
            float temp;

            bool result = float.TryParse(textBox_pose_range.Text.ToString(), out temp);

            if (result)
            {
                if ((int)temp < trackBar_pose_range.Minimum)
                {
                    trackBar_pose_range.Value = trackBar_pose_range.Minimum;
                }
                else if ((int)temp > trackBar_pose_frame.Maximum)
                {
                    trackBar_pose_range.Value = trackBar_pose_range.Maximum;
                }
                else
                {
                    trackBar_pose_range.Value = (int)temp;
                }
            }
        }

        private void trackBar_pose_time_Scroll(object sender, EventArgs e)
        {
            int temp;

            int.TryParse(trackBar_pose_time.Value.ToString(), out temp);

            textBox_pose_time.Text = ((float)temp).ToString();
        }

        private void textBox_pose_time_TextChanged(object sender, EventArgs e)
        {
            float temp;

            bool result = float.TryParse(textBox_pose_time.Text.ToString(), out temp);

            if (result)
            {
                if ((int)temp < trackBar_pose_time.Minimum)
                {
                    trackBar_pose_time.Value = trackBar_pose_time.Minimum;
                }
                else if ((int)temp > trackBar_pose_frame.Maximum)
                {
                    trackBar_pose_time.Value = trackBar_pose_time.Maximum;
                }
                else
                {
                    trackBar_pose_time.Value = (int)temp;
                }
            }
        }

        private void _4D座椅_Load(object sender, EventArgs e)
        {

        }
    }
}
