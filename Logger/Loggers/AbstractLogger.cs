using Logger.Enums;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Logs
{
    public abstract class AbstractLogger: ILogger
    {
        protected LogLevel level;

        // next element in chain or responsibility
        protected AbstractLogger nextLogger;

        public void SetNextLogger(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        public void LogMessage(LogLevel level, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Missing log message");
            }

            if (this.level <= level)
            {
                AddLog(level, message);
            }

            if (this.nextLogger != null)
            {
                this.nextLogger.LogMessage(level, message);
            }
        }

        public abstract void AddLog(LogLevel level, string message);

    }
}
