using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Mapping;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.Services
{//dto
    public class ManagerService:UserBaseService<Manager>
    {
        private IManagerRepository csq;
        public ManagerService(IManagerRepository sql, ICommonProcess<Manager> proces)
            : base(proces)
        {
            this.csq = sql;
        }
        public Result<List<UpdateProductDTO>> DecreasingProduct(Dictionary<int, int> products)
        {

            var result = csq.DecreasingStock(products);
            if (!result.Issuccess)
                return Result<List<UpdateProductDTO>>.Fail(result.Message);

            return Result<List<UpdateProductDTO>>.Success(result.Value, result.Message);

        }
        public Result<List<UpdateProductDTO>> IncreasingProduct(Dictionary<int, int> products)
        {
            var result = csq.IncreasingStock(products);
            if (!result.Issuccess)
                return Result<List<UpdateProductDTO>>.Fail(result.Message);

            return Result<List<UpdateProductDTO>>.Success(result.Value, result.Message);
        }




    }
}
