using C__SQL_ADO.NET_Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
    internal class UpdateOrder
    {
        private readonly List<ProductsDTO> products;
        private readonly Dictionary<int,int> orders; 

        public UpdateOrder(List<ProductsDTO>products,Dictionary<int,int>orders)
        {
            this.orders = orders;
            this.products = products;


        }
        
        public Dictionary<int, int> Updateorder()
        {
            var maxıd = products.Max(x => x.ıd);
            var minıd = products.Min(x => x.ıd);

           
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
                Console.WriteLine("The products you choosed");
                Console.WriteLine("----------------");
                foreach (var pr in orders)
                {
                    Console.WriteLine($"ID:{pr.Key}");
                    Console.WriteLine($"Quantity:{pr.Value}");
                }
                try
                {
                    Console.WriteLine("Press zero to complete the your order");
                    Console.Write("Please choose the ID of product that you want to delete:");
                    int ıd = Convert.ToInt32(Console.ReadLine());


                    if (orders.Count != 0 && ıd == 0)
                    {
                        DeleteHelper.Delete();
                        return orders;
                    }

                    // switch




                    if (ıd > maxıd || ıd < minıd)
                        throw new Exception("Please choose valid ID between certain range");

                    if (!orders.ContainsKey(ıd))
                        throw new Exception("Please choose the product that is in your order");

                    orders.Remove(ıd);
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
