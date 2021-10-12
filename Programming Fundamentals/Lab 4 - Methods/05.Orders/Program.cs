using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine($"{ExactPrice(product, quantity):f2}");
        }

        static double ExactPrice(string product, int quantity)
        {
            switch (product)
            {
                case "coffee":
                    {
                        return 1.50 * quantity;
                        break;
                    }
                case "coke":
                    {
                        return 1.40 * quantity;
                        break;
                    }
                case "water":
                    {
                        return 1.00 * quantity;
                        break;
                    }
                case "snacks":
                    {
                        return 2.00 * quantity;
                        break;
                    }
                default:
                    {
                        return 0;
                        break;
                    }
            }
        }
    }
}
