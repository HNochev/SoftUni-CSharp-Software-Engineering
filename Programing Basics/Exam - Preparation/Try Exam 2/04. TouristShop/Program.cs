using System;

namespace _04._TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string productName = Console.ReadLine();
            int productCount = 0;
            double finalPrice = 0;

            while (productName != "Stop")
            {
                double priceProduct = double.Parse(Console.ReadLine());
                productCount++;
                if (productCount % 3 == 0)
                {
                    priceProduct = priceProduct * 0.50;
                }
                finalPrice = finalPrice + priceProduct;
                if (finalPrice > budget)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {finalPrice - budget:f2} leva!");
                    break;
                }
                productName = Console.ReadLine();
            }
            if (productName == "Stop")
            {
                Console.WriteLine($"You bought {productCount} products for {finalPrice:f2} leva.");
            }
        }
    }
}
