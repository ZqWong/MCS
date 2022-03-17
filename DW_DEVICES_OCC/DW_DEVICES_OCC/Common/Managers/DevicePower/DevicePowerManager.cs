using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DevicePowerManager
{

    /// <summary>
    /// 远程关闭计算机（需要设计Guest用户）
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public static bool RemotePowerOff(string ip, int delay = 1)
    {
        bool ret = false;

        string tmpCmd = $"shutdown -s -m \\\\{ip} -t {delay}";
        string[] cmd = new string[]
        {
               tmpCmd
        };
        int exitCode = SystemHelper.RunCmd(cmd);
        if (exitCode == 0)
        {
            ret = true;
        }
        else
        {
            Debug.Error("远程关闭计算机" + ip + " 出现异常：" + exitCode.ToString());
            ret = false;
        }

        return ret;
    }

    /// <summary>
    /// 远程重启计算机（需要设计Guest用户）
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    public static bool RemoteRestart(string ip, int delay = 1)
    {
        bool ret = false;

        string tmpCmd = $"shutdown -r -m \\\\{ip} -t {delay}";

        string[] cmd = new string[]
        {
                tmpCmd
        };
        int exitCode = SystemHelper.RunCmd(cmd);
        if (exitCode == 0)
        {
            ret = true;
        }
        else
        {
            string log = "远程重启计算机" + ip + " 出现异常：";
            if (exitCode == 5)
            {
                log += "目标计算机拒绝访问,请检查是否正确设置了Guest账户！";
            }
            else if (exitCode == 53)
            {
                log += "输入的计算机名无效，或者目标计算机不支持远程关闭。请检查名称然后再试一次，或者与您的系统管理员联系。";
            }
            log += "(错误码：" + exitCode.ToString() + ")";

            Debug.Error (log);
            ret = false;
        }

        return ret;
    }

    /// <summary>
    /// 远程开启计算机 macAddress should  look like '013FA049'
    /// 现在发现的问题是第一次断电之后不能启动
    /// </summary>
    /// <param name="macAddress"></param>
    public static void RemotePowerOn(string macAddress)
    {
        macAddress = macAddress.Replace("-", "");

        try
        {
            PowerOnHelper client = new PowerOnHelper();

            //255.255.255.255  i.e broadcast
            // port=12287 let's use this one 
            client.Connect(new System.Net.IPAddress(0xffffffff), 0x2fff);
            client.SetClientToBrodcastMode();
            //set sending bites
            int counter = 0;
            //buffer to be send
            byte[] bytes = new byte[1024];   // more than enough :-)
                                             //first 6 bytes should be 0xFF
            for (int y = 0; y < 6; y++)
                bytes[counter++] = 0xFF;
            //now repeate MAC 16 times
            for (int y = 0; y < 16; y++)
            {
                int i = 0;
                for (int z = 0; z < 6; z++)
                {
                    bytes[counter++] =
                        byte.Parse(macAddress.Substring(i, 2),
                        System.Globalization.NumberStyles.HexNumber);
                    i += 2;
                }
            }

            //now send wake up packet
            int reterned_value = client.Send(bytes, 1024);
        }
        catch (Exception e)
        {
            Debug.Error("远程唤醒计算机" + macAddress + " 出现异常：" + e.ToString());
            throw e;
        }
    }


}

