using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Audit
{
	class Order
	{
		public int OrderId { get; set; }
		public int Count { get; set; }
		public int Sum { get; set; }
		public int ClientId { get; set; }
		public virtual Client Client { get; set; }
		public virtual List<Product> Products { get; set; }
		public virtual List<Storage> Storages { get; set; }
	}
}
