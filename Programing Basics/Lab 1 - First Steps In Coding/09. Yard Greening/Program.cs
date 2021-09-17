using System;

namespace _09._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double areaForGreening = double.Parse(Console.ReadLine());

            double finalPriceWithoutDiscount = areaForGreening * 7.61;
            double discount = finalPriceWithoutDiscount*0.18;
            double priceFinal = finalPriceWithoutDiscount - discount;

            Console.WriteLine($"The final price is: {priceFinal:0.00} lv.");
            Console.WriteLine($"The discount is: {discount:0.00} lv.");
        }
    }
}
