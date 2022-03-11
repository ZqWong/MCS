using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DW_CC_NET.EventStore;
using DW_CC_NET.Handlers;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using UserEventData;

namespace DW_CC_NET.RabbitMQ
{

    // ReSharper disable once InconsistentNaming
    public class RabbitMQEventBus : Singleton<RabbitMQEventBus>, IEventBus
    {
        // 同步上下文
        private static SynchronizationContext _uiContext;

        private readonly IEventStore _eventStore;
        public IWindsorContainer IocContainer { get; private set; }

        //private readonly IConnectionFactory _connectionFactory;
        private readonly ConnectionFactory _connectionFactory;

        private IConnection _connection;
        private IModel _channel;

        private string _brokerName;
        private string _localIP;
        private string _queueName;
        private string _exchangeType;
        private string _SSL_switch;
        private string _sync;
        private int _timeout;

        public RabbitMQEventBus()
        {
            _uiContext = SynchronizationContext.Current;

            _eventStore = new InMemoryEventStore();
            IocContainer = new WindsorContainer();

            _connectionFactory = new ConnectionFactory()
            {
            };
        }

        /// <summary>
        /// 保证Init函数是被最先调用，否则会出错
        /// init 函数是为了获取参数
        /// </summary>
        /// <param name="borkerName"></param>
        /// <param name="localIp"></param>
        /// <param name="processName"></param>
        /// <param name="exchangeType"></param>
        /// <param name="userName"></param>
        /// <param name="hostName"></param>
        /// <param name="passWord"></param>
        /// <param name="ssl"></param>
        /// <param name="sync"></param>
        /// <param name="timeout">0:如果连接不上一直重连。 最小超时时间为30s，如果传入参数小于30，则为默认30s。超时会抛异常，需要用户自己获取异常</param>
        public void Init(string borkerName, string localIp, string processName, string exchangeType, string userName, string hostName, string passWord, string ssl = "0", string sync = "0", int timeout=0)
        {
            _brokerName = borkerName;
            _localIP = localIp;
            _queueName = localIp + "_" + processName + "_queue";
            _exchangeType = exchangeType;
            _SSL_switch = ssl;
            _sync = sync;
            _timeout = timeout;

            // 设置连接参数
            _connectionFactory.UserName = userName;
            _connectionFactory.HostName = hostName;
            _connectionFactory.Password = passWord;

            // 设置心跳检测时长
            _connectionFactory.RequestedHeartbeat = 20;

            // 设置SSL相关
            if (_SSL_switch == "0")
            {

            }
            else if (_SSL_switch == "1")
            {
                _connectionFactory.Ssl.Enabled = true;

                //  @"mkcert DESKTOP-HOC33DJ\DuoWei@DESKTOP-HOC33DJ (lnkyzhang)";
                _connectionFactory.Ssl.ServerName = "DESKTOP-HOC33DJ";
                _connectionFactory.Ssl.CertPath = @"./SslKey/client_key.p12";
                _connectionFactory.Ssl.CertPassphrase = "bunnies";
                _connectionFactory.Ssl.Version = SslProtocols.Tls12;
            }


            CreateConsumerChannel();
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }


        public void Register<TEventData>(IEventHandler eventHandler) where TEventData : IEventData
        {
            Register(typeof(TEventData), eventHandler.GetType());
        }

        public void Register<TEventData>(Action<TEventData> action) where TEventData : IEventData
        {
            //1.构造ActionEventHandler
            var actionHandler = new ActionEventHandler<TEventData>(action);

            //2.将ActionEventHandler的实例注入到Ioc容器
            IocContainer.Register(
                Component.For<IEventHandler<TEventData>>()
                    .UsingFactoryMethod(() => actionHandler));

            //注册到事件总线
            Register<TEventData>(actionHandler);
        }

        public void Register(Type eventType, Type handler)
        {
            //注册IEventHandler<T>到IOC容器
            var handlerInterface = handler.GetInterface("IEventHandler`1");
            if (!IocContainer.Kernel.HasComponent(handlerInterface))
            {
                IocContainer.Register(
                    Component.For(handlerInterface, handler));
            }
            if (!_eventStore.HasRegisterForEvent(eventType))
            {

                if (_exchangeType == "topic")
                {
                    _channel.QueueBind(queue: _queueName, exchange: _brokerName, routingKey: _localIP + ".#");
                }

                _channel.QueueBind(queue: _queueName, exchange: _brokerName, routingKey: eventType.Name);


            }
            _eventStore.AddRegister(eventType, handler);
        }

