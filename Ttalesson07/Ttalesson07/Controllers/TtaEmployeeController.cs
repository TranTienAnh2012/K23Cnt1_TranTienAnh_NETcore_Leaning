using Microsoft.AspNetCore.Mvc;
using Ttalesson07.Models;

namespace Ttalesson07.Controllers
{
    public class TtaEmployeeController : Controller
    {
        // Biến static giữ danh sách nhân viên
        private static List<TtaEmployee> ttaListEmployees = new List<TtaEmployee>()
        {
            new TtaEmployee() { TtaId = 1, TtaName = "Trần Tiến Anh", TtaBirthDay = new DateTime(2004, 12, 15), TtaEmail = "tienanhtran755@gmail.com", TtaPhone = "0387742492", TtaSalary = 3500000.0f, TtaStatus = 1 },
            new TtaEmployee() { TtaId = 2, TtaName = "Nguyễn Văn B", TtaBirthDay = new DateTime(2003, 5, 10), TtaEmail = "nguyenb@example.com", TtaPhone = "0912345678", TtaSalary = 4200000.0f, TtaStatus = 1 },
            new TtaEmployee() { TtaId = 3, TtaName = "Lê Thị C", TtaBirthDay = new DateTime(2002, 3, 22), TtaEmail = "c.le@example.com", TtaPhone = "0901234567", TtaSalary = 4000000.0f, TtaStatus = 0 },
            new TtaEmployee() { TtaId = 4, TtaName = "Phạm Văn D", TtaBirthDay = new DateTime(2001, 8, 5), TtaEmail = "d.pham@example.com", TtaPhone = "0987654321", TtaSalary = 4600000.0f, TtaStatus = 1 },
            new TtaEmployee() { TtaId = 5, TtaName = "Ngô Thị E", TtaBirthDay = new DateTime(2005, 11, 30), TtaEmail = "e.ngo@example.com", TtaPhone = "0938123456", TtaSalary = 3900000.0f, TtaStatus = 1 }
        };

        
        public IActionResult TtaIndex()
        {
            return View(ttaListEmployees);
        }

        // GET: Hiển thị form tạo mới
        public IActionResult TtaCreate()
        {
            var model = new TtaEmployee();
            return View(model);
        }

        // POST: Thêm mới nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TtaCreate(TtaEmployee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Thêm vào danh sách
                    ttaListEmployees.Add(model);
                    return RedirectToAction(nameof(TtaIndex));
                }

                // Nếu model không hợp lệ
                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi tạo mới nhân viên.");
                return View(model);
            }
        }
        public IActionResult TtaEdit(int id)
        {
            var employee = ttaListEmployees.FirstOrDefault(e => e.TtaId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TtaEdit(int id, TtaEmployee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existing = ttaListEmployees.FirstOrDefault(e => e.TtaId == id);
                    if (existing == null)
                    {
                        return NotFound();
                    }

                    // Cập nhật thông tin
                    existing.TtaName = model.TtaName;
                    existing.TtaBirthDay = model.TtaBirthDay;
                    existing.TtaEmail = model.TtaEmail;
                    existing.TtaPhone = model.TtaPhone;
                    existing.TtaSalary = model.TtaSalary;
                    existing.TtaStatus = model.TtaStatus;

                    return RedirectToAction(nameof(TtaIndex));
                }

                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật.");
                return View(model);
            }
        }
        public IActionResult TtaDetails(int id)
        {
            var employee = ttaListEmployees.FirstOrDefault(e => e.TtaId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // GET: Hiển thị xác nhận xóa
        public IActionResult TtaDelete(int id)
        {
            var employee = ttaListEmployees.FirstOrDefault(e => e.TtaId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Xóa nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TtaDelete(int id, IFormCollection collection)
        {
            try
            {
                var employee = ttaListEmployees.FirstOrDefault(e => e.TtaId == id);
                if (employee != null)
                {
                    ttaListEmployees.Remove(employee);
                }
                return RedirectToAction(nameof(TtaIndex));
            }
            catch
            {
                return View();
            }
        }


    }
}
