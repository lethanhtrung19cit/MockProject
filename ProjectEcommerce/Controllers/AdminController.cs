using ProjectEcommerce.Models;
using ProjectEcommerce.Models.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEcommerce.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult listOrder()
        {
            ViewBag.listOrder= new OrderModel().listOrderAdmin(0);
            return View();
        }
        public void Approval(int IdOrder, string CodePro, int Number)
        {
            new OrderModel().updateStatus(IdOrder, 1);
            new OrderModel().updateNumberPro(CodePro, Number);
        }
        public ActionResult listOrdering()
        {
            ViewBag.listOrder= new OrderModel().listOrderAdmin(1);
            return View();
        }
        public void ReturnGoods(int IdOrder)
        {
            new OrderModel().updateStatus(IdOrder, 2);
        }
        public ActionResult listOrdered()
        {
            ViewBag.listOrder= new OrderModel().listOrderAdmin(2);
            return View();
        }
        public ActionResult listProduct()
        {
            ViewBag.listProduct = new ProductModel().listProducts();
            return View();
        }
        public ActionResult addProduct(string CodePro, string NamePro, HttpPostedFileBase image, int Price, int Number)
        {
            var Extension = Path.GetExtension(image.FileName);
            string fileName = CodePro + "." + Extension;
             
            string path = Path.Combine(Server.MapPath("~/images/Product/"), fileName);
            string FileName = Url.Content(Path.Combine("~/images/Product/", fileName));
            image.SaveAs(path);
            new ProductModel().addProduct(CodePro, NamePro, FileName, Price, Number);
            ViewBag.listProduct = new ProductModel().listProducts();
            return View("listProduct");
        }
        public void updateProduct(int IdPro, string NamePro, float Price, int Number)
        {
            new ProductModel().updateProduct(IdPro, NamePro, Price, Number);
        }
        public void deleteProduct(int IdPro)
        {
            new ProductModel().deleteProduct(IdPro);
        }

    }
}