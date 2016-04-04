using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Audit
{
    class Program
    {
        static void Main(string[] args)
        {
			TestAddEntity(100);
			
			//TestUpdateEntity(100);

			//TestDeleteEntity(400);
			
			ShowEntities();
        }

		private static void TestAddEntity(int iter)
		{
			for (int i = 0; i < iter; i++)
				AddEntity(InitEntity());
		}

		private static void TestUpdateEntity(int iter)
		{
			for (int i = 0; i < iter; i++)
				UpdateEntity(i);
		}

		private static void TestDeleteEntity(int iter)
		{
			for (int i = 0; i < iter; i++)
				DeleteEntity(i);
		}

        private static int Rnd()
        {
            Random rand = new Random();
            return rand.Next(100, 2000);
        }

        static Test InitEntity()
        {
			var test = new Test
			{
				IdOrder = Rnd(),
				Count = Rnd(),
				Sum = Rnd(),
				ClientSets = new List<ClientSet>(),
				ProductSets = new List<ProductSet>(),
				StorageSets = new List<StorageSet>()
			};

			var product = new ProductSet
			{
				IdProduct = Rnd(),
				Name = RandomLetString(4),
				Price = Rnd(),
				OrderIdOrder = Rnd(),
				Test = test
			};

			var storage = new StorageSet
			{
				IdStorage = Rnd(),
				Name = RandomLetString(7),
				OrderIdOrder = Rnd(),
				Test = test
			};

			var client = new ClientSet
			{
				IdClient = Rnd(),
				Name = RandomLetString(6),
				Adress = RandomLetString(6) + " st.",
				Tel = RandomNumString(9),
				OrderIdOrder = Rnd(),
				BankSets = new List<BankSet>(),
				Test = test
			};

			var bank = new BankSet
			{
				IdBank = Rnd(),
				Name = RandomLetString(5),
				Adress = RandomLetString(6) + " st.",
				Acсount = RandomNumString(3) + ".0",
				ClientIdClient = Rnd(),
				ClientSet = client
			};

			test.ClientSets.Add(client);
			test.ProductSets.Add(product);
			test.StorageSets.Add(storage);

			return test;
        }

        private static void AddEntity(Test test)
        {
            using (var db = new BusinessModel())
            {
                db.Tests.Add(test);
                db.SaveChanges();
            }
        }

        private static void UpdateEntity(int id)
        {
            using (var db = new BusinessModel())
            {
				var client = db.ClientSets.FirstOrDefault(s => s.IdClient == id);
	
	            if (client != null)
	            {
	                client.Tel = "88005553535";
					db.SaveChanges();
	            }
				else
				{
					Console.WriteLine("\nError: entity not found.");
				}
            }
        }

        private static void DeleteEntity(int id)
        {
            using (var db = new BusinessModel())
            {
				var client = db.ClientSets.FirstOrDefault(s => s.IdClient == id);

				if (client != null)
				{
					db.ClientSets.Remove(client);
					db.SaveChanges();
				} 
				else
				{
					Console.WriteLine("\nError: entity not found.");
				}
            }
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

		private static void ShowEntities()
		{
 			using (var db = new BusinessModel()) //new ctx
            {
				var query = db.ClientSets.OrderBy(x => x.Name).ToList();

                Console.WriteLine("Entities in db:");

				if (query.Count() != 0)
				{
					foreach (var item in query)
					{
						Console.WriteLine("id: " + item.IdClient + "\tname: " + item.Name + "\tphone: " + item.Tel);
					}
				}
				else
				{
					db.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('ClientSet', RESEED, 0);");
					Console.WriteLine("none");
				}
			}
		}
    }
}
