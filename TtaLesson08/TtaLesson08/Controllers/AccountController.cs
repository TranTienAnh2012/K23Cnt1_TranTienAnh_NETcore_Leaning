using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Ttalesson08.Models;

namespace Ttalesson08.Controllers
{
    public class TtaAccountController : Controller
    {
        // Danh sách tạm lưu tài khoản (static)
        public static List<TtaAccount> TtaAccounts = new List<TtaAccount>
        {
            new TtaAccount
            {
                TtaId = 1,
                TtaFulloName = "Nguyễn Văn A",
                TtaEmail = "vana@example.com",
                TtaPhone = "0986421127",
                TtaAddress = "Hà Nội",
                TtaAvata = "avatar1.png",
                TtaBirtday = new DateTime(1990, 5, 20),
                TtaGender = "Nam",
                TtaPassWord = "password1",
                TtaFacebook = "https://facebook.com/vana"
            },
            new TtaAccount
            {
                TtaId = 2,
                TtaFulloName = "Trần Thị B",
                TtaEmail = "thib@example.com",
                TtaPhone = "0981234567",
                TtaAddress = "Đà Nẵng",
                TtaAvata = "avatar2.png",
                TtaBirtday = new DateTime(1995, 10, 10),
                TtaGender = "Nữ",
                TtaPassWord = "password2",
                TtaFacebook = "https://facebook.com/thib"
            },
            new TtaAccount
            {
                TtaId = 3,
                TtaFulloName = "Lê Văn C",
                TtaEmail = "vanc@example.com",
                TtaPhone = "0977654321",
                TtaAddress = "TP.HCM",
                TtaAvata = "avatar3.png",
                TtaBirtday = new DateTime(1988, 3, 15),
                TtaGender = "Nam",
                TtaPassWord = "password3",
                TtaFacebook = "https://facebook.com/vanc"
            }
        };

        // GET: TtaIndex - Danh sách tài khoản
        public ActionResult TtaIndex()
        {
            return View(TtaAccounts);
        }

        // GET: TtaCreate - Form tạo mới
        public ActionResult TtaCreate()
        {
            return View(new TtaAccount());
        }
        // GET: TtaAccount/Details/5
        public ActionResult Details(int id)
        {
            var account = TtaAccounts.FirstOrDefault(a => a.TtaId == id);
            if (account == null)
                return NotFound();

            return View(account);
        }

        // POST: TtaCreate - Lưu tạo mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TtaCreate(TtaAccount account)
        {
            if (ModelState.IsValid)
            {
                account.TtaId = TtaAccounts.Count > 0 ? TtaAccounts.Max(a => a.TtaId) + 1 : 1;
                TtaAccounts.Add(account);
                return RedirectToAction(nameof(TtaIndex));
            }
            return View(account);
        }

        // GET: TtaEdit/5 - Form sửa tài khoản
        public ActionResult TtaEdit(int id)
        {
            var account = TtaAccounts.FirstOrDefault(a => a.TtaId == id);
            if (account == null)
                return NotFound();

            return View(account);
        }

        // POST: TtaEdit/5 - Lưu sửa tài khoản
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TtaEdit(int id, TtaAccount account)
        {
            if (ModelState.IsValid)
            {
                var existing = TtaAccounts.FirstOrDefault(a => a.TtaId == id);
                if (existing == null)
                    return NotFound();

                existing.TtaFulloName = account.TtaFulloName;
                existing.TtaEmail = account.TtaEmail;
                existing.TtaPhone = account.TtaPhone;
                existing.TtaAddress = account.TtaAddress;
                existing.TtaAvata = account.TtaAvata;
                existing.TtaBirtday = account.TtaBirtday;
                existing.TtaGender = account.TtaGender;
                existing.TtaPassWord = account.TtaPassWord;
                existing.TtaFacebook = account.TtaFacebook;

                return RedirectToAction(nameof(TtaIndex));
            }

            return View(account);
        }

        // GET: TtaDelete/5 - Form xóa tài khoản
        public ActionResult TtaDelete(int id)
        {
            var account = TtaAccounts.FirstOrDefault(a => a.TtaId == id);
            if (account == null) return NotFound();

            return View(account);
        }

        // POST: TtaDelete/5 - Xóa tài khoản
        [HttpPost, ActionName("TtaDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TtaDeleteConfirmed(int id)
        {
            var account = TtaAccounts.FirstOrDefault(a => a.TtaId == id);
            if (account == null) return NotFound();

            TtaAccounts.Remove(account);
            return RedirectToAction(nameof(TtaIndex));
        }

        // API Verify số điện thoại (có thể dùng ajax validate)
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string TtaPhone)
        {
            var isPhone = new Regex(@"^(\d{10}|\d{3}[-.]?\d{3}[-.]?\d{4})$");
            if (!isPhone.IsMatch(TtaPhone))
            {
                return Json($"Số điện thoại {TtaPhone} không đúng định dạng, VD: 0986421127 hoặc 098.421.1127");
            }
            return Json(true);
        }
    }
}
