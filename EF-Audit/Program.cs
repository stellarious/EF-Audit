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
            for (int i = 0; i < 10; i++)
				addEntity(initEntity());
			//
            //for (int i = 0; i < 25; i++)
			//	updateEntity(i);
			//
            //for (int i = 0; i < 55; i++)
			//	deleteEntity(i);

			showEntities();
        }

        static int rnd()
        {
            Random rand = new Random();
            return rand.Next(100, 2000);
        }

        static Test initEntity()
        {
            using (var db = new BusinessModel())
            {                
                var test = new Test
                {
                    IdOrder = rnd(),
                    Count = rnd(),
                    Sum = rnd(),
                    ClientSets = new List<ClientSet>(),
                    ProductSets = new List<ProductSet>(),
                    StorageSets = new List<StorageSet>()
                };

                var product = new ProductSet
                {
                    IdProduct = rnd(),
                    Name = randomString(4, 'l'),
                    Price = rnd(),
                    OrderIdOrder = rnd(),
                    Test = test
                };

                var storage = new StorageSet
                {
                    IdStorage = rnd(),
                    Name = randomString(7, 'l'),
                    OrderIdOrder = rnd(),
                    Test = test
                };

                var client = new ClientSet
                {
                    IdClient = rnd(),
                    Name = randomString(6, 'l'),
                    Adress = "Popova st.",
                    Tel = randomString(9, 'n'),
                    OrderIdOrder = rnd(),
                    BankSets = new List<BankSet>(),
                    Test = test
                };

                var bank = new BankSet
                {
                    IdBank = rnd(),
                    Name = randomString(5, 'l'),
                    Adress = randomString(6, 'l') + " st.",
                    Acсount = randomString(3, 'n') + ".0",
                    ClientIdClient = rnd(),
                    ClientSet = client
                };

                test.ClientSets.Add(client);
                test.ProductSets.Add(product);
                test.StorageSets.Add(storage);

                return test;
            }
        }

        static void addEntity(Test test)
        {
            Console.Write("addEntity() start\n");
            using (var db = new BusinessModel())
            {
				//db.Tests.Attach(test); //attach to context
                db.Tests.Add(test);    //attach to db(?)
                db.SaveChanges();
            }
        }

        static void updateEntity(int id)
        {
            Console.Write("\nupdateEntity() start");

            ClientSet client;

            using (var db = new BusinessModel())
            {

	            client = db.ClientSets.Where(s => s.IdClient == id).FirstOrDefault<ClientSet>();
	
	            if (client != null)
	            {
	                client.Tel = "88005553535";
	            }
            }

            using (var newdbCtx = new BusinessModel()) //new ctx
            {
                if (client != null)
                {
	                newdbCtx.Entry(client).State = System.Data.Entity.EntityState.Modified;
	                newdbCtx.SaveChanges();
	            }
                else 
                {
                    Console.WriteLine("\nError: entity not found.");
                }
            }
        }

        static void deleteEntity(int id)
        {
            Console.Write("\ndeleteEntity() start");

            ClientSet client;

            using (var db = new BusinessModel())
            {
                client = db.ClientSets.Where(s => s.IdClient == id).FirstOrDefault<ClientSet>();
            }

            using (var newdbCtx = new BusinessModel()) //new ctx
            {
                if (client != null)
                {
					newdbCtx.Entry(client).State = System.Data.Entity.EntityState.Deleted;
					//newdbCtx.ClientSets.Remove(client);
                    newdbCtx.SaveChanges();
                }
                else
                {
                    Console.WriteLine("\nError: entity not found.");
                }
            }
        }

        /// <summary>
        /// Return random string of letters or numbers: 
        /// 'l' for letter string, 'n' for number string.
        /// </summary>
         public static string randomString(int length, char c)
        {
            var random = new Random();

            if (c == 'l')
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";                
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            if (c == 'n')
            {
                const string chars = "0123456789";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            return "error";
        }

		public static void showEntities()
		{
 			using (var db = new BusinessModel()) //new ctx
            {
                //updated output
                var query = from x in db.ClientSets //choose table
                            orderby x.Name
                            select x;

                Console.WriteLine("\nEntities in db:");
                foreach (var item in query)
                {
                    Console.WriteLine("id: " + item.IdClient + " | name: " + item.Name + " | phone: " + item.Tel);
                }
			}
		}
    }
}
