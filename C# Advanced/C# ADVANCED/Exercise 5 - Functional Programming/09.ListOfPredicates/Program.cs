using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, int, bool> filter = (n, d) => n % d == 0;

            for (int i = 1; i <= range; i++)
            {
                if (dividers.All(d => filter(i, d)))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
