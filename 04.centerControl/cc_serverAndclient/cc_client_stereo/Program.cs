using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using LibNvDriverSetting;
using LibUtilitiesNameSpace;


namespace cc_client_stereo
{
    class Program
    {
        /// <summary>
        /// 控制立体和左右眼饭庄的dll是32位，所以需要通过该32位的exe的管道通信进行转发
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            NamedPipeClientStream client = new NamedPipeClientStream("127.0.0.1", "StereoPipeLine");

            client.Connect();

            if (client.IsConnected)
            {
                Console.WriteLine("connect success");

                StreamWriter sw = new StreamWriter(client);

                StreamReader reder = new StreamReader(client);
                string result = reder.ReadLine();

                

                if (result == "GetStereoInfo")
                {
                    Console.WriteLine(result);

                    //获取客户端立体显示的状态
                    NvStateData data = LibNvDriverSetting.LibNvDriverSetting.GetNvCurStateByFile(LibUtilities.GetAssemblyExeFolder() + @"\NvState\NvStateRwWin32.exe");

                    // 通过管道发送回去，发送格式为GetStereoInfo+立体+左右眼
                    sw.WriteLine(result + data.m_stereoOn + data.m_swapEye);
                    Console.WriteLine(data.m_stereoOn + "   " + data.m_swapEye);
                }
                else if (result.StartsWith("SetStereo"))
                {

                    string stereo = result.Substring("SetStereo".Length, 1);
                    string swapEye = result.Substring("SetStereo".Length + 1, 1);

                    LibNvDriverSetting.LibNvDriverSetting.SwapEyes(Convert.ToBoolean(Convert.ToInt32(swapEye)));

                    LibNvDriverSetting.LibNvDriverSetting.EnableStereo(Convert.ToBoolean(Convert.ToInt32(stereo)));

                    // 通过管道发送回去
                    sw.WriteLine("SetStereo" + stereo + swapEye);
                }
                else if (result == "SetEye")
                {
                    NvStateData data = LibNvDriverSetting.LibNvDriverSetting.GetNvCurStateByFile(LibUtilities.GetAssemblyExeFolder() + @"\NvState\NvStateRwWin32.exe");

                    try
                    {
                        LibNvDriverSetting.LibNvDriverSetting.SwapEyes(!Convert.ToBoolean(data.m_swapEye));

                        // 通过管道发送回去
                        sw.WriteLine(result + Convert.ToInt32(!Convert.ToBoolean(data.m_swapEye)));

                    }
                    catch (System.Exception ex)
                    {
                    }
                }

                else if (result == "SetStereo")
                {
                    NvStateData data = LibNvDriverSetting.LibNvDriverSetting.GetNvCurStateByFile(LibUtilities.GetAssemblyExeFolder() + @"\NvState\NvStateRwWin32.exe");

                    try
                    {
                        LibNvDriverSetting.LibNvDriverSetting.EnableStereo(!Convert.ToBoolean(data.m_stereoOn));

                        // 通过管道发送回去
                        sw.WriteLine(result + Convert.ToInt32(!Convert.ToBoolean(data.m_stereoOn)));

                        //NlogHandler.GetSingleton().Info("当前显卡设置状态：立体->" + eventData.m_stereoOn + ", 左右眼->" + eventData.m_swapEye);

                    }
                    catch (System.Exception ex)
                    {

                    }
                }
                

                sw.Close();
                reder.Close();
            }
        }
    }
}
