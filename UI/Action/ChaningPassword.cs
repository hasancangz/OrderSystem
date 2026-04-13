using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Application.Session;
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
    internal class ChangingPassword<T> :BaseAction  where T : User
    {

        private readonly UserBaseService<T> servicegeneral;
        private readonly UserSession session;

        public ChangingPassword(UserBaseService<T> service, UserSession session)
        {
            this.servicegeneral = service;
            this.session = session;

        }

        public override ActionStatus OnExecute()
        {

            var passınfo = ChangingPasswordProcess.PasswordProcess();

            var result = servicegeneral.ChangingPassword(passınfo.oldpassword, session.ID, passınfo.newpassword);

            Console.WriteLine(result.Message);

            if (!result.Issuccess)
                return ActionStatus.Continue;

            return ActionStatus.Logout;
        }

    }
}
