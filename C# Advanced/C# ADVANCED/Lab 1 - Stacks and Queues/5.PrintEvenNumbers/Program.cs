using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> even = new Queue<int>(nums.Where(x => x % 2 == 0));

            Console.WriteLine(string.Join(", ", even));
        }
    }
}
