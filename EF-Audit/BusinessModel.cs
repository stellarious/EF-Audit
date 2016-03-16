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
        public virtual DbSet<SkladiSet> SkladiSets { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TovarSet> TovarSets { get; set; }

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
                .HasForeignKey(e => e.ZakaziIdZakaz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.SkladiSets)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.ZakaziIdZakaz)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.TovarSets)
                .WithRequired(e => e.Test)
                .HasForeignKey(e => e.ZakaziIdZakaz)
                .WillCascadeOnDelete(false);
        }
    }
}
