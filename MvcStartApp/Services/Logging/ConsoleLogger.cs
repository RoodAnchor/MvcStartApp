namespace MvcStartApp.Services.Logging
{
    public class ConsoleLogger : ILogger
    {
        public async Task WriteEntry(string message)
        {
            var text = $"[{DateTime.Now}] {message}";

            Console.WriteLine(text);
        }
    }
}
