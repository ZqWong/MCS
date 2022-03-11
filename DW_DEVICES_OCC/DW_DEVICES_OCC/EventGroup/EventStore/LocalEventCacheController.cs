using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace EventGroup
{
    /// <summary>
    /// 内存中的事件缓存
    /// </summary>
    public class LocalEventCacheController/* : IEventStore*/
    {
        /// <summary>
        /// 定义锁对象
        /// </summary>
        private static readonly object LockObj = new object();

        /// <summary>
        /// 多线程字典
        /// </summary>
        private readonly ConcurrentDictionary<Type, List<Type>> m_eventAndHandlerMapping;

        public LocalEventCacheController()
        {
            m_eventAndHandlerMapping = new ConcurrentDictionary<Type, List<Type>>();
        }
        public void AddRegister<T, TH>() where T : IEventData where TH : IEventHandler
        {
            AddRegister(typeof(T), typeof(TH));
        }


        public void AddActionRegister<T>(Action<T> action) where T : EventData
        {
            var actionHandler = new ActionEventHandler<T>(action);

            AddRegister(typeof(T), actionHandler.GetType());
        }

        /// <summary>
        /// 添加事件到字典中
        /// </summary>
        /// <param name="eventData"></param>
        /// <param name="eventHandler"></param>
        public void AddRegister(Type eventData, Type eventHandler)
        {
            lock (LockObj)
            {
                if (!HasRegisterForEvent(eventData))
                {
                    var handlers = new List<Type>();
                    m_eventAndHandlerMapping.TryAdd(eventData, handlers);
                }

                if (m_eventAndHandlerMapping[eventData].All(h => h != eventHandler))
                {
                    m_eventAndHandlerMapping[eventData].Add(eventHandler);
                }
            }
        }

        public void RemoveRegister<T, TH>() where T : IEventData where TH : IEventHandler
        {
            var handlerToRemove = FindRegisterToRemove(typeof(T), typeof(TH));
            RemoveRegister(typeof(T), handlerToRemove);
        }

        public void RemoveActionRegister<T>(Action<T> action) where T : EventData
        {
            var actionHandler = new ActionEventHandler<T>(action);
            var handlerToRemove = FindRegisterToRemove(typeof(T), actionHandler.GetType());
            RemoveRegister(typeof(T), handlerToRemove);
        }

        public void RemoveRegister(Type eventData, Type eventHandler)
        {
            if (eventHandler != null)
            {
                lock (LockObj)
                {
                    m_eventAndHandlerMapping[eventData].Remove(eventHandler);
                    if (!m_eventAndHandlerMapping[eventData].Any())
                    {
                        List<Type> removedHandlers;
                        m_eventAndHandlerMapping.TryRemove(eventData, out removedHandlers);
                    }
                }
            }
        }

        private Type FindRegisterToRemove(Type eventData, Type eventHandler)
        {
            if (!HasRegisterForEvent(eventData))
            {
                return null;
            }

            return m_eventAndHandlerMapping[eventData].FirstOrDefault(eh => eh == eventHandler);
        }

        public bool HasRegisterForEvent<T>() where T : IEventData
        {
            return m_eventAndHandlerMapping.ContainsKey(typeof(T));
        }

        /// <summary>
        /// 检测是否有不表事件存在
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public bool HasRegisterForEvent(Type eventData)
        {
            return m_eventAndHandlerMapping.ContainsKey(eventData);
        }

        public IEnumerable<Type> GetHandlersForEvent<T>() where T : IEventData
        {
            return GetHandlersForEvent(typeof(T));
        }

        public IEnumerable<Type> GetHandlersForEvent(Type eventData)
        {
            if (HasRegisterForEvent(eventData))
            {
                return m_eventAndHandlerMapping[eventData];
            }

            return new List<Type>();
        }

        public Type GetEventTypeByName(string eventName)
        {
            return m_eventAndHandlerMapping.Keys.FirstOrDefault(eh => eh.Name == eventName);
        }

        public bool IsEmpty => !m_eventAndHandlerMapping.Keys.Any();

        public void Clear() => m_eventAndHandlerMapping.Clear();
    }
}