using Microsoft.AspNetCore.Mvc;

namespace Day04.Controllers
{
    public class My_layoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
