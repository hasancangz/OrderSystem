using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Mapping;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;


namespace C__SQL_ADO.NET_Application.Services
{

    public class CustomerService:UserBaseService<Custom>
    {
        
        private ICustomerRepository csq;
        public CustomerService(ICustomerRepository customerRepositorySql,ICommonProcess<Custom>proc)
            :base(proc)

        {
            this.csq = customerRepositorySql;
        }

        public Result<List<OrderItem>> GetPreviousOrder(int customerıd)
        {
            var order = csq.PreviousOrder(customerıd);
            if (!order.Issuccess)
                return Result<List<OrderItem>>.Fail(order.Message);

            return Result<List<OrderItem>>.Success(order.Value,default);
        }   
    }
}
