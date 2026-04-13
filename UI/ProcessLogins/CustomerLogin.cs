using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using C__SQL_ADO.NET_UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.ProcessLogin
{
    internal class CustomerLogin:IProcess
    {

        private readonly AuthService<Custom> auth;
        public CustomerLogin(AuthService<Custom> service)
        {
            auth = service;
        }

        public Result<AuthDto> Execute()
        {
            return ProcessLogin<Custom>.Login(auth);
        }

    }
}
