using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using LibUtilitiesNameSpace;

namespace LibNvDriverSetting
{
    /*
    把类的指针给暴露出来，然后需要用的时候，传回C++的接口函数就可以了。

    你根本就不用管这个类在C++里面是怎么定义的，也最好不要知道，如果不得不需要知道的话，那就请重新设计……

    {类的有一个成员函数，是返回这个类的指针，那么在C#里面就是一个INTPTR，它是什么你不用管。

    然后C++文件里面再定义几个函数，专门用于处理这个类的对像的操作，参数就是类对像的指针。这样你在C#层调用C++的这个函数，并将准备好的类对像的指针传回去就好了。

    这种方法，安全，方便，而且……你那些查到的使用C++函数的方法，就可以用得到了。

    当然了，暴露出整个C++类的定义也是可以的，不过那样要进行一次全结构定义复制，涉及到类型转换，很麻烦，而且不安全，最好不要这么做。
    
     *
     * 
    C++ class A{void print()}

    C++ 函数1  INTPTR getAinstance(){return (INTPTR )new A()}

    C++ 函数2  void   A_print(INTPTR pA){A* pa = (A*)pA;pa->print();}
     * 
     * 
 
    DllImport 属性定义如下：
    namespace System.Runtime.InteropServices
    {
      [AttributeUsage(AttributeTargets.Method)]
      public class DllImportAttribute: System.Attribute
      {
       public DllImportAttribute(string dllName) {...}
       public CallingConvention CallingConvention;
       public CharSet CharSet;
       public string EntryPoint;
       public bool ExactSpelling;
       public bool PreserveSig;
       public bool SetLastError;
       public string Value { get {...} }
      }
    } 
      说明： 
      1、DllImport只能放置在方法声明上。 
      2、DllImport具有单个定位参数：指定包含被导入方法的 dll 名称的 dllName 参数。 
      3、DllImport具有五个命名参数： 
       a、CallingConvention 参数指示入口点的调用约定。如果未指定 CallingConvention，则使用默认值 CallingConvention.Winapi。 
       b、CharSet 参数指示用在入口点中的字符集。如果未指定 CharSet，则使用默认值 CharSet.Auto。 
       c、EntryPoint 参数给出 dll 中入口点的名称。如果未指定 EntryPoint，则使用方法本身的名称。 
       d、ExactSpelling 参数指示 EntryPoint 是否必须与指示的入口点的拼写完全匹配。如果未指定 ExactSpelling，则使用默认值 false。 
       e、PreserveSig 参数指示方法的签名应当被保留还是被转换。当签名被转换时，它被转换为一个具有 HRESULT 返回值和该返回值的一个名为 retval 的附加输出参数的签名。如果未指定 PreserveSig，则使用默认值 true。 
       f、SetLastError 参数指示方法是否保留 Win32"上一错误"。如果未指定 SetLastError，则使用默认值 false。 
      4、它是一次性属性类。 
      5、此外，用 DllImport 属性修饰的方法必须具有 extern 修饰符。
     * 
     * 
     Nvidia启动立体的函数不太稳定，因此通过启动外部程序的方式来启用、禁用立体。
     NV的外部程序只需要下面三个文件就可以单独提取出来使用 nvSCPAPI.dll nvSCPAPI64.dll nvstlink.exe
     */

    //客户端NV状态的获取通过控制台程序+读写文本的方式进行。对控制面板的设置直接调用dll中的函数
    //客户端NV状态的获取必须得将程序关闭之后再运行才能获取到正确的状态 ，如果不关闭程序的话，
    //用户手动更改控制面板中的内容后，应用程序不能获取到正确的状态，这个不是代码的问题，是英伟达
    //自身提供的函数的问题（可能是英伟达提供的函数初始化机制导致的）
    public class LibNvDriverSetting
    {
        private const string NV_DLL_NAME = @"./NvState/NvDriverSettingDll.dll";
        private const string STATE_SEPERATOR = " ";

        [DllImport(NV_DLL_NAME)]
        public static extern void EnableStereo(bool enable);

        [DllImport(NV_DLL_NAME)]
        public static extern void SwapEyes(bool on);

        [DllImport(NV_DLL_NAME)]
        public static extern void SetNVDefaultValuesExceptSwap();

        [DllImport(NV_DLL_NAME)]
        public static extern void SetNvDriverDefaultValue();

        [DllImport(NV_DLL_NAME)]
        public static extern NvStateData GetNvCurStateByFile(string path);

        [DllImport(NV_DLL_NAME)]
        public static extern void Init();

        [DllImport(NV_DLL_NAME)]
        public static extern void Free();

        /// <summary>
        /// 将英伟达状态转换成socket传送的字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ConvertNvState2SocketString(NvStateData data)
        {
            string ret = "";

            ret = data.m_stereoOn.ToString();
            ret += STATE_SEPERATOR;
            ret += data.m_swapEye.ToString();
            return ret;
        }

        /// <summary>
        /// 将socket发送过来的NV状态转换成NvStateData
        /// </summary>
        /// <param name="sktData"></param>
        /// <returns></returns>
        public static NvStateData ConvertSocketString2NvState(string sktData)
        {
            NvStateData data;
            data.m_stereoOn = 1;
            data.m_swapEye = 1;

            string[] strArrDataRecv = sktData.Split(new string[] { STATE_SEPERATOR }, StringSplitOptions.None);
            if (strArrDataRecv.Length == 2)//拆分后只有两个元素
            {
                data.m_stereoOn = Convert.ToInt32(strArrDataRecv[0]);
                data.m_swapEye = Convert.ToInt32(strArrDataRecv[1]);
            }
            return data;
        }

        /// <summary>
        /// 测试用
        /// </summary>
        public static NvStateData GetCurrentState()
        {
            NvStateData data = GetNvCurStateByFile(LibUtilities.GetAssemblyExeFolder() + "\\NvStateRwWin32.exe");

            return data;
        }
    }

    public struct NvStateData
    {
        public int m_swapEye;
        public int m_stereoOn;
    }



}
