using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_UI.GeneralProcess;
using C__SQL_ADO.NET_UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.Action
{
    internal class IncreasingStock:BaseAction
    {
        OrderService orderService;
        ManagerService managerService;
        HelperStock helperStock;

        public IncreasingStock(OrderService orderService, ManagerService managerService, HelperStock help)
        {
            this.orderService = orderService;
            this.managerService = managerService;
            this.helperStock = help;
        }

        public override ActionStatus OnExecute()
        {
            var dict = helperStock.Help();
            var result = managerService.IncreasingProduct(dict);

            if (result.Issuccess)
            {
                foreach (var item in result.Value)
                {
                    Console.WriteLine($"Name:{item.name}");
                    Console.WriteLine($"Previous Stock:{item.previousstock}");
                    Console.WriteLine($"Current Stock:{item.newstock}");
                    Console.WriteLine("---------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);

            }
            return ActionStatus.Continue;

        }
    }
}
