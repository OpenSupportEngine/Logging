using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupportEngine.Logging.LoggingFormatProvider;

namespace OpenSupportEngine.Logging.LoggingProvider
{
    public class FileLoggingProvider : ILoggingProvider
    {
        private readonly static List<LogAttribute> AttributeList =
            new List<LogAttribute>()
            {
                new LogAttribute(nameof(CommonLogAttributes.Timestamp))
            };

        public ILoggingFormatProvider FormatProvider
        {
            get { return formatProvider; }
        }
        public bool IsCrashResistent { get; } = true;
        public string FilePath { get; private set; }

        private ILoggingFormatProvider formatProvider =
            new StandardLoggingFormatProvider();

        public FileLoggingProvider(string path, bool append)
        {
            FilePath = path;

            var logDirectory = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(logDirectory))
            {
                throw new DirectoryNotFoundException(
                    string.Format(
                        "Log folder \"{0}\" not found.",
                        logDirectory
                        )
                    );
            }

            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
        }

        public void StartLog()
        {
            WriteEntry(LoggingAction.StartLog, AttributeList);
        }

        public void FinishLog()
        {
            WriteEntry(LoggingAction.EndLog, AttributeList);
        }

        public void LogMessage(string message, LoggingCategory category = LoggingCategory.Standard)
        {
            if (Logger.IsLoggingEnabled && Logger.IsCategoryEnabled(category))
            {
                var attributes = AttributeList.ToList();
                attributes.Add(new LogAttribute()
                {
                    Name = nameof(CommonLogAttributes.Message),
                    Value = message

                });

                WriteEntry(LoggingAction.Entry, attributes);
            }
        }

        private void WriteEntry(LoggingAction action, List<LogAttribute> attributes)
        {
            var msg = FormatProvider.FormatLogEntry(
                LoggingAction.Entry,
                attributes
                ).ToString();
            WriteLine(msg);
        }

        private void WriteLine(string message)
        {
            using (var stream = new StreamWriter(FilePath, true))
                stream.Write(message + Environment.NewLine);
        }
    }
}
