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
            epidemia.Step();
            epidemia.Step();

            Console.ReadKey();
        }
    }
}
