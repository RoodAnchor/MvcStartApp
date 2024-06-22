using MvcStartApp.DAL.Repositories;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Services.Logging.Loggers
{
    public class DbLogger : ILogger, IDisposable
    {
        private readonly ILogsRepository _logsRepository;

        public DbLogger(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public IDisposable? BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose() { }

        public Boolean IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, String> formatter)
        {
            if (eventId != -1) return;

            Request request = new Request();
            request.Id = Guid.NewGuid();
            request.Date = DateTime.Now;
            request.Url = formatter(state, null).Split(": ")[1];

            Task.Run(async () => 
            {
                await _logsRepository.AddEntry(request);
            });
        }
    }
}
