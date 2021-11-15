using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> minFunc = numbers =>
            {
                int min = int.MaxValue;
                foreach (var num in numbers)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }
                return min;
            };

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(minFunc(numbers));
        }
    }
}
