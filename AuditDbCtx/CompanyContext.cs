using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFramework.Auditing;

namespace EF_Audit
{
	public class CompanyContext : AuditDbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Bank> Banks { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Storage> Storages { get; set; }

		public DbSet<ClientAudit> ClientAudits { get; set; }
		public DbSet<BankAudit> BankAudits { get; set; }
		public DbSet<ProductAudit> ProductAudits { get; set; }
		public DbSet<OrderAudit> OrderAudits { get; set; }
		public DbSet<StorageAudit> StorageAudits { get; set; }
		public CompanyContext()
			: base("EF_Audit.CompanyContext")
		{
		}
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			AuditDbContext.RegisterAuditType(typeof(Client), typeof(ClientAudit));
			AuditDbContext.RegisterAuditType(typeof(Bank), typeof(BankAudit));
			AuditDbContext.RegisterAuditType(typeof(Order), typeof(OrderAudit));
			AuditDbContext.RegisterAuditType(typeof(Storage), typeof(StorageAudit));
			AuditDbContext.RegisterAuditType(typeof(Product), typeof(ProductAudit));
		}

	}
}
