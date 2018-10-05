using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendarM133BusinessData
{
    public static class CalendarLogger
    {
        private static NLog.Logger nLog = NLog.LogManager.GetCurrentClassLogger();

        public static void addLog(String logMessage) {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
            nLog.Trace(logMessage);
            nLog.Trace(logMessage);
        }
    }
}
