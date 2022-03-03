using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEcommerce.Models.DAO;
using ProjectEcommerce.Models.EF;
namespace ProjectEcommerce.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index(string id)
        {
            Session["Id"] = id;
            Session["IdCus"] = null;
            
            return View();
        }
        public ActionResult Login(Account account)
        {
            
            if (new AccountModel().checkLogin(account.Email, account.PassWord)==1)
            {
                Session["IdCus"] = new AccountModel().IdCus(account.Email);
                 return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("SessionLogin", "Tên đăng nhập hoặc mật khẩu không đúng");
                return View("Index");
            }
            
        }
    }
}