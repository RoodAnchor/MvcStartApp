namespace MvcStartApp.Services.Logging
{
    public class ConsoleLogger : ILogger
    {
        public async Task WriteEntry(string message)
        {
            Console.WriteLine(message);
        }
    }
}
