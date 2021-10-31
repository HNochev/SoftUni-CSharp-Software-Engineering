using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<string> words = new List<string>();

            string pattern = @"([@#])(?<firstWord>[A-Za-z]{3,})\1{2}(?<secondWord>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            foreach (Match match in matches)
            {
                if (match.Groups["firstWord"].Value == new string(match.Groups["secondWord"].Value.Reverse().ToArray()))
                {
                    words.Add($"{match.Groups["firstWord"].Value} <=> {match.Groups["secondWord"].Value}");
                }
            }
            if (words.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", words));
            }
        }
    }
}
