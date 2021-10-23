using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @">>(?<furniture>[A-Za-z]+)<<(?<price>[0-9]+\.?(?:[0-9]+)?)!(?<quantity>[0-9]+)";

            Regex regex = new Regex(pattern);

            List<string> items = new List<string>();
            double sum = 0;

            while (input != "Purchase")
            {
                Match matches = regex.Match(input);
                if(regex.IsMatch(input))
                {
                    items.Add(matches.Groups["furniture"].ToString());
                    sum = sum + (double.Parse(matches.Groups["price"].ToString()) * double.Parse(matches.Groups["quantity"].ToString()) );
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Bought furniture:");
            if (items.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, items));
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
