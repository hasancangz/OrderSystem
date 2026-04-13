using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Domain.DomainRule
{
    public static class PasswordValidator
    {
        static private readonly List<Func<string, Result<bool>>> rules;


       static PasswordValidator()
        {

            rules = new List<Func< string, Result<bool>>>()
            {
               

                ( y) =>
                {
                    if (y.Length >= 8 && y.Length <= 64)
                    {
                        return Result<bool>.Success(true, default);
                    }

                    return Result<bool>.Fail("The length of password must be between 8 and 64 digit");


                },
                ( y) =>
                {
                    if (y.Count(char.IsLetter) >= 5)
                    {
                        return Result<bool>.Success(true, default);

                    }
                    return Result<bool>.Fail("at least 5 letters have to be exists in password");


                },

                ( y) =>
                {
                    if (y.Count(char.IsDigit) >= 3)
                    {
                        return Result<bool>.Success(true, default);
                    }
                    return Result<bool>.Fail("at least 3 digit have to exists in password");
                },

                ( y) =>
                {
                    if (y.Count(char.IsUpper) >= 1)
                    {
                        return Result<bool>.Success(true, default);
                    }
                    return Result<bool>.Fail("at least 1 Upper letter have to exists in password");
                },
                (y) =>
                {
                    if (y.Count(char.IsSymbol) >= 1)
                    {
                        return Result<bool>.Success(true, default);
                    }
                    return Result<bool>.Fail("at least 1 symbol charc have to exists in password");

                }
            };
        }

        static public Result<bool> PasswordCheck(byte[] oldpassword, string password)
        {
            if (HashHelper.ComputeSha256Hash(password).SequenceEqual(oldpassword))
            {
                return Result<bool>.Fail("New password must not be same old password");
            }
            return Result<bool>.Success(true, null);
        }



        static public Result<bool> PasswordCheck( string password)
        {


            foreach (var rule in rules)
            {
                if (!rule(password).Issuccess)
                    return rule(password);
            }

            return Result<bool>.Success(true, default);

        }
    }
}
