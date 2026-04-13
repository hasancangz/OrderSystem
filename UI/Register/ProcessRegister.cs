using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.ProcessRegister
{
    internal class processRegister
    {

        static public UIRegisterRequestDTO Register()
        {
            Console.Write("Please enter your name:");
            string name=Console.ReadLine();

            Console.Write("Please enter username:");
            string username = Console.ReadLine();

            Console.Write("Please enter password:");
            string password = Console.ReadLine();

            return new UIRegisterRequestDTO(name,username, password);
        }
       static public Result<AuthDto> Register(AuthService<Custom> service)
        {
            UIRegisterRequestDTO dto = Register();
            return service.Register(dto.name, dto.username, dto.password);
        }
    }
}
