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
    internal class ManagerMenu:Imenu
    {
        UserSession session1;
        Dictionary<int, Func<IAction>> Action;
        public ManagerMenu(UserSession session1)
        {
            this.session1 = session1;
            ManagerRepositorySql managerRepositorySql = new ManagerRepositorySql();
            OrderService orderService = new OrderService(new OrderRepositorySql());
            ManagerService managerService = new ManagerService(managerRepositorySql, managerRepositorySql);
            HelperStock helperStock=new HelperStock(orderService,managerService);

            Dictionary<int, Func<IAction>> sessionsmenu = new Dictionary<int, Func<IAction>>()
            {
                

                {1,() =>new ShowingUserInfo<Manager>(managerService,session1)},
                {2,()=>new DecreasingStock(orderService,managerService,helperStock)},
                {3,()=>new IncreasingStock(orderService,managerService, helperStock)},
                {4,()=>new ChangingPassword<Manager>(managerService,session1) },
                {5,()=>new ChaningUserName<Manager>(managerService,session1)}
            };
            Action = sessionsmenu;
        }

        public ActionStatus PrivateMenu(UserSession session)
        {

            ActionStatus status = ActionStatus.Continue;

            while (status!= ActionStatus.Continue)
            {
                int b = ChooseProcessManager.Process();
                status = Action[b]().Execute();
            }

            return status;



        }

    }
}
