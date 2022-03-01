using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PacketCommon;

namespace MIServer.Handler
{
    public class C2SFramePacket : BasePacketHandler
    {
        
        private object mMyLock = new Object();
        private object mControlLock = new object();
        private long mCurrentFrameTime = 0;
        // private System.Threading.Timer CheckConnectStateTimer;

        private System.Timers.Timer _CheckConnectStateTimer;

        // 保存连接进来的session
        private ConcurrentBag<LockStepServerSession> mSessionReadyBag = new ConcurrentBag<LockStepServerSession>();

        public C2SFramePacket() : base()
        {
            _CheckConnectStateTimer = new System.Timers.Timer();
            _CheckConnectStateTimer.Elapsed += CheckConnectState;

            _CheckConnectStateTimer.AutoReset = true;
            _CheckConnectStateTimer.Enabled = false;
            _CheckConnectStateTimer.Interval = 1000;

        }

        //private void CheckConnectState(object a)
        private void CheckConnectState(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (mCurrentFrameTime == 0 || server == null)
                return;

            // server.Logger.Info(string.Format("checkConnectState come in. server count : {0}",server.serverSessionCount));

            if ((DateTime.Now.Ticks / 10000 - mCurrentFrameTime) > server.clientWaitOutTime)
            {
                List<LockStepServerSession> mReadyList = mSessionReadyBag.ToList();

                foreach (var iSession in server.GetAllSessions())
                {
                    if (mReadyList.Contains(iSession) == false)
                    {
                        iSession.Close();
                        server.Logger.Error(string.Format("Client ID : {0}, timeout {1} , disconnection. Session count : {2} , serverSessionCount : {3}", iSession.RoleId, server.clientWaitOutTime, server.SessionCount, server.serverSessionCount));
                    }
                }

                if (server.SessionCount < server.serverSessionCount)
                {
                    Interlocked.Exchange(ref server.serverSessionCount, server.SessionCount);
                }

                if (server.SessionCount == 0)
                {
                    server.Logger.Info(string.Format("checkConnectState timmer stop. server count : {0}", server.serverSessionCount));
                    _CheckConnectStateTimer.Stop();
                }

                AllReadySend();
            }
        }

