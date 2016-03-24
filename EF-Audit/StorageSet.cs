namespace EF_Audit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StorageSet")]
    public partial class StorageSet
    {
        [Key]
        public int IdStorage { get; set; }

        [Required]
        public string Name { get; set; }

        public int OrderIdOrder { get; set; }

        public virtual Test Test { get; set; }
    }
}