        public void RegisterAllEventHandlerFromAssembly(Assembly assembly)
        {
            //1.将IEventHandler注册到Ioc容器
            IocContainer.Register(Classes.FromAssembly(assembly)
                .BasedOn(typeof(IEventHandler<>))
                .WithService.Base());

            //2.从IOC容器中获取注册的所有IEventHandler
            var handlers = IocContainer.Kernel.GetAssignableHandlers(typeof(IEventHandler));
            foreach (var handler in handlers)
            {
                //循环遍历所有的IEventHandler<T>
                var interfaces = handler.ComponentModel.Implementation.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    if (!typeof(IEventHandler).IsAssignableFrom(@interface))
                    {
                        continue;
                    }

                    //获取泛型参数类型(eventDate子类)
                    var genericArgs = @interface.GetGenericArguments();
                    if (genericArgs.Length == 1)
                    {
                        //注册到事件源与事件处理的映射字典中
                        Register(genericArgs[0], handler.ComponentModel.Implementation);
                    }
                }
            }
        }

        public void UnRegister<TEventData>(Type handlerType) where TEventData : IEventData
        {
            _eventStore.RemoveRegister(typeof(TEventData), handlerType);
        }

        public void UnRegisterAll<TEventData>() where TEventData : IEventData
        {
            //获取所有映射的EventHandler
            List<Type> handlerTypes = _eventStore.GetHandlersForEvent(typeof(TEventData)).ToList();
            foreach (var handlerType in handlerTypes)
            {
                _eventStore.RemoveRegister(typeof(TEventData), handlerType);
            }
        }

        public void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            //using (var connection = _connectionFactory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
            //channel.ExchangeDeclare(exchange: _brokerName, type: _exchangeType);

            var message = JsonConvert.SerializeObject(eventData);
            var body = Encoding.UTF8.GetBytes(message);

            // todo 消息不可达处理
            //IBasicProperties props = channel.CreateBasicProperties();
            //props.DeliveryMode = 2; //1:非持久化 2:持续久化 （即：当值为2的时候，我们一个消息发送到服务器上之后，如果消息还没有被消费者消费，服务器重启了之后，这条消息依然存在）
            //props.Persistent = true;
            //props.ContentEncoding = "UTF-8";
            
            //EventHandler<BasicReturnEventArgs> evreturn = new EventHandler<BasicReturnEventArgs>((o, basic) =>
            //{
            //    Console.WriteLine(basic.ReplyCode); //消息失败的code
            //    Console.WriteLine(basic.ReplyText); ////描述返回原因的文本
            //    Console.WriteLine(Encoding.UTF8.GetString(basic.Body)); //失败消息的内容

            //    //在这里我们可能要对这条不可达消息做处理，比如是否重发这条不可达的消息呀，或者这条消息发送到其他的路由中呀，等等
            //    System.IO.File.AppendAllText("d:/return.txt", "调用了Return;ReplyCode:" + basic.ReplyCode + ";ReplyText:" + basic.ReplyText + ";Body:" + Encoding.UTF8.GetString(basic.Body));
            //});
            //channel.BasicReturn += evreturn;


            _channel.BasicPublish(
                exchange: _brokerName,                  // 交换器名称
                routingKey: eventData.GetType().Name,   // 路由键
                basicProperties: null,                  // 参数
                body: body);                            // 消息体，payload真正需要发送的消息

