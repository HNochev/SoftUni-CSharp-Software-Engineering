using System;

namespace _07._FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine());
            int zumbuls = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactuses = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());

            double finalProfit = magnolias * 3.25 + zumbuls * 4 + roses * 3.5 + cactuses * 8;
            finalProfit = finalProfit - (finalProfit * 0.05);

            if (finalProfit >= price)
            {
                Console.WriteLine($"She is left with {Math.Floor(finalProfit - price)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(price - finalProfit)} leva.");
            }
        }
    }
}
