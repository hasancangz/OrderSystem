using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Domain.Domain
{
    public class Order
    {

        public  List<OrderItem>OrderItem=new List<OrderItem>();
        public DateTime dateTime { get; }
        public OrderType Status { get; }
        public decimal TotalPrice { get; }
        public int OrderID { get;}
        public int CustomerID { get;}
        public Order(int orderıd,DateTime nowtime,OrderType type,decimal totalprice,int customerıd)
        {
            CustomerID = customerıd;
            TotalPrice = totalprice;
            OrderID = orderıd;
            dateTime = nowtime;
            Status = type;
        }      
        
        public void AssignItem(List<OrderItem>ıtems)
        {
            OrderItem=ıtems;
        }

        public Result<bool>   CanApprove()
        { 
        if (Status==OrderType.CreatedOrder)
            {
                return Result<bool>.Success(true, default);
            }
                return Result<bool>.Fail($"{Status}"); 
        }
        public Result<bool>CanCancelled()

        { 
        if (Status ==OrderType.CreatedOrder)
            {
                return Result<bool>.Success(true, default);
            }
                return Result<bool>.Fail(" the status of the order you entered was changed"); 
        }
        public enum OrderType
        {
            CreatedOrder,
            ApporvedOrder,
            CancelledOrder
            
        }
    }
}
