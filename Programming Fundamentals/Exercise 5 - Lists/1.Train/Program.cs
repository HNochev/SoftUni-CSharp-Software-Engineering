using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .ToUpper()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "END")
            {
                if (input[0] == "ADD")
                {
                    wagons.Add(int.Parse(input[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if(wagons[i] + int.Parse(input[0]) <= maxCapacity)
                        {
                            wagons[i] = wagons[i] + int.Parse(input[0]);
                            break;
                        }
                    }
                }
                input = Console.ReadLine()
                .ToUpper()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
