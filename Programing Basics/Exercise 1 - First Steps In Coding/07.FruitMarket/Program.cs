using System;

namespace _07.FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double kgOfBananas = double.Parse(Console.ReadLine());
            double kgOfOranges = double.Parse(Console.ReadLine());
            double kgOfraspberry = double.Parse(Console.ReadLine());
            double kgOfStrawberry = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberryPrice / 2;
            double orangesPrice = raspberryPrice * 0.60;
            double bananasPrice = raspberryPrice * 0.20;

            double sumOfRaspberry = raspberryPrice * kgOfraspberry;
            double sumOfOranges = orangesPrice * kgOfOranges;
            double sumOfBananas = bananasPrice * kgOfBananas;
            double sumOfStrawberry = strawberryPrice * kgOfStrawberry;

            double finalSum = sumOfBananas + sumOfOranges + sumOfRaspberry + sumOfStrawberry;

            Console.WriteLine($"{finalSum:f2}");

        }
    }
}
