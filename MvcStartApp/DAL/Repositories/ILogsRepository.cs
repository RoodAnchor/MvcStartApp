using MvcStartApp.Models.Db;

namespace MvcStartApp.DAL.Repositories
{
    public interface ILogsRepository
    {
        Task AddEntry(Request request);
        Task<Request[]> GetEntries();
    }
}
