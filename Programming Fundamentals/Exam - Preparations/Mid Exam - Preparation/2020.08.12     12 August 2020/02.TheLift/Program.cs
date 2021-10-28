using System;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int counter = 0;

            while (peopleWaiting != 0)
            {
                if (counter == wagons.Length && peopleWaiting > 0)
                {
                    Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                    Console.WriteLine(string.Join(' ', wagons));
                    return;
                }

                int freeSpace = 0;
                freeSpace = 4 - wagons[counter];
                if (freeSpace == 0)
                {
                    counter++;
                    continue;
                }
                if (peopleWaiting >= freeSpace)
                {
                    peopleWaiting = peopleWaiting - freeSpace;
                    wagons[counter] = wagons[counter] + freeSpace;
                }
                else if (peopleWaiting < freeSpace)
                {
                    wagons[counter] = wagons[counter] + peopleWaiting;
                    peopleWaiting = 0;
                }


                counter++;
            }
            if (peopleWaiting == 0 && wagons.Sum() == 4*(wagons.Length))
            {
                Console.WriteLine(string.Join(' ', wagons));
                return;
            }
            if (peopleWaiting == 0)
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(' ', wagons));
                return;
            }
        }
    }
}
