using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Auditing;

namespace EF_Audit
{
	public class Bank : AuditableEntity
	{
		public virtual int BankId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Address { get; set; }
		public virtual string Account { get; set; }
		public virtual int ClientId { get; set; }
		public virtual Client Client { get; set; }
	}

	public class BankAudit : AuditEntity
	{
		public virtual int BankAuditId { get; set; }
		public virtual int BankId { get; set; }
		public virtual string Name { get; set; }
		public virtual string Address { get; set; }
		public virtual string Account { get; set; }
		public virtual int ClientId { get; set; }
		public virtual Client Client { get; set; }
	}
}
