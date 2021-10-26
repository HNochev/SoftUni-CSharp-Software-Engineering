using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> houses = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();
            int currIndex = 0;

            while (input != "Love!")
            {
                string[] jump = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int lenghtJump = int.Parse(jump[1]);
                currIndex = currIndex + lenghtJump;



                if (currIndex >= houses.Count)
                {
                    currIndex = 0;
                }

                if (houses[currIndex] == 0)
                {
                    Console.WriteLine($"Place {currIndex} already had Valentine's day.");
                    input = Console.ReadLine();
                    continue;
                }
                houses[currIndex] = houses[currIndex] - 2;
                if (houses[currIndex] == 0)
                {
                    Console.WriteLine($"Place {currIndex} has Valentine's day.");
                    input = Console.ReadLine();
                    continue;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Cupid's last position was {currIndex}.");
            if (houses.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houses.Count(x => x > 0)} places.");
            }
        }
    }
}
