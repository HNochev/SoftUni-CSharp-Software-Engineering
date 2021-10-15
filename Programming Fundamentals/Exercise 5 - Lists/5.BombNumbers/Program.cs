using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] specialNumberAndPower = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bombNum = specialNumberAndPower[0];
            int power = specialNumberAndPower[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNum)
                {
                    int startIndex = i - power;
                    int finalIndex = i + power;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (finalIndex > numbers.Count - 1)
                    {
                        finalIndex = numbers.Count - 1;
                    }
                    numbers.RemoveRange(startIndex, finalIndex - startIndex + 1);
                    i = -1;
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
