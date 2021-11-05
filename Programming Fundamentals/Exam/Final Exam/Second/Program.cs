using System;
using System.Text.RegularExpressions;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                string pattern = @"(\*|\@)(?<tag>[A-Z][a-z]{2,})\1\: \[(?<letter1>[A-Za-z])\]\|\[(?<letter2>[A-z])\]\|\[(?<letter3>[A-z])\]\|$";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(text);

                if(match.Success)
                {
                    char first = match.Groups["letter1"].Value[0];
                    char second = match.Groups["letter2"].Value[0];
                    char third = match.Groups["letter3"].Value[0];

                    Console.WriteLine($"{match.Groups["tag"]}: {(int)first} {(int)second} {(int)third}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
