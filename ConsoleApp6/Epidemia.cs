using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Epidemia
    {
        // вирус
        public Virus Virus { get; set; } = new Virus();
        // пациенты (необходимо использовать Init для их создания
        public ManyHumans ManyHumans { get; set; } = new ManyHumans();

        // время эпидемии
        public int Day { get; set; } = 0;

        // вспомогательная функция - выдает истину или ложь с заданной вероятностью
        // например, если  prob = 0.2, то 2 раза из десяти будет истина, иначе - ложь

        // для ее работы  нужен генератор случайных чисел
        Random _random = new Random();

        private bool Test(double probValue=0.5)
        {
            // вероятность должна быть в диапазоне 0-1, иначе корректируем ее до 0,5
            if (probValue<0 || probValue>1)
            {
                probValue = 0.5;
            }
            // NextDouble - дает число от 0 до 1, равномерно распределенное
            // если оно меньше вероятности - выдаем истину, иначе - ложь
            return _random.NextDouble() < probValue;
        }

        // функции для расчета эпидемии

        // живые, проболевшие полный срок болезни, либо умирают (вероятность задана в вирусе)
        // либо получают иммунитет
        private void KillThem()
        {
            // перебираем пациентов
            for (int i = 0; i < this.ManyHumans.MAX_HUMANS; i++)
            {
                // убеждаемся, что пациент не умер = жив
                if ( !(ManyHumans.Humans[i].IsDead) )
                {
                    // проверяем, что пациент болен
                    if ( !(ManyHumans.Humans[i].IsAlive) )
                    {
                        // проверяем, что срок его болезни - больше инкубационного +время болезни
                        if ( ManyHumans.Humans[i].InfestTime > (Virus.IncTime+Virus.BolesnTime) )
                        {
                            if (Test(Virus.Dead))
                            {
                                ManyHumans.Humans[i].IsDead = true;
                            }
                            else
                            {
                                ManyHumans.Humans[i].HaveImmunitet = true;
                            }
                        }

                    }
                    
                }
            }
        }

    }
}
