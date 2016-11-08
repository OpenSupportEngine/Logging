using OpenSupportEngine.Logging.LoggingFormatProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupportEngine.Logging.LoggingProvider
{
    public interface ILoggingProvider
    {
        ILoggingFormatProvider FormatProvider { get; }
        bool IsCrashResistent { get; }

        void StartLog();
        void FinishLog();
        void LogMessage(string message, LoggingCategory category = LoggingCategory.Standard);
    }
}
