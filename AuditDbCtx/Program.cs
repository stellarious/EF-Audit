using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Auditing;
using System.Data.Entity;

namespace EF_Audit
{
	class Program
	{
		static void Main(string[] args)
		{
			//AddEntity();
			//UpdateEntity();
			DeleteEntity();

			ShowEntities();
		}

		private static Client InitEntity()
		{
			var client = new Client
			{
				ClientId = Rnd(),
				Name = RandomLetString(6),
				Address = RandomLetString(6) + " st.",
				Phone = RandomNumString(9),
				Banks = new List<Bank>(),
				Orders = new List<Order>()
			};

			var bank = new Bank
			{
				BankId = Rnd(),
				Name = RandomLetString(5),
				Address = RandomLetString(6) + " st.",
				Account = RandomNumString(3) + ".0",
				ClientId = client.ClientId,
				Client = client
			};

			var order = new Order
			{
				OrderId = Rnd(),
				Count = Rnd(),
				Sum = Rnd(),
				ClientId = client.ClientId,
				Client = client,
				Products = new List<Product>(),
				Storages = new List<Storage>()
			};

			var product = new Product
			{
				ProductId = Rnd(),
				Name = RandomLetString(4),
				Price = Rnd(),
				OrderId = order.OrderId,
				Order = order
			};

			var storage = new Storage
			{
				StorageId = Rnd(),
				Name = RandomLetString(7),
				OrderId = order.OrderId,
				Order = order
			};

			order.Products.Add(product);
			order.Storages.Add(storage);

			client.Banks.Add(bank);
			client.Orders.Add(order);

			return client;
		}

		private static void AddEntity()
		{
			using (var db = new CompanyContext())
			{
				for (int j = 0; j < 10; j++) //1000
				{
					for (int i = 0; i < 100; i++)
						db.Clients.Add(InitEntity());

					db.SaveChanges(); // every 100
					Console.WriteLine("Saved.");
				}
			}
		}

		private static void UpdateEntity()
		{
			using (var db = new CompanyContext())
			{
				Client client;
				for (int i = 0, j = 1; i < 1000; i++, j++)
				{
					client = db.Clients.FirstOrDefault(s => s.ClientId == i);

					if (client != null)
					{
						client.Phone = "88005553535";
					}
					else
					{
						Console.WriteLine("Entity with id " + i + " not found.");
					}

					if (j == 100) //every 100
					{
						db.SaveChanges();
						Console.WriteLine("Saved.");
						j = 0;
					}
				}
			}
		}

		private static void DeleteEntity()
		{
			using (var db = new CompanyContext())
			{
				Client client;
				for (int i = 0, j = 1; i < 1000; i++, j++)
				{
					client = db.Clients.FirstOrDefault(s => s.ClientId == i);

					if (client != null)
					{
						db.Clients.Remove(client);
					}
					else
					{
						Console.WriteLine("Entity with id " + i + " not found.");
					}

					if (j == 100) //every 100
					{
						db.SaveChanges();
						Console.WriteLine("Saved.");
						j = 0;
					}
				}
			}
		}

		private static void ShowEntities()
		{
			List<Client> query;
			using (var db = new CompanyContext()) //new ctx
			{
				query = db.Clients.OrderBy(x => x.Name).ToList();

				Console.WriteLine("\nEntities in db:");

				if (query.Count() != 0)
				{
					foreach (var item in query)
					{
						Console.WriteLine("id: " + item.ClientId + "\tname: " + item.Name + "\tphone: " + item.Phone);
					}
				}
				else
				{
					db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('Clients', RESEED, 0);");
					Console.WriteLine("none");
				}
			}
		}

		private static int Rnd()
		{
			Random rand = new Random();
			return rand.Next(100, 2000);
		}
		
		private static string RandomLetString(int length)
		{
			var random = new Random();
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		private static string RandomNumString(int length)
		{
			var random = new Random();
			const string chars = "0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}
	}
}
