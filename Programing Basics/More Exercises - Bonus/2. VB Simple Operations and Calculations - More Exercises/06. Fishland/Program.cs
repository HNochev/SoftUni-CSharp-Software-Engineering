using System;

namespace _06._Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double mackerelPrice = double.Parse(Console.ReadLine());
            double spratPrice = double.Parse(Console.ReadLine());
            double bonitoKg = double.Parse(Console.ReadLine());
            double horseMackerelKg = double.Parse(Console.ReadLine());
            double shellKG = double.Parse(Console.ReadLine());

            double bonitoPrice = mackerelPrice * 1.60;
            double horseMackerelPrice = spratPrice * 1.80;

            double finalBonitoPrice = bonitoPrice * bonitoKg;
            double finalhorseMackerelPrice = horseMackerelPrice * horseMackerelKg;
            double finalShellPrice = 7.50 * shellKG;

            double finalPrice = finalBonitoPrice + finalhorseMackerelPrice + finalShellPrice;

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
