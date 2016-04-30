using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Audit
{
	class Storage
	{
		public int StorageId { get; set; }
		public string Name { get; set; }
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
	}
}
