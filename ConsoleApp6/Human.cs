using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Human
    {
        public int id { get; set; } = 0;
        // мертвый или живой
        public bool IsDead { get; set; } = false;
        // если живой, то здоровый или нет?
        public bool IsAlive { get; set; } = true;
        // время заражения
        public int InfestTime { get; set; } = 0;
        // есть ли иммунитет
        public bool HaveImmunitet { get; set; } = false;
    }
}
