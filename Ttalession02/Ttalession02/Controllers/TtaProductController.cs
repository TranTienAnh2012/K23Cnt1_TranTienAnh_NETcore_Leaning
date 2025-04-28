using Microsoft.AspNetCore.Mvc;
using Ttalession02.Models;    // namespace chứa class TtaProducts

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

        public IActionResult GetProducts()
        {
            // khởi tạo một instance của products
            TtaProducts p = new TtaProducts
            {
                ProductId = 1,
                ProductName = "Tran Tien Anh",
                YearRelease = 2005,
                Price = 224.99    // dùng dấu . cho số thực
            };

            // đưa object này vào ViewBag và ViewData
            ViewBag.product = p;
            ViewData["productsVD"] = p;

            // trả về view action
            return View();
        }
        public IActionResult GetAllProducts()
        {
            List<TtaProducts> products = new List<TtaProducts>()
            {
                new TtaProducts() { ProductId = 1, ProductName="Trek 820 - 2016", YearRelease=2016, Price=379.99},
                new TtaProducts() { ProductId = 2, ProductName="Ritchay Timberwolf Frameset - 2016", YearRelease=2016, Price=749.99},
                new TtaProducts() { ProductId = 3, ProductName="Surly Wednesday Frameset - 2016", YearRelease=2016, Price=999.99},
                new TtaProducts() { ProductId = 4, ProductName="Trek Fuel EX 8 29 - 2016", YearRelease=2016, Price=2899.99},
                new TtaProducts() { ProductId = 5, ProductName="Heller Shagamaw Frame - 2016", YearRelease=2016, Price=1320.99},
                new TtaProducts() { ProductId = 6, ProductName="Surly Ice Cream Truck Frameset - 2016", YearRelease=2016, Price=469.99},
                new TtaProducts() { ProductId = 7, ProductName="Trek Slash 8 27.5 - 2016", YearRelease=2016, Price=3999.99},
                new TtaProducts() { ProductId = 8, ProductName="Trek Remedy 29 Carbon Frameset - 2016", YearRelease=2016, Price=1799.99},
                new TtaProducts() { ProductId = 9, ProductName="Trek Conduit - 2016", YearRelease=2016, Price=2999.99},
                new TtaProducts() { ProductId = 10, ProductName="Surly Straggler - 2016", YearRelease=2016, Price=1549.00},
                new TtaProducts() { ProductId = 11, ProductName="Surly Straggler 650b - 2016", YearRelease=2016, Price=1680.99},
                new TtaProducts() { ProductId = 12, ProductName="Electra Townie Original 21D - 2016", YearRelease = 2016, Price = 549.99},
                new TtaProducts() { ProductId = 13, ProductName="Electra Cruiser 1 (24-Inch) - 2016", YearRelease = 2016, Price = 269.99},
                new TtaProducts() { ProductId = 14, ProductName="Electra Girl's Hawaii 1 (16-inch) - 2015/2016", YearRelease = 2016, Price = 269.99},
            };

            ViewBag.products = products;  // <<< sửa đúng tên biến
            return View("GetAllProducts");    // <<< tên view là TtaProduct.cshtml
        }

    }
}
