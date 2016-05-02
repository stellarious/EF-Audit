using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TrackerEnabledDbContext;

namespace EF_Audit
{
	class CompanyContext : TrackerContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Bank> Banks { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Storage> Storages { get; set; }
	}
}
