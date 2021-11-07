using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int n = nsx[0];
            int s = nsx[1];
            int x = nsx[2];

            int[] number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(number);

            for (int i = 0; i < s; i++)
            {
                numbers.Pop();
            }

            if(numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Any())
            {
                Console.WriteLine(numbers.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
