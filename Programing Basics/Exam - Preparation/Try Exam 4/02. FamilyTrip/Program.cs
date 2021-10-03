using System;

namespace _02._FamilyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double priceNight = double.Parse(Console.ReadLine());
            double percentAddons = double.Parse(Console.ReadLine());

            if (nights > 7)
            {
                priceNight = priceNight * 0.95;
            }
            double fullPrice = priceNight * nights;
            double addons = budget * (percentAddons / 100);

            double all = fullPrice + addons;

            if(all <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget-all:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{all-budget:f2} leva needed.");
            }
        }
    }
}
