using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
    internal class UpdateProducts
    {

        public Dictionary<DecAndInc,int> Choosed { get; }
        public List<DecAndInc> Prod { get;}
        public UpdateProducts(List<DecAndInc>prod,Dictionary<DecAndInc,int>choosed)
        {
            this.Prod = prod;
            this.Choosed = choosed;
        }

        public Dictionary<int, int> UpdateProdcts()
        {
            var max = Prod.Max(x =>x.ıd);
            var min = Prod.Min(x => x.ıd);

            while (true)
            {
                foreach (var prod in Prod )
                {
                    Console.WriteLine($"ID:{prod.ıd}");
                    Console.WriteLine($"Name:{prod.name}");
                    Console.WriteLine($"Stock:{prod.stock}");
                    Console.WriteLine($"ReservedStock:{prod.reservedstock}");
                    Console.WriteLine("------------------------------");
                }
                Console.WriteLine("The products you choosed");
                Console.WriteLine("----------------");
                foreach (var pr in Choosed)
                {
                    Console.WriteLine($"Name:{pr.Key.name}");
                    Console.WriteLine($"ID:{pr.Key.ıd}");
                    Console.WriteLine($"Quantity:{pr.Value}");
                    Console.WriteLine("----------------");

                }

                try
                {
                    Console.WriteLine("Press zero to complete the your update of products");
                    Console.Write("Please choose the ID of product that you want to delete:");
                    int ıd = Convert.ToInt32(Console.ReadLine());


                    if (Choosed.Count != 0 && ıd == 0)
                    {
                        DeleteHelper.Delete();
                        var rs = Choosed.ToDictionary(x => x.Key.ıd, x => x.Value);
                        return rs;
                    }

                    if (ıd > max || ıd < min)
                        throw new Exception("Please choose valid ID between certain range");

                    if (!Choosed.Any(x=>x.Key.ıd==ıd))
                        throw new Exception("Please choose the product that is in your order");

                    Choosed.Remove(Prod.First(x => x.ıd == ıd));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                DeleteHelper.Delete();

            }
   
        } 
    }
}
