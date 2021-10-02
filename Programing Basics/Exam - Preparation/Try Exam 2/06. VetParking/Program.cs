using System;

namespace _06._VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());
            double price = 0;
            double fullprice = 0;

            for (int i = 1; i <= days; i++)
            {
                double dayFullPrice = 0;
                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 1)
                        {
                            price = 2.50;
                            dayFullPrice = dayFullPrice + price;
                        }
                        else
                        {
                            price = 1;
                            dayFullPrice = dayFullPrice + price;
                        }
                    }
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            price = 1.25;
                            dayFullPrice = dayFullPrice + price;
                        }
                        else
                        {
                            price = 1;
                            dayFullPrice = dayFullPrice + price;
                        }
                    }
                }
                Console.WriteLine($"Day: {i} - {dayFullPrice:f2} leva");
                fullprice = fullprice + dayFullPrice;
            }
            Console.WriteLine($"Total: {fullprice:f2} leva");
        }
    }
}
