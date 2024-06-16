using Microsoft.AspNetCore.Mvc;
using MvcStartApp.DAL.Repositories;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogsRepository _logsRepository;

        public LogsController(ILogsRepository logsRepository) 
        {
            _logsRepository = logsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _logsRepository.GetEntries();

            return View(logs);
        }
    }
}
