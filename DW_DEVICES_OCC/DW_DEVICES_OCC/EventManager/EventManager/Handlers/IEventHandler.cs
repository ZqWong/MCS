using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQEvent
{
    /// <summary>
    /// 定义事件处理器公共接口，所有的事件处理都要实现该接口
    /// </summary>
    public interface IEventHandler
    {
    }

    /// <summary>
    /// 泛型事件处理器接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // public interface IEventHandler<T> : IEventHandler where T : IEventData 这里用IEventData有点不太严谨，会缺失一些基本信息
    public interface IEventHandler<T> : IEventHandler where T : EventData
    {
        /// <summary>
        /// 事件处理器实现该方法来处理事件
        /// </summary>
        /// <param name="eventData"></param>
        void HandleEvent(T eventData);
    }
}
