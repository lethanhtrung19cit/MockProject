using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEcommerce.Models.EF
{
    public class DetailCart
    {
        public int IdPro;
        public int IdCart;
        public string CodePro;
        public string NamePro;
        public string Image;
        public float Price;
        public int Number;

        public DetailCart(string codePro, string namePro, string image, float price, int number, int idPro, int idCart)
        {
            CodePro = codePro;
            NamePro = namePro;
            Image = image;
            Price = price;
            Number = number;
            IdPro = idPro;
            IdCart = idCart;
        }
    }
}