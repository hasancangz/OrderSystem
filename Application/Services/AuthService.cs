using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Repositories;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


[assembly: InternalsVisibleTo("C__SQL_ADO.NET_UI")]


namespace C__SQL_ADO.NET_Application.Services
{
    public class AuthService<T> where T :User
    {

        private readonly IAuthRepository<T> repor;
      
       
        public AuthService(IAuthRepository<T> repository )
        {
            this.repor = repository;
        }

        public Result<AuthDto> Login(string username, string password)
        {

            
            Result<T> first = repor.Login(username, HashHelper.ComputeSha256Hash(password));
                if (!first.Issuccess)
                    return Result<AuthDto>.Fail(first.Message);


            var logindto =new AuthDto(first.Value.ID,first.Value.Name,first.Value.UserName,first.Value.role);


            return Result<AuthDto>.Success(logindto, first.Message);




        }
        public Result<AuthDto> Register(string name,string username, string password)
        {

            Result<bool> namevalid = NameValidator.namevalid(name);
            if (!namevalid.Issuccess)
                return Result<AuthDto>.Fail(namevalid.Message);

            Result<bool>passwordcheck=PasswordValidator.PasswordCheck(password);
            if (!passwordcheck.Issuccess)
                return Result<AuthDto>.Fail(passwordcheck.Message);

            Result<bool>usernamecheck=UserNameValidator.Usernamevalid(username);
            if (!usernamecheck.Issuccess)
                return Result<AuthDto>.Fail(usernamecheck.Message);


            Result<T> first = repor.Register(name,username, HashHelper.ComputeSha256Hash(password));
                if (!first.Issuccess)
                    return Result<AuthDto>.Fail(first.Message);



            var logindto = new AuthDto(first.Value.ID, first.Value.Name, first.Value.UserName, first.Value.role);


            return Result<AuthDto>.Success((AuthDto)logindto, first.Message);
        }

    }
}
