using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
    internal class Choosewayofentry
    {


        public static int Choose()
        {
            while (true)
            {

                Console.WriteLine("1.Customer Login");
                Console.WriteLine("2.Manager Login");
                Console.WriteLine("3.Customer Register");
                Console.Write("Please choose the way of entry:");

                try
                {
                    int entry= Convert.ToInt32(Console.ReadLine());

                    _ = entry switch
                    {
                        < 1 or > 3 => throw new Exception("Please choose a right valid process"),
                        _ => entry
                    };

                    return entry;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                DeleteHelper.Delete();
            }
        }
    }
}
