namespace ProjectEcommerce.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public Order(int idCus, int idPro, int number, double sumPrice)
        {
            IdCus = idCus;
            IdPro = idPro;
            Number = number;
            SumPrice = sumPrice;
        }

        public Order(int idOrder, string nameCus, string codePro, string namePro, float price, int number, double sumPrice, string address)
        {
            NameCus = nameCus;
            CodePro = codePro;
            NamePro = namePro;
            Price = price;
            Number = number;
            SumPrice = sumPrice;
            Address = address;
            IdOrder = idOrder;
        }

        [Key]
        public int IdOrder { get; set; }
        public string NameCus { get; set; }

        public string CodePro { get; set; }
        public string NamePro { get; set; }
        public float Price { get; set; }
        public int Number { get; set; }
        public double SumPrice { get; set; }

        public int IdPro { get; set; }

         public int IdCus { get; set; }



        [Column(TypeName = "ntext")]
        public string Address { get; set; }

        public int? Status { get; set; }
    }
}
