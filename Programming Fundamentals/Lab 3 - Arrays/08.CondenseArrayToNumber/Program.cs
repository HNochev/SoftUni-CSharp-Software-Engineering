using System;
using System.Linq;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int totalElements = numbers.Count();
            int[] condensed = new int[totalElements-1];
            while (totalElements != 1)
            {
                for (int i = 0; i < numbers.Length-1; i++)
                {
                    condensed[i] = numbers[i] + numbers[i + 1];
                }

                for (int i = 0; i < condensed.Length; i++)
                {
                    numbers[i] = condensed[i];
                }
                totalElements--;
            }
            Console.WriteLine($"{numbers[0]}");
        }
    }
}
