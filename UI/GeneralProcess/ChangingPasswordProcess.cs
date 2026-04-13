using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
   public static class ChangingPasswordProcess
    {
        public record PassWordInfo(string oldpassword,string newpassword);

        public static PassWordInfo PasswordProcess()
        {

            Console.Write("Please enter old password:");
            string oldpas=Console.ReadLine();

            Console.Write("Please enter new password:");
            string newpas =Console.ReadLine();

            return new PassWordInfo(oldpas,newpas);
        }

    }
}
