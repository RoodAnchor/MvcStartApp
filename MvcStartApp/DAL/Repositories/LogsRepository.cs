using Microsoft.EntityFrameworkCore;

using MvcStartApp.DAL.Db;
using MvcStartApp.Models.Db;

namespace MvcStartApp.DAL.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly BlogContext _context;

        public LogsRepository(BlogContext context) 
        {
            _context = context;
        }

        public async Task AddEntry(Request request)
        {
            var entry = _context.Entry(request);

            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetEntries()
        {
            return await _context.Requests.OrderByDescending(x => x.Date).ToArrayAsync();
        }
    }
}
