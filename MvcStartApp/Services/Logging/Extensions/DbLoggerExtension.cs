using MvcStartApp.DAL.Repositories;
using MvcStartApp.Services.Logging.Providers;

namespace MvcStartApp.Services.Logging.Extensions
{
    public static class DbLoggerExtension
    {
        public static ILoggingBuilder AddDbLogger(
            this ILoggingBuilder builder)
        {
            var logsRepository = builder.Services.BuildServiceProvider().GetService<ILogsRepository>();

            builder.AddProvider(new DbLoggerProvider(logsRepository));
            return builder;
        }
    }
}
