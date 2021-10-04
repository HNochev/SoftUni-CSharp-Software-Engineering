using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceUSDForProcessor = double.Parse(Console.ReadLine());
            double priceUSDForGPU = double.Parse(Console.ReadLine());
            double priceUSDFor1RAM = double.Parse(Console.ReadLine());
            int piecesRAM = int.Parse(Console.ReadLine());
            double discountPercent = double.Parse(Console.ReadLine());

            double priceLVForProcessor = priceUSDForProcessor * 1.57;
            double priceLVForGPU = priceUSDForGPU * 1.57;
            double fullRAMPriceUSD = priceUSDFor1RAM * piecesRAM;
            double fullRAMPriceLV = fullRAMPriceUSD * 1.57;

            priceLVForProcessor = priceLVForProcessor * (1 - discountPercent);
            priceLVForGPU = priceLVForGPU * (1 - discountPercent);


            double finalPrice = priceLVForProcessor + priceLVForGPU + fullRAMPriceLV;
            

            Console.WriteLine($"Money needed - {finalPrice:f2} leva.");
        }
    }
}
