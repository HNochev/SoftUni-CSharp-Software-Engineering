using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] capacities = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> one = new HashSet<int>();
            HashSet<int> two = new HashSet<int>();

            int n = capacities[0];
            int m = capacities[1];

            for (int i = 0; i < n; i++)
            {
                one.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < m; i++)
            {
                two.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var num in one)
            {
                if (two.Contains(num))
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
