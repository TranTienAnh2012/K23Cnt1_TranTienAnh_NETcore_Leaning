using Microsoft.AspNetCore.Mvc;

namespace Ttalession02.Controllers
{
    public class TtaProductController : Controller
    {
        public IActionResult TtaIndex()
        {
            ViewData["messageData"] = "Dữ liệu từ ViewData";
            ViewBag.messageData = "Dữ liệu từ ViewBag";
            TempData["messageData"] = "Dữ liệu từ TempData";
            return View();
        }
   

    }
}
