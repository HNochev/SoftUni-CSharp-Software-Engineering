using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine()
                .ToCharArray();

            Dictionary<char, int> elements = new Dictionary<char, int>();

            foreach (var character in text)
            {
                if(!elements.ContainsKey(character))
                {
                    elements.Add(character, 0);
                }
                elements[character]++;
            }

            foreach (var item in elements.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
