using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;

namespace MvcStartApp.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Feedback feedback)
        {
            return StatusCode(200, $"{feedback.From}, спасибо за отзыв!");
        }
    }
}
