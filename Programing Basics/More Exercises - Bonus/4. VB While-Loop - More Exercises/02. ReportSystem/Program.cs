using System;

namespace _02._ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int expectedSum = int.Parse(Console.ReadLine());
            string money = Console.ReadLine();
            int counter = 0;
            double averageCard = 0;
            double averageCash = 0;
            int cardCounter = 0;
            int cashCounter = 0;
            double finalSum = 0;

            while (money != "End")
            {
                double moneyInt = double.Parse(money);
                if (counter % 2 == 0)
                {
                    if (moneyInt > 100 && moneyInt != 0)
                    {
                        Console.WriteLine("Error in transaction! ");
                    }
                    else
                    {
                        cashCounter++;
                        averageCash = averageCash + moneyInt;
                        Console.WriteLine("Product sold!");
                        finalSum = finalSum + moneyInt;
                    }
                    if (finalSum >= expectedSum)
                    {
                        Console.WriteLine($"Average CS: {averageCash / cashCounter:f2}");
                        Console.WriteLine($"Average CC: {averageCard / cardCounter:f2}");
                        break;
                    }
                }
                else
                {
                    if (moneyInt < 10 && moneyInt != 0)
                    {
                        Console.WriteLine("Error in transaction! ");
                    }
                    else
                    {
                        cardCounter++;
                        averageCard = averageCard + moneyInt;
                        Console.WriteLine("Product sold!");
                        finalSum = finalSum + moneyInt;
                    }
                }
                if (finalSum >= expectedSum)
                {
                    Console.WriteLine($"Average CS: {averageCash / cashCounter:f2}");
                    Console.WriteLine($"Average CC: {averageCard / cardCounter:f2}");
                    break;
                }
                counter++;
                money = Console.ReadLine();
            }
            if(money == "End")
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