        private void AllReadySend()
        {
            lock (mMyLock)
            {

                //if (mReadyCount == 0)
                if (mSessionReadyBag.IsEmpty || server.serverSessionCount > mSessionReadyBag.Count)
                {
                    return;
                }
                else
                {
                    //mReadyCount = 0;

                    PacketCommon.S2CFramePacket sendData = new PacketCommon.S2CFramePacket();

                    // todo 应用对象池来避免重复
                    sendData.cmdDict = new Dictionary<int, Dictionary<string, byte[]>>();

                    // 有可能全部关闭后，会导致部分客户端继续进入这个函数而报错
                    if (server.mFrameDic.Count == 0)
                    {
                        LockStepServerSession someItem;

                        while (!mSessionReadyBag.IsEmpty)
                        {
                            mSessionReadyBag.TryTake(out someItem);
                        }

                        server.Logger.Error(string.Format("帧同步当所有连接都断开后，将还包括未处理完成的帧同步逻辑清空!等待主控机连接！"));

                        return;
                    }

                    server.Logger.Debug(string.Format("come in AllReadySend current frame :{0}, dict count: {1}", server.mCurrentFrame, server.mFrameDic.Count));

                    if (server.mCurrentFrame < server.mFrameDic.Keys.Max())
                    {
                        server.mCurrentFrame = server.mFrameDic.Keys.Max();
                    }

                    // todo 解决异常
                    try
                    {

                        var it = server.mFrameDic[server.mCurrentFrame].GetEnumerator();
                        while (it.MoveNext())
                        {
                            if (it.Current.Value == null)
                                continue;

                            foreach (var item in it.Current.Value)
                            {
                                if (!sendData.cmdDict.ContainsKey(it.Current.Key))
                                {
                                    sendData.cmdDict.Add(it.Current.Key, new Dictionary<string, byte[]>());
                                }

                                if (!sendData.cmdDict[it.Current.Key].ContainsKey(item.Key))
                                {
                                    sendData.cmdDict[it.Current.Key].Add(item.Key, item.Value);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        server.Logger.Error(string.Format("Current Frame key error : {0} ,message : {1}!", server.mCurrentFrame, e.Message.ToString()));
                    }


                    //server.Logger.Debug(string.Format("Current Frame : {0} is all send!", server.mCurrentFrame));

                    // 先增加计数后发送
                    Interlocked.Increment(ref server.mCurrentFrame);

                    sendData.frameCount = server.mCurrentFrame;

                    // 计算最慢客户端
                    int minRoleID = server.mTimeStatistic.OrderBy(d => d.Value).Select(d => d.Key).FirstOrDefault();
                    int maxRoleID = server.mTimeStatistic.OrderByDescending(d => d.Value).Select(d => d.Key).FirstOrDefault();

                    TimeSpan ts = server.mTimeStatistic[maxRoleID].Subtract(server.mTimeStatistic[minRoleID]);

                    if (ts.TotalMilliseconds > server.mSameFrameTimeDiffThreshold)
                    {
                        server.Logger.Warn(string.Format("Fastest roldID :{0}, slowest roldID: {1}, millisecodes :{2} ", minRoleID, maxRoleID, ts.TotalMilliseconds));
                    }

                    // Console.WriteLine("Frame count :{0}", server.mCurrentFrame);

                    //server.Logger.Debug(string.Format("Current Frame : {0} is all send! count is {1}",server.mCurrentFrame, mSessionReadyBag.Count));

                    BroadCastProtobuf(sendData, mSessionReadyBag);

                    //server.Logger.Debug(string.Format("Current Frame : {0} send over!", server.mCurrentFrame));

                    // 防止服务端运行内存逐渐升高，每999帧清空一次保存额帧数据
                    if (server.mCurrentFrame % 999 == 0)
                    {
                        server.mFrameDic.Clear();
                    }
                }
            }
        }

        public override void ExecuteCommand(LockStepServerSession session, ProtobufRequestInfo requestInfo)
        {
            // todo 衡量放到此位置是否准确设置并启动定时器
            if (_CheckConnectStateTimer.Enabled == false)
            {
                if (server.SessionCount >= server. mIMinClientCounts)
                {
                    _CheckConnectStateTimer.Start();
                    server.Logger.Info(string.Format("checkConnectState timer start. server count : {0},mSessionReadyBag count ：{1}", server.serverSessionCount, mSessionReadyBag.Count));
                }
            }

            base.ExecuteCommand(session, requestInfo);

            PacketCommon.C2SFramePacket recvData = packetSerialiser.Deserialise<PacketCommon.C2SFramePacket>(requestInfo.messageBuffer);

            if (server.serverSessionCount > mSessionReadyBag.Count)
            {
                //todo
                //可以删除协议中的mRoleId，因为session中保存着该变量

                //server.Logger.Debug(string.Format("Current Frame : {0} , recv roleid :{1}  , serverSessionCount: {2}, client frame count :{3}", server.mCurrentFrame, recvData.roleId, server.serverSessionCount, recvData.frameCount));

                long mFrameCount = recvData.frameCount;
                int mRoleId = recvData.roleId;

                try
                {
                    server.mTimeStatistic.AddOrUpdate(mRoleId, DateTime.Now, (key, oldValue) => DateTime.Now);
                }
                catch (Exception e)
                {
                    server.Logger.Error(string.Format("server.mTimeStatistic 遇到异常： {0}, id : {1}",e.Message.ToString(), mRoleId));
                }
                
                if (server.CONTROL_ID_LIST.Contains(mRoleId))
                {
                    lock (mControlLock)
                    {
                        mCurrentFrameTime = DateTime.Now.Ticks / 10000;

                        // 如果主控客户端发送来的framecount与服务端记录不一致，则放弃该客户端发送上来的消息
                        if (mFrameCount != server.mCurrentFrame)
                        {
                            mSessionReadyBag.Add(session);
                            server.Logger.Debug(string.Format("Current Frame : {0} , client frame count : {1}", server.mCurrentFrame, mFrameCount));
                            return;
                        }

                        // 在服务端的内存中添加一个空帧
                        if (server.mFrameDic.ContainsKey(mFrameCount) == false)
                        {

                            var temp = new Dictionary<int, Dictionary<string, byte[]>>();

                            server.mFrameDic.Add(mFrameCount, temp);

                            server.Logger.Debug(string.Format("Current Frame : {0} , mFrameDic add ", server.mCurrentFrame));
                        }

                        var frames = server.mFrameDic[mFrameCount];

                        // 当前帧的服务器命令
                        if (frames.ContainsKey(server.SERVER_ROLEID) == false && server.serverCommandDict.Count > 0)
                        {
                            Dictionary<string, byte[]> _serverCmdDict = new Dictionary<string, byte[]>(server.serverCommandDict);

                            server.serverCommandDict.Clear();

                            frames.Add(server.SERVER_ROLEID, _serverCmdDict);

                        }

                        // 当前帧的客户端命令
                        if (frames.ContainsKey(mRoleId) == false)
                        {
                            //PacketCommon.FramePacket recvData = packetSerialiser.Deserialise<PacketCommon.FramePacket>(recvData.cmdDict[]);
                            frames.Add(mRoleId, recvData.cmdDict);

                            if (recvData.cmdDict != null)
                            {
                                if (recvData.cmdDict.ContainsKey("CmdChangeScenePacket"))
                                {
                                    server.Logger.Debug(string.Format(" client command have CmdChangeScenePacket "));
                                }
                            }
                        }
                    }
                }

                mSessionReadyBag.Add(session);
                
            }

            if (server.serverSessionCount > mSessionReadyBag.Count)
            {
                return;
            }
            else
            {
                AllReadySend();
            }
        }
    }
}
