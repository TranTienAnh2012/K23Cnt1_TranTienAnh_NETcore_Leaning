using HomeworkDay03.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkDay03.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<TtaAccount> accounts = new List<TtaAccount>
            {
                new TtaAccount ()
                {
                    Id = 1,
                    Name = "Tran Tien Anh",
                    Email = "tienanhtran755@gmail.com",
                    Phone="0387742492",
                    Address = "Ninh Binh",
                    Avatar= Url.Content("~/img/03.jpg"),
                    Gender= 1 ,
                    Bio= "my name is small",
                    Birthday=new DateTime(2005,12,20)
                },
                new TtaAccount()
                {
                    Id = 2,
                    Name = "Nguyen Anh Mai",
                    Email = "tienanhtran755@gmail.com",
                    Phone="0387742492",
                    Address = "Ninh Binh",
                    Avatar= Url.Content("~/img/02.jpg"),
                    Gender= 1 ,
                    Bio= "my name is small",
                    Birthday=new DateTime(2005,12,20)
                },
                new TtaAccount()
                {
                    Id = 3,
                    Name = "Nguyen Thuy Mai",
                    Email = "tienanhtran755@gmail.com",
                    Phone="0387742492",
                    Address = "Ninh Binh",
                    Avatar= Url.Content("~/img/01.jpg"),
                    Gender= 1 ,
                    Bio= "my name is small",
                    Birthday=new DateTime(2005,12,20)
                }

            };
            ViewBag.Accounts = accounts;
            return View();
        }
        //Dinh nghia url va nam cho action
        [Route("ho-so-cua-toi", Name = "profile")]
        public IActionResult TtaProfile(int id)
        {
            // Khởi tạo danh sách các tài khoản
            List<TtaAccount> accounts = new List<TtaAccount>()
            {
                new TtaAccount()
                {
                    Id = 1,
                    Name = "Tran Tien Anh",
                    Email = "tienanhtran755@gmail.com",
                    Phone = "0387742492",
                    Address = "Ninh Binh",
                    Avatar = Url.Content("~/img/03.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 12, 20)
                },
                new TtaAccount()
                {
                    Id = 2,
                    Name = "Nguyen Anh Mai",
                    Email = "tienanhtran755@gmail.com",
                    Phone = "0387742492",
                    Address = "Ninh Binh",
                    Avatar = Url.Content("~/img/02.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 12, 20)
                },
                new TtaAccount()
                {
                    Id = 3,
                    Name = "Nguyen Thuy Mai",
                    Email = "tienanhtran755@gmail.com",
                    Phone = "0387742492",
                    Address = "Ninh Binh",
                    Avatar = Url.Content("~/img/01.jpg"),
                    Gender = 1,
                    Bio = "My name is small",
                    Birthday = new DateTime(2005, 12, 20)
                }
            };

                    // Tìm account theo id
                    TtaAccount account = accounts.FirstOrDefault(ac => ac.Id == id);

                    if (account == null)
                    {
                        return NotFound(); // hoặc RedirectToAction("Index")
                    }

                    // Gửi đối tượng qua View
                    ViewBag.Account = account;
                    return View();
                }

            }
        }
