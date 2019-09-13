using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Enums;

namespace Logger.Logs
{
    public class ConsoleLogger : AbstractLogger
    {
        public override void AddLog(LogLevel level, string message)
        {
            try
            {
                switch (level)
                {
                    case LogLevel.INFO:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case LogLevel.WARNING:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case LogLevel.ERROR:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }

                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
