using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("C__SQL_ADO.NET_Application")]


namespace C__SQL_ADO.NET_Domain.Domain
{// event unutma
    public class Custom:User
    {

        public Custom(int ıd, string name, string username, byte[] password)
           : base(ıd, name, username,password,Role.Customer)
        {
          
        }
     
    }
}
