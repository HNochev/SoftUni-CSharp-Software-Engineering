using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string timeOfYear = Console.ReadLine();
            string destination = "a";
            string place = "a";
            double spentMoney = 0.00;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (timeOfYear == "summer")
                {
                    place = "Camp";
                    spentMoney = budget * 0.30;
                }
                else if (timeOfYear == "winter")
                {
                    place = "Hotel";
                    spentMoney = budget * 0.70;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (timeOfYear == "summer")
                {
                    place = "Camp";
                    spentMoney = budget * 0.40;
                }
                else if (timeOfYear == "winter")
                {
                    place = "Hotel";
                    spentMoney = budget * 0.80;
                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";
                if (timeOfYear == "summer")
                {
                    place = "Hotel";
                    spentMoney = budget * 0.90;
                }
                else if (timeOfYear == "winter")
                {
                    place = "Hotel";
                    spentMoney = budget * 0.90;
                }
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{place} - {spentMoney:f2}");
        }
    }
}