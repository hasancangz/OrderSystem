using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("C__SQL_ADO.NET_UI")]


namespace C__SQL_ADO.NET_Domain.DomainRule
{
    public class Result<T>
    {
        public bool Issuccess { get; }
        public string Message { get; }
        public T Value { get; }

        private Result(bool istrue,T value,string message)
        {
            Issuccess = istrue;  
            Value = value;
            Message = message;
        }
  
        public static Result<T> Success(T value,string message)
        {
            return new Result<T>(true,value, message);
        }
        public static Result<T> Fail(string error)
        {
            return new Result<T>(false,default, error);
        }


    }
}
