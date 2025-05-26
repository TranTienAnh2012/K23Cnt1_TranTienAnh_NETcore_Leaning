using Microsoft.AspNetCore.Mvc;
using TtaLesson05Model.Models.Datamodle;

namespace TtaLesson05Model.Controllers
{
    public class TtaManageMemberController : Controller
    {
        // Danh sách static các thành viên
        public static readonly List<TtaMember> members = new List<TtaMember>()
        {
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member1", TtaFullName = "Thành viên 1", TtaPassword ="123456", TtaEmail = "tv1@gmail.com"},
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member2", TtaFullName = "Thành viên 2", TtaPassword ="abcdef", TtaEmail = "tv2@gmail.com"},
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member3", TtaFullName = "Thành viên 3", TtaPassword ="qwerty", TtaEmail = "tv3@gmail.com"},
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member4", TtaFullName = "Thành viên 4", TtaPassword ="123abc", TtaEmail = "tv4@gmail.com"},
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member5", TtaFullName = "Thành viên 5", TtaPassword ="pass123", TtaEmail = "tv5@gmail.com"},
        };

        public IActionResult TtaGetmember02()
        {
            ViewBag.member02 = members;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TtaMember member)
        {
            member.TtaMemberId = Guid.NewGuid().ToString();
            members.Add(member);
            return RedirectToAction("TtaGetmember02");
        }
    }
}
