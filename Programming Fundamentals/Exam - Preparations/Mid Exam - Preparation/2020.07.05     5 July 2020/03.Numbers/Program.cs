using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double averageNumber = numbers.Average();

            numbers.Sort();
            numbers.Reverse();

            List<int> result = numbers
                .Where(x => x >= averageNumber)
                .ToList();

            int counter = 0;

            while(counter != 5 && result.Count > counter && result[counter] != averageNumber)
            {
                Console.Write($"{result[counter]} ");
                counter++;
            }
            if (counter == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
