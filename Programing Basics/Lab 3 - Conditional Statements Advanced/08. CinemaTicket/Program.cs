using System;

namespace _08._CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                    {
                        Console.WriteLine("12");
                        break;
                    }
                case "Wednesday":
                case "Thursday":
                    {
                        Console.WriteLine("14");
                        break;
                    }
                case "Friday":
                    {
                        Console.WriteLine("12");
                        break;
                    }
                case "Saturday":
                case "Sunday":
                    {
                        Console.WriteLine("16");
                        break;
                    }
            }
        }
    }
}
