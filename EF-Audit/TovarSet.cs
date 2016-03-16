namespace EF_Audit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TovarSet")]
    public partial class TovarSet
    {
        [Key]
        public int IdTovar { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Csena { get; set; }

        public int ZakaziIdZakaz { get; set; }

        public virtual Test Test { get; set; }
    }
}
