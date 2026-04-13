using C__SQL_ADO.NET_Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
    internal class ChoosingProductProcess
    {
        private readonly List<ProductsDTO> products;
        public ChoosingProductProcess(List<ProductsDTO> productsDTOs)
        {
            this.products = productsDTOs;
        }
        public Dictionary<int,int> ChoosingProducts()
        {
              var maxıd = products.Max(x => x.ıd);
              var minıd = products.Min(x => x.ıd);
                    
             Dictionary<int, int> thepr = new Dictionary<int, int>();
                  
            while (true)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product's ID:{product.ıd}");
                    Console.WriteLine($"Name:{product.name}");
                    Console.WriteLine($"Unreservedstock:{product.unreservedstock}");
                    Console.WriteLine($"Price:{product.price}");
                    Console.WriteLine("----------------");
                } 
                try
                {
                    Console.WriteLine("Press zero to complete the your order");
                    Console.Write("Please choose the ID of product that you want to order:");
                    int ıd = Convert.ToInt32(Console.ReadLine());

                    if (thepr.Count!=0 && ıd==0)
                    {
                        DeleteHelper.Delete();
                        return thepr;
                    }

                    // switch
                    if (ıd > maxıd || ıd < minıd)
                        throw new Exception("Please choose valid ID between certain range");

                    if(thepr.ContainsKey(ıd))
                            throw new Exception("Please dont choose same product");


                    Console.Write("How many quantity do you want to order:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                        if (quantity <= 0)  
                            throw new Exception("Please choose valid quantity");

                    thepr.Add(ıd, quantity);
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
