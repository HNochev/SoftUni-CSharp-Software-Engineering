using System;

namespace _06._TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmMonth = double.Parse(Console.ReadLine());

            double lvKm = 0;

            if(kmMonth <= 5000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        {
                            lvKm = 0.75;
                            break;
                        }
                    case "Summer":
                        {
                            lvKm = 0.90;
                            break;
                        }
                    case "Winter":
                        {
                            lvKm = 1.05;
                            break;
                        }
                }
            }
            else if(kmMonth > 5000 && kmMonth <= 10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        {
                            lvKm = 0.95;
                            break;
                        }
                    case "Summer":
                        {
                            lvKm = 1.10;
                            break;
                        }
                    case "Winter":
                        {
                            lvKm = 1.25;
                            break;
                        }
                }
            }
            else if (kmMonth > 10000 && kmMonth <= 20000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                    case "Summer":
                    case "Winter":
                        {
                            lvKm = 1.45;
                            break;
                        }
                }
            }
            double finalPrice = (kmMonth * lvKm)*4;
            finalPrice = finalPrice * 0.90;

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
