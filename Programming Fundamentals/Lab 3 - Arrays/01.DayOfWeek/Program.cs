using System;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            string[] weekDay = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            if (day >= 1 && day <= 7)
            {
                Console.WriteLine($"{weekDay[day - 1]}");
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
