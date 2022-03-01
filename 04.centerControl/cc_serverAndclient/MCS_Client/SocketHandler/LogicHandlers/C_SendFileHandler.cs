using Common;

namespace MCS_Client.SocketHandler.LogicHandlers
{
    public class C_SendFileHandler : C_HandlerInterface
    {
        public void MessageReceive(SocketModel message)
        {
            // 根据Command分别进行处理
            switch (message.Command)
            {
                case (byte)Protocol.Command.SendFiles_SavePath:

                    string[] data = (string[])message.Message;

                    ClientForm.Form.ShowMessage(data);

                    break;

                case (byte)Protocol.Command.SendFiles_FileNames:

                    string[] data2 = (string[])message.Message;

                    ClientForm.Form.ShowMessage(data2);

                    break;

                case (byte)Protocol.Command.SendFiles_FileLengths:

                    string[] data3 = (string[])message.Message;

                    ClientForm.Form.ShowMessage(data3);

                    break;

                case (byte)Protocol.Command.SendFiles_SendFile:

                    string[] data4 = new string[1];
                    data4[0] = "收到数据！";

                    ClientForm.Form.ShowMessage(data4);

                    break;
            }
        }
    }
}
