using System;

namespace _07._SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string typeGroup = Console.ReadLine();
            int countStudents = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            double price = 0;
            string sport = "";

            switch (season)
            {
                case "Winter":
                    {
                        switch (typeGroup)
                        {
                            case "boys":
                                {
                                    price = 9.60;
                                    sport = "Judo";
                                    break;
                                }
                            case "girls":
                                {
                                    price = 9.60;
                                    sport = "Gymnastics";
                                    break;
                                }
                            case "mixed":
                                {
                                    price = 10;
                                    sport = "Ski";
                                    break;
                                }
                        }
                        break;
                    }
                case "Spring":
                    {
                        switch (typeGroup)
                        {
                            case "boys":
                                {
                                    price = 7.20;
                                    sport = "Tennis";
                                    break;
                                }
                            case "girls":
                                {
                                    price = 7.20;
                                    sport = "Athletics";
                                    break;
                                }
                            case "mixed":
                                {
                                    price = 9.50;
                                    sport = "Cycling";
                                    break;
                                }
                        }
                        break;
                    }
                case "Summer":
                    {
                        switch (typeGroup)
                        {
                            case "boys":
                                {
                                    price = 15;
                                    sport = "Football";
                                    break;
                                }
                            case "girls":
                                {
                                    price = 15;
                                    sport = "Volleyball";
                                    break;
                                }
                            case "mixed":
                                {
                                    price = 20;
                                    sport = "Swimming";
                                    break;
                                }
                        }
                        break;
                    }
            }
            double finalPrice = countStudents * price * nights;
            if (countStudents >= 50)
            {
                finalPrice = finalPrice * 0.50;
            }
            else if (countStudents >= 20 && countStudents < 50)
            {
                finalPrice = finalPrice * 0.85;
            }
            else if (countStudents >= 10 && countStudents < 20)
            {
                finalPrice = finalPrice * 0.95;
            }
            Console.WriteLine($"{sport} {finalPrice:f2} lv.");
        }
    }
}
