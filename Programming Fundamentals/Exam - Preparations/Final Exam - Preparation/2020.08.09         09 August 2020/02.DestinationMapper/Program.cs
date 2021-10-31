using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string places = Console.ReadLine();
            int sum = 0;
            List<string> destinations = new List<string>();

            string pattern = @"(\=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(places);

            foreach (Match item in matches)
            {
                    destinations.Add(item.Groups["destination"].Value);
                    sum = sum + item.Groups["destination"].ToString().Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {sum}");
        }
    }
}
