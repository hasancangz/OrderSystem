using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.InterfaceRepor
{
    public interface IAuthRepository<T> 
    {

        Result<T> Login(string username, byte[] password);

        Result<T> Register(string name,string username, byte[] password);


    }
}
