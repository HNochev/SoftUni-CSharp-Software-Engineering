using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (var item in text)
            {
                if (count.ContainsKey(item))
                {
                    count[item]++;
                }
                else
                {
                    count.Add(item, 1);
                }
            }
            foreach (var item in count)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
