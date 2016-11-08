using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupportEngine.Logging.LoggingFormatProvider
{
    public interface ILoggingFormatProvider
    {
        List<CommonLogAttributes> SupportedDefaultValueAttributes { get; }

        object FormatLogEntry(LoggingAction action, List<LogAttribute> attributes);
    }
}
