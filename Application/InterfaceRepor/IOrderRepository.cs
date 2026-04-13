using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.InterfaceRepor
{
   public interface IOrderRepository
    {
        Result<Order> GetOrderID(int orderıd);
        Result<List<Product>> GetProducts();

        Result<List<Product>> GetProductFor();


        Result<Order> CreatingOrder(Dictionary<int,int> orderıtem, int customerıd);
        Result<Order> CancelledOrder(int orderıd);
          Result<Order> ApporvedOrder(int orderıd);

    }
}
