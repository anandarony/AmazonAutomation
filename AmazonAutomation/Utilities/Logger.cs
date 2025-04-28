using log4net;
using log4net.Core;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace AmazonAutomation.Utilities
{
    public  class Logger<T> where T : class
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Error(string message)
        {
            log.Error(message);
        }

        public static Microsoft.Extensions.Logging.ILogger<T> GetLogger()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("ConsoleApp", LogLevel.Debug)
                    .AddConsole();
            });

            Microsoft.Extensions.Logging.ILogger<T> logger = loggerFactory.CreateLogger<T>();
            return logger;
        }
    }
}
