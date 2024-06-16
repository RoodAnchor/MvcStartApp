using MvcStartApp.DAL.Repositories;
using MvcStartApp.Services.Logging;

namespace MvcStartApp.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogsRepository _logsRepository;

        public LoggingMiddleware(RequestDelegate next, ILogsRepository logsRepository)
        {
            _next = next;
            _logsRepository = logsRepository;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var fileLogger = new FileLogger();
            var consoleLogger = new ConsoleLogger();
            var dbLogger = new DbLogger(_logsRepository);
            var message = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value}{context.Request.Path}";

            await fileLogger.WriteEntry(message);
            await consoleLogger.WriteEntry(message);
            await dbLogger.WriteEntry($"http://{context.Request.Host.Value}{context.Request.Path}");

            await _next.Invoke(context);
        }
    }
}
