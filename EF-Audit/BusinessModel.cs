namespace EF_Audit
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BusinessModel : DbContext
    {
        public BusinessModel()
            : base("name=BusinessModel")
        {
        }

        public virtual DbSet<BankSet> BankSets { get; set; }
        public virtual DbSet<ClientSet> ClientSets { get; set; }
        public virtual DbSet<ProductSet> ProductSets { get; set; }
        public virtual DbSet<StorageSet> StorageSets { get; set; }
        public virtual DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientSet>()
                .HasMany(e => e.BankSets)
                .WithRequired(e => e.ClientSet)
                .HasForeignKey(e => e.ClientIdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.ClientSets)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.OrderIdOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.ProductSets)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.OrderIdOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.StorageSets)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.OrderIdOrder)
                .WillCascadeOnDelete(false);
        }
    }
}
