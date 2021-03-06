using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());

            decimal startPump = 0;
            decimal fuelLeft = 0;

            for (decimal i = 0; i < n; i++)
            {
                List<decimal> pair = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(decimal.Parse)
                         .ToList();

                decimal gasPump = pair[0];
                decimal distanceToNext = pair[1];

                fuelLeft += gasPump;

                if (fuelLeft >= distanceToNext)
                {
                    fuelLeft = fuelLeft - distanceToNext;
                }
                else
                {
                    startPump = i + 1;
                    fuelLeft = 0;
                }
            }
            Console.WriteLine($"{startPump}");
        }
    }
}
