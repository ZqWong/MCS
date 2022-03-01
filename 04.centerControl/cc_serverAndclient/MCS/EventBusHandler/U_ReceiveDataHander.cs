using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Model;
using DW_CC_NET.Handlers;
using DW_CC_NET.RabbitMQ;
using MCS;
using UserEventData;
using Utilities;

namespace cc_server
{
    /// <summary>
    /// 处理unity发送的数据
    /// </summary>
    public class U_ReceiveDataHander : IEventHandler<U_S_DeviceData>
    {
        //todo 更改为了方案控制  需要重写
        public void HandleEvent(U_S_DeviceData eventData)
        {
            NlogHandler.GetSingleton().Info(string.Format("Unity发送数据 seatData :{0}", System.Text.Encoding.Default.GetString(eventData.seatDatas) ));
        }
    }
}
