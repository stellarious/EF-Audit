using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Auditing;

namespace EF_Audit
{
	public class Order : AuditableEntity
	{
		public virtual int OrderId { get; set; }
		public virtual int Count { get; set; }
		public virtual int Sum { get; set; }
		public virtual int ClientId { get; set; }
		public virtual Client Client { get; set; }
		public virtual List<Product> Products { get; set; }
		public virtual List<Storage> Storages { get; set; }
	}

	public class OrderAudit : AuditEntity
	{
		public virtual int OrderAuditId { get; set; }
		public virtual int OrderId { get; set; }
		public virtual int Count { get; set; }
		public virtual int Sum { get; set; }
		public virtual int ClientId { get; set; }
		public virtual Client Client { get; set; }
		//public virtual List<Product> Products { get; set; }
		//public virtual List<Storage> Storages { get; set; }
	}
}
