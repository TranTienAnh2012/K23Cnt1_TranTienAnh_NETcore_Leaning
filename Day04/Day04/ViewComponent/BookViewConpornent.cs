using Day04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day04.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();
        public IViewComponentResult Invoke()
        {
            var books = book.GetBooksList();
            return View(books); // tìm view Default.cshtml
        }
    }
}
