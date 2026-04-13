using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static C__SQL_ADO.NET_Domain.DomainRule.User;

namespace C__SQL_ADO.NET_Application.Session
{

        public record UserSession(int ID,string name,string username, Role Role);

}
