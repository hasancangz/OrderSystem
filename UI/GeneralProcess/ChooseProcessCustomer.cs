using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.GeneralProcess
{
    public static class ChooseProcessCustomer
    {
        public static int Process()
        {
            while (true)
            {

                Console.WriteLine("1.Showing Information");
                Console.WriteLine("2.Creating Order");
                Console.WriteLine("3.Showing Previous Order");
                Console.WriteLine("4.Changing Password");
                Console.WriteLine("5.Changing Username");
                Console.WriteLine("6.Retuning Main Menu");
                Console.WriteLine("7.Off App");
                Console.Write("Please choose the process that you want:");

                try
                {
                    int proc = Convert.ToInt32(Console.ReadLine());

                    _ = proc switch
                    {
                        < 1 or > 7 => throw new Exception("Please choose a right valid process"),
                        _ => proc
                    };

                    return proc;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    DeleteHelper.Delete();
                    continue;

                }


            }




        }


    }
}
