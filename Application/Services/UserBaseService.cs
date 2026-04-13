using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Mapping;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.Services
{
    public class UserBaseService<T> where T:User
    {

        private readonly ICommonProcess<T>csq;

        public UserBaseService(ICommonProcess<T> csq)
        {
            this.csq = csq;
        }

        public Result<ServiceUserDTO> ChangingPassword(string oldpassword, int Tıd, string newpassword)
        {
            Result<T> firstprocess = csq.TakingPassword(Tıd, HashHelper.ComputeSha256Hash(oldpassword));
            if (!firstprocess.Issuccess)
                return Result<ServiceUserDTO>.Fail(firstprocess.Message);

            Result<bool> oldpasswordcheck = PasswordValidator.PasswordCheck(firstprocess.Value.Password, newpassword);
            if (!oldpasswordcheck.Issuccess)
                return Result<ServiceUserDTO>.Fail(oldpasswordcheck.Message);

            Result<bool> secondpasswordcheck = PasswordValidator.PasswordCheck(newpassword);
            if (!secondpasswordcheck.Issuccess)
                return Result<ServiceUserDTO>.Fail(secondpasswordcheck.Message);


            Result<T> Ter = csq.ChangingPassword(oldpassword,Tıd, newpassword);
            if (!Ter.Issuccess)
                return Result<ServiceUserDTO>.Fail(Ter.Message);



            var Terdto = Ter.Value.userMapping();

            return Result<ServiceUserDTO>.Success(Terdto, Ter.Message);




        }
        public Result<ServiceUserDTO> ChangingUserName(int Terıd, string username)
        {



            Result<bool> usernamecheck = UserNameValidator.Usernamevalid(username);
            if (!usernamecheck.Issuccess)
                return Result<ServiceUserDTO>.Fail(usernamecheck.Message);


            Result<T> chaningusername = csq.ChangingUserName(Terıd, username);
            if (!chaningusername.Issuccess)
                return Result<ServiceUserDTO>.Fail(chaningusername.Message);
           


            var Terdto = chaningusername.Value.userMapping();

            return Result<ServiceUserDTO>.Success(Terdto, chaningusername.Message);

        }
        public Result<ServiceUserDTO> GetUser(int ıd)
        {

            Result<T> result = csq.GetUser(ıd);

            if (!result.Issuccess)
                return Result<ServiceUserDTO>.Fail(result.Message);
           
             var dto=result.Value.userMapping();
            return Result<ServiceUserDTO>.Success(dto, default);
        }
      

    }
}
