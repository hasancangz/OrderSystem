using C__SQL_ADO.NET_Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C__SQL_ADO.NET_Domain.Domain.Order;

namespace C__SQL_ADO.NET_Application.DTO
{
    public record OrderDTO(DateTime nowtime, OrderType type, decimal totalprice, List<OrderItem> orderItems);
   
}
