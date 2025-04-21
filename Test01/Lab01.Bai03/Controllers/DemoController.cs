using Microsoft.AspNetCore.Mvc;

namespace Lab01.Bai03.Controllers
{
	public class DemoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
