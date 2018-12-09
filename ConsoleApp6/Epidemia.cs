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
                                ManyHumans.Humans[i].IsAlive = true;
                            }
                        }

                    }
                    
                }
            }
        }

        // больные встречаются с выбранными наугад N1=20 людьми
        // если встретился здоровый то с вероятностью из вируса заражаем его
        // тогда также устанавливаем день болезни 1
        private void InfectedThem(int N1= 20)
        {
            // перебираем пациентов
            for (int i = 0; i < this.ManyHumans.MAX_HUMANS; i++)
            {
                // убеждаемся, что пациент не умер = жив
                if (!(ManyHumans.Humans[i].IsDead))
                {
                    // проверяем, что пациент болен
                    if (!(ManyHumans.Humans[i].IsAlive))
                    {
                        // в цикле N1 раз моделируем контакт
                        for (int j = 0; j < N1; j++)
                        {
                            // номер пациента для контакта
                            int contact = _random.Next(0, ManyHumans.MAX_HUMANS);
                            // если он здоров и не имеет иммунитета
                            if (ManyHumans.Humans[contact].IsAlive && !ManyHumans.Humans[contact].HaveImmunitet )
                            {
                                if (Test(Virus.Zaraza))
                                {
                                    // заболел при контакте
                                    ManyHumans.Humans[contact].IsAlive = false;
                                    // задаем срок болезни - 1 день
                                    ManyHumans.Humans[contact].InfestTime = 1;
                                }
                            }
                        }

                    }
                }
            }
        }

        /// <summary>
        /// для следующего дня просматриваем больных и увеличиваем им срок на 1
        /// </summary>
        private void NextDay()
        {
            // перебираем пациентов
            for (int i = 0; i < this.ManyHumans.MAX_HUMANS; i++)
            {
                // если нездоров
                if (!(this.ManyHumans.Humans[i].IsAlive))
                {
                    this.ManyHumans.Humans[i].InfestTime += 1;
                }

            }
        }
        /// <summary>
        /// открытый метод для имитации одного дня эпидемии
        /// </summary>
        public void Step()
        {
            // увеличиваем время эпидемии
            this.Day += 1;
            Console.WriteLine($"Time of epidemia {Day}");
            // увеличиваем сроки болезней пациентов
            Console.WriteLine("Считаем больных");
            NextDay();

            // убиваем кого можно
            Console.WriteLine("Считаем умерших");
            KillThem();

            // заражаем
            Console.WriteLine("Моделируем заражение новых");
            InfectedThem();

            Console.WriteLine(ManyHumans.Stat());
        }

        public Epidemia()
        {
            ManyHumans.Init();
            Console.WriteLine(ManyHumans.Stat());
        }

        /// <summary>
        /// заражаем несколько случайных пациентов
        /// </summary>
        /// <param name="infectedAtStart"></param>
        public void Init(int infectedAtStart = 50)
        {
            for (int i = 0; i < infectedAtStart; i++)
            {
                // номер пациента для контакта
                int contact = _random.Next(0, ManyHumans.MAX_HUMANS);
                ManyHumans.Humans[contact].IsAlive = false;

            }

        }
    }
}
