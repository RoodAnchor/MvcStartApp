using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStartApp.DAL.Repositories;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        public UsersController(IBlogRepository blogRepository) 
        {
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _blogRepository.GetUsers();

            return View(users);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            await _blogRepository.AddUser(user);

            return View(user);
        }
    }
}
