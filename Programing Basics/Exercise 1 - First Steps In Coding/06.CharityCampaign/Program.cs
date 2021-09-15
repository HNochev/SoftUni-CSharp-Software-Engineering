using System;

namespace _06.CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            double cakePrice = 45;
            double wafflePrice = 5.80;
            double pancakePrice = 3.20;

            int days = int.Parse(Console.ReadLine());
            int cookers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double fullPriceOfCakes = cakes * cakePrice;
            double fullPriceOfWaffles = waffles * wafflePrice;
            double fullPriceOfPancakes = pancakes * pancakePrice;
            double sumForADay = (fullPriceOfCakes + fullPriceOfPancakes + fullPriceOfWaffles) * cookers;
            double allDaysSum = sumForADay * days;

            double onlyProfitSum = allDaysSum - (allDaysSum / 8);

            Console.WriteLine($"{onlyProfitSum:0.00}");

        }
    }
}
