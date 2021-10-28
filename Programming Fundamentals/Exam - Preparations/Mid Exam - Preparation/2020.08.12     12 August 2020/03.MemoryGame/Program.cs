using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string input = Console.ReadLine();
            int moves = 0;
            int middleIndex = 0;

            while (input != "end")
            {
                int[] nums = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                moves++;

                if (nums[0] == nums[1] || nums[0] < 0 || nums[1] < 0 || nums[0] > elements.Count - 1 || nums[1] > elements.Count - 1)
                {
                    middleIndex = (elements.Count) / 2;
                    elements.Insert(middleIndex, $"-{moves}a");
                    elements.Insert(middleIndex, $"-{moves}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    input = Console.ReadLine();
                    continue;
                }

                if (elements[nums[0]] == elements[nums[1]])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[nums[0]]}!");
                    string currElem = elements[nums[0]];
                    elements.RemoveAll(x => x == currElem);
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    return;
                }

                input = Console.ReadLine();
            }
            if (elements.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(' ', elements));
            }
        }
    }
}
