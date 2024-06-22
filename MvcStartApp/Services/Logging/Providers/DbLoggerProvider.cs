using MvcStartApp.DAL.Repositories;
using MvcStartApp.Services.Logging.Loggers;

namespace MvcStartApp.Services.Logging.Providers
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly ILogsRepository _logsRepository;
        public DbLoggerProvider(ILogsRepository logsRepository) 
        {
            _logsRepository = logsRepository;
        }

        public ILogger CreateLogger(String categoryName)
        {
            return new DbLogger(_logsRepository);
        }

        public void Dispose() { }
    }
}
