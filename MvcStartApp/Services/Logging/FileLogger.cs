using MvcStartApp.Utils;

namespace MvcStartApp.Services.Logging
{
    public class FileLogger : ILogger
    {
        public async Task WriteEntry(string message)
        {
            var logPath = GetLogPath();
            var file = FSTools.CreateFile(logPath);
            var text = $"[{DateTime.Now}] {message}";

            while (FSTools.IsFileLocked(file)) continue;

            using (var sw = file.AppendText())
            {
                sw.WriteLine(text);
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
