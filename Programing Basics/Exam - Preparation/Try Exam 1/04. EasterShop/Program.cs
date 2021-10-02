using System;

namespace _04._EasterShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double startEggs = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double allSoldEggs = 0 ;

            while (command != "Close")
            {
                double eggsBuySell = double.Parse(Console.ReadLine());
                if (command == "Buy")
                {
                    allSoldEggs = allSoldEggs + eggsBuySell;
                    if (startEggs < eggsBuySell)
                    {
                        Console.WriteLine($"Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {startEggs}.");
                        break;
                    }
                    startEggs = startEggs - eggsBuySell;
                }
                else if (command == "Fill")
                {
                    startEggs = startEggs + eggsBuySell;
                }
                command = Console.ReadLine();
            }
            if(command == "Close")
            {
                Console.WriteLine("Store is closed!");
                Console.WriteLine($"{allSoldEggs} eggs sold.");
            }
        }
    }
}
