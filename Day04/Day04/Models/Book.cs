using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Day04.Models

{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public string Image { get; set; }

        public float Price { get; set; }

        public int TotalPage { get; set; }

        public string Sumary { get; set; }
        //danh sach cac cuon sach (nhớ using System.Collections.Generic)
        public List<Book> GetBooksList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo ",
                    AuthorId = 1,
                    GenreId = 1,
                    Image= "~/img/products/04.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage =250,
                },
                new Book()
                {
                     Id = 2,
                    Title = "Chí Phèo ",
                    AuthorId = 1,
                    GenreId = 1,
                    Image= "~/img/products/05.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage =250,
                },
                new Book()
                {
                     Id = 3,
                    Title = "Chí Phèo ",
                    AuthorId = 1,
                    GenreId = 1,
                    Image= "~/img/products/06.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage =250,
                },
                new Book()
                {
                     Id = 4,
                    Title = "Chí Phèo ",
                    AuthorId = 1,
                    GenreId = 1,
                    Image= "~/img/products/05.jpg",
                    Price = 500000,
                    Sumary = "",
                    TotalPage =250,
                }

            };
            return books;
        }
        // chi tiết môt cuốn sách theo id ( nhớ using System.Linq)
        public Book GetBookId(int id)
        {
            Book book = this.GetBooksList().FirstOrDefault(b => b.Id == id);
            return book;
        }
        //SelectListItem Athors (using Microsoft.AspNetCore.Mvc.Rendering)
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value ="1" , Text=" Nam Cao "},
            new SelectListItem {Value="2", Text="Ngô Tất Tố"},
            new SelectListItem {Value="3", Text="Adamkhoom"},
            new SelectListItem {Value="4", Text="Thiền sư Thích Nhất Hạnh"}
        };
        // SelectListItem Genres
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value ="1" ,Text="Truyện Tranh" },
            new SelectListItem {Value ="2" ,Text="Văn Học Đương Đại" },
            new SelectListItem {Value ="3" ,Text="Phật Học Phổ Thông" },
            new SelectListItem {Value ="4" ,Text="Truyện Cười" },
        };
    }
}
