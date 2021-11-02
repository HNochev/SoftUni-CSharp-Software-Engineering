using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> destionations = new List<string>();
            int travelPoints = 0;

            string pattern = @"(\=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match destionation in matches)
            {
                destionations.Add(destionation.Groups["destination"].Value);
                travelPoints = travelPoints + destionation.Groups["destination"].Value.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destionations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
