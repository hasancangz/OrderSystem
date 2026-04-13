using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Domain.DomainRule
{
    public class UserNameValidator
    {

        internal static List<Func<string, Result<bool>>> rules = new List<Func<string, Result<bool>>>
        {
            (x=>
            {
                if(x.Count(char.IsLetter)>=5)
                    return Result<bool>.Success(true,default);

                return Result<bool>.Fail("at least 5 letters have to be exists in username");

            }),

                 ( y) =>
                {
                    if (y.Count(char.IsDigit) >= 3)
                    {
                        return Result<bool>.Success(true, default);
                    }
                    return Result<bool>.Fail("at least 3 digit have to exists in username");
                 },

                ( y) =>
                {
                    if (y.Count(char.IsUpper) >= 1)
                    {
                        return Result<bool>.Success(true, default);
                    }
                    return Result<bool>.Fail("at least 1 Upper letter have to exists in username");
                },
                (y) =>
                {
                    if (y.Count(char.IsSymbol) >= 1)
                    {
                        return Result<bool>.Success(true, default);
                    }
                    return Result<bool>.Fail("at least 1 symbol charc have to exists in username");

                }
        };




        public static Result<bool> Usernamevalid(string username)
        {
            foreach (var rule in rules)
            {
                if (!rule(username).Issuccess)
                    return rule(username);
            }

            return Result<bool>.Success(true,default);

        }


    }
}
