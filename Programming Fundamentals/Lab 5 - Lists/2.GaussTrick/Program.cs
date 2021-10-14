using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gausNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int halfListCount = gausNumbers.Count / 2;

            for (int i = 0; i < halfListCount; i++)
            {
                gausNumbers[i] = gausNumbers[i] + gausNumbers[gausNumbers.Count - 1];
                gausNumbers.RemoveAt(gausNumbers.Count - 1);
            }

            Console.WriteLine(string.Join(' ', gausNumbers));
        }
    }
}
