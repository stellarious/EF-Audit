using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EF_Audit
{
	[TrackChanges]
	class Product
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int OrderId { get; set; }
		public virtual Order Order { get; set;}
	}
}
