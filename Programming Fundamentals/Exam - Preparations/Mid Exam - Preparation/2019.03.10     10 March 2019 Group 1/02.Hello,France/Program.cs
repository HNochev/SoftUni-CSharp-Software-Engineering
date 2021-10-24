using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Hello_France
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] itemsToBuy = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double budget = double.Parse(Console.ReadLine());

            List<double> result = new List<double>();
            double profit = 0;

            for (int i = 0; i < itemsToBuy.Length; i++)
            {
                string[] currItem = itemsToBuy[i]
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if(currItem[0] == "Clothes" && double.Parse(currItem[1]) > 50.00)
                {
                    continue;
                }
                else if (currItem[0] == "Shoes" && double.Parse(currItem[1]) > 35.00)
                {
                    continue;
                }
                else if (currItem[0] == "Accessories" && double.Parse(currItem[1]) > 20.50)
                {
                    continue;
                }

                if(budget < double.Parse(currItem[1]))
                {
                    continue;
                }

                budget = budget - double.Parse(currItem[1]);
                profit = profit+ double.Parse(currItem[1]) * 0.4;
                result.Add(double.Parse(currItem[1]));

            }
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i] * 1.40;
            }
            
            double fullSum = result.Sum();
            fullSum = fullSum + budget;

            foreach (var item in result)
            {
                Console.Write($"{item:f2} ");
            }
            Console.WriteLine("");
            Console.WriteLine($"Profit: {profit:f2}");
            if(fullSum >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
