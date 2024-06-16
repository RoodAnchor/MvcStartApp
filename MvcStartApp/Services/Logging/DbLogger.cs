using MvcStartApp.DAL.Repositories;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Services.Logging
{
    public class DbLogger : ILogger
    {
        private readonly ILogsRepository _logsRepository;

        public DbLogger(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public async Task WriteEntry(String message)
        {
            Request request = new Request();
            request.Id = Guid.NewGuid();
            request.Date = DateTime.Now;
            request.Url = message;

            await _logsRepository.AddEntry(request);
        }
    }
}
