using System;

namespace _01.ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());
            decimal km = meters / 1000.0M;
            Console.WriteLine($"{km:f2}");
        }
    }
}
