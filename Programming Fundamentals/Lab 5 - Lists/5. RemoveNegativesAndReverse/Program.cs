using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = numbers
                .Where(n => n >= 0)
                .Reverse()
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(' ', result));
            }
        }
    }
}
