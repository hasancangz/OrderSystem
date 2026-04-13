using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.ProcessLogin
{
    internal class ProcessLogin<T> where T:User
    {
        static public UILoginRequestDTO Login()
        {

            Console.Write("Please enter username:");
            string username=Console.ReadLine();

            Console.Write("Please enter password:");
            string password=Console.ReadLine();

            return new UILoginRequestDTO(username, password);
        }
                        

        static public Result<AuthDto> Login(AuthService<T> service )
        {

            UILoginRequestDTO dTO =ProcessLogin<T>.Login();

            Result<AuthDto> result=service.Login(dTO.Username, dTO.Password);

            return result;



        }
    }
}
