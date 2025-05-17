using Microsoft.AspNetCore.Mvc;
using Day04.Models;
using System.Collections.Generic;
using System.Linq;

namespace Day04.Controllers
{
    public class TtaBookController : Controller
    {
        // Sử dụng danh sách tĩnh để lưu sách, thay vì gọi GetBooksList mỗi lần (cứng nhắc)
        private static List<Book> books = new Book().GetBooksList();

        protected Book book = new Book();
        [HttpGet]
        public IActionResult TtaIndex()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            return View(books);
        }

        [HttpPost]
        public IActionResult TtaIndex(int? AuthorId, int? GenreId)
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;

            var filteredBooks = books.AsEnumerable();

            if (AuthorId.HasValue && AuthorId.Value != 0)
            {
                filteredBooks = filteredBooks.Where(b => b.AuthorId == AuthorId.Value);
            }

            if (GenreId.HasValue && GenreId.Value != 0)
            {
                filteredBooks = filteredBooks.Where(b => b.GenreId == GenreId.Value);
            }

            return View(filteredBooks);
        }


        [HttpGet]
        public IActionResult TtaCreate()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            return View(new Book());
        }

        [HttpPost]
        public IActionResult TtaCreate(Book newBook)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.authors = book.Authors;
                ViewBag.genres = book.Genres;
                return View(newBook);
            }

            // Gán ID tự động tăng
            newBook.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            books.Add(newBook);

            return RedirectToAction("TtaIndex");
        }

        [HttpGet]
        public IActionResult TtaEdit(int id)
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            var model = books.FirstOrDefault(b => b.Id == id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        public IActionResult TtaEdit(Book updatedBook)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.authors = book.Authors;
                ViewBag.genres = book.Genres;
                return View(updatedBook);
            }

            var existingBook = books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (existingBook == null) return NotFound();

            existingBook.Title = updatedBook.Title;
            existingBook.AuthorId = updatedBook.AuthorId;
            existingBook.GenreId = updatedBook.GenreId;
            existingBook.Price = updatedBook.Price;
            existingBook.TotalPage = updatedBook.TotalPage;
            existingBook.Sumary = updatedBook.Sumary;
            existingBook.Image = updatedBook.Image;

            return RedirectToAction("TtaIndex");
        }

        [HttpGet]
        public IActionResult TtaDelete(int id)
        {
            var bookToDelete = books.FirstOrDefault(b => b.Id == id);
            if (bookToDelete == null) return NotFound();

            books.Remove(bookToDelete);
            return RedirectToAction("TtaIndex");
        }

        public PartialViewResult PopularBook()
        {
            var books = book.GetBooksList();
            return PartialView(books);
        }
    }
}
