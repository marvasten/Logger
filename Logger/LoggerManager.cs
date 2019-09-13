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
        private AbstractLogger _loggers;

        public AbstractLogger GetLoggers(params LogType[] loggerTypes)
        {
            AbstractLogger textfileLogger = null;
            AbstractLogger consoleLogger = null;
            AbstractLogger databaseLogger = null;

            // remove possible duplicates in the list and sort it
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

            // determine the active loggers and return 
            if (consoleLogger != null && databaseLogger != null && textfileLogger != null)
            {
                consoleLogger.SetNextLogger(databaseLogger);
                databaseLogger.SetNextLogger(textfileLogger);
                _loggers = consoleLogger;
            }
            else if (consoleLogger != null && databaseLogger != null && textfileLogger == null)
            {
                consoleLogger.SetNextLogger(databaseLogger);
                _loggers = consoleLogger;
            }
            else if (consoleLogger != null && databaseLogger == null && textfileLogger != null)
            {
                consoleLogger.SetNextLogger(textfileLogger);
                _loggers = consoleLogger;
            }
            else if (consoleLogger == null && databaseLogger != null && textfileLogger != null)
            {
                databaseLogger.SetNextLogger(textfileLogger);
                _loggers = databaseLogger;
            }
            else if (consoleLogger != null && databaseLogger == null && textfileLogger == null)
            {
                _loggers = consoleLogger;
            }
            else if (consoleLogger == null && databaseLogger != null && textfileLogger == null)
            {
                _loggers = databaseLogger;
            }
            else if (consoleLogger == null && databaseLogger == null && textfileLogger != null)
            {
                _loggers = textfileLogger;
            }

            return _loggers;
        }

        public void LogMessage(LogLevel level, string message)
        {
            _loggers.LogMessage(level, message);
        }

    }
}
