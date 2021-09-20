using System;
using System.Runtime.ConstrainedExecution;

namespace _13._SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string feedback = Console.ReadLine();
            double pricePerNight = 0;
            double finalPrice = 0;

            int nights = days - 1;

            if(room == "room for one person")
            {
                pricePerNight = 18.00;
                finalPrice = nights * pricePerNight;
            }
            else if (room == "apartment")
            {
                pricePerNight = 25.00;
                finalPrice = nights * pricePerNight;
                if (days < 10)
                {
                    finalPrice = finalPrice - (finalPrice * 0.30);
                }
                else if (days >= 10 && days <= 15)
                {
                    finalPrice = finalPrice - (finalPrice * 0.35);
                }
                else if (days > 15) 
                {
                    finalPrice = finalPrice - (finalPrice * 0.50);
                }
            }
            else if (room == "president apartment")
            {
                pricePerNight = 35.00;
                finalPrice = nights * pricePerNight;
                if (days < 10)
                {
                    finalPrice = finalPrice - (finalPrice * 0.10);
                }
                else if (days >= 10 && days <= 15)
                {
                    finalPrice = finalPrice - (finalPrice * 0.15);
                }
                else if (days > 15)
                {
                    finalPrice = finalPrice - (finalPrice * 0.20);
                }
            }

            if(feedback == "positive")
            {
                finalPrice = finalPrice + (finalPrice * 0.25);
            }
            else if (feedback == "negative")
            {
                finalPrice = finalPrice - (finalPrice * 0.10);
            }

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
