using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ttalesson07.Controllers
{
    public class TtaMemBerController : Controller
    {
        // GET: TtaMemBerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TtaMemBerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TtaMemBerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TtaMemBerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TtaMemBerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TtaMemBerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TtaMemBerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TtaMemBerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
