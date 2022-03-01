using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;


namespace MCS.Common
{
    public class Command
    {
        public delegate void CommandResultHandler(Command sender, Response response);

        protected Response _cmdResponse;

        public enum Response
        {
            SUCCESS,
            UNDEFINED_CMD,
            OUT_OF_PARAMETER,
            UNVAILABLE_TIME,
            PROJECTOR_FAILURE,
            AUTH_FAILURE,
            COMMUNICATION_ERROR
        }

        internal virtual string getCommandString()
        {
            //NOOP
            return "";
        }

        internal virtual bool processAnswerString(string a)
        {

            if (a.IndexOf("=ERR1") >= 0)
                _cmdResponse = Response.UNDEFINED_CMD;
            else if (a.IndexOf("=ERR2") >= 0)
                _cmdResponse = Response.UNDEFINED_CMD;
            else if (a.IndexOf("=ERR3") >= 0)
                _cmdResponse = Response.UNVAILABLE_TIME;
            else if (a.IndexOf("=ERR4") >= 0)
                _cmdResponse = Response.PROJECTOR_FAILURE;
            else if (a.IndexOf(" ERRA") >= 0)
                _cmdResponse = Response.AUTH_FAILURE;
            else //OK or query answer...
                _cmdResponse = Response.SUCCESS;

            return _cmdResponse == Response.SUCCESS;
        }

        public Response CmdResponse
        {
            get { return _cmdResponse; }
        }

        public virtual string dumpToString()
        {
            return "";
        }
    }
    public class TcpClientTimedConnection : TcpClient
    {
        /// <summary>
        /// Connects to a remote host.
        /// </summary>
        /// <param name="hostname">The hostname of the host to connect to.</param>
        /// <param name="port">The port of the host to connect to.</param>
        /// <param name="connectTimeout">
        /// The timeout after which to cancel the connection attempt. 
        /// A <see cref="SocketException"/> is thrown if the connection cannot be established in the specified timeout.
        /// </param>
        public void Connect(string hostname, int port, int connectTimeout)
        {
            IPAddress address;
            if (!IPAddress.TryParse(hostname, out address))
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                if (hostEntry.AddressList.Length > 0)
                    Connect(hostEntry.AddressList[0], port, connectTimeout);
                else
                    // 11004 = WSANO_DATA
                    throw new SocketException(11004);
            }
            else
                Connect(address, port, connectTimeout);
        }

        /// <summary>
        /// Connects to a remote host.
        /// </summary>
        /// <param name="address">The address of the host to connect to.</param>
        /// <param name="port">The port of the host to connect to.</param>
        /// <param name="connectTimeout">
        /// The timeout after which to cancel the connection attempt. 
        /// A <see cref="SocketException"/> is thrown if the connection cannot be established in the specified timeout.
        /// </param>
        public void Connect(IPAddress address, int port, int connectTimeout)
        {
            IAsyncResult result = this.BeginConnect(address, port, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(connectTimeout);
            if (!success || !this.Client.Connected)
            {
                try
                {
                    this.Client.Close();
                }
                catch (Exception)
                {
                }

                // 10060 = WSAETIMEDOUT
                throw new SocketException(10060);
            }
        }
    }

    public delegate void DelegateMsg(object msg, string ipPort);

    public class LinkConnection
    {
        /// <summary>
        /// hostname or IP (as string, e.g. "192.168.1.12") of the projector
        /// </summary>
        private string _hostName = "";
        /// <summary>
        /// PJLink port, default ist 4352 (see Spec)
        /// </summary>
        private int _port = 4352;
        /// <summary>
        /// Flag is true, if the projector requires authentication
        /// </summary>
        private bool _useAuth = false;
        /// <summary>
        /// Password supplied by user if authentication is enabled
        /// </summary>
        private string _passwd = "";
        /// <summary>
        /// Random key returned by projector for MD5 sum generation 
        /// </summary>
        private string _pjKey = "";
        /// <summary>
        /// device name . Device unique identification
        /// </summary>
        private string _name = "";
        /// <summary>
        /// The connection client
        /// </summary>
        TcpClientTimedConnection _client = null;
        /// <summary>
        /// The Network stream the _client provides
        /// </summary>
        NetworkStream _stream = null;

        // async event
        public DelegateMsg OnReceive;
        public DelegateMsg OnServerDown;
        public DelegateMsg OnErr;

        #region C'tors

        public LinkConnection(string host, int port, string name)
        {
            _hostName = host;
            _port = port;
            _name = name;
        }

        public LinkConnection(string host, string passwd)
        {
            _hostName = host;
            _passwd = passwd;
            _useAuth = (passwd != "");
        }

