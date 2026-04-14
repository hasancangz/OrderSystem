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
    public class CustomerMenu:BaseMenu
    {
        public CustomerMenu(UserSession session,CustomerRepositorySql customerRepositorySql,OrderService orderService,CustomerService customerService)
            :base(session)
        {
            privatedict = new Dictionary<int, Func<IAction>>
            {
                { 1,() => new ShowingUserInfo<Custom>(customerService, session) },
                { 2,() => new CreateOrder(orderService, session)},
                { 3,() => new ShowPreviousOrder(customerService, session) },
                { 4,() => new ChangingPassword<Custom>(customerService, session) },
                { 5,() => new ChaningUserName<Custom>(customerService, session) },
                { 6,() => new Exit() },
                { 7,() => new Off_App() }

            };
        }

        public override int PrivateMenu()
        {

            Selection = ChooseProcessCustomer.Process();
            return Selection;
        }
    }
}
