using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCS.Common
{
    class KeyboardHookLib
    {
        // 委托
        public delegate int MyHookDelegate(int nCode, int wParam, IntPtr lParam);

        //钩子类型：键盘
        public static int WH_KEYBOARD_LL = 13; //全局钩子键盘为13，线程钩子键盘为2
        public static int WM_KEYDOWN = 0x0100; //键按下
        public static int WM_KEYUP = 0x0101; //键弹起
        //全局系统按键
        public static int WM_SYSKEYDOWN = 0x104;
        //键盘处理委托事件,捕获键盘输入，调用委托方法
        private delegate int HookHandle(int nCode, int wParam, IntPtr lParam);
        private static HookHandle _keyBoardHookProcedure;
        //接收SetWindowsHookEx返回值   
        public static int _hHookValue = 0;
        //Hook结构 存储按键信息的结构体
        [StructLayout(LayoutKind.Sequential)]
        public class HookStruct
        {
            public int vkVode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        //安装钩子
        //idHook为13代表键盘钩子为14代表鼠标钩子，lpfn为函数指针，指向需要执行的函数，hIntance为指向进程快的指针，threadId默认为0就可以了
        [DllImport("user32.dll")]
        private static extern int SetWindowsHookEx(int idHook, HookHandle lpfn, IntPtr hInstance, int threadId);
        //取消钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //调用下一个钩子
        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);
        //获取当前线程id
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        //通过线程Id,获取进程快
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(String name);

        private IntPtr _hookWindowPtr = IntPtr.Zero;

        public KeyboardHookLib() { }

        public void InstallHook(MyHookDelegate hookDelete)
        {
            //安装键盘勾子
            if (_hHookValue == 0)
            {
                _keyBoardHookProcedure = new HookHandle(hookDelete);
                //得到进程块
                _hookWindowPtr = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
                _hHookValue = SetWindowsHookEx(
                    WH_KEYBOARD_LL,
                    _keyBoardHookProcedure,
                    _hookWindowPtr,
                    0
                    );
                //如果设置钩子失败
                if (_hHookValue == 0)
                {
                    UninstallHook();
                }
            }
        }

        //取消钩子事件
        public void UninstallHook()
        {
            if (_hHookValue != 0)
            {
                bool ret = UnhookWindowsHookEx(_hHookValue);
                if (ret)
                {
                    _hHookValue = 0;
                }
            }
        }
    }
}
