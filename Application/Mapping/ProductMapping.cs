using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.Mapping
{
    internal static class ProductMapping
    {
        public static List<ProductsDTO> ProductsMapping(this List<Product> mapping)
        {
            List<ProductsDTO> products = new List<ProductsDTO>();

            foreach (var product in mapping)
            {
              products.Add(new ProductsDTO(product.ID,product.name, product.Price, product.stock.stock));
            }

            return products;
        }
        public static List<DecAndInc> DecAndIncMapping(this List<Product> map)
        {
            List<DecAndInc>products=new List<DecAndInc>();


            foreach (var prod in map)
            {
                products.Add(new DecAndInc(prod.ID, prod.name, prod.stock.stock, prod.ReservedStock));
            }
            return products;

        }

    }
}
