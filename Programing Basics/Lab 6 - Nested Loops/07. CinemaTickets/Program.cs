using System;

namespace _07._CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            double freeSpaces = 0;
            int counter = 0;
            double totalTickets = 0;
            double studentCounter = 0;
            double kidCounter = 0;
            double standardCounter = 0;

            while (movieName != "Finish")
            {
                freeSpaces = double.Parse(Console.ReadLine());

                string category = Console.ReadLine();
                while (category != "End")
                {
                    counter++;
                    switch (category)
                    {
                        case "student":
                            {
                                studentCounter++;
                                break;
                            }
                        case "kid":
                            {
                                kidCounter++;
                                break;
                            }
                        case "standard":
                            {
                                standardCounter++;
                                break;
                            }
                    }
                    if (counter == freeSpaces)
                    {
                        break;
                    }
                    category = Console.ReadLine();
                }
                totalTickets = totalTickets + counter;
                Console.WriteLine($"{movieName} - {counter / freeSpaces * 100:f2}% full.");
                counter = 0;
                movieName = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentCounter / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{standardCounter / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{kidCounter / totalTickets * 100:f2}% kids tickets.");
        }
    }
}
