using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Application.Session;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using C__SQL_ADO.NET_UI.GeneralProcess;
using C__SQL_ADO.NET_UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.Action
{
    internal class ShowPreviousOrder:BaseAction
    {
        private readonly    CustomerService CustomerService;
        private readonly UserSession session;
        public ShowPreviousOrder(CustomerService CustomerService,UserSession session)
        {
            this.CustomerService = CustomerService;
            this.session = session;
        }

        public override ActionStatus OnExecute()
        {

            var result = CustomerService.GetPreviousOrder(session.ID);

            if (result.Issuccess)
            {
                foreach (var ıtem in result.Value)
                {
                    Console.WriteLine($"OrderID:{ıtem.ID}-ProductName:{ıtem.Name}-Quantity:{ıtem.Quantity}-Price:{ıtem.Price}");
                }
            }
            else
            {
                Console.WriteLine($"Message:{result.Message}");
            }

            return ActionStatus.Continue;


        }
    }
}
