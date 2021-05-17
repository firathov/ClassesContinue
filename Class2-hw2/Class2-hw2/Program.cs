﻿using System;

namespace Class2_hw2
{
    class Account
    {
        private decimal sum;
        private decimal number;
        private DateTime data;

        public Account(decimal sum, decimal number, DateTime data)
        {
            this.sum = sum;
            this.number = number;
            this.data = data;
        }

        public decimal Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
            }
        }
        public decimal Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        public DateTime Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        public virtual void AccSum(decimal sum)
        {

            Console.WriteLine($"Ваш баланс {sum}");
            
        }
        public void accData()
        {
            Console.WriteLine($"Дата открытия:{" " + data.ToString("D")}"); // это я взял с интернета
        }
    }
    class IndividualAccount: Account
    {
        private string accType;
        public string AccType
        {
            get
            {
                return accType;
            }
            set
            {
                accType = value;
            }
        }

        public IndividualAccount(decimal sum, decimal number, DateTime data, string accType)
            :base (sum, number,data)
        {
            this.accType = accType;
        }

        public void AccTyper()
        {
            Console.WriteLine("Укажите тип счёта:\n1) Дебетовый\n2)Кредитный\n3)Депозитный\n");
            int switcher = forNumberCheck();
            switch (switcher)
            {
                case 1:
                    Console.WriteLine("Ваш счёт дебетовый\n");
                    Console.WriteLine("--------------------\n");
                    break;
                case 2:
                    Console.WriteLine("Ваш счёт кредитный\n");
                    Console.WriteLine("--------------------\n");
                    break;
                case 3:
                    Console.WriteLine("Ваш счёт депозитный\n");
                    Console.WriteLine("--------------------\n");
                    break;

            }
        }

        public decimal Percent(DateTime data, decimal sum)
        {
            int years = DateTime.Now.Year - data.Year;
            for (int i = 0; i < years; i++)
            {
                sum += sum * 0.08M;
            }
            return sum;
        }

        public decimal CashOut(decimal sum)
        {
            bool booler = true;
            Console.Write("Укажите сумму, которую хотите обналичивать: ");
            do
            {
                decimal cash = forNumberCheck();
                if(cash > sum)
                {
                    Console.Write("Недостаточно денег, попробуйте ещё: ");
                    
                }
                else
                {
                    sum = sum - cash;
                    booler = false;
                }
            }
            while (booler == true);
            return sum;
        }

        public override void AccSum(decimal sum)
        {
            Console.WriteLine($"Баланс при открытии счёта {sum}");
        }
        public void SumAfterPercent(decimal sum, DateTime data)
        {
            Console.WriteLine($"Ваш баланс {sum} с {data.ToString("D")}");
        }
        public void SumAfterCash (decimal sum)
        {
            Console.WriteLine($"Ваш баланс после вывода денег {sum}");
        }
        static int forNumberCheck()
        {
            int number;

            for (; ; )
            {
                string checkingNumber = Console.ReadLine();
                ;
                if (Int32.TryParse(checkingNumber, out number) && number > 0)
                {
                    return number;
                }
                else
                {
                    Console.Write("Вы ввели неправильный символ, попробуйте ещё: ");
                }
            }
        }
    }

    class Entity: Account
    {
        public Entity (decimal sum, decimal number, DateTime data)
            :base (sum, number, data)
        {
            
        }
        public decimal Percent2 (DateTime data, decimal sum2)
        {
            int years = DateTime.Now.Year - data.Year;
            for (int i = 0; i < years; i++)
            {
                sum2 += sum2 * 0.08M;
            }
            return sum2;
        }
        public void SumAfterPercent2 (DateTime data, decimal sum2)
        {
            Console.WriteLine($"Ваш баланс {sum2} с {data.ToString("D")}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            decimal sum = 1000;
            DateTime data = new DateTime(2020, 05, 16);
            decimal number = 3880009812321454;
            Account account = new Account(sum, number, data);

            string accType = "Физический счёт";
            Console.WriteLine($"\n{accType}");
            IndividualAccount individual = new IndividualAccount(sum, number, data, accType);
            individual.AccTyper();
            individual.AccSum(sum);
            sum = individual.Percent(data, sum);
            individual.SumAfterPercent(sum, data);
            sum = individual.CashOut(sum);
            individual.SumAfterCash(sum);

            string accType2 = "Юридический счёт";
            Console.WriteLine($"\n{accType2}");
            decimal sum2 = 500;
            decimal number2 = 3242342231231321;
            DateTime data2 = new DateTime(2019, 06, 30);
            Entity entity = new Entity(sum2, number2, data2);
            sum = entity.Percent2(data, sum2);
            entity.SumAfterPercent2(data, sum);

            Console.ReadKey();
        }

        
    }
}
