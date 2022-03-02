using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Debug
{

    private static Logger s_logger;

    static Debug()
    {
        NLog.Config.LoggingConfiguration config = new NLog.Config.LoggingConfiguration();
        var logFile = new NLog.Targets.FileTarget() { FileName = "log.txt", Name = "logFile" };
        var logConsole = new NLog.Targets.ConsoleTarget() { Name = "logconsole" };

        config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Info, logConsole));
        config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Debug, logFile));

        LogManager.Configuration = config;

        s_logger = LogManager.GetCurrentClassLogger();
    }

    public static void Trace(string message)
    {
        s_logger.Trace(message);
    }

    public static void Info(string message)
    {
        s_logger.Info(message);
    }

    public static void Warn(string message)
    {
        s_logger.Warn(message);
    }

    public static void Error(string message)
    {
        s_logger.Error(message);
    }

    public static void Fatal(string message)
    {
        s_logger.Fatal(message);
    }

    public static void Log(LogLevel level, string message)
    {
        s_logger.Log(level, message);
    }
}

