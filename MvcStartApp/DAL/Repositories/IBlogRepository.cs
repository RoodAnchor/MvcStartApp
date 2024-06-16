using MvcStartApp.Models.Db;

namespace MvcStartApp.DAL.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
