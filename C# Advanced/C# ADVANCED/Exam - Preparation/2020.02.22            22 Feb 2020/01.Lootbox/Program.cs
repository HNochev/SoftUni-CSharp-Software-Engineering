using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> first = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            Stack<int> second = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            int sum = 0;

            while (first.Count > 0 && second.Count > 0)
            {
                int firstLoot = first.Peek();
                int secondLoot = second.Pop();

                int currSum = firstLoot + secondLoot;

                if (currSum % 2 == 0)
                {
                    sum = sum + currSum;
                    first.Dequeue();
                }
                else
                {
                    first.Enqueue(secondLoot);
                }
            }

            if (first.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
