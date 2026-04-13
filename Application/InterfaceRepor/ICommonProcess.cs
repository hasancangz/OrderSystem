using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Application.InterfaceRepor
{
    public interface ICommonProcess<T>
    {
        Result<T> TakingPassword(int Tıd, byte[] oldpassword);
        Result<T> ChangingPassword(string oldpass,int Tıd, string newps);

        Result<T> ChangingUserName(int Tıd, string username);

        Result<T> GetUser(int Tıd);

    }
}
