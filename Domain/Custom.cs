using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("C__SQL_ADO.NET_Application")]


namespace C__SQL_ADO.NET_Domain
{ 
    internal class Custom:User
    {
      
        public Custom(int customerıd,string name,string username, byte[] password)
        {
            this.
            this.Name = name;
            this.UserName = username;
        }
        internal void ChangingUserName(string username)
        {
            this.UserName = username;
        }
    }
}
