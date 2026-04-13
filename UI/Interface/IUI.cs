using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.Interface
{
    internal interface IProcess
    {

        Result<AuthDto> Execute();
    }
}
