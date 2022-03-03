using ProjectEcommerce.Models.DAO;
using ProjectEcommerce.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEcommerce.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            Session["Cart"] = null;
            ViewBag.listCarts= new CartModel().listCart(Session["IdCus"].ToString());
            return View();
        }
        public void addSession(string IdCart)
        {
             
            Session["Cart"]= IdCart+","+Session["Cart"];
             
        }
        public void updateNumber(int IdCart, int Number)
        {
            new CartModel().updateCart(IdCart, Number);
        }
        public void deleteCart(int IdCart)
        {
            new CartModel().deleteCart(IdCart);
        }
        public ActionResult buyProduct(string Address)
        {
            List<string> listIdCart = Session["Cart"].ToString().Split(',').ToList();
            for (int i=0;i<listIdCart.Count-1;i++)
            {
                List<Order> listOrders = new OrderModel().listOrder(int.Parse(listIdCart[i].ToString()));
                
                foreach (var item in listOrders)
                {                     
                    new OrderModel().addOrder(item.IdCus, item.IdPro, item.Number, item.SumPrice*item.Number, Address);
                }
                new CartModel().deleteCart(int.Parse(listIdCart[i]));
            }
            ViewBag.listCarts = new CartModel().listCart(Session["IdCus"].ToString());

            return View("Index");
        }
    }
}