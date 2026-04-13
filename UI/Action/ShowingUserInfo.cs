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
    internal class ShowingUserInfo<T>:BaseAction where T : User
    {

        private readonly UserBaseService<T> servicegeneral;
        private readonly UserSession session;

        public ShowingUserInfo(UserBaseService<T> service, UserSession session)
        {
            this.servicegeneral = service;
            this.session = session;

        }

        public override ActionStatus OnExecute()
        {
            var result = servicegeneral.GetUser(session.ID);
            if (result.Issuccess)
            {
                Console.WriteLine($"Name:{result.Value.name}");
                Console.WriteLine($"UserName:{result.Value.username}");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            return ActionStatus.Continue;


        }
    }
}
