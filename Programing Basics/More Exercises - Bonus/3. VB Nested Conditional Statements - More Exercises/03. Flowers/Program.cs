using System;
using System.Runtime.CompilerServices;

namespace _03._Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int hrizantemas = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int lulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holiday = Console.ReadLine();

            double hrizantemasPrice = 0;
            double rosesPrice = 0;
            double lulipsPrice = 0;

            int allFlowers = hrizantemas + roses + lulips;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    {
                        hrizantemasPrice = 2.00;
                        rosesPrice = 4.10;
                        lulipsPrice = 2.50;
                        break;
                    }
                case "Autumn":
                case "Winter":
                    {
                        hrizantemasPrice = 3.75;
                        rosesPrice = 4.50;
                        lulipsPrice = 4.15;
                        break;
                    }
            }
            if (holiday == "Y")
            {
                hrizantemasPrice = hrizantemasPrice * 1.15;
                rosesPrice = rosesPrice * 1.15;
                lulipsPrice = lulipsPrice * 1.15;
            }
            double finalPrice = hrizantemas * hrizantemasPrice + roses * rosesPrice + lulips * lulipsPrice;
            if (season == "Spring" && lulips > 7)
            {
                finalPrice = finalPrice * 0.95;
            }
            if (season == "Winter" && roses >= 10)
            {
                finalPrice = finalPrice * 0.90;
            }
            if (allFlowers > 20)
            {
                finalPrice = finalPrice * 0.80;
            }

            finalPrice = finalPrice + 2;
            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
