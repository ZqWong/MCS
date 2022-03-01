using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class SocketModel
    {
        /// <summary>
        /// 
        /// </summary>
        public byte Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Command { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Message { get; set; }

        public SocketModel()
        {

        }

        public SocketModel(byte type, int area, int command, object message)
        {
            this.Type = type;
            this.Area = area;
            this.Command = command;
            this.Message = message;
        }

        public T GetMessage<T>()
        {
            return (T)this.Message;
        }
    }
}
