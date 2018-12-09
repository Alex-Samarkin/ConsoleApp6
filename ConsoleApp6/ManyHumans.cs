using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class ManyHumans
    {
        // всего жителей
        public int MAX_HUMANS { get; set; } = 200000;
        public List<Human> Humans { get; set; } = new List<Human>();

        public void Init()
        {
            for (int i = 0; i < this.MAX_HUMANS; i++)
            {
                Human h = new Human();
                h.id = i;
                Humans.Add(h);
                //Console.WriteLine($"Пациент {i}");
            }

            Console.WriteLine("Humans ready");
        }

        public int DeadsCount()
        {
            int res = 0;
            foreach (Human h in Humans)
            {
                if (h.IsDead)
                {
                    res++;
                }
            }

            return res;
        }

        public int AliveCount()
        {
            int res = 0;
            foreach (Human h in Humans)
            {
                if (h.IsAlive)
                {
                    res++;
                }
            }

            return res;
        }
        public int ImmunitetCount()
        {
            int res = 0;
            foreach (Human h in Humans)
            {
                if (h.HaveImmunitet)
                {
                    res++;
                }
            }

            return res;
        }

        public string Stat()
        {
            return $"Всего {MAX_HUMANS}, здоровых {AliveCount()}, с иммунитетом {ImmunitetCount()}\n" +
                   $"Больных {MAX_HUMANS - AliveCount()}, умерших - {DeadsCount()}";
        }
    }
}
