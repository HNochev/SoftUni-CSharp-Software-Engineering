using System;

namespace _06.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double clothesPriceOfOneStatist = double.Parse(Console.ReadLine());

            double decorPrice = budget * 0.10;
            double finalPriceForClothes = statists * clothesPriceOfOneStatist;
            if(statists > 150)
            {
                finalPriceForClothes = finalPriceForClothes * 0.90;
            }
            double finalSum = finalPriceForClothes + decorPrice;
            double finalResult = budget - finalSum;

            if(finalSum > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(finalResult):f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {finalResult:f2} leva left.");
            }
        }
    }
}
