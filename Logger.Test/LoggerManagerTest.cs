using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Logger.Interfaces;
using Logger.Enums;

namespace Logger.Test
{
    /// <summary>
    /// Descripción resumida de LoggerManagerTest
    /// </summary>
    [TestFixture]
    public class LoggerManagerTest
    {
        [Test]
        [Description("Only errors for database logger")]
        public void LogErrorsForDatabaseTest()
        {
            ILogger logger = new LoggerManager().GetLoggers(LogType.DATABASE);
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.ERROR, "This is an error message for testing"));
        }

        [Test]
        [Description("Only warnings for console logger")]
        public void LogWarningsForConsoleTest()
        {
            ILogger logger = new LoggerManager().GetLoggers(LogType.CONSOLE);
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.WARNING, "This is a warning message for testing"));
        }

        [Test]
        [Description("Only info for textfile logger")]
        public void LogInfoForTextfileTest()
        {
            ILogger logger = new LoggerManager().GetLoggers(LogType.TEXTFILE);
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.INFO, "This is an info message for testing"));
        }

        [Test]
        [Description("Only errors and warnings for console and textfile loggers")]
        public void LogErrorsAndWarningsForConsoleAndTextfile()
        {
            ILogger logger = new LoggerManager().GetLoggers(LogType.CONSOLE, LogType.TEXTFILE);
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.WARNING, "This is a warning message for testing"));
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.ERROR, "This is an error message for testing"));   
        }

        [Test]
        [Description("Only info and warnings for database and textfile loggers")]
        public void LogInfoAndWarningsForDatabaseAndTextfile()
        {
            ILogger logger = new LoggerManager().GetLoggers(LogType.TEXTFILE, LogType.DATABASE);
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.INFO, "This is an info message for testing"));
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.WARNING, "This is a warning message for testing"));
        }

        [Test]
        [Description("Only info and errors for database and console loggers")]
        public void LogInfoAndErrorsForConsoleAndDatabase()
        {
            ILogger logger = new LoggerManager().GetLoggers(LogType.CONSOLE, LogType.DATABASE);
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.INFO, "This is an info message for testing"));
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.ERROR, "This is an error message for testing"));
        }

        [Test]
        [Description("Logs all for all the logger types")]
        public void LogAllTest()
        {
            ILogger logger = new LoggerManager().GetLoggers(LogType.TEXTFILE, LogType.DATABASE, LogType.CONSOLE);
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.INFO, "This is an info message for testing"));
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.WARNING, "This is a warning message for testing"));
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.ERROR, "This is an error message for testing"));
        }

    }
}
