namespace ProjectEcommerce.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [Key]
        public int IdCart { get; set; }

        public int? IdCus { get; set; }

        public int? IdPro { get; set; }

        public int? Number { get; set; }
    }
}
