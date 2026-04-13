using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Domain.Domain
{
   public class Product
    {
        public int ID { get;  }
        public decimal Price { get; private set;}
        public int? ReservedStock {  get;}
        public readonly string name;
      public Stock stock;

     public Product(int ıd,string name,decimal price, int stock,int? reserv)
        {
            this.ID = ıd;
            Price = price;
            this.ReservedStock = reserv;
            this.name = name;
            this.stock = new Stock(stock);
        }
        internal Result<Product> DecreasePrice(decimal amount)
        {
            if (amount > Price)
            {
                return Result<Product>.Fail("Amount is not higher than current price");
            }
            Price -= amount;
            return Result<Product>.Success(this, "Price updated");


        }

        internal  void DecreaseStockFor(int amount)
        {
            stock = stock.DecreaseStock(amount);
        }
        internal void IncreasingStockForO(int amount)
        {
            stock=stock.IncreasingStock(amount);  
        }
        public readonly struct Stock
        {
            public int stock{ get; }

            public Stock(int stock)
            {
                this.stock = stock;
            }

            public Stock DecreaseStock(int amount)
            {
                return new Stock(stock - amount);
            }
            public Stock IncreasingStock(int amount)
            {
                return new Stock(stock + amount);
            }
        }
    }
}
