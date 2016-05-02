using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EF_Audit
{
	[TrackChanges]
	class Client
	{
		public int ClientId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public virtual List<Bank> Banks { get; set; }
		public virtual List<Order> Orders { get; set; } 
	}
}
