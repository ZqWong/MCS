using DW_CC_NET.Handlers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DW_CC_NET.EventStore;

/// <summary>
/// 
/// </summary>

namespace DW_CC_NET
{
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly IEventStore _eventStore;
        public IWindsorContainer IocContainer { get; private set; }
        public static EventBus Default { get; private set; }

        public EventBus()
        {
            _eventStore = new InMemoryEventStore();
            IocContainer = new WindsorContainer();
        }

        static EventBus()
        {
            Default = new EventBus();
        }

        #region Register

        /// <summary>
        /// 手动绑定事件源与事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandler"></param>
        public void Register<TEventData>(IEventHandler eventHandler) where TEventData : IEventData
        {
            Register(typeof(TEventData), eventHandler.GetType());
        }

        /// <summary>
        /// 注册Action事件处理器
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="action"></param>
        public void Register<TEventData>(Action<TEventData> action) where TEventData : IEventData
        {
            //1.构造ActionEventHandler
            var actionHandler = new ActionEventHandler<TEventData>(action);

            //2.将ActionEventHandler的实例注入到Ioc容器
            IocContainer.Register(
                Component.For<IEventHandler<TEventData>>()
                .UsingFactoryMethod(() => actionHandler));

            //3.注册到事件总线
            Register<TEventData>(actionHandler);
        }

        /// <summary>
        /// 手动绑定事件源与事件处理
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="handlerType"></param>
        public void Register(Type eventType, Type handlerType)
        {
            //注册IEventHandler<T>到IOC容器
            var handlerInterface = handlerType.GetInterface("IEventHandler`1");
            if (!IocContainer.Kernel.HasComponent(handlerInterface))
            {
                IocContainer.Register(
                    Component.For(handlerInterface, handlerType));
            }

            _eventStore.AddRegister(eventType, handlerType);
        }

        /// <summary>
        /// 提供入口支持注册其它程序集中实现的IEventHandler
        /// </summary>
        /// <param name="assembly"></param>
        public void RegisterAllEventHandlerFromAssembly(Assembly assembly)
        {
            //1.将IEventHandler注册到Ioc容器
            // 包括component和service
            IocContainer.Register(Classes.FromAssembly(assembly)
                .BasedOn(typeof(IEventHandler<>))
                .WithService.Base());

            //2.从IOC容器中获取注册的所有IEventHandler
            // 仅获取component（type）
            var handlers = IocContainer.Kernel.GetAssignableHandlers(typeof(IEventHandler));
            foreach (var handler in handlers)
            {
                //循环遍历所有的IEventHandler<T>
                //获取当前type继承或实现的所有接口
                var interfaces = handler.ComponentModel.Implementation.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    //过滤掉除继承自IEventHandler之外的所有继承的接口
                    if (!typeof(IEventHandler).IsAssignableFrom(@interface))
                    {
                        continue;
                    }

                    //获取泛型参数类型
                    var genericArgs = @interface.GetGenericArguments();
                    if (genericArgs.Length == 1)
                    {
                        //注册到事件源（数据）与事件处理的映射（type）字典中
                        //可以理解为IocContainer保存着所有不需要new出来的handler实例
                        //_eventStore 作用是通过事件源（数据）可以获取到所有的handler的type，之后再IocContainer中找到handler实例来处理
                        Register(genericArgs[0], handler.ComponentModel.Implementation);
                    }
                }
            }
        }

        #endregion

        #region UnRegister 

        /// <summary>
        /// 手动解除事件源与事件处理的绑定
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="handlerType"></param>
        public void UnRegister<TEventData>(Type handlerType) where TEventData : IEventData
        {
            _eventStore.RemoveRegister(typeof(TEventData), handlerType);
        }

        /// <summary>
        /// 卸载指定事件源上绑定的所有事件
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        public void UnRegisterAll<TEventData>() where TEventData : IEventData
        {
            //获取所有映射的EventHandler
            List<Type> handlerTypes = _eventStore.GetHandlersForEvent(typeof(TEventData)).ToList();
            foreach (var handlerType in handlerTypes)
            {
                _eventStore.RemoveRegister(typeof(TEventData), handlerType);
            }
        }

        #endregion

        #region Trigger

        /// <summary>
        /// 根据事件源触发绑定的事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventData"></param>
        public void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            //获取所有映射的EventHandler
            List<Type> handlerTypes = _eventStore.GetHandlersForEvent(eventData.GetType()).ToList();

            if (handlerTypes.Count > 0)
            {
                foreach (var handlerType in handlerTypes)
                {
                    //获取当前type实现或继承的特定接口
                    //返回值是由当前type实现或继承的接口对象
                    var handlerInterface = handlerType.GetInterface("IEventHandler`1");
                    //通过接口从Ioc容器中获取所有的实例
                    var eventHandlers = IocContainer.ResolveAll(handlerInterface);

                    //循环遍历，仅当解析的实例类型与映射字典中事件处理类型一致时，才触发事件
                    foreach (var eventHandler in eventHandlers)
                    {
                        if (eventHandler.GetType() == handlerType)
                        {
                            var handler = eventHandler as IEventHandler<TEventData>;
                            handler?.HandleEvent(eventData);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 触发指定EventHandler
        /// </summary>
        /// <param name="eventHandlerType"></param>
        /// <param name="eventData"></param>

        public void Trigger<TEventData>(Type eventHandlerType, TEventData eventData)
            where TEventData : IEventData
        {
            if (_eventStore.HasRegisterForEvent<TEventData>())
            {
                var handlers = _eventStore.GetHandlersForEvent<TEventData>();
                if (handlers.Any(th => th == eventHandlerType))
                {
                    //获取类型实现的泛型接口
                    var handlerInterface = eventHandlerType.GetInterface("IEventHandler`1");

                    var eventHandlers = IocContainer.ResolveAll(handlerInterface);
                    //循环遍历，仅当解析的实例类型与映射字典中事件处理类型一致时，才触发事件
                    foreach (var eventHandler in eventHandlers)
                    {
                        if (eventHandler.GetType() == eventHandlerType)
                        {
                            var handler = eventHandler as IEventHandler<TEventData>;
                            handler?.HandleEvent(eventData);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 异步触发
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public Task TriggerAsync<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            return Task.Run(() => Trigger<TEventData>(eventData));
        }

        /// <summary>
        /// 异步触发指定EventHandler
        /// </summary>
        /// <param name="eventHandlerType"></param>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public Task TriggerAsycn<TEventData>(Type eventHandlerType, TEventData eventData)
            where TEventData : IEventData
        {
            return Task.Run(() => Trigger(eventHandlerType, eventData));
        }

        #endregion
    }
}
