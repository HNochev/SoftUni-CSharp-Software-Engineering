using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            List<int> secondPlayer = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            for (int i = 0; i < Math.Min(firstPlayer.Count, secondPlayer.Count); i++)
            {
                if (firstPlayer[i] == secondPlayer[i])
                {
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                }
                else if (firstPlayer[i] > secondPlayer[i])
                {
                    firstPlayer.Add(firstPlayer[i]);
                    firstPlayer.Add(secondPlayer[i]);
                    firstPlayer.RemoveAt(i);
                    secondPlayer.RemoveAt(i);
                }
                else if(firstPlayer[i] < secondPlayer[i])
                {
                    secondPlayer.Add(secondPlayer[i]);
                    secondPlayer.Add(firstPlayer[i]);
                    secondPlayer.RemoveAt(i);
                    firstPlayer.RemoveAt(i);
                }
                i = -1;
            }
            if(firstPlayer.Count>secondPlayer.Count)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }
        }
    }
}
