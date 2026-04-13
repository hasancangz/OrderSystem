using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using C__SQL_ADO.NET_Application.Mapping;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__SQL_ADO.NET_Application.DTO;

namespace C__SQL_ADO.NET_Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository repor;
        public OrderService(IOrderRepository _repor)
        {
            this.repor = _repor;
        }

        public Result<Order> CreatingOrder(Dictionary<int,int> orderıtem,int customerıd)
        {
            Result<Order> process = repor.CreatingOrder(orderıtem,customerıd);
            if (!process.Issuccess)
                return Result<Order>.Fail(process.Message);

            return Result<Order>.Success(process.Value,default);
        }
        public Result<OrderDTO> ApporvedOrder(int orderıd)
        {
            Result<Order> getıd = repor.GetOrderID(orderıd);
            if (!getıd.Issuccess)
                return Result<OrderDTO>.Fail(getıd.Message);

            Result<bool> checkstatus = getıd.Value.CanApprove();
            if (!checkstatus.Issuccess)
                return Result<OrderDTO>.Fail(checkstatus.Message);

            Result<Order> result = repor.ApporvedOrder(getıd.Value.OrderID);
            if (!result.Issuccess)
                return Result<OrderDTO>.Fail(result.Message);

            var orderdto = result.Value.OrderMapp();

            return Result<OrderDTO>.Success(orderdto,result.Message);
        }
        public Result<OrderDTO> CancelledOrder(int orderıd )
        {
            Result<Order> getıd = repor.GetOrderID(orderıd);
            if (!getıd.Issuccess)
                return Result<OrderDTO>.Fail(getıd.Message);



            Result<bool> checkstatus = getıd.Value.CanCancelled();
            if (!checkstatus.Issuccess)
                return Result<OrderDTO>.Fail(checkstatus.Message);

            Result<Order> result = repor.CancelledOrder(getıd.Value.OrderID);
                if (!result.Issuccess)
                    return Result<OrderDTO>.Fail(result.Message);
            
            var orderdto = result.Value.OrderMapp();

            return Result<OrderDTO>.Success(orderdto, result.Message);
        }
        public Result<List<ProductsDTO>> GetProducts()
        {
            var result=repor.GetProducts();

            if(!result.Issuccess)
                    return Result<List<ProductsDTO>>.Fail(result.Message);

            var list=result.Value.ProductsMapping();

            return Result<List<ProductsDTO>>.Success(list, default);
        }
        public Result<List<DecAndInc>> GetProductsFor()
        {
            var result=repor.GetProductFor();

            if(!result.Issuccess)
                    return Result<List<DecAndInc>>.Fail(result.Message);

            var list=result.Value.DecAndIncMapping();

            return Result<List<DecAndInc>>.Success(list, default);
        }
    }
}
