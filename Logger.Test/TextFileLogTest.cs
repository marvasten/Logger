using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using Logger.Interfaces;
using Logger.Enums;

namespace Logger.Test
{
    /// <summary>
    /// Descripción resumida de TextFileLogTest
    /// </summary>
    [TestFixture]
    public class TextFileLogTest
    {
        ILogger logger;

        [SetUp]
        public void Setup()
        {
            logger = new LoggerManager().GetLoggers(LogType.TEXTFILE);
        }

        [Test]
        public void IsLoggerInitializedTest()
        {
            Assert.IsNotNull(logger);
        }

        [Test]
        public void IsNullMessageTest()
        {
            var ex = Assert.Throws<ArgumentException>(() => logger.LogMessage(LogLevel.INFO, null));
            Assert.That(ex.Message == "Missing log message");
        }

        [Test]
        public void TextFileLogInfoTest()
        {
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.INFO, "This is an info message for testing"));
        }

        [Test]
        public void TextFileLogWarningTest()
        {
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.WARNING, "This is a warning message for testing"));
        }

        [Test]
        public void TextFileLogErrorTest()
        {
            Assert.DoesNotThrow(() => logger.LogMessage(LogLevel.ERROR, "This is an error message for testing"));
        }
    }
}
