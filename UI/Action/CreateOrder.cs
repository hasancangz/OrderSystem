using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.InterfaceRepor;
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
   public class CreateOrder:BaseAction
    {
        private readonly OrderService orderRepository;
        private readonly UserSession userSession;
        public CreateOrder(OrderService orderrepository,UserSession session)
        {

            this.userSession = session;
            this.orderRepository = orderrepository;
        }
        public override ActionStatus OnExecute()
        {

            //En sonda sadece ıd ve quan olmasın namede gelsin int,int gereksiz products,int
            var getproducts=orderRepository.GetProducts();
            if (!getproducts.Issuccess)
            {
                Console.WriteLine(getproducts.Message);
                return ActionStatus.Continue;
            }

            ChoosingProductProcess pr=new ChoosingProductProcess(getproducts.Value);

            var order = pr.ChoosingProducts();


            //onaylama kısmını ıd==0 ksımında yapılabilir;
            UpdateOrder up = new UpdateOrder(getproducts.Value,order);

            var rs = up.Updateorder();

             Result<Order>dt=  orderRepository.CreatingOrder(rs, userSession.ID);

            if (!dt.Issuccess)
            {
                Console.WriteLine(dt.Message);
                DeleteHelper.Delete();

                return ActionStatus.Continue;
            }

            AppORCan appORCan = new AppORCan();

            int b = appORCan.AppOrCn();

           Result<OrderDTO>result= b switch
            {
                1 => orderRepository.ApporvedOrder(dt.Value.OrderID),
                2=> orderRepository.CancelledOrder(dt.Value.OrderID)
            };

            Console.WriteLine(result.Message);

            return ActionStatus.Continue;

        }
    }
}
