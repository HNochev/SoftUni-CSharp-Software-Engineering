using System;

namespace _06._EasterDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int clientsCount = int.Parse(Console.ReadLine());
            double price = 0;
            double averageBillPerClient = 0;

            for (int i = 0; i < clientsCount; i++)
            {
                string command = Console.ReadLine();
                int products = 0;
                double fullClientPrice = 0;
                while (command != "Finish")
                {
                    switch (command)
                    {
                        case "basket":
                            {
                                price = 1.50;
                                break;
                            }
                        case "wreath":
                            {
                                price = 3.80;
                                break;
                            }
                        case "chocolate bunny":
                            {
                                price = 7.00;
                                break;
                            }
                    }
                    products++;
                    fullClientPrice = fullClientPrice + price;
                    command = Console.ReadLine();
                }
                if(products%2 ==0)
                {
                    fullClientPrice = fullClientPrice * 0.80;
                }
                averageBillPerClient = averageBillPerClient + fullClientPrice;
                Console.WriteLine($"You purchased {products} items for {fullClientPrice:f2} leva.");
            }
            averageBillPerClient = averageBillPerClient / clientsCount;
            Console.WriteLine($"Average bill per client is: {averageBillPerClient:f2} leva.");
        }
    }
}
