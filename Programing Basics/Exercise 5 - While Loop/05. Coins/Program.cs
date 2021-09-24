using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double moneyInPences = Math.Floor(money * 100);
            int count = 0;

            while (moneyInPences > 0)
            {
                if (moneyInPences - 200 >= 0)
                {
                    count++;
                    moneyInPences = moneyInPences - 200;
                }
                else if (moneyInPences - 100 >= 0)
                {
                    count++;
                    moneyInPences = moneyInPences - 100;
                }
                else if (moneyInPences - 50 >= 0)
                {
                    count++;
                    moneyInPences = moneyInPences - 50;
                }
                else if (moneyInPences - 20 >= 0)
                {
                    count++;
                    moneyInPences = moneyInPences - 20;
                }
                else if (moneyInPences - 10 >= 0)
                {
                    count++;
                    moneyInPences = moneyInPences - 10;
                }
                else if (moneyInPences - 5 >= 0)
                {
                    count++;
                    moneyInPences = moneyInPences - 5;
                }
                else if (moneyInPences - 2 >= 0)
                {
                    count++;
                    moneyInPences = moneyInPences - 2;
                }
                else if (moneyInPences - 1 >= 0)
                {
                    count++;
                    moneyInPences = moneyInPences - 1;
                }
            }
            Console.WriteLine(count);
        }
    }
}
