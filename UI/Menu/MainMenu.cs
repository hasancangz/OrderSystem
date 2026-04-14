using C__SQL_ADO.NET_Application;
using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Repositories;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Application.Session;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using C__SQL_ADO.NET_UI.GeneralProcess;
using C__SQL_ADO.NET_UI.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace C__SQL_ADO.NET_UI.Menu
{


    //public IMenu ShowMenu(UserSession session)
    //{
    //    return session.Role switch
    //    {
    //        User.Role.Customer => new CustomerMenu(),
    //        User.Role.Manager => new ManagerMenu(),
    //        _ => throw new NotImplementedException("Role için menu tanımlı değil")
    //    };
    //}



    public class MainMenu
    {

        Dictionary<User.Role, Func<BaseMenu>> RoleMenu;

        public UserSession Session { get; }
        public MainMenu(UserSession session)
        {
            this.Session = session;


            RoleMenu = new Dictionary<User.Role, Func<BaseMenu>>()
          {

            { User.Role.Customer,()=>
                {

                CustomerRepositorySql customerRepositorySql = new CustomerRepositorySql();
                OrderService orderService=new OrderService(new OrderRepositorySql());
                CustomerService customerService=new CustomerService(customerRepositorySql,customerRepositorySql);

                return new CustomerMenu(session,customerRepositorySql,orderService,customerService); }
                },

            { User.Role.Manager,() =>
                {
                ManagerRepositorySql managerRepositorySql = new ManagerRepositorySql();
                ManagerService managerService = new ManagerService(managerRepositorySql,managerRepositorySql);
                OrderService orderService = new OrderService(new OrderRepositorySql());
                HelperStock helperStock=new HelperStock(orderService,managerService);

                return new ManagerMenu(session, managerRepositorySql, orderService, managerService, helperStock);
                }

            }
          };

        }

        public ActionStatus ShowMenu()
        {
            if (RoleMenu.TryGetValue(Session.Role, out var menu))
            {
                return menu().baseMenu();
            }
            return ActionStatus.Exit;
        }

    }

}
