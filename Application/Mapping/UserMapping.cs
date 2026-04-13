using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.Mapping
{
    public static class UserMapping
    {

        internal static ServiceUserDTO userMapping(this User user)
        {
            ServiceUserDTO UserDTO = new ServiceUserDTO(user.Name, user.UserName);

            return UserDTO;
        }
    }
}
