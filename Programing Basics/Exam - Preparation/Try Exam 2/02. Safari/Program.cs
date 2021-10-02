using System;

namespace _02._Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double litersFuel = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double priceForLiter = 2.10;
            double fullPriceForFuel = litersFuel * priceForLiter;

            double fullPrice = fullPriceForFuel + 100;

            if(day == "Saturday")
            {
                fullPrice = fullPrice * 0.90;
            }
            else if(day == "Sunday")
            {
                fullPrice = fullPrice * 0.80;
            }

            if(budget>=fullPrice)
            {
                Console.WriteLine($"Safari time! Money left: {budget - fullPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {fullPrice - budget:f2} lv.");
            }
        }
    }
}
