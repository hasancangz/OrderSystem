using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.InterfaceRepor
{
    public interface ICustomerRepository
    {
        Result<List<OrderItem>> PreviousOrder(int customerıd );
    }
}
