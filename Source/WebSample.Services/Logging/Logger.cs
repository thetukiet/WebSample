using System;
using System.Linq;
using log4net;
using log4net.Appender;

namespace WebSample.Services.Logging
{
    public class Logger : ILogger
    {
        public void Debug(object sender, string message)
        {
            GetLogger(sender).Debug(message);
            Flush();
        }

        public void Info(object sender, string message)
        {
            GetLogger(sender).Info(message);
            Flush();
        }

        public void Error(object sender, string message)
        { 
            GetLogger(sender).Error(message);
            Flush();
        }

        private ILog GetLogger(object sender)
        {
            return GetLogger(sender.GetType());
        }

        private ILog GetLogger(Type type)
        {
            return GetLogger(type.FullName);
        }

        private ILog GetLogger(string typeName)
        {
            return LogManager.GetLogger(typeName);
        }

        private void Flush()
        {
            var loggerRepository = LogManager.GetRepository();
            foreach (var buffered in loggerRepository.GetAppenders().OfType<BufferingAppenderSkeleton>())
            {
                buffered.Flush();
            }
        }
    }
}
