using System;

namespace _04._VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceVegetablesKG = double.Parse(Console.ReadLine());
            double priceFruitsKG = double.Parse(Console.ReadLine());
            double kgOFVegetables = double.Parse(Console.ReadLine());
            double kgOfFruits = double.Parse(Console.ReadLine());

            double priceInLV = (priceVegetablesKG * kgOFVegetables) + (priceFruitsKG * kgOfFruits);
            double priceInEURO = priceInLV / 1.94;

            Console.WriteLine($"{priceInEURO:f2}");
        }
    }
}
