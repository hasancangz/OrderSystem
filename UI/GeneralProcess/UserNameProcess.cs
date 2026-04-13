using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
    static class UserNameProcess
    {

        //valid işlemleri service kısmından alınıp iş kısmına alınabilir

        static public string ProcessUserName()
        {

            Console.Write("Please enter new username:");
            string newusername= Console.ReadLine();

            return newusername;
        }
    }
}
