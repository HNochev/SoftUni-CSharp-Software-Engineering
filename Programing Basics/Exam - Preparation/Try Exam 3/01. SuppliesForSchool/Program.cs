using System;

namespace _01._SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double litersDetergent = double.Parse(Console.ReadLine());
            double discountPercent = double.Parse(Console.ReadLine());

            double pensPrice = pens * 5.80;
            double markersPrice = markers * 7.20;
            double detergentPrice = litersDetergent * 1.20;

            double finalPrice = pensPrice + markersPrice + detergentPrice;

            finalPrice = finalPrice - (finalPrice * (discountPercent / 100));

            Console.WriteLine($"{finalPrice:f3}");
        }
    }
}
