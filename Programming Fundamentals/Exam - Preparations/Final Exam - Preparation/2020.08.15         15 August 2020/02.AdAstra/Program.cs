using System;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(\||\#)(?<itemName>[A-Za-z ]+)\1(?<expirationDate>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>[0-9]+)\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            int allCalories = 0;
            int days = 0;

            foreach (Match match in matches)
            {
                allCalories = allCalories + int.Parse(match.Groups["calories"].Value);
            }
            days = allCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["itemName"].Value}, Best before: {item.Groups["expirationDate"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }
        }
    }
}
