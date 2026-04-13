using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace C__SQL_ADO.NET_Domain.Domain
{
    public class Manager:User
    {//username unutma  


    

        public Manager(int ıd, string name, string username, byte[] password)
            : base(ıd,name,username,password,Role.Manager)
        {
                
        }

        
    }
}
