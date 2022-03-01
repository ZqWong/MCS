using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using DW_CC_NET.tools;
using UserEventData;
using Utilities;

namespace cc_clinet
{
    /// <summary>
    /// 时间同步
    /// </summary>
    public class TimeSyncHandler : IEventHandler<S_C_SyncSystemTimeData>
    {
        private struct SYSTEMTIME
        {
            public short year;
            public short month;
            public short dayOfWeek;
            public short day;
            public short hour;
            public short minute;
            public short second;
            public short milliseconds;
        }

        //设置系统时间的API函数
        [DllImport("kernel32.dll")]
        private static extern bool SetLocalTime(ref SYSTEMTIME time);
        public void HandleEvent(S_C_SyncSystemTimeData eventData)
        {
            bool flag = false;

            SYSTEMTIME st;
            st.year = (short)eventData.wYear;
            st.month = (short) eventData.wMonth;
            st.dayOfWeek = (short)eventData.wDayOfWeek;
            st.day = (short)eventData.wDay;
            st.hour = (short)eventData.wHour;
            st.minute = (short)eventData.wMinute;
            st.second = (short)eventData.wSecond;
            st.milliseconds = (short)eventData.wMiliseconds;

            try
            {
                // 关闭时间同步
                // flag = SetLocalTime(ref st);
            }
            catch (Exception e)
            {
                NlogHandler.GetSingleton().Error("SetSystemDateTime函数执行异常 : " + e.Message);
            }
            // NlogHandler.GetSingleton().Info("时间同步成功");

        }
    }
}
