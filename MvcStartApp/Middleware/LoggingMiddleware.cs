using MvcStartApp.DAL.Repositories;
using MvcStartApp.Services.Logging;

namespace MvcStartApp.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogsRepository _logsRepository;
        private readonly IEnumerable<Services.Logging.ILogger> _loggers;

        public LoggingMiddleware(
            RequestDelegate next, 
            ILogsRepository logsRepository, 
            IEnumerable<Services.Logging.ILogger> loggers)
        {
            _next = next;
            _logsRepository = logsRepository;
            _loggers = loggers;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var message = $"http://{context.Request.Host.Value}{context.Request.Path}";

            foreach (var log in _loggers)
                await log.WriteEntry(message);

            await _next.Invoke(context);
        }
    }
}
