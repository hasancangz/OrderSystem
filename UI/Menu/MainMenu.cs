using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using C__SQL_ADO.NET_Application;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Repositories;
using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.Session;
using C__SQL_ADO.NET_Domain.DomainRule;
using C__SQL_ADO.NET_UI.Interface;
using C__SQL_ADO.NET_UI.GeneralProcess;

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

        Dictionary<User.Role, Func<Imenu>> RoleMenu = new Dictionary<User.Role, Func<Imenu>>();

        public UserSession Session { get; }
        public MainMenu(UserSession session)
        {
            this.Session = session;
        Dictionary<User.Role, Func<Imenu>> RoleMenu = new Dictionary<User.Role, Func<Imenu>>()
        {

            { User.Role.Customer,()=>new CustomerMenu(session)},
            {User.Role.Manager,()=>new ManagerMenu(session)},

        };

            this.RoleMenu = RoleMenu;
        }

        public ActionStatus ShowMenu()
        {
            if (RoleMenu.TryGetValue(Session.Role, out var menu))
            {
                return menu().PrivateMenu(Session);
            }
            return ActionStatus.Exit;
        }

      
    }
}
