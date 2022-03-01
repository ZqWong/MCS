using ServerFrame;
using System.Collections.Generic;

namespace MCS.Common
{
    public class Global
    {
        private static Global _Instance;

        public Dictionary<string, UserToken> _ClientDic = new Dictionary<string, UserToken>();

        public Dictionary<string, bool> _ApplicationOpenStateDic = new Dictionary<string, bool>();

        public string LoginUserName;

        public bool IsHasAdminLevel = false;

        public static Global Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Global();
                }

                return _Instance;
            }
        }

        /// <summary>
        /// 已连接的客户端个数
        /// </summary>
        /// <returns></returns>
        public int ShowClientCount()
        {
            return _ClientDic.Count;
        }

        /// <summary>
        /// 判断客户端是否存在
        /// </summary>
        /// <param name="clientKey"></param>
        /// <returns></returns>
        public bool IsClientExist(string clientKey)
        {
            if (_ClientDic.ContainsKey(clientKey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 添加客户端
        /// </summary>
        /// <param name="clientKey"></param>
        /// <param name="userToken"></param>
        /// <returns>成功/失败（客户端已存在！）</returns>
        public bool AddClientToClientDic(string clientKey, UserToken userToken)
        {
            bool result = true;

            if (!_ClientDic.ContainsKey(clientKey))
            {
                _ClientDic.Add(clientKey, userToken);
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="clientKey"></param>
        /// <returns>成功/失败（客户端不存在！）</returns>
        public bool RemoveClientFromClientDic(string clientKey)
        {
            bool result = true;

            if (IsClientExist(clientKey))
            {
                _ClientDic.Remove(clientKey);

                // add by wuxin at 2018/09/09 - start
                if (_ApplicationOpenStateDic.ContainsKey(clientKey.Substring(0, clientKey.IndexOf(':'))))
                {
                    _ApplicationOpenStateDic.Remove(clientKey.Substring(0, clientKey.IndexOf(':')));
                }
                // add by wuxin at 2018/09/09 - end
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        ///  获取所有客户端的Key集合（IP:Port集合）
        /// </summary>
        /// <returns></returns>
        public string[] GetClientDicKeys()
        {
            int count = this.ShowClientCount();

            if (count > 0)
            {
                string[] keyArr = new string[count];

                _ClientDic.Keys.CopyTo(keyArr, 0);

                return keyArr;
            }

            return null;
        }

        /// <summary>
        /// 通过客户端IP获取客户端IP:Port
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public string GetClientIPAddressByIP(string ip)
        {
            string clientIPAddress = "";

            // 查找指定IP Socket客户端的IP地址 IP:Port
            string[] clientAddress = GetClientDicKeys();

            if (clientAddress != null)
            {
                for (int i = 0; i < clientAddress.Length; i++)
                {
                    if (ip == clientAddress[i].Substring(0, clientAddress[i].IndexOf(':')))
                    {
                        clientIPAddress = clientAddress[i];
                        break;
                    }
                }
            }

            return clientIPAddress;
        }

        /// <summary>
        /// 添加应用程序打开状态字典
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public void AddApplicationOpenStateDic(string ip, bool isOpen)
        {

            if (_ApplicationOpenStateDic.ContainsKey(ip))
            {
                for (int i = 0; i < _ApplicationOpenStateDic.Count; i++)
                {
                    bool old = _ApplicationOpenStateDic[ip];

                    if (old != isOpen)
                    {
                        _ApplicationOpenStateDic.Remove(ip);

                        _ApplicationOpenStateDic.Add(ip, isOpen);
                    }
                }

                // 报错：集合已修改；可能无法执行枚举操作。
                //foreach(KeyValuePair<string, bool> temp in _ApplicationOpenStateDic)
                //{
                //    if (temp.Key == ip && temp.Value != isOpen)
                //    {

                //    }
                //}
            }
            else
            {
                _ApplicationOpenStateDic.Add(ip, isOpen);
            }
        }

        //public bool SendMessage2OneClient(string clientIPAddress, Protocol.Type type, Protocol.Area area, Protocol.Command command, object message)
        //{
        //    bool result = false;

        //    ByteArray ba = new ByteArray();

        //    ba.write((byte)type); // 必须进行转化否则出错，正常是不应该的
        //    ba.write((byte)area);
        //    ba.write((int)command);

        //    // 判断消息体是否为空  不为空则序列化后写入
        //    if (message != null)
        //    {
        //        ba.write(SerializeAndDeserializeTool.Serialize((object)message));
        //    }

        //    // 因为要进行长度粘包处理，所以需要新建一个头部带数据长度的数组
        //    ByteArray resultByteArray = new ByteArray();
        //    resultByteArray.write(ba.Length);
        //    resultByteArray.write(ba.GetBuffer());

        //    // 发客户端发送信息
        //    if (_ClientDic.ContainsKey(clientIPAddress))
        //    {
        //        result = _ClientDic[clientIPAddress].Send(resultByteArray.GetBuffer());
        //    }

        //    return result;
        //}

        //public List<string> SendMessage2AllClient(Protocol.Type type, Protocol.Area area, Protocol.Command command, object message)
        //{
        //    List<string> sendFailClientList = new List<string>();

        //    ByteArray ba = new ByteArray();

        //    ba.write((byte)type); // 必须进行转化否则出错，正常是不应该的
        //    ba.write((byte)area);
        //    ba.write((int)command);

        //    // 判断消息体是否为空  不为空则序列化后写入
        //    if (message != null)
        //    {
        //        ba.write(SerializeAndDeserializeTool.Serialize((object)message));
        //    }

        //    // 因为要进行长度粘包处理，所以需要新建一个头部带数据长度的数组
        //    ByteArray resultByteArray = new ByteArray();
        //    resultByteArray.write(ba.Length);
        //    resultByteArray.write(ba.GetBuffer());

        //    int count = this.ShowClientCount();

        //    if (count > 0)
        //    {
        //        UserToken[] valueArr = new UserToken[count];

        //        _ClientDic.Values.CopyTo(valueArr, 0);

        //        for (int i = 0; i < valueArr.Length; i++)
        //        {
        //            bool result = valueArr[i].Send(resultByteArray.GetBuffer());

        //            if (!result)
        //            {
        //                sendFailClientList.Add(valueArr[i].ClientSocket.RemoteEndPoint.ToString());
        //            }
        //        }
        //    }

        //    return sendFailClientList;
        //}
    }
}
