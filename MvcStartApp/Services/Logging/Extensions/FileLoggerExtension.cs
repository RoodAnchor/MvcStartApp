using MvcStartApp.Services.Logging.Providers;

namespace MvcStartApp.Services.Logging.Extensions
{
    public static class FileLoggerExtension
    {
        public static ILoggingBuilder AddFileLogger(this ILoggingBuilder builder)
        {
            builder.AddProvider(new FileLoggerProvider());

            return builder;
        }
    }
}
