using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            nums.Sort();
            nums.Reverse();

            if (nums.Count > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{nums[i]} ");
                }
            }
            else
            {
                Console.WriteLine(string.Join(' ', nums));
            }
        }
    }
}
