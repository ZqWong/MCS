using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCC.Core.LocalConfig
{
    [Serializable]
    public class SystemConfigDataModel : LocalDataModelBase
    {
        public bool ShowLoginForm;

        public string Hostname;

        public string Password;
        public string Username;

        public string RabbitMQBrokerName;
        public string RabbitMQExchangeType;
        public string RabbitMQSSL;

        public string DatabaseUsername;
        public string DatabasePassword;
        public string DatabaseHost;
        public string DatabasePort;
        public string DatabaseRepName;

        public bool WindowsCanMoved;

        public bool GroupInfoByCompany;
    }
}
