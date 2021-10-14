using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace _4.ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int indexes = int.Parse(Console.ReadLine());
            string[] products = new string[indexes];
            List<string> productsList = new List<string>();

            for (int i = 0; i < indexes; i++)
            {
                products[i] = Console.ReadLine();
                productsList.Add(Console.ReadLine());
            }

            Array.Sort(products);
            productsList.Sort();

            for (int i = 0; i < indexes; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
                Console.WriteLine($"{i + 1}.{productsList[i]}");
            }
        }
    }
}
