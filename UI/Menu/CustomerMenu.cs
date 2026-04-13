using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Repositories;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Application.Session;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_UI.Action;
using C__SQL_ADO.NET_UI.GeneralProcess;
using C__SQL_ADO.NET_UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.Menu
{
    public class CustomerMenu:Imenu
    {
       

        private UserSession session;
        private Dictionary<int, Func<IAction>> serviceofmenu = new Dictionary<int, Func<IAction>>();



        public CustomerMenu(UserSession session )
        {
            CustomerRepositorySql customerRepositorySql = new CustomerRepositorySql();
              OrderService orderService = new OrderService(new OrderRepositorySql());
             CustomerService customerService = new CustomerService(customerRepositorySql,customerRepositorySql);

            this.session = session;

            Dictionary<int, Func<IAction>> serviceofmenu = new Dictionary<int, Func<IAction>>()
            {
                {1,() => new ShowingUserInfo <Custom>(customerService, session) },
                {2,()=>new CreateOrder(orderService,session)},
                {3,()=>new  ShowPreviousOrder(customerService,session) },
                {4,()=>new ChangingPassword<Custom>(customerService,session) },
                {5,()=>new ChaningUserName<Custom>(customerService,session) },
                {6,()=>new Exit() },
                {7,()=>new Off_App() }

            };

          this.serviceofmenu = serviceofmenu;
        }


       
        public ActionStatus PrivateMenu(UserSession session)
        {
            
            ActionStatus status=ActionStatus.Continue;

            while (status==ActionStatus.Continue)
            {
                int b = ChooseProcessCustomer.Process();
                status=serviceofmenu[b]().Execute();
            }

            return status;

        }

    }
}
