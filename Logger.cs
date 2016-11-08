using OpenSupportEngine.Logging.LoggingProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupportEngine.Logging
{
    public static class Logger
    {
        public static ILoggingProvider LogProvider;
        public static bool IsLoggingEnabled
        {
            get { return isLoggingEnabled && LogProvider != null; }
            set { isLoggingEnabled = value; }
        }
        public static bool AreAllCategoriesEnabled { get; set; } = false;
        public static bool AreNonSetCategoriesEnabled { get; set; } = true;

        private static bool isLoggingEnabled;
        private static Dictionary<LoggingCategory, bool> loggingCategories =
            new Dictionary<LoggingCategory, bool>();
        
        public static void EnableCategory(LoggingCategory category, bool enable)
        {
            loggingCategories[category] = enable;
        }

        public static bool IsCategoryEnabled(LoggingCategory category)
        {
            if (AreAllCategoriesEnabled)
                return true;
            else if (loggingCategories.Keys.Contains(category))
                return loggingCategories[category];
            else
                return AreNonSetCategoriesEnabled;
        }
    }
}
