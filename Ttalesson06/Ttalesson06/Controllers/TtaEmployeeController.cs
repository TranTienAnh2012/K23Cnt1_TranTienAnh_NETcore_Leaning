using Microsoft.AspNetCore.Mvc;
using Ttalesson06.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ttalesson06.Controllers
{
    public class TtaEmployeeController : Controller
    {
        // Biến static giữ danh sách học viên
        private static List<TtaEmployee> ttaEmployees = new List<TtaEmployee>()
        {
            new TtaEmployee()
            {
                TtaId = 1,
                TtaName = "Trần Tiến Anh",
                TtaBirthDay = new DateTime(2004, 12, 15),
                TtaEmail = "tienanhtran755@gmail.com",
                TtaPhone = "0387742492",
                TtaSalary = 3500000.0f,
                TtaStatus = 1
            },
            new TtaEmployee()
            {
                TtaId = 2,
                TtaName = "Nguyễn Văn B",
                TtaBirthDay = new DateTime(2003, 5, 10),
                TtaEmail = "nguyenb@example.com",
                TtaPhone = "0912345678",
                TtaSalary = 4200000.0f,
                TtaStatus = 1
            },
            new TtaEmployee()
            {
                TtaId = 3,
                TtaName = "Lê Thị C",
                TtaBirthDay = new DateTime(2002, 3, 22),
                TtaEmail = "c.le@example.com",
                TtaPhone = "0901234567",
                TtaSalary = 4000000.0f,
                TtaStatus = 0
            },
            new TtaEmployee()
            {
                TtaId = 4,
                TtaName = "Phạm Văn D",
                TtaBirthDay = new DateTime(2001, 8, 5),
                TtaEmail = "d.pham@example.com",
                TtaPhone = "0987654321",
                TtaSalary = 4600000.0f,
                TtaStatus = 1
            },
            new TtaEmployee()
            {
                TtaId = 5,
                TtaName = "Ngô Thị E",
                TtaBirthDay = new DateTime(2005, 11, 30),
                TtaEmail = "e.ngo@example.com",
                TtaPhone = "0938123456",
                TtaSalary = 3900000.0f,
                TtaStatus = 1
            }

            // ... các học viên khác
        };

        // Trả về danh sách tất cả học viên
     
        public IActionResult TtaIndex()
        {
            return View(ttaEmployees);
        }


        // Hiển thị form tạo mới học viên
        [HttpGet]
        public IActionResult TtaCreate()
        {
            return View();
        }

        // Xử lý tạo mới học viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TtaCreate(TtaEmployee newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return View(newEmployee);
            }

            newEmployee.TtaId = ttaEmployees.Any() ? ttaEmployees.Max(e => e.TtaId) + 1 : 1;
            ttaEmployees.Add(newEmployee);

            return RedirectToAction("TtaIndex");
        }

        // Chi tiết học viên theo id
        public IActionResult GetEmployee(int id)
        {
            var employee = ttaEmployees.FirstOrDefault(e => e.TtaId == id);
            if (employee == null)
            {
                return NotFound(); // Nếu không có học viên với id đó
            }
            return View(employee); // Truyền model sang View
        }

    }
}
