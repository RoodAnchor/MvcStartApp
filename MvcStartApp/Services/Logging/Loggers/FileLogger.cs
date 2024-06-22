using MvcStartApp.Utils;

namespace MvcStartApp.Services.Logging.Loggers
{
    public class FileLogger : ILogger, IDisposable
    {
        static object _lock = new object();

        public IDisposable? BeginScope<TState>(TState state)
        {
            return this;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (eventId != -1) return;

            lock (_lock)
            {
                var logPath = GetLogPath();
                var file = FSTools.CreateFile(logPath);

                while (FSTools.IsFileLocked(file)) continue;

                using (var sw = file.AppendText())
                {
                    sw.WriteLine(formatter(state, null));
                };
            }
        }

        public void Dispose() { }

        private string GetLogPath()
        {
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            var logsPath = Path.Combine(appPath, "logs");
            var logName = $"RequestLog_{DateTime.Now.ToShortDateString()}.txt";

            FSTools.CreateFolder(logsPath);

            return Path.Combine(logsPath, logName);
        }
    }
}
