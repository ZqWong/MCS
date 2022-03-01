using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS.Common
{
    public class ICCardWriterAndReader
    {
        /// <summary>
        /// ICCard是否存在
        /// </summary>
        private bool IsICCardExist()
        {
            bool flag = true;


            return flag;
        }

        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="content">写入内容</param>
        /// <returns>成功/失败</returns>
        public static bool Write(string content)
        {
            //byte mode1 = (writeKeyB.Checked) ? (byte)0x01 : (byte)0x00;
            //byte mode2 = (writeAll.Checked) ? (byte)0x01 : (byte)0x00;
            //byte mode = (byte)((mode1 << 1) | mode2);

            byte mode = 0;

            // 起始块
            //byte blk_add = Convert.ToByte(writeStart.Text, 16); // 将10进制转换成16进制 byte temp = Convert.ToByte("3A", 16);

            // 块的数量
            //byte num_blk = Convert.ToByte(writeNum.Text, 16);

            // 起始块
            byte blk_add = 1;    // 默认从数据块1开始写入数据

            // 块的数量
            byte num_blk = 1;    // 默认只填写1个数据块，每个数据块占16个字节

            byte[] snr = new byte[6];

            //snr = convertSNR(writeKey.Text, 16);
            snr = ConvertSNR("FF FF FF FF FF FF", 16);

            if (snr == null)
            {
                Alert.alert("写入IC卡失败！原因：序列号无效。", "读卡器错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 根据选择的数据块的数量，确定数据的存储空间，因为数据块数量默认指定为1，所以数据的存储空间固定为16字节
            byte[] byteBuffers = new byte[16 * num_blk];

            // add by wangao at 2018/04/26 - start
            string contentAfterFormat = FormatInputId(content);
            // add by wangao at 2018/04/26 - end

            // ID初始化失败，直接返回
            if (string.IsNullOrEmpty(contentAfterFormat))
            {
                return false;
            }

            //string bufferStr = formatStr(writeData.Text, num_blk);

            string bufferStr = FormatStr(contentAfterFormat, num_blk);

            if (bufferStr == null)
            {
                Alert.alert("写入IC卡失败！原因：序列号无效。", "读卡器错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 将Format之后的bufferStr存到byteBuffers中
            ConvertStr(byteBuffers, bufferStr, 16 * num_blk);

            // 调用底层函数，写卡
            int ret = Reader.MF_Write(mode, blk_add, num_blk, snr, byteBuffers);

            //ShowCommand(ret);

            if (ret != 0)
            {
                ShowCommand(byteBuffers[0]);

                return false;
            }
            //else
            //{
            //    ShowData("卡号：", snr, 0, 4);
            //}

            return true;
        }

        /// <summary>
        /// 读取
        /// </summary>
        public static string[] Read()
        {
            byte mode = 0;
            byte blk_add = 1;
            byte num_blk = 1;

            byte[] snr = new byte[6];

            snr = ConvertSNR("FF FF FF FF FF FF", 6);

            if (snr == null)
            {
                //Alert.alert("读取IC卡失败！原因：序列号无效。", "读卡器错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            byte[] byteBuffers = new byte[16 * num_blk];

            int ret = Reader.MF_Read(mode, blk_add, num_blk, snr, byteBuffers);

            //ShowCommand(ret);

            // 操作失败
            if (ret != 0)
            {
                //ShowCommand(byteBuffers[0]);
                //text_OutputIdField.Text = "";
                return null;
            }
            // 操作成功
            else
            {
                string content = FormatOutputId(byteBuffers);
                    //.Replace('F', new char());

                //卡号
                string cardID = ShowData("", snr, 0, 4);

                //ShowData("数据：", byteBuffers, 0, 16 * num_blk);

                string[] strArr = { content, cardID };

                return strArr;
            }
        }

        #region 辅助方法
        /// <summary>
        /// 把输入的Id标准化
        /// </summary>
        /// <param name="content"></param>
        private static string FormatInputId(string content)
        {
            // 标准输出: 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
            content = content.Trim();

            // 不满32位用0补齐
            if (content.Length < 32)
            {
                int length = 32 - content.Length;

                for (int i = 0; i < length; i++)
                {
                    content += 'F';
                }
            }
            else if (content.Length > 32)
            {
                Alert.alert("写入IC卡失败！原因：ID过长。", "读卡器错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
                //content = content.Substring(0, 32);
            }

            //if (content.Length != 32)
            //{
            //    Alert.alert("写入IC卡失败！原因：ID长度错误", "读卡器错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    MessageBox.Show("不满足16字节无效！", "错误");
            //}

            // 每隔两位中间隔一个空格
            string result = "";

            for (int i = 0; i < content.Length; i++)
            {
                result += content[i];

                if ((i + 1) % 2 == 0 && i != content.Length - 1)
                {
                    result += " ";
                }
            }

            return result;
        }

        /// <summary>
        /// 把输出的字节数字标准化为Id
        /// </summary>
        /// <param name="byteBuffers"></param>
        /// <returns></returns>
        private static string FormatOutputId(byte[] byteBuffers)
        {
            string content = "";

            for (int i = 0; i < byteBuffers.Length; i++)
            {
                string s = string.Format("{0:X}", byteBuffers[i]);
                if (s.Length == 1)
                {
                    s = "0" + s;
                }
                content += s;
            }

            //int length = content.Length;

            //while (content[length - 1] == '0')
            //{
            //    content = content.Substring(0, length - 1);
            //    length = content.Length;
            //}

            //if (Convert.ToInt32(content) == 83) MessageBox.Show("83!!!!");

            return content;
        }

        /// <summary>
        /// 转换卡号专用
        /// </summary>
        /// <param name="str"></param>
        /// <param name="keyN"></param>
        /// <returns></returns>
        private static byte[] ConvertSNR(string str, int keyN)
        {
            string regex = "[^a-fA-F0-9]";
            string temJudge = Regex.Replace(str, regex, "");

            // 长度不对，直接返回
            if (temJudge.Length != 12) return null;

            string[] tmpResult = Regex.Split(str, regex);

            byte[] result = new byte[keyN];
            int i = 0;

            foreach (string tmp in tmpResult)
            {
                result[i] = Convert.ToByte(tmp, 16);
                i++;
            }

            return result;
        }

        /// <summary>
        /// 数据输入判断函数2个
        /// </summary>
        /// <param name="content"></param>
        /// <param name="num_blk"></param>
        /// <returns></returns>
        private static string FormatStr(string content, int num_blk)
        {
            // 将内容按照符合规定的格式输出
            string regexContent = Regex.Replace(content, "[^a-fA-F0-9]", "");

            // 检验长度
            if (num_blk == -1)    // -1表示不用检查位数
            {
                return regexContent;
            }

            //num_blk==其它负数，为-1/num_blk
            if (num_blk < -1)
            {
                if (regexContent.Length != -16 / num_blk * 2)
                {
                    return null;
                }
                else
                {
                    return regexContent;
                }
            }

            if (regexContent.Length != 16 * num_blk * 2)
            {
                return null;
            }
            else
            {
                return regexContent;
            }
        }

        /// <summary>
        /// 将string转换成16进制Byte数组
        /// </summary>
        /// <param name="after"></param>
        /// <param name="before"></param>
        /// <param name="length"></param>
        public static void ConvertStr(byte[] after, string before, int length)
        {
            for (int i = 0; i < length; i++)
            {
                after[i] = Convert.ToByte(before.Substring(2 * i, 2), 16);
            }
        }

        /// <summary>
        /// 显示数据结果
        /// </summary>
        /// <param name="text"></param>
        /// <param name="data"></param>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private static string ShowData(string text, byte[] data, int s, int e)
        {
            string content = "";

            //非负转换
            for (int i = 0; i < e; i++)
            {
                if (data[s + i] < 0)
                    data[s + i] = Convert.ToByte(Convert.ToInt32(data[s + i]) + 256);
            }

            content += text;

            for (int i = 0; i < e; i++)
            {
                content += data[s + i].ToString("X2") + " ";
            }

            return content;
        }

        /// <summary>
        /// 显示执行命令结果
        /// </summary>
        /// <param name="Code"></param>
        private static void ShowCommand(int Code)
        {
            string msg = "";
            switch (Code)
            {
                case 0x00:
                    msg = "命令执行成功 .....";
                    break;
                case 0x01:
                    msg = "命令操作失败 .....";
                    break;
                case 0x02:
                    msg = "地址校验错误 .....";
                    break;
                case 0x03:
                    msg = "找不到已选择的端口 .....";
                    break;
                case 0x04:
                    msg = "读写器返回超时 .....";
                    break;
                case 0x05:
                    msg = "数据包流水号不正确 .....";
                    break;
                case 0x07:
                    msg = "接收异常 .....";
                    break;
                case 0x0A:
                    msg = "参数值超出范围 .....";
                    break;
                case 0x80:
                    msg = "参数设置成功 .....";
                    break;
                case 0x81:
                    msg = "参数设置失败 .....";
                    break;
                case 0x82:
                    msg = "通讯超时.....";
                    break;
                case 0x83:
                    msg = "卡不存在，请把IC卡放置于读卡机上！";
                    //MessageBox.Show("请把Ic卡放置于读卡机上", "错误");
                    break;
                case 0x84:
                    msg = "接收卡数据出错.....";
                    break;
                case 0x85:
                    msg = "未知的错误.....";
                    break;
                case 0x87:
                    msg = "输入参数或者输入命令格式错误.....";
                    break;
                case 0x89:
                    msg = "输入的指令代码不存在.....";
                    break;
                case 0x8A:
                    msg = "在对于卡块初始化命令中出现错误.....";
                    break;
                case 0x8B:
                    msg = "在防冲突过程中得到错误的序列号.....";
                    break;
                case 0x8C:
                    msg = "密码认证没通过.....";
                    break;
                case 0x8F:
                    msg = "读取器接收到未知命令.....";
                    break;
                case 0x90:
                    msg = "卡不支持这个命令.....";
                    break;
                case 0x91:
                    msg = "命令格式有错误.....";
                    break;
                case 0x92:
                    msg = "在命令的FLAG参数中，不支持OPTION 模式.....";
                    break;
                case 0x93:
                    msg = "要操作的BLOCK不存在.....";
                    break;
                case 0x94:
                    msg = "要操作的对象已经别锁定，不能进行修改.....";
                    break;
                case 0x95:
                    msg = "锁定操作不成功.....";
                    break;
                case 0x96:
                    msg = "写操作不成功.....";
                    break;
                default:
                    msg = "未知错误2.....";
                    break;
            }

            Alert.alert("写入IC卡失败！原因：" + msg, "读卡器错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
