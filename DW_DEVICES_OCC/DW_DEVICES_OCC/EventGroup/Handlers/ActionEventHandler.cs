using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGroup
{
    /// <summary>
    /// 支持Action的事件处理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ActionEventHandler<T> : IEventHandler<T> where T : EventData
    {
        /// <summary>
        /// 定义Action的引用，并通过构造函数传参初始化
        /// </summary>
        public Action<T> Action { get; private set; }

        public ActionEventHandler(Action<T> handler)
        {
            Action = handler;
        }

        /// <summary>
        /// 调用具体的Action来处理事件逻辑
        /// </summary>
        /// <param name="eventData"></param>
        public void HandleEvent(T eventData)
        {
            Action(eventData);
        }
    }
}
