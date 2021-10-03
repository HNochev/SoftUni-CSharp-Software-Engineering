using System;

namespace _04._Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            string coctail = Console.ReadLine();
            double finalPrice = 0;

            while (coctail != "Party!")
            {
                int countCoctails = int.Parse(Console.ReadLine());
                double price = coctail.Length;
                double fullPrice = countCoctails * price;
                if (fullPrice % 2 == 1)
                {
                    fullPrice = fullPrice * 0.75;
                }
                finalPrice = finalPrice + fullPrice;
                if (finalPrice >= neededMoney)
                {
                    Console.WriteLine($"Target acquired.");
                    Console.WriteLine($"Club income - {finalPrice:f2} leva.");
                    break;
                }
                coctail = Console.ReadLine();
            }
            if (coctail == "Party!")
            {
                Console.WriteLine($"We need {Math.Abs(neededMoney - finalPrice):f2} leva more.");
                Console.WriteLine($"Club income - {finalPrice:f2} leva.");
            }
        }
    }
}
