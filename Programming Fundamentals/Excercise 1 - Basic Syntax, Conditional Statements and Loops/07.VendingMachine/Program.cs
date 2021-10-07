using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sumMoney = 0;

            while (input != "Start")
            {
                double money = double.Parse(input);
                bool validMoney = money == 0.1 || money == 0.2 || money == 0.5 || money == 1.00 || money == 2.00;

                if (validMoney)
                {
                    sumMoney = sumMoney + money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }

                input = Console.ReadLine();
            }

            string product = Console.ReadLine();
            double priceProduct = 0;

            while (product != "End")
            {
                switch (product)
                {
                    case "Nuts":
                        {
                            priceProduct = 2.0;
                            break;
                        }
                    case "Water":
                        {
                            priceProduct = 0.7;
                            break;
                        }
                    case "Crisps":
                        {
                            priceProduct = 1.5;
                            break;
                        }
                    case "Soda":
                        {
                            priceProduct = 0.8;
                            break;
                        }
                    case "Coke":
                        {
                            priceProduct = 1.0;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid product");
                            product = Console.ReadLine();
                            continue;
                        }
                }
                if (sumMoney >= priceProduct)
                {
                    sumMoney = sumMoney - priceProduct;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sumMoney:f2}");

        }
    }
}
