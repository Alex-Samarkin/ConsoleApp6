using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Эпидемия");

            // ManyHumans mh = new ManyHumans();
            // mh.Init();
            // Console.WriteLine(mh.DeadsCount());

            Epidemia epidemia = new Epidemia();
            epidemia.Init();
            Console.WriteLine(epidemia.ManyHumans.Stat());
            Console.WriteLine("====================================================================================");
            do
            {
                epidemia.Step();
                Console.WriteLine("введите 0 для выхода");
                ConsoleKeyInfo c = Console.ReadKey();
                if(c.KeyChar == '0')
                    break;

            } while (true);

            Console.ReadKey();
        }
    }
}
