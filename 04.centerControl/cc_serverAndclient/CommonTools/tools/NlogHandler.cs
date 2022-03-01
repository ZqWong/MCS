using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Targets;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Targets.Wrappers;

namespace Utilities
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static readonly object syslock = new object();
        private static T _instance = default(T);
        public static T GetSingleton()
        {
            if (_instance == null)
            {
                lock (syslock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }
            }

            return _instance;
        }

        public virtual void Init(Action callback = null)
        {
            if (callback != null)
            {
                callback();
            }
        }
        public virtual void Dispose()
        {
        }
    }

    public class NlogHandler : Singleton<NlogHandler>
    {

        private Logger logger;
        private string targerName = "targetFile";
        public NlogHandler()
        {
            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create targets
            var consoleTarget = new ColoredConsoleTarget("targetConsole")
            {
                Layout = @"${date:format=HH\:mm\:ss.fff} | ${level:uppercase=true} | ${message} | ${exception}"
            };

            var vAsyncTargetConsole = new AsyncTargetWrapper(consoleTarget);
            config.AddTarget(consoleTarget);

            var fileTarget = new FileTarget(targerName)
            {
                // FileName = "${basedir}/Logs/log${shortdate}.txt",
                FileName = "${basedir}Logs\\log${shortdate}.txt",

                Layout = "${longdate} | ${message} | ${exception}"
            };

            fileTarget.Encoding = Encoding.UTF8;
            var vAsyncTarget = new AsyncTargetWrapper(fileTarget);
            config.AddTarget(fileTarget);

            // Step 3. Define rules
            config.AddRule(LogLevel.Info, LogLevel.Fatal, vAsyncTargetConsole);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, vAsyncTarget);

            // Step 4. Activate the configuration
            LogManager.Configuration = config;

            logger = LogManager.GetLogger("NlogHandler");
        }


        public void Trace(string sInput)
        {
            logger?.Trace(sInput);
        }

        public void Debug(string sInput)
        {
            logger?.Debug(sInput);
        }

        public void Info(string sInput)
        {
            logger?.Info(sInput);
        }

        public void Warn(string sInput)
        {
            logger?.Warn(sInput);
        }

        public void Error(string sInput)
        {
            logger?.Error(sInput);
        }

        public void Fatal(string sInput)
        {
            logger?.Fatal(sInput);
        }

        public string GetFileName()
        {
            var fileTarget = (FileTarget)LogManager.Configuration.FindTargetByName(targerName);
            // Need to set timestamp here if filename uses date. 
            // For example - filename="${basedir}/logs/${shortdate}/trace.log"
            var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
            string fileName = fileTarget.FileName.Render(logEventInfo);


            if (!File.Exists(fileName))
                throw new Exception("Log file does not exist.");

            return fileName;
        }

        public string GetFolderName()
        {
            string str = AppDomain.CurrentDomain.BaseDirectory; 
            return str + @"\" + "Logs";
        }




    }

}
