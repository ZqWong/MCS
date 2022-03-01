/*********************************************************************************
 *Copyright(C) 2018 by wuxin
 *All rights reserved.
 *FileName:    IDCardReader.cs
 *Author:      wuxin
 *Version:     1.0
 *Date:         
 *Description:   推荐操作流程：
 *               初始化端口（启动定时器或线程，以可以循环读卡） → 
 *               验证卡 → 
 *               读基本信息 → 
 *               显示处理信息或调用GetXXX函数获取单项信息 → 
 *               关闭端口（不再读卡操作或程序退出前，需要关闭端口）
 *History:  
**********************************************************************************/
using Common.Model;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MCS.Common
{

    public class IDCardReader
    {
        public static byte cmd;
        public static int para0;
        public static int para1;
        public static int para2;

        public static int nRet;

        private static string _TxtFilePath = Application.StartupPath + @"\wx.txt";
        private static string _DefaultPhotoFilePath = Application.StartupPath + @"\blank.bmp";
        private static string _PhotoFilePath = Application.StartupPath + @"\\zp.bmp";


        /// <summary>
        /// 初始化端口
        /// </summary>
        /// <returns>true成功/false失败</returns>
        public static bool InitializePort()
        {
            bool result = false;

            cmd = 65; // 0x41 初始化端口
            para0 = 0;
            para1 = 8811;
            para2 = 9986;

            nRet = UCommand1(ref cmd, ref para0, ref para1, ref para2);

            if (nRet == 62171)
            {
                result = true;
            }

            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 读卡中……
        /// </summary>
        /// <returns>姓名，身份证号</returns>
        public static ExamineeModel ReadingCard()
        {
            ExamineeModel em = new ExamineeModel();

            cmd = 67; // 0x43 验证卡
            para0 = 0;
            para1 = 8811;
            para2 = 9986;

            nRet = UCommand1(ref cmd, ref para0, ref para1, ref para2);

            if (nRet == 62171)
            {
                //this.pictureBox1.Image = Image.FromFile(_DefaultPhotoFilePath);

                if (File.Exists(_TxtFilePath))
                {
                    File.Delete(_TxtFilePath);
                }
                if (File.Exists(_PhotoFilePath))
                {
                    File.Delete(_PhotoFilePath);
                }

                cmd = 68; // 0x44 读卡内信息
                para0 = 0;
                para1 = 8811;
                para2 = 9986;

                nRet = UCommand1(ref cmd, ref para0, ref para1, ref para2);

                if (nRet == 62171 || nRet == 62172)
                {
                    StreamReader sr = new StreamReader(_TxtFilePath, Encoding.Default);
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // 姓名
                        if (i == 0)
                        {
                            em.ExamineeName = line;
                        }
                        // 身份证号
                        else if (i == 5)
                        {
                            em.IDCardNum = line;
                        }

                        i++;
                    }

                    sr.Close();
                    sr.Dispose();
                }
                else if (nRet == -5)
                {
                    Alert.alert("身份证读卡器软件未授权！");
                    LogHelper.WriteErrorLog("身份证读卡器软件未授权！");
                }

                return em;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 关闭端口
        /// </summary>
        public static void ClosePort()
        {
            cmd = 66; // 0x42 关闭端口
            para0 = 0;
            para1 = 8811;
            para2 = 9986;

            try
            {
                nRet = UCommand1(ref cmd, ref para0, ref para1, ref para2);
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("关闭身份证阅读器端口失败！");
            }
        }


        [DllImport("RdCard.dll")]
        public static extern int UCommand1(ref byte pCmd, ref int para0, ref int para1, ref int para2);

    }
}
