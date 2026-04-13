using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Domain.Domain
{
    public class OrderItem
    {

        public  decimal Price { get; }
        public  int Quantity  { get; }
        public  int ID  { get; }
        public  string Name { get; }

        public OrderItem(int ıd,string name,decimal price,int quantity)
        {
            ID = ıd;
            Name = name;
            Price = price;
            Quantity = quantity;
        }


    }
}
