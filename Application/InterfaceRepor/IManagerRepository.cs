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
    public interface IManagerRepository
    {

       
        Result<List<UpdateProductDTO>> IncreasingStock(Dictionary<int, int> products);


        Result<List<UpdateProductDTO>> DecreasingStock(Dictionary<int, int> products);

    }

}
