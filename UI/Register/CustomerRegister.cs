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

namespace C__SQL_ADO.NET_UI.ProcessRegister.ProcessRegister
{
    internal class CustomerRegister:IProcess
    {


       

            private readonly AuthService<Custom> auth;
            public CustomerRegister(AuthService<Custom> service)
            {
                auth = service;
            }

            public Result<AuthDto> Execute()
            {
                return processRegister.Register(auth);
            }

    }
}
