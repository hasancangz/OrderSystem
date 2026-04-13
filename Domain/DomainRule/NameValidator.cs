using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_Domain.DomainRule
{
  public static class NameValidator
    {

        internal static List<Func<string, Result<bool>>> rules = new List<Func<string, Result<bool>>>
        {

             (y=>
             {
                 if(!y.Any(char.IsLetter))
                     return Result<bool>.Fail("Does not exists anything inside in name except for letter");

                 return Result<bool>.Success(true,default);
             })

        };




        public static Result<bool> namevalid(string name)
        {
            foreach (var rule in rules)
            {
                Result<bool> result = rule(name);

                if (!result.Issuccess)
                    return Result<bool>.Fail(result.Message);
                        
            }

            return Result<bool>.Success(true, default);

        }

    }
}
