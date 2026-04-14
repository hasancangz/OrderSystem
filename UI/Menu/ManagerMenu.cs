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
    public class ManagerMenu:BaseMenu
    {
        public ManagerMenu(UserSession session1, ManagerRepositorySql managerRepositorySql, OrderService orderService, ManagerService managerService, HelperStock helperStock)
          : base(session1)
        {
             privatedict=new Dictionary<int, Func<IAction>>()
            {
                
                {1,() =>new ShowingUserInfo<Manager>(managerService,session1)},
                {2,()=>new DecreasingStock(orderService,managerService,helperStock)},
                {3,()=>new IncreasingStock(orderService,managerService, helperStock)},
                {4,()=>new ChangingPassword<Manager>(managerService,session1) },
                {5,()=>new ChaningUserName<Manager>(managerService,session1)}
            };
        }

        public override int PrivateMenu()
        {
            Selection = ChooseProcessManager.Process();
            return Selection;
        }

    }
}
