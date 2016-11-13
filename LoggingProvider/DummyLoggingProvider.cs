using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenSupportEngine.Logging.LoggingFormatProvider;

namespace OpenSupportEngine.Logging.LoggingProvider
{
    public class DummyLoggingProvider : ILoggingProvider
    {
        public ILoggingFormatProvider FormatProvider { get; } =
            new StandardLoggingFormatProvider();

        public bool IsCrashResistent { get; } = true;

        public void FinishLog()
        {
        }

        public void LogMessage(string message, LoggingCategory category = LoggingCategory.Standard)
        {
        }

        public void StartLog()
        {
        }
    }
}
