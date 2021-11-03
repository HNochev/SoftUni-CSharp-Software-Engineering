using System;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(\||\#)(?<product>[A-Za-z ]+)\1(?<expirationDate>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>[0-9]+)\1";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            int allCalories = 0;
            foreach (Match item in matches)
            {
                allCalories = allCalories + int.Parse(item.Groups["calories"].Value);
            }
            int days = allCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach(Match product in matches)
            {
                Console.WriteLine($"Item: {product.Groups["product"].Value}, Best before: {product.Groups["expirationDate"].Value}, Nutrition: {product.Groups["calories"].Value}");
            }
        }
    }
}
