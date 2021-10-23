using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"%(?<name>[A-Z][a-z]+)%[^\|\$\%\.]*<(?<product>\w+)>[^\|\$\%\.]*\|(?<quantity>[0-9]+)\|[^\|\$\%\.]*?(?<price>\d+\.?\d+)\$";
            Regex regex = new Regex(pattern);

            double totalMoney = 0;

            while (input != "end of shift")
            {
                Match match = regex.Match(input);

                if(match.Success)
                {
                    string name = match.Groups["name"].ToString();
                    string product = match.Groups["product"].ToString();
                    int quantity = int.Parse(match.Groups["quantity"].ToString());
                    double price = double.Parse(match.Groups["price"].ToString());

                    double sum = quantity * price;
                    totalMoney = totalMoney + sum;

                    Console.WriteLine($"{name}: {product} - {sum:f2}");
                }
                
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalMoney:f2}");
        }
    }
}
