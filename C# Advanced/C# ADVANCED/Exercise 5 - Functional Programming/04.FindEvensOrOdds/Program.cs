using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] startEnd = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = startEnd[0];
            int end = startEnd[1];

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            string oddEven = Console.ReadLine();

            Console.WriteLine(string.Join(" ", numbers.Where(getOddEven(oddEven))));
        }

        static Func<int, bool> getOddEven(string oddEven)
        {
            switch (oddEven)
            {
                case "odd":
                    {
                        return x => x % 2 != 0;
                    }
                case "even":
                    {
                        return x => x % 2 == 0;
                    }
                default:
                    return null;
            }
        }
    }
}
