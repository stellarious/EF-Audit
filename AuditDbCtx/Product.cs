using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Auditing;

namespace EF_Audit
{
	public class Product : AuditableEntity
	{
		public virtual int ProductId { get; set; }
		public virtual string Name { get; set; }
		public virtual int Price { get; set; }
		public virtual int OrderId { get; set; }
		public virtual Order Order { get; set; }
	}

	public class ProductAudit : AuditEntity
	{
		public virtual int ProductAuditId { get; set; }
		public virtual int ProductId { get; set; }
		public virtual string Name { get; set; }
		public virtual int Price { get; set; }
		public virtual int OrderId { get; set; }
		public virtual Order Order { get; set; }
	}
}
