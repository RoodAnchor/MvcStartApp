using MvcStartApp.Utils;

namespace MvcStartApp.Services.Logging
{
    public class FileLogger : ILogger
    {
        public async Task WriteEntry(string message)
        {
            var logPath = GetLogPath();
            var file = FSTools.CreateFile(logPath);

            while (FSTools.IsFileLocked(file)) continue;

            using (var sw = file.AppendText())
            {
                sw.WriteLine(message);
            };
        }

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
