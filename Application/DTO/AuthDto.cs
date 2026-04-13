using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C__SQL_ADO.NET_Domain.DomainRule.User;

namespace C__SQL_ADO.NET_Application.DTO
{
    public record AuthDto(int id, string name, string username, Role Role);
  
}
