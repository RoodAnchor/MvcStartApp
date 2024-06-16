namespace MvcStartApp.Services.Logging
{
    public interface ILogger
    {
        public Task WriteEntry(string message);
    }
}
