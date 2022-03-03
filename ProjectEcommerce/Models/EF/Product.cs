namespace ProjectEcommerce.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public Product(int idPro, string CodePro, string NamePro, float Price, int Amount, string Image)
        {
            this.CodePro = CodePro;
            this.NamePro = NamePro;
            this.Price = Price;
            this.Amount = Amount;
            this.Image = Image;
            IdPro = idPro;
        }
        [Key]
        public int IdPro { get; set; }

        [StringLength(10)]
        public string CodePro { get; set; }

        [Column(TypeName = "ntext")]
        public string NamePro { get; set; }

        public double Price { get; set; }

        public int? Amount { get; set; }
        public string Image { get; set; }
    }
}
