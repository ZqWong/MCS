using System;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace ServerFrame
{
    public class Server
    {
        #region 构造方法中创建对象、赋值

        /// <summary>
        /// 服务器Socket
        /// </summary>
        Socket _ServerSocket;

        /// <summary>
        /// 最大客户端连接数
        /// </summary>
        int _MaxClientConnectionNum;

        #endregion

        #region Start方法中创建对象

        /// <summary>
        /// 信号量：限制同时访问某一资源或资源池的线程数（using System.Threading;）
        /// </summary>
        Semaphore _UserNumSemaphore;

        /// <summary>
        /// 客户端连接对象池
        /// </summary>
        UserTokenPool _UserTokenPool;

        #endregion

        #region 应用层赋值
        /// <summary>
        /// 长度编码委托
        /// </summary>
        public LengthEncodeDelegate _LengthEncodeDelegate;

        /// <summary>
        /// 长度解码委托
        /// </summary>
        public LengthDecodeDelegate _LengthDecodeDelegate;

        /// <summary>
        /// 消息编码委托
        /// </summary>
        public MessageEncodeDelegate _MessageEncodeDelegate;

        /// <summary>
        /// 消息解码委托
        /// </summary>
        public MessageDecodeDelegate _MessageDecodeDelegate;

        /// <summary>
        /// 消息处理中心，由外部应用传入
        /// </summary>
        public AbsHandleCenter _HandlerCenter;

        #endregion

        /// <summary>
        /// 构造方法（服务器初始化）
        /// </summary>
        /// <param name="maxClientConnectionNum">最大客户端连接数</param>
        public Server(int maxClientConnectionNum)
        {
            // 初始化服务器Socket对象 | AddressFamily.InterNetwork IP4 | SocketType.Stream 流传输
            _ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 设置最大客户端连接数
            _MaxClientConnectionNum = maxClientConnectionNum;

        }

        /// <summary>
        /// 服务器启动
        /// </summary>
        /// <param name="port"></param>
        public void Start(int port)
        {
            // 初始化客户端连接对象池
            _UserTokenPool = new UserTokenPool(_MaxClientConnectionNum);

            // 初始化信号量
            _UserNumSemaphore = new Semaphore(_MaxClientConnectionNum, _MaxClientConnectionNum); // 参数意义：initialCount:可以同时满足的信号量的初始请求数。maximumCount:可以同时满足的信号量的最大请求数。

            /* Semaphore是一个线程同步的辅助类，可以维护当前访问自身的线程个数，并提供了同步机制。使用Semaphore可以控制同时访问资源的线程个数，例如，实现一个文件允许的并发访问数。
             * 信号量的概念：
             * 以一个停车场是运作为例。为了简单起见，假设停车场只有三个车位，一开始三个车位都是空的。
             * 这时如果同时来了五辆车，看门人允许其中三辆不受阻碍的进入，然后放下车拦，剩下的车则必须在入口等待，此后来的车也都不得不在入口处等待。
             * 这时，有一辆车离开停车场，看门人得知后，打开车拦，放入一辆，如果又离开两辆，则又可以放入两辆，如此往复。
             * 在这个停车场系统中，车位是公共资源，每辆车好比一个线程，看门人起的就是信号量的作用。
             * 
             * 更进一步，信号量的特性如下：信号量是一个非负整数（车位数），所有通过它的线程（车辆）都会将该整数减一（通过它当然是为了使用资源），
             * 当该整数值为零时，所有试图通过它的线程都将处于等待状态。
             * 在信号量上我们定义两种操作： Wait（等待） 和 Release（释放）。
             * 当一个线程调用Wait（等待）操作时，它要么通过然后将信号量减一，要么一直等下去，直到信号量大于一或超时。
             * Release（释放）实际上是在信号量上执行加操作，对应于车辆离开停车场，该操作之所以叫做“释放”是因为加操作实际上是释放了由信号量守护的资源。
             */

            // 根据最大客户端连接数，预先创建出所有的客户端连接对象，并存放到客户端连接池中（备注参考：ClientConnectionTokenPool.cs最下面的注释部分）
            for (int i = 0; i < _MaxClientConnectionNum; i++)
            {
                UserToken token = new UserToken();

                // 在UserToken的构造方法中已经完成了对token.ReceiveSAEA、token.SendSAEA异步操作对象的创建
                // 下面两个方法时创建这两个异步操作的完成事件

                // 注册【接收异步操作完成事件】
                token.ReceiveSAEA.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                // 注册【发送异步操作完成事件】
                token.SendSAEA.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);

                // 长度编码解码器
                token._LengthEncodeDelegate = _LengthEncodeDelegate;
                token._LengthDecodeDelegate = _LengthDecodeDelegate;

                // 消息编码解码器
                token._MessageEncodeDelegate = _MessageEncodeDelegate;
                token._MessageDecodeDelegate = _MessageDecodeDelegate;

                // 处理发送
                token._ProcessSendDelegate = ProcessSend;

                //// 处理接收
                //token._ProcessReceiveDelegate = ProcessReceive;

                // 处理客户端关闭
                token._ProcessClientCloseDelegate = ProcessClientClose;

                // 消息处理中心
                token._Center = _HandlerCenter;

                _UserTokenPool.push(token);
            }

            // 监听当前服务器网卡所有可用IP地址的Port端口，绑定IP端口
            // 外网IP、内网IP 192.168.X.X、本机IP 127.0.0.1
            _ServerSocket.Bind(new IPEndPoint(IPAddress.Any, port)); // 监听所有IP地址

            // 置于侦听状态（使得一个进程可以接受其它进程的请求，从而成为一个服务器进程）
            _ServerSocket.Listen(10); // 参数解释：挂起连接队列的最大长度

            /* 进程在处理一个连接请求的时候，可能还存在其它的连接请求。因为TCP连接是一个过程，所以可能存在一种半连接的状态，有时由于同时尝试连接的用户过多，
             * 使得服务器进程无法快速地完成连接请求。如果这个情况出现了，服务器进程希望内核如何处理呢？
             * 内核会在自己的进程空间里维护一个队列以跟踪这些完成的连接但服务器进程还没有接手处理或正在进行的连接，这样的一个队列内核不可能让其任意大，
             * 所以必须有一个大小的上限。这个backlog告诉内核使用这个数值作为上限。
             * 毫无疑问，服务器进程不能随便指定一个数值，内核有一个许可的范围。
             * 这个范围是实现相关的。很难有某种统一，一般这个值会小30以内。
             */

            // 开始监听客户端连接
            StartAccept(null);
        }

        /// <summary>
        /// 开始监听客户端连接
        /// </summary>
        /// <param name="e"></param>
        public void StartAccept(SocketAsyncEventArgs e)
        {
            // 如果e为空，说明调用新的监听客户端连接的异步操作对象，否则的话，移除已接受的客户端Socket对象
            if (e == null)
            {
                // 新创建一个异步操作对象，用于监听客户端连接
                e = new SocketAsyncEventArgs();

                // 用于异步操作完成的事件
                e.Completed += new EventHandler<SocketAsyncEventArgs>(Accept_Completed);
            }
            else
            {
                // 获取或设置要使用的套接字或创建用于接受与异步套接字方法的连接的套接字
                e.AcceptSocket = null;
            }

            // 信号量-1
            _UserNumSemaphore.WaitOne();

            // 如果信号量减到0了，就不会再往下执行了，达到一个阻塞的效果，只有当有信号量释放以后，即信号量大于0了，才能继续往下执行

            // 开始一个异步操作来接受一个传入的连接尝试
            bool result = _ServerSocket.AcceptAsync(e);

            /*
             * 返回结果:
             *          如果 I/O 操作挂起，将返回 true。操作完成时，将引发 e 参数的 System.Net.Sockets.SocketAsyncEventArgs.Completed事件。
             *          如果 I/O 操作同步完成，将返回 false。将不会引发 e 参数的 System.Net.Sockets.SocketAsyncEventArgs.Completed事件，
             *          并且可能在方法调用返回后立即检查作为参数传递的 e 对象以检索操作的结果。
             */

            // 判断异步事件是否挂起，没挂起说明立刻完成，直接处理事件，否则会在处理完成后触发Accept_Completed事件
            if (!result)
            {
                ProcessAccept(e);
            }

        }

        /// <summary>
        /// 用于监听客户端连接的异步操作完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Accept_Completed(object sender, SocketAsyncEventArgs e)
        {
            ProcessAccept(e);
        }

        /// <summary>
        /// 处理客户端连接
        /// </summary>
        /// <param name="e"></param>
        public void ProcessAccept(SocketAsyncEventArgs e)
        {
            // 从客户端连接对象池中取出连接对象，供新用户使用
            UserToken token = _UserTokenPool.pop();

            token.ClientSocket = e.AcceptSocket;

            // 通知应用层有客户端连接
            _HandlerCenter.ClientConnect(token);

            // 开启监听消息到达
            StartReceive(token);

            /* 无限递归是指在服务器刚启动起来的时候，就创建一个异步的连接监听事件，只不过e.AcceptSocket = null，
             * 当第一个客户端连接进来的时候，就会触发之前创建的监听事件（Accept_Completed），哪个客户端触发了这个事件，即连接到服务器了，连接事件e.AcceptSocket就是哪个客户端的Socket，
             * 然后创建接收监听事件，进行消息的监听。
             * 函数最后重新调用一遍StartAccept(e)，StartAccept方法就会将e.AcceptSocket设为null，包括信号量再次-1，再次调用异步监听连接的操作（_ServerSocket.AcceptAsync(e)），继续进行监听
             * 就是说在客户端进来之前，服务器对客户端连接的监听准备就已经就绪了，一旦客户端有连接服务器就会立马知道，然后将监视到的对象清空，准备监视一下连接进来的对象。
             * 相当于三步操作，准备接收客户端连接-接收到了客户端连接-准备接收下次客户端连接
             * 用于监控客户端连接的异步事件，只需要创建一次，用完只需要设置e.AcceptSocket = null就可，那么这个事件就可再接着用于其他的异步操作事件，调用异步监视客户端连接的方法是需要的时候就调用。
             */

            // 清空监听到的客户端对象，重新监视下次其他客户端的连接
            StartAccept(e);
        }

        /// <summary>
        /// 开始接收客户端消息
        /// </summary>
        /// <param name="token"></param>
        public void StartReceive(UserToken token)
        {
            // 开始一个异步请求以便从连接的Socket对象中接收数据
            bool result = token.ClientSocket.ReceiveAsync(token.ReceiveSAEA);

            // 未挂起，直接执行括号内语句
            if (!result)
            {
                ProcessReceive(token.ReceiveSAEA);
            }
            else
            {
                // 挂起，等待结束之后，自动调用完成事件

            }

        }

        /// <summary>
        /// 用于接受客户端网络数据的异步操作完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            UserToken userToken = e.UserToken as UserToken;

            lock (userToken)
            {
                // 判断本次Socket异步操作类型
                if (e.LastOperation == SocketAsyncOperation.Receive)
                {
                    ProcessReceive(e);
                }
                else
                {
                    ProcessSend(e);
                }
            }
        }

        /// <summary>
        /// 处理（消息）接收
        /// </summary>
        /// <param name="e"></param>
        public void ProcessReceive(SocketAsyncEventArgs e)
        {
            UserToken token = e.UserToken as UserToken;

            // 判断网络消息接收是否成功
            // token.ReceiveSAEA.BytesTransferred : 获取在套接字操作中传输的字节数
            // token.ReceiveSAEA.SocketError : SocketError Socket类的错误代码
            if (token.ReceiveSAEA.BytesTransferred > 0 && token.ReceiveSAEA.SocketError == SocketError.Success)
            {
                byte[] buffer = new byte[token.ReceiveSAEA.BytesTransferred];

                // 原数组，偏移量，目标数组，偏移量，指定数目
                Buffer.BlockCopy(token.ReceiveSAEA.Buffer, 0, buffer, 0, token.ReceiveSAEA.BytesTransferred);

                // 处理接收到的消息
                token.Receive(buffer);

                // 继续递归
                StartReceive(token);
            }
            // 接收失败
            else
            {
                // 读取报错
                if (token.ReceiveSAEA.SocketError != SocketError.Success)
                {
                    ProcessClientClose(token, token.ReceiveSAEA.SocketError.ToString());
                }
                // 接收到的数据为0 （在网络传输的过程中有这么一个机制，当客户端向服务器发送数据，但是长度为0的情况，这说明客户端主动断开连接）
                else
                {
                    ProcessClientClose(token, "客户端主动断开连接。");
                }
            }
        }

        /// <summary>
        /// 处理（消息）发送
        /// </summary>
        /// <param name="e"></param>
        public void ProcessSend(SocketAsyncEventArgs e)
        {
            UserToken token = e.UserToken as UserToken;

            if (e.SocketError != SocketError.Success)
            {
                ProcessClientClose(token, e.SocketError.ToString());
            }
            else
            {
                // 消息发送成功，回调成功
                token.SendOK();
            }
        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        /// <param name="userToken">断开连接的用户对象</param>
        /// <param name="error">断开连接的错误编码</param>
        public void ProcessClientClose(UserToken token, string error)
        {
            if (token.ClientSocket != null)
            {
                lock (token) // 加锁  括号内容执行完解锁，防止token在清理过程中被调用
                {
                    // 通知应用层面 客户端关闭
                    _HandlerCenter.ClientClose(token, error);

                    // 释放内部对象
                    token.Close();

                    _UserTokenPool.push(token);

                    // 信号量 + 1 
                    _UserNumSemaphore.Release();
                }

                /* 当我们使用线程的时候，效率最高的方式当然是异步，即各个线程同时运行，其间不相互依赖和等待。
                 * 但当不同的线程都需要访问某个资源的时候，就需要同步机制了，也就是说当对同一个资源进行读写的时候，
                 * 我们要使该资源在同一时刻只能被一个线程操作，以确保每个操作都是有效即时的，也即保证其操作的原子性。
                 * lock是C#中最常用的同步方式，格式为lock(objectA){codeB} 。
                 * 
                 * lock(objectA){codeB} 看似简单，实际上有三个意思，这对于适当地使用它至关重要：
                 * 1. objectA被lock了吗？没有则由我来lock，否则一直等待，直至objectA被释放。
                 * 2. lock以后在执行codeB的期间其他线程不能调用codeB，也不能使用objectA。
                 * 3. 执行完codeB之后释放objectA，并且codeB可以被其他线程访问。
                 * 
                 */
            }
        }



    }
}