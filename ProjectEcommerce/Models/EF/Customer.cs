namespace ProjectEcommerce.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        public int IdCus { get; set; }

        [StringLength(10)]
        public string CodeCus { get; set; }

        [Column(TypeName = "ntext")]
        public string NameCus { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(40)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        public string Address { get; set; }

        [StringLength(12)]
        public string CMND { get; set; }
    }
}
