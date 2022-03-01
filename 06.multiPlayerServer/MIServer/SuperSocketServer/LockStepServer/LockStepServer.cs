using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PacketCommon;

namespace MIServer
{
    public struct ClientInfo
    {
        public string mIp;
        public int mId;
        public int mPitch;
        public int mRotate;
        public int mRoll;
    };

    public class LockStepServer : AppServer<LockStepServerSession, ProtobufRequestInfo>
    {

        public LockStepServer() : base(new ProtobufReceiveFilterFactory())
        {
            //读取配置文件中配置的服务端和客户端参数
            ReadConfig();
        }

    protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted()
        {
            base.OnStarted();

            Program.AutoDeleteLog();

            mFrameTimer = new System.Threading.Timer(new System.Threading.TimerCallback(FrameCounterCallBack), null, 0, 1000);

        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }

        protected override void OnNewSessionConnected(LockStepServerSession session)
        {
            
            base.OnNewSessionConnected(session);
            Console.WriteLine(string.Format("Client connected! id:{0}", session.RemoteEndPoint));
        }

        void ReadConfig()
        {
            //读取配置文件
            string path = "config.xml";

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            XmlReader reader = XmlReader.Create(path, settings);

            reader.ReadToFollowing("server");
            int.TryParse(reader.GetAttribute("tcpPort"), out TCP_PORT);
            CONTROL_ID_LIST = Array.ConvertAll<string, int>(reader.GetAttribute("controlID").Split(','), s => int.Parse(s)).ToList();
            int.TryParse(reader.GetAttribute("minClientCounts"), out mIMinClientCounts);
            int.TryParse(reader.GetAttribute("limitGpuUsage"), out limitGpuUsage);
            int.TryParse(reader.GetAttribute("limitGpuSleepTime"), out limitGpuSleepTime);
            int.TryParse(reader.GetAttribute("clientWaitOutTime"), out clientWaitOutTime);
            float.TryParse(reader.GetAttribute("sameFrameTimeDiffThreshold"), out mSameFrameTimeDiffThreshold);

            while (reader.ReadToFollowing("client"))
            {
                ClientInfo clientInfo = new ClientInfo();
                clientInfo.mIp = reader.GetAttribute("ip");

                if (clientInfo.mIp == null)
                    continue;

                int.TryParse(reader.GetAttribute("id"), out clientInfo.mId);
                int.TryParse(reader.GetAttribute("pitch"), out clientInfo.mPitch);
                int.TryParse(reader.GetAttribute("rotate"), out clientInfo.mRotate);
                int.TryParse(reader.GetAttribute("roll"), out clientInfo.mRoll);

                mClientDict.Add(clientInfo.mIp, clientInfo);
            }
        }

        void FrameCounterCallBack(object a)
        {
            if (serverSessionCount > 0)
            {
                int frameCount = 0;

                if (mLastSecondFrame > mCurrentFrame)
                {
                    mLastSecondFrame = mCurrentFrame;
                    frameCount = (int)mCurrentFrame;
                    mLastSecondFrame = mCurrentFrame;
                }
                else if (mLastSecondFrame < mCurrentFrame)
                {
                    frameCount = (int)(mCurrentFrame - mLastSecondFrame);
                    mLastSecondFrame = mCurrentFrame;
                }
                else
                {
                    frameCount = 0;
                }

                // Logger.Info(string.Format("FPS :{0}, Frame count : {1}", frameCount, mCurrentFrame));
            }
        }

        int mSessionCounts = 0;

        public int TCP_PORT;
        public List<int> CONTROL_ID_LIST;
        public int mIMinClientCounts; //服务端启动客户端最小连接数
        public int DEFAULT_ID = 999;

        public int limitGpuUsage; //是否启动Gpu限制模式
        public int limitGpuSleepTime; //启动Gpu限制模式下的休眠时间 

        public int clientWaitOutTime; //判断客户端断开连接的时间

        public Dictionary<string, ClientInfo> mClientDict = new Dictionary<string, ClientInfo>(); //读取的client配置 
        public Dictionary<long, Dictionary<int, Dictionary<string, byte[]>>> mFrameDic = new Dictionary<long, Dictionary<int, Dictionary<string, byte[]>>>();//关键帧
        public Dictionary<string, byte[]> serverCommandDict = new Dictionary<string, byte[]>();

        public int SERVER_ROLEID = 1111; //服务器也参与整局游戏，负责发送一些全局命令，比如Buff、怪物生成
        public long mCurrentFrame = 0; // 当前服务器帧数
        public long mLastSecondFrame = 0; // 上一秒的帧数
        public int FRAME_INTERVAL = 1;//客户端帧间隔。默认为1

        //public Command controlCmd; //controler最近的position和rotation。给掉线重连的客户端准备
        //已连接到服务端的session.value值应用在帧同步消息判断是否已经准备好
        //public ConcurrentDictionary<LockStepServerSession, bool> serverSessionDict = new ConcurrentDictionary<LockStepServerSession, bool>(); 

        public int serverSessionCount = 0;
        // 统计帧率定时器
        public System.Threading.Timer mFrameTimer;
        // 保存连接的时间 方便统计个客户端效率
        public ConcurrentDictionary<int, DateTime> mTimeStatistic = new ConcurrentDictionary<int, DateTime>();
        // 当同一帧最快客户端和最慢客户端时间差阈值，大于就打印log
        public float mSameFrameTimeDiffThreshold;

        // -------------------------以下为多人服务器新增------------------------------------
        // 保存连接到服务器的客户端的session和id
        public ConcurrentDictionary<LockStepServerSession, string> connectedClientDict = new ConcurrentDictionary<LockStepServerSession, string>();
        // 客户端的属性
        public ConcurrentDictionary<string, ConcurrentDictionary<string, string>> clientPropertyDict = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();
        // 服务端属性
        public Dictionary<string, object> serverProperty = new Dictionary<string, object>();
    }
}
