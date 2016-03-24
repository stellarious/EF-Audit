namespace EF_Audit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BankSet")]
    public partial class BankSet
    {
        [Key]
        public int IdBank { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        public string Acñount { get; set; }

        public int ClientIdClient { get; set; }

        public virtual ClientSet ClientSet { get; set; }
    }
}
