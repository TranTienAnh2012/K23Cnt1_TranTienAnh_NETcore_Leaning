using lession01.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lession01.mvc.Controllers
{
    public class TtaHomeController : Controller
    {
        private readonly ILogger<TtaHomeController> _logger;

        public TtaHomeController(ILogger<TtaHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult TtaIndex()
        {
            return View();
        }

        public IActionResult TtaPrivacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