            //    }
            //}
        }

        public void Trigger<TEventData>(string ip, TEventData eventData) where TEventData : IEventData
        {

            var message = JsonConvert.SerializeObject(eventData);
            var body = Encoding.UTF8.GetBytes(message);

            // todo 消息不可达处理
            //IBasicProperties props = channel.CreateBasicProperties();
            //props.DeliveryMode = 2; //1:非持久化 2:持续久化 （即：当值为2的时候，我们一个消息发送到服务器上之后，如果消息还没有被消费者消费，服务器重启了之后，这条消息依然存在）
            //props.Persistent = true;
            //props.ContentEncoding = "UTF-8";

            //EventHandler<BasicReturnEventArgs> evreturn = new EventHandler<BasicReturnEventArgs>((o, basic) =>
            //{
            //    Console.WriteLine(basic.ReplyCode); //消息失败的code
            //    Console.WriteLine(basic.ReplyText); ////描述返回原因的文本
            //    Console.WriteLine(Encoding.UTF8.GetString(basic.Body)); //失败消息的内容

            //    //在这里我们可能要对这条不可达消息做处理，比如是否重发这条不可达的消息呀，或者这条消息发送到其他的路由中呀，等等
            //    System.IO.File.AppendAllText("d:/return.txt", "调用了Return;ReplyCode:" + basic.ReplyCode + ";ReplyText:" + basic.ReplyText + ";Body:" + Encoding.UTF8.GetString(basic.Body));
            //});
            //channel.BasicReturn += evreturn;


            _channel.BasicPublish(exchange: _brokerName,
                routingKey: ip + '.' + eventData.GetType().Name,
                basicProperties: null,
                body: body);

        }

        public void Trigger<TEventData>(Type eventHandlerType, TEventData eventData) where TEventData : IEventData
        {
            var message = JsonConvert.SerializeObject(eventData);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: _brokerName,
                routingKey: eventData.GetType().Name,
                basicProperties: null,
                body: body);
        }

        public Task TriggerAsync<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            return Task.Run(() => Trigger<TEventData>(eventData));
        }

        public Task TriggerAsycn<TEventData>(Type eventHandlerType, TEventData eventData) where TEventData : IEventData
        {
            return Task.Run(() => Trigger(eventHandlerType, eventData));
        }

        public void CreateConsumerChannel()
        {
            _connection = null;

            int remainConnectCount = -1;

            if (_timeout != 0)
            {
                remainConnectCount = _timeout * 1000 / _connectionFactory.RequestedConnectionTimeout;
            }

            while (_connection == null)
            {
                Thread.Sleep(1000);
                
                try
                {
                    _connection = _connectionFactory.CreateConnection();
                }
                catch (Exception e)
                {
                    if (remainConnectCount == 0)
                    {
                        throw;
                    }
                    else if (remainConnectCount != -1)
                    {
                        remainConnectCount -= 1;
                    }
                }
            }

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: _brokerName, type: _exchangeType);

            // todo 打印出的信息，可以删掉
            Console.WriteLine("Local port : {0}", _connection.LocalPort);
            Console.WriteLine("remote port : {0}", _connection.RemotePort);
            Console.WriteLine("end point : {0}", _connection.Endpoint);

            // todo 只有设置了autoDelete为false ，才能在autoRecover中回复binding成功
            // 需要断开连接是手动删除
            _channel.QueueDeclare(_queueName, exclusive: false, autoDelete: true);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {

                // eventName 是最后一个"."之后的字符.eventype
                string[] arrayTmp = ea.RoutingKey.Split('.');
                var eventName = arrayTmp[arrayTmp.Length - 1];

                //var eventName = ea.RoutingKey;
                var message = Encoding.UTF8.GetString(ea.Body);
                Console.WriteLine($"message {message}");
                if (_sync == "0")
                {
                    HandleEvent(eventName, message);
                }
                else
                {
                    HandlerEventArgs args = new HandlerEventArgs() { EventName = eventName, Message = message };

                    _uiContext.Post(HandlerEventCallback, args);
                }

                //手动应答
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            // autoAck: true 自动确认，消息到达了consumer就确认消息。
            // 可能会导致在消息回调函数执行过程中产生异常导致消息未处理成功，但是已经确认了
            // autoAck: false 手动确认
            _channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);

        }

        /// <summary>
        /// 同步上下文
        /// </summary>
        public class HandlerEventArgs
        {
            public string EventName { get; set; }
            public string Message { get; set; }
        }

        private void HandlerEventCallback(object state)
        {
            string eventName = ((HandlerEventArgs)state).EventName;
            string message = ((HandlerEventArgs)state).Message;

            HandleEvent(eventName, message);
        }

        private void HandleEvent(string eventName, string message)
        {
            var eventType = _eventStore.GetEventTypeByName(eventName);

            if (eventType != null)
            {
                if (_eventStore.HasRegisterForEvent(eventType))
                {
                    var eventData = JsonConvert.DeserializeObject(message, eventType) as IEventData;
                    var handlerTypes = _eventStore.GetHandlersForEvent(eventType);

                    foreach (var handlerType in handlerTypes)
                    {
                        //获取类型实现的泛型接口
                        var handlerInterface = handlerType.GetInterface("IEventHandler`1");

                        var eventHandlers = IocContainer.ResolveAll(handlerInterface);
                        //循环遍历，仅当解析的实例类型与映射字典中事件处理类型一致时，才触发事件
                        foreach (var eventHandler in eventHandlers)
                        {
                            if (eventHandler.GetType() == handlerType)
                            {
                                var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);


                                //OneThreadSynchronizationContext.GetSingleton().Post(new SendOrPostCallback((ss) =>
                                //{
                                //    concreteType.GetMethod("HandleEvent").Invoke(eventHandler, new object[] { eventData });
                                //}), null);

                                concreteType.GetMethod("HandleEvent").Invoke(eventHandler, new object[] { eventData });
                            }
                        }
                    }
                }
            }
        }

        private void HandleEvent(string eventName, IDictionary<string, object> message)
        {
            var eventType = _eventStore.GetEventTypeByName(eventName);

            if (eventType != null)
            {
                if (_eventStore.HasRegisterForEvent(eventType))
                {
                    //var eventData = JsonConvert.DeserializeObject(message, eventType) as IEventData;
                    var handlerTypes = _eventStore.GetHandlersForEvent(eventType);

                    foreach (var handlerType in handlerTypes)
                    {
                        //获取类型实现的泛型接口
                        var handlerInterface = handlerType.GetInterface("IEventHandler`1");

                        var eventHandlers = IocContainer.ResolveAll(handlerInterface);
                        //循环遍历，仅当解析的实例类型与映射字典中事件处理类型一致时，才触发事件
                        foreach (var eventHandler in eventHandlers)
                        {
                            if (eventHandler.GetType() == handlerType)
                            {
                                var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);


                                //OneThreadSynchronizationContext.GetSingleton().Post(new SendOrPostCallback((ss) =>
                                //{
                                //    concreteType.GetMethod("HandleEvent").Invoke(eventHandler, new object[] { eventData });
                                //}), null);

                                concreteType.GetMethod("HandleEvent").Invoke(eventHandler, new object[] { message });
                            }
                        }
                    }


                }
            }
        }

        /// <summary>
        /// 新创建一个channel，添加 rabbitmq-event-exchange 插件的消息
        /// 仅订阅了connection的连接和断开消息
        /// </summary>
        /// <returns></returns>
        public void CreatePluginEventConsumerChannel()
        {

            //var connection = _connectionFactory.CreateConnection();
            //var channel = connection.CreateModel();

            string eventExchangeName = "amq.rabbitmq.event";
            string eventQueueName = "plugin_event";

            _channel.QueueDeclare(eventQueueName, exclusive: false, autoDelete: true);

            _channel.QueueBind(queue: eventQueueName, exchange: eventExchangeName, routingKey: "#");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                //var body = ea.Body;
                //var message = Encoding.UTF8.GetString(body);

                S_PluginEventData SendEventData = new S_PluginEventData();
                SendEventData.routingKeys = ea.RoutingKey;
                SendEventData.headers = ea.BasicProperties.Headers;

                void DealWithSystemObjectList(object objectList)
                {
                    if (objectList.GetType() == typeof(List<System.Object>))
                    {

                        List<System.Object> tmp = (List<System.Object>)objectList;
                        for (int i = 0; i < tmp.Count; i++)
                        {
                            DealWithSystemObjectList(tmp[i]);

                            tmp[i] = Encoding.Default.GetString((System.Byte[])tmp[i]);
                            //Console.WriteLine("         ||value：{0}", temp);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                List<string> indexList = new List<string>();
                indexList.AddRange(SendEventData.headers.Keys);

                foreach (string index in indexList)
                {
                    DealWithSystemObjectList(SendEventData.headers[index]);

                    if (SendEventData.headers[index].GetType() == typeof(System.Byte[]))
                    {
                        SendEventData.headers[index] = Encoding.Default.GetString((System.Byte[])SendEventData.headers[index]);
                    }
                    else
                    {
                    }
                }

                var message = JsonConvert.SerializeObject(SendEventData);
                var body = Encoding.UTF8.GetBytes(message);

                _channel.BasicPublish(exchange: _brokerName,
                    routingKey: SendEventData.GetType().Name,
                    basicProperties: null,
                    body: body);
                // 转发
                //RabbitMQEventBus.GetSingleton().Trigger<S_PluginEventData>(SendEventData);//直接通过事件总线触发

                //手动应答
                //channel.BasicAck(ea.DeliveryTag, false);

                //Console.WriteLine("========================== [x] Received ===================='{0}':'{1}'",
                //    routingKey, message);




            };
            // autoAck: true 自动确认，消息到达了consumer就确认消息。
            // 可能会导致在消息回调函数执行过程中产生异常导致消息未处理成功，但是已经确认了
            // autoAck: false 手动确认
            _channel.BasicConsume(queue: eventQueueName, autoAck: true, consumer: consumer);

        }
    }
}