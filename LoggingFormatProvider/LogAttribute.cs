using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupportEngine.Logging.LoggingFormatProvider
{
    public sealed class LogAttribute
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public LogAttribute()
        { }

        public LogAttribute(string name)
        {
            Name = name;
        }

        public LogAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
