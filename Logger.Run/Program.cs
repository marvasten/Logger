using Logger.Enums;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            LogRepositories();

            System.Console.ReadLine();
        }

        static void LogRepositories()
        {
            try
            {
                // Define the loggers to use
                ILogger loggerManager = new LoggerManager().GetLoggers(LogType.DATABASE, LogType.CONSOLE);
                // Log different types of messages
                loggerManager.LogMessage(LogLevel.ERROR, "This is an error test message");
                loggerManager.LogMessage(LogLevel.WARNING, "This is a warning test message");
                loggerManager.LogMessage(LogLevel.INFO, "This is a info test message");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
