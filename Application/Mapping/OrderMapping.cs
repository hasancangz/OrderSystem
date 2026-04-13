using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.Mapping
{
    public static class OrderMapping
    {
        internal static OrderDTO OrderMapp(this Order order)
        {
            return new OrderDTO(order.dateTime, order.Status, order.TotalPrice, order.OrderItem);
        }
    }

}
