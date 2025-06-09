using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Ttalesson08.Models;

namespace Ttalesson08.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        public ActionResult TtaIndex()
        {
            List<TtaAccount> ttaaccounts = new()
            {
                new()
                {
                    TtaId = 1,
                    TtaFulloName = "Nguyễn Văn A",
                    TtaEmail = "vana@example.com",
                    TtaPhone = "0986421127",
                    TtaAddress = "Hà Nội",
                    TtaAvata = "avatar1.png",
                    TtaBirtday = new(1990, 5, 20),
                    TtaGender = "Nam",
                    TtaPassWord = "password1",
                    TtaFacebook = "https://facebook.com/vana"
                },
                new()
                {
                    TtaId = 2,
                    TtaFulloName = "Trần Thị B",
                    TtaEmail = "thib@example.com",
                    TtaPhone = "0981234567",
                    TtaAddress = "Đà Nẵng",
                    TtaAvata = "avatar2.png",
                    TtaBirtday = new(1995, 10, 10),
                    TtaGender = "Nữ",
                    TtaPassWord = "password2",
                    TtaFacebook = "https://facebook.com/thib"
                },
                new()
                {
                    TtaId = 3,
                    TtaFulloName = "Lê Văn C",
                    TtaEmail = "vanc@example.com",
                    TtaPhone = "0977654321",
                    TtaAddress = "TP.HCM",
                    TtaAvata = "avatar3.png",
                    TtaBirtday = new(1988, 3, 15),
                    TtaGender = "Nam",
                    TtaPassWord = "password3",
                    TtaFacebook = "https://facebook.com/vanc"
                }
            };

            return View(ttaaccounts);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id) => View();

        // GET: AccountController/Create
        public ActionResult TtaCreate()
        {
            TtaAccount model = new TtaAccount();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TtaCreate(TtaAccount account)
        {
            if (ModelState.IsValid)
            {
                // Tăng ID tự động dựa trên danh sách tĩnh
                account.TtaId = TtaAccounts.Count > 0 ? TtaAccounts.Max(a => a.TtaId) + 1 : 1;

                // Thêm tài khoản mới vào danh sách
                TtaAccounts.Add(account);

                return RedirectToAction(nameof(TtaIndex));
            }

            return View(account);
        }

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

        // GET: AccountController/Edit/5
        public ActionResult TtaEdit(int id) => View();

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(TtaIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult TtaDelete(int id) => View();

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(TtaIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
