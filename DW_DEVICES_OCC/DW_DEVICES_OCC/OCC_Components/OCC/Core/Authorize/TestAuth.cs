using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




public class TestAuth
{
    /// <summary>
    /// 验证非负正整数是否为 2 的幂级
    /// </summary>
    /// <remarks>
    /// 判断是2的幂，1个数乘以2就是将该数左移1位，而2的0次幂为1， 所以2的n次幂（就是2的0次幂n次乘以2）就是将1左移n位， 这样我们知道如果一个数n是2的幂，则其只有首位为1，其后若干个0，必然有n & (n - 1)为0。（在求1个数的二进制表示中1的个数的时候说过，n&(n-1)去掉n的最后一个1）。因此，判断一个数n是否为2的幂，只需要判断n&(n-1)是否为0即可。
    /// </remarks>
    /// <returns></returns>

    public void TestIsBinPower(int i)
    {
        string str = "";
        //for (int i = 0; i < 64; i++)
        //{
            long n = UserAuthManager.GetBinPower(i);
            str = UserAuthManager.GetBin(n);
            if (!UserAuthManager.IsBinPower(n))
                Debug.Info($"TestIsBinPower {str} false");
        //}
        Debug.Info($" TestIsBinPower {str} true");
    }


    /// <summary>
    /// 获取2 的 x 次方值
    /// </summary>
    /// <returns></returns>
    public void TestGetBinPower()
    {
        long n = (long)Math.Pow(2, 50);
        string ns = UserAuthManager.GetBin(n);


        long m = UserAuthManager.GetBinPower(50);
        string ms = UserAuthManager.GetBin(m);
        Debug.Info($"TestGetBinPower {n == m}");
    }
    /// <summary>
    /// 将数值转为等值2进制数
    /// </summary>
    /// <returns></returns>
    public void TestGetBin()
    {
        long n = (long)Math.Pow(2, 50);
        string s1 = UserAuthManager.GetBin(n);
        string s2 = Convert.ToString(n, 2);
        Debug.Info($"TestGetBin {s1.Equals(s2)}");
    }


    /// <summary>
    /// 生成鉴权码
    /// </summary>
    /// <param name="arr">权限值（2的幂级）</param>
    /// <remarks>每个鉴权值执行或操作</remarks>
    /// <returns></returns>
    public void TestGenAuthCode()
    {
        long authCode = 0;
        string binStr = "";
        List<long> codeList = new List<long>();
        for (int i = 1; i <= 62; i++)
        {
            codeList.Add((long)Math.Pow(2, i));
        }
        authCode = UserAuthManager.GenAuthCode(codeList.ToArray());
        binStr = UserAuthManager.GetBin(authCode); ;
        Debug.Info($"TestGenAuthCode true");
    }
    /// <summary>
    /// 添加权限
    /// </summary>
    /// <remarks>code = authCode | auth</remarks>
    /// <returns></returns>
    public void TestAddAuth()
    {
        long authCode = 0;
        string binStr = "";
        for (int i = 1; i <= 62; i++)
        {
            long x = UserAuthManager.GetBinPower(i);
            authCode = UserAuthManager.AddAuth(authCode, x);
            binStr = UserAuthManager.GetBin(authCode);
        }
        binStr = UserAuthManager.GetBin(authCode);
        Debug.Info($"TestAddAuth true");
    }
    /// <summary>
    /// 移除权限
    /// </summary>
    /// <remarks>code = authCode & (~auth)</remarks>
    /// <returns></returns>
    public void TestRemoveAuth()
    {
        long authCode = 9223372036854775806;//表示最大权限值
        string binStr = "";
        for (int i = 1; i <= 62; i++)
        {
            long x = UserAuthManager.GetBinPower(i);
            authCode = UserAuthManager.RemoveAuth(authCode, x);
            binStr = UserAuthManager.GetBin(authCode);
        }
        binStr = UserAuthManager.GetBin(authCode);
        Debug.Info($"TestRemoveAuth true");
    }


    /// <summary>
    /// 验证权限
    /// </summary>
    /// <returns></returns>
    public void TestIsHasAuth()
    {
        long[] arr = { 1, 2, 4, 8, 16, 32, 64 };
        long authCode = UserAuthManager.GenAuthCode(arr);

        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(authCode, 1)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(authCode, 2)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(authCode, 4)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(authCode, 8)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(authCode, 16)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(authCode, 32)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(authCode, 64)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(authCode, 128)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(authCode, 256)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(-1, 1)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(0, 0)}");
        Debug.Info($"TestIsHasAuth {UserAuthManager.IsHasAuth(0, 0)}");
    }
}
