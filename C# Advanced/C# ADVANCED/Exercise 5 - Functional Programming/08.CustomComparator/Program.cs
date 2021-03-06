using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, (a, b) =>
                {
                    if (a % 2 != 0 && b % 2 == 0)
                    {
                        return 1;
                    }
                    else if (a % 2 == 0 && b % 2 != 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return a.CompareTo(b);
                    }
                });

            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));
            print(numbers);
        }
    }
}
