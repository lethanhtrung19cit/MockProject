using ProjectEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEcommerce.Models.DAO;

namespace ProjectEcommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.listProduct = new ProductModel().listProducts();
            return View();
        }
        public ActionResult SearchProduct(string NameProduct)
        {
            ViewBag.listSearch = new ProductModel().SearchProduct(NameProduct);
            return View();
        }
        public void AddCart(string IdCus, string IdPro, int Amount)
        {
            int IdCart = new CartModel().checkIdCart(int.Parse(IdCus), int.Parse(IdPro));
            if (IdCart == 1)

                new CartModel().addCart(IdCus, IdPro, Amount);
            else

                new CartModel().updateCart(IdCart, Amount+new CartModel().getAmount(IdCart));
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}