using Logger.Enums;
using Logger.Interfaces;
using Logger.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class LoggerManager
    {
        private AbstractLogger loggers;

        public AbstractLogger GetLoggers(params LogType[] loggerTypes)
        {
            AbstractLogger textfileLogger = null;
            AbstractLogger consoleLogger = null;
            AbstractLogger databaseLogger = null;

            List<LogType> loggerTypesNoDupes = loggerTypes.Distinct().OrderBy(t => t.ToString()).ToList();
            foreach (LogType loggerType in loggerTypesNoDupes)
            {
                switch (loggerType)
                {
                    case LogType.TEXTFILE:
                        textfileLogger = new TextFileLogger();
                        break;
                    case LogType.CONSOLE:
                        consoleLogger = new ConsoleLogger();
                        break;
                    case LogType.DATABASE:
                        databaseLogger = new DatabaseLogger();
                        break;
                }
            }

            if (consoleLogger != null && databaseLogger != null && textfileLogger != null)
            {
                consoleLogger.SetNextLogger(databaseLogger);
                databaseLogger.SetNextLogger(textfileLogger);
                loggers = consoleLogger;
                return consoleLogger;
            }
            else if (consoleLogger != null && databaseLogger != null && textfileLogger == null)
            {
                consoleLogger.SetNextLogger(databaseLogger);
                loggers = consoleLogger;
                return consoleLogger;
            }
            else if (consoleLogger != null && databaseLogger == null && textfileLogger != null)
            {
                consoleLogger.SetNextLogger(textfileLogger);
                loggers = consoleLogger;
                return consoleLogger;
            }
            else if (consoleLogger == null && databaseLogger != null && textfileLogger != null)
            {
                databaseLogger.SetNextLogger(textfileLogger);
                loggers = databaseLogger;
                return databaseLogger;
            }
            else if (consoleLogger != null && databaseLogger == null && textfileLogger == null)
            {
                loggers = consoleLogger;
                return consoleLogger;
            }
            else if (consoleLogger == null && databaseLogger != null && textfileLogger == null)
            {
                loggers = databaseLogger;
                return databaseLogger;
            }
            else // if (consoleLogger == null && databaseLogger == null && textfileLogger != null)
            {
                loggers = textfileLogger;
                return textfileLogger;
            }
        }

        public void LogMessage(LogLevel level, string message)
        {
            loggers.LogMessage(level, message);
        }

    }
}
