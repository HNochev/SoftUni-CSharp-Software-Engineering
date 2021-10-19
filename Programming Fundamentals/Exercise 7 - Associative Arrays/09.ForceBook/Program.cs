using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, string> forceUsers = new Dictionary<string, string>();
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            while (input != "Lumpawaroo")
            {
                string symbol = string.Empty;
                List<string> text1 = new List<string>();
                List<string> text2 = new List<string>();


                if (input.Contains("|"))
                {
                    text1 = input
                        .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    symbol = "|";
                }
                if (input.Contains("->"))
                {
                    text2 = input
                         .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                         .ToList();
                    symbol = "->";
                }
                if (symbol == "|")
                {
                    if (!forceUsers.ContainsKey(text1[1]))
                    {
                        forceUsers.Add(text1[1], text1[0]);
                    }
                }
                else if (symbol == "->")
                {
                    if (forceUsers.ContainsKey(text2[0]))
                    {
                        forceUsers[text2[0]] = text2[1];
                    }
                    else
                    {
                        forceUsers.Add(text2[0], text2[1]);
                    }
                    Console.WriteLine($"{text2[0]} joins the {text2[1]} side!");
                }
                input = Console.ReadLine();
            }
            foreach (var item in forceUsers)
            {
                if (!sides.ContainsKey(item.Value))
                {
                    sides.Add(item.Value, new List<string>());
                }
                sides[item.Value].Add(item.Key);
            }
            foreach (var item in sides.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                foreach (var participant in item.Value.OrderBy(x=>x))
                {
                    Console.WriteLine($"! {participant}");
                }
            }
        }
    }
}
