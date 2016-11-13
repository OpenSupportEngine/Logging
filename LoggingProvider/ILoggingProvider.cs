using OpenSupportEngine.Logging.LoggingFormatProvider;

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