        public LinkConnection(string host, int port)
        {
            _hostName = host;
            _port = port;
            _useAuth = false;
        }

        public LinkConnection(string host)
        {
            _hostName = host;
            _useAuth = false;
        }

        #endregion

        public bool sendAsciiCode(string cmd)
        {
            if (initConnection())
            {
                try
                {

                    byte[] sendBytes = Encoding.ASCII.GetBytes(cmd);
                    _stream.Write(sendBytes, 0, sendBytes.Length);

                    byte[] recvBytes = new byte[_client.ReceiveBufferSize];
                    int bytesRcvd = _stream.Read(recvBytes, 0, (int)_client.ReceiveBufferSize);
                    string returndata = Encoding.ASCII.GetString(recvBytes, 0, bytesRcvd);
                    returndata = returndata.Trim();
                    return true;

                }
                catch (Exception e)
                {
                    return false;
                }
                finally
                {
                    //closeConnection();
                }
            }
            return false;
        }

        public bool sendBytes(byte[] cmd)
        {
            if (initConnection())
            {
                try
                {

                    byte[] sendBytes = cmd;
                    _stream.Write(sendBytes, 0, sendBytes.Length);

                    return true;
                }
                catch (Exception e)
                {
                    // NlogHandler.GetSingleton().Info(string.Format("设备控制网口数据异常: " + e.Message));
                    return false;
                }
                finally
                {
                    //closeConnection();
                }
            }

            return false;
        }

        public void Recive()
        {
            byte[] data = new byte[1024];
            try
            {
                _stream.BeginRead(data, 0, data.Length,
                    asyncResult =>
                    {
                        try
                        {
                            int length = _stream.EndRead(asyncResult);
                            string returndata = Encoding.ASCII.GetString(data, 0, length);
                            OnReceive(returndata.Trim(), _name);
                            Recive();
                        }
                        catch (SocketException e)
                        {
                            if (e.ErrorCode == 10054)
                            {
                                OnServerDown("服务器已断线", _name);
                            }
                            else
                            {
                                OnErr(e.Message, _name);
                            }
                        }
                    }, null);
            }
            catch (Exception ex)
            {
                OnErr(ex.Message, _name);
            }
        }


        public Command.Response sendCommand(Command cmd)
        {
            if (initConnection())
            {
                try
                {
                    string cmdString = cmd.getCommandString() + "\r";

                    if (_useAuth && _pjKey != "")
                        cmdString = getMD5Hash(_pjKey + _passwd) + cmdString;

                    byte[] sendBytes = Encoding.ASCII.GetBytes(cmdString);
                    _stream.Write(sendBytes, 0, sendBytes.Length);

                    byte[] recvBytes = new byte[_client.ReceiveBufferSize];
                    int bytesRcvd = _stream.Read(recvBytes, 0, (int)_client.ReceiveBufferSize);
                    string returndata = Encoding.ASCII.GetString(recvBytes, 0, bytesRcvd);
                    returndata = returndata.Trim();
                    cmd.processAnswerString(returndata);
                    return cmd.CmdResponse;

                }
                catch (Exception e)
                {
                }
                finally
                {
                    //closeConnection();
                }
            }

            return Command.Response.COMMUNICATION_ERROR;
        }

        /// <summary>
        /// Sends a command asynchronously. The specified resultCallback will be called when 
        /// the command has executed.
        /// </summary>
        public void sendCommandAsync(Command cmd, Command.CommandResultHandler resultCallback)
        {
            System.Threading.Thread t = new System.Threading.Thread((System.Threading.ThreadStart)delegate
            {
                var response = sendCommand(cmd);
                resultCallback(cmd, response);
            });
            t.IsBackground = true;
            t.Start();
        }

        public string HostName
        {
            get { return _hostName; }
        }

        #region private methods

        private bool initConnection()
        {
            try
            {
                if (_client == null || !_client.Connected)
                {
                    _client = new TcpClientTimedConnection();
                    _client.Connect(_hostName, _port, 100);
                    _stream = _client.GetStream();
                    _stream.ReadTimeout = 100;
                    _stream.WriteTimeout = 100;

                    Recive();

                }
                return true;
            }
            catch (Exception e)
            {
                // NlogHandler.GetSingleton().Error(string.Format("连接到设备 {0} 失败", _hostName));
                return false;
            }

        }

        public void closeConnection()
        {
            if (_client != null)
                _client.Close();
            if (_stream != null)
                _stream.Close();
        }

        private string getMD5Hash(string input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.ASCII.GetBytes(input);
            byte[] hash = x.ComputeHash(bs);

            string toRet = "";
            foreach (byte b in hash)
            {
                toRet += b.ToString("x2");
            }
            return toRet;
        }

        #endregion

    }


}
