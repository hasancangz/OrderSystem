using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
    internal class AppORCan
    {

        public int AppOrCn()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("1.ApproveOrder");
                    Console.WriteLine("2.CancelOrder");
                    Console.Write("Please choose the process that you want:");
                    int t = Convert.ToInt32(Console.ReadLine());

                    if (t != 1 && t != 2)
                        throw new Exception("Please choose a valid process ");

                    return t;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                DeleteHelper.Delete();
            }

        }
    }
}

