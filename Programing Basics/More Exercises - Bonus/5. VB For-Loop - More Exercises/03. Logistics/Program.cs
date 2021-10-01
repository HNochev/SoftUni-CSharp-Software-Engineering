using System;

namespace _03._Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int countDeliveries = int.Parse(Console.ReadLine());
            double price = 0;
            double finalPrice = 0;
            int allTons = 0;
            double microbus = 0;
            double truck = 0;
            double train = 0;

            for (int i = 0; i < countDeliveries; i++)
            {
                int tons = int.Parse(Console.ReadLine());
                if (tons <= 3)
                {
                    price = 200 * tons;
                    microbus = microbus + tons;
                }
                else if (tons >= 4 && tons <= 11)
                {
                    price = 175 * tons;
                    truck = truck + tons;
                }
                else if (tons >= 12)
                {
                    price = 120 * tons;
                    train = train + tons;
                }
                finalPrice = finalPrice + price;
                allTons = allTons + tons;
            }
            Console.WriteLine($"{finalPrice / allTons:f2}");
            Console.WriteLine($"{microbus/allTons*100:f2}%");
            Console.WriteLine($"{truck/allTons*100:f2}%");
            Console.WriteLine($"{train/allTons*100:f2}%");
        }
    }
}
