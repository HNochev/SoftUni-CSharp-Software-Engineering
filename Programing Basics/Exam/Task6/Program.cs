using System;
using System.Transactions;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int positionsInRow = int.Parse(Console.ReadLine());
            double priceStrawberries = 3.50;
            double priceBlueberrie = 5.00;
            double finalPrice = 0;

            for (int i = 1; i <= rows; i++)
            {
                if (i % 2 == 1)
                {
                    finalPrice = finalPrice + (positionsInRow * priceStrawberries);
                }
                else if (i % 2 == 0)
                {
                    for (int j = 1; j <= positionsInRow; j++)
                    {
                        if (j % 3 != 0)
                        {
                            finalPrice = finalPrice + priceBlueberrie;
                        }
                    }
                }
            }
            finalPrice = finalPrice * 0.80;
            Console.WriteLine($"Total: {finalPrice:f2} lv.");
        }
    }
}
