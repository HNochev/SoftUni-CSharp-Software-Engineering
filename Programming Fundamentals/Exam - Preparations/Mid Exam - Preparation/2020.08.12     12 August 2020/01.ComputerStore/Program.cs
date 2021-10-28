using System;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double finalPriceNoTax = 0;

            while(input != "special" && input != "regular")
            {
                double price = double.Parse(input);
                if(price < 0)
                {
                    Console.WriteLine($"Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }
                finalPriceNoTax = finalPriceNoTax + price;

                input = Console.ReadLine();
            }

            double withTax = finalPriceNoTax * 1.20;
            double tax = withTax - finalPriceNoTax;

            if(input == "special")
            {
                withTax = withTax * 0.90;
            }
            if(withTax == 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {finalPriceNoTax:f2}$");
            Console.WriteLine($"Taxes: {tax:f2}$");
            Console.WriteLine($"-----------");
            Console.WriteLine($"Total price: {withTax:f2}$");
        }
    }
}
