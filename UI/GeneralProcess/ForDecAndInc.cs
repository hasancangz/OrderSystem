using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
    internal class ForDecAndInc
    {

        public List<DecAndInc> prop { get; set; }
      
        public ForDecAndInc(List<DecAndInc>prod)
        {
            this.prop = prod;
        }

        public Dictionary<int, int> ChooseProducts()
        {
            Dictionary<DecAndInc, int> returnpr = new Dictionary<DecAndInc, int>();
            var max = prop.Max(x => x.ıd);
            var min = prop.Min(x => x.ıd);

          
            while (true)
            {
                foreach (DecAndInc prod in prop)
                {
                    Console.WriteLine($"ID:{prod.ıd}");
                    Console.WriteLine($"Name:{prod.name}");
                    Console.WriteLine($"Stock:{prod.stock}");
                    Console.WriteLine($"ReservedStock:{prod.reservedstock}");
                    Console.WriteLine("------------------------------");
                }

                try
                {
                    Console.WriteLine("Please press zero to complete your process about products");
                    Console.WriteLine("Warning!! Quantity of Reserved stock must not be more than main stock");
                    Console.Write("Please choose a product:");
                    int ıd=Convert.ToInt32( Console.ReadLine() );


                    
                    

                    if (returnpr.Count != 0 && ıd == 0)
                    {
                        UpdateProducts updateProducts = new UpdateProducts(prop,returnpr);
                        var prod = updateProducts.UpdateProdcts();
                        return prod;
                    }

                    if (ıd < min || ıd > max)
                        throw new Exception("Please choose valid ID between certain range");

                    if (returnpr.Any(x => x.Key.ıd == ıd))
                        throw new Exception("Please dont choose same product");


                    Console.Write("How many quantity do you want to update:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    if (quantity <= 0)
                        throw new Exception("Please choose valid quantity");


                    returnpr.Add(prop.First(x => x.ıd == ıd),quantity);
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
