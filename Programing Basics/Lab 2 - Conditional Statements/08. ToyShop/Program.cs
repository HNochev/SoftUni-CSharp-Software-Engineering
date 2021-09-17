using System;

namespace _08._ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double puzzle = 2.60;
            double talkingDoll = 3.00;
            double teddyBear = 4.10;
            double minion = 8.20;
            double truck = 2.00;

            double priceOfTrip = double.Parse(Console.ReadLine());
            int puzzlesCount = int.Parse(Console.ReadLine());
            int talkingDollsCount = int.Parse(Console.ReadLine());
            int teddyBearsCount = int.Parse(Console.ReadLine());
            int minionsCount = int.Parse(Console.ReadLine());
            int trucksCount = int.Parse(Console.ReadLine());

            double finalPrice = puzzle * puzzlesCount + talkingDoll * talkingDollsCount + teddyBear * teddyBearsCount + minion * minionsCount + truck * trucksCount;

            int finalCount = puzzlesCount + talkingDollsCount + teddyBearsCount + minionsCount + trucksCount;

            if(finalCount >= 50)
            {
                finalPrice = finalPrice * 0.75;
            }

            double finalPriceWithRent = finalPrice * 0.90;

            double final = finalPriceWithRent - priceOfTrip;

            if (finalPriceWithRent >= priceOfTrip)
            {
                Console.WriteLine($"Yes! {final:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {Math.Abs(final):f2} lv needed.");
            }
        }
    }
}
