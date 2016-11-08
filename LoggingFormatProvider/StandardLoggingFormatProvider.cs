using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OpenSupportEngine.Logging.LoggingFormatProvider
{
    public class StandardLoggingFormatProvider : ILoggingFormatProvider
    {
        public virtual List<CommonLogAttributes> SupportedDefaultValueAttributes
        {
            get
            {
                return new List<CommonLogAttributes>()
                {
                    CommonLogAttributes.Timestamp
                };
            }
        }

        public object FormatLogEntry(LoggingAction action, List<LogAttribute> attributes)
        {
            var logEntry = string.Empty;

            logEntry = string.Format(
                "{0}:",
                action);

            foreach (var attribute in attributes)
            {
                var value = string.Empty;

                if (attribute.Value == null)
                    value = GetDefaultValue(attribute.Name);
                else
                    value = attribute.Value.ToString();

                logEntry += string.Format(
                    " {0}=\"{1}\";",
                    HttpUtility.HtmlEncode(attribute.Name),
                    HttpUtility.HtmlEncode(value)
                    );
            }

            return logEntry;
        }

        protected virtual string GetDefaultValue(string attributeName)
        {
            var value = string.Empty;

            switch (attributeName)
            {
                case nameof(CommonLogAttributes.Timestamp):
                    value = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                    break;
            }

            return value;
        }
    }
}
