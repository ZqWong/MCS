using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQEvent
{
    public class RabbitMQManager : LockedSingletonClass<RabbitMQManager>
    {
        /// <summary>
        /// 这个中间件需要外部传过来
        /// </summary>
        public static SynchronizationContext UIContext;

        //private readonly IEventStore m_eventCacheInMemory;
        private readonly LocalEventCacheController m_eventCacheInMemory;

        public IWindsorContainer IocContainer { get; private set; }

        //private readonly IConnectionFactory _connectionFactory;
        /// <summary>
        /// RabbitMQ 连接对象实例
        /// </summary>
        private readonly ConnectionFactory m_connectionFactory;

        /// <summary>
        /// RabbitMQ 服务器连接对象
        /// </summary>
        private IConnection m_connection;
        /// <summary>
        /// RabbitMQ 连接通道
        /// </summary>
        private IModel _channel;

        #region RabbitMQ 初始化参数
        /// <summary>
        /// 中间件名
        /// </summary>
        private string m_brokerName;
        /// <summary>
        /// IP
        /// </summary>
        private string m_localIP;
        /// <summary>
        /// 队列名
        /// </summary>
        private string m_queueName;
        /// <summary>
        /// 执行模式 topic
        /// </summary>
        private string m_exchangeType;
        /// <summary>
        /// 是否使用SSL
        /// </summary>
        private bool m_userSSL;
        /// <summary>
        /// 是否需要上下文同步
        /// </summary>
        private bool m_sync;
        /// <summary>
        /// 超时
        /// </summary>
        private int m_timeout;
        #endregion

        #region RabbitMQ Initialize

        public RabbitMQManager()
        {
            UIContext = SynchronizationContext.Current;
            // 初始化事件缓存
            m_eventCacheInMemory = new LocalEventCacheController();
            // 初始化Ioc容器 （Castle Windsor）
            IocContainer = new WindsorContainer();
            // 初始化RabbitMQ 连接对象
            m_connectionFactory = new ConnectionFactory(){};
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
        /// <param name="ssl">是否启用SSL</param>
        /// <param name="sync">是否同步（通过SynchronizationContext.post的方式处理）</param>
        /// <param name="timeout">0:如果连接不上一直重连。 最小超时时间为30s，如果传入参数小于30，则为默认30s。超时会抛异常，需要用户自己获取异常</param>
        public void Initialize(string borkerName, string localIp, string processName, string exchangeType, string userName, string hostName, string passWord, bool ssl = false, bool sync = false, int timeout = 0)
        {
            m_brokerName = borkerName;
            m_localIP = localIp;
            m_queueName = localIp + "_" + processName + "_queue";
            m_exchangeType = exchangeType;
            m_userSSL = ssl;
            m_sync = sync;
            m_timeout = timeout;
            
            CreateConsumerChannel(userName, hostName, passWord);
        }


        #region 消费者通道

        /// <summary>
        /// 消费者消息接受成功回调参数
        /// </summary>
        public class HandlerEventArgs
        {
            public string EventName { get; set; }
            public string Message { get; set; }
        }

        /// <summary>
        /// 消费者消息接受成功回调处理
        /// </summary>
        /// <param name="state"></param>
        private void HandlerEventCallback(object state)
        {
            string eventName = ((HandlerEventArgs)state).EventName;
            string message = ((HandlerEventArgs)state).Message;

            HandleEvent(eventName, message);
        }

        /// <summary>
        /// 消费者
        /// 创建一个通往 RabbitMQ Service 的 Connection 连接
        /// </summary>
        private void CreateConsumerChannel(string userName, string hostName, string passWord)
        {
            /* 
             * 创建到代理的连接
             * 要连接到RabbitMQ，需要实例化一个ConnectionFactory并将其配置为使用所需的主机名，虚拟主机和凭据。 然后使用ConnectionFactory.CreateConnection（）
             */
            // 设置连接参数
            m_connectionFactory.UserName = userName;
            m_connectionFactory.HostName = hostName;
            m_connectionFactory.Password = passWord;
            m_connectionFactory.Port = AmqpTcpEndpoint.UseDefaultPort;
            m_connectionFactory.VirtualHost = "/";
            // 设置心跳检测时长
            m_connectionFactory.RequestedHeartbeat = 60;

            // 设置SSL相关

            if (m_userSSL)
            {
                m_connectionFactory.Ssl.Enabled = true;
                //  @"mkcert DESKTOP-HOC33DJ\DuoWei@DESKTOP-HOC33DJ (lnkyzhang)";
                m_connectionFactory.Ssl.ServerName = "DESKTOP-HOC33DJ";
                m_connectionFactory.Ssl.CertPath = @"./SslKey/client_key.p12";
                m_connectionFactory.Ssl.CertPassphrase = "bunnies";
                m_connectionFactory.Ssl.Version = SslProtocols.Tls12;
            }

            m_connection = null;


            // 设置超时重连
            int remainConnectCount = -1;

            if (m_timeout != 0)
            {
                remainConnectCount = m_timeout * 1000 / m_connectionFactory.RequestedConnectionTimeout;
            }

            // 连接 RabbitMQ 服务器
            while (m_connection == null)
            {
                Thread.Sleep(1000);

                try
                {
                    m_connection = m_connectionFactory.CreateConnection();
                }
                catch (Exception ex)
                {
                    Debug.Error($"{this} RabbitMQ Magaer CreateConsumerChannel Failed : {ex}");
                    if (remainConnectCount == 0)
                    {                     
                    }
                    else if (remainConnectCount != -1)
                    {
                        remainConnectCount -= 1;
                    }

                    throw ex;
                }
            }

            // 通过服务器对象创建一个连接通道, 通道Channel用于接收和发送消息
            _channel = m_connection.CreateModel();

            /* 
             * 使用消息交换机和队列 
             * 客户端应用程序将与消息交换机和消息队列（AMQP 0-9-1的高级构建块）配合工作。 【消息交换机】和【消息队列】在使用之前必须先声明他们。 声明任何类型的对象只是确保其中一个名称存在，如有必要，创建它。
             */
            //m_brokerName: event_bus   m_exchangeType: topic
            _channel.ExchangeDeclare(exchange: m_brokerName, type: m_exchangeType);

            // todo 打印出的信息，可以删掉
            Console.WriteLine("Local port : {0}", m_connection.LocalPort);
            Console.WriteLine("remote port : {0}", m_connection.RemotePort);
            Console.WriteLine("end point : {0}", m_connection.Endpoint);

            // 声名
            // todo 只有设置了autoDelete为false ，才能在autoRecover中回复binding成功
            // 需要断开连接是手动删除
            // m_queueName: localIp + "_" + processName + "_queue" 
            // exclusive ： 是否排他的，true，排他。如果一个队列声明为排他队列，该队列公对首次声明它的连接可见，并在连接断开时自动删除.
            // autoDelete ：是否自动删除,true，自动删除，自动删除的前提：至少有一个消息者连接到这个队列，之后所有与这个队列连接的消息都断开时，才会自动删除.
            _channel.QueueDeclare(m_queueName, exclusive: false, autoDelete: true);

            // 创建 订阅式 消费者 （使用这种方式消息会全部打入当前消费者中，不管是否启用确认机制。）
            var consumer = new EventingBasicConsumer(_channel);

            // 接受处理
            consumer.Received += (model, basicDeliverEventArgs) =>
            {
                // 接收到的消息字段处理
                // eventName 是最后一个"."之后的字符.eventype
                string[] arrayTmp = basicDeliverEventArgs.RoutingKey.Split('.');
                string eventName = arrayTmp[arrayTmp.Length - 1];

                // 消息体解析
                //var eventName = ea.RoutingKey;
                byte[] body = basicDeliverEventArgs.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                Debug.Info($"{this} RabbitMQManager consumer Received - \neventName: {eventName} \nmessage: {message}");

                if (m_sync)
                {
                    HandleEvent(eventName, message);
                }
                else
                {
                    // 同步上下文
                    HandlerEventArgs args = new HandlerEventArgs() { EventName = eventName, Message = message };
                    UIContext.Post(HandlerEventCallback, args);
                }

                //手动应答(用IModel.BasicAck来确认您已成功接收并处理该消息)
                _channel.BasicAck(basicDeliverEventArgs.DeliveryTag, false);
            };

            // autoAck: true 自动确认，消息到达了consumer就确认消息。
            // 可能会导致在消息回调函数执行过程中产生异常导致消息未处理成功，但是已经确认了
            // autoAck: false 手动确认
            _channel.BasicConsume(queue: m_queueName, autoAck: false, consumer: consumer);
        }

        #endregion


        #region 单独的rabbitmq-event-exchange 插件的消息通道

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

                _channel.BasicPublish(exchange: m_brokerName,
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

        #endregion



        #region IEventHandler<T> 事件处理

        /// <summary>
        /// 注册当前程序集中实现的所有IEventHandler<T>
        /// </summary>
        /// <param name="assembly"></param>
        public void RegisterAllEventHandlerFromAssembly(Assembly assembly)
        {
            //1.将IEventHandler注册到Ioc容器（详见 https://www.bookstack.cn/read/Windsor-doc-cn/docs-registering-components-by-conventions.md ）
            IocContainer.Register(Classes.FromAssembly(assembly).BasedOn(typeof(IEventHandler<>)).WithService.Base());

            //2.从IOC容器中获取注册的所有IEventHandler
            Castle.MicroKernel.IHandler[] handlers = IocContainer.Kernel.GetAssignableHandlers(typeof(IEventHandler));
            Debug.Info($"{this} RabbitMQManager RegisterAllEventHandlerFromAssembly Get Handlers Count: {handlers.Length}");
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

        #endregion

        /// <summary>
        /// RabbitMQ连接关闭
        /// </summary>
        public void Dispose()
        {
            _channel.Close();
            m_connection.Close();
        }
        #endregion


        #region Event Register Controls

        /// <summary>
        /// 注册到事件源与事件处理的映射字典中
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="handler"></param>
        public void Register(Type eventType, Type handler)
        {
            //注册IEventHandler<T>到IOC容器
            var handlerInterface = handler.GetInterface("IEventHandler`1");
            if (!IocContainer.Kernel.HasComponent(handlerInterface))
            {
                IocContainer.Register(Component.For(handlerInterface, handler));
            }
            if (!m_eventCacheInMemory.HasRegisterForEvent(eventType))
            {
                // 消息绑定
                if (m_exchangeType == "topic")
                {
                    _channel.QueueBind(queue: m_queueName, exchange: m_brokerName, routingKey: m_localIP + ".#");
                }
                _channel.QueueBind(queue: m_queueName, exchange: m_brokerName, routingKey: eventType.Name);
            }
            m_eventCacheInMemory.AddRegister(eventType, handler);
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandler"></param>
        public void Register<TEventData>(IEventHandler eventHandler) where TEventData : IEventData
        {
            Register(typeof(TEventData), eventHandler.GetType());
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        public void Register<T>(Action<T> action) where T : EventData
        {
            //1.构造ActionEventHandler
            var actionHandler = new ActionEventHandler<T>(action);

            //2.将ActionEventHandler的实例注入到Ioc容器
            IocContainer.Register(Component.For<IEventHandler<T>>().UsingFactoryMethod(() => actionHandler));

            //注册到事件总线
            Register<T>(actionHandler);
        }


        /// <summary>
        /// 事件解除注册
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="handlerType"></param>
        public void UnRegister<TEventData>(Type handlerType) where TEventData : IEventData
        {
            m_eventCacheInMemory.RemoveRegister(typeof(TEventData), handlerType);
        }

        /// <summary>
        /// 接触所有事件注册
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        public void UnRegisterAll<TEventData>() where TEventData : IEventData
        {
            //获取所有映射的EventHandler
            List<Type> handlerTypes = m_eventCacheInMemory.GetHandlersForEvent(typeof(TEventData)).ToList();
            foreach (var handlerType in handlerTypes)
            {
                m_eventCacheInMemory.RemoveRegister(typeof(TEventData), handlerType);
            }
        }

        #endregion

        #region 触发消息


        /// <summary>
        /// 向指定IP发送消息
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="ip"></param>
        /// <param name="eventData"></param>
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


            _channel.BasicPublish(
                exchange: m_brokerName,
                routingKey: ip + '.' + eventData.GetType().Name,
                basicProperties: null,
                body: body);

        }


        /// <summary>
        /// 异步出发
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public Task TriggerAsync<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            return Task.Run(() => Trigger<TEventData>(eventData));
        }

        /// <summary>
        /// 全局发送不带IP
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventData"></param>
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


            _channel.BasicPublish(exchange: m_brokerName,
                routingKey: eventData.GetType().Name,
                basicProperties: null,
                body: body);

            //    }
            //}
        }


        /// <summary>
        /// 异步触发
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandlerType"></param>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public Task TriggerAsycn<TEventData>(Type eventHandlerType, TEventData eventData) where TEventData : IEventData
        {
            return Task.Run(() => Trigger(eventHandlerType, eventData));
        }

        public void Trigger<TEventData>(Type eventHandlerType, TEventData eventData) where TEventData : IEventData
        {
            var message = JsonConvert.SerializeObject(eventData);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: m_brokerName,
                routingKey: eventData.GetType().Name,
                basicProperties: null,
                body: body);
        }


        #endregion

        #region Event execute

        /// <summary>
        /// 接收到的消息处理, 简单的阐述一下工作原理，就是RabbitMQ接收到消息后进行处理，因为初始化时已经做了所有的IEventHandler<T>类型缓存，
        /// 对 handlerType -> eventHandlers 进行遍历，找到对应的IEventHandler<>类，并执行其中的HandleEvent方法
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="message"></param>
        private void HandleEvent(string eventName, string message)
        {
            var eventType = m_eventCacheInMemory.GetEventTypeByName(eventName);

            if (eventType != null)
            {               
                if (m_eventCacheInMemory.HasRegisterForEvent(eventType))
                {
                    var eventData = JsonConvert.DeserializeObject(message, eventType) as IEventData;
                    var handlerTypes = m_eventCacheInMemory.GetHandlersForEvent(eventType);

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

        [Obsolete("使用 HandleEvent(string eventName, string message) 代替实现")]
        private void HandleEvent(string eventName, IDictionary<string, object> message)
        {
            var eventType = m_eventCacheInMemory.GetEventTypeByName(eventName);

            if (eventType != null)
            {
                if (m_eventCacheInMemory.HasRegisterForEvent(eventType))
                {
                    //var eventData = JsonConvert.DeserializeObject(message, eventType) as IEventData;
                    var handlerTypes = m_eventCacheInMemory.GetHandlersForEvent(eventType);

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

        #endregion
    }
}