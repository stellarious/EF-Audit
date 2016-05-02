using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Auditing;

namespace EF_Audit
{
	public class Storage : AuditableEntity
	{
		public virtual int StorageId { get; set; }
		public virtual string Name { get; set; }
		public virtual int OrderId { get; set; }
		public virtual Order Order { get; set; }
	}

	public class StorageAudit : AuditEntity
	{
		public virtual int StorageAuditId { get; set; }
		public virtual int StorageId { get; set; }
		public virtual string Name { get; set; }
		public virtual int OrderId { get; set; }
		public virtual Order Order { get; set; }
	}
}
