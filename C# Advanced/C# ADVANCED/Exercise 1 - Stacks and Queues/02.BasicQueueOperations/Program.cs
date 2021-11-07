using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
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

            int[] numbersArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                numbers.Enqueue(numbersArray[i]);
            }

            for (int i = 0; i < s; i++)
            {
                numbers.Dequeue();
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
