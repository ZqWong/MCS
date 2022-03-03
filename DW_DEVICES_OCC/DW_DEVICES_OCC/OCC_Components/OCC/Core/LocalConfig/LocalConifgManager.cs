using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCC.Core.LocalConfig
{
    public class LocalConifgManager : LockedSingletonClass<LocalConifgManager>
    {
        public Action OnInitialized;

        private const string CONFIG_FOLDER_NAME = "LocalConfigs";

        public string ConifgFolerPath = Path.Combine(Global.Instance.ApplicationBasePath, CONFIG_FOLDER_NAME);



        private const string SYSTEM_CONFIG_FILE_NAME = "SystemConfig.json";
        public DataManagerBase<SystemConfigDataModel> SystemConfig { get; private set; }



        public LocalConifgManager()
        {
            SystemConfig = new DataManagerBase<SystemConfigDataModel>(new SystemConfigDataModel());
        }


        public void Initialize()
        {
            try
            {
                SystemConfig.Initialize(Path.Combine(ConifgFolerPath, SYSTEM_CONFIG_FILE_NAME), true);



#if DEBUG
                LogConfigContent();
#endif
            }
            catch (Exception ex)
            {
                Debug.Error($"[LocalConifgManager] Initialize failed : {ex}");
                
            }





            OnInitialized?.Invoke();
        }




#if DEBUG

        private void LogConfigContent()
        {
            Debug.Info($"(￣y▽￣)╭ Ohohoho....." +
                $"\n===========================SystemConfig===========================" +
                $"\nHostname :{SystemConfig.DataModel.Hostname} " +
                $"\nUsername :{SystemConfig.DataModel.Username} " +
                $"\nPassword :{SystemConfig.DataModel.Password} " +
                $"\nRabbitMQBrokerName :{SystemConfig.DataModel.RabbitMQBrokerName} " +
                $"\nRabbitMQExchangeType :{SystemConfig.DataModel.RabbitMQExchangeType} " +
                $"\nSSL :{SystemConfig.DataModel.RabbitMQSSL} " +
                $"\nDatabaseUsername :{SystemConfig.DataModel.DatabaseUsername} " +
                $"\nDatabasePassword :{SystemConfig.DataModel.DatabasePassword} " +
                $"\nDatabaseHost :{SystemConfig.DataModel.DatabaseHost} " +
                $"\nDatabasePort :{SystemConfig.DataModel.DatabasePort} " +
                $"\nDatabaseRepName :{SystemConfig.DataModel.DatabaseRepName}" +
                $"\n==================================================================");
        }


#endif


    }
}
