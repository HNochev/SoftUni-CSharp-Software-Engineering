using System;
using System.Runtime.CompilerServices;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());
            int days = 0;
            int spendConter = 0;

            while (spendConter < 5 && money < neededMoney)
            {
                string action = Console.ReadLine();
                double spentRaised = double.Parse(Console.ReadLine());

                if (action == "spend")
                {
                    spendConter++;
                    money = money - spentRaised;
                    if (money < 0)
                    {
                        money = 0;
                    }
                }
                else if (action == "save")
                {
                    money = money + spentRaised;
                    spendConter = 0;
                }
                days++;
            }
            if (spendConter >= 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }
            if (money >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
