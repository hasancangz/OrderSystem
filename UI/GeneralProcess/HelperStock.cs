using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Domain.DomainRule;
using C__SQL_ADO.NET_UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
    internal class HelperStock
    {

        private readonly OrderService orderService;
        protected readonly ManagerService managerService;
       

        public HelperStock(OrderService orderService,ManagerService managerService)
        {
            this.orderService = orderService;
            this.managerService = managerService;
            
        }

        public Dictionary<int,int> Help()
        {
            Result<List<DecAndInc>> result = orderService.GetProductsFor();

            var b = new ForDecAndInc(result.Value) { };

            Dictionary<int,int> products=b.ChooseProducts();

            return products;
        }




    }
}
