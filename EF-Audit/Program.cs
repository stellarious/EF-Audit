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
            using (var db = new BusinessModel())
            {
                Console.Write("Begin\n...\n");
                                
                var test = new Test
                {
                    IdZakaz = 959955,
                    Kolich = 1555,
                    Sum = 3434,
                    //add ClientSets, 
                    //add SkladiSets,
                    //add TovarSets 
                };

                var tovar = new TovarSet
                {
                    IdTovar = 2895,
                    Name = "Device",
                    Csena = 3400,
                    ZakaziIdZakaz = 2192,
                    Test = test
                };

                var sklad = new SkladiSet
                {
                    IdSklad = 34342,
                    Name = "Sklad1",
                    ZakaziIdZakaz = 3677,
                    Test = test
                };

                var client = new ClientSet
                {
                    Adress = "Popova st.",
                    //BankSets = System.Collections.Generic.ICollection<BankSet>,
                    IdClient = 123,
                    Name = "Alexey",
                    Tel = "983459598",
                    Test = test,
                    ZakaziIdZakaz = 4545
                };

                var bank1 = new BankSet
                {
                    IdBank = 1341,
                    Name = "Bank1",
                    Adress = "Nevsky pr.",
                    Schet = "99.0",
                    ClientIdClient = 2323,
                    ClientSet = client
                };

                Console.WriteLine("Start Add()");
                db.ClientSets.Add(client);
                Console.WriteLine("End Add()\n\nStart SaveChanges()");
                db.SaveChanges();
                Console.WriteLine("End SaveChanges()\n");

                var query = from x in db.ClientSets //choose table
                            orderby x.Name
                            select x;

                Console.WriteLine("Entities in db:");
                foreach(var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
