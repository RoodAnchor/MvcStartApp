using MvcStartApp.Services.Logging.Loggers;

namespace MvcStartApp.Services.Logging.Providers
{
    public class FileLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger();
        }

        public void Dispose() { }
    }
}
