using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EF_Audit
{
	class CompanyContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Bank> Banks { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Storage> Storages { get; set; }
		public virtual DbSet<ChangeLog> ChangeLogs { get; set; }

		object GetPrimaryKeyValue(DbEntityEntry entry)
		{
			var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
			return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
		}

		public override int SaveChanges()
		{
			var modifiedEntities = ChangeTracker.Entries()
				.Where(p => p.State == EntityState.Modified).ToList();
			var now = DateTime.UtcNow;

			foreach (var change in modifiedEntities)
			{
				var entityName = change.Entity.GetType().Name;
				var primaryKey = GetPrimaryKeyValue(change);

				foreach (var prop in change.OriginalValues.PropertyNames)
				{
					var originalValue = change.OriginalValues[prop].ToString();
					var currentValue = change.CurrentValues[prop].ToString();
					if (originalValue != currentValue)
					{
						ChangeLog log = new ChangeLog()
						{
							EntityName = entityName,
							PrimaryKeyValue = primaryKey.ToString(),
							PropertyName = prop,
							OldValue = originalValue,
							NewValue = currentValue,
							DateChanged = now
						};
						ChangeLogs.Add(log);
					}
				}
			}
			return base.SaveChanges();
		}

	}

	public class ChangeLog
	{
		public int Id { get; set; }
		public string EntityName { get; set; }
		public string PropertyName { get; set; }
		public string PrimaryKeyValue { get; set; }
		public string OldValue { get; set; }
		public string NewValue { get; set; }
		public DateTime DateChanged { get; set; }
	}

}
