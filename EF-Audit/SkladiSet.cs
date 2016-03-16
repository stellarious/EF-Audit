namespace EF_Audit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkladiSet")]
    public partial class SkladiSet
    {
        [Key]
        public int IdSklad { get; set; }

        [Required]
        public string Name { get; set; }

        public int ZakaziIdZakaz { get; set; }

        public virtual Test Test { get; set; }
    }
}
