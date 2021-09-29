using System;

namespace _01._MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double price = 0;

            if (category == "VIP")
            {
                price = 499.99;
            }
            else if (category == "Normal")
            {
                price = 249.99;
            }

            if (people <= 4)
            {
                budget = budget * 0.25;
            }
            else if (people > 4 && people <= 9)
            {
                budget = budget * 0.40;
            }
            else if (people > 9 && people <= 24)
            {
                budget = budget * 0.50;
            }
            else if (people > 24 && people <= 49)
            {
                budget = budget * 0.60;
            }
            else if (people > 49)
            {
                budget = budget * 0.75;
            }

            double finalPrice = people * price;

            if (budget > finalPrice)
            {
                Console.WriteLine($"Yes! You have {budget - finalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(budget - finalPrice):f2} leva.");
            }
        }
    }
}
