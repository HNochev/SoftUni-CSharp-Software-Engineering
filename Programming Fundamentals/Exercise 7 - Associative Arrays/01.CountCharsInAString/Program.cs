using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> count = new Dictionary<string, int>();

            for (int i = 0; i < text.Length; i++)
            {
                string word = text[i];
                for (int j = 0; j < text[i].Length; j++)
                {
                    if (count.ContainsKey(word[j].ToString()))
                    {
                        count[word[j].ToString()]++;
                    }
                    else
                    {
                        count.Add(word[j].ToString(), 1);
                    }
                }
            }

            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
