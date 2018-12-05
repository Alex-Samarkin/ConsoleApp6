using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    /// <summary>
    /// 
    /// </summary>
    public class Virus
    {
        // вероятность заражения
        public double Zaraza { get; set; }
        // инкубационный период
        public int IncTime { get; set; }
        // время болезни
        public int BolesnTime { get; set; }
        // вероятность смерти
        public double Dead { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zaraza"></param>
        /// <param name="incTime"></param>
        /// <param name="bolesnTime"></param>
        /// <param name="dead"></param>
        public Virus(double zaraza = 0.2, int incTime = 3, int bolesnTime = 7, double dead = 0.1)
        {
            Zaraza = zaraza;
            IncTime = incTime;
            BolesnTime = bolesnTime;
            Dead = dead;
        }

    }
}
