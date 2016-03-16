namespace EF_Audit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientSet")]
    public partial class ClientSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientSet()
        {
            BankSets = new HashSet<BankSet>();
        }

        [Key]
        public int IdClient { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string Tel { get; set; }

        public int ZakaziIdZakaz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankSet> BankSets { get; set; }

        public virtual Test Test { get; set; }
    }
}
