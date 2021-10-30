using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string barcodePattern = @"([\@][#]+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])([\@][#]+)";
            string numberPattern = @"[0-9]";

            Regex barcodeRegex = new Regex(barcodePattern);
            Regex numberRegex = new Regex(numberPattern);

            List<string> validMatches = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();

                Match match = barcodeRegex.Match(barcode);

                if (match.Success)
                {
                    validMatches.Add(match.Groups["barcode"].Value);


                    MatchCollection match1 = numberRegex.Matches(validMatches[0]);
                    if (match1.Count > 0)
                    {
                        Console.WriteLine($"Product group: {string.Join("", match1)}");
                        
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    validMatches.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
