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
            addEntity();
            
            updateEntity();

            deleteEntity();
        }

        static void addEntity()
        {
            Console.Write("addEntity() start\n");

            using (var db = new BusinessModel())
            {
                var test = new Test
                {
                    IdOrder = 959955,
                    Count = 1555,
                    Sum = 3434,
                    ClientSets = new List<ClientSet>(),
                    ProductSets = new List<ProductSet>(),
                    StorageSets = new List<StorageSet>()
                };

                var product = new ProductSet
                {
                    IdProduct = 2895,
                    Name = "Device",
                    Price = 3400,
                    OrderIdOrder = 2192,
                    Test = test
                };

                var storage = new StorageSet
                {
                    IdStorage = 34342,
                    Name = "Storage1",
                    OrderIdOrder = 3677,
                    Test = test
                };

                var client = new ClientSet
                {
                    IdClient = 123,
                    Name = "Alexey",
                    Adress = "Popova st.",
                    Tel = "983459598",
                    OrderIdOrder = 4545,
                    BankSets = new List<BankSet>(),
                    Test = test
                };

                var bank = new BankSet
                {
                    IdBank = 1341,
                    Name = "Bank1",
                    Adress = "Nevsky pr.",
                    Acсount = "99.0",
                    ClientIdClient = 2323,
                    ClientSet = client
                };

                test.ClientSets.Add(client);
                test.ProductSets.Add(product);
                test.StorageSets.Add(storage);

                db.Tests.Add(test);                
                db.SaveChanges();

                var query = from x in db.ClientSets //choose table
                            orderby x.Name
                            select x;

                Console.WriteLine("\nEntities in db:");
                foreach (var item in query)
                {
                    Console.WriteLine("id: " + item.IdClient + " name: " + item.Name + " phone: " + item.Tel);
                }
            }

        }

        static void updateEntity()
        {
            Console.Write("\nupdateEntity() start");

            ClientSet client;

            using (var db = new BusinessModel())
            {

	            client = db.ClientSets.Where(s => s.IdClient == 4).FirstOrDefault<ClientSet>();
	
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
	
	                //updated output
	                var query = from x in newdbCtx.ClientSets //choose table
	                            orderby x.Name
	                            select x;
	
	                Console.WriteLine("\nUpdated Entities in db:");
	                foreach (var item in query)
	                {
	                    Console.WriteLine("id: " + item.IdClient + " name: " + item.Name + " phone: " + item.Tel);
	                }
                }
                else 
                {
                    Console.WriteLine("\nError: entity not found.");
                }
            }
        }

        static void deleteEntity()
        {
            Console.Write("\ndeleteEntity() start");

            ClientSet client;

            using (var db = new BusinessModel())
            {
                client = db.ClientSets.Where(s => s.IdClient == 8).FirstOrDefault<ClientSet>();
            }

            using (var newdbCtx = new BusinessModel()) //new ctx
            {
                if (client != null)
                {
                    newdbCtx.Entry(client).State = System.Data.Entity.EntityState.Deleted;
                    newdbCtx.SaveChanges();

                    //updated output
                    var query = from x in newdbCtx.ClientSets
                                orderby x.Name
                                select x;

                    Console.WriteLine("\nUpdated Entities in db:");
                    foreach (var item in query)
                    {
                        Console.WriteLine("id: " + item.IdClient + " name: " + item.Name + " phone: " + item.Tel);
                    }
                }
                else
                {
                    Console.WriteLine("\nError: entity not found.");
                }
            }
        }

    }
}
