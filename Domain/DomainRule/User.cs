using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace C__SQL_ADO.NET_Domain.DomainRule
{
    public abstract class User
    {
        public int ID { get; }
        public string Name { get;  }
        public string UserName { get; }

       public  Role role { get; set; }
        public byte[] Password { get; }




       public enum Role
        {
            Customer,
            Manager
        }


        public User(int ıd, string name, string username, byte[]password,Role role)
        {
            this.ID = ıd;
            this.Name = name;
            this.UserName = username;
            this.Password = password;
            this.role = role;
        }



      
    }
}
