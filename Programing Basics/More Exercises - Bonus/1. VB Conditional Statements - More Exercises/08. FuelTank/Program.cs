using System;

namespace _08._FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            bool fuelT = true;
            double liters = double.Parse(Console.ReadLine());

            switch (fuel)
            {
                case "Diesel":
                    {
                        break;
                    }
                case "Gasoline":
                    {
                        break;
                    }
                case "Gas":
                    {
                        break;
                    }
                default:
                    {
                        fuelT = false;
                        Console.WriteLine("Invalid fuel!");
                        break;
                    }
            }
            if(liters>= 25 && fuelT == true)
            {
                Console.WriteLine($"You have enough {fuel.ToLower()}.");
            }
            else if (liters < 25 && fuelT == true)
            {
                Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
            }
        }
    }
}
