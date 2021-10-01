using System;

namespace _1._Change_бюро
{
    class Program
    {
        static void Main(string[] args)
        {
            int countBitcoins = int.Parse(Console.ReadLine());
            double countYuans = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine()) / 100;

            double finalInEuros = (countBitcoins * (1168 / 1.95) + countYuans * ((0.15 * 1.76) / 1.95))*(1.00-comission);

            Console.WriteLine($"{finalInEuros:f2}");
        }
    }
}
