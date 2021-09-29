using System;

namespace _02._BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string trace = Console.ReadLine();
            double juniorsPrice = 0;
            double seniorsPrice = 0;

            switch (trace)
            {
                case "trail":
                    {
                        juniorsPrice = 5.50;
                        seniorsPrice = 7;
                        break;
                    }
                case "cross-country":
                    {
                        juniorsPrice = 8;
                        seniorsPrice = 9.50;
                        if((juniors + seniors) >= 50)
                        {
                            juniorsPrice = juniorsPrice * 0.75;
                            seniorsPrice = seniorsPrice * 0.75;
                        }
                        break;
                    }
                case "downhill":
                    {
                        juniorsPrice = 12.25;
                        seniorsPrice = 13.75;
                        break;
                    }
                case "road":
                    {
                        juniorsPrice = 20;
                        seniorsPrice = 21.50;
                        break;
                    }
            }
            double fullPrice = juniors * juniorsPrice + seniors * seniorsPrice;
            fullPrice = fullPrice * 0.95;

            Console.WriteLine($"{fullPrice:f2}");
        }
    }
}
