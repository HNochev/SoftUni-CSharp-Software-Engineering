using System;
using System.Drawing;

namespace _04._TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string dayNight = Console.ReadLine();

            double finalPriceTaxiDay = 0.70 + 0.79 * km;
            double finalPriceTaxiNight = 0.70 + 0.90 * km;
            double finalPriceBus = 0.09 * km;
            double finalPriceTrain = 0.06 * km;

            switch (dayNight)
            {
                case "day":
                    {
                        if (km < 20)
                        {
                            Console.WriteLine($"{finalPriceTaxiDay:f2}");
                        }
                        else if (km >= 20 && km < 100)
                        {
                            Console.WriteLine($"{finalPriceBus:f2}");
                        }
                        else
                        {
                            Console.WriteLine($"{finalPriceTrain:f2}");
                        }
                        break;
                    }
                case "night":
                    {
                        if (km < 20)
                        {
                            Console.WriteLine($"{finalPriceTaxiNight:f2}");
                        }
                        else if (km >= 20 && km < 100)
                        {
                            Console.WriteLine($"{finalPriceBus:f2}");
                        }
                        else
                        {
                            Console.WriteLine($"{finalPriceTrain:f2}");
                        }
                        break;
                    }
            }
        }
    }
}
