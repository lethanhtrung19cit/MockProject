namespace ProjectEcommerce.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(40)]
        public string Email { get; set; }

        [StringLength(40)]
        public string PassWord { get; set; }

        public int? Role { get; set; }
    }
}
