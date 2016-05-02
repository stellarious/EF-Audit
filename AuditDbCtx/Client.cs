using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Auditing;

namespace EF_Audit
{
	public class Client : AuditableEntity
	{
		public virtual int ClientId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Address { get; set; }
		public virtual string Phone { get; set; }
		public virtual List<Bank> Banks { get; set; }
		public virtual List<Order> Orders { get; set; }
	}

	public class ClientAudit : AuditEntity
	{
		public virtual int ClientAuditId { get; set; }
		public virtual int ClientId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Address { get; set; }
		public virtual string Phone { get; set; }
		//public virtual IList<Bank> Banks { get; set; }
		//public virtual IList<Order> Orders { get; set; }
	}
}
