using HomeworkDay03.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkDay03.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult TtaSanPham()
        {
            List<TtaSanPham> accountsSp = new List<TtaSanPham>
            {
                new TtaSanPham()
                {
                    IdSp = 1,
                    NameSp = "Sach English B1",
					 Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/04.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new TtaSanPham()
                {
                    IdSp = 2,
                    NameSp = "Sach English B1",
					Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/05.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new TtaSanPham()
                {
                    IdSp = 3,
                    NameSp = "Sach English B1",
					Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/06.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new TtaSanPham()
                {
                    IdSp = 4,
                    NameSp = "Sach English B1",
					 Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/07.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new TtaSanPham()
                {
                    IdSp = 5,
                    NameSp = "Sach English B1",
					Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/08.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new TtaSanPham()
                {
                    IdSp = 6,
                    NameSp = "Sach English B1",
				   Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/09.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                }
            };

            // ✅ Truyền danh sách sang View
            ViewBag.accounts = accountsSp;

            return View();
        }

        [Route("Chi-tier-san-pham", Name = "sanPham")]
        public IActionResult TtaChiTietSanPham(int idsp)
        {
            List<TtaSanPham> sanPhams = new List<TtaSanPham>() {
			  new TtaSanPham()
                {
	                IdSp = 1,
	                NameSp = "Sach English B1",
	                Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
	                AvatarSp = Url.Content("~/img/04.jpg"),
	                TrangThai = "Tot",
	                BioSp = "my name is small",
	                NgayDang = new DateTime(2025, 10, 22),
                },
				new TtaSanPham()
                {
                    IdSp = 2,
                    NameSp = "Sach English B1",
					 Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/05.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new TtaSanPham()
                {
                    IdSp = 3,
                    NameSp = "Sach English B1",
				 Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/06.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new TtaSanPham()
                {
                    IdSp = 4,
                    NameSp = "Sach English B1",
			Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/07.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new TtaSanPham()
                {
                    IdSp = 5,
                    NameSp = "Sach English B1",
					 Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/08.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                },
                new TtaSanPham()
                {
                    IdSp = 6,
                    NameSp = "Sach English B1",
					 Gia = "300000",           // Giá gốc
                    GiaKhuyenMai = "250000", // Giá đã giảm
                    MoTa = "tot",
                    AvatarSp = Url.Content("~/img/09.jpg"), // Updated image path
                    TrangThai = "Tot",
                    BioSp = "my name is small",
                    NgayDang = new DateTime(2025, 10, 22),
                }
            };

            // Tìm sản phẩm theo id
            TtaSanPham sanpham = sanPhams.FirstOrDefault(ac => ac.IdSp == idsp);

            if (sanpham == null)
            {
                return NotFound(); // hoặc chuyển hướng, hoặc thông báo lỗi
            }

            // Gửi sản phẩm tìm được sang view
            ViewBag.SanPham = sanpham;

            return View();
        }
    }
}
