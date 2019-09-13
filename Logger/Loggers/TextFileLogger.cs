using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Enums;

namespace Logger.Logs
{
    public class TextFileLogger : AbstractLogger
    {
        public override void AddLog(LogLevel level, string message)
        {
            string logFileFolder = Environment.GetEnvironmentVariable("LogFileDirectory", EnvironmentVariableTarget.User);
            if (string.IsNullOrEmpty(logFileFolder))
            {
                throw new ApplicationException("Missing configuration: LogFile Folder");
            }

            // Separate log files based on the LogLevel (INFO, WARNING, ERROR)
            string filePath = string.Format(@"{0}\LogFile_{1}_{2}.txt",
                                    logFileFolder,
                                    DateTime.UtcNow.ToString("MM-dd-yyy"),
                                    level.ToString());

            try
            {
                // validate if log folder exists. If not, create it
                if (!System.IO.Directory.Exists(logFileFolder))
                {
                    System.IO.Directory.CreateDirectory(logFileFolder);
                }

                // process
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.WriteAllText(filePath,
                                                string.Format(@"{0}: {1}{2}", DateTime.UtcNow.ToString("HH:mm:ss"), message, Environment.NewLine));
                }
                else
                {
                    System.IO.File.AppendAllText(filePath,
                                                string.Format(@"{0}: {1}{2}", DateTime.UtcNow.ToString("HH:mm:ss"), message, Environment.NewLine));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
