using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            while (input != "buy")
            {
                string[] data = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!products.ContainsKey(data[0]))
                {
                    products.Add(data[0], new List<double> { double.Parse(data[1]), double.Parse(data[2]) });
                }
                else
                {
                    products[data[0]][1] = products[data[0]][1] + double.Parse(data[2]);
                    products[data[0]][0] = double.Parse(data[1]);
                }

                input = Console.ReadLine();
            }

            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value[0] * item.Value[1]):f2}");
            }
        }
    }
}
