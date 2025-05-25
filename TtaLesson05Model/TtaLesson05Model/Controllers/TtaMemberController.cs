using Microsoft.AspNetCore.Mvc;
using TtaLesson05Model.Models.Datamodle;

namespace TtaLesson05Model.Controllers
{
    public class TtaMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TtaGetMember()
        {
            var Ttamember = new TtaMember();
            Ttamember.TtaMemberId = Guid.NewGuid().ToString();
            Ttamember.TtaUsersName = "Tien Anh";
            Ttamember.TtaFullName = "Tran Tien Anh";
            Ttamember.TtaPassword = "2003@";
            Ttamember.TtaEmail = "tienanhtran755@gmail.com";
            ViewBag.member = Ttamember;
            return View();
        }
        public IActionResult TtaGetMembers()
        {
            List<TtaMember> members = new List<TtaMember>()
        {
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member1", TtaFullName = "Thanh viên 1", TtaPassword ="123456", TtaEmail = "tv1@gmail.com"},
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member1", TtaFullName = "Thanh viên 1", TtaPassword ="123456", TtaEmail = "tv1@gmail.com"},
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member1", TtaFullName = "Thanh viên 1", TtaPassword ="123456", TtaEmail = "tv1@gmail.com"},
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member1", TtaFullName = "Thanh viên 1", TtaPassword ="123456", TtaEmail = "tv1@gmail.com"},
            new TtaMember{TtaMemberId = Guid.NewGuid().ToString(), TtaUsersName = "member1", TtaFullName = "Thanh viên 1", TtaPassword ="123456", TtaEmail = "tv1@gmail.com"},
        };
            ViewBag.members = members;
            return View();
        }

    }
}
