using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Application.Session;
using C__SQL_ADO.NET_Domain.DomainRule;
using C__SQL_ADO.NET_UI.GeneralProcess;
using C__SQL_ADO.NET_UI.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.Action
{
    internal class ChaningUserName<T>:BaseAction where T : User
    {
        private readonly UserBaseService<T> servicegeneral;
        private readonly UserSession session;
        public ChaningUserName(UserBaseService<T> service, UserSession session)
        {
            this.servicegeneral = service;
            this.session = session;
        }

        public  override ActionStatus OnExecute()
        {

            string username = UserNameProcess.ProcessUserName();

            var result = servicegeneral.ChangingUserName(session.ID, username);
            Console.WriteLine(result.Message);

            if(!result.Issuccess)
                return ActionStatus.Continue;

            return ActionStatus.Logout;
        }

    }
}
