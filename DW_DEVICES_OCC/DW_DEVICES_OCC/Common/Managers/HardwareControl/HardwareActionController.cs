using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HardwareActionController
{
    public class NIC
    {
        public HardwareNICConnectHelper.LinkConnection ActionExecute(string ip, int port, string name, byte[] cmd)
        {
            HardwareNICConnectHelper.LinkConnection connect = null;
            try
            {
                connect = new HardwareNICConnectHelper.LinkConnection(ip, port, name);
                connect.SendBytes(cmd);
                return connect;
            }
            catch (Exception ex)
            {
                Debug.Error($"HardwareActionController NIC ActionExecute failed {ex}");
                throw ex;
            }
           
        }

        public HardwareNICConnectHelper.LinkConnection ActionExecute(string ip, int port, string name, byte[] cmd, Action<string, string> receiveAction, Action<string, string> errorAction, Action<string, string> serverDownAction)
        {
            HardwareNICConnectHelper.LinkConnection connect = null;
            try
            {
                connect = new HardwareNICConnectHelper.LinkConnection(ip, port, name);           
                connect.ReceiveAction += receiveAction;
                connect.ErrorAction += errorAction;
                connect.ServerDownAction += serverDownAction;
                connect.SendBytes(cmd);
                return connect;
            }
            catch (Exception ex)
            {
                Debug.Error($"HardwareActionController NIC ActionExecute failed {ex}");
                throw ex;
            }                 
        }
    }

    public class Serial
    {
        public void ActionExecute(SerialPort serial, byte[] cmd)
        {
            try
            {
                serial.Write(cmd, 0, cmd.Length);
            }
            catch (Exception ex)
            {
                Debug.Error($"HardwareActionController Serial ActionExecute failed {ex}");
                throw ex;
            }
        }
    }



}
