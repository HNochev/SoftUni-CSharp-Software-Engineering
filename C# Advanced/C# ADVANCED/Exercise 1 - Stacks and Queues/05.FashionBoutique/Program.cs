using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesRow = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int capacityRack = int.Parse(Console.ReadLine());
            int currCapacity = capacityRack;
            int counter = 1;

            Stack<int> clothes = new Stack<int>(clothesRow);

            while (clothes.Any())
            {
                int cloth = clothes.Pop();
                if(cloth <= currCapacity)
                {
                    currCapacity = currCapacity - cloth;
                }
                else
                {
                    counter++;
                    currCapacity = capacityRack;
                    currCapacity = currCapacity - cloth;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
