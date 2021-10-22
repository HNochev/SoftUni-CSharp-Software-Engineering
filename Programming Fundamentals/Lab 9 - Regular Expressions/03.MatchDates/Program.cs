using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();

            string pattern = @"\b(?<day>[0-2][0-9]|3[0-1])([\.\-\/])(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]+)\b";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(date);

            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}
