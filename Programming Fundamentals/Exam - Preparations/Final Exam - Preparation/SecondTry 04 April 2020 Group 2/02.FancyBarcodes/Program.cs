using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"\@\#+(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])\@\#+";
            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Match match = regex.Match(barcode);

                string productGroup = string.Empty;
                for (int j = 0; j < barcode.Length; j++)
                {
                    if(Char.IsDigit(barcode[j]))
                    {
                        productGroup = productGroup + barcode[j];
                    }
                }

                if(match.Success)
                {
                    if (productGroup != string.Empty)
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
