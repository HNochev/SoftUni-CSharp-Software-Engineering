using System;

namespace _04._CarToGo
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string klass = "";
            string type = "";
            double price = 0;

            if (budget <= 100)
            {
                klass = "Economy class";
                switch (season)
                {
                    case "Summer":
                        {
                            type = "Cabrio";
                            price = budget * 0.35;
                            break;
                        }
                    case "Winter":
                        {
                            type = "Jeep";
                            price = budget * 0.65;
                            break;
                        }
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                klass = "Compact class";
                switch (season)
                {
                    case "Summer":
                        {
                            type = "Cabrio";
                            price = budget * 0.45;
                            break;
                        }
                    case "Winter":
                        {
                            type = "Jeep";
                            price = budget * 0.80;
                            break;
                        }
                }
            }
            else if (budget > 500)
            {
                klass = "Luxury class";
                switch (season)
                {
                    case "Summer":
                    case "Winter":
                        {
                            type = "Jeep";
                            price = budget * 0.90;
                            break;
                        }
                }
            }
            Console.WriteLine($"{klass}");
            Console.WriteLine($"{type} - {price:f2}");
        }
    }
}
