using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            prices = Select(prices, x => x * 1.2m);

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }

        static decimal[] Select(decimal[] array, Func<decimal, decimal> transformer)
        {
            decimal[] newArray = new decimal[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = transformer(array[i]);
            }

            return newArray;
        }
    }
}
