using System.Collections.Generic;

namespace OpenSupportEngine.Logging.LoggingFormatProvider
{
    public interface ILoggingFormatProvider
    {
        List<CommonLogAttributes> SupportedDefaultValueAttributes { get; }

        object FormatLogEntry(LoggingAction action, List<LogAttribute> attributes);
    }
}
